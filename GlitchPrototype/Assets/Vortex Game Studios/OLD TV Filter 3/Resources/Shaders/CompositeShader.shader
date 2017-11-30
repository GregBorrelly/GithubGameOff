/*
*
* CompositeShader.shader
* Use this file to create a awesome old tv effect.
*
* Version 3.0
*
* Developed by Vortex Game Studios LTDA ME. (http://www.vortexstudios.com)
* Authors:		Alexandre Ribeiro de Sa (@alexribeirodesa)
*				Luiz Fernando Ribeiro de Sa
*
*/

Shader "Vortex Game Studios/Filters/OLD TV Filter/Composite" {
	Properties {
		_MainTex("Base (RGB)", 2D) = "white" {}
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
			float _ScreenWidth;
			float _ScreenHeight;

			fixed _Distortion;
			fixed _Gamma;
			fixed _Artifact;
			fixed _Fringing;

			float _Kernel[3];
			float4 _MainTex_ST;

			struct v2f {
				float4 pos : SV_POSITION;
				half2 uv : TEXCOORD0;
			};

			v2f vert(appdata_img v) {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;
				return o;
			}

			fixed Overlay(float I, float M) {
				I += 0.5;
				M += 0.5;
				return (I * (I + (2 * M)*(1 - I))) -0.5;
			}

			fixed4 frag(v2f i) : SV_Target {
				int even = fmod(abs(i.uv.x / -_ScreenWidth*0.5 + i.uv.y / _ScreenHeight) + 0.5, 2);
				_Distortion = _ScreenWidth*(even - 0.5)*_Distortion;
				fixed4 output = tex2D(_MainTex, i.uv);
				output += tex2D(_MainTex, i.uv + fixed2(_Distortion,0));

				fixed3 yuv = RGB2YUV(output.rgb*0.5); 

				//	video composto
				fixed3 tc = fixed3(0.0, 0.0, 0.0);

				tc += tex2D(_MainTex, i.uv + fixed2(-_ScreenWidth+ _Distortion, 0)).rgb * _Kernel[0];
				tc += tex2D(_MainTex, i.uv + fixed2(_Distortion, 0)).rgb * _Kernel[1];
				tc += tex2D(_MainTex, i.uv + fixed2(_ScreenWidth+ _Distortion, 0)).rgb * _Kernel[2];

				fixed c = RGB2Y(tc);

				if (even > 0)
					c = -c;

				_Artifact = c*_Artifact;
				_Fringing = c*_Fringing;
				
				yuv.r = Overlay(yuv.r, _Artifact);
				yuv.g = Overlay(yuv.g, _Fringing);
				yuv.b = Overlay(yuv.b, _Fringing);

				output.rgb = YUV2RGB(yuv);

				output.a = 1.0;
				return output;
			}
			ENDCG
		}
	}
	
	Fallback off
}
