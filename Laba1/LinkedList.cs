using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Laba1
{
    class LinkedList<T>  : IEnumerable<T>, IComparer<T>
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
        public void AddItem_sort(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> current = null;
            if (first == null || Comparer.Default.Compare(first.Data, node.Data) > 0)
            {
                node.Next = first;
                first = node;
            }
            else
            {
                current = first;
                while (Comparer.Default.Compare(current.Next.Data, node.Data) < 0 && current.Next != null)
                {
                    current = current.Next;
                }
                node.Next = current.Next;
                current.Next = node;

            }
            count++;
        }
        public void Print()
        {
            Console.WriteLine("Вывод листа: ");
            Node<T> curent = first;
            if (first == null)
            {
                Console.WriteLine("This List is empty");
            }
            else
            {
                while (curent != null)
                {
                    Console.Write(curent.Data + " ");
                    curent = curent.Next;

                }
                
                Console.WriteLine();
            }
        }
        public bool DeleteItem(T Data)
        {
            Node<T> curent = first;
            Node<T> previous = null;
            while (curent != null)
            {
                if (curent.Data.Equals(Data))
                {
                    if (previous != null)
                    {
                        previous.Next = curent.Next;
                        if (curent.Next == null)
                        {
                            last = previous;
                        }
                    }
                    else
                    {
                        first = first.Next;
                        if (first == null)
                        {
                            last = null;
                        }
                    }
                    count--;
                    return true;
                }
                previous = curent;
                curent = curent.Next;
            }
            return false;
        }
        public int Sizeof()
        {
            return count;
        }
        public bool Search(T item)
        {
            Node<T> curent = first;
            while (curent != null)
            {
                if (Convert.ToInt32(curent.Data) == Convert.ToInt32(item)) return true;
                curent = curent.Next;
            }
            return false;
        }
        public bool isEmpty()
        {
            if (count > 0) return false;
            else return true;
        }

        public int Compare(T x, T y)
        {
            return Comparer.Default.Compare(x, y);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = first;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
