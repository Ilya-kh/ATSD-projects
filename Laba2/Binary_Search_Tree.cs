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
    }
}
