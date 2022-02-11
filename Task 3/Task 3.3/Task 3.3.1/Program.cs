using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3._3._1 
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] mass1 = { 1, 2, 3, 1, 2, 2, 2, 3, 4 };
            float[] mass2 = { 1.2f, 2.5f, 5.5f, 1.3f, 2,4f, 5.5f, 5.5f, 6.4f };
            double[] mass3 = { 1.2, 2.5, 5.5, 2.4, 1.2, 1.2, 0,0 };
            short[] mass4 = { 1, 2, 3, 2, 1, 1, 3 };
            byte[] mass5 = { 1, 2, 3, 3, 3, 3, 4, 4, 4, 5 };
            decimal[] mass6 = { 1.222222222m, 2.222222222m, 5.222222222m };

            int IncreaseInt(int el) => el * 3;
            float IncreaseFloat(float el) => el * 3;
            double IncreaseDouble(double el) => el * 3;
            short IncreaseShort(short el) => (short)(el * 3);
            byte IncreaseByte(byte el) => (byte)(el * 3);
            decimal IncreaseDecimal(decimal el) => el * 3;

            mass1.DoWithElements(IncreaseInt);

            Console.WriteLine("Массив интов");

            foreach (var item in mass1)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"{Environment.NewLine}Самый частый элемент: {mass1.Frequent()}");
            Console.WriteLine(Environment.NewLine);

            mass2.DoWithElements(IncreaseFloat);

            Console.WriteLine("Массив флоатов");

            foreach (var item in mass2)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"{Environment.NewLine}Самый частый элемент: {mass2.Frequent()}");
            Console.WriteLine(Environment.NewLine);

            mass3.DoWithElements(IncreaseDouble);

            Console.WriteLine("Массив даблов");

            foreach (var item in mass3)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"{Environment.NewLine}Самый частый элемент: {mass3.Frequent()}");
            Console.WriteLine(Environment.NewLine);

            mass4.DoWithElements(IncreaseShort);

            Console.WriteLine("Массив шортов (шорты)");

            foreach (var item in mass4)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"{Environment.NewLine}Самый частый элемент: {mass4.Frequent()}");
            Console.WriteLine(Environment.NewLine);

            mass5.DoWithElements(IncreaseByte);

            Console.WriteLine("Массив байтов");

            foreach (var item in mass5)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"{Environment.NewLine}Самый частый элемент: {mass5.Frequent()}");
            Console.WriteLine(Environment.NewLine);

            mass6.DoWithElements(IncreaseDecimal);

            Console.WriteLine("Массив децималов");

            foreach (var item in mass6)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"{Environment.NewLine}Самый частый элемент: {mass6.Frequent()}");
            Console.WriteLine(Environment.NewLine);
        }
    }
}