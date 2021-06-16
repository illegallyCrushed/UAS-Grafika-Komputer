#version 330 core

out vec4 outputColor;
uniform vec3 lineColor;

void main(){
	outputColor = vec4(normalize(lineColor),1.0);
}