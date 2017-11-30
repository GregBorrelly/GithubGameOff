using System;
using UnityEngine;

namespace VortexStudios.PostProcessing {
    [System.Serializable]
    public class TelevisionProfile : PostProcessingProfile {
        [SerializeField]
        public int lineCount = 224;

        [SerializeField]
        public Vector2 sync = new Vector2( 0.0f, 0.0f );
        private Vector2 _sync = new Vector2( 0.0f, 0.0f );
        [SerializeField]
        public float brightness = 0.0f;
        [SerializeField]
        public float contrast = 0.0f;
        [SerializeField]
        public float saturation = 0.5f;
        [SerializeField]
        public float sharpness = -1.0f; 

        public override void OnEnable() {
        }

        public override void OnFixedUpdate() {
            _sync += sync * Time.fixedUnscaledDeltaTime;
        }

        public override RenderTexture OnRenderImage( RenderTexture source ) {
            base.OnRenderImage( source );

            float screenAspect = (float)( lineCount ) / (float)( source.height );
            if ( material != null && (brightness != 0.0f || 
                                      contrast != 0.0f || 
                                      saturation != 0.0f || 
                                      sharpness != 0.0f) ) {
                material.SetFloat( "_ScreenWidth", 1.0f / ( source.width * screenAspect ) );
                material.SetFloat( "_ScreenHeight", 1.0f / ( source.height * screenAspect ) );
                material.SetVector( "_Sync", sync );
                material.SetFloat( "_Brightness", brightness );
                material.SetFloat( "_Contrast", ( 1.016f * ( contrast + 1.0f ) ) / ( 1.016f * ( 1.016f - contrast ) ) );
                material.SetFloat( "_Saturation", (saturation * 2.0f) );
                material.SetFloat( "_Sharpness", sharpness );

                Graphics.Blit( SOURCEBUFFER, DESTBUFFER, material );
                SWAPBUFFER();
            }

            return null;
        }
    }
}
