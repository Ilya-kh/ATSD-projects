using System;
using System.Collections.Generic;
using System.Text;

namespace Laba2
{
    public class Tree<T> where T : IComparable<T>
    {
        public Node<T> head { get; set; }
        public int count = 0;
    }
}
