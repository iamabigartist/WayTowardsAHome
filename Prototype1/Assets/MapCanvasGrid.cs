using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[ExecuteInEditMode]
public class MapCanvasGrid : MonoBehaviour
{
    static private float width = 100;

    public int i;

    private void Update ()
    {
        i = (int)( transform.position.x + transform.position.z * width );
    }
}