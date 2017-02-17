using System;

namespace Algorithm3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] arrayToSort = new int[100];

            for (int i = 0; i < arrayToSort.Length; i++)
            {
                arrayToSort[i] = random.Next(0, 1000);
            }

            for (int i = arrayToSort.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    if (arrayToSort[j] > arrayToSort[j + 1])
                    {
                        int highValue = arrayToSort[j];
                        arrayToSort[j] = arrayToSort[j + 1];
                        arrayToSort[j + 1] = highValue;
                    }
                }
            }

            Console.WriteLine("Sorted elements using Bubble Sort:");
            Console.WriteLine();

            for (int i = 0; i < arrayToSort.Length; i++)
            {
                Console.WriteLine(arrayToSort[i]);
            } Console.WriteLine();
        }
    }
}