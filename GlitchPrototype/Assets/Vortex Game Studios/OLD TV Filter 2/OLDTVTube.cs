using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class OLDTVTube : FilterBehavior {
    public Texture scanlinePattern;
    public bool scanlineCountAuto = false;
    public int scanlineCount = 320;
    public float scanlineBrightMin = 0.75f;
    public float scanlineBrightMax = 1.0f;
    // scanline min/max
    public Texture mask;
    public Texture reflex;
    public float reflexMagnetude = 0.5f;
    public float radialDistortion = 0.2f;

    public delegate void RepaintAction();

    public event RepaintAction WantRepaint;

    private void Repaint() {
        if ( WantRepaint != null ) {
            WantRepaint();
        }
    }

    void OnRenderImage( RenderTexture source, RenderTexture destination ) {
		/*
        float screenHorizontal = 1.0f;
        bool isMobile = false;

        #if ( UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 )
        isMobile = true;
        #endif
		*/

        this.material.SetTexture( "_ScanLine", scanlinePattern );

        if ( scanlineCountAuto )
            scanlineCount = Screen.height;

		this.material.SetFloat( "_ScanLineCount", scanlineCount / 2 );

		this.material.SetFloat( "_ScanLineMin", scanlineBrightMin );
		this.material.SetFloat( "_ScanLineMax", scanlineBrightMax );
		
		/*
        if ( Screen.orientation == UnityEngine.ScreenOrientation.Landscape || Screen.orientation == UnityEngine.ScreenOrientation.LandscapeLeft || Screen.orientation == UnityEngine.ScreenOrientation.LandscapeRight ) {
            // DEITADO
            if ( isMobile ) {
                screenHorizontal = 0.0f;
                //if( scanlineCountAuto )
                //    tvMaterialTube.SetFloat( "_ScanLineCount", Screen.height / 4.0f );
            } else {
                //if ( scanlineCountAuto )
                //    tvMaterialTube.SetFloat( "_ScanLineCount", Screen.height / 2.0f );
            }

			this.material.SetFloat( "_ScreenHorizontal", screenHorizontal );

        } else {    
            // PÉ (PADRÃO)
            if ( isMobile ) {
                screenHorizontal = 1.0f;
                //if ( scanlineCountAuto )
                //    tvMaterialTube.SetFloat( "_ScanLineCount", Screen.height / 4.0f );
            } else {
                //if ( scanlineCountAuto )
                //    tvMaterialTube.SetFloat( "_ScanLineCount", Screen.height / 2.0f );
            }

			this.material.SetFloat( "_ScreenHorizontal", screenHorizontal );
        }
		*/

		this.material.SetTexture( "_MaskTex", mask );
		this.material.SetTexture( "_ReflexTex", reflex );
		this.material.SetFloat( "_ReflexMagnetude", reflexMagnetude );
		this.material.SetFloat( "_Distortion", radialDistortion );

        Graphics.Blit( source, destination, this.material );
    }
}