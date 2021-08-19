using AssemblyGraph;
using NUnit.Framework;

namespace Graph
{
    public class GraphNodeManipulationTests
    {
        private Graph<SimpleNode, SimpleEdge> graph;
        private SimpleNode simpleNode;
        private const int SimpleNodeIndex = 10;

        [SetUp]
        public void SetUp()
        {
            graph = new Graph<SimpleNode, SimpleEdge>();
            simpleNode = new SimpleNode(SimpleNodeIndex);
        }


        [Test]
        public void AddNodeToGraphWithNoIndex()
        {
            SimpleNode noIndex = new SimpleNode();
            int returnedIndex = graph.AddNode(noIndex);
            Assert.AreEqual(GNode.InvalidNodeIndex, returnedIndex);
            Assert.AreEqual(1, graph.NumberOfNodes());
        }

        [Test]
        public void AddNodeWithCustomIndex()
        {
            int returnedIndex = graph.AddNode(simpleNode);
            Assert.AreEqual(SimpleNodeIndex, returnedIndex);
            Assert.AreEqual(1, graph.NumberOfNodes());
        }

        [Test]
        public void EmptyNumberOfNodes()
        {
            Assert.AreEqual(0, graph.NumberOfNodes());
        }

        [Test]
        public void MultipleNumberOfNodes()
        {
            SimpleNode node2 = AddNodeWithIndex(4);
            graph.AddNode(simpleNode);
            Assert.AreEqual(2, graph.NumberOfNodes());
        }

        private SimpleNode AddNodeWithIndex(int index)
        {
            SimpleNode node2 = new SimpleNode(index);
            graph.AddNode(node2);
            return node2;
        }

        [Test]
        public void GetNode()
        {
            graph.AddNode(simpleNode);
            SimpleNode getNode = graph.GetNode(SimpleNodeIndex);
            Assert.AreEqual(simpleNode, getNode);
        }

        [Test]
        public void RemoveNode()
        {
            graph.AddNode(simpleNode);
            Assert.AreEqual(1, graph.NumberOfNodes());
            graph.RemoveNode(SimpleNodeIndex);
            Assert.AreEqual(0, graph.NumberOfNodes());
        }

        [Test]
        public void RemoveANonExistingNode()
        {
            graph.RemoveNode(SimpleNodeIndex);
        }

        [Test]
        public void EmptyNextIndex()
        {
            Assert.AreEqual(0, graph.GetNextAvailableIndex());
        }

        [Test]
        public void SingleNextIndex()
        {
            AddNodeWithIndex(0);
            AddNodeWithIndex(1);
            graph.AddNode(simpleNode);
            Assert.AreEqual(2, graph.GetNextAvailableIndex());
        }

        [Test]
        public void GapNextIndex()
        {
            AddNodeWithIndex(1);
            AddNodeWithIndex(0);
            AddNodeWithIndex(3);
             graph.AddNode(simpleNode);
            Assert.AreEqual(2, graph.GetNextAvailableIndex());
        }

        [Test]
        public void RemoveMakesIndexAvailable()
        {
            for (int i = 0; i < 10; i++)
            {
                AddNodeWithIndex(i);
            }
            graph.RemoveNode(5);
            Assert.AreEqual(5, graph.GetNextAvailableIndex());
        }
    }
}