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
        Ray r = HandleUtility.GUIPointToWorldRay( Event.current.mousePosition );
        g.mouse_position = r.RayY2V3( g.paint_height );
        Handles.DrawWireDisc( g.mouse_position , Vector3.up , 2 );
        g.mouse_grid_position = g.ruler.Snap( g.mouse_position.XZ() ).XZ2V3( g.mouse_position.y );

        InputAction();
    }

    public override void OnInspectorGUI ()
    {
        g.cur_block = EditorGUILayout.ObjectField( label: new GUIContent( "样本地图块" , "是一个设置好的地图块的Prefab" ) , obj: g.cur_block , objType: typeof( GameObject ) , allowSceneObjects: false ) as GameObject;
        EditorGUILayout.PropertyField( serializedObject.FindProperty( "mesh_scale" ) , new GUIContent( "模型调整参数" ) );

        g.paint_height = EditorGUILayout.FloatField( label: new GUIContent( "绘制高度" ) , value: g.paint_height , style: EditorStyles.numberField );
        EditorGUILayout.PropertyField( serializedObject.FindProperty( "ruler" ) , new GUIContent( "地图设置" ) );

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
    }

    private bool IfPaint ()
    {
        return Event.current.keyCode == KeyCode.Alpha1 && Event.current.type == EventType.KeyDown;
    }

    private void PaintOne ()
    {
        var gameobj = Instantiate( g.cur_block , g.mouse_grid_position , Quaternion.identity , grid_list );
        gameobj.transform.localScale = g.prefab_scale;
    }

    //Get paint shape from collider
    //Get paint shape from selection
    //Get paint color from current shape
    //Fill paint color using the block
    //Paint/Delete
}