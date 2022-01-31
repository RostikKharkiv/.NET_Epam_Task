using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2._2._1.Game;

namespace Task_2._2._1.Models
{
    public enum MoveDirection
    {
        None = 0,
        Up = 1,
        Right = 2,
        Down = 3,
        Left = 4
    }
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"({X}; {Y})";
        }

    }

    public class Human : GameObject
    {
        public int Health { get; protected set; }

        public int Armor { get; protected set; }

        public int Strength { get; protected set; }

        public bool IsAlive => Health == 0 ? false : true;

        public LinkedList<Item> Items { get; protected set; }

        public int VisabilityRadius { get; protected set; }

        public List<Point> Visability { get; protected set; }

        public Point StartPoint { get; protected set; }

        public Point CurrentPoint { get; set; }

        public MoveDirection Direction { get; protected set; }

        public Human()
        {
            Health = 100;
            Armor = 0;
            Strength = 15;
            Items = new LinkedList<Item>();
            Visability = new List<Point>();
            Direction = MoveDirection.Left;
        }

        public void Hit(Human human)
        {
            if (this.Strength - human.Armor > human.Health)
                human.Health = 0;
            else
                human.Health = human.Health - (this.Strength - human.Armor);
        }

        public void UseItem(Item item)
        {

            if (item is Potion)
            {
                Health += item.HealthChange;
                if (Health > 100)
                    Health = 100;
                Items.Remove(item);
            }
            else if (item is Food)
            {
                Health += item.HealthChange;
                if (Health > 100)
                    Health = 100;
                Items.Remove(item);
            }
            else if (item is Weapon)
                Strength = item.StrengthImpact;
            else if (item is Armor)
                Armor = item.ArmorRate;
        }

        public void PickUp(Item item)
        {
            Items.AddLast(item);
        }

        public void CheckVisability(GameObject[,] field)
        {
            Visability.Clear();
            for (int x = CurrentPoint.X - VisabilityRadius; x <= CurrentPoint.X + VisabilityRadius; x++)
            {
                for (int y = CurrentPoint.Y - VisabilityRadius; y <= CurrentPoint.Y + VisabilityRadius; y++)
                {
                    if (x >= 0 && x <= field.GetUpperBound(0) && y >= 0 && y <= field.GetUpperBound(1))
                    {
                        Visability.Add(new Point(x, y));
                    }
                }
            }
        }

        public MoveDirection Move(MoveDirection moveDirection, GameObject[,] field)
        {
            switch (moveDirection)
            {
                case MoveDirection.Left when (CurrentPoint.Y - 1 >= 0) 
                && !(field[CurrentPoint.X, CurrentPoint.Y - 1] is Obstacle):
                    if (!(field[CurrentPoint.X, CurrentPoint.Y - 1] is Chest))
                    {
                        field[CurrentPoint.X, CurrentPoint.Y] = new None();
                        CurrentPoint = new Point(CurrentPoint.X, CurrentPoint.Y - 1);
                        field[CurrentPoint.X, CurrentPoint.Y] = this;
                    }
                    return Direction = MoveDirection.Left;
                case MoveDirection.Down when (CurrentPoint.X + 1 <= field.GetUpperBound(0))
                && !(field[CurrentPoint.X + 1, CurrentPoint.Y] is Obstacle):
                    if (!(field[CurrentPoint.X + 1, CurrentPoint.Y] is Chest))
                    {
                        field[CurrentPoint.X, CurrentPoint.Y] = new None();
                        CurrentPoint = new Point(CurrentPoint.X + 1, CurrentPoint.Y);
                        field[CurrentPoint.X, CurrentPoint.Y] = this;
                    }
                    return Direction = MoveDirection.Down;
                case MoveDirection.Right when (CurrentPoint.Y + 1 <= field.GetUpperBound(1))
                && !(field[CurrentPoint.X, CurrentPoint.Y + 1] is Obstacle):
                    field[CurrentPoint.X, CurrentPoint.Y] = new None();
                    if (!(field[CurrentPoint.X, CurrentPoint.Y + 1] is Chest))
                    {
                        CurrentPoint = new Point(CurrentPoint.X, CurrentPoint.Y + 1);
                        field[CurrentPoint.X, CurrentPoint.Y] = this;
                    }
                    return Direction = MoveDirection.Right;
                case MoveDirection.Up when (CurrentPoint.X - 1 >= 0)
                && !(field[CurrentPoint.X - 1, CurrentPoint.Y] is Obstacle):
                    if (!(field[CurrentPoint.X - 1, CurrentPoint.Y] is Chest))
                    {
                        field[CurrentPoint.X, CurrentPoint.Y] = new None();
                        CurrentPoint = new Point(CurrentPoint.X - 1, CurrentPoint.Y);
                        field[CurrentPoint.X, CurrentPoint.Y] = this;
                    }
                    return Direction = MoveDirection.Up;
                default:
                    return Direction = MoveDirection.None;
            }
        }

        public void Chase(Human human)
        {
            int xRange = human.CurrentPoint.X - this.CurrentPoint.X;
            int yRange = human.CurrentPoint.Y - this.CurrentPoint.Y;

            MoveDirection left = MoveDirection.Left;
            MoveDirection right = MoveDirection.Right;
            MoveDirection up = MoveDirection.Up;
            MoveDirection down = MoveDirection.Down;
            MoveDirection none = MoveDirection.None;

            var field = Game.Game.Field;

            if (xRange < 0 && yRange <= 0)
            {
                if (Move(up, field) == none)
                    if (Move(left, field) == none)
                        if (Move(down, field) == none)
                            Move(right, field);
            }
            else if (xRange > 0 && yRange <= 0)
            {

                if (Move(down, field) == none)
                    if (Move(left, field) == none)
                        if (Move(up, field) == none)
                            Move(right, field);
            }
            else if (xRange > 0 && yRange >= 0)
            {
                if (Move(down, field) == none)
                    if (Move(right, field) == none)
                        if (Move(up, field) == none)
                            Move(left, field);
            }
            else if (xRange < 0 && yRange >= 0)
            {
                if (Move(up, field) == none)
                    if (Move(right, field) == none)
                        if (Move(down, field) == none)
                            Move(left, field);
            }
            else if (xRange == 0 && yRange > 0)
            {
                if (Move(right, field) == none)
                    if (Move(up, field) == none)
                        if (Move(down, field) == none)
                            Move(left, field);
            }
            else if (xRange == 0 && yRange < 0)
            {
                if (Move(left, field) == none)
                    if (Move(up, field) == none)
                        if (Move(down, field) == none)
                            Move(right, field);
            }
            else
                Move(none, field);
        }
    }

    public class Player : Human
    {
        public Player()
        {
            VisabilityRadius = 6;
            Direction = MoveDirection.Right;
        }

        public override string ToString()
        {
            return "Главный герой";
        }
    }

    public class LightweightWarrior : Human
    {
        public LightweightWarrior()
        {
            Armor = 10;
            Strength = 25;
            VisabilityRadius = 3;
        }

        public override string ToString()
        {
            return "Воин в лёгкой броне";
        }
    }

    public class Warrior : Human
    {
        public Warrior()
        {
            Armor = 15;
            Strength = 35;
            VisabilityRadius = 2;
        }

        public override string ToString()
        {
            return "Воин";
        }
    }

    public class HeavyWarrior : Human
    {
        public HeavyWarrior()
        {
            Armor = 25;
            Strength = 50;
            VisabilityRadius = 2;
        }

        public override string ToString()
        {
            return "Воин в тяжёлой броне";
        }
    }
}
