using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2._1.Models
{
    public class GameObject 
    { 
        public bool IsNone { get; protected set; }

        public GameObject()
        {
            IsNone = false;
        }
    }

    public class Obstacle : GameObject { }

    public class Tree : Obstacle { }

    public class Border : Obstacle { }

    public class Chest : GameObject
    {
        public List<Item> Items { get; private set; } = new List<Item>();

        public bool IsEmpty => Items.Count() == 0;

        private Random rnd = new Random();

        public void GenerateItemsLow()
        {
            for (int i = 0; i < rnd.Next(1, 4); i++) 
            {
                int randomItem = rnd.Next(0, 5);

                switch(randomItem)
                {
                    case 0:
                        Items.Add(new WeakHealthPotion());
                        break;
                    case 1:
                        Items.Add(new Bread());
                        break;
                    case 2:
                        Items.Add(new Ale());
                        break;
                    case 3:
                        Items.Add(new ApplePie());
                        break;
                    case 4:
                        Items.Add(new PureWater());
                        break;
                    case 5:
                        Items.Add(new Steak());
                        break;
                    default:
                        break;
                }
            }
        }

        public void GenerateItemsMedium()
        {
            for (int i = 0; i < rnd.Next(1, 3); i++)
            {
                int randomItem = rnd.Next(0, 2);

                switch (randomItem)
                {
                    case 0:
                        Items.Add(new HealthPotion());
                        break;
                    case 1:
                        Items.Add(new StrongHealthPotion());
                        break;
                    case 2:
                        Items.Add(new WeakHealthPotion());
                        break;
                    default:
                        break;
                }
            }
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }
    }

    public class None : GameObject
    {
        public None()
        {
            IsNone = true;
        }
    }
}
