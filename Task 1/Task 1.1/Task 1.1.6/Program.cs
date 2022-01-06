using System;

namespace Task_1._1._6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bold = false;
            bool italic = false;
            bool underline = false;

            while (true)
            {
                Console.WriteLine($"Параметры надписи: " +
                    $"{(!bold && !italic && !underline? "none" : "")}" +
                    $"{(bold ? "bold " : "")}" +
                    $"{(italic ? "italic " : "")}" +
                    $"{(underline ? "underline " : "")}" +
                    "\nВведите:" +
                    "\n1: bold" +
                    "\n2: italic" +
                    "\n3: underline");
                int choose;
                int.TryParse(Console.ReadLine(), out choose);

                switch (choose)
                {
                    case 1:
                        bold = !bold;
                        break;
                    case 2:
                        italic = !italic;
                        break;
                    case 3:
                        underline = !underline;
                        break;
                    default:
                        Console.WriteLine("Invalid parameter");
                        break;
                }
            }


        }
    }
}
