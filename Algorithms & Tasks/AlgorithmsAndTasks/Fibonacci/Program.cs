using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 1;
            int sum = 0;
            int count = 1;
            int n = int.Parse(Console.ReadLine());

            for (int i = 2; i < n; i++)
            {
                sum = a + b;
                a = b;
                b = sum;
                count = count + sum;
            }

            Console.WriteLine(count);
        }
    }
}