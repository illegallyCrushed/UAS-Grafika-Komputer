#version 330 core

out vec4 FragColor;

struct Material {
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;    
    vec3 emissive;    
    float shininess;
    float alpha;
    float ambiance;
}; 

struct Light {
    // 1 = directional;
    // 2 = point;
    // 3 = specular;
    int lightType;

    // positional
    vec3 position;
    vec3 direction;
	
    // light color
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;

    // spot light cone cutoff
    float innerCutOff;
    float outerCutOff;

    // attenuation
    float constant;
    float linear;
    float quadratic;
    float farPlane;

    // cast shadow 0 : not
    int castShadow;
    samplerCube shadowMap;
};


// processed input
in VS_OUT {
    vec3 FragPos;
    vec3 TangentViewPos;
    vec3 TangentFragPos;
    vec2 TexCoord;
    mat3 TBN;
} fs_in;

// maps
uniform sampler2D diffMap;
uniform sampler2D specMap;
uniform sampler2D normMap;
uniform sampler2D paraMap;
uniform sampler2D ambiMap;
uniform sampler2D emisMap;

// others
uniform vec3 viewPos;
uniform int globallighting;
uniform int globalshadow;
uniform float height_scale;

// lights and materials
uniform Material material;
uniform int lightCount;
uniform Light lights[10];

vec3 gridSamplingDisk[20] = vec3[]
(
   vec3(1, 1,  1), vec3( 1, -1,  1), vec3(-1, -1,  1), vec3(-1, 1,  1), 
   vec3(1, 1, -1), vec3( 1, -1, -1), vec3(-1, -1, -1), vec3(-1, 1, -1),
   vec3(1, 1,  0), vec3( 1, -1,  0), vec3(-1, -1,  0), vec3(-1, 1,  0),
   vec3(1, 0,  1), vec3(-1,  0,  1), vec3( 1,  0, -1), vec3(-1, 0, -1),
   vec3(0, 1,  1), vec3( 0, -1,  1), vec3( 0, -1, -1), vec3( 0, 1, -1)
);

// calculates shadow
float ShadowCalculation(vec3 fragPos, Light light)
{   
    vec3 fragToLight = fragPos - light.position;
    
    float currentDepth = length(fragToLight);
    
    float shadow = 0.0;
    float bias = 0.15;
    int samples = 20;
    float viewDistance = length(viewPos - fragPos);
    float diskRadius = (1.0 + (viewDistance / light.farPlane)) / 25.0;
    for(int i = 0; i < samples; ++i)
    {
        float closestDepth = texture(light.shadowMap, fragToLight + gridSamplingDisk[i] * diskRadius).r;
        closestDepth *= light.farPlane;   
        if(currentDepth - bias > closestDepth)
            shadow += 1.0;
    }
    shadow /= float(samples);
    return shadow;
}

// calculates the color when using a directional light.
vec3 CalcDirLight(Light light, vec3 normal, vec3 fragPos, vec3 viewDir, vec2 TexCoord)
{
    vec3 lightDir = normalize(-light.direction);
    // diffuse shading
    float diff = max(dot(lightDir, normal), 0.0);
    // specular shading
    vec3 halfwayDir = normalize(lightDir + viewDir);  
    float spec = pow(max(dot(halfwayDir, normal), 0.0), material.shininess);
    // combine results
    vec3 ambient = light.ambient * material.ambient * texture(ambiMap, TexCoord).r * texture(diffMap, TexCoord).rgb;
    vec3 diffuse = light.diffuse * diff * material.diffuse * texture(diffMap, TexCoord).rgb;
    vec3 specular = light.specular * spec * material.specular * texture(specMap, TexCoord).r;
    return (ambient + diffuse + specular);
}

// calculates the color when using a point light.
vec3 CalcPointLight(Light light, vec3 normal, vec3 fragPos, vec3 viewDir, vec2 TexCoord)
{
    vec3 lightDir = normalize(light.position - fragPos);
    // diffuse shading
    float diff = max(dot(lightDir, normal), 0.0);
    // specular shading
    vec3 halfwayDir = normalize(lightDir + viewDir);  
    float spec = pow(max(dot(halfwayDir, normal), 0.0), material.shininess);
    // attenuation
    float distance = length(light.position - fragPos);
    float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * (distance * distance));    
    // combine results
    vec3 ambient = light.ambient * material.ambient * texture(ambiMap, TexCoord).r * texture(diffMap, TexCoord).rgb;
    vec3 diffuse = light.diffuse * diff * material.diffuse * texture(diffMap, TexCoord).rgb;
    vec3 specular = light.specular * spec * material.specular * texture(specMap, TexCoord).r;
    ambient *= attenuation;
    diffuse *= attenuation;
    specular *= attenuation;
    
    return (ambient + diffuse + specular);
}

