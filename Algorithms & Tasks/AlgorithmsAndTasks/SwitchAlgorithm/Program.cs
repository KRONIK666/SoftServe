using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 3;

            a = a - b;
            b = a + b;
            a = b - a;

            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
        }
    }
}