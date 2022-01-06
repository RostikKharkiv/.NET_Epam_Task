using System;

namespace Task_1._1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbol = '*';
            char space = ' ';
            Console.Write("Enter N: ");
            int n;
            int.TryParse(Console.ReadLine(), out n);

            for (int i = 0; i <= n; i++)
            {
                for (int j = 1; j < i * 2; j += 2)
                    Console.WriteLine(new string(space, n - j / 2) + new string(symbol, j));
            }
        }
    }
}
