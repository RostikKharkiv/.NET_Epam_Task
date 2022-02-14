using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3._3
{
    public class Client
    {
        private static int _clientIdCount = 0;
        private List<Order> _orders = new List<Order>();

        public IEnumerable<Order> UpcomingOrders => _orders.Where(o => o.Completed == false);

        public IEnumerable<Order> CompletedOrders => _orders.Where(o => o.Completed == true);
        
        public int ClientId { get; private set; }

        public string FirstName { get; private set; }

        public int WalletWithMoney { get; private set; }

        public Client(string firstName, int money)
        {
            ClientId = _clientIdCount++;
            FirstName = firstName;
            WalletWithMoney = money;
        }

        public void MakeAnOrder(List<Pizza> orderedPizza, Pizzeria pizzeria)
        {
            int orderCost = orderedPizza.Select(o => o.Cost).Sum();

            if (orderCost > WalletWithMoney)
            {
                Console.WriteLine("У вас недостаточно денег");
                return;
            }

            WalletWithMoney -= orderCost;

            Order order = pizzeria.Checkout(orderedPizza, FirstName);

            _orders.Add(order);
        }

        public void PickUpOrder(Pizzeria pizzeria, Order order)
        {
            order = (Order)pizzeria.ReadyOrders.Where(o => o.Equals(UpcomingOrders.FirstOrDefault()));

            if (order is null)
            {
                return;
            }

            pizzeria.ClientPickUpOrder(order);
        }
    }
}
