using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3._3
{
    public class Order
    {
        private static int _orderIdCount = 0;

        public event Action OnReady = () => { };

        public int OrderId { get; private set; }

        public string ClientName { get; private set; }

        public int Cost { get; private set; }

        public int WaitingTime { get; private set; }

        public bool IsReady { get; private set; } = false;

        public List<Pizza> OrderedPizza { get; private set; }

        public Order(string clientName, int cost, int waitingTime, List<Pizza> orderedPizza)
        {
            OrderId = _orderIdCount++;
            ClientName = clientName;
            Cost = cost;
            WaitingTime = waitingTime;
            OrderedPizza = orderedPizza;
        }

        public void OrderReady()
        {
            OnReady();
        }
    }
}
