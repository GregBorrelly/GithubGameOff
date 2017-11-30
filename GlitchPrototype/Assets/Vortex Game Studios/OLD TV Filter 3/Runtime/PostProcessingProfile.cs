using System;
using UnityEngine;

namespace VortexStudios.PostProcessing {
    [System.Serializable]
    public class PostProcessingProfile {
        protected RenderBuffer _BUFFER;

        private static bool _CURRENTBUFFER = false;
        private static RenderTexture[] _TEMPBUFFER = new RenderTexture[2];// = null;

        public static void SWAPBUFFER() {
            _CURRENTBUFFER = !_CURRENTBUFFER;
        }

        public static RenderTexture SOURCEBUFFER {
            get {
                return _TEMPBUFFER[ _CURRENTBUFFER ? 0 : 1 ];
            }

            set {
                _TEMPBUFFER[ _CURRENTBUFFER ? 0 : 1 ] = value;
            }
        }

        public static RenderTexture DESTBUFFER {
            get {
                return _TEMPBUFFER[ !_CURRENTBUFFER ? 0 : 1 ];
            }

            set {
                _TEMPBUFFER[ !_CURRENTBUFFER ? 0 : 1 ] = value;
            }
        }

#pragma warning disable 0414
        [ SerializeField]
        private bool _foldout = false;

        [SerializeField]
        protected Material _material;
        public Material material {
            get {
                if ( _material == null ) {
                    Shader shader = Shader.Find( "Vortex Game Studios/Filters/OLD TV Filter/" + this.GetType().Name.Replace( "Profile", "" ) );
                    if ( shader != null )
                        _material = new Material( shader );
                }

                //  se o filtro não for compatível com o hardware ele é desativado
                if ( _enabled && !_material.shader.isSupported )
                    this.enabled = false;

                return _material;
            }
        }

        [SerializeField]
        protected bool _enabled = true;
        public bool enabled {
            get { return _enabled; }
            set {
                _enabled = value;

                if ( value )
                    OnValidate();
            }
        }

        public PostProcessingProfile() { _foldout = false; }

        public virtual void OnFixedUpdate() { }
        public virtual void OnEnable() { }
        public virtual void OnValidate() { }
        public virtual void OnReset() { }
        public virtual RenderTexture OnRenderImage( RenderTexture source ) {
            return source;
        }
    }
}
