using System.Collections.Generic;

namespace GraphDomain
{
    internal class NodeStore<Node> where Node : GNode
    {
        private Dictionary<int, Node> nodes = new Dictionary<int, Node>();

        public void Add(Node node)
        {
            nodes[node.Index] = node;
        }

        public Node GetNode(int index)
        {
            return nodes[index];
        }

        public bool Contains(int nodeIdex)
        {
            return nodes.ContainsKey(nodeIdex);
        }
    }
}