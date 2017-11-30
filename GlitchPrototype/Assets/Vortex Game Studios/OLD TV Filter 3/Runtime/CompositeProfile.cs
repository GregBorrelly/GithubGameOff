using System;
using UnityEngine;

namespace VortexStudios.PostProcessing {
    [System.Serializable]
    public class CompositeProfile : PostProcessingProfile {
        [SerializeField]
        private Material _materialBleeding;
        public Material materialBleeding {
            get {
                if ( _materialBleeding == null ) {
                    Shader shader = Shader.Find( "Vortex Game Studios/Filters/OLD TV Filter/Bleeding" );
                    if ( shader != null )
                        _materialBleeding = new Material( shader );
                }

                return _materialBleeding;
            }
        }

        //  NTSC
        private bool _polarity = false;
        private float[] _polarityPositive = new float[] { -1.0f, 2.0f, -1.0f };
        private float[] _polarityNegative = new float[] { 1.0f, -2.0f, 1.0f };

        //  BLEEDING
        private Texture2D _bleedingTexture;
        //private float[] _bleedingReferenceKernel = new float[] { 0.882f, 0.575f, 0.381f, 0.575f, 0.882f, 3.295f };
        //private float[] _bleedingKernel = new float[] { 16.0f / 42.0f, 4.0f / 42.0f, 2.0f / 42.0f, 4.0f / 42.0f, 16.0f / 42.0f };

        [SerializeField]
        public int lineCount = 224;
        [SerializeField]
        public float distortion = 0.5f;
        [SerializeField]
        public float artifact = 0.2f;
        [SerializeField]
        public float fringing = 0.7f;
        [SerializeField]
        public float bleeding = 1.0f;

        public override void OnEnable() {
        }

        float t = 0.0f;
        public override void OnFixedUpdate() {
            t += Time.unscaledDeltaTime;

            if ( t >= 0.25f ) {
                t -= 0.25f;
                _polarity = !_polarity;
            }
        }

        public override RenderTexture OnRenderImage( RenderTexture source ) {
            base.OnRenderImage( source );

            float screenAspect = (float)( lineCount ) / (float)( source.height );
            //RenderTexture src = source;

            Vector2 screenSize = new Vector2( 1.0f / ( source.width * screenAspect ), 1.0f / ( source.height * screenAspect ) );

            if ( material != null && (fringing > 0.0f || artifact > 0.0f) ) {
                material.SetFloat( "_ScreenWidth", screenSize.x );
                material.SetFloat( "_ScreenHeight", screenSize.y );
                material.SetFloat( "_Distortion", distortion );
                material.SetFloat( "_Fringing", fringing );
                material.SetFloat( "_Artifact", artifact );
                material.SetFloatArray( "_Kernel", _polarity ? _polarityPositive : _polarityNegative );
                Graphics.Blit( SOURCEBUFFER, DESTBUFFER, material );
                SWAPBUFFER();
            }

            if ( materialBleeding != null && (bleeding > 0.0f) ) {
                //_bleedingKernel = new float[] { 2.0f/ 13.0f, 4.0f / 13.0f, 1.0f / 13.0f, 4.0f / 13.0f, 2.0f / 13.0f };
                materialBleeding.SetFloat( "_ScreenWidth", screenSize.x );
                materialBleeding.SetFloat( "_ScreenHeight", screenSize.y );
                materialBleeding.SetFloat( "_Magnitude", bleeding );
                Graphics.Blit( SOURCEBUFFER, DESTBUFFER, materialBleeding );
                SWAPBUFFER();
            }

            return null;
        }
    }
}