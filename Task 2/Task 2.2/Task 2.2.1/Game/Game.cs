using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task_2._2._1.Models;

namespace Task_2._2._1.Game
{
    public class Game
    {
        public static GameObject[,] Field { get; private set; } = new GameObject[20, 60];
        public static Player MainHero { get; private set; }

        public static List<Human> Enemies = new List<Human>();
        public static void PaintDirection(Human human, ConsoleColor color)
        {
            switch (human.Direction)
            {
                case MoveDirection.Down:
                    Console.ForegroundColor = color;
                    Console.Write("↓");
                    Console.ResetColor();
                    break;
                case MoveDirection.Left:
                    Console.ForegroundColor = color;
                    Console.Write("←");
                    Console.ResetColor();
                    break;
                case MoveDirection.Up:
                    Console.ForegroundColor = color;
                    Console.Write("↑");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = color;
                    Console.Write("→");
                    Console.ResetColor();
                    break;
            }
        }

        public static void PaintItems(LinkedList<Item> items, LinkedListNode<Item> current)
        {
            foreach (var item in items)
            {
                if (current.Value.Equals(item))
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine(item.ToString());
                    Console.ResetColor();
                }
                else
                    Console.WriteLine(item.ToString());
            }
        }
        public static void CheckItems(LinkedList<Item> items, bool inventory = false)
        {
            var current = items.First;
            var next = items.First;

            ConsoleKeyInfo info = new ConsoleKeyInfo();
            PaintItems(items, current);

            do
            {
                info = Console.ReadKey();
                switch (info.Key)
                {
                    case ConsoleKey.W:
                        if (current.Previous != null)
                            current = current.Previous;
                        Console.Clear();
                        PaintItems(items, current);
                        break;
                    case ConsoleKey.S:
                        if (current.Next != null)
                            current = current.Next;
                        Console.Clear();
                        PaintItems(items, current);
                        break;
                    case ConsoleKey.E:
                        if (!inventory)
                        {
                            if (current.Next != null)
                                next = current.Next;
                            else if (current.Previous != null)
                                next = current.Previous;
                            MainHero.Items.AddLast(current.Value);
                            items.Remove(current);
                            current = next;
                            Console.Clear();
                            PaintItems(items, current);
                        }
                        else
                        {
                            if (current.Next != null)
                                next = current.Next;
                            else if (current.Previous != null)
                                next = current.Previous;
                            MainHero.UseItem(current.Value);
                            Console.Clear();
                            PaintItems(items, current);
                        }
                        break;
                }
            } while (info.Key != ConsoleKey.Tab && items.Count != 0);

        }

        public static void HeroMove()
        {
            MoveDirection left = MoveDirection.Left;
            MoveDirection right = MoveDirection.Right;
            MoveDirection up = MoveDirection.Up;
            MoveDirection down = MoveDirection.Down;
            MoveDirection none = MoveDirection.None;

            while (MainHero.IsAlive)
            {
                ConsoleKeyInfo info = new ConsoleKeyInfo();

                do
                {
                    info = Console.ReadKey();
                    switch (info.Key)
                    {
                        case ConsoleKey.W:
                            if (!IsChest(MainHero.CurrentPoint))
                                Field[MainHero.CurrentPoint.X, MainHero.CurrentPoint.Y] = new None();
                            MainHero.Move(up, Field);
                            Console.Clear();
                            Field[MainHero.CurrentPoint.X, MainHero.CurrentPoint.Y] = MainHero;
                            if (IsChest(MainHero.CurrentPoint)) ;
                            IsChasingZone(MainHero.CurrentPoint);
                            PaintField();
                            break;
                        case ConsoleKey.S:
                            if (!IsChest(MainHero.CurrentPoint))
                                Field[MainHero.CurrentPoint.X, MainHero.CurrentPoint.Y] = new None();
                            MainHero.Move(down, Field);
                            Console.Clear();
                            Field[MainHero.CurrentPoint.X, MainHero.CurrentPoint.Y] = MainHero;
                            if (IsChest(MainHero.CurrentPoint)) ;
                            IsChasingZone(MainHero.CurrentPoint);
                            PaintField();
                            break;
                        case ConsoleKey.A:
                            if (!IsChest(MainHero.CurrentPoint))
                                Field[MainHero.CurrentPoint.X, MainHero.CurrentPoint.Y] = new None();
                            MainHero.Move(left, Field);
                            Console.Clear();
                            Field[MainHero.CurrentPoint.X, MainHero.CurrentPoint.Y] = MainHero;
                            if (IsChest(MainHero.CurrentPoint)) ;
                            IsChasingZone(MainHero.CurrentPoint);
                            PaintField();
                            break;
                        case ConsoleKey.D:
                            if (!IsChest(MainHero.CurrentPoint))
                                Field[MainHero.CurrentPoint.X, MainHero.CurrentPoint.Y] = new None();
                            MainHero.Move(right, Field);
                            Console.Clear();
                            Field[MainHero.CurrentPoint.X, MainHero.CurrentPoint.Y] = MainHero;
                            IsChasingZone(MainHero.CurrentPoint);
                            PaintField();
                            break;
                        case ConsoleKey.E:
                            if (IsChest(new Point(MainHero.CurrentPoint.X - 1, MainHero.CurrentPoint.Y))
                                || IsChest(new Point(MainHero.CurrentPoint.X + 1, MainHero.CurrentPoint.Y))
                                || IsChest(new Point(MainHero.CurrentPoint.X, MainHero.CurrentPoint.Y + 1))
                                || IsChest(new Point(MainHero.CurrentPoint.X, MainHero.CurrentPoint.Y - 1))) ;    
                            break;
                        case ConsoleKey.I:
                            CheckItems(MainHero.Items, true);
                            break;
                    }
                } while (info.Key != ConsoleKey.Escape);
            }
        }

