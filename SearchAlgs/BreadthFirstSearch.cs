using System.Collections.Generic;
using GraphDomain;

namespace Search
{
    public class BreadthFirstSearch<Node,Edge> where Node : GNode where Edge : GEdge
    {
        private Graph<Node, Edge> graph;
        public bool found;
        private int start;
        private int end;
        private HashSet<int> visitedNodes = new HashSet<int>();
        private Dictionary<int,int> parentOf = new Dictionary<int, int>();

        public BreadthFirstSearch(Graph<Node,Edge> searchGraph, int startIndex, int endIndex)
        {
             graph = searchGraph;
             start = startIndex;
             end = endIndex;
             found = Search();
        }

        private bool Search()
        {
            Queue<int> toBeSearched = new Queue<int>();
            toBeSearched.Enqueue(start);
            while (toBeSearched.Count>0)
            {

                int current = toBeSearched.Dequeue();
                visitedNodes.Add(current);
                if (current == end)
                {
                    return true;
                }

                // Node currentNode = graph.GetNode(current);
                int[] neighbors = graph.GetOutWardEdges(current);
                foreach (int neighbor in neighbors)
                {
                    if (!visitedNodes.Contains(neighbor))
                    {
                        toBeSearched.Enqueue(neighbor);
                        parentOf[neighbor] = current;
                    }
                }
            }

            return false;
        }

        public List<int> BuildRoute()
        {
            List<int> path = new List<int>();
            int current = end;
            path.Add(current);
            while (current != start)
            {
                current = parentOf[current];
                path.Add(current);
            }

            path.Reverse();
            return path;
        }
    }

}