using System;

namespace Task_1._1._8
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            int m = 4;
            int k = 5;
            int[,,] array = ArrayGenerator(n, m, k);
            ArrayNoPositive(ref array, n, m, k);
            ArrayShow(array);

        }

        static int[,,] ArrayGenerator(int n, int m, int k)
        {
            Random rnd = new Random();

            int[,,] array = new int[n, m, k];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int l = 0; l < k; l++)
                    {
                        array[i, j, l] = rnd.Next(-100, 101);
                    }
                }
            }

            return array;
        }
        static void ArrayNoPositive(ref int[,,] array, int n, int m, int k)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int l = 0; l < k; l++)
                    {
                        if (array[i, j, l] > 0) 
                            array[i, j, l] = 0;
                    }
                }
            }
        }

        static void ArrayShow(int[,,] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }


}
