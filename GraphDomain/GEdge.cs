namespace GraphDomain
{
    public class GEdge
    {
        public int startFrom;
        public int endAt;
        public double Cost;

        public GEdge(int start, int to)
        {
            startFrom = start;
            endAt = to;
            Cost = 1.0;
        }

        public GEdge(int start, int to, double edgeCost)
        {
            startFrom = start;
            endAt = to;
            Cost = edgeCost;
        }
    }
}