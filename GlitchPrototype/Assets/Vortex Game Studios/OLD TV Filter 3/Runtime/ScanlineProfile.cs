using System;
using UnityEngine;

namespace VortexStudios.PostProcessing {
    [Serializable]
    public class ScanlineProfile : PostProcessingProfile {
        [SerializeField]
        public Texture pattern = null;
        [SerializeField]
        public int lineCount = 224;
        [SerializeField]
        public float magnetude = 0.75f;


        public override void OnEnable() {
            if ( pattern == null )
                pattern = material.GetTexture( "_PatternTex" );
        }

        public override RenderTexture OnRenderImage( RenderTexture source ) {
            base.OnRenderImage( source );

            if ( material != null && ( pattern != null && magnetude != 0.0f ) ) {
                material.SetInt( "_ScreenWidth", (int)( source.width * ( (float)( lineCount ) / (float)( source.height ) ) ) );
                material.SetInt( "_ScreenHeight", lineCount );

                material.SetTexture( "_PatternTex", pattern );
                material.SetFloat( "_Magnitude", 1.0f - magnetude );

                Graphics.Blit( SOURCEBUFFER, DESTBUFFER, material );
                SWAPBUFFER();
            }

            return null;
        }
    }
}