using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2._1.Models
{
    public class Item : GameObject
    {
        public int HealthChange { get; protected set; }

        public int ArmorRate { get; protected set; }

        public int StrengthImpact { get; protected set; }

    }

    public class Potion : Item
    {
        public override string ToString()
        {
            return "Зелье";
        }
    }
    public class Food : Item 
    {
        public override string ToString()
        {
            return "Еда";
        }
    }
    public class Weapon : Item
    {
        public override string ToString()
        {
            return "Оружие";
        }
    }
    public class Armor : Item
    {
        public override string ToString()
        {
            return "Броня";
        }
    }

    public class Bread : Food
    {
        public Bread()
        {
            HealthChange = 5;
        }

        public override string ToString()
        {
            return "Хлеб";
        }
    }

    public class ApplePie : Food
    {
        public ApplePie()
        {
            HealthChange = 7;
        }

        public override string ToString()
        {
            return "Яблочный пирог";
        }
    }

    public class PureWater : Food
    {
        public PureWater()
        {
            HealthChange = 3;
        }

        public override string ToString()
        {
            return "Чистая вода";
        }
    }

    public class Ale : Food
    {
        public Ale()
        {
            HealthChange = 5;
        }

        public override string ToString()
        {
            return "Эль";
        }
    }

    public class Steak : Food
    {
        public Steak()
        {
            HealthChange = 10;
        }

        public override string ToString()
        {
            return "Стейк";
        }
    }

    public class WeakHealthPotion : Potion
    {
        public WeakHealthPotion()
        {
            HealthChange = 25;
        }

        public override string ToString()
        {
            return "Слабое зелье здоровья";
        }
    }

    public class HealthPotion : Potion
    {
        public HealthPotion()
        {
            HealthChange = 50;
        }

        public override string ToString()
        {
            return "Зелье здоровья";
        }
    }

    public class StrongHealthPotion : Potion
    {
        public StrongHealthPotion()
        {
            HealthChange = 100;
        }

        public override string ToString()
        {
            return "Сильное зелье здоровья";
        }
    }

    public class Dagger : Weapon
    {
        public Dagger()
        {
            StrengthImpact = 25;
        }

        public override string ToString()
        {
            return "Железный кинжал";
        }
    }

    public class Sword : Weapon
    {
        public Sword()
        {
            StrengthImpact = 35;
        }

        public override string ToString()
        {
            return "Железный меч";
        }
    }

    public class GreatSword : Weapon
    {
        public GreatSword()
        {
            StrengthImpact = 50;
        }

        public override string ToString()
        {
            return "Двуручный железный меч";
        }
    }

    public class GreatHammer : Weapon
    {
        public GreatHammer()
        {
            StrengthImpact = 70;
        }

        public override string ToString()
        {
            return "Двуручный боевой молот";
        }
    }


    public class LeatherArmor : Armor
    {
        public LeatherArmor()
        {
            ArmorRate = 10;
        }

        public override string ToString()
        {
            return "Кожаная броня";
        }
    }

    public class IronArmor : Armor
    {
        public IronArmor()
        {
            ArmorRate = 15;
        }

        public override string ToString()
        {
            return "Железная броня";
        }
    }

    public class SteelArmor : Armor
    {
        public SteelArmor()
        {
            ArmorRate = 25;
        }

        public override string ToString()
        {
            return "Стальная броня";
        }
    }
}
