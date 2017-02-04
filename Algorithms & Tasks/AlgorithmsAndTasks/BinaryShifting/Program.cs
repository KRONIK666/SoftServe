using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryShifting
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;

            Console.WriteLine("Shifted result: {0}", i << 1);
            Console.WriteLine("Shifted result: {0}", i << 33);
            Console.WriteLine();
        }
    }
}