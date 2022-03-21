using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3._3
{
    public class Order
    {
        private static int _orderIdCount = 200;

        public event Action<Order> OnReady = (order) => { };

        public int OrderId { get; private set; }

        public Pizzeria Pizzeria { get; private set; }

        public string ClientName { get; private set; }

        public int Cost { get; private set; }

        public int WaitingTime { get; private set; }

        public bool Ready { get; private set; } = false;

        public bool Completed { get; private set; } = false;

        public List<Pizza> OrderedPizza { get; private set; }

        public Order(string clientName, Pizzeria pizzeria, int cost, int waitingTime, List<Pizza> orderedPizza)
        {
            OrderId = _orderIdCount++;
            Pizzeria = pizzeria;
            ClientName = clientName;
            Cost = cost;
            WaitingTime = waitingTime;
            OrderedPizza = orderedPizza;

            pizzeria.OnPickedUp += OnPickedUp;
        }

        public void Cooking()
        {
            Console.WriteLine($"Заказ номер {OrderId} готовится...");

            Thread.Sleep(WaitingTime * 500);

            Ready = true;

            OnReady(this);
        }

        public void OnPickedUp(Order order)
        {
            order.Completed = true;
        }
    }
}
