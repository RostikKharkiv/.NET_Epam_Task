using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_1._2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();

            Validator(ref str);

            Console.WriteLine(str);
        }

        static void Validator(ref string _str)
        {
            char[] str = _str.ToCharArray();
            char[] temp;

            if (char.IsLetter(str[0]))
            {
                temp = str[0].ToString().ToUpper().ToCharArray();
                str[0] = temp[0];
            }
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i].Equals('.')
                    || str[i].Equals('?')
                    || str[i].Equals('!'))
                {
                    while (i < str.Length && !char.IsLetter(str[i]))
                        i++;
                    if (i < str.Length)
                    {
                        temp = str[i].ToString().ToUpper().ToCharArray();
                        str[i] = temp[0];
                    }
                }
            }

            _str = new string(str);
        }
    }
}
