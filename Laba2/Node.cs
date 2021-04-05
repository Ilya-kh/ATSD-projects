using System;
using System.Collections.Generic;
using System.Text;

namespace Laba2
{
    public class Node<T> where T : IComparable<T>
    {
        public Node<T> left { get; set; }
        public Node<T> right { get; set; }
        public Node(T data)
        {
            Data = data;
        }
        public T Data;

        public void AddNode(T number)
        {
            Node<T> node = new Node<T>(number);
            if (node.Data.CompareTo(Data) == 1)
            {
                if (right == null)
                {
                    right = node;
                }
                else
                {
                    right.AddNode(number);
                }
            }
            else
            {
                if (left == null)
                {
                    left = node;
                }
                else
                {
                    left.AddNode(number);
                }
            }
        }
        public void Printt(Node<T> current) 
        {

        }
      
    }
}
