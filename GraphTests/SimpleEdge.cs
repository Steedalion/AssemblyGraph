using GraphDomain;

namespace Graph
{
    public class SimpleEdge : GEdge
    {
        public SimpleEdge(int start, int endAt) : base(start, endAt)
        {
        }

        public SimpleEdge(int start, int to, double cost) : base(start, to, cost)
        {
        }
    }
}