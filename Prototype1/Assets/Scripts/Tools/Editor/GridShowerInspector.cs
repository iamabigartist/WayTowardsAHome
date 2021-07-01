using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor( typeof( GridShower ) )]
public class GridShowerInspector : Editor
{
    private void OnSceneGUI ()
    {
        var shower = target as GridShower;

        if (Physics.Raycast( HandleUtility.GUIPointToWorldRay( Event.current.mousePosition ) , out RaycastHit hit , Mathf.Infinity , LayerMask.GetMask( "TouchGround" ) ))
        {
            var mousePos = hit.point;
            //mouseRot = Quaternion.FromToRotation( Vector3.up , hit.normal );
            Handles.color = Color.blue;
            Handles.DrawWireDisc( mousePos , hit.normal , 2 );
        }
    }

    public override void OnInspectorGUI ()
    {
        //base.OnInspectorGUI();
        GUILayout.Button( "asdasd" );
    }
}