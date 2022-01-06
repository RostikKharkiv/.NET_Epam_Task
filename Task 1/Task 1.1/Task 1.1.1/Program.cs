using System;

namespace Task_1._1._1
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle();

            Console.Write("Enter first side: ");
            int fs;
            int.TryParse(Console.ReadLine(), out fs);
            rectangle.FirstSide = fs;
            Console.Write("Enter second side: ");
            int ss;
            int.TryParse(Console.ReadLine(), out ss);
            rectangle.SecondSide = ss;

            if (rectangle.Square != 0)
                Console.WriteLine($"Square: {rectangle.Square}");
        }
    }

}
