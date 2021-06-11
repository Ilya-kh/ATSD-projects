using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new[] {5,4,3,2,1};
            Heap newHeap = new Heap("minheap");
            newHeap.CreateHeap(array);
            //newHeap.Delete();
            //newHeap.Add(10);
            newHeap.Print();
            Console.WriteLine();
            Console.WriteLine(newHeap.isEmpty());
            Console.WriteLine(newHeap.Size());
            //newHeap.Find_k_max(2);
        }
    }
}
