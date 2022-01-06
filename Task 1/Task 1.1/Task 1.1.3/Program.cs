using System;

namespace Task_1._1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 10;
            int spaces = N;

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j < spaces; j++)
                {
                    Console.Write(" ");
                }

                spaces = spaces - 1;

                for (int t = 1; t < i * 2; t++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
