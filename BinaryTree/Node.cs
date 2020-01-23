using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp56
{
    class Node
    {
        public int value { get; }
        public Node left;
        public Node right;
        private int count = 1;
        private bool resultRight, resultLeft;
        public Node(int inputValue)
        {
            this.value = inputValue;
        }
        public void AddValue(int nodeValue)
        {
            count++;
            if (nodeValue <= value)
            {
                if (left == null)
                {
                    left = new Node(nodeValue);
                }
                else
                {
                    left.AddValue(nodeValue);
                }
            }
            else
            {
                if (right == null)
                {
                    right = new Node(nodeValue);
                }
                else
                {
                    right.AddValue(nodeValue);
                }
            }
        }
        public bool SearchValue(int searchedNode)
        {
            if (searchedNode == value) return true;
            else
            {
                resultLeft = left == null ? false : left.SearchValue(searchedNode);
                resultRight = right == null ? false : right.SearchValue(searchedNode);
            }
            return resultLeft || resultRight;
        }
        public void GetSortedList()
        {
            if (left != null) left.GetSortedList();
            Console.Write(value.ToString() + " ");
            if (right != null) right.GetSortedList();
        }
        public bool CheckNodes(int checkedValue)
        {
            return right.value == checkedValue || left.value == checkedValue;
        }
        public int CountNodes() { return count; }
        public override string ToString()
        {
            return $"{value}";
        }
    }
}
