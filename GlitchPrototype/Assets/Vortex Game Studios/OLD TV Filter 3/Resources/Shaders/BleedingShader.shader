/*
*
* BleedingShader.shader
* Use this file to create a awesome old tv effect.
*
* Version 3.0
*
* Developed by Vortex Game Studios LTDA ME. (http://www.vortexstudios.com)
* Authors:		Alexandre Ribeiro de Sa (@alexribeirodesa)
*				Luiz Fernando Ribeiro de Sa
*
*/

Shader "Vortex Game Studios/Filters/OLD TV Filter/Bleeding" {
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
			fixed _ScreenWidth;
			fixed _ScreenHeight;
			float _Magnitude;
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

			fixed4 frag(v2f i) : SV_Target {
				//	matriz original:
				//	{ 2.0f / 13.0f, 4.0f / 13.0f, 1.0f / 13.0f, 4.0f / 13.0f, 2.0f / 13.0f };
				float _Kernel[5];
				_Kernel[0] = 0.1538;
				_Kernel[1] = 0.3076;
				_Kernel[2] = 0.0769;
				_Kernel[3] = 0.3076;
				_Kernel[4] = 0.1538;

				fixed4 output = tex2D(_MainTex, i.uv);
				fixed3 yuv = fixed3(0, 0, 0);
				fixed3 rgb = fixed3(0, 0, 0);
				fixed hWidth = _ScreenWidth / 2;

				rgb = tex2D(_MainTex, i.uv + fixed2(-2 * _ScreenWidth - hWidth, 0)).rgb * _Kernel[0];
				rgb += tex2D(_MainTex, i.uv + fixed2(-_ScreenWidth - hWidth, 0)).rgb * _Kernel[1];
				rgb += tex2D(_MainTex, i.uv + fixed2(-hWidth, 0)).rgb * _Kernel[2];
				rgb += tex2D(_MainTex, i.uv + fixed2(_ScreenWidth - hWidth, 0)).rgb * _Kernel[3];
				rgb += tex2D(_MainTex, i.uv + fixed2(2 * _ScreenWidth - hWidth, 0)).rgb * _Kernel[4];

				yuv.r = RGB2Y(output.rgb);
				yuv.g = RGB2U(rgb);
				yuv.b = RGB2V(rgb);

				output.rgb = (output.rgb*(1.0-_Magnitude))+(YUV2RGB(yuv)*_Magnitude);
				output.a = 1.0;
				return output;
			}
			ENDCG
		}
	}
	
	Fallback off
}
