using System;
using UnityEngine;

namespace VortexStudios.PostProcessing {
    [System.Serializable]
    public class StaticProfile : PostProcessingProfile {
        [SerializeField]
        public Texture staticPattern = null;
        [SerializeField]
        public float staticMagnitude = 0.1f;
        [SerializeField]
        public float staticScale = 1.0f;
        [SerializeField]
        public float staticOffset = 0.0f;
        [SerializeField]
        public Texture dirtPattern = null;
        [SerializeField]
        public float dirtMagnitude = 0.35f;

        //[SerializeField]
        //public Vector2 scale = Vector2.one;
        private Vector2 _offset = Vector2.zero;

        public override void OnEnable() {
            if ( staticPattern == null )
                staticPattern = material.GetTexture( "_StaticTex" );
            if ( dirtPattern == null )
                dirtPattern = material.GetTexture( "_DirtTex" );
        }

        public override void OnFixedUpdate() {
            _offset.x = UnityEngine.Random.Range( 0.0f, 1.0f );
            _offset.y = 0.0f;
        }

        public override RenderTexture OnRenderImage( RenderTexture source ) {
            base.OnRenderImage( source );
            
            if ( material != null && ((staticPattern != null && staticMagnitude != 0.0f) || 
                                      (dirtPattern != null && dirtMagnitude != 0.0)) ) {
                material.SetTexture( "_StaticTex", staticPattern );
                material.SetFloat( "_PatternOffsetX", _offset.x );
                material.SetFloat( "_PatternOffsetY", staticOffset );
                material.SetFloat( "_PatternScaleY", staticScale );

                material.SetFloat( "_StaticMagnitude", staticMagnitude );

                material.SetTexture( "_DirtTex", dirtPattern );
                material.SetFloat( "_DirtMagnitude", dirtMagnitude );

                Graphics.Blit( SOURCEBUFFER, DESTBUFFER, material );
                SWAPBUFFER();
            }
            
            return null;
        }
    }
}