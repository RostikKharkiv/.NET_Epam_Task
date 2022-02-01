using System;

namespace Task_3._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPeoples;
            int droppedOut;
            Console.Write("Введите количество участников: ");
            int.TryParse(Console.ReadLine(), out countOfPeoples);
            Console.Write("Введите, какой по счёту человек будет вычеркнут каждый раунд: ");
            int.TryParse(Console.ReadLine(), out droppedOut);
            WeakestLink game = new WeakestLink(countOfPeoples, droppedOut);
            game.GameStart();
        }
    }
}
