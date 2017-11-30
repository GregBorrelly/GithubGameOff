/*
*
* NoiseShader.shader
* Use this file to create a awesome old tv effect.
*
* Version 3.0
*
* Developed by Vortex Game Studios LTDA ME. (http://www.vortexstudios.com)
* Authors:		Alexandre Ribeiro de Sa (@alexribeirodesa)
*
*/

Shader "Vortex Game Studios/Filters/OLD TV Filter/Noise" {
	Properties {
		_MainTex("Base (RGB)", 2D) = "white" {}
		_PatternTex("Pattern (RGB)", 2D) = "white" {}
		_Magnitude("Noise Magnitude", Range(-1.0, 1.0)) = 0.5
	}

	SubShader {
		Pass {
			ZTest Always Cull Off ZWrite Off

			CGPROGRAM
			#pragma target 2.0
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			#include "../../../Common/Shaders/RGB_YUV.cginc"

			uniform sampler2D _MainTex;
			uniform sampler2D _PatternTex;
			uniform fixed _Magnitude;

			float4 _MainTex_ST;

			half _PatternOffsetX;
			half _PatternOffsetY;
			half _PatternScaleX;
			half _PatternScaleY;

			struct v2f {
				float4 pos : SV_POSITION;
				half2 uv : TEXCOORD0;
			};

			fixed Overlay(float I, float M) {
				I += 0.5;
				M += 0.5;
				return (I * (I + (2 * M)*(1 - I))) - 0.5;
			}

			v2f vert(appdata_img v) {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target {
				fixed4 output = tex2D(_MainTex, i.uv);
				fixed3 noise = tex2D(_PatternTex, half2(_PatternOffsetX, _PatternOffsetY) + i.uv * half2(_PatternScaleX, _PatternScaleY)).rgb;

				if( _Magnitude > 0 )
					output.rgb = lerp(output.rgb, noise, _Magnitude);
				else
					output.rgb = lerp(output.rgb, output.rgb*noise, -_Magnitude);

				//fixed4 
				//output = tex2D(_MainTex, i.uv)*(1.0 - _Magnitude);
				//output.rgb *= RGB2Y(tex2D(_PatternTex, half2(_PatternOffsetX, _PatternOffsetY) + i.uv * half2(_PatternScaleX, _PatternScaleY)).rgb * _Magnitude);
				//output.rgb = RGB2YUV(output.rgb);
				//output.g += RGB2U(tex2D(_PatternTex, half2(_PatternOffsetX, _PatternOffsetY) + i.uv * half2(_PatternScaleX, _PatternScaleY)).rgb * _Magnitude);
				//output.b += RGB2V(tex2D(_PatternTex, half2(_PatternOffsetX, _PatternOffsetY) + i.uv * half2(_PatternScaleX, _PatternScaleY)).rgb * _Magnitude);
				//output.rgb = YUV2RGB(output.rgb);
				//output.rgb *= tex2D(_PatternTex, half2(_PatternOffsetX, _PatternOffsetY) + i.uv * half2(_PatternScaleX, _PatternScaleY)).rgb * _Magnitude;
				//output.rgb += (half3(1, 1, 1) - tex2D(_PatternTex, half2(_PatternOffsetX, _PatternOffsetY) + i.uv * half2(_PatternScaleX, _PatternScaleY)).rgb) * _Magnitude;
				//output.rgb += tex2D(_PatternTex, half2(_PatternOffsetX, _PatternOffsetY) + i.uv * half2(_PatternScaleX, _PatternScaleY)).rgb * _Magnitude;
				/*
				if (_Magnitude > 0.0) {
					output = tex2D(_MainTex, i.uv)*(1.0 - _Magnitude);
					//output.rgb *= tex2D(_PatternTex, half2(_PatternOffsetX, _PatternOffsetY) + i.uv * half2(_PatternScaleX, _PatternScaleY)).rgb * _Magnitude;
					output.rgb += tex2D(_PatternTex, half2(_PatternOffsetX, _PatternOffsetY) + i.uv * half2(_PatternScaleX, _PatternScaleY)).rgb * _Magnitude;
				} else {
					_Magnitude = (-_Magnitude);
					//output = tex2D(_MainTex, i.uv) *  (1.0 - _Magnitude);
					//output.rgb += tex2D(_PatternTex, half2(_PatternOffsetX, _PatternOffsetY) + i.uv * half2(_PatternScaleX, _PatternScaleY)).rgb * _Magnitude;
					output = tex2D(_MainTex, i.uv);// *(1.0 - _Magnitude);
					output.rgb *= tex2D(_PatternTex, half2(_PatternOffsetX, _PatternOffsetY) + i.uv * half2(_PatternScaleX, _PatternScaleY)).rgb * _Magnitude;
					output.rgb += (half3(1,1,1)-tex2D(_PatternTex, half2(_PatternOffsetX, _PatternOffsetY) + i.uv * half2(_PatternScaleX, _PatternScaleY)).rgb) * _Magnitude;
				}
				*/

				//output.rgb = lerp(output.rgb, noise, RGB2V(noise)*_Magnitude);

				output.a = 1.0;
				return output;
			}
			ENDCG
		}
	}
	
	Fallback off
}
