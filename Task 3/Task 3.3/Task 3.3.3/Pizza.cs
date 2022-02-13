using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3._3
{
    public enum PizzaType
    {
        None = 0,
        Pepperoni = 1,
        Cheesy = 2,
        Hawaii = 3,
        Branded = 4,
        Common = 5,
        Mushroom = 6
    }
    public class Pizza
    {
        protected static string _mushrooms = "грибы";
        protected static string _cheese = "сыр";
        protected static string _chiken = "курица";
        protected static string _tomato = "помидоры";
        protected static string _sauce = "соус";
        protected static string _dough = "тесто";
        protected static string _pineapple = "ананасы";
        protected static string _pepperoni = "колбаски пепперони";
        protected static string _ham = "ветчина";
        protected static string _onion = "лук";
        protected static string _pepper = "болгарский перец";
        public string Name { get; private set; }

        public int Cost { get; private set; }

        public int Weight { get; private set; }

        public PizzaType Type { get; private set; }

        public string Ingredients { get; private set; }

        public int CookingTimeInMinutes { get; private set; }

        public Pizza(string name, int cost, int weight, PizzaType type, 
            string ingredients, int cookingTimeInMinutes)
        {
            Name = name;
            Cost = cost;
            Weight = weight;
            Type = type;
            Ingredients = ingredients;
            CookingTimeInMinutes = cookingTimeInMinutes;
        }

        public override string ToString()
        {
            return $"Название: {Name}{Environment.NewLine}" +
                $"Ингридиенты: {Ingredients}{Environment.NewLine}" +
                $"Стоимость: {Cost} рублей{Environment.NewLine}" +
                $"Время приготовления: {CookingTimeInMinutes} минут{Environment.NewLine}{Environment.NewLine}";
        }
    }

    public class Pepperoni : Pizza
    {
        private static string[] _ingredients = new string[] { _dough, _pepperoni, _tomato, _sauce };
        public Pepperoni() : base("Пепперони", 480, 600, PizzaType.Pepperoni, 
            String.Join(", ", _ingredients), 10)
        {
        }
    }

    public class Cheesy : Pizza
    {
        private static string[] _ingredients = new string[] { _dough, _cheese, _tomato, _sauce };
        public Cheesy() : base("Сырная", 420, 500, PizzaType.Cheesy,
            String.Join(", ", _ingredients), 8)
        {
        }
    }

    public class Hawaii : Pizza
    {
        private static string[] _ingredients = new string[] { _dough, _ham, _tomato, _sauce, _pineapple };
        public Hawaii() : base("Гавайская", 600, 700, PizzaType.Hawaii,
            String.Join(", ", _ingredients), 14)
        {
        }
    }

    public class Branded : Pizza
    {
        private static string[] _ingredients = new string[] { _dough, _onion, _chiken, _cheese, _sauce, _tomato };
        public Branded() : base("Пицца \"Epam\"", 600, 700, PizzaType.Branded,
            String.Join(", ", _ingredients), 14)
        {
        }
    }

    public class Common : Pizza
    {
        private static string[] _ingredients = new string[] { _dough, _ham, _cheese, _sauce, _tomato, _mushrooms };
        public Common() : base("Домашняя", 500, 700, PizzaType.Common,
            String.Join(", ", _ingredients), 12)
        {
        }
    }

    public class Mushroom : Pizza
    {
        private static string[] _ingredients = new string[] { _dough, _cheese, _sauce, _mushrooms, _chiken };
        public Mushroom() : base("Грибная", 500, 600, PizzaType.Mushroom,
            String.Join(", ", _ingredients), 10)
        {
        }
    }
}
