using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm2
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

            int maxValue = arrayToSort[0];
            int minValue = arrayToSort[0];

            for (int i = 0; i < arrayToSort.Length; i++)
            {
                if (arrayToSort[i] > maxValue)
                {
                    maxValue = arrayToSort[i];
                }

                if (arrayToSort[i] < minValue)
                {
                    minValue = arrayToSort[i];
                }
            }

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            for (int i = 0; i < arrayToSort.Length; i++)
            {
                bucket[arrayToSort[i] - minValue].Add(arrayToSort[i]);
            }

            int index = 0;

            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        arrayToSort[index] = bucket[i][j];
                        index++;
                    }
                }
            }

            Console.WriteLine("Sorted elements using Bucket Sort:");
            Console.WriteLine();

            for (int i = 0; i < arrayToSort.Length; i++)
            {
                Console.WriteLine(arrayToSort[i]);
            } Console.WriteLine();
        }
    }
}