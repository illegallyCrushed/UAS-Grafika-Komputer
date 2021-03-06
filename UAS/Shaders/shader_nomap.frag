#version 330 core

out vec4 FragColor;

struct Material {
    vec3 ambient;
    vec3 diffuse;
    vec3 emissive;
    vec3 specular;    
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
    sampler2D shadowPlane;
    samplerCube shadowMap;
};


// processed input
in VS_OUT {
    vec3 FragPos;
    vec3 Normal;
} fs_in;

// others
uniform vec3 viewPos;
uniform int globallighting;
uniform int globalshadow;

// lights and material
uniform Material material;
uniform int lightCount;
uniform Light lights[15];

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
    float shadow = 0.0;
    vec3 fragToLight = fragPos - light.position;
    
    float currentDepth = length(fragToLight);
    
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
vec3 CalcDirLight(Light light, vec3 normal, vec3 viewDir)
{

    vec3 lightDir = normalize(-light.direction);
    // diffuse shading
    float diff = max(dot(normal, lightDir), 0.0);
    // specular shading
    vec3 halfwayDir = normalize(lightDir + viewDir);  
    float spec = pow(max(dot(normal, halfwayDir), 0.0), material.shininess);
    // combine results
    vec3 ambient = light.ambient * material.ambient;
    vec3 diffuse = light.diffuse * diff * material.diffuse;
    vec3 specular = light.specular * spec * material.specular;
    
    return (ambient + diffuse + specular);
}

// calculates the color when using a point light.
vec3 CalcPointLight(Light light, vec3 normal, vec3 fragPos, vec3 viewDir)
{
    vec3 lightDir = normalize(light.position - fragPos);
    // diffuse shading
    float diff = max(dot(normal, lightDir), 0.0);
    // specular shading
    vec3 halfwayDir = normalize(lightDir + viewDir);  
    float spec = pow(max(dot(normal, halfwayDir), 0.0), material.shininess);
    // attenuation
    float distance = length(light.position - fragPos);
    float attenuation = 1.0 / (distance * distance);    
    // combine results
    vec3 ambient = light.ambient * material.ambient;
    vec3 diffuse = light.diffuse * diff * material.diffuse;
    vec3 specular = light.specular * spec * material.specular;
    ambient *= attenuation;
    diffuse *= attenuation;
    specular *= attenuation;
   
    return (ambient + diffuse + specular);
}

// calculates the color when using a spot light.
vec3 CalcSpotLight(Light light, vec3 normal, vec3 fragPos, vec3 viewDir)
{
    vec3 lightDir = normalize(light.position - fragPos);
    // diffuse shading
    float diff = max(dot(normal, lightDir), 0.0);
    // specular shading
    vec3 halfwayDir = normalize(lightDir + viewDir);  
    float spec = pow(max(dot(normal, halfwayDir), 0.0), material.shininess);
    // attenuation
    float distance = length(light.position - fragPos);
    float attenuation = 1.0 / (distance * distance);    
    // spotlight intensity
    float theta = dot(lightDir,normalize(-light.direction)); 
    float epsilon = light.innerCutOff - light.outerCutOff;
    float intensity = clamp((theta - light.outerCutOff) / epsilon, 0.0, 1.0);
    // combine results
    vec3 ambient = light.ambient * material.ambient;
    vec3 diffuse = light.diffuse * diff * material.diffuse;
    vec3 specular = light.specular * spec * material.specular;
    ambient *= attenuation * intensity;
    diffuse *= attenuation * intensity;
    specular *= attenuation * intensity;
    
    return (ambient + diffuse + specular);
}

void main()
{    
    
    // init of positional data
    vec3 viewDir = normalize(viewPos - fs_in.FragPos);
    vec3 normal = normalize(fs_in.Normal);

    // start calculating lights
    vec3 result;
    if(globallighting == 1){
        result = vec3(0,0,0);
        for(int i = 0; i < lightCount; i++){
            float shadow;
            if(globalshadow == 1 && lights[i].castShadow == 1){
               shadow = ShadowCalculation(fs_in.FragPos, lights[i])*(1.0-material.ambiance);    
            }else{
                shadow = 0;
            }
            if(lights[i].lightType == 1){
                result += CalcDirLight(lights[i], fs_in.FragPos, viewDir) * (1.0-shadow);
            }else if(lights[i].lightType == 2){
                result += CalcPointLight(lights[i], normal, fs_in.FragPos, viewDir)* (1.0-shadow);    
            }else if(lights[i].lightType == 3){
                result += CalcSpotLight(lights[i], normal, fs_in.FragPos, viewDir)* (1.0-shadow);    
            }
        }
    }else{
        result = material.ambient * material.diffuse;
    }
    FragColor = vec4(result, material.alpha) + vec4(material.emissive,1.0);
}
