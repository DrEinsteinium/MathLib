using UnityEngine;

namespace MathLib.Extensions
{
    public static class Vector3Extension
    {
        public static float DistanceTo(this Vector3 v1, Vector3 v2)
        {
            return Mathf.Sqrt(v1.DistanceToSq(v2));
        }

        public static float DistanceToSq(this Vector3 v1, Vector3 v2)
        {
            float dist = 0;
            dist += Mathf.Pow(v2.x - v1.x, 2.0f);
            dist += Mathf.Pow(v2.y - v1.y, 2.0f);
            dist += Mathf.Pow(v2.z - v1.z, 2.0f);
            return dist;
        }

        public static void Clamp(this Vector3 vector, Vector3 min, Vector3 max)
        {
            // max check
            if (vector.x > max.x) vector.x = max.x;
            if (vector.y > max.y) vector.y = max.y;
            if (vector.z > max.z) vector.z = max.z;
            // min check
            if (vector.x < min.x) vector.x = min.x;
            if (vector.y < min.y) vector.y = min.y;
            if (vector.z < min.z) vector.z = min.z;
        }

    }

}
