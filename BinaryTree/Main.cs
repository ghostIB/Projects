using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp56
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            Tree a = new Tree(new Node(4));
            Node b = new Node(3);
            Node c = new Node(3);
            a.AddNode(b);
            c.AddValue(5);
            Console.Write(a.SearchNode(c));
            a.GetSortedTree();
            Console.ReadKey();
        }
        public static void WriteLineArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i.ToString() + " ");
            }
            Console.Write("\n");
        }
    }
}
