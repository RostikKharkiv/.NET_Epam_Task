using System;

namespace Task_1._1._7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = ArrayGenerator(10,100);
            Console.WriteLine($"Array max: {ArrayMax(array)}");
            Console.WriteLine($"Array min: {ArrayMin(array)}");
            Console.WriteLine("Несортированный массив:\n");
            ArrayShow(array);
            Console.WriteLine("\nСортированный массив:\n");
            ArraySort(ref array);
            ArrayShow(array);

        }

        static int[] ArrayGenerator(int min, int max)
        {
            Random rnd = new Random();

            int[] array = new int[rnd.Next(min, max + 1)];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(min, max + 1);
            }

            return array;
        }

        static int ArrayMin(int[] array)
        {
            int min = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }

            return min;
        }

        static int ArrayMax(int[] array)
        {
            int max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }

            return max;
        }

        static void ArraySort(ref int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        static void ArrayShow(int[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
