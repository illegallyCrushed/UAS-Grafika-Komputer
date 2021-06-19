#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;

out VS_OUT {
    vec3 FragPos;
    vec3 Normal;
} vs_out;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    vs_out.FragPos =  vec3(vec4(aPos, 1.0) * model);
    vs_out.Normal = aNormal * mat3(transpose(inverse(model)));
    gl_Position = vec4(aPos, 1.0) * model * view * projection;
}