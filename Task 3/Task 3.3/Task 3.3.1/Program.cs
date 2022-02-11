using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3._3._1 
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] mass = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] mass2 = { };

            int Increase(int el) => el * 3;

            mass.DoWithElements(Increase);

            foreach (var item in mass)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine(mass2.Frequent());
            Console.WriteLine(mass2.Average());
            Console.WriteLine(mass2.Sum());
        }
    }
}