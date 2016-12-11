using UnityEngine;
using System.Collections;

namespace MathLib.Attribute
{
    /// <summary>
    /// Attribute that allows the programmer to display a field in the inspector
    /// but does not allow editing of that field. Used for things like UUIDs
    /// </summary>
    public class ReadOnlyAttribute : PropertyAttribute
    {   }
}
