using GraphDomain;
using NUnit.Framework;

namespace Graph
{
    public class EdgeWithoutCosts : GraphEdgeTests
    {
        [Test]
        public void AddSimpleEdge()
        {
            Assert.AreEqual(0, graph.NumberOfEdges());
            AddNodeWithIndex(1);
            AddNodeWithIndex(2);
            AddEdgeBetweenNodes(1, 2);
        }

       

        [Test]
        public void AddEdgeWithoutNodes()
        {
            Assert.Throws<AddingEdgeWithoutNode>(() => graph.AddEdge(new SimpleEdge(1, 2)));
        }

        [Test]
        public void AddEdgeIncreaseAmount()
        {
            Assert.AreEqual(0, graph.NumberOfEdges());
            AddNodeWithIndex(1);
            AddNodeWithIndex(2);
            AddEdgeBetweenNodes(1, 2);
            Assert.AreEqual(1, graph.NumberOfEdges());
        }

        [Test]
        public void AddDeepEdgesIncreaseAmount()
        {
            AddNodeWithIndex(1);
            AddNodeWithIndex(2);
            AddNodeWithIndex(3);
            Assert.AreEqual(0, graph.NumberOfEdges());
            AddEdgeBetweenNodes(1, 2);
            Assert.AreEqual(1, graph.NumberOfEdges());
            AddEdgeBetweenNodes(2, 3);
            Assert.AreEqual(2, graph.NumberOfEdges());
        }

        [Test]
        public void AddWideEdgesIncreaseAmount()
        {
            AddNodeWithIndex(1);
            AddNodeWithIndex(2);
            AddNodeWithIndex(3);
            Assert.AreEqual(0, graph.NumberOfEdges());
            AddEdgeBetweenNodes(1, 2);
            Assert.AreEqual(1, graph.NumberOfEdges());
            AddEdgeBetweenNodes(1, 3);
            Assert.AreEqual(2, graph.NumberOfEdges());
        }

        [Test]
        public void RemoveEdgeDecreasesAmount()
        {
            AddNodeWithIndex(1);
            AddNodeWithIndex(2);
            AddNodeWithIndex(3);
            AddEdgeBetweenNodes(1, 2);
            AddEdgeBetweenNodes(1, 3);
            graph.RemoveEdge(start: 1, end: 2);
        }

        [Test]
        public void GetEdge()
        {
            AddNodeWithIndex(1);
            AddNodeWithIndex(2);
            AddNodeWithIndex(3);
            SimpleEdge onetwo = AddEdgeBetweenNodes(1, 2);
            Assert.AreEqual(onetwo, graph.GetEdge(1, 2));
            AddEdgeBetweenNodes(1, 3);
            AddEdgeBetweenNodes(2, 3);
        }

        [Test]
        public void GetMultipleEdges()
        {
            AddNodeWithIndex(1);
            AddNodeWithIndex(2);
            AddNodeWithIndex(3);
            SimpleEdge oneTwo = AddEdgeBetweenNodes(1, 2);
            Assert.AreEqual(oneTwo, graph.GetEdge(1, 2));
            AddEdgeBetweenNodes(1, 3);
            SimpleEdge twoThree = AddEdgeBetweenNodes(2, 3);
            Assert.AreEqual(twoThree, graph.GetEdge(2, 3));
            Assert.AreEqual(oneTwo, graph.GetEdge(1, 2));
        }
    }
}