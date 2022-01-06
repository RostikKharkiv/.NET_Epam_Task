using System;

namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = '*';
            Console.Write("Enter N: ");
            int N;
            int.TryParse(Console.ReadLine(), out N);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(a);
                }
                Console.WriteLine();
            }
        }
    }
}
