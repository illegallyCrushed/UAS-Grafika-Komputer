#version 330 core

out vec4 outputColor;
uniform vec3 flatColor;

void main(){
	outputColor = vec4(normalize(flatColor),1.0);
}