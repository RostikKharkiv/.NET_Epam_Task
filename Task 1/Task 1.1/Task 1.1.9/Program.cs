using System;

namespace Task_1._1._9
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            int[] array = ArrayGenerator(n);
            ArrayShow(array);
            Console.WriteLine($"Sum = {ArraySum(array)}"); 

        }

        static int[] ArrayGenerator(int n)
        {
            Random rnd = new Random();
            int[] array = new int[n];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-100, 101);
            }

            return array;
        }
        static int ArraySum(int[] array)
        {
            int sum = 0;

            foreach (var item in array)
            {
                if (item >= 0)
                    sum += item;
            }

            return sum;
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
