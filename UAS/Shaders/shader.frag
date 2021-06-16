#version 330 core

out vec4 FragColor;

struct Material {
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;    
    float shininess;
}; 

struct Light {
    vec3 position;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

uniform vec3 viewPos;
uniform Material material;
uniform Light light;
uniform int simple;
uniform int shadowenable;
uniform float alpha;
uniform float far_plane;

uniform float height_scale;

uniform samplerCube depthMap;
uniform sampler2D diffMap;
uniform sampler2D specMap;
uniform sampler2D normMap;
uniform sampler2D paraMap;
uniform sampler2D ambiMap;

in VS_OUT {
    vec3 FragPos;
    vec3 TangentLightPos;
    vec3 TangentViewPos;
    vec3 TangentFragPos;
    vec2 TexCoord;
    mat3 TBN;
} fs_in;

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

vec3 gridSamplingDisk[20] = vec3[]
(
   vec3(1, 1,  1), vec3( 1, -1,  1), vec3(-1, -1,  1), vec3(-1, 1,  1), 
   vec3(1, 1, -1), vec3( 1, -1, -1), vec3(-1, -1, -1), vec3(-1, 1, -1),
   vec3(1, 1,  0), vec3( 1, -1,  0), vec3(-1, -1,  0), vec3(-1, 1,  0),
   vec3(1, 0,  1), vec3(-1,  0,  1), vec3( 1,  0, -1), vec3(-1, 0, -1),
   vec3(0, 1,  1), vec3( 0, -1,  1), vec3( 0, -1, -1), vec3( 0, 1, -1)
);

float ShadowCalculation(vec3 fragPos)
{
    vec3 fragToLight = fragPos - light.position;
    
    float currentDepth = length(fragToLight);
    
    float shadow = 0.0;
    float bias = 0.15;
    int samples = 25;
    float viewDistance = length(viewPos - fragPos);
    float diskRadius = (1.0 + (viewDistance / far_plane)) / 25.0;
    for(int i = 0; i < samples; ++i)
    {
        float closestDepth = texture(depthMap, fragToLight + gridSamplingDisk[i] * diskRadius).r;
        closestDepth *= far_plane;   
        if(currentDepth - bias > closestDepth)
            shadow += 1.0;
    }
    shadow /= float(samples);
        
        
    return shadow;
}

void main()
{           
    vec3 viewDir = normalize(fs_in.TangentViewPos - fs_in.TangentFragPos);
    vec2 TexCoord = ParallaxMapping(fs_in.TexCoord,  viewDir);
    //if(TexCoord.x > 1.0 || TexCoord.y > 1.0 || TexCoord.x < 0.0 || TexCoord.y < 0.0)
     //    discard;

    vec3 normal = vec3(texture(normMap, TexCoord));
    normal = normalize(normal * 2.0 - 1.0);
    normal = normalize(fs_in.TBN * normal); 

    vec3 ambient = light.ambient * material.ambient * texture(ambiMap, TexCoord).r;

    vec3 lightDir = normalize(light.position - fs_in.FragPos);
    float diff = max(dot(lightDir, normal), 0.0);
    vec3 diffuse = light.diffuse * (diff * material.diffuse);

    vec3 reflectDir = normalize(-lightDir - 2.0 * normal * dot(-lightDir, normal));
    vec3 halfwayDir = normalize(lightDir + viewDir);  
    float spec = pow(max(dot(halfwayDir, normal), 0.0), material.shininess);
    vec3 specular = light.specular * (spec * material.specular) * texture(specMap, TexCoord).r;
    
    float shadow = shadowenable==1 ? ShadowCalculation(fs_in.FragPos) : 0.0;                      

    vec3 result;
    if(simple == 1)
        result = vec3(1,1,1) * (1.0 - shadow*alpha) * material.ambient;
    else if(simple == 2)
        result = ambient + (1.0 - shadow*alpha) * diffuse;
    else if (simple == 3)
        result = (ambient + (1.0 - shadow*alpha) * (diffuse + specular));
        
    FragColor =  vec4(result, alpha) * texture(diffMap, TexCoord);
}