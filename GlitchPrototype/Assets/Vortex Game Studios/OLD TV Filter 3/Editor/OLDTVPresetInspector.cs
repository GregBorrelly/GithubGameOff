using System.IO;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using VortexStudios.PostProcessing;

public class OLDTVPresetFactory {
    [MenuItem( "Assets/Create/TV Filter Preset", priority = 201 )]
    static void MenuCreatePostProcessingProfile() {
        Texture2D icon = EditorGUIUtility.FindTexture( "ScriptableObject Icon" );
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists( 0, ScriptableObject.CreateInstance<CreateTVProfile>(), "New TV Filter Preset.asset", icon, null );

        /*
        PropertyInfo inspectorModeInfo = typeof( SerializedObject ).GetProperty( "inspectorMode", BindingFlags.NonPublic | BindingFlags.Instance );
        SerializedObject serializedObject = new SerializedObject( script );
        inspectorModeInfo.SetValue( serializedObject, InspectorMode.Debug, null );
        SerializedProperty iconProperty = serializedObject.FindProperty( "m_Icon" );
        iconProperty.objectReferenceValue = icon;
        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
        EditorUtility.SetDirty( script );
        Debug.Log( "Applied Fancy Icon to: " + script.name );
        */
    }

    internal static OLDTVPreset CreatePostProcessingProfileAtPath( string path ) {
        OLDTVPreset profile = ScriptableObject.CreateInstance<OLDTVPreset>();
        profile.name = Path.GetFileName( path );
        AssetDatabase.CreateAsset( profile, path );

        return profile;
    }
}

class CreateTVProfile : EndNameEditAction {
    public override void Action( int instanceId, string pathName, string resourceFile ) {
        OLDTVPreset profile = OLDTVPresetFactory.CreatePostProcessingProfileAtPath( pathName );
        ProjectWindowUtil.ShowCreatedAsset( profile );
    }
}

[CustomEditor( typeof( OLDTVPreset ) )]
public class OLDTVPresetInspector : Editor {
    private SerializedProperty _noiseFilter;
    private SerializedProperty _compositeFilter;
    private SerializedProperty _staticFilter;
    private SerializedProperty _televisionFilter;
    private SerializedProperty _chromaticAberrationFilter;
    private SerializedProperty _scanlineFilter;
    private SerializedProperty _tubeFilter;

    private OLDTVFilter3 t {
        get { return (OLDTVFilter3)target; }
    }

    void OnEnable() {
        if ( _compositeFilter == null )
            _compositeFilter = serializedObject.FindProperty( "_compositeFilter" );
        if ( _noiseFilter == null )
            _noiseFilter = serializedObject.FindProperty( "_noiseFilter" );
        if ( _staticFilter == null )
            _staticFilter = serializedObject.FindProperty( "_staticFilter" );
        if ( _televisionFilter == null )
            _televisionFilter = serializedObject.FindProperty( "_televisionFilter" );
        if ( _chromaticAberrationFilter == null )
            _chromaticAberrationFilter = serializedObject.FindProperty( "_chromaticAberrationFilter" );
        if ( _scanlineFilter == null )
            _scanlineFilter = serializedObject.FindProperty( "_scanlineFilter" );
        if ( _tubeFilter == null )
            _tubeFilter = serializedObject.FindProperty( "_tubeFilter" );
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        GUILayout.BeginVertical();

        EditorGUILayout.PropertyField( _noiseFilter );
        EditorGUILayout.PropertyField( _staticFilter );
        EditorGUILayout.PropertyField( _compositeFilter );
        EditorGUILayout.PropertyField( _televisionFilter ); 
        EditorGUILayout.PropertyField( _chromaticAberrationFilter );
        EditorGUILayout.PropertyField( _scanlineFilter );
        EditorGUILayout.PropertyField( _tubeFilter );

        GUILayout.EndVertical();

        GUILayout.Label( "OLD TV Filter v.3.0.0", EditorStyles.miniBoldLabel );

        serializedObject.ApplyModifiedProperties();
    }
}
