using System;
using System.Collections.Generic;
using System.Text;

namespace Laba2
{
    public class Tree<T> where T : IComparable<T>
    {
        public Node<T> Head { get; set; }
        public int count = 0;

        public void AddNodeHead(T number)
        {

            if (Head == null)
            {
                Node<T> node = new Node<T>(number);
                Head = node;
            }
            else
            {
                Head.AddNode(number);
            }
        }
        public void Print() 
        {
            var list = new List<T>();
            Print_1(list,Head);
            Console.WriteLine("Ascending order: ");
            foreach (var i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Descending order: ");
            for (int i = list.Count-1; i >= 0; i--) 
            {
                Console.Write(list[i] + " ");
            }

        }
        public List<T> Print_1(List<T> list, Node<T> current)
        {
            if (current != null)
            {
                if (current.Left != null)
                {
                    Print_1(list, current.Left);
                }
                list.Add(current.Data);
                if (current.Right != null)
                {
                    Print_1(list, current.Right);
                }
            }
            return list;
        }
        public void CountNodes_() {
            int countt=CountNodes(Head.Left);
            Console.WriteLine();
            Console.WriteLine("the number of Left son nodes in a BBST:" + countt);
            
        }        
        public int CountNodes(Node<T> current,int countt=0) 
        {
            if (current != null)
            {
                if (current.Left!=null)
                    CountNodes(current.Left, countt++);
               
                if (current.Right!=null)
                    CountNodes(current.Right, countt++);
                countt++;
            }
            return countt;  
        }

       

    }
}
