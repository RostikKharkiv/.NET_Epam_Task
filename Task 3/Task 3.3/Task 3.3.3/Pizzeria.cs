using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3._3
{
    public class Pizzeria
    {
        private int _pizzeriaId = 0;
        private Pepperoni _pepperoni = new Pepperoni();
        private Cheesy _cheesy = new Cheesy();
        private Hawaii _hawaii = new Hawaii();
        private Branded _branded = new Branded();
        private Common _common = new Common();
        private Mushroom _mushroom = new Mushroom();
        private List<Order> _orders = new List<Order>();
        private List<Order> _readyOrders = new List<Order>();

        public event Action<Order> OnPickedUp = (order) => { };

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Adress { get; private set; }

        public string PhoneNumber { get; private set; }

        public IEnumerable<Order> ReadyOrders => _readyOrders;

        public Pizzeria(string name, string adress, string phoneNumber)
        {
            Id = _pizzeriaId++;
            Name = name;
            Adress = adress;
            PhoneNumber = phoneNumber;
        }

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

            Order order = new Order(firstName, this, orderCost, cookingTime, orderedPizza);

            order.OnReady += OnOrderReady;

            _orders.Add(order);

            return order;
        }

        public void Cooking()
        {
            _orders.Where(o => o.Ready == false && o.Completed == false).ToList().ForEach(o => o.Cooking());
        }

        public void OnOrderReady(Order order)
        {
            order.OnReady -= OnOrderReady;
            ReadyOrders.Append(order);
            Console.WriteLine($"{order.ClientName}, ваш заказ номер {order.OrderId} готов");
        }

        public void ClientPickUpOrder(Order order)
        {
            OnPickedUp(order);
        }
    }
}
