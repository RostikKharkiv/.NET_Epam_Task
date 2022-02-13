using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3._3
{
    public class Pizzeria
    {
        private Pepperoni _pepperoni = new Pepperoni();
        private Cheesy _cheesy = new Cheesy();
        private Hawaii _hawaii = new Hawaii();
        private Branded _branded = new Branded();
        private Common _common = new Common();
        private Mushroom _mushroom = new Mushroom();
        private List<Order> _orders = new List<Order>();

        public IEnumerable<Order> ReadyOrders => _orders.Where(o => o.IsReady == true);

        public string Menu()
        {
            return _pepperoni.ToString() + _cheesy.ToString() + 
                _hawaii.ToString() + _branded.ToString() + 
                _common.ToString() + _mushroom.ToString();
        }

        public Order Checkout(List<Pizza> orderedPizza, string firstName)
        {
            int orderCost = orderedPizza.Select(o => o.Cost).Sum();
            int cookingTime = orderedPizza.Select(o => o.CookingTimeInMinutes).Sum();

            Order order = new Order(firstName, orderCost, cookingTime, orderedPizza);

            order.OnReady += OnOrderReady;
            return order;
        }

        public void OnOrderReady()
        {

        }

    }
}
