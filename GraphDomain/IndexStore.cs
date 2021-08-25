using System.Collections.Generic;

namespace GraphDomain
{
    public class IndexStore
    {
        private HashSet<int> store = new HashSet<int>();

        public void Add(int node1Index)
        {
            store.Add(node1Index);
        }

        public int Size()
        {
            return store.Count;
        }

        public void Remove(int index)
        {
            store.Remove(index);
        }

        public int GetNextAvailable()
        {
            for (int i = 0; i < store.Count; i++)
            {
                if (!store.Contains(i))
                {
                    return i;
                }
            }

            return store.Count ;
        }

        public bool Contains(int nodeIndex)
        {
            return store.Contains(nodeIndex);
        }
    }
}