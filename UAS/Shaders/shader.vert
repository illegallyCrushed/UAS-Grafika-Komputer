#version 330 core
layout (location = 0) in vec3 aPosition;
layout (location = 1) in vec3 aNormal;
layout (location = 2) in vec3 aTangent;
layout (location = 3) in vec3 aBitangent;
layout (location = 4) in vec2 aTexCoord;

out VS_OUT {
    vec3 FragPos;
    vec3 TangentViewPos;
    vec3 TangentFragPos;
    vec2 TexCoord;
    mat3 TBN;
} vs_out;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

uniform vec3 viewPosB;

void main()
{
    mat3 trainvmodel = mat3(transpose(inverse(model)));

    vs_out.FragPos = vec3(vec4(aPosition, 1.0) * model);
    vs_out.TexCoord = aTexCoord;

    vec3 T = aTangent * trainvmodel;
    vec3 B = aBitangent * trainvmodel;
    vec3 N = aNormal * trainvmodel;

    vs_out.TBN = mat3(T,B,N);

    vs_out.TangentViewPos  = viewPosB * vs_out.TBN;
    vs_out.TangentFragPos  = vs_out.FragPos * vs_out.TBN;

    gl_Position = vec4(aPosition, 1.0) * model * view * projection;
}
