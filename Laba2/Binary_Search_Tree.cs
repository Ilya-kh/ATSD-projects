using System;
using System.Collections.Generic;
using System.Text;

namespace Laba2
{
    public class Tree<T> where T : IComparable<T>
    {
        public Node<T> head { get; set; }
        public int count = 0;

        public void AddNodeHead(T number)
        {

            if (head == null)
            {
                Node<T> node = new Node<T>(number);
                head = node;
            }
            else
            {
                head.AddNode(number);
            }
        }
        public void Print() 
        {
            var List = new List<T>();
            Print_1(List,head);
            foreach (var i in List)
            {
                Console.Write(i + " ");
            }

        }
        public List<T> Print_1(List<T> List, Node<T> current)
        {
            if (current != null)
            {
                if (current.left != null)
                {
                    Print_1(List, current.left);
                }
                List.Add(current.Data);
                if (current.right != null)
                {
                    Print_1(List, current.right);
                }
            }
            return List;
        }
    }
}
