using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
public class TestSort : MonoBehaviour
{
    public float radius;

    private void OnValidate ()
    {
        var collider_list = Physics.OverlapSphere( transform.position , radius );
        print( "List:{ " + String.Join( " , " , collider_list.Select( ( c ) => { return c.GetComponent<MapCanvasGrid>().i; } ) ) + " }" );
    }

    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere( transform.position , radius );
    }
}