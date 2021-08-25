using System.Collections.Generic;

namespace GraphDomain
{
    public class NodeStore<Node> where Node : GNode
    {
        private Dictionary<int, Node> nodes = new Dictionary<int, Node>();
        public int Count => nodes.Count;
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

        public int GetNextAvailableIndex()
        {
           for (int i = 0; i < nodes.Count; i++)
            {
                if (!nodes.ContainsKey(i))
                {
                    return i;
                }
            }

            return nodes.Count ;
        }
    }
}