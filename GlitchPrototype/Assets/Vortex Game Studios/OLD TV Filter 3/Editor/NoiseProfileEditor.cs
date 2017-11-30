using UnityEngine;
using UnityEditor;
using VortexStudios.PostProcessing;

[CustomPropertyDrawer( typeof( NoiseProfile ) )]
public class NoiseProfileEditor : PostProcessingProfileEditor {
    private SerializedProperty _pattern = null;
    private SerializedProperty _magnitude = null;
    private SerializedProperty _scale = null;

    public override void OnGUI( Rect position, SerializedProperty property, GUIContent label ) {
        if ( _pattern == null )
            _pattern = property.FindPropertyRelative( "pattern" );
        if ( _magnitude == null )
            _magnitude = property.FindPropertyRelative( "magnetude" );
        if ( _scale == null )
            _scale = property.FindPropertyRelative( "scale" );

        base.OnGUI( position, property, label );
        if ( foldout.boolValue ) {
            _pattern.objectReferenceValue = EditorGUILayout.ObjectField( "Pattern", _pattern.objectReferenceValue, typeof( Texture ), false );
            _magnitude.floatValue = EditorGUILayout.Slider( "Magnitude", _magnitude.floatValue, -1.0f, 1.0f );
            _scale.vector2Value = EditorGUILayout.Vector2Field( "Scale", _scale.vector2Value );

            property.serializedObject.ApplyModifiedProperties();
        }
    }
}
