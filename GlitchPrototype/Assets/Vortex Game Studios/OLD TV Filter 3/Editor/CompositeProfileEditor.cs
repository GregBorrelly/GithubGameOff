using UnityEngine;
using UnityEditor;
using VortexStudios.PostProcessing;

[CustomPropertyDrawer( typeof( CompositeProfile ) )]
public class CompositeProfileEditor : PostProcessingProfileEditor {
    private SerializedProperty _lineCount = null;
    private SerializedProperty _distortion = null;
    private SerializedProperty _fringing = null;
    private SerializedProperty _artifact = null;
    private SerializedProperty _bleeding = null;

    public override void OnGUI( Rect position, SerializedProperty property, GUIContent label ) {
        if( _lineCount == null )
            _lineCount = property.FindPropertyRelative( "lineCount" );
        if ( _distortion == null )
            _distortion = property.FindPropertyRelative( "distortion" );
        if ( _fringing == null )
            _fringing = property.FindPropertyRelative( "fringing" );
        if ( _artifact == null )
            _artifact = property.FindPropertyRelative( "artifact" );
        if ( _bleeding == null )
            _bleeding = property.FindPropertyRelative( "bleeding" );

        base.OnGUI( position, property, label );
        if ( foldout.boolValue ) {
            _lineCount.intValue = EditorGUILayout.IntField( "Line Count", _lineCount.intValue );

            _distortion.floatValue = EditorGUILayout.Slider( "Distortion", _distortion.floatValue, -1.0f, 1.0f );
            _artifact.floatValue = EditorGUILayout.Slider( "Artifact", _artifact.floatValue, 0.0f, 1.0f );
            _fringing.floatValue = EditorGUILayout.Slider( "Fringing", _fringing.floatValue, 0.0f, 1.0f );
            _bleeding.floatValue = EditorGUILayout.Slider( "Bleeding", _bleeding.floatValue, 0.0f, 1.0f );
            property.serializedObject.ApplyModifiedProperties();
        }
    }
}
