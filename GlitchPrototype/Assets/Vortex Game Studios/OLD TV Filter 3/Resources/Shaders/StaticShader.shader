/*
*
* StaticShader.shader
* Use this file to create a awesome old tv effect.
*
* Version 3.0
*
* Developed by Vortex Game Studios LTDA ME. (http://www.vortexstudios.com)
* Authors:		Alexandre Ribeiro de Sa (@alexribeirodesa)
*
*/

Shader "Vortex Game Studios/Filters/OLD TV Filter/Static" {
	Properties {
		_MainTex("Base (RGB)", 2D) = "white" {}
		_StaticTex("Static Pattern (RGB)", 2D) = "white" {}
		_DirtTex("Dirt Pattern (RGB)", 2D) = "white" {}
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
			uniform sampler2D _StaticTex;
			uniform fixed _StaticMagnitude;
			uniform sampler2D _DirtTex;
			uniform fixed _DirtMagnitude;

			float4 _MainTex_ST;

			half _PatternOffsetX;
			half _PatternOffsetY;
			half _PatternScaleX;
			half _PatternScaleY;

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
				fixed4 output;

				half staticMask = tex2D(_StaticTex, fixed2(_PatternOffsetX, i.uv.y*_PatternScaleY+ _PatternOffsetY)).g;
				half3 dirt = (tex2D(_DirtTex, i.uv+fixed2(_PatternOffsetX,0)).rgb*10) * staticMask * (_DirtMagnitude*_DirtMagnitude);
				
				dirt.r = clamp(dirt.r, 0.0, 1.0);
				dirt.g = clamp(dirt.g, 0.0, 1.0);
				dirt.b = clamp(dirt.b, 0.0, 1.0);

				half staticOffset = (RGB2Y(tex2D(_MainTex, fixed2(_PatternOffsetX, i.uv.y)).rgb) - 0.5)*2.0*staticMask*(_StaticMagnitude*_StaticMagnitude);
				output.rgb = tex2D(_MainTex, i.uv + fixed2(staticOffset, 0)).rgb*(half3(1,1,1)-dirt)+dirt;
				
				output.a = 1.0;
				return output;
			}
			ENDCG
		}
	}
	
	Fallback off
}
