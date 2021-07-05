using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

[ExecuteInEditMode]
public class HexMapGenerator : MonoBehaviour
{
    public Vector3 prefab_scale => Vector3.one * mesh_scale * ruler.gird_scale;

    public int Paint_rotation
    {
        get => paint_rotation * 60;
        set
        {
            paint_rotation = value % 6;
        }
    }

    //��������
    public GameObject cur_block;

    //����Mesh�Ĵ�С��������
    public float mesh_scale;

    //���Ƹ߶�
    public float paint_height;

    //������ת
    private int paint_rotation;

    //���ʿ�
    public Mesh pen_grid;

    public HexMapRuler ruler;

    public Vector3 mouse_position;
    public Vector3 mouse_grid_position;

    //�� ��
    //������״

    private void OnEnable ()
    {
        pen_grid =
            Resources.Load<GameObject>( "HexMapCanvasGrid/�������ε���·��" ).
            GetComponentInChildren<MeshFilter>().sharedMesh;
    }

    private void OnDrawGizmos ()
    {
        Gizmos.color = new Color( 1 , 1 , 1 , 0.3f );
        Gizmos.DrawMesh(
            cur_block.GetComponentInChildren<MeshFilter>().sharedMesh ,
            mouse_grid_position , Quaternion.Euler( 0 , Paint_rotation , 0 ) , prefab_scale * 1.01f );
    }
}