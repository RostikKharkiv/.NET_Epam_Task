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

        public List<Item> Items { get; protected set; }

        public int VisabilityRadius { get; protected set; }

        public List<Point> Visability { get; protected set; }

        public Point StartPoint { get; protected set; }

        public Point CurrentPoint { get; protected set; }

        public Human()
        {
            Health = 100;
            Armor = 0;
            Strength = 15;
            Items = new List<Item>();
            Visability = new List<Point>();
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
            else if (item is Weapon)
                Strength = item.StrengthImpact;
            else if (item is Armor)
                Armor = item.ArmorRate;
        }

        public void PickUp(Item item)
        {
            Items.Add(item);
        }

        public void CheckVisability(int r, GameObject[,] field)
        {
            Visability.Clear();
            for (int x = CurrentPoint.X - r; x <= CurrentPoint.X + r; x++)
            {
                for (int y = CurrentPoint.Y - r; y <= CurrentPoint.Y + r; y++)
                {
                    if (x >= 0 && x < field.GetUpperBound(1) && y >= 0 && y < field.GetUpperBound(2))
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
                case MoveDirection.Up when (CurrentPoint.Y - 1 >= 0) 
                && !(field[CurrentPoint.X, CurrentPoint.Y - 1] is Obstacle):
                    CurrentPoint = new Point(CurrentPoint.X, CurrentPoint.Y - 1);
                    return MoveDirection.Up;
                case MoveDirection.Right when (CurrentPoint.X + 1 < field.GetUpperBound(1))
                && !(field[CurrentPoint.X + 1, CurrentPoint.Y] is Obstacle):
                    CurrentPoint = new Point(CurrentPoint.X + 1, CurrentPoint.Y);
                    return MoveDirection.Right;
                case MoveDirection.Down when (CurrentPoint.Y + 1 < field.GetUpperBound(2))
                && !(field[CurrentPoint.X, CurrentPoint.Y + 1] is Obstacle):
                    CurrentPoint = new Point(CurrentPoint.X, CurrentPoint.Y + 1);
                    return MoveDirection.Down;
                case MoveDirection.Left when (CurrentPoint.X - 1 >= 0)
                && !(field[CurrentPoint.X - 1, CurrentPoint.Y] is Obstacle):
                    CurrentPoint = new Point(CurrentPoint.X - 1, CurrentPoint.Y);
                    return MoveDirection.Left;
                default:
                    return MoveDirection.None;
            }
        }

        public void Chase(Human human)
        {
            int xRange = human.CurrentPoint.X - this.CurrentPoint.X;
            int yRange = human.CurrentPoint.Y - this.CurrentPoint.Y;

            if (xRange < 0 && yRange <= 0)
            {
                if (this.Move(MoveDirection.Left, Game.Game.Field) == MoveDirection.None)
                    if (this.Move(MoveDirection.Up, Game.Game.Field) == MoveDirection.None)
                        if (this.Move(MoveDirection.Right, Game.Game.Field) == MoveDirection.None)
                            this.Move(MoveDirection.Down, Game.Game.Field);
            }
            else if (xRange > 0 && yRange <= 0)
            {
                if (this.Move(MoveDirection.Right, Game.Game.Field) == MoveDirection.None)
                    if (this.Move(MoveDirection.Up, Game.Game.Field) == MoveDirection.None)
                        if (this.Move(MoveDirection.Left, Game.Game.Field) == MoveDirection.None)
                            this.Move(MoveDirection.Down, Game.Game.Field);
            }
            else if (xRange > 0 && yRange >= 0)
            {
                if (this.Move(MoveDirection.Right, Game.Game.Field) == MoveDirection.None)
                    if (this.Move(MoveDirection.Down, Game.Game.Field) == MoveDirection.None)
                        if (this.Move(MoveDirection.Left, Game.Game.Field) == MoveDirection.None)
                            this.Move(MoveDirection.Up, Game.Game.Field);
            }
            else if (xRange < 0 && yRange >= 0)
            {
                if (this.Move(MoveDirection.Left, Game.Game.Field) == MoveDirection.None)
                    if (this.Move(MoveDirection.Down, Game.Game.Field) == MoveDirection.None)
                        if (this.Move(MoveDirection.Right, Game.Game.Field) == MoveDirection.None)
                            this.Move(MoveDirection.Up, Game.Game.Field);
            }
            else if (xRange == 0 && yRange > 0)
            {
                if (this.Move(MoveDirection.Down, Game.Game.Field) == MoveDirection.None)
                    if (this.Move(MoveDirection.Left, Game.Game.Field) == MoveDirection.None)
                        if (this.Move(MoveDirection.Right, Game.Game.Field) == MoveDirection.None)
                            this.Move(MoveDirection.Up, Game.Game.Field);
            }
            else if (xRange == 0 && yRange < 0)
            {
                if (this.Move(MoveDirection.Up, Game.Game.Field) == MoveDirection.None)
                    if (this.Move(MoveDirection.Left, Game.Game.Field) == MoveDirection.None)
                        if (this.Move(MoveDirection.Right, Game.Game.Field) == MoveDirection.None)
                            this.Move(MoveDirection.Down, Game.Game.Field);
            }
            else
                this.Move(MoveDirection.None, Game.Game.Field);
        }
    }

    public class Player : Human
    {
        public Player()
        {
            VisabilityRadius = 6;
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
    }

    public class Warrior : Human
    {
        public Warrior()
        {
            Armor = 15;
            Strength = 35;
            VisabilityRadius = 2;
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
    }
}
