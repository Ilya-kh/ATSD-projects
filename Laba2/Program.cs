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
            //newtree.DeleteNode(4);
            //newtree.Print();
            newtree.CountNodes_();
            newtree.SearchNode(7);
            newtree.SearchNode(11);
            newtree.SearchNode(10);
            Console.WriteLine(newtree.IsEmpty());
            Console.WriteLine(newtree.Size());
            Console.WriteLine(newtree.SumKeys());
            Console.WriteLine(newtree.IsBalanced());

            var tree = newtree.DeleteEven();
            //tree.Print();
            //newtree.DeleteEven();
            tree.Print();
            Console.WriteLine(tree.FindSecondLargest());
            
        }
    }
}
