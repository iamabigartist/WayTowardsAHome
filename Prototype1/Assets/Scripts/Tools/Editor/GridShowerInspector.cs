using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor( typeof( GridShower ) )]
public class GridShowerInspector : Editor
{
    private void OnSceneGUI ()
    {
        if (Physics.Raycast( HandleUtility.GUIPointToWorldRay( Event.current.mousePosition ) , out RaycastHit hit , Mathf.Infinity , LayerMask.GetMask( "TouchGround" ) ))
        {
            Debug.Log( hit.point );
            var mousePos = hit.point;
            //mouseRot = Quaternion.FromToRotation( Vector3.up , hit.normal );
            Handles.color = Color.blue;
            Handles.DrawWireDisc( mousePos , hit.normal , 20 );
            Handles.DrawWireCube( mousePos , Vector3.one );
            Handles.DrawWireCube( mousePos , Vector3.one );
            Handles.DrawWireCube( mousePos , Vector3.one );
            Handles.DrawWireCube( mousePos , Vector3.one );
            Handles.DrawWireCube( mousePos , Vector3.one );
            Handles.DrawWireCube( mousePos , Vector3.one );
            Handles.DrawWireCube( mousePos , Vector3.one );
            Handles.DrawWireCube( mousePos , Vector3.one );
            Handles.DrawWireCube( mousePos , Vector3.one );
            Handles.DrawWireCube( mousePos , Vector3.one );
            Handles.DrawWireCube( mousePos , Vector3.one );
            Handles.DrawWireCube( mousePos , Vector3.one );
            Handles.DrawWireCube( mousePos , Vector3.one );
            Handles.DrawWireCube( mousePos , Vector3.one );
            Handles.DrawWireCube( mousePos , Vector3.one );
            Handles.DrawWireCube( mousePos , Vector3.one );
        }
    }
}