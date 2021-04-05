using System;

namespace Laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            var newtree = new Tree<int>();
            for (int i = 1; i <= 6; i++)
                newtree.AddNodeHead(i);
        }
    }
}
