using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UT.UEditor;


[CustomEditor( typeof( OLDTVTube) )]
[CanEditMultipleObjects]
public class OLDTVTubeEditor : Editor {
    private SerializedObject _so;

    private bool _foldScanline = true;
    private bool _foldTube = true;

    private SerializedProperty _scanlinePattern;
    private SerializedProperty _scanlineCount;
    private SerializedProperty _scanlineCountAuto;
    private SerializedProperty _scanlineBrightMin;
    private SerializedProperty _scanlineBrightMax;

    private SerializedProperty _tubeMask;
    private SerializedProperty _tubeReflex;
    private SerializedProperty _tubeReflexMagnetude;
    private SerializedProperty _tubeRadialDistortion;
    
    private Texture2D _logo = null;

    private OLDTVTube Target {
        get { return ( OLDTVTube )target; }
    }

    void OnEnable() {
        if ( _logo == null ) {
            _logo = ( Texture2D )AssetDatabase.LoadAssetAtPath( "Assets/Vortex Game Studios/OLD TV Filter 2/Gizmos/logo_tube.png", typeof( Texture2D ) );
        }

        _scanlinePattern = serializedObject.FindProperty( "scanlinePattern" );
        _scanlineCount = serializedObject.FindProperty( "scanlineCount" );
        _scanlineCountAuto = serializedObject.FindProperty( "scanlineCountAuto" );

        _scanlineBrightMin = serializedObject.FindProperty( "scanlineBrightMin" );
        _scanlineBrightMax = serializedObject.FindProperty( "scanlineBrightMax" );

        _tubeMask = serializedObject.FindProperty( "mask" );
        _tubeReflex = serializedObject.FindProperty( "reflex" );
        _tubeReflexMagnetude = serializedObject.FindProperty( "reflexMagnetude" );
        _tubeRadialDistortion = serializedObject.FindProperty( "radialDistortion" );

        Target.WantRepaint += this.Repaint;
    }

    void OnDisable() {
        Target.WantRepaint -= this.Repaint;
    }

    public override void OnInspectorGUI() {
        GUILayout.BeginVertical();
        GUILayout.Box( _logo, GUIStyle.none );
		EditorGUILayout.LabelField( "Ver. 2.2" );

		// SCANLINE PROPERTIES
		_foldScanline = UEditor.BeginGroup( null, "Scanline", _foldScanline, Color.Lerp( Color.gray, Color.white, 0.4f ) );
        if ( _foldScanline ) {
            // Select the scanline texture pattern
            _scanlinePattern.objectReferenceValue = EditorGUILayout.ObjectField( "Pattern", Target.scanlinePattern, typeof( Texture ), false ) as Texture;
            
			// Adjust the screen resolution for the scanline
            _scanlineCount.intValue = EditorGUILayout.IntField( "Line Count", Target.scanlineCount );
            _scanlineCountAuto.boolValue = EditorGUILayout.Toggle( "Auto Line Count", Target.scanlineCountAuto );
            if ( ( target as OLDTVTube ).scanlineCountAuto ) {
                UEditor.BeginBox( "Using screen height as line counter.", Color.yellow ); UEditor.EndBox();
            }

            // Adjust the scanline bright
            float tMin = Target.scanlineBrightMin;
            float tMax = Target.scanlineBrightMax;
            EditorGUILayout.MinMaxSlider( new GUIContent( "Bright" ), ref tMin, ref tMax, 0.0f, 1.0f );
            _scanlineBrightMin.floatValue = tMin;
            _scanlineBrightMax.floatValue = tMax;

            _scanlineBrightMin.floatValue = EditorGUILayout.Slider( "Min Bright", Target.scanlineBrightMin, 0.0f, 1.0f );
            _scanlineBrightMax.floatValue = EditorGUILayout.Slider( "Max Bright", Target.scanlineBrightMax, 0.0f, 1.0f );

            if ( _scanlineBrightMin.floatValue > _scanlineBrightMax.floatValue ) {
                _scanlineBrightMin.floatValue = _scanlineBrightMax.floatValue;
            }
        }
        UEditor.EndGroup();

        // TUBE PROPERTIES
        _foldTube = UEditor.BeginGroup( null, "Tube", _foldTube, Color.Lerp( Color.gray, Color.white, 0.4f ) );
        if ( _foldTube ) {
            _tubeMask.objectReferenceValue = EditorGUILayout.ObjectField( "Mask", Target.mask, typeof( Texture ), false ) as Texture;
            _tubeReflex.objectReferenceValue = EditorGUILayout.ObjectField( "Reflex", Target.reflex, typeof( Texture ), false ) as Texture;

            _tubeReflexMagnetude.floatValue = EditorGUILayout.Slider( "Reflex Magnetude", Target.reflexMagnetude, 0.0f, 1.0f );
            _tubeRadialDistortion.floatValue = EditorGUILayout.Slider( "Radial Distortion", Target.radialDistortion, -1.0f, 1.0f );
        }
        UEditor.EndGroup();
        GUILayout.EndVertical();

        // Apply the values
        serializedObject.ApplyModifiedProperties();
        Repaint();
    }
}

// We are forcing a cellphone battery charger, this is very dangerous!!
// Don't try this at home if you didn't have any idea how to do it!!
// 3.17v 3.28v