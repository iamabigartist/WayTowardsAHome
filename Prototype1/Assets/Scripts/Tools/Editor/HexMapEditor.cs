using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor( typeof( HexMapGenerator ) )]
public class HexMapEditor : Editor
{
    public override void OnInspectorGUI ()
    {
        var g = target as HexMapGenerator;
        var e = CreateEditor( g.transform );
        e.OnInspectorGUI();
    }
}