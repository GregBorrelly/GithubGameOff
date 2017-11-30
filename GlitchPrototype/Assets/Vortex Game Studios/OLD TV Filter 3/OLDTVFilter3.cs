using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VortexStudios.PostProcessing;

[ExecuteInEditMode]
public class OLDTVFilter3 : MonoBehaviour {
    [SerializeField]
    private OLDTVPreset _preset = null;
    public OLDTVPreset preset {
        get { return _preset; }
        set { _preset = value; }
    }

    [SerializeField]
    private Camera _camera = null;

    public bool customAspectRatio = false;
    [SerializeField]
    private Vector2 _aspectRatio = new Vector2( 4.0f, 3.0f );
    public Vector2 aspectRatio {
        set {
            _aspectRatio = value;
        }
        get {
            return _aspectRatio;
        }
    }

    public bool timeScale = false;

    void Start() {
        OnValidate();
    }  

    void Update() {
        if ( _preset == null ||
            ( timeScale && Time.timeScale == 0.0f ) )
            return;

        _preset.compositeFilter.OnFixedUpdate();
        _preset.noiseFilter.OnFixedUpdate();
        _preset.staticFilter.OnFixedUpdate();
        _preset.chromaticAberrationFilter.OnFixedUpdate();
        _preset.scanlineFilter.OnFixedUpdate();
        _preset.televisionFilter.OnFixedUpdate();
        _preset.tubeFilter.OnFixedUpdate();
    }

    private void OnValidate() {
        aspectRatio = _aspectRatio;
    }

    private void OnPreRender() {
        if ( _camera != null ) {
            if ( customAspectRatio == true ) {
                float screenRatio = (float)Screen.width / (float)Screen.height;                
                float gameRatio = _aspectRatio.x / _aspectRatio.y;

                if ( screenRatio / gameRatio >= 1.0f ) {          //  horizontal
                    float width = Screen.height / _aspectRatio.y * _aspectRatio.x;   
                    float x = ( Screen.width - width ) / 2.0f;
                    _camera.pixelRect = new Rect( x, 0.0f, width, Screen.height );
                } else {
                    float height = Screen.width / _aspectRatio.x * _aspectRatio.y;
                    float y = ( Screen.height - height ) / 2.0f;
                    _camera.pixelRect = new Rect( 0.0f, y, Screen.width, height );
                }
            } else
                _camera.rect = new Rect( 0, 0, 1, 1 );
        }
    }

    void OnRenderImage( RenderTexture source, RenderTexture destination ) {
        if ( _preset == null ) {
            Graphics.Blit( source, destination );
            return;
        }

        source.wrapMode = TextureWrapMode.Repeat;

        if ( PostProcessingProfile.SOURCEBUFFER == null || !PostProcessingProfile.SOURCEBUFFER.IsCreated() ||
            PostProcessingProfile.SOURCEBUFFER.width != source.width || PostProcessingProfile.SOURCEBUFFER.height != source.height ||
            PostProcessingProfile.SOURCEBUFFER.depth != source.depth ) {
            if ( PostProcessingProfile.SOURCEBUFFER != null && PostProcessingProfile.SOURCEBUFFER.IsCreated() )
                PostProcessingProfile.SOURCEBUFFER.DiscardContents();

            PostProcessingProfile.SOURCEBUFFER = new RenderTexture( source.width, source.height, source.depth );
            PostProcessingProfile.SOURCEBUFFER.antiAliasing = 1;
            PostProcessingProfile.SOURCEBUFFER.anisoLevel = 0;
            PostProcessingProfile.SOURCEBUFFER.autoGenerateMips = false;
            PostProcessingProfile.SOURCEBUFFER.filterMode = FilterMode.Bilinear;
        }

        if ( PostProcessingProfile.DESTBUFFER == null || !PostProcessingProfile.DESTBUFFER.IsCreated() ||
            PostProcessingProfile.DESTBUFFER.width != source.width || PostProcessingProfile.DESTBUFFER.height != source.height ||
            PostProcessingProfile.DESTBUFFER.depth != source.depth ) {
            if ( PostProcessingProfile.DESTBUFFER != null && PostProcessingProfile.DESTBUFFER.IsCreated() )
                PostProcessingProfile.DESTBUFFER.DiscardContents();

            PostProcessingProfile.DESTBUFFER = new RenderTexture( source.width, source.height, source.depth );
            PostProcessingProfile.DESTBUFFER.antiAliasing = 1;
            PostProcessingProfile.DESTBUFFER.anisoLevel = 0;
            PostProcessingProfile.DESTBUFFER.autoGenerateMips = false;
            PostProcessingProfile.DESTBUFFER.filterMode = FilterMode.Bilinear;
        }

        Graphics.Blit( source, PostProcessingProfile.SOURCEBUFFER );

        //  ruido
        if ( _preset.noiseFilter.enabled ) {
            _preset.noiseFilter.OnRenderImage( source );
        }
        //  estática
        if ( _preset.staticFilter.enabled ) {
            _preset.staticFilter.OnRenderImage( source );
        }
        //  vídeo composto
        if ( _preset.compositeFilter.enabled ) {
            _preset.compositeFilter.OnRenderImage( source );
        }
        //  aberração cromatica
        if ( _preset.chromaticAberrationFilter.enabled ) {
            _preset.chromaticAberrationFilter.OnRenderImage( source );
        }
        //  televisão
        if ( _preset.televisionFilter.enabled ) {
            _preset.televisionFilter.OnRenderImage( source );
        }
        //  scanline
        if ( _preset.scanlineFilter.enabled ) {
            _preset.scanlineFilter.OnRenderImage( source );
        }
        //  tubo
        if( _preset.tubeFilter.enabled) {
            _preset.tubeFilter.OnRenderImage( source );
        }

        //Graphics.CopyTexture( source, destination );
        Graphics.Blit( PostProcessingProfile.SOURCEBUFFER, destination );
    }
}