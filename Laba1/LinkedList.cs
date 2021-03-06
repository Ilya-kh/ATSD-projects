using System;
using System.Collections.Generic;
using System.Text;

namespace Laba1
{
    class LinkedList<T> where T : IComparable
    {
        Node<T> first;
        Node<T> last;
        int count = 0;
    }
}
