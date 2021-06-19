#version 330 core

layout(location = 0) in vec3 aPosition;
layout(location = 1) in vec3 aNormal;

uniform mat4 mvp_transform;

void main(void){
	gl_Position = vec4(aPosition, 1.0) * mvp_transform ;
}