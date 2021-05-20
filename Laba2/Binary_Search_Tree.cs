﻿using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using System.Linq;     


namespace Laba2
{
    public class Tree<T> where T : IComparable<T>, IComparable
    {
        private Node<T> Head { get; set; }
       
        public Tree(Node<T> node)
        {
            Head = node;
        }
        public Tree(){}
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
        public List<T> Print() 
        {
            var list = new List<T>();
            list=Print_1(list,Head);
            Console.WriteLine("Ascending order : ");
            foreach (var i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Descending order : ");
            for (int i = list.Count-1; i >= 0; i--) 
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Inorder : ");
            print_inorder(Head);
            Console.WriteLine();
            Console.WriteLine("Preorder : ");
            print_preorder(Head);
            Console.WriteLine();
            Console.WriteLine("Postorder : ");
            print_postorder(Head);
            return list;
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
            Console.WriteLine();
            Console.WriteLine($"the number of Left son nodes in a BBST:{CountNodes(Head.Left)}" );
        }   
        
        private static int CountNodes(Node<T> current)
        {
            if (current == null) return 0;
            if (current.Left == null)
                return CountNodes(current.Right) + 1;
            else
            {
                return CountNodes(current.Left) + CountNodes(current.Right) + 1;
            }
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
        
        public void DeleteNode(T data)
        {
            Head = Delete(Head, data);
        }

        private Node<T> Delete(Node<T> current, T data)
        {
            Node<T> privious;
            if (current == null)
            {
                return null;
            }
            if (data.CompareTo(current.Data) < 0)
            {
                current.Left=Delete(current.Left, data);
                if (Differense(current) == -2)
                {
                    if (Differense(current.Right)<=0)
                    {
                        current = Left_Rotation(current);
                    }
                    else
                    {
                        current = Left_Right_Rotation(current);
                    }
                }
            } else if (data.CompareTo(current.Data) > 0)
            {
                current.Right = Delete(current.Right, data);
                if (Differense(current) == 2)
                {
                    if (Differense(current.Left)>=0)
                    {
                        current = Right_Rotation(current);
                    }
                    else
                    {
                        current = Right_Left_Rotation(current);
                    }
                }
            }
            else
            {
                if (current.Right != null)
                {
                    privious = current.Right;
                    while (privious.Left != null)
                    {
                        privious = privious.Left;
                    }

                    current.Data = privious.Data;
                    current.Right = Delete(current.Right, privious.Data);
                    if (Differense(current) == 2)
                    {
                        if (Differense(current.Left) >= 0)
                        {
                            current =Right_Rotation(current);
                        }
                        else
                        {
                            current = Left_Right_Rotation(current);
                        }
                    }
                }
                else
                {
                    return current.Left;
                }
            }
            return current;
        }
        
        public void SearchNode(T data)
        {
            if (Search(Head, data) == null)
            {
                Console.WriteLine($"This node {data} isn't in the tree");
                return;
            }
            if (Search(Head,data).Data.Equals(data))
                Console.WriteLine($"This node {data} is in the tree");
            else
                Console.WriteLine($"This node {data} isn't in the tree");
        }
        
        private Node<T> Search(Node<T> current, T data)
        {
            if (current == null) return null ; 
            if (current.Data.Equals(data))
            {
                return current;
            }
            if (current.Data.CompareTo(data) == -1)
                return Search(current.Right,data);
            else 
                return Search(current.Left,data);
        }
        
        public bool IsEmpty()
        {
            return Head == null;
        }
        
        public int Size()
        {
            return CountNodes(Head);
        }
        
        private void print_preorder(Node<T> current)
        {
            if (current != null)
            {
                Console.Write(current.Data + " ");
                print_preorder(current.Left);
                print_preorder(current.Right);
            }
        }

        private void print_postorder(Node<T> current)
        {
            if (current != null)
            {
                print_preorder(current.Left);
                print_preorder(current.Right);
                Console.Write(current.Data + " ");
            }
        }

        private void print_inorder(Node<T> current)
        {
            if (current != null)
            {
                print_preorder(current.Left);
                Console.Write(current.Data + " ");
                print_preorder(current.Right);
            }
        }

        public int SumKeys()
        {
            Console.WriteLine("the sum of keys in right son nodes in a BBST ");
            return Sum(Head.Right);
        }

        private int Sum(Node<T> current,int count=0)
        {
            if (current == null)
            {
                return 0;
            }
            return Convert.ToInt32(current.Data) + Sum(current.Left, count) + Sum(current.Right, count);
            
        }
        public Tree<T> CopyTree()
        {
            Tree<T> tree = new Tree<T>(this.Copy(Head));
            return tree;
        }   

        private Node<T> Copy(Node<T> current)
        {
            if (current == null)
            {
                return null;
            }
            else
            {
                var temp = new Node<T>(current.Data);
                temp.Left = Copy(current.Left);
                temp.Right = Copy(current.Right);
                return temp;
            }
        }
        public Tree<T> DeleteEven()
        {
            var tree = new Tree<T>();
            var result = ToList().Where(x => Convert.ToInt32(x) % 2 != 0);
            foreach (var item in result)
            {
                tree.NewNode(item);
            }

            return tree;
        }
        private  void ToList(Node<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }
            list.Add(node.Data);
            if (node.Left != null)
            {
                ToList(node.Left, list);
            }

            if (node.Right != null)
            {
                ToList(node.Right, list);
            }
        }

        public List<T> ToList()
        {
            var list = new List<T>();
            ToList(Head, list);
            return list;
        }

        public void InsertBBST(Tree<T> current)
        {
            var list= current.ToList();
            foreach (var i in list)
            {
                NewNode(i);
            }
        }

        public bool IsBalanced()
        { 
            return Differense(Head) < 2 && Differense(Head) > -2;
        }

        public T FindSecondLargest()
        {
            var list = Print();
            return list[list.Count-1];
        }

        public bool ContainsBBST(Tree<T> tree)
        {
            return this.ToList().Except(tree.ToList()).Any();
        }

    }   
}
