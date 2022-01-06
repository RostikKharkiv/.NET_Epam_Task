using System;

namespace Task_1._1._10
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 50;
            int m = 50;

            int[,] array = ArrayGenerator(n, m);
            ArrayShow(array);
            Console.WriteLine($"Sum = {ArraySum(array, n, m)}"); 
        }

        static int[,] ArrayGenerator(int n, int m)
        {
            Random rnd = new Random();

            int[,] array = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = rnd.Next(-100, 101);
                }
            }

            return array;
        }

        static int ArraySum(int[,] array, int n, int m)
        {
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += array[i, j];
                    }
                }
            }

            return sum;
        }

        static void ArrayShow(int[,] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
