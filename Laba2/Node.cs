using System;
using System.Collections.Generic;
using System.Text;

namespace Laba2
{
    public class Node<T> where T : IComparable<T>
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
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
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.AddNode(number);
                }
            }
            else
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.AddNode(number);
                }
            }
        }
    }
}
