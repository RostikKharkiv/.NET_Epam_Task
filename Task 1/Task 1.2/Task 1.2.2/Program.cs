using System;
using System.Collections.Generic;

namespace Task_1._2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первую строку: ");
            string str1 = Console.ReadLine();
            Console.Write("Введите вторую строку: ");
            string str2 = Console.ReadLine();

            Doubler(str1, str2);
        }

        static void Doubler(string _str1, string _str2)
        {
            char[] str2 = _str2.ToCharArray();

            HashSet<char> symbols = new HashSet<char>();

            foreach (var item in str2)
            {
                symbols.Add(item);
            }

            foreach (var item in symbols)
            {
                if (_str1.Contains(item))
                {
                    _str1 = _str1.Replace(item.ToString(), new string(item, 2));
                }
            }

            Console.WriteLine(_str1);
        }
    }
}
