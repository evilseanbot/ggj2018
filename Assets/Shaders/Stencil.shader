// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


Shader "Stencils/StencilMask" {
	Properties{
		_StencilMask("Stencil Mask", Int) = 0
	}
		SubShader{
		Tags{
		"RenderType" = "Opaque"
		"Queue" = "Geometry-100"
	}
		ColorMask 0
		ZWrite on
		Stencil{
		Ref[_StencilMask]
		Comp always
		Pass replace
	}

		Pass{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

		struct appdata {
		float4 vertex : POSITION;
	};

	struct v2f {
		float4 pos : SV_POSITION;
	};

	v2f vert(appdata v) {
		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		return o;
	}

	half4 frag(v2f i) : COLOR{
		return half4(1,1,0,1);
	}
		ENDCG
	}
	}
}

/*
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


Shader "Custom/TransparentShadowCollector"
{
Properties
{
_Scale("Scale", float) = 0.6
_MainTex("Texture", 2D) = "white" {}
}


SubShader
{

Tags{ "Queue" = "AlphaTest" }

Pass
{
Tags{ "LightMode" = "ForwardBase" }
Cull Back
Blend SrcAlpha OneMinusSrcAlpha
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma multi_compile_fwdbase

#include "UnityCG.cginc"
#include "AutoLight.cginc"
#include "GGJ-Glitch.cginc"
uniform float _HueOffset;
sampler2D _MainTex;
float _Scale;
struct v2f
{
float4 pos : SV_POSITION;
float4 uv : TEXCOORD0;
LIGHTING_COORDS(1, 2)
};
v2f vert(appdata_base v)
{
v2f o;
o.pos = UnityObjectToClipPos(v.vertex);
o.uv = float4(v.texcoord.xy, 0, 0);

TRANSFER_VERTEX_TO_FRAGMENT(o);

return o;
}
fixed4 frag(v2f i) : COLOR
{
float attenuation = LIGHT_ATTENUATION(i);
float4 tex = tex2D(_MainTex, i.uv * _Scale + _Time.x);
return fixed4(0, 0, 0, (1 - attenuation));
//return float4(hsv2rgb(float3(_HueOffset * tex.r, .75f, .75f)), (1 - attenuation)*.5f);
}
ENDCG
}

}
Fallback "VertexLit"
}*/