using System;
using UnityEngine;

namespace VortexStudios.PostProcessing {
    [System.Serializable]
    public class TubeProfile : PostProcessingProfile {
        [SerializeField]
        public Texture maskPattern = null;
        [SerializeField]
        public Texture reflexPattern = null;
        [SerializeField]
        public float distortionMagnitude = 0.15f;
        [SerializeField]
        public float reflexMagnitude = 0.15f;

        public override void OnEnable() {
            if ( maskPattern == null )
                maskPattern = material.GetTexture( "_MaskTex" );
        }

        public override RenderTexture OnRenderImage( RenderTexture source ) {
            base.OnRenderImage( source );

            if ( material != null && ( maskPattern != null ||
                                       distortionMagnitude != 0.0f ||
                                       (reflexPattern != null && distortionMagnitude > 0.0f) ) ) {
                material.SetTexture( "_MaskTex", maskPattern );
                material.SetTexture( "_ReflexTex", reflexPattern );
                material.SetFloat( "_Distortion", distortionMagnitude );
                material.SetFloat( "_Reflex", reflexMagnitude );

                Graphics.Blit( SOURCEBUFFER, DESTBUFFER, material, 0 );
                SWAPBUFFER();
            }

            return null;
        }
    }
}