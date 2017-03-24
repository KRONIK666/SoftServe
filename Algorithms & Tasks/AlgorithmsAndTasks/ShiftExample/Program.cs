using System;

namespace ShiftExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int value1 = new Random().Next();

            for (int i = 0; i < 32; i++)
            {
                int shift = value1 >> i;
                Console.WriteLine("{0} = {1}",
                GetIntBinaryString(shift), shift);
            }

            for (int i = 0; i < 32; i++)
            {
                int shift = value1 << i;
                Console.WriteLine("{0} = {1}",
                GetIntBinaryString(shift), shift);
            } Console.WriteLine();
        }

        static string GetIntBinaryString(int n)
        {
            char[] b = new char[32];
            int pos = 31;
            int i = 0;

            while (i < 32)
            {
                if ((n & (1 << i)) != 0)
                {
                    b[pos] = '1';
                }
                else
                {
                    b[pos] = '0';
                }
                pos--;
                i++;
            } return new string(b);
        }
    }
}