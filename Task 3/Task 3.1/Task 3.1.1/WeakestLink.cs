using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_3._1._1
{
    public class WeakestLink
    {
        private LinkedList<int> _peoples = new LinkedList<int>();
        private int _countOfPeople;
        private int _droppedOut;

        public bool IsGameOver => _peoples.Count == 1;

        public int CountOfPeople
        {
            get
            {
                return _countOfPeople;
            }
            private set
            {
                if (value > 1)
                {
                    _countOfPeople = value;
                }
                else
                {
                    throw new ArgumentException("Количество участников должно быть от 2-х человек");
                }
            }
        }

        public int DroppedOut 
        { 
            get 
            {
                return _droppedOut;
            } 
            private set
            {
                if (value <= _countOfPeople && value > 0)
                {
                    _droppedOut = value;
                }
                else
                {
                    throw new ArgumentException("Номер каждого вычёркиваемого " +
                        "человека должен быть больше нуля и меньше количества участников");
                }
            }

        }

        public LinkedList<int> Peoples
        {
            get
            {
                return _peoples;
            }
        }

        public void FillTheList()
        {
            for (int i = 1; i <= CountOfPeople; i++)
            {
                _peoples.AddLast(i);
            }
        }

        public WeakestLink(int countOfPeople, int droppedOut)
        {
            CountOfPeople = countOfPeople;
            DroppedOut = droppedOut;
            FillTheList();
        }

        public void GameStart()
        {
            LinkedListNode<int> current = Peoples.Find(DroppedOut);
            LinkedListNode<int> next = current?.Next;

            int round = 1;

            while (Peoples.Contains(current.Value) && DroppedOut <= Peoples.Count && !IsGameOver)
            {
                if (current != null)
                {
                    Console.Write($"Раунд {round}: ");
                    foreach (var item in Peoples)
                    {
                        if (item == current.Value)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{current.Value} ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write($"{item} ");
                        }
                    }
                    Console.WriteLine();

                    if (Peoples.Contains(current.Value))
                    {
                        Peoples.Remove(current);
                    }
                    round++;
                }

                if (next != null)
                {
                    current = next;
                }

                if (current != null)
                {
                    next = current?.Next;
                }

                Thread.Sleep(2500);
            }

            if (IsGameOver)
            {
                Console.Write($"{Environment.NewLine}Игра окончена! Победитель с номером ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{Peoples.First.Value}{Environment.NewLine}");
                Console.ResetColor();
            }

            else if (DroppedOut <= Peoples.Count || !Peoples.Contains(current.Value))
            {
                Console.WriteLine($"{Environment.NewLine}Оставшиеся участники:");

                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var item in Peoples)
                {
                    Console.Write($"{item} ");
                }
                Console.ResetColor();

                Console.WriteLine($"{Environment.NewLine}Игра окончена! Невозможно вычеркнуть больше людей!");
            }
        }

        public override string ToString()
        {
            return $"Осталось {Peoples.Count} участников";
        }
    }
}
