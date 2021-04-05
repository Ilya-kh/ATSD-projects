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
    }
}
