using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public static class VectorExtension
{
    public static Vector3 RayX2V3 ( this Ray r , float v )
    {
        float c = ( v - r.origin.x ) / r.direction.x;
        return r.origin + c * r.direction;
    }

    public static Vector3 RayY2V3 ( this Ray r , float v )
    {
        float c = ( v - r.origin.y ) / r.direction.y;
        return r.origin + c * r.direction;
    }

    public static Vector3 RayZ2V3 ( this Ray r , float v )
    {
        float c = ( v - r.origin.z ) / r.direction.z;
        return r.origin + c * r.direction;
    }

    public static Vector3 XZ2V3 ( this Vector2 v , float y )
    {
        return new Vector3( v.x , y , v.y );
    }

    public static Vector2 XZ ( this Vector3 v )
    {
        return new Vector2( v.x , v.z );
    }
}