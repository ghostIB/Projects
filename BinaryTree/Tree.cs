using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp56
{
    class Tree
    {
        public Node rootNode { get; }
        public Tree(Node inputRootNode)
        {
            rootNode = inputRootNode;
        }
        public Node left;
        public Node right;
        private int countNode = 1;
        private bool resultSearchRight = true;
        private bool resultSearchLeft = true;
        public void AddNode(Node inputNode)
        {
            if (inputNode.left != null)
            {
                this.AddNode(inputNode.left);
            }
            this.rootNode.AddValue(inputNode.value);
            countNode++;
            if (inputNode.right != null)
            {
                this.AddNode(inputNode.right);
            }
        }
        public bool SearchNode(Node inputRawNode)
        {
            if (inputRawNode.left != null)
            {
                resultSearchLeft = this.SearchNode(inputRawNode.left);
            }
            if (inputRawNode.right != null)
            {
                resultSearchRight = this.SearchNode(inputRawNode.right);
            }
            if (resultSearchLeft && resultSearchRight == false) return false;
            return this.rootNode.SearchValue(inputRawNode.value);
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
        public override string ToString()
        {
            return $"{this.rootNode.value}";
        }
    }
}
