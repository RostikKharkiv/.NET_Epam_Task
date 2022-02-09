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
            DynamicArray<string> stringArray = new DynamicArray<string>();
            DynamicArray<string> stringArray2 = new DynamicArray<string>();

            for (int i = 0; i < 20; i++)
            {
                stringArray.AddLast($"{i}");
                stringArray2.AddLast($"{i}");
            }

            List<string> stringList = stringArray2.ToList();

            Console.WriteLine(stringArray2.GetType());

            foreach (var item in stringList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(stringList.GetType());
        }
    }
}