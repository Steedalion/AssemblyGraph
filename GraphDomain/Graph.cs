namespace GraphDomain
{
    public class Graph<Node, Edge> where Edge : GEdge where Node : GNode
    {
        DigraphStore<Edge> digraphs = new DigraphStore<Edge>();
        NodeStore<Node> nodes = new NodeStore<Node>();
        private IndexStore indexs = new IndexStore();
        private Node start, target;
        public string EdgesAsString => digraphs.ToString();

        public int GetNextAvailableIndex()
        {
            return indexs.GetNextAvailable();
        }

        public int AddNode(Node node1)
        {
            indexs.Add(node1.Index);
            nodes.Add(node1);
            return node1.Index;
        }

        public int NumberOfNodes() => indexs.Size();

        public Node GetNode(int index)
        {
            return nodes.GetNode(index);
        }


        public void RemoveNode(int index)
        {
            indexs.Remove(index);
        }

        public void AddEdge(Edge edge)
        {
            if (!nodes.Contains(edge.startFrom) || !nodes.Contains(edge.endAt))
            {
                throw new AddingEdgeWithoutNode();
            }

            digraphs.Add(edge);
        }

        public int NumberOfEdges()
        {
            return digraphs.Count;
        }

        public void RemoveEdge(int start, int end)
        {
            digraphs.Remove(start, end);
        }

        public Edge GetEdge(int start, int end)
        {
            return digraphs.GetEdge(start, end);
        }

        public bool isPresent(int nodeIndex)
        {
            return indexs.Contains(nodeIndex);
        }

        public int[] GetOutWardEdges(int nodeIndex)
        {
            return digraphs.GetOutwardEdges(nodeIndex);
        }
    }

    // public class AssemblyComponentBfs : GraphSearch
    // {
    //     public AssemblyComponentBfs(GraphTests<GNode, GEdge> graph)
    //     {
    //     }
    // }
    //
    // public class GraphSearch
    // {
    // }
}