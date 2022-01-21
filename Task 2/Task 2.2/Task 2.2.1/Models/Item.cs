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

    public class Potion : Item { }
    public class Food : Item { }
    public class Weapon : Item { }
    public class Armor : Item { }

    public class Bread : Food
    {
        public Bread()
        {
            HealthChange = 5;
        }
    }

    public class ApplePie : Food
    {
        public ApplePie()
        {
            HealthChange = 7;
        }
    }

    public class PureWater : Food
    {
        public PureWater()
        {
            HealthChange = 3;
        }
    }

    public class Ale : Food
    {
        public Ale()
        {
            HealthChange = 5;
        }
    }

    public class Steak : Food
    {
        public Steak()
        {
            HealthChange = 10;
        }
    }

    public class WeakHealthPotion : Potion
    {
        public WeakHealthPotion()
        {
            HealthChange = 25;
        }
    }

    public class HealthPotion : Potion
    {
        public HealthPotion()
        {
            HealthChange = 50;
        }
    }

    public class StrongHealthPotion : Potion
    {
        public StrongHealthPotion()
        {
            HealthChange = 100;
        }
    }

    public class Dagger : Weapon
    {
        public Dagger()
        {
            StrengthImpact = 25;
        }
    }

    public class Sword : Weapon
    {
        public Sword()
        {
            StrengthImpact = 35;
        }
    }

    public class GreatSword : Weapon
    {
        public GreatSword()
        {
            StrengthImpact = 50;
        }
    }

    public class GreatHammer : Weapon
    {
        public GreatHammer()
        {
            StrengthImpact = 70;
        }
    }


    public class LeatherArmor : Armor
    {
        public LeatherArmor()
        {
            ArmorRate = 10;
        }
    }

    public class IronArmor : Armor
    {
        public IronArmor()
        {
            ArmorRate = 15;
        }
    }

    public class SteelArmor : Armor
    {
        public SteelArmor()
        {
            ArmorRate = 25;
        }
    }
}
