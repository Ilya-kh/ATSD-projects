using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba3
{
    public class Heap
    {
        private List<int> _list = new List<int>();
        public string Type;
        private int HeapSize
        {
            get
            {
                return _list.Count;
            }
        }

        public Heap(string type)
        {
            Type = type;
        }

        public void Add(int item)
        {
            _list.Add(item);
            int current = HeapSize - 1;
            int parent = (current - 1) / 2;

            while (current > 0 && _list[parent] < _list[current])
            {
                Change(parent,current);
                current = parent;
                parent = (current - 1) / 2;
            }
        }

        public void Change(int x, int y)
        {
            int temporary = _list[x];
            _list[x] = _list[y];
            _list[y] = temporary;
            
        }
        public void Heapify(int current, string type, List<int> list)
        {
            int greatest;
            int left;
            int right;

            while (true)
            {
                left = 2 * current + 1;
                right = 2 * current + 2;
                greatest = current;
                switch (type)
                {
                    case "maxheap":
                        if (right < HeapSize && list[right] > list[greatest])
                            greatest = right;
                        if (left < HeapSize && list[left] > list[greatest])
                            greatest = left;
                        break;
                    case "minheap":
                        if (right < HeapSize && list[right] < list[greatest])
                            greatest = right;
                        if (left < HeapSize && list[left] < list[greatest])
                            greatest = left;
                        break;
                }
                if (greatest == current)
                    break;
                Change(greatest, current);
                //Heapify(greatest, type, list);
            }
        }
        public void CreateHeap(int[] Array)
        {
            _list = Array.ToList();
            for (int i = HeapSize / 2; i >= 0; i--)
            {
                Heapify(i, Type, _list);
            }
        }
        public List<int> HeapSort (List<int> currentList, string type)
        {
            for (int i = currentList.Count / 2; i >= 0; i--)
            {
                Heapify(i, type, currentList);
            }
            return currentList;
        }

        public void Print()
        {
            foreach (var i in _list)
            {
                Console.Write(i + " ");
            }
        }

        public bool isEmpty() => HeapSize == 0;
        public int Size() => HeapSize;
        public void Delete()
        {
            Change(0,HeapSize-1);
            _list.Remove(_list[HeapSize - 1]);
            Heapify(0,Type,_list);
        }

        public void Find_k_max(int k)
        {
            if (k > HeapSize)
            {
                Console.WriteLine("k is bigger then size of the list");
                return;
            }
            /*List<int> list = new List<int>();
            foreach (var i in _list)
            {
                list.Add(i);
            }*/
            List<int> list = _list.GetRange(0,HeapSize);
           
            if (Type == "minheap")
                list = HeapSort(list, "maxheap");
            for (int i = 0; i < k; i++)
            {
                Console.Write(list[0] + " ");
                Delete(list,"maxheap");
            }
        }
        public void Delete(List<int> list, string type)
        {
            Change(0,list.Count-1);
            list.Remove(list[HeapSize - 1]);
            Heapify(0,type,list);
        }
    }
}