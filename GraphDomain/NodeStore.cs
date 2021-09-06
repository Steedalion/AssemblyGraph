﻿using System;
using System.Collections.Generic;
using System.Text;

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