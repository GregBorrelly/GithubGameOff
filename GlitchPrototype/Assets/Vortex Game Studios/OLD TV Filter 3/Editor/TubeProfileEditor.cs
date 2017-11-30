using UnityEngine;
using UnityEditor;
using VortexStudios.PostProcessing;

[CustomPropertyDrawer( typeof( TubeProfile ) )]
public class TubeProfileEditor : PostProcessingProfileEditor {
    private SerializedProperty _maskPattern = null;
    private SerializedProperty _reflexPattern = null;
    private SerializedProperty _distortionMagnitude = null;
    private SerializedProperty _reflexMagneture = null;

    public override void OnGUI( Rect position, SerializedProperty property, GUIContent label ) {
        if ( _maskPattern == null )
            _maskPattern = property.FindPropertyRelative( "maskPattern" );
        if ( _reflexPattern == null )
            _reflexPattern = property.FindPropertyRelative( "reflexPattern" );
        if ( _distortionMagnitude == null )
            _distortionMagnitude = property.FindPropertyRelative( "distortionMagnitude" );
        if ( _reflexMagneture == null )
            _reflexMagneture = property.FindPropertyRelative( "reflexMagnitude" );

        base.OnGUI( position, property, label );
        if ( foldout.boolValue ) {
            _maskPattern.objectReferenceValue = EditorGUILayout.ObjectField( "Border Mask", _maskPattern.objectReferenceValue, typeof( Texture ), false );
            _reflexPattern.objectReferenceValue = EditorGUILayout.ObjectField( "Reflex Pattern", _reflexPattern.objectReferenceValue, typeof( Texture ), false );
            _reflexMagneture.floatValue = EditorGUILayout.Slider( "Reflex Magnitude", _reflexMagneture.floatValue, 0.0f, 1.0f );
            _distortionMagnitude.floatValue = EditorGUILayout.Slider( "Distortion Magnitude", _distortionMagnitude.floatValue, -1.0f, 1.0f );

            EditorGUILayout.HelpBox( "You can use the image from player's webcam as a reflex to create a awesome arcade effect!", MessageType.Info );

            property.serializedObject.ApplyModifiedProperties();
        }
    }
}
