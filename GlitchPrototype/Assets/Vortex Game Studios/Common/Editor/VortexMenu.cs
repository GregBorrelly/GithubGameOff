using UnityEngine;
using UnityEditor;
using System.Collections;

public class VortexMenu : EditorWindow {
    [MenuItem( "Window/Vortex Game Studios/Check our Assets", false, 1000 )]
    public static void ShowAssetStore() {
        Application.OpenURL( "https://goo.gl/pqyDZx" );
    }
    [MenuItem( "Window/Vortex Game Studios/Visit our Site", false, 1200 )]
    public static void ShowWebsite() {
        Application.OpenURL( "https://goo.gl/r6hKhy" );
    }

    [MenuItem( "Window/Vortex Game Studios/Like us on Facebook", false, 1200 )]
    public static void ShowFacebook() {
        Application.OpenURL( "https://goo.gl/EA1zpb" );
    }

    [MenuItem( "Window/Vortex Game Studios/Follow us on Twitter", false, 1200 )]
    public static void ShowTwitter() {
        Application.OpenURL( "https://goo.gl/aHPiZ7" );
    }
}
