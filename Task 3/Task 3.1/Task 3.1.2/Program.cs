using System;
using System.IO;

namespace Task_3._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = String.Empty;
            int frequency;
            int choose = 0;

            try
            {
                using (StreamReader sr = new StreamReader("FileWithEnglishText.txt"))
                {
                    text = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            TextAnalysis textAnalysis = new TextAnalysis(text);

            while (choose != 9)
            {
                Console.WriteLine($"Выберите действие:{Environment.NewLine}" +
                $"1)Поменять процент частоты часто используемых слов{Environment.NewLine}" +
                $"2)Отобразить все слова в тексте{Environment.NewLine}" +
                $"3)Отобразить часто используемые слова{Environment.NewLine}" +
                $"4)Отобразить количество слов в тексте{Environment.NewLine}" +
                $"9)Выйти из программы{Environment.NewLine}");

                int.TryParse(Console.ReadLine(), out choose);

                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите процент от общего количества слов, " +
                    "которые будут считаться часто используемыми " +
                    "(Например, значение 5 будет равно 5% от общего числа слов, " +
                    "то есть если у вас 100 слов в тексте, то будут отображены только те слова " +
                    "которые встречаются в тексте 5 или больше раз):");

                        int.TryParse(Console.ReadLine(), out frequency);

                        if (frequency != 0)
                        {
                            textAnalysis.Frequency = frequency;
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.Clear();
                        foreach (var item in textAnalysis.Words)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.Clear();
                        foreach (var item in textAnalysis.FrequentlyUsedWords)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"Количество слов: {textAnalysis.WordsCount}{Environment.NewLine}");
                        break;
                }
            }
        }
    }
}
