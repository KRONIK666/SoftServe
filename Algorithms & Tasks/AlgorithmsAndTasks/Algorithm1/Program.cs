using System;

namespace Algorithm1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[10];

            for (int i = 0; i < myArray.Length; i++)
            {
                Console.Write("Enter number to fill the array: ");
                myArray[i] = int.Parse(Console.ReadLine());
            }

            QuicksortArray(myArray, 0, 9);

            Console.WriteLine();
            Console.WriteLine("The array has been sorted as follows:");
            Console.WriteLine();

            for (int i = 0; i < myArray.Length; i++)
            {
                Console.Write(myArray[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void QuicksortArray(int[] array, int left, int right)
        {
            int temp = 0;
            int i = left, j = right;
            int pivot = array[(left + right) / 2];

            while (i <= j)
            {
                while (array[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (array[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;

                    i++;
                    j--;
                }

                if (left < j)
                {
                    QuicksortArray(array, left, j);
                }

                if (i < right)
                {
                    QuicksortArray(array, i, right);
                }
            }
        }
    }
}