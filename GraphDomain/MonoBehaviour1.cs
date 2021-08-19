using System.Collections.Generic;

namespace AssemblyGraph
{
    public class Graph<Node, Edge> where Edge : GEdge where Node : GNode
    {
        List<Edge> edges = new List<Edge>();
        NodeStore<Node> nodes = new NodeStore<Node>();
        private IndexStore indexs = new IndexStore();
        private Node start, target;

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
    }

    internal class IndexStore
    {
        private HashSet<int> store = new HashSet<int>();
        public void Add(int node1Index)
        {
            store.Add(node1Index);
        }

        public int Size()
        {
            return store.Count;
        }

        public void Remove(int index)
        {
            store.Remove(index);
        }

        public int GetNextAvailable()
        {
            for (int i = 0; i <= store.Count; i++)
            {
                if (!store.Contains(i))
                {
                    return i;
                }
            }
            return store.Count+1;
        }
    }

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


    public class GNode
    {
        public int Index;
        public static int InvalidNodeIndex = -1;

        public GNode(int index)
        {
            Index = index;
        }

        public GNode()
        {
            Index = InvalidNodeIndex;
        }
    }

    public class GEdge
    {
    }
}