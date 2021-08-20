namespace GraphDomain
{
    /// <summary>
    /// StoresEdges for bidirectional graphs. This is done by selecting
    /// the smaller index first. For example Get(1,2) = Get(2,1).
    /// This ensures that a bidirectional graph is maintained.
    /// </summary>
    /// <typeparam name="Edge"></typeparam>
    public class BigraphStore<Edge> : DigraphStore<Edge> where Edge : GEdge
    {
        public int Count { get =>base.Count; }
        public void Add(Edge edge)
        {
            SmallestIndexFirst(edge);
            base.Add(edge);
        }

        private void SmallestIndexFirst(Edge edge)
        {
            if (edge.startFrom <= edge.endAt) return;
            int buffer = edge.startFrom;
            edge.startFrom = edge.endAt;
            edge.endAt = buffer;
        }

        public void Remove(int start, int end)
        {
            BigraphStore<Edge>.SortIndex sorted = new SortIndex(start, end);
            base.Remove(sorted.smaller, sorted.larger);
        }


        public Edge GetEdge(int start, int end)
        {
            var sorted = new SortIndex(start, end);
            return base.GetEdge(sorted.smaller, sorted.larger);
        }

        public int[] GetOutwardEdges(int nodeIndex)
        {
            return base.GetOutwardEdges(nodeIndex);
        }
        internal class SortIndex
        {
            public int smaller;
            public int larger;

            public SortIndex(int start, int end)
            {
                smaller = start < end ? start : end;
                larger = start < end ? end : start;
            }
        }
    }
}