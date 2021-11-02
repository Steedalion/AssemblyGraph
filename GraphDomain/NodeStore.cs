using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphDomain
{
    public class NodeStore<Node> : IEnumerable<Node> where Node : GNode
    {
        private Dictionary<int, Node> nodes = new Dictionary<int, Node>();
        public int Count => nodes.Count;

        public void Add(Node node)
        {
            if (node.Index == GNode.InvalidNodeIndex)
            {
                node.Index = GetNextAvailableIndex();
            }
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

            public IEnumerator GetEnumerator()
        {
            return nodes.Values.GetEnumerator();
        }
        IEnumerator<Node> IEnumerable<Node>.GetEnumerator()
        {
            return nodes.Values.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<int, Node> node in nodes)
            {
                builder.Append("Node index:" + node.Key);
                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
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

            return nodes.Count;
        }
    }
}