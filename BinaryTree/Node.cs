using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp59
{
    class Node<T> where T:IComparable
    {
        public T value { get; }
        public Node<T> left;
        public Node<T> right;
        private int count = 1;
        private bool resultRight, resultLeft;
        public Node(T inputValue)
        {
            this.value = inputValue;
        }
        public void AddValue(T nodeValue)
        {
            count++;
            if (nodeValue.CompareTo(value)<=0)
            {
                if (left == null)
                {
                    left = new Node<T>(nodeValue);
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
                    right = new Node<T>(nodeValue);
                }
                else
                {
                    right.AddValue(nodeValue);
                }
            }
        }
        public bool SearchValue(T searchedNode)
        {
            if (searchedNode.CompareTo(value)==0) return true;
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
        public int CountNodes() { return count; }
        public override string ToString()
        {
            return $"{value}";
        }
        public IEnumerator GetEnumerator()
        {
            if (this.left != null)
            {
                foreach (var v in left)
                {
                    yield return v;
                }
            }
            yield return value;
            if (this.right != null)
            {
                foreach (var v in right)
                {
                    yield return v;
                }
            }
        }
    }
}
