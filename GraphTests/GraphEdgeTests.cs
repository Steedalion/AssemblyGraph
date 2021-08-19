using GraphDomain;
using NUnit.Framework;

namespace Graph
{
    public class GraphEdgeTests : GraphBaseTests
    {
        [SetUp]
        public void SetUp()
        {
            graph = new Graph<SimpleNode, SimpleEdge>();
        }
    }
}