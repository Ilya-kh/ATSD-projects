﻿using System;
using System.Collections.Generic;


namespace Laba2
{
    public class Tree<T> where T : IComparable<T>
    {
        private Node<T> Head { get; set; }
        public int Count = 0;

        public void NewNode(T number)
        {
            Node<T> node = new Node<T>(number);
            Head = Head == null ? node : AddNode(Head, node);
        }
        private Node<T> AddNode(Node<T> current, Node<T> node)
        {
            if (current == null)
            {
                current = node;
                return current;
            }
            if (node.Data.CompareTo(current.Data) < 0)
            {
                current.Left = AddNode(current.Left, node);
                current = Balance(current);
            }
            else if(node.Data.CompareTo(current.Data) > 0)
            {
                current.Right = AddNode(current.Right, node);
                current = Balance(current);
            }
            return current;
        }
        public void Print() 
        {
            var list = new List<T>();
            list=Print_1(list,Head);
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
        private List<T> Print_1(List<T> list, Node<T> current)
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
        private int CountNodes(Node<T> current,int countt=0) 
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

        private Node<T> Balance(Node<T> current)
        {
           
                if (Differense(current) > 1)
                {
                    if (Differense(current.Left) > 0)
                    {
                        current=Right_Left_Rotation(current);
                    }
                    else
                    {
                        current=Right_Rotation(current);
                    }
                }
                else if (Differense(current) < -1)
                {
                    if (Differense(current.Right) > 0)
                    {
                        current=Left_Right_Rotation(current);
                    }
                    else
                    {
                        current=Left_Rotation(current);
                    }
                }
            
            return current;
        }

        private int Differense(Node<T> current)
        {
            int lef = GetHeight(current.Left);
            int righ = GetHeight(current.Right);
            int difference = lef - righ;
            return difference;
        }

        private int GetHeight(Node<T> current)
        {
            int height = 0;
            if (current != null)
            {
                int l = GetHeight(current.Left);
                int r = GetHeight(current.Right);
                int res = Maximum(l, r);
                height = res + 1;
            }
            return height;
        }
        private static int Maximum(int x, int y)
        {
            return x > y ? x : y;
        }

        private Node<T> Left_Rotation(Node<T> current)
        {
            Node<T> newNode = current.Right;
            current.Right = newNode.Left;
            newNode.Left = current;
            return newNode;
        }

        private Node<T> Right_Rotation(Node<T> current)
        { 
            Node<T> newNode = current.Left;
            current.Left = newNode.Right; 
            newNode.Right = current;
            return newNode;
        }

        private Node<T> Left_Right_Rotation(Node<T> current)
        {
            Node<T> newNode = current.Left;
            current.Left = Left_Rotation(newNode);
            return Right_Rotation(current);
        }
        private Node<T> Right_Left_Rotation(Node<T> current)
        {
            Node<T> newNode = current.Right;
            current.Right = Right_Rotation(newNode);
            return Left_Rotation(current);
        }
    }
}
