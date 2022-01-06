using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Averages(str);
        }

        static void Averages(string _str)
        {
            List<string> words = new List<string>();
            List<int> symbolCount = new List<int>();

            char[] str = _str.ToCharArray();

            StringBuilder word = new StringBuilder();

            int sum = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    while (i < str.Length && char.IsLetter(str[i]))
                    {
                        word.Append(str[i]);
                        i++;
                    }
                    words.Add(word.ToString());
                    symbolCount.Add(word.Length);
                    word.Clear();
                }
            }

            Console.Write("Слова: ");
            foreach (var item in words)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            foreach (var item in symbolCount)
            {
                sum += item;
            }

            double average = sum / symbolCount.Count;

            Console.WriteLine($"Среднее количество букв в словах текста: " +
                $"{Math.Round(average)}");
        }
    }
}
