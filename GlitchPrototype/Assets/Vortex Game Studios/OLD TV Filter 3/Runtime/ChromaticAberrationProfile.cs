using System;
using UnityEngine;

namespace VortexStudios.PostProcessing {
    [System.Serializable]
    public class ChromaticAberrationProfile : PostProcessingProfile {
        [SerializeField]
        public Texture pattern = null;
        [SerializeField]
        public float magnetude = 0.2f;

        public override void OnEnable() {
            if ( pattern == null )
                pattern = material.GetTexture( "_MaskTex" );
        }

        public override RenderTexture OnRenderImage( RenderTexture source ) {
            base.OnRenderImage( source );

            if ( material != null && pattern != null && magnetude > 0.0f ) {
                material.SetTexture( "_MaskTex", pattern );
                material.SetFloat( "_Magnitude", magnetude * magnetude );

                Graphics.Blit( SOURCEBUFFER, DESTBUFFER, material, 0 );

                SWAPBUFFER();
            }

            return null;
        }
    }
}