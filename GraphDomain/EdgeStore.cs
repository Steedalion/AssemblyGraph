using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphDomain
{
    internal class EdgeStore<Edge> where Edge : GEdge
    {
        private readonly Dictionary<int, Dictionary<int, Edge>> edges = new Dictionary<int, Dictionary<int, Edge>>();

        public int Count
        {
            get
            {
                int size = 0;
                foreach (KeyValuePair<int, Dictionary<int, Edge>> startPair in edges)
                {
                    size += startPair.Value.Count;
                }

                return size;
            }
        }

        public void Add(Edge edge)
        {
            if (!edges.ContainsKey(edge.startFrom))
            {
                edges[edge.startFrom] = new Dictionary<int, Edge>();
            }

            edges[edge.startFrom][edge.endAt] = edge;
        }


        public void Remove(int start, int end)
        {
            edges[start].Remove(end);
            if (edges[start].Count <= 1)
            {
                edges.Remove(start);
            }
        }


        public Edge GetEdge(int start, int end)
        {
            return edges[start][end];
        }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<int, Dictionary<int, Edge>> startPair in edges)
            {
                foreach (KeyValuePair<int, Edge> endPair in startPair.Value)
                {
                    builder.Append("Start:" + startPair.Key);
                    builder.Append(" End:" + endPair.Key);
                    builder.Append(" Cost:" + endPair.Value.Cost);
                    builder.Append(Environment.NewLine);
                }
            }

            return builder.ToString();
        }

        public int[] GetOutwardEdges(int nodeIndex)
        {
            return !edges.ContainsKey(nodeIndex) ? new int[0] : edges[nodeIndex].Keys.ToArray();
        }
    }
}