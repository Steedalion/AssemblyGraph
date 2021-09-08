using System;
using GraphDomain;
using NUnit.Framework;

namespace Graph
{
    public class NodeStoreTests
    {
        NodeStore<SimpleNode> store;

        [SetUp]
        public void Setup()
        {
            store = new NodeStore<SimpleNode>();
        }

        [Test]
        public void ToStringShowsAllNodes()
        {
            SimpleNode node = new SimpleNode(0);
            SimpleNode node2 = new SimpleNode(2);
            store.Add(node);
            store.Add(node2);
            Assert.AreEqual("Node index:0" + Environment.NewLine
                                           + "Node index:2" + Environment.NewLine
                , store.ToString());
        }

        [Test]
        public void AddNode()
        {
            SimpleNode node = new SimpleNode(0);
            store.Add(node);
            Assert.AreEqual(1, store.Count);
        }

        [Test]
        public void GetNode()
        {
            SimpleNode node = new SimpleNode(0);
            SimpleNode node2 = new SimpleNode(1);
            store.Add(node);
            store.Add(node2);
            Assert.AreEqual(2, store.Count);
            Assert.AreSame(node, store.GetNode(0));
            Assert.AreSame(node2, store.GetNode(1));
        }

        [Test]
        public void AddExistingNode()
        {
            SimpleNode node = new SimpleNode(0);
            SimpleNode node2 = new SimpleNode(0);
            store.Add(node);
            store.Add(node2);
            Assert.AreEqual(1, store.Count);
            Assert.AreSame(node2, store.GetNode(0));
        }

        [Test]
        public void GetNextAvailableNode()
        {
            SimpleNode node = new SimpleNode(0);
            SimpleNode node2 = new SimpleNode(2);
            Assert.AreEqual(0, store.GetNextAvailableIndex());
            store.Add(node);
            Assert.AreEqual(1, store.GetNextAvailableIndex());
            store.Add(node2);
            Assert.AreEqual(2, store.Count);
            Assert.AreEqual(1, store.GetNextAvailableIndex());
        }

        [Test]
        public void ForeachWithNodeStore()
        {
             SimpleNode node = new SimpleNode(0);
            SimpleNode node2 = new SimpleNode(2);
            store.Add(node);
            store.Add(node2);

            foreach (SimpleNode simpleNode in store)
            {
                Assert.NotNull(simpleNode);
            }
        }
    }
}