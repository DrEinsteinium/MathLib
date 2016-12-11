using UnityEngine;

namespace MathLib.Shape
{
    /// <summary>
    /// Shape is an abstract base class used to define a 2D or 3D object with a set
    /// of verticies as Vector3 objects. 
    /// </summary>
    public abstract class Shape
    {
        protected Vector3[] verticies;

        public Shape()
        {
            this.verticies = new Vector3[]{ };
        }

        /// <summary>
        /// The Vector3[] of verticies that define this shape.
        /// </summary>
        /// <returns>The set of verticies that defines this shape.</returns>
        public Vector3[] GetVerticies()
        {
            return verticies;
        }
    }
}
