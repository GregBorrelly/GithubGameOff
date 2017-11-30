// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

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

Shader "Vortex Game Studios/Filters/OLD TV Screen Effect" {
	Properties {
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Saturation("Saturation", Range(0.0, 1.0)) = 0.0

		// Chromatic Aberration
		_ChromaticAberrationTex("Chromatic Aberration (RGB)", 2D) = "black" {}
		_ChromaticAberrationMagnetude("Chromatic Aberration Magnetude", Range(-1.0, 1.0)) = 0

		// Noise
		_NoiseTex("Noise (RGB)", 2D) = "black" {}
		_NoiseOffsetX("Noise OffsetX", float) = 0.0
		_NoiseOffsetY("Noise OffsetY", float) = 0.0
		_NoiseMagnetude("Noise Magnetude", Range(-1.0, 1.0)) = 0.5

		// Static
		_StaticTex("Static (RGB)", 2D) = "black" {}
		_StaticMask("Static Mask (RGB)", 2D) = "white" {}
		_StaticMagnetude("Static Magnetude", Range(-1.0, 1.0)) = 0.5
		_StaticVertical("Static Vertical", float) = 0.5
	}

	SubShader{
		Pass {
			ZTest Always Cull Off ZWrite Off

			CGPROGRAM
			#pragma target 2.0
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;

			// Chromatic Aberration
			uniform sampler2D _ChromaticAberrationTex;
			uniform fixed _ChromaticAberrationMagnetude;

			// Static and Noise
			uniform sampler2D _NoiseTex;
			uniform fixed _NoiseOffsetX;
			uniform fixed _NoiseOffsetY;
			uniform fixed _NoiseMagnetude;

			uniform sampler2D _StaticTex;
			uniform fixed _StaticOffsetX;
			uniform fixed _StaticOffsetY;
			uniform sampler2D _StaticMask;
			uniform fixed _StaticMagnetude;
			uniform fixed _StaticVertical;

			// Saturation
			uniform fixed _Saturation;

			// UV Stuff
			float4 _MainTex_ST;
			float4 _NoiseTex_ST;
			float4 _StaticTex_ST;
			float4 _StaticMask_ST;

			struct v2f {
				float4 pos : SV_POSITION;
				half2 uv : TEXCOORD0;
				half2 uvNoise : TEXCOORD1;
				half2 uvStatic : TEXCOORD2;
				half2 uvStaticMask : TEXCOORD3;
			};

			v2f vert(appdata_img v) {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;

				o.uvNoise = o.uv + fixed2(_NoiseOffsetX, _NoiseOffsetY);		//TRANSFORM_TEX(v.texcoord, _NoiseTex);
				o.uvStatic = o.uvNoise;// TRANSFORM_TEX(v.texcoord, _StaticTex);
				o.uvStaticMask = o.uv + fixed2(0.0, _StaticVertical);// TRANSFORM_TEX(v.texcoord, _StaticMask);

				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target {
				fixed4 output;
				
				fixed3 chromaticAberration = tex2D(_ChromaticAberrationTex, i.uv)*_ChromaticAberrationMagnetude;

				// Apply the static distortion
				fixed2 staticOffset = fixed2(0, 0);
				staticOffset = fixed2(tex2D(_StaticTex, fixed2(i.uvStatic.y, 0.0)).g - 0.5, 0.0) * (_StaticMagnetude * tex2D(_StaticMask, -i.uvStaticMask).g);
				
				// Apply the gamescreen
				output.rgb = half3( tex2D(_MainTex, i.uv + staticOffset - chromaticAberration.r).r,
									 tex2D(_MainTex, i.uv + staticOffset).g,
									 tex2D(_MainTex, i.uv + staticOffset + chromaticAberration.b).b );
				//output.rgb = tex2D(_MainTex, i.uv + staticOffset);

				// Apply the screen static and noise
				output.rgb += (tex2D(_NoiseTex, i.uvNoise) * _NoiseMagnetude);
				//output.rgb = half3( i.uvNoise.x, i.uvNoise.y, 0 );

				

				// Apply the screen saturation
				output.rgb = fixed3(lerp(output.rgb, dot(fixed3(0.2126, 0.7152, 0.0722), output.rgb), _Saturation));
				output.a = 1.0;
				return output;
			}
			ENDCG
		}
	}
	
	Fallback off
}