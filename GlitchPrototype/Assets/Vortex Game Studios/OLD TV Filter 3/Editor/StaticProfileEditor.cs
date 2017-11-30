using UnityEngine;
using UnityEditor;
using VortexStudios.PostProcessing;

[CustomPropertyDrawer( typeof( StaticProfile ) )]
public class StaticProfileEditor : PostProcessingProfileEditor {
    private SerializedProperty _staticPattern = null;
    private SerializedProperty _staticMagnitude = null;
    private SerializedProperty _staticScale = null;
    private SerializedProperty _staticOffset = null;
    private SerializedProperty _dirtPattern = null;
    private SerializedProperty _dirtMagnitude = null;
    //private SerializedProperty _vertical = null;
    //private SerializedProperty _scale = null;

    public override void OnGUI( Rect position, SerializedProperty property, GUIContent label ) {
        if ( _staticPattern == null )
            _staticPattern = property.FindPropertyRelative( "staticPattern" );
        if ( _staticMagnitude == null )
            _staticMagnitude = property.FindPropertyRelative( "staticMagnitude" );
        if ( _staticScale == null )
            _staticScale = property.FindPropertyRelative( "staticScale" );
        if ( _staticOffset == null )
            _staticOffset = property.FindPropertyRelative( "staticOffset" );
        if ( _dirtPattern == null )
            _dirtPattern = property.FindPropertyRelative( "dirtPattern" );
        if ( _dirtMagnitude == null )
            _dirtMagnitude = property.FindPropertyRelative( "dirtMagnitude" );


        base.OnGUI( position, property, label );
        if ( foldout.boolValue ) {
            _staticPattern.objectReferenceValue = EditorGUILayout.ObjectField( "Static Pattern", _staticPattern.objectReferenceValue, typeof( Texture ), false );
            _staticMagnitude.floatValue = EditorGUILayout.Slider( "Static Magnitude", _staticMagnitude.floatValue, 0.0f, 1.0f );
            _staticScale.floatValue = EditorGUILayout.FloatField( "Static Scale", _staticScale.floatValue );
            _staticOffset.floatValue = EditorGUILayout.FloatField( "Static Offset", _staticOffset.floatValue );

            _dirtPattern.objectReferenceValue = EditorGUILayout.ObjectField( "Dirt Pattern", _dirtPattern.objectReferenceValue, typeof( Texture ), false );
            _dirtMagnitude.floatValue = EditorGUILayout.Slider( "Dirt Magnitude", _dirtMagnitude.floatValue, 0.0f, 1.0f );

            //_scale.vector2Value = EditorGUILayout.Vector2Field( "Scale", _scale.vector2Value );

            property.serializedObject.ApplyModifiedProperties();
        }
    }
}
