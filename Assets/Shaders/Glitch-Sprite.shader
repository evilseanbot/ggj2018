// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

//based on https://github.com/anlev/Unity-2D-Sprite-cast-and-receive-shadows
Shader "GGJ/Glitch-Sprite" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		[PerRendererData]_MainTex("Sprite Texture", 2D) = "white" {}
		_Cutoff("Alpha Cutoff", Range(0,1)) = 0.5
		
		[Header(HSV)]
		_Hue("Hue", Range(0,1)) = 0.5
		_Saturation("Saturation", Range(0,1)) = 0.5
		_Value("Value", Range(0,1)) = 0.5

		[Header(Noise)]
		_VertexAmplitude("Vertex Amplitude", Range(0,1)) = 0.5
		_Scale("Scale", float) = 1
		[Toggle]_Billboard("Billboard", float) = 0
		
		[Header(Bend)]
		_BendAxis("Bend Axis (XYZ (0,1))", vector) = (0,1,0,0)
		_BendSpeed("Bend Speed", float) = 1
		_BendPower("Bend Power", vector) = (1,1,1,1)
	}
		SubShader{
		Tags
	{
		"Queue" = "Geometry"
		"RenderType" = "TransparentCutout"
			"DisableBatching" = "True"


	}
		LOD 200

		Cull Off

		CGPROGRAM
		// Lambert lighting model, and enable shadows on all light types
	#pragma surface surf SimpleLambert addshadow fullforwardshadows vertex:vert 

		// Use shader model 3.0 target, to get nicer looking lighting
	#pragma target 3.0
	#include "GGJ-Glitch.cginc"

		sampler2D _MainTex;
		fixed4 _Color;
		fixed _Cutoff;

		float  _Hue;
		float _Saturation;
		float _Value;

		float _VertexAmplitude;
		float  _Scale;
		int _Billboard;


		float3 _BendAxis;
		float _BendSpeed;
		float4 _BendPower;

		struct Input
		{
			float2 uv_MainTex;
		};


		void vert(inout appdata_full v) {
			//v.vertex.xyz += rand(v.vertex + _Time.x * .01f) * .1f;
			float4 worldPos = mul(unity_ObjectToWorld, v.vertex);
			worldPos += rand(v.vertex.xyz + _Time.x) * _VertexAmplitude;//sin(v.vertex.y + _Time.x * 100) * .05f * _VertexAmplitude;
			worldPos = round(worldPos * round(_Scale)) / round(_Scale);
			v.vertex = mul(unity_WorldToObject, worldPos);
			if (_Billboard != 0) {
				// get the camera basis vectors
				float3 forward = -normalize(UNITY_MATRIX_V._m20_m21_m22);
				float3 up = normalize(UNITY_MATRIX_V._m10_m11_m12);
				float3 right = normalize(UNITY_MATRIX_V._m00_m01_m02);

				// rotate to face camera
				float4x4 rotationMatrix = float4x4(right, 0,
					up, 0,
					forward, 0,
					0, 0, 0, 1);

				//float offset = unity_ObjectToWorld._m22 / 2;
				float offset = 0;
				v.vertex = mul(v.vertex + float4(0, offset, 0, 0), rotationMatrix) + float4(0, -offset, 0, 0);
				  v.normal = mul(v.normal, rotationMatrix);
			}
			v.vertex = lerp(v.vertex, mul(v.vertex, rotationMatrix(_BendAxis,_Time.x * _BendSpeed * 360.f)), saturate(abs(v.texcoord.x - .5f)) * _BendPower);
		}

		void surf(Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			
			o.Albedo = c.rgb;
			o.Alpha = c.a;
			clip(o.Alpha - _Cutoff);
		}

		half4 LightingSimpleLambert(SurfaceOutput s, half3 lightDir, half atten) {
			half4 c;
			c.rgb = s.Albedo;
			//c.rgb = s.Albedo * _LightColor0.rgb * (NdotL * atten);
			c.rgb = hsv2rgb(float3(c.r * .5f + _Hue + atten * .5f, c.r * lerp(atten, 1.f, .85f) * _Saturation, c.r * saturate(.5f + atten)* _Value));
			c.a = s.Alpha;
			return c;
		}

		ENDCG
		}
	FallBack "Diffuse"
}