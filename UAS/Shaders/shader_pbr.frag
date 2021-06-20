#version 330 core

out vec4 FragColor;

// material parameters
uniform sampler2D albedoMap;
uniform sampler2D normalMap;
uniform sampler2D metallicMap;
uniform sampler2D roughnessMap;
uniform sampler2D aoMap;
uniform sampler2D emisMap;
uniform sampler2D paraMap;

const float PI = 3.14159265359;

struct Light {
    // 1 = directional;
    // 2 = point;
    // 3 = specular;
    int lightType;

    // positional
    vec3 position;
    vec3 direction;
	
    // light color
    vec3 diffuse;

    // spot light cone cutoff
    float innerCutOff;
    float outerCutOff;

    // light farPlane
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


// others
uniform vec3 viewPos;
uniform int globallighting;
uniform int globalshadow;
uniform float height_scale;
uniform float alpha;
uniform float ambiance;

// lights and materials
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

float DistributionGGX(vec3 N, vec3 H, float roughness)
{
    float a = roughness*roughness;
    float a2 = a*a;
    float NdotH = max(dot(H, N), 0.0);
    float NdotH2 = NdotH*NdotH;

    float nom   = a2;
    float denom = (NdotH2 * (a2 - 1.0) + 1.0);
    denom = PI * denom * denom;

    return nom / denom;
}
// ----------------------------------------------------------------------------
float GeometrySchlickGGX(float NdotV, float roughness)
{
    float r = (roughness + 1.0);
    float k = (r*r) / 8.0;

    float nom   = NdotV;
    float denom = NdotV * (1.0 - k) + k;

    return nom / denom;
}
// ----------------------------------------------------------------------------
float GeometrySmith(vec3 N, vec3 V, vec3 L, float roughness)
{
    float NdotV = max(dot(V, N), 0.0);
    float NdotL = max(dot(L, N), 0.0);
    float ggx2 = GeometrySchlickGGX(NdotV, roughness);
    float ggx1 = GeometrySchlickGGX(NdotL, roughness);

    return ggx1 * ggx2;
}
// ----------------------------------------------------------------------------
vec3 fresnelSchlick(float cosTheta, vec3 F0)
{
    return F0 + (1.0 - F0) * pow(max(1.0 - cosTheta, 0.0), 5.0);
}
// ----------------------------------------------------------------------------

// calculates the color when using a directional light.
vec3 CalcDirLight(Light light, vec3 N, vec3 fragPos, vec3 V, vec3 F0,vec3 albedo,float metallic,float roughness,float ao)
{
    vec3 L = normalize(-light.direction);
    vec3 H = normalize(V + L);
    float attenuation = 1.0;
    vec3 radiance = light.diffuse * attenuation;
    
    float NDF = DistributionGGX(N, H, roughness);   
    float G = GeometrySmith(N, V, L, roughness);      
    vec3 F = fresnelSchlick(max(dot(V, H), 0.0), F0);
       
    vec3 numerator = NDF * G * F; 
    float denominator = 4 * max(dot(V, N), 0.0) * max(dot(L, N), 0.0) + 0.001;
    vec3 specular = numerator / denominator;
    
    vec3 kS = F;
    vec3 kD = vec3(1.0) - kS;
    kD *= 1.0 - metallic;	  
    
    float NdotL = max(dot(L, N), 0.0);        
    
    return (kD * albedo / PI + specular) * radiance * NdotL;
}

// calculates the color when using a point light.
vec3 CalcPointLight(Light light, vec3 N, vec3 fragPos, vec3 V, vec3 F0,vec3 albedo,float metallic,float roughness,float ao)
{
    vec3 L = normalize(light.position - fragPos);
    vec3 H = normalize(V + L);
    float distance = length(light.position - fragPos);
    float attenuation = 1.0 / (distance * distance);
    vec3 radiance = light.diffuse * attenuation;
    
    float NDF = DistributionGGX(N, H, roughness);   
    float G = GeometrySmith(N, V, L, roughness);      
    vec3 F = fresnelSchlick(max(dot(V, H), 0.0), F0);
       
    vec3 numerator = NDF * G * F; 
    float denominator = 4 * max(dot(V, N), 0.0) * max(dot(L, N), 0.0) + 0.001;
    vec3 specular = numerator / denominator;
    
    vec3 kS = F;
    vec3 kD = vec3(1.0) - kS;
    kD *= 1.0 - metallic;	  
    
    float NdotL = max(dot(L, N), 0.0);        
    
    return (kD * albedo / PI + specular) * radiance * NdotL;
}

// calculates the color when using a spot light.
vec3 CalcSpotLight(Light light, vec3 N, vec3 fragPos, vec3 V, vec3 F0,vec3 albedo,float metallic,float roughness,float ao)
{                   
    vec3 L = normalize(light.position - fragPos);
    vec3 H = normalize(V + L);
    float distance = length(light.position - fragPos);
    float attenuation = 1.0 / (distance * distance);

    // spotlight intensity
    float theta = dot(normalize(-light.direction), L); 
    float epsilon = light.innerCutOff - light.outerCutOff;
    float intensity = clamp((theta - light.outerCutOff) / epsilon, 0.0, 1.0);
    
    vec3 radiance = light.diffuse * attenuation * intensity;
    
    float NDF = DistributionGGX(N, H, roughness);   
    float G = GeometrySmith(N, V, L, roughness);      
    vec3 F = fresnelSchlick(max(dot(V, H), 0.0), F0);
       
    vec3 numerator = NDF * G * F; 
    float denominator = 4 * max(dot(V, N), 0.0) * max(dot(L, N), 0.0) + 0.001;
    vec3 specular = numerator / denominator;
    
    vec3 kS = F;
    vec3 kD = vec3(1.0) - kS;
    kD *= 1.0 - metallic;	  
    
    float NdotL = max(dot(L, N), 0.0);        
    
    return (kD * albedo / PI + specular) * radiance * NdotL;
}

void main()
{		
    // init of positional data
    vec3 V = normalize(fs_in.TangentViewPos - fs_in.TangentFragPos);
    vec2 TexCoords = ParallaxMapping(fs_in.TexCoord,  V);
    vec3 N = vec3(texture(normalMap, TexCoords));
    N = normalize(N * 2.0 - 1.0);
    N = normalize(fs_in.TBN * N);

    vec3 emission = texture(emisMap, TexCoords).rgb;
    vec3 albedo     = pow(texture(albedoMap, TexCoords).rgb, vec3(2.2));
    float metallic  = texture(metallicMap, TexCoords).r;
    float roughness = texture(roughnessMap, TexCoords).r;
    float ao        = texture(aoMap, TexCoords).r;

    vec3 F0 = vec3(0.04); 
    F0 = mix(F0, albedo, metallic);

    vec3 Lo = vec3(0.0);
    if(globallighting == 1){
        for(int i = 0; i < lightCount; i++){
            float shadow;
            if(globalshadow == 1 && lights[i].castShadow == 1){
               shadow = ShadowCalculation(fs_in.FragPos, lights[i])*ambiance;    
            }else{
                shadow = 0;
            }
            if(lights[i].lightType == 1){
                Lo += CalcDirLight(lights[i], N, fs_in.FragPos, V, F0, albedo, metallic, roughness, ao) * (1.0-shadow);
            }else if(lights[i].lightType == 2){
                Lo += CalcPointLight(lights[i], N, fs_in.FragPos, V, F0, albedo, metallic, roughness, ao)* (1.0-shadow);    
            }else if(lights[i].lightType == 3){
                Lo += CalcSpotLight(lights[i], N, fs_in.FragPos, V, F0, albedo, metallic, roughness, ao)* (1.0-shadow);    
            }
        }
    }else{
        Lo = texture(albedoMap, TexCoords).rgb;
    }
    
    // ambient lighting (note that the next IBL tutorial will replace 
    // this ambient lighting with environment lighting).
    vec3 ambient = vec3(0.03) * albedo * ao;
    
    vec3 color = ambient + Lo;

    // HDR tonemapping
    color = color / (color + vec3(1.0));
    // gamma correct
    color = pow(color, vec3(1.0/2.2)); 

    FragColor = vec4(color, alpha) + vec4(emission, 1.0); 
}


