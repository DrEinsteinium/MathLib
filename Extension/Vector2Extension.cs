using UnityEngine;
using System.Collections;


namespace MathLib.Extensions
{
    public static class Vector2Extension
    {
        /// <summary>
        /// Multiplies the X component of this vector by -1
        /// </summary>
        public static void FlipX(this Vector2 vec)
        {
            vec.x = vec.x * -1;
        }

        /// <summary>
        /// Multiplies the Y component of this vector by -1
        /// </summary>
        public static void FlipY(this Vector2 vec)
        {
            vec.y = vec.y * -1;
        }
    }
}
