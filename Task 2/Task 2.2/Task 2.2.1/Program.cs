using System;
using Task_2._2._1.Models;

namespace Task_2._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Chest chest = new Chest();
            chest.GenerateItemsLow();


            Game.Game.ChestItems(chest);
        }
    }
}
