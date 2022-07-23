shader_type canvas_item;
uniform vec4 color=vec4(1,1,1,1); 

 float nrand(vec2 co){
    return fract(sin(dot(co.xy ,vec2(12.9898,78.233))) * 43758.5453);
}

 float rand(){
	vec2 co=vec2(TIME,0.0);
    return fract(sin(dot(co.xy ,vec2(12.9898,78.233))) * 43758.5453);
}

void fragment(){
  

vec4 tex=texture(TEXTURE,UV);

if(tex.a>0.0){
	float a=nrand(vec2(TIME+UV.x,TIME+UV.y));
	
	
	COLOR = vec4(a,a,a, 1.0);
}
else{
	COLOR = vec4(0,0,0,0)
}

}

