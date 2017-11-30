/*
*
* TubeShader.shader
* Use this file to create a awesome old tv effect.
*
* Version 3.0
*
* Developed by Vortex Game Studios LTDA ME. (http://www.vortexstudios.com)
* Authors:		Alexandre Ribeiro de Sa (@alexribeirodesa)
*
*/

Shader "Vortex Game Studios/Filters/OLD TV Filter/Tube" {
	Properties {
		_MainTex("Base (RGB)", 2D) = "white" {}
		_MaskTex("Mask Pattern (RGB)", 2D) = "white" {}
		_ReflexTex("Reflex Pattern (RGB)", 2D) = "black" {}
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
			uniform sampler2D _MaskTex;
			uniform sampler2D _ReflexTex;
			uniform fixed _Distortion;
			uniform fixed _Reflex;

			float4 _MainTex_ST;
			float4 _MaskTex_ST;
			float4 _ReflexTex_ST;
			//half ;

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

			fixed2 radialDistortion(fixed2 uv) {
				fixed2 cc = uv - 0.5;
				fixed dt = dot(cc, cc)*_Distortion;
				dt -= 0.2 * _Distortion;
				return uv + cc*(1.0 + dt)*dt;
			}

			fixed4 frag(v2f i) : SV_Target {
				fixed4 output;
				i.uv = radialDistortion(i.uv);
				if (i.uv.x < 0.0025 || i.uv.x > 0.9975 || i.uv.y < 0.0025 || i.uv.y > 0.9975) {
					return float4(0.0, 0.0, 0.0, 1.0);
				}

				output = tex2D(_MainTex, i.uv);
				fixed3 r = tex2D(_ReflexTex, i.uv).rgb * _Reflex * (1.0-RGB2Y(output.rgb));
				output.rgb = (output.rgb + r) * tex2D(_MaskTex, i.uv).rgb;
				output.a = 1.0;
				return output;
			}
			ENDCG
		}
	}
	
	Fallback off
}
