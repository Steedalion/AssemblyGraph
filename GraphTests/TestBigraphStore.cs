using System.Linq;
using GraphDomain;
using NUnit.Framework;

namespace Graph
{
    public class TestBigraphStore
    {
        private BigraphStore<SimpleEdge> distore;
        private int small = 5;
        private int medium = 7;
        private int large = 10;

        private SimpleNode smallNode;
        private SimpleNode largeNode;
        private SimpleNode mediumNode;
        
        private SimpleEdge wrongOrder;
        private SimpleEdge correctOrder;

        [SetUp]
        public void Create()
        {
            distore = new BigraphStore<SimpleEdge>();
        
            smallNode = new SimpleNode(small);
            largeNode = new SimpleNode(large);
            mediumNode = new SimpleNode(medium);
            correctOrder = new SimpleEdge(small, large);
            wrongOrder = new SimpleEdge(large, small);
        }

        [Test]
        public void AddNodeInCorrectOrder()
        {
            correctOrder = new SimpleEdge(small, large);
            distore.Add(correctOrder);
        }

        [Test]
        public void GetNodeInCorrectOrder()
        {
            correctOrder = new SimpleEdge(small, large);
            distore.Add(correctOrder);
            Assert.AreSame(correctOrder, distore.GetEdge(small, large));
        }

        [Test]
        public void GetNodeInWrongOrder()
        {
            correctOrder = new SimpleEdge(small, large);
            distore.Add(correctOrder);
            Assert.AreSame(correctOrder, distore.GetEdge(large, small));
        }

        [Test]
        public void AddNodeInWrongOrder()
        {
            distore.Add(wrongOrder);
            Assert.AreEqual(wrongOrder, distore.GetEdge(large, small));
            Assert.AreEqual(wrongOrder, distore.GetEdge(small, large));
        }

        [Test]
        public void EmptyCountZero()
        {
            Assert.AreEqual(0, distore.Count);
        }

        [Test]
        public void CountStillWorks()
        {
            distore.Add(correctOrder);
            Assert.AreEqual(1, distore.Count);
        }

        [Test]
        public void CountStillWorks2()
        {
            distore.Add(wrongOrder);
            Assert.AreEqual(1, distore.Count);
        }

        [Test]
        public void RemoveGraphCorrectOrder()
        {
            distore.Add(correctOrder);
            distore.Remove(small, large);
            Assert.AreEqual(0, distore.Count);
        }

        [Test]
        public void RemoveGraphWrongOrder()
        {
            distore.Add(correctOrder);
            distore.Remove(large, small);
            Assert.AreEqual(0, distore.Count);
            distore.Add(correctOrder);
            distore.Remove(small, large);
            Assert.AreEqual(0, distore.Count);
        }

        [Test]
        public void GetOutwardEdges()
        {
            SimpleEdge edge = new SimpleEdge(small, medium);
            distore.Add(edge);
            distore.Add(wrongOrder);
            Assert.AreEqual(2,distore.Count);
            var outwardEdges = distore.GetOutwardEdges(small);
            Assert.AreEqual(2,outwardEdges.Length);
            outwardEdges.Contains(medium);
            outwardEdges.Contains(large);
        }

        [Test]
        public void AddingSameEdgeOverides()
        {
            distore.Add(correctOrder);
            distore.Add(wrongOrder);
            Assert.AreEqual(1,distore.Count);
        }
    }
}