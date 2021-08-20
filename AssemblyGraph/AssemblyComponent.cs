using UnityEngine;

namespace AssemblyGraph
{
    public class AssemblyComponent :MonoBehaviour
    {
        public static string Type { get; } = "Component" ;
    }

    public class CylinderComponenet : AssemblyComponent
    {
      string type { get; } = "Cylinder" ;
    }
}