using UnityEngine;

public static class GameUtilities 
{
    //public static LayerMask BLOCK_LAYER = LayerMask.NameToLayer("Block");
    public static float BlockMovementTime = 0.5f; 

    public static Vector3 GetMiddlePoint(Vector3 minPosition, Vector3 maxPosition)
    {
        return (minPosition + maxPosition) / 2;
    }

    public static Vector2 GetMiddlePoint(Vector2 minPosition, Vector2 maxPosition)
    {
        return (minPosition + maxPosition) / 2;
    }

    public static float GetMiddlePoint(float minPosition, float maxPosition)
    {
        return (minPosition + maxPosition) / 2;
    }

    public static Vector3 Snap(Vector3 pos, int v)
    {
        float x = pos.x;
        float y = pos.y;
        float z = pos.z;
        x = Mathf.FloorToInt(x / v) * v;
        y = Mathf.FloorToInt(y / v) * v;
        z = Mathf.FloorToInt(z / v) * v;
        return new Vector3(x, y, z);
    }

    public static int Snap(int pos, int v)
    {
        float x = pos;
        return Mathf.FloorToInt(x / v) * v;
    }

    public static float Snap(float pos, float v)
    {
        float x = pos;
        return Mathf.FloorToInt(x / v) * v;
    }
}
