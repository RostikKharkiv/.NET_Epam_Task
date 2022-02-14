using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3._3._3 // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Pizzeria pizzeria = new Pizzeria("Пиццерия Epam", "Белоглинская 75/81", "89954002319");

            Client client = new Client("Дмитрий", 2000);

            Console.WriteLine(pizzeria.Menu());

            client.MakeAnOrder(new List<Pizza> { new Pepperoni(), new Cheesy() }, pizzeria);

        }
    }
}