using UnityEngine;
using UnityEditor;
using VortexStudios.PostProcessing;

[CustomPropertyDrawer( typeof( ChromaticAberrationProfile ) )]
public class ChromaticAberrationProfileEditor : PostProcessingProfileEditor {
    private SerializedProperty _pattern = null;
    private SerializedProperty _magnitude = null;

    public override void OnGUI( Rect position, SerializedProperty property, GUIContent label ) {
        if ( _pattern == null )
            _pattern = property.FindPropertyRelative( "pattern" );
        if ( _magnitude == null )
            _magnitude = property.FindPropertyRelative( "magnetude" );

        base.OnGUI( position, property, label );
        if ( foldout.boolValue ) {
            _pattern.objectReferenceValue = EditorGUILayout.ObjectField( "Pattern", _pattern.objectReferenceValue, typeof( Texture ), false );
            _magnitude.floatValue = EditorGUILayout.Slider( "Magnitude", _magnitude.floatValue, 0.0f, 1.0f );

            property.serializedObject.ApplyModifiedProperties();
        }
    }
}
