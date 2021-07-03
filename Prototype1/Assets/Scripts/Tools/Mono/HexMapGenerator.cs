using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

[ExecuteInEditMode]
public class HexMapGenerator : MonoBehaviour
{
    public Vector3 prefab_scale => Vector3.one * mesh_scale * ruler.gird_scale;

    public float Paint_rotation { get => paint_rotation; set => paint_rotation = value; }

    //画笔内容
    public GameObject cur_block;

    //所有Mesh的大小调整参数
    public float mesh_scale;

    //绘制高度
    public float paint_height;

    //绘制旋转
    private float paint_rotation;

    //画笔块
    public Mesh pen_grid;

    public HexMapRuler ruler;

    public Vector3 mouse_position;
    public Vector3 mouse_grid_position;

    //长 宽
    //画笔形状

    private void OnEnable ()
    {
        pen_grid =
            Resources.Load<GameObject>( "HexMapCanvasGrid/正六边形倒角路基" ).
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