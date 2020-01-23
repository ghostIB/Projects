using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue a = new Queue(3);
            a.Push(4);
            a.Push(5);
            a.Push(6);
            a.Push(7);
            Console.WriteLine(a.Pop());
            a.GetQueue();
            Console.ReadKey();
        }
    }
}
