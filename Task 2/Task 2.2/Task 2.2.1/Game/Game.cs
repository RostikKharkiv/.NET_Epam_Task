using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2._2._1.Models;

namespace Task_2._2._1.Game
{
    public class Game
    {
        public static GameObject[,] Field { get; private set; } = new GameObject[20, 60];
        public static Player MainHero { get; private set; }

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

        public static void PaintChestItems(Chest chest, LinkedListNode<Item> current)
        {
            foreach (var item in chest.Items)
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
        public static void ChestItems(Chest chest)
        {
            var current = chest.Items.First;

            ConsoleKeyInfo info = new ConsoleKeyInfo();
            PaintChestItems(chest, current);

            do
            {
                info = Console.ReadKey();
                switch (info.Key)
                {
                    case ConsoleKey.W:
                        if (current.Previous != null)
                            current = current.Previous;
                        Console.Clear();
                        PaintChestItems(chest, current);
                        break;
                    case ConsoleKey.S:
                        if (current.Next != null)
                            current = current.Next;
                        Console.Clear();
                        PaintChestItems(chest, current);
                        break;
                }
            } while (info.Key != ConsoleKey.Tab && chest.Items.Count != 0);

        }
        public static void GenerateField()
        {
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
                    }
                    else
                    {
                        Field[i, j] = new None();
                    }
                }
            }
        }

        public static void PaintField()
        {
            for (int i = 0; i <= Field.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= Field.GetUpperBound(1); j++)
                {
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
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
                            PaintDirection(Field[i, j] as LightweightWarrior, ConsoleColor.Yellow);
                            break;
                        case Warrior:
                            PaintDirection(Field[i, j] as Warrior, ConsoleColor.Red);
                            break;
                        case HeavyWarrior:
                            PaintDirection(Field[i, j] as HeavyWarrior, ConsoleColor.Magenta);
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
