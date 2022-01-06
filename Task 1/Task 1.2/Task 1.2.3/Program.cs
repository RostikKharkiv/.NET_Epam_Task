using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            Console.WriteLine(CountOfWords(str));
        }

        static int CountOfWords(string _str)
        {
            char[] str = _str.ToCharArray();

            StringBuilder word = new StringBuilder();

            List<string> lowerWords = new List<string>();
            List<string> upperWords = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsUpper(str[i]))
                {
                    while (i < str.Length && char.IsLetter(str[i]))
                    {
                        word.Append(str[i]);
                        i++;
                    }
                    upperWords.Add(word.ToString());
                    word.Clear();
                }

                else if (char.IsLower(str[i]))
                {
                    while (i < str.Length && char.IsLetter(str[i]))
                    {
                        word.Append(str[i]);
                        i++;
                    }
                    lowerWords.Add(word.ToString());
                    word.Clear();
                }
            }

            Console.Write("Слова с маленькой буквы: ");
            foreach (var item in lowerWords)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            return lowerWords.Count;
        }
    }
}