// calculates the color when using a spot light.
vec3 CalcSpotLight(Light light, vec3 normal, vec3 fragPos, vec3 viewDir, vec2 TexCoord)
{
    vec3 lightDir = normalize(light.position - fragPos);
    // diffuse shading
    float diff = max(dot(lightDir, normal), 0.0);
    // specular shading
    vec3 halfwayDir = normalize(lightDir + viewDir);  
    float spec = pow(max(dot(halfwayDir, normal), 0.0), material.shininess);
    // attenuation
    float distance = length(light.position - fragPos);
    float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * (distance * distance));    
    // spotlight intensity
    float theta = dot(normalize(-light.direction), lightDir); 
    float epsilon = light.innerCutOff - light.outerCutOff;
    float intensity = clamp((theta - light.outerCutOff) / epsilon, 0.0, 1.0);
    // combine results
    vec3 ambient = light.ambient * material.ambient * texture(ambiMap, TexCoord).r * texture(diffMap, TexCoord).rgb;
    vec3 diffuse = light.diffuse * diff * material.diffuse * texture(diffMap, TexCoord).rgb;
    vec3 specular = light.specular * spec * material.specular * texture(specMap, TexCoord).r;
    ambient *= attenuation * intensity;
    diffuse *= attenuation * intensity;
    specular *= attenuation * intensity;
   
    return (ambient + diffuse + specular);
}

vec2 ParallaxMapping(vec2 texCoords, vec3 viewDir)
{ 
    const float minLayers = 64.0;
    const float maxLayers = 128.0;
    float numLayers = mix(maxLayers, minLayers, max(dot(vec3(0.0, 0.0, 1.0), viewDir), 0.0));
    
    float layerDepth = 1.0 / numLayers;

    float currentLayerDepth = 0.0;

    vec2 P = viewDir.xy * height_scale; 
    vec2 deltaTexCoords = P / numLayers;    
    vec2 currentTexCoords = texCoords;
    float currentDepthMapValue = texture(paraMap, currentTexCoords).r;
  
    while(currentLayerDepth < currentDepthMapValue)
    {
        currentTexCoords -= deltaTexCoords;
        currentDepthMapValue = texture(paraMap, currentTexCoords).r;  
        currentLayerDepth += layerDepth;  
    }

    vec2 prevTexCoords = currentTexCoords + deltaTexCoords;

    float afterDepth  = currentDepthMapValue - currentLayerDepth;
    float beforeDepth = texture(paraMap, prevTexCoords).r - currentLayerDepth + layerDepth;
 
    float weight = afterDepth / (afterDepth - beforeDepth);
    vec2 finalTexCoords = prevTexCoords * weight + currentTexCoords * (1.0 - weight);
    
    return finalTexCoords;  
} 

void main()
{    
    
    // init of positional data
    vec3 viewDir = normalize(fs_in.TangentViewPos - fs_in.TangentFragPos);
    vec2 TexCoord = ParallaxMapping(fs_in.TexCoord,  viewDir);
    vec3 normal = vec3(texture(normMap, TexCoord));
    normal = normalize(normal * 2.0 - 1.0);
    normal = normalize(fs_in.TBN * normal);

    // start calculating lights
    vec3 result= vec3(0,0,0);
    if(globallighting == 1){
        for(int i = 0; i < lightCount; i++){
            float shadow;
            if(globalshadow == 1 && lights[i].castShadow == 1){
               shadow = ShadowCalculation(fs_in.FragPos, lights[i])*(1.0-material.ambiance);    
            }else{
                shadow = 0;
            }
            if(lights[i].lightType == 1){
                result += CalcDirLight(lights[i], normal, fs_in.FragPos, viewDir, TexCoord) * (1.0-shadow);
            }else if(lights[i].lightType == 2){
                result += CalcPointLight(lights[i], normal, fs_in.FragPos, viewDir, TexCoord)* (1.0-shadow);    
            }else if(lights[i].lightType == 3){
                result += CalcSpotLight(lights[i], normal, fs_in.FragPos, viewDir, TexCoord)* (1.0-shadow);    
            }
        }
    }else{
        result = material.ambient * texture(diffMap, TexCoord).rgb;
    }
    FragColor = vec4(result, material.alpha) + texture(emisMap, TexCoord) + vec4(material.emissive,1.0); 
}
