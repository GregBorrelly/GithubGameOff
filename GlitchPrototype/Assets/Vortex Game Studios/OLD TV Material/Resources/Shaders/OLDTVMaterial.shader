/*
*
* OLDTVMaterial.shader
* Use this file to create a old tv effect material.
*
* Version 1.0
*
* Developed by Vortex Game Studios LTDA ME. (http://www.vortexstudios.com)
* Authors:		Alexandre Ribeiro de Sa (@alexribeirodesa)
*
*/

Shader "Vortex Game Studios/Materials/OLD TV Filter/Standard" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0

		//CustomEditor( "Screen Resolution" )
		_ScreenWidth("Screen Width", float) = 320.0
		_ScreenHeight("Screen Height", float) = 240.0

		_Brightness("Brightness", Range(-1,1)) = 0.0
		_Contrast("Contrast", Range(-1,1)) = 0.0
		_Saturation("Saturation", Range(0,1)) = 0.0

		//CustomEditor "Television"
		_CompositeDistortion("Composite Distortion", Range(0,1)) = 0.125

		//CustomEditor "Noise and Static"
		_NoiseTex("Noise (RGB)", 2D) = "white" {}
		_NoiseMagnitude("Noise Magniture", Range(-1,1)) = 0.25

		_StaticMaskTex("Static Mask (RGB)", 2D) = "black" {}
		_StaticTex("Static (RGB)", 2D) = "black" {}
		_StaticDistortionMagnitude("Static Distortion Magniture", Range(0,1)) = 0.16
		_StaticDirtMagnitude("Static Dirt Magniture", Range(0,1)) = 0.64


		//CustomEditor "Scanline"
		_ScanlineTex("Scanline (RGB)", 2D) = "white" {}
		_ScanlineMagnitude("Scanline Magniture", Range(0,1)) = 0.75

		_MaskTex("Mask (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }

		LOD 200
		CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma surface surf Standard fullforwardshadows
			#include "../../../Common/Shaders/RGB_YUV.cginc"

			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0

			sampler2D _MainTex;

			//	composite
			fixed _CompositeDistortion;

			//	television
			float _ScreenWidth;
			float _ScreenHeight;
			float _Brightness;
			float _Contrast;
			float _Saturation;

			//	scanline
			sampler2D _ScanlineTex;
			half _ScanlineMagnitude;

			//	noise
			sampler2D _NoiseTex;
			half _NoiseMagnitude;

			//	static/dirt
			sampler2D _StaticMaskTex;
			sampler2D _StaticTex;
			half _StaticDistortionMagnitude;
			half _StaticDirtMagnitude;

			//	mask
			sampler2D _MaskTex;

			struct Input {
				float2 uv_MainTex;
				float2 uv_ScanlineTex;
				float2 uv_NoiseTex;
				float2 uv_StaticMaskTex;
			};

			half _Glossiness;
			half _Metallic;
			fixed4 _Color;

			// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
			// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
			// #pragma instancing_options assumeuniformscaling
			UNITY_INSTANCING_CBUFFER_START(Props)
				// put more per-instance properties here
			UNITY_INSTANCING_CBUFFER_END

			float Random(float min, float max ) {
				if (min > max)
					return 1;

				float cap = max - min;
				float rand = tex2D(_NoiseTex, float2(_Time.w, _Time.x)).r * cap + min;
				return rand;
			}

			void surf(Input IN, inout SurfaceOutputStandard o) {
				float os = Random(-1.0, 1.0);// _Time.y*(_CosTime.w + _Time.x);

				fixed staticMask = tex2D(_StaticMaskTex, float2(os, IN.uv_StaticMaskTex.y));
				half staticOffset = (RGB2Y(tex2D(_StaticTex, float2(os,IN.uv_MainTex.y)).rgb)-0.5)*staticMask*(_StaticDistortionMagnitude*_StaticDistortionMagnitude);

				fixed4 output = tex2D(_MainTex, IN.uv_MainTex+float2(staticOffset, 0.0));
				if (_CompositeDistortion > 0.0) {
					output += tex2D(_MainTex, IN.uv_MainTex + float2(staticOffset + _CompositeDistortion / _ScreenWidth*sin((IN.uv_MainTex.y*6.28318531)*_ScreenHeight), 0.0));
					output *= 0.5;
				}

				if (_StaticDirtMagnitude > 0.0)
					output.rgb += tex2D(_StaticTex, IN.uv_MainTex + float2(os, 0.0)).rgb * staticMask * _StaticDirtMagnitude;

				output *= _Color;

				//	noise
				if (_NoiseMagnitude != 0.0) {
					fixed3 noise = tex2D(_NoiseTex, IN.uv_NoiseTex + float2(os, os));
					if (_NoiseMagnitude > 0)
						output.rgb = lerp(output.rgb, noise, _NoiseMagnitude);
					else
						output.rgb = lerp(output.rgb, output.rgb*noise, -_NoiseMagnitude);
				}

				//	television
				output.r = clamp(output.r, 0, 1.0);
				output.g = clamp(output.g, 0, 1.0);
				output.b = clamp(output.b, 0, 1.0);

				_Contrast = _Contrast + 1.0;
				float cs = _Contrast * _Saturation;
				fixed3 yuv = RGB2YUV(output.rgb);
				yuv.r = ((yuv.r - 0.062745) * _Contrast) + _Brightness + 0.062745;
				yuv.g *= cs;
				yuv.b *= cs;

				output.rgb = YUV2RGB(yuv);
				output.r = clamp(output.r, 0, 1.0);
				output.g = clamp(output.g, 0, 1.0);
				output.b = clamp(output.b, 0, 1.0);

				//	scanline
				if (_ScanlineMagnitude > 0.0) {
					_ScanlineMagnitude = 1.0 - _ScanlineMagnitude;
					fixed3 scanLine = tex2D(_ScanlineTex, IN.uv_ScanlineTex * fixed2(_ScreenWidth, _ScreenHeight)).rgb;
					//scanLine *= (1.0 - _ScanlineMagnitude);
					scanLine += _ScanlineMagnitude;

					half over = RGB2Y(output.rgb);

					scanLine = RGB2YUV(scanLine);
					scanLine.r += (over*over*over)*(0.75*(1 - _ScanlineMagnitude));// ((over*over*over)*(0.25 *(1 - _Magnitude)));
					if (scanLine.r > 1) scanLine.r = 1;
					scanLine = YUV2RGB(scanLine);

					output.rgb *= scanLine;
				}

				o.Albedo = output.rgb * tex2D(_MaskTex, IN.uv_MainTex).g;
				// Metallic and smoothness come from slider variables
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness * (1.0 - RGB2Y(o.Albedo));
				o.Alpha = output.a;
			}
		ENDCG
	}
	FallBack "Diffuse"
}
