using UnityEngine;
using System;
using System.Collections.Generic;
using MathLib.Extensions;

namespace MathLib.Shape
{
    [System.Serializable]
    public class Triangle : Shape, MeshableShape
    {
        private float? area;
        private float? radius;

        public float Area
        { get
            {
                return (float)(area = area ?? CalculateTriangleArea());
            }
        }

        public float CircumRadius
        { get
            {
                return (float)(radius = radius ?? CalculateCircumradius());
            }
        }

        public Vector3 a { get { return verticies[0]; } set { verticies[0] = value; } }
        public Vector3 b { get { return verticies[1]; } set { verticies[1] = value; } }
        public Vector3 c { get { return verticies[2]; } set { verticies[2] = value; } }

        public Triangle(Vector3 a, Vector3 b, Vector3 c) : base()
        {
            verticies = new Vector3[3];
            this.a = a;
            this.b = b;
            this.c = c;
        }

        private float CalculateCircumradius()
        {
            float ab = a.DistanceTo(b);
            float bc = b.DistanceTo(c);
            float ca = c.DistanceTo(a);
            // s = a+b+c/2
            float s = (ab + bc + ca) * 0.5f;
            //r = abc(4*sqrt(s(s-a)(s-b)(s-c))
            float r = (ab * bc * ca) / (4 * Mathf.Sqrt(s * (s - ab) * (s - bc) * (s - ca)));
            return r;
        }

        private float CalculateTriangleArea()
        {
            float ab = a.DistanceTo(b);
            float bc = b.DistanceTo(c);
            float ca = c.DistanceTo(a);
            // s = a+b+c/2
            float s = (ab + bc + ca) * 0.5f;
            // area = sqrt(s(s-a)(s-b)(s-c))
            float area = Mathf.Sqrt(s * (s - ab) * (s - bc) * (s - ca));
            return area;
        }

        public Mesh GenerateMesh()
        {
            Mesh mesh = new Mesh();
            mesh.name = this.GetType().Name;
            int[] triangles = { 2, 1, 0 };
            mesh.SetVertices(new List<Vector3>(this.verticies));
            mesh.SetTriangles(triangles, 0);

            //calculte Normals
            mesh.RecalculateNormals();
            for (int i = 0; i < triangles.Length; i++)
                mesh.normals[i] = Vector3.up;

            //calculate UV's
            Vector2[] uvs = new Vector2[verticies.Length];
            for (int i = 0; i < uvs.Length; i++)
            {
                uvs[i] = new Vector2(verticies[i].x, verticies[i].z);
            }
            mesh.uv = uvs;

            return mesh;
        }
    }
}
