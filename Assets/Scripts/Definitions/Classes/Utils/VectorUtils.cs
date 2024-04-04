using System;
using UnityEngine;

public class VectorUtils
{
    public static Vector3 Vector2To3(Vector2 vector, float y = 0)
    {
        return new Vector3(vector.x, y, vector.y);
    }
}
