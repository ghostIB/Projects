using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Queue
    {
        public int size;
        private Node back;
        public int count { get; private set; }
        private int result;
        public Queue(int inputSize)
        {
            this.size = inputSize;
        }
        public int Top()
        {
            return back.GetForvardValue();
        }
        public int Pop()
        {
            result = back.GetForvardValue();
            back.DeleteForwardNode();
            count--;
            return result;
        }
        public void GetQueue(){ back.GetNode(); }
        public bool IsEmpty() { return back == null; }
        public int CountNodes() { return count; }
        public void Push(int inputPushNode)
        {
            if (count==0)
            {
                back = new Node(inputPushNode);
            }
            else if (count < size)
            {
                back.AddValue(inputPushNode);
            }
            else if (count==size)
            {
                back.ChangeNodes(inputPushNode);
                count--;
            }
            count++;
        }
        public bool SearchNode(int inputSearchNode)
        {
            return back.SearchValue(inputSearchNode);
        }
        public int GetBackValue() { return back.value; }
        public override string ToString()
        {
            return $"{back.value}";
        }
    }
}
