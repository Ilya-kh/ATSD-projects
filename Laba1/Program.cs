using System;

namespace Laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> List = new LinkedList<int>();
            int k = Convert.ToInt32(Console.ReadLine());
            int l;
            for (int i = 0; i < k; i++)
            {
                l = Convert.ToInt32(Console.ReadLine());
                List.AddItem(l);
            }
        }
    }
}
