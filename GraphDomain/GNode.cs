namespace GraphDomain
{
    public class GNode
    {
        public int Index;
        public static int InvalidNodeIndex = -1;

        public GNode(int index)
        {
            Index = index;
        }

        public GNode()
        {
            Index = InvalidNodeIndex;
        }
    }
}