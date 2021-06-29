using UnityEngine;

public struct HexMapRuler
{
    static public float GWIDTH, GHEIGHT;

    public float gird_scale;

    /// <summary>
    /// leftdown_point,x:left->right,y:down->up
    /// </summary>
    public Vector2 origin;

    public float Gwidth { get => gird_scale * GWIDTH; }
    public float Gheight { get => gird_scale * GHEIGHT; }

    static HexMapRuler ()
    {
        GWIDTH = 1.5f;
        GHEIGHT = Mathf.Sqrt( 3 ) / 2;
    }

    public HexMapRuler ( float gird_scale , Vector2 origin )
    {
        this.gird_scale = gird_scale;
        this.origin = origin;
    }

    private bool CheckIfCenter ( Vector2Int gird_pos )
    {
        return ( gird_pos.x + gird_pos.y ) % 2 == 0;
    }

    private Vector2 Gird2WorldPoint ( Vector2Int gird_pos )
    {
        return new Vector2( gird_pos.x * Gwidth , gird_pos.y * Gheight ) + origin;
    }

    private Vector2Int World2GirdPoint ( Vector2 world_pos )
    {
        float x_offset = world_pos.x - origin.x;
        float y_offset = world_pos.y - origin.y;
        int x = Mathf.CeilToInt( Mathf.FloorToInt( x_offset / ( Gwidth / 2 ) ) / 2f );
        int y = Mathf.CeilToInt( Mathf.FloorToInt( y_offset / ( Gheight / 2 ) ) / 2f );
        return new Vector2Int( x , y );
    }

    /// <summary>
    /// return the cloest point center on the gird.
    /// </summary>
    /// <param name="world_pos">the rare position</param>
    /// <returns></returns>
    public Vector2 Snap ( Vector2 world_pos )
    {
        Vector2Int grid_pos = World2GirdPoint( world_pos );
        Vector2 point_center = Gird2WorldPoint( grid_pos );
        if (!CheckIfCenter( grid_pos ))//not center
        {
            grid_pos.y += world_pos.y > point_center.y ? 1 : -1;
            point_center = Gird2WorldPoint( grid_pos );
        }
        return point_center;
    }
}