Shader "Custom/Grief" {
	Properties
	{
		_Color ("Color", Color) = (1,1,1,1)
		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, .5)
		_Spec ("Spec", Range (0.01, 1)) = 0.25
		_MainTex ("Texture", 2D) = "white" {}
		_BumpMap ("Bumpmap", 2D) = "bump" {}
		_RimColor ("Rim Color", Color) = (0.26,0.19,0.16,0.0)
		_RimPower ("Rim Power", Range(0.5,8.0)) = 3.0
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		CGPROGRAM
		#pragma surface surf BlinnPhong
		sampler2D _MainTex;
		sampler2D _BumpMap;
		fixed4 _Color;
		half _Spec;
		float4 _RimColor;
		float _RimPower;

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float3 viewDir;
		};

		void surf (Input IN, inout SurfaceOutput o)
		{
			fixed4 tex = tex2D(_MainTex, IN.uv_MainTex); //mostly from Brim of Obscurity, which is based off the Unity RimLighting tutorial
			fixed4 color = tex * _Color;
			o.Albedo = color.rgb;
			o.Gloss = tex.a;
			o.Alpha = color.a;
			o.Specular = _Spec;
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
			half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
			o.Emission = color.rgb * _RimColor.rgb * pow (rim, _RimPower);
		}
		
		ENDCG
	}
	FallBack "Bumped Specular"
}