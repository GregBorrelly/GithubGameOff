using UnityEngine;
using UnityEditor;
using VortexStudios.PostProcessing;

[CustomPropertyDrawer( typeof( TelevisionProfile ) )]
public class TelevisionProfileEditor : PostProcessingProfileEditor {
    private SerializedProperty _sync = null;
    private SerializedProperty _brightness = null;
    private SerializedProperty _contrast = null;
    private SerializedProperty _saturation = null;
    private SerializedProperty _sharpness = null;

    public override void OnGUI( Rect position, SerializedProperty property, GUIContent label ) {
        if ( _sync == null )
            _sync = property.FindPropertyRelative( "sync" );
        if ( _brightness == null )
            _brightness = property.FindPropertyRelative( "brightness" );
        if ( _contrast == null )
            _contrast = property.FindPropertyRelative( "contrast" );
        if ( _saturation == null )
            _saturation = property.FindPropertyRelative( "saturation" );
        if ( _sharpness == null )
            _sharpness = property.FindPropertyRelative( "sharpness" );

        base.OnGUI( position, property, label );
        if ( foldout.boolValue ) {
            //_sync.vector2Value = EditorGUILayout.Vector2Field( "Sync", _sync.vector2Value );
            _brightness.floatValue = EditorGUILayout.Slider( "Brightness", _brightness.floatValue, -1.0f, 1.0f );
            _contrast.floatValue = EditorGUILayout.Slider( "Contrast", _contrast.floatValue, -1.0f, 1.0f );
            _saturation.floatValue = EditorGUILayout.Slider( "Saturation", _saturation.floatValue, 0.0f, 1.0f );
            _sharpness.floatValue = EditorGUILayout.Slider( "Sharpness", _sharpness.floatValue, -1.0f, 1.0f );

            property.serializedObject.ApplyModifiedProperties();
        }
    }
}
