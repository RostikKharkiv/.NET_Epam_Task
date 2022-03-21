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

            Client client1 = new Client("Дмитрий", 2000);
            Client client2 = new Client("Захар", 3000);
            Client client3 = new Client("Добрыня", 1000);

            client1.MakeAnOrder(new List<Pizza> { new Pepperoni(), new Cheesy() }, pizzeria);
            client2.MakeAnOrder(new List<Pizza> { new Pepperoni() }, pizzeria);
            client3.MakeAnOrder(new List<Pizza> { new Hawaii() }, pizzeria);

            pizzeria.Cooking();

        }
    }
}