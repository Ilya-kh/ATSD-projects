using System.Collections.Generic;

namespace Laba3
{
    public class Heap
    {
        private List<int> _list = new List<int>();
        private int HeapSize = 0;

        public void Add(int item)
        {
            _list.Add(item);
            HeapSize++;
            int current = HeapSize - 1;
            int parent = (current - 1) / 2;

            while (current > 0 && _list[parent] > _list[current])
            {
                int temporary = _list[parent];
                _list[parent] = _list[current];
                _list[current] = temporary;

                current = parent;
                parent = (current - 1) / 2;
            }
        }
    }
}