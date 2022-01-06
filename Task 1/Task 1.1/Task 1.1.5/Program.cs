using System;

namespace Task_1._1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 1000;
            int sum = 0;

            for (int i = 0; i < N; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                    //Console.WriteLine($"i = {i}; sum = {sum}");
                }
            }
            Console.WriteLine(sum);
        }
    }
}
