namespace GraphDomain
{
    public interface IEdgeStore<Edge> where Edge : GEdge
    {
        int Count { get; }
        void Add(Edge edge);
        void Remove(int start, int end);
        Edge GetEdge(int start, int end);
        string ToString();
        int[] GetOutwardEdges(int nodeIndex);
    }
}