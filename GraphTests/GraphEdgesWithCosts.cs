using System;
using NUnit.Framework;

namespace Graph
{
    public class GraphEdgesWithCosts : GraphEdgeTests
    {
        [Test]
        public void AddEdgeWithCost()
        {
            AddNodeWithIndex(1);
            AddNodeWithIndex(2);
            SimpleEdge edge = new SimpleEdge(1, 2, 3);
            graph.AddEdge(edge);
            SimpleEdge retrievedEdge = graph.GetEdge(1, 2);
            Assert.AreEqual(edge, retrievedEdge);
            Assert.AreEqual(edge.Cost, retrievedEdge.Cost);
        }

        [Test]
        public void ReplaceEdgeCost()
        {
            AddNodeWithIndex(1);
            AddNodeWithIndex(2);
            SimpleEdge edge = new SimpleEdge(1, 2, 3);
            graph.AddEdge(edge);

            SimpleEdge Updated = new SimpleEdge(1, 2, 0.5f);
            graph.AddEdge(Updated);

            SimpleEdge retrievedEdge = graph.GetEdge(1, 2);
            Assert.AreEqual(Updated, retrievedEdge);
            Assert.AreEqual(Updated.Cost, retrievedEdge.Cost);
        }

        [Test]
        public void PrintEdgesSingle()
        {
            AddNodeWithIndex(1);
            AddNodeWithIndex(2);
            SimpleEdge edge = new SimpleEdge(1, 2, 3);
            graph.AddEdge(edge);
            string edgesAsString = 
                    "Start:1 End:2 Cost:3"+Environment.NewLine;
            Assert.AreEqual(edgesAsString, graph.EdgesAsString);
            
        }
    }
}