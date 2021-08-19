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
    }
}