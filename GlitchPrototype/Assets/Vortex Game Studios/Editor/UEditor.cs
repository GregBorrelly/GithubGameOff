using UnityEditor;
using UnityEngine;
using System.Reflection;
using System.Collections.Generic;

namespace UT.UEditor {
    public class UEditor {
        #region Inspector Box Component
        public static void BeginBox( string title, Color color ) {
            // Actions list
            GUI.backgroundColor = color;
            GUILayout.BeginVertical( "AS TextArea", GUILayout.Height( 5 ) );
            GUI.backgroundColor = Color.white;
            if ( title != "" ) {
                GUILayout.Space( 2 );
                GUILayout.Label( title );
            }
        }

        public static void EndBox() {
            GUILayout.EndVertical();
        }
        #endregion

        #region Inspector Group Component
        public static bool BeginGroup( Texture2D icon, string title, bool fooldout, Color color ) {
            bool returnValue = false;

            GUI.backgroundColor = color;
            GUILayout.BeginVertical( EditorStyles.textArea, GUILayout.Height( 5 ) );
            GUI.backgroundColor = Color.white;
            GUILayout.Space( 2 );


            GUILayout.BeginHorizontal();
            if ( icon != null ) {
                GUIContent content = new GUIContent( title, icon );
                returnValue = EditorGUILayout.Foldout( fooldout, content );
            } else {

                returnValue = EditorGUILayout.Foldout( fooldout, title );
            }

            /*
            if( list == null ) {
                GUILayout.FlexibleSpace();
                GUILayout.Button( "▲", GUILayout.Width(32) );
                GUILayout.Button( "▼", GUILayout.Width(32) );
                GUI.backgroundColor = Color.red;
                GUILayout.Button( "×", GUILayout.Width(32) );
                GUI.backgroundColor = Color.white;
            }
            */
            GUILayout.EndHorizontal();




            return returnValue;
        }

        public static void EndGroup() {
            GUILayout.EndVertical();
            GUILayout.Space( 2 );
        }
        #endregion
    }
}