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

        public void AddItem(T data)
        {
            Node<T> node = new Node<T>(data);
            if (first == null)
            {
                first = node;
            }
            else
            {
                last.Next = node;
            }
            last = node;
            count++;
        }
        public void Print()
        {
            Node<T> curent = first;
            if (first == null)
            {
                Console.WriteLine("This List is empty");
            }
            else
            {
                while (curent != last)
                {
                    Console.Write(curent.Data + ", ");
                    curent = curent.Next;

                }
                Console.Write(curent.Data);
                Console.WriteLine();
            }
        }
    }
}
