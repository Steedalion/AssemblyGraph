using System.Collections.Generic;
using GraphDomain;
using NUnit.Framework;
using Search;

namespace Graph
{
    public class BfsStackTests : BFS
    {
        [SetUp]
        public void SetUp()
        {
            graph = new Graph<SimpleNode, SimpleEdge>();
            search = new BreadthFirstSearch<SimpleNode, SimpleEdge>(graph, 1, 5);
            for (int i = 0; i < 10; i++)
            {
                AddNodeWithIndex(i);
            }
        }

        [Test]
        public void CreateSearch()
        {
            search = new BreadthFirstSearch<SimpleNode, SimpleEdge>(graph, 1, 5);
            Assert.False(search.found);
        }

        [Test]
        public void SearchAStack()
        {
            AddEdgeBetweenNodes(1, 5);
            search = new BreadthFirstSearch<SimpleNode, SimpleEdge>(graph, 1, 5);
            Assert.True(search.found);
            
        }

        [Test]
        public void SimpleStackRoute()
        {
             AddEdgeBetweenNodes(1, 5);
            search = new BreadthFirstSearch<SimpleNode, SimpleEdge>(graph, 1, 5);

            List<int> route = search.BuildRoute();
            Assert.AreEqual(2,route.Count);
            Assert.AreEqual(1, route[0]);
            Assert.AreEqual(5, route[1]);
        }

        [Test]
        public void SearchDeepStack()
        {
            AddEdgeBetweenNodes(1, 2);
            AddEdgeBetweenNodes(2, 3);
            AddEdgeBetweenNodes(3, 4);
            search = new BreadthFirstSearch<SimpleNode, SimpleEdge>(graph, 1, 5);
            Assert.False(search.found);
            search = new BreadthFirstSearch<SimpleNode, SimpleEdge>(graph, 1, 4);
            Assert.True(search.found);
            
            List<int> route = search.BuildRoute();
            Assert.AreEqual(4,route.Count);
            Assert.AreEqual(1, route[0]);
            Assert.AreEqual(2, route[1]);
            Assert.AreEqual(3, route[2]);
            Assert.AreEqual(4, route[3]);
        }

        [Test]
        public void DeepStackRoute()
        {
            AddEdgeBetweenNodes(1, 2);
            AddEdgeBetweenNodes(2, 3);
            AddEdgeBetweenNodes(3, 4);
            search = new BreadthFirstSearch<SimpleNode, SimpleEdge>(graph, 1, 4);
            
            List<int> route = search.BuildRoute();
            Assert.AreEqual(4,route.Count);
            Assert.AreEqual(1, route[0]);
            Assert.AreEqual(2, route[1]);
            Assert.AreEqual(3, route[2]);
            Assert.AreEqual(4, route[3]);
        }

        [Test]
        public void SearchWideGraph()
        {
            AddEdgeBetweenNodes(1, 2);
            AddEdgeBetweenNodes(1, 3);
            AddEdgeBetweenNodes(1, 4);
            search = new BreadthFirstSearch<SimpleNode, SimpleEdge>(graph, 1, 5);
            Assert.False(search.found);
            search = new BreadthFirstSearch<SimpleNode, SimpleEdge>(graph, 1, 4);
            Assert.True(search.found);
        }

        [Test]
        public void SearchSmallGraph()
        {
            AddEdgeBetweenNodes(1, 2);
            AddEdgeBetweenNodes(1, 3);
            AddEdgeBetweenNodes(3, 4);

            search = new BreadthFirstSearch<SimpleNode, SimpleEdge>(graph, 1, 5);
            Assert.False(search.found);
            search = new BreadthFirstSearch<SimpleNode, SimpleEdge>(graph, 1, 4);
            Assert.True(search.found);
        }  
        
        [Test]
        public void SearchRepeatingNode()
        {
            AddEdgeBetweenNodes(1, 2);
            AddEdgeBetweenNodes(1, 3);
            AddEdgeBetweenNodes(3, 2);
            AddEdgeBetweenNodes(3, 4);

            search = new BreadthFirstSearch<SimpleNode, SimpleEdge>(graph, 1, 5);
            Assert.False(search.found);
            search = new BreadthFirstSearch<SimpleNode, SimpleEdge>(graph, 1, 4);
            Assert.True(search.found);
        }
    }
}