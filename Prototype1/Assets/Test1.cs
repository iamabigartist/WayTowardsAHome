using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[ExecuteInEditMode]
public class Test1 : MonoBehaviour
{
    private Vector3 m_pos;

    // Start is called before the first frame update
    private void Start ()
    {
    }

    // Update is called once per frame
    private void Update ()
    {
        if (Physics.Raycast( Camera.main.ScreenPointToRay( Input.mousePosition ) , out RaycastHit hitInfo , 10000.0f , LayerMask.GetMask( "TouchGround" ) ))
        {
            m_pos = hitInfo.point;
        }
    }

    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere( m_pos , 10 );
    }
}