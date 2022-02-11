using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3._2
{
    public enum WordType
    {
        None = 0,
        Russian = 1,
        English = 2,
        Number = 3,
        Other = 4
    }

    public static class StringExtension
    {
        private static string russian = "АБВГДЕЁЖЗИЙКЛМНОПРСТУЙФЦЧШЩЬЪЫЭЮЯ" +
            "абвгдеёжзийклмнопрстуфхцчшщьъыэюя";
        private static string english = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
            "abcdefghijklmnopqrstuvwxyz";
        private static string numbers = "0123456789";

        private static WordType CheckWordType(string str)
        {
            if (str is null || str == String.Empty)
            {
                return WordType.None;
            }

            char firstSymbol = str[0];
            int index = 1;

            if (russian.Contains(firstSymbol))
            {
                while (index < str.Length)
                {
                    if (!russian.Contains(str[index]))
                    {
                        return WordType.Other;
                    }

                    index++;
                }

                return WordType.Russian;
            }

            if (english.Contains(firstSymbol))
            {
                while (index < str.Length)
                {
                    if (!english.Contains(str[index]))
                    {
                        return WordType.Other;
                    }

                    index++;
                }

                return WordType.English;
            }

            if (numbers.Contains(firstSymbol))
            {
                while (index < str.Length)
                {
                    if (!numbers.Contains(str[index]))
                    {
                        return WordType.Other;
                    }

                    index++;
                }

                return WordType.Number;
            }

            return WordType.Other;


        }
        public static WordType CheckLanguage(this string str)
        {
            string[] words = str.Split(new char[] { ' ', '.', '?', ',', '!' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
            {
                return WordType.None;
            }

            if (words.Length == 1)
            {
                return CheckWordType(words[0]);
            }


            return WordType.Other;
        }

    }
}
