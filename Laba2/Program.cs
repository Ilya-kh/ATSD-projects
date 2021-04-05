using System;

namespace Laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            var newtree = new Tree<int>();
            for (int i = 1; i <= 7; i+=2)
                newtree.AddNodeHead(i);
            newtree.AddNodeHead(2);
            newtree.AddNodeHead(4);
            newtree.Print();
            
        }
    }
}
