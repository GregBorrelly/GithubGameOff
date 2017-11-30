/*
*
* OLDTVFilter_Tube.shader
* Use this file to create a awesome old tv effect.
*
* Version 2.1
*
* Developed by Vortex Game Studios LTDA ME. (http://www.vortexstudios.com)
* Authors:		Alexandre Ribeiro de Sa (@alexribeirodesa)
*
*/

Shader "Vortex Game Studios/Filters/OLD TV Tube Effect" {
	Properties {
		_MainTex("Base (RGB)", 2D) = "white" {}
		_ScreenHorizontal("Screen Horizontal Orientation", float) = 1.0

		// Scanline
		_ScanLine("ScanLine (RGB)", 2D) = "white" {}
		_ScanLineCount("ScanLine Count (Resolution Size)", float) = 100
		_ScanLineMin("ScanLine Min", float) = 0.0
		_ScanLineMax("ScanLine Max", float) = 1.0

		// Tube
		_MaskTex("Mask (RGB)", 2D) = "white" {}
		_ReflexTex("Reflex (RGB)", 2D) = "black" {}
		_ReflexMagnetude("Reflex Magnetude", Range(0.0, 1.0)) = 0.5

		// Distortion
		_Distortion("Distortion", Range(-1.0, 1.0)) = 0.1
	}

	SubShader {
		Pass {
			ZTest Always Cull Off ZWrite Off

			CGPROGRAM
			#pragma target 2.0
			#pragma vertex vert_img
			#pragma fragment frag
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform fixed _ScreenHorizontal;

			sampler2D _ScanLine;
			fixed _ScanLineCount;
			fixed _ScanLineMin;
			fixed _ScanLineMax;

			sampler2D _MaskTex;							// The TV rounded corner mask;
			sampler2D _ReflexTex;						// The TV Reflex on the screen;
			fixed _ReflexMagnetude;						// The TV Reflex on the screen magnetude;

			fixed _Distortion;

			// Tube radial distortion
			fixed2 radialDistortion(fixed2 uv) {
				fixed2 cc = uv - 0.5;
				fixed dt = dot(cc, cc)*_Distortion;

				return uv + cc*(1.0 + dt)*dt;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				fixed4 output;
			
				// Tube Distortion
				// Just a gohorse to keep the screen... on screen xD when you distort the screen)
				if (_Distortion != 0.0) {
					fixed minSize = _Distortion * 0.098;
					fixed maxSize = 1.0 - (minSize);

					i.uv *= (maxSize - minSize);
					i.uv += minSize;

					i.uv = radialDistortion(i.uv);
				}

				if (i.uv.x < 0.0 || i.uv.x > 1.0 || i.uv.y < 0.0 || i.uv.y > 1.0) {
					return float4(0.0, 0.0, 0.0, 1.0);
				}

				//_ScreenHorizontal = 1.0;

				// Scanline Stuff
				fixed scanLine = 1.0;

				if(_ScanLineCount > 0) {
					scanLine = tex2D(_ScanLine, i.uv*_ScanLineCount).g;
					scanLine *= (_ScanLineMax - _ScanLineMin);
					scanLine += _ScanLineMin;
				}
				output.rgb = tex2D(_MainTex, i.uv) * scanLine;

				// Tube mask and reflex
				fixed3 tubeMask = tex2D(_MaskTex, i.uv).rgb;
				fixed3 tubeReflex = tex2D(_ReflexTex, i.uv).rgb * _ReflexMagnetude;
				tubeReflex = tubeReflex*(1.0 - ((output.r + output.g + output.b) / 3.0));
				output.rgb = (output.rgb + tubeReflex) * tubeMask;

				output.a = 1.0;
				return output;
			}
			ENDCG
		}
	}
	
	Fallback off
}
