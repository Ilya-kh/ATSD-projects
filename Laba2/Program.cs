using System;

namespace Laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            var newtree = new Tree<int>();
            newtree.NewNode(8);
            newtree.NewNode(5);
            newtree.NewNode(7);
            newtree.NewNode(4);
            newtree.NewNode(2);
            newtree.NewNode(10);
            newtree.Print();
            newtree.CountNodes_();
            
        }
    }
}
