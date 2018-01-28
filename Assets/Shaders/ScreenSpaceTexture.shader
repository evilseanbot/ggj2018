// based on: http://www.shaderslab.com/demo-92---outline-and-screenspace-texture.html
Shader "GGJ/SS-Texture"
{
	Properties
	{
		[PerRendererData]_MainTex("Sprite Texture", 2D) = "white" {}
		_SSTexture("ScreenSpace Texture", 2D) = "white" {}
		_Zoom("Zoom", Range(0.5, 20)) = 1
		_SpeedX("Speed along X", Range(-1, 1)) = 0
		_SpeedY("Speed along Y", Range(-1, 1)) = 0
	}
	
	SubShader
	{
		Tags{ "Queue" = "Geometry" "RenderType" = "Opaque" }

	Pass
	{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#include "UnityCG.cginc"
		#include "GGJ-Glitch.cginc"

	float4 vert(appdata_base v) : SV_POSITION
	{
		return UnityObjectToClipPos(v.vertex);
	}

	sampler2D _MainTex;
	sampler2D _SSTexture;
	float _Zoom;
	float _SpeedX;
	float _SpeedY;

	fixed4 frag(float4 i : VPOS) : SV_Target
	{
		// Screen space texture
		float4 ssTex = tex2D(_SSTexture, ((i.xy / _ScreenParams.y) + float2(_Time.y * _SpeedX, _Time.y * _SpeedY)) / _Zoom);
		return float4(hsv2rgb(float3(ssTex.r * .25f + _Time.x, ssTex.g * .75f, ssTex.b)).rgb,1);
	}

		ENDCG
	}
	}
}