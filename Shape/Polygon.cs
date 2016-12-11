using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MathLib.Shape
{
    class Polygon : Shape, MeshableShape
    {
        protected int numSides;

        protected float radius;
        public float Radius { get { return radius; } }

        protected Vector3 center;

        public Polygon(int numSides, float radius, Vector3 center) : base()
        {
            this.center = center;
            this.radius = radius;
            this.numSides = numSides;
            InitializeVerticies();
        }

        private void InitializeVerticies()
        {
            verticies = new Vector3[numSides];
            int inc = Mathf.FloorToInt(360.0f / (float)numSides);
            int count = 0;
            for (int i = 0; i < 360; i+= inc)
            {
                float x = Mathf.Cos(Mathf.Deg2Rad * i) * radius;
                float y = Mathf.Sin(Mathf.Deg2Rad * i) * radius;
                this.verticies[count++] = new Vector3(x, y, 0f);
            }
        }


        public Mesh GenerateMesh()
        {
            Mesh mesh = new Mesh();
            mesh.name = this.GetType().Name;
            CombineInstance[] combine = new CombineInstance[numSides];
            for (int i = 0; i < numSides; i++)
            {
                Triangle tri;
                if (i == numSides - 1)
                    tri = new Triangle(verticies[0], verticies[i], this.center);
                else
                    tri = new Triangle(verticies[i + 1], verticies[i], this.center);

                combine[i].mesh = tri.GenerateMesh();
            }
            mesh.CombineMeshes(combine, true, false);
            return mesh;
        }
    }
}
