using UnityEngine;

namespace MathLib.Shape
{
    /// <summary>
    /// MeshableShape is an interface class used to procedurally generate mesh objects
    /// from any class that implements it. The main idea is to generalize basic shapes
    /// and their methodology for creating and combining meshes. 
    /// </summary>
    public interface MeshableShape
    {
        Mesh GenerateMesh();

    }
}