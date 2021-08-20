using System.Collections.Generic;
using GraphDomain;
using UnityEngine;

namespace AssemblyGraph
{
    public class ComponentNode:GNode
    {
        private List<ConnectorNode> connectors;
        public string name;
        public Transform transform;
        public string type;


        public ComponentNode(int index, string name, Transform transform, string type) : base(index)
        {
            this.name = name;
            this.transform = transform;
            this.type = type;
        }

        public ComponentNode(string name, Transform transform, string type)
        {
            this.name = name;
            this.transform = transform;
            this.type = type;
        }

        public IEnumerable<ConnectorNode> GetAllConnectors()
        {
            return connectors;
        }
    }
}