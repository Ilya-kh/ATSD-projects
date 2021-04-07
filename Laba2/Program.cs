using System;

namespace Laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            var newtree = new Tree<int>();
            newtree.AddNodeHead(8);
            newtree.AddNodeHead(5);
            newtree.AddNodeHead(7);
            newtree.AddNodeHead(4);
            newtree.AddNodeHead(2);
            newtree.AddNodeHead(10);
            newtree.Print();
            newtree.CountNodes_();
            
        }
    }
}
