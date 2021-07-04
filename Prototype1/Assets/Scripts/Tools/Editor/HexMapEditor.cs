using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor( typeof( HexMapGenerator ) )]
public class HexMapEditor : Editor
{
    private HexMapGenerator g;
    private Transform grid_list;

    private void OnEnable ()
    {
        g = target as HexMapGenerator;
        grid_list = g.transform.Find( "MapGrids" );
    }

    private void OnSceneGUI ()
    {
        InputAction();

        Ray r = HandleUtility.GUIPointToWorldRay( Event.current.mousePosition );
        g.mouse_position = r.RayY2V3( g.paint_height );
        Handles.DrawWireDisc( g.mouse_position , Vector3.up , 2 );
        g.mouse_grid_position = g.ruler.Snap( g.mouse_position.XZ() ).XZ2V3( g.mouse_position.y );

        //Debug.Log( GetGrid( g.mouse_grid_position ) );
    }

    public override void OnInspectorGUI ()
    {
        EditorGUILayout.PropertyField(
            serializedObject.FindProperty( "ruler" ) ,
            new GUIContent( "地图设置" ) );
        EditorGUILayout.PropertyField(
            serializedObject.FindProperty( "paint_height" ) ,
            new GUIContent( "绘制高度" ) );
        EditorGUILayout.IntField( new GUIContent( "画笔旋转角度" ) , g.Paint_rotation , EditorStyles.label );

        EditorGUILayout.PropertyField(
            serializedObject.FindProperty( "cur_block" ) ,
            new GUIContent( "样本地图块" , "是一个设置好的地图块的Prefab" ) );
        EditorGUILayout.PropertyField(
            serializedObject.FindProperty( "mesh_scale" ) ,
            new GUIContent( "模型调整参数" ) );

        serializedObject.ApplyModifiedProperties();
    }

    public void DrawSpaceAxisOnMouse ()
    {
        Handles.color = Color.red;
        Handles.DrawDottedLine(
            g.mouse_position - Vector3.right * 10000f ,
            g.mouse_position + Vector3.right * 10000f , 3 );
        Handles.color = Color.green;
        Handles.DrawDottedLine(
            g.mouse_position - Vector3.up * 10000f ,
            g.mouse_position + Vector3.up * 10000f , 3 );
        Handles.color = Color.blue;
        Handles.DrawDottedLine(
            g.mouse_position - Vector3.forward * 10000f ,
            g.mouse_position + Vector3.forward * 10000f , 3 );
    }

    private void InputAction ()
    {
        if (IfPaint()) { PaintOne(); }
        if (IfRotate()) { g.Paint_rotation = g.Paint_rotation / 60 + 1; }
    }

    private bool IfPaint ()
    {
        return Event.current.keyCode == KeyCode.Alpha1 && Event.current.type == EventType.KeyUp;
    }

    private bool IfRotate ()
    {
        return Event.current.keyCode == KeyCode.Alpha3 && Event.current.type == EventType.KeyUp;
    }

    private void PaintOne ()
    {
        var gameobj = Instantiate( g.cur_block ,
            //g.mouse_grid_position.RotateAround( g.mouse_grid_position , g.Paint_rotation , Vector3.up ) ,
            g.mouse_grid_position ,
            Quaternion.Euler( 0 , g.Paint_rotation , 0 ) , grid_list );
        gameobj.transform.localScale = g.prefab_scale;
    }

    //private GameObject GetGrid ( Vector3 pos )
    //{
    //    var list = Physics.OverlapSphere( pos , g.prefab_scale.magnitude / 5.0f );
    //    if (list.Length == 0) return null;
    //    if (list.Length > 1) throw new System.Exception( "GridOverlap!" );
    //    return list[0].gameObject;
    //}

    //Get paint shape from collider
    //Get paint shape from selection
    //Get paint color from current shape
    //Fill paint color using the block
    //Paint/Delete
}