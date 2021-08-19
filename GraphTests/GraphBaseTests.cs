using System.Threading;
using GraphDomain;

namespace Graph
{
    public class GraphBaseTests
    {
        protected Graph<SimpleNode, SimpleEdge> graph;

        protected SimpleNode AddNodeWithIndex(int index)
        {
            SimpleNode node2 = new SimpleNode(index);
            graph.AddNode(node2);
            return node2;
        }

        protected SimpleEdge AddEdgeBetweenNodes(int from, int to)
        {
            SimpleEdge edge = new SimpleEdge(from, to);
            graph.AddEdge(edge);
            return edge;
        }
    }
}