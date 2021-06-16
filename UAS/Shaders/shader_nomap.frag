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

uniform samplerCube depthMap;

in VS_OUT {
    vec3 FragPos;
    vec3 Normal;
} fs_in;

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
    float bias = 0.1;
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
    vec3 normal = normalize(fs_in.Normal);

    vec3 ambient = light.ambient * material.ambient;

    vec3 lightDir = normalize(light.position - fs_in.FragPos);
    float diff = max(dot(lightDir, normal), 0.0);
    vec3 diffuse = light.diffuse * (diff * material.diffuse);

    vec3 viewDir = normalize(viewPos - fs_in.FragPos);
    vec3 reflectDir = reflect(-lightDir, normal);
    vec3 halfwayDir = normalize(lightDir + viewDir);  
    float spec = pow(max(dot(halfwayDir, normal), 0.0), material.shininess);
    vec3 specular = light.specular * (spec * material.specular);  
    
    float shadow = shadowenable==1 ? ShadowCalculation(fs_in.FragPos) : 0.0;                      

    vec3 result;
    if(simple == 1)
        result = vec3(1,1,1) * (1.0 - shadow*alpha) * material.ambient ;
    else if(simple == 2)
        result = ambient + (1.0 - shadow*alpha) * diffuse;
    else if (simple == 3)
        result = (ambient + (1.0 - shadow*alpha) * ( diffuse + specular));
        
    FragColor = vec4(result, alpha);
}