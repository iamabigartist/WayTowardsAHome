using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

[ExecuteInEditMode]
public class HexMapGenerator : MonoBehaviour
{
    //����Mesh�Ĵ�С��������
    public float mesh_scale;

    public Vector3 prefab_scale => Vector3.one * mesh_scale * ruler.gird_scale;

    //��������
    public GameObject cur_block;

    //���Ƹ߶�
    public float paint_height;

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
            pen_grid ,
            mouse_grid_position , Quaternion.identity , prefab_scale );
    }
}