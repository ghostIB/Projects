using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Node
    {
        public int value;
        public dynamic nextNode;
        private int tempValue;
        private int result;
        private bool searchResult;
        public Node(int inputValue)
        {
            this.value = inputValue;
        }
        public void AddValue(int inputAddValue)
        {
            if (nextNode == null)
            {
                nextNode = new Node(value);
                value = inputAddValue;
            }
            else
            {
                nextNode.AddValue(value);
                value = inputAddValue;
            }
        }
        public void ChangeNodes(int inputChangeVlaue)
        {
            tempValue = value;
            value = inputChangeVlaue;
            if (nextNode != null) nextNode.ChangeNodes(tempValue);
        }
        public int GetForvardValue()
        {
            if (nextNode == null) return value;
            else result = nextNode.GetForvardValue();
            return result;
        }
        public void GetNode()
        {
            Console.Write(value + " ");
            if (nextNode != null) nextNode.GetNode();
        }
        public bool SearchValue(int inputSearchValue)
        {
            if (value == inputSearchValue)
            {
                searchResult = true;
                return true;
            }
            else if (nextNode != null) searchResult=nextNode.SearchValue(inputSearchValue);
            else if (nextNode==null)  return false;
            return searchResult;
        }
        public void DeleteForwardNode()
        {
            if (nextNode.nextNode == null) nextNode=null;
            else nextNode.DeleteForwardNode();
        }
        public override string ToString()
        {
            return $"{value}";
        }
    }
}
