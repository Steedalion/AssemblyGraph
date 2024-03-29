﻿using GraphDomain;
using NUnit.Framework;

namespace Graph
{
    public class NodeTests : GraphBaseTests
    {
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
        public void AddTwoNoIdexNodes()
        {
            SimpleNode one = new SimpleNode();
            SimpleNode two = new SimpleNode();
            int onesIndex = graph.AddNode(one);
            int twoIndex = graph.AddNode(two);
            Assert.AreNotEqual(onesIndex,twoIndex);
            Assert.IsTrue(graph.nodes.Contains(one.Index));
            Assert.IsTrue(graph.nodes.Contains(two.Index));
            Assert.AreSame(one,graph.GetNode(one.Index));
            Assert.AreSame(two,graph.GetNode(two.Index));
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

        [Test]
        public void EmptyGraphContainsNothing()
        {
            Assert.IsFalse( graph.isPresent(SimpleNodeIndex));
            AddNodeWithIndex(1);
            Assert.IsTrue(graph.isPresent(1));
            graph.RemoveNode(1);
            Assert.IsFalse(graph.isPresent(1));
        }
    }
}