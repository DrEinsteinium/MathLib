using UnityEngine;
using System.Collections;

public static class Vector2Extension
{
    public static void FlipX(this Vector2 vec)
    {
        vec.x = vec.x * -1;
    }

    public static void FlipY(this Vector2 vec)
    {
        vec.y = vec.y * -1;
    }
}