        public static bool IsChasingZone(Point point)
        {
            foreach (var enemy in Enemies)
            {
                enemy.CheckVisability(Field);
                foreach (var chasePoint in enemy.Visability)
                {
                    if (chasePoint.Equals(point))
                    {
                        if (enemy.CurrentPoint.Equals(MainHero.CurrentPoint))
                        {
                            Fight(enemy);
                        }
                        else
                        {
                            enemy.Chase(MainHero);
                        }
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsChest(Point point)
        {
            if (Field[point.X, point.Y] is Chest)
            {
                Chest chest = Field[point.X, point.Y] as Chest;
                Console.Clear();
                CheckItems(chest.Items);
                if (chest.IsEmpty)
                {
                    Field[point.X, point.Y] = new None();
                }
                return true;
            }

            return false;
        }

        private static void Fight(Human enemy)
        {
            Console.WriteLine($"Началось сражение! " +
                $"{MainHero} vs {enemy}");
            while (MainHero.IsAlive && enemy.IsAlive)
            {
                MainHero.Hit(enemy);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{MainHero}({MainHero.Health}) ");
                Console.ResetColor();
                Console.Write($"наносит ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{MainHero.Strength - enemy.Armor}");
                Console.ResetColor();
                Console.Write(" урона по ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{enemy}({enemy.Health})");
                Console.ResetColor();
                Console.WriteLine();
                Thread.Sleep(2000);
                enemy.Hit(MainHero);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{enemy}({enemy.Health}) ");
                Console.ResetColor();
                Console.Write($"наносит ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{enemy.Strength - MainHero.Armor}");
                Console.ResetColor();
                Console.Write(" урона по ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{MainHero}({MainHero.Health})");
                Console.ResetColor();
                Console.WriteLine();
                Thread.Sleep(2000);
            }
            if (MainHero.IsAlive)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{MainHero} ");
                Console.ResetColor();
                Console.Write("выигрывает сражение!");
                Thread.Sleep(2000);
                MainHero.CurrentPoint = enemy.CurrentPoint;
                enemy.CurrentPoint = new Point(-10, -10);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{enemy} ");
                Console.ResetColor();
                Console.Write("выигрывает сражение!\n");
                Console.WriteLine("Конец игры!");
                Thread.Sleep(2000);
                Field[MainHero.CurrentPoint.X, MainHero.CurrentPoint.Y] = new None();
            }
        }

        public static void GenerateField()
        {
            Random rnd = new Random();

            int warriorCount = 0;
            int lightweightWarriorCount = 0;
            int heavyWarriorCount = 0;

            int x;
            int y;

            for (int i = 0; i <= Field.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= Field.GetUpperBound(1); j++)
                {
                    if ((i == 0 || i == Field.GetUpperBound(0))
                        || (j == 0 || j == Field.GetUpperBound(1)))
                    {
                        Field[i, j] = new Border();
                    }
                    else if (i == Field.GetUpperBound(0) / 2 && j == 5)
                    {
                        Field[i, j] = new Player();
                        MainHero = Field[i, j] as Player;
                        MainHero.CurrentPoint = new Point(i, j);
                    }
                    else
                    {
                        Field[i, j] = new None();
                    }
                }
            }

            for (int i = 0; i < rnd.Next(30, 70); i++)
            {
                x = rnd.Next(0, Field.GetUpperBound(0));
                y = rnd.Next(0, Field.GetUpperBound(1));

                if (Field[x, y] is None)
                {
                    Field[x, y] = new Tree();
                }
            }

            for (int i = 0; i < rnd.Next(5, 10); i++)
            {
                x = rnd.Next(0, Field.GetUpperBound(0));
                y = rnd.Next(0, Field.GetUpperBound(1));

                if (Field[x, y] is None)
                {
                    Field[x, y] = new Chest();
                    (Field[x, y] as Chest).GenerateItemsLow();
                }
            }

            do
            {
                x = rnd.Next(0, Field.GetUpperBound(0));
                y = rnd.Next(0, Field.GetUpperBound(1));

                if (Field[x, y] is None & y > MainHero.CurrentPoint.Y + 6)
                {
                    Field[x, y] = new LightweightWarrior();
                    Enemies.Add(Field[x, y] as LightweightWarrior);
                    (Field[x, y] as LightweightWarrior).CurrentPoint = new Point(x, y);
                }

                lightweightWarriorCount++;

            } while (lightweightWarriorCount < rnd.Next(10, 15));

            do
            {
                x = rnd.Next(0, Field.GetUpperBound(0));
                y = rnd.Next(0, Field.GetUpperBound(1));

                if (Field[x, y] is None && y > Field.GetUpperBound(1) / 3 - 1)
                {
                    Field[x, y] = new Warrior();
                    Enemies.Add(Field[x, y] as Warrior);
                    (Field[x, y] as Warrior).CurrentPoint = new Point(x, y);
                }

                warriorCount++;

            } while (warriorCount < rnd.Next(7, 12));

            do
            {
                x = rnd.Next(0, Field.GetUpperBound(0));
                y = rnd.Next(0, Field.GetUpperBound(1));

                if (Field[x, y] is None && y > Field.GetUpperBound(1) / 3 * 2 - 1)
                {
                    Field[x, y] = new HeavyWarrior();
                    Enemies.Add(Field[x, y] as HeavyWarrior);
                    (Field[x, y] as HeavyWarrior).CurrentPoint = new Point(x, y);
                }

                heavyWarriorCount++;

            } while (heavyWarriorCount < rnd.Next(5, 8));
        }

        public static void PaintField()
        {
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i <= Field.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= Field.GetUpperBound(1); j++)
                {
                    switch (Field[i, j])
                    {
                        case Border:
                            if (i == 0 && j == 0)
                                Console.Write("*");
                            else if (i == 0 && j == Field.GetUpperBound(1))
                                Console.Write("*");
                            else if (i == Field.GetUpperBound(0) && j == 0)
                                Console.Write("*");
                            else if (i == Field.GetUpperBound(0) && j == Field.GetUpperBound(1))
                                Console.Write("*");
                            else if ((i == 0 || i == Field.GetUpperBound(0)))
                                Console.Write("—");
                            else if ((j == 0 || j == Field.GetUpperBound(1)))
                                Console.Write("|");
                            break;
                        case None:
                            Console.Write(" ");
                            break;
                        case Player:
                            PaintDirection(MainHero, ConsoleColor.Cyan);
                            break;
                        case LightweightWarrior:
                            LightweightWarrior lightweightWarrior = Field[i, j] as LightweightWarrior;
                            if (lightweightWarrior != null)
                                PaintDirection(lightweightWarrior, ConsoleColor.Yellow);
                            break;
                        case Warrior:
                            Warrior warrior = Field[i, j] as Warrior;
                            if (warrior != null)
                                PaintDirection(Field[i, j] as Warrior, ConsoleColor.Red);
                            break;
                        case HeavyWarrior:
                            HeavyWarrior heavyWarrior = Field[i, j] as HeavyWarrior;
                            if (heavyWarrior != null)
                                PaintDirection(heavyWarrior, ConsoleColor.DarkRed);
                            break;
                        case Chest:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("\uaaaa");
                            Console.ResetColor();
                            break;
                        case Tree:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("‡");
                            Console.ResetColor();
                            break;

                    }
                }
                Console.WriteLine();
            }
        }
    }
}
