using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Task_3._2._1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CycledDynamicArray<string> stringArray = new CycledDynamicArray<string>();
            CycledDynamicArray<string> stringArray2 = new CycledDynamicArray<string>();

            for (int i = 0; i < 20; i++)
            {
                stringArray.AddLast($"{i}");
                stringArray2.AddLast($"{i}");
            }

            Console.WriteLine(stringArray.Equals(stringArray2));

            foreach (var item in stringArray2)
            {
                Console.Write($"{item} ");
            }
        }
    }
}