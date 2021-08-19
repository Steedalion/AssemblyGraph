using BFS;
using GraphDomain;
using NUnit.Framework;

namespace Graph
{
    public class BFS : GraphBaseTests
    {
        protected BreadthFirstSearch<SimpleNode, SimpleEdge> search;

        [SetUp]
        public void SetUp()
        {
            graph = new Graph<SimpleNode, SimpleEdge>();
        }
    }
}