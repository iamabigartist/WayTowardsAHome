using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

public class ShowResourceInfo : EditorWindow
{
    [MenuItem( "Show/ResourceInfo" )]
    public static void Open ()
    {
        var w = GetWindow<ShowResourceInfo>();
        w.Show();
    }

    private bool fold1 = false;

    private void OnGUI ()
    {
        if (Selection.objects.Length == 0) return;
        Object @object = Selection.objects[0];
        GUIContent content = EditorGUIUtility.ObjectContent( @object , @object.GetType() );
        EditorGUILayout.LabelField( content );
        EditorGUILayout.TextField( "Type: " , $"{@object.GetType().Name}" , EditorStyles.label );
        if (@object.GetType() == typeof( GameObject ))
        {
            GameObject gameObject = @object as GameObject;
            foreach (var component in gameObject.GetComponents<Component>())
            {
                var c_content = EditorGUIUtility.ObjectContent( component , component.GetType() );
                c_content.text = component.GetType().Name;
                EditorGUILayout.LabelField( c_content );
                if (component.GetType() == typeof( Transform ))
                {
                    fold1 = EditorGUILayout.BeginFoldoutHeaderGroup( fold1 , c_content );
                    if (fold1)
                    {
                        EditorGUI.indentLevel++;
                        Editor.CreateEditor( gameObject.transform ).OnInspectorGUI();
                        EditorGUI.indentLevel--;
                    }
                    EditorGUILayout.EndFoldoutHeaderGroup();
                }
            }
        }
    }

    private void OnSelectionChange ()
    {
        Repaint();
    }
}