using System;
using System.Collections.Generic;

namespace Task_2._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomString str1 = "Привет мир!";

            CustomString str2 = new char[6] { 'П', 'р', 'и', 'в', 'е', 'т'};

            CustomString str3 = new char[6] { 'п', 'р', 'и', 'в', 'е', 'т'};

            Console.WriteLine($"str1: {str1}");
            Console.WriteLine($"str2: {str2}{Environment.NewLine}");
            Console.WriteLine($"str1.Contains((string)str2): {str1.Contains((string)str2)}");
            Console.WriteLine($"str1.Contains((string)str3): {str1.Contains((string)str3)}");
            Console.WriteLine($"str2.Equals(str3): {str2.Equals(str3)}");

            str3[0] = 'П';
            Console.WriteLine($"{Environment.NewLine}str3: {str3}");
            Console.WriteLine($"str1.Contains((string)str3): {str1.Contains((string)str3)}");
            Console.WriteLine($"str2.Equals(str3): {str2.Equals(str3)}");

            CustomString str4 = "Привет24, Мир!25.4..3.2..1и5.34.2.1.44";

            List<double> numbers = str4.FindNumbers();

            Console.WriteLine($"{Environment.NewLine}Поиск чисел в строке str4: {str4}");
            foreach (var item in numbers)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            CustomString str5 = "метод    для   ,поиска Всех. СлоВ  в,,, строке     .";

            Console.WriteLine($"{Environment.NewLine}Поиск слов в строке str5: {str5}");
            List<CustomString> words = str5.FindWords();

            foreach (var item in words)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            char[] charArray = (char[])str3;

            Console.WriteLine();
            foreach (var item in charArray)
            {
                Console.Write(item);
            }

            CustomString str6 = charArray;

            Console.WriteLine($"{Environment.NewLine}Строка из массива символов: {str6}");

            CustomString str7 = "Первое слово";
            CustomString str8 = " и второе слово";

            Console.WriteLine($"Конкатенация строк: {str7+str8}");
        }
    }
}
