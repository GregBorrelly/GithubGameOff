using UnityEngine;
using UnityEditor;
using VortexStudios.PostProcessing;

//[CustomPropertyDrawer( typeof( OLDTVFilter3 ) )]
[CustomEditor( typeof( OLDTVFilter3 ) )]
public class OLDTVFilter3Editor : Editor {
    private SerializedProperty _preset = null;
    private SerializedProperty _timeScale = null;
    private SerializedProperty _aspectRatio = null;
    private SerializedProperty _cameraAspectRatio = null;
    private SerializedProperty _customAspectRatio = null;
    

    private OLDTVFilter3 t {
        get { return (OLDTVFilter3)target; }
    }

    void OnEnable() {
        if ( _preset == null )
            _preset = serializedObject.FindProperty( "_preset" );
        if ( _timeScale == null )
            _timeScale = serializedObject.FindProperty( "timeScale" );

        if ( _customAspectRatio == null )
            _customAspectRatio = serializedObject.FindProperty( "customAspectRatio" );
        if ( _cameraAspectRatio == null )
            _cameraAspectRatio = serializedObject.FindProperty( "_camera" );
        if ( _aspectRatio == null )
            _aspectRatio = serializedObject.FindProperty( "_aspectRatio" );
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        _preset.objectReferenceValue = EditorGUILayout.ObjectField( "Preset", _preset.objectReferenceValue, typeof( OLDTVPreset ), false );
        _timeScale.boolValue = EditorGUILayout.Toggle( "Time Scalable", _timeScale.boolValue );

        _customAspectRatio.boolValue = EditorGUILayout.Toggle( "Custom Aspect Ratio", _customAspectRatio.boolValue );
        if ( _customAspectRatio.boolValue ) {
            _cameraAspectRatio.objectReferenceValue = EditorGUILayout.ObjectField( "Camera", _cameraAspectRatio.objectReferenceValue, typeof( Camera ), true );
            _aspectRatio.vector2Value = EditorGUILayout.Vector2Field( "Aspect Ratio", _aspectRatio.vector2Value );
        }

        GUILayout.Label( "OLD TV Filter v.3.0.1", EditorStyles.miniBoldLabel );

        serializedObject.ApplyModifiedProperties();
    }
}
