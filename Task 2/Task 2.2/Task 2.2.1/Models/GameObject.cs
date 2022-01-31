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
        public LinkedList<Item> Items { get; private set; } = new LinkedList<Item>();

        public bool IsEmpty => Items.Count() == 0;

        private Random rnd = new Random();

        public void GenerateItemsLow()
        {
            for (int i = 0; i < rnd.Next(1, 10); i++) 
            {
                int randomItem = rnd.Next(0, 5);

                switch(randomItem)
                {
                    case 0:
                        Items.AddLast(new WeakHealthPotion());
                        break;
                    case 1:
                        Items.AddLast(new Bread());
                        break;
                    case 2:
                        Items.AddLast(new Ale());
                        break;
                    case 3:
                        Items.AddLast(new ApplePie());
                        break;
                    case 4:
                        Items.AddLast(new PureWater());
                        break;
                    case 5:
                        Items.AddLast(new Steak());
                        break;
                    default:
                        break;
                }
            }
        }

        public void GenerateItemsMedium()
        {
            for (int i = 0; i < rnd.Next(1, 10); i++)
            {
                int randomItem = rnd.Next(0, 2);

                switch (randomItem)
                {
                    case 0:
                        Items.AddLast(new HealthPotion());
                        break;
                    case 1:
                        Items.AddLast(new StrongHealthPotion());
                        break;
                    case 2:
                        Items.AddLast(new WeakHealthPotion());
                        break;
                    default:
                        break;
                }
            }
        }

        public void AddItem(Item item)
        {
            Items.AddLast(item);
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
