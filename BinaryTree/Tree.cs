using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp59
{
    class Tree<T> where T:IComparable
    {
        public Node<T> rootNode { get; }
        public Tree(T inputRootNode)
        {
            rootNode = new Node<T>(inputRootNode);
        }
        public Node<T> left;
        public Node<T> right;
        private int countNode = 1;
        private bool resultSearchRight = true;
        private bool resultSearchLeft = true;
        public void AddNode(T inputNode)
        {
            rootNode.AddValue(inputNode);
            countNode++;
        }
        public bool SearchNode(T inputRawNode)
        {
            return rootNode.SearchValue(inputRawNode);
        }
        public void GetSortedTree()
        {
            Console.Write("\n");
            this.rootNode.GetSortedList();
        }
        public int CountNodes()
        {
            return countNode;
        }
        public IEnumerator GetEnumerator()
        {
            foreach (var elem in rootNode)
            {
                yield return elem;
            }
        }
    }
}
