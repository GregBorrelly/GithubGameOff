using UnityEngine;
using UnityEditor;
using VortexStudios.PostProcessing;
using System.Text.RegularExpressions;

public class PostProcessingProfileEditor : PropertyDrawer {
    protected SerializedProperty foldout;
    protected SerializedProperty enabled;

    public override float GetPropertyHeight( SerializedProperty property, GUIContent label ) {
        return 0.0f;
    }    

    public override void OnGUI( Rect position, SerializedProperty property, GUIContent label ) {
        foldout = property.FindPropertyRelative( "_foldout" );
        enabled = property.FindPropertyRelative( "_enabled" );

        GUILayout.BeginHorizontal( EditorStyles.miniButton );
        foldout.boolValue = GUILayout.Toggle( foldout.boolValue, "", EditorStyles.foldout, GUILayout.Width( 13 ) );
        enabled.boolValue = GUILayout.Toggle( enabled.boolValue, "", GUILayout.Width( 13 ) );
        foldout.boolValue = GUILayout.Toggle( foldout.boolValue, Regex.Replace( property.type.Replace("Profile",""), @"((?<=\p{Ll})\p{Lu})|((?!\A)\p{Lu}(?>\p{Ll}))", " $0" ), EditorStyles.label );
        GUILayout.EndHorizontal();
    }
}
