using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MathLib.Shape
{
    class Circle : Polygon, MeshableShape
    {
        public Vector2 Center { get { return center; } }

        public float Area { get { return 2 * Mathf.PI * radius; } }

        public Circle(Vector3 center, float radius) : base(360, radius, center)
        {
        }
    }
}
