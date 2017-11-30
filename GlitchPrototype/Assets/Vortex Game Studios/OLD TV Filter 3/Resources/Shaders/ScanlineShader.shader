/*
*
* ScablineShader.shader
* Use this file to create a awesome old tv effect.
*
* Version 3.0
*
* Developed by Vortex Game Studios LTDA ME. (http://www.vortexstudios.com)
* Authors:		Alexandre Ribeiro de Sa (@alexribeirodesa)
*
*/

Shader "Vortex Game Studios/Filters/OLD TV Filter/Scanline" {
	Properties {
		_MainTex("Base (RGB)", 2D) = "white" {}
		_PatternTex("Pattern (RGB)", 2D) = "white" {}
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
			
			int _ScreenWidth;
			int _ScreenHeight;
			half _Magnitude;

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
				fixed3 scanLine = 1.0;
				fixed4 output;
				output = tex2D(_MainTex, i.uv);
				
				output.r = clamp(output.r, 0, 0.95);
				output.g = clamp(output.g, 0, 0.95);
				output.b = clamp(output.b, 0, 0.95);

				if (_ScreenHeight > 0 ) {
					scanLine = tex2D(_PatternTex, i.uv * fixed2(_ScreenWidth, _ScreenHeight)).rgb;

					//half over = scanLine + RGB2Y(output.rgb);
					//output.rgb *= over;
					/*
					half over = RGB2Y(output.rgb);// *1.0;
					float bunda = (1 - over*over*over)*(0.75*(1 - _Magnitude));
					//output.rgb = lerp(output.rgb, (output.rgb-0.5)*scanLine, (0.9 - RGB2Y(output.rgb)*RGB2Y(output.rgb)*RGB2Y(output.rgb))*_Magnitude);
					//output.rgb = (RGB2Y(output.rgb)*0.5)*(RGB2Y(output.rgb)*0.5);// ((1.0 - RGB2Y(output.rgb)*0.5)*(-_Magnitude));
					output.rgb = lerp(output.rgb, output.rgb*(scanLine*(over*over*over*0.75)), _Magnitude);
					//output.rgb = ;
					*/
					
					scanLine *= (1.0 - _Magnitude);
					scanLine += _Magnitude;
					
					
					//	isso aqui deixa tudo AWESOME!!
					half over = RGB2Y(output.rgb);

					scanLine = RGB2YUV(scanLine);
					scanLine.r += (over*over*over)*(0.75*(1-_Magnitude));// ((over*over*over)*(0.25 *(1 - _Magnitude)));
					if(scanLine.r > 1) scanLine.r = 1;
					scanLine = YUV2RGB(scanLine);

					output.rgb *= scanLine;
					
				}

				output.a = 1.0;
				return output;
			}
			ENDCG
		}
	}
	
	Fallback off
}
