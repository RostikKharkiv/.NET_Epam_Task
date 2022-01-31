using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_2._1._2
{
    public class Menu
    {
        private static List<User> users = new List<User>();
        private static User user;

        private static Point InputPoint(string name)
        {
            double x;
            double y;
            Console.Write($"{Environment.NewLine}{name} точка:" +
                $"{Environment.NewLine}X: ");
            //double x = double.Parse(Console.ReadLine());
            double.TryParse(Console.ReadLine(), out x);
            Console.Write("Y: ");
            double.TryParse(Console.ReadLine(), out y);
            //double y = double.Parse(Console.ReadLine());
            return new Point(x, y);
        }

        public static void SignIn()
        {
            Console.Clear();
            Console.Write("Введите своё имя: ");
            string name = Console.ReadLine();
            if (users.Contains(name))
                user = users.Find(x => x.Name == name);
            else
            {
                user = name;
                users.Add(user);
            }
            Console.Clear();
            ShowMenu();
        }

        public static void ShowMenu()
        {
            Console.WriteLine($"{user}, выберите действие:" +
                $"{Environment.NewLine}1)Добавить фигуру" +
                $"{Environment.NewLine}2)Показать все фигуры" +
                $"{Environment.NewLine}3)Выбрать фигуру по id" +
                $"{Environment.NewLine}4)Удалить все фигуры" +
                $"{Environment.NewLine}5)Сменить пользователя" +
                $"{Environment.NewLine}0)Выйти из программы");

            string choose = Console.ReadLine();

            switch (choose)
            {
                case "1":
                    {
                        Console.WriteLine($"Выберите фигуру для создания:" +
                    $"{Environment.NewLine}1)Создать линию" +
                    $"{Environment.NewLine}2)Создать круг" +
                    $"{Environment.NewLine}3)Создать кольцо" +
                    $"{Environment.NewLine}4)Создать треугольник" +
                    $"{Environment.NewLine}5)Создать четырёхугольник" +
                    $"{Environment.NewLine}6)Создать квадрат");

                        string chooseFigure = Console.ReadLine();
                        Point p1;
                        Point p2;
                        Point p3;
                        Point p4;
                        double radius;
                        double radius2;


                        switch (chooseFigure)
                        {
                            case "1":
                                p1 = InputPoint("Первая");
                                p2 = InputPoint("Вторая");
                                try
                                {
                                    Side side = new Side(p1, p2);
                                    user.Figures.Add(side);
                                    Console.WriteLine($"Создана линия:{Environment.NewLine}{side}");
                                    Console.WriteLine();
                                    ShowMenu();
                                }
                                catch
                                {
                                    throw new Exception();
                                }
                                break;
                            case "2":
                                p1 = InputPoint("Центральная");
                                Console.Write("Введите радиус: ");
                                //radius = double.Parse(Console.ReadLine());
                                double.TryParse(Console.ReadLine(), out radius);
                                try
                                {
                                    Circle circle = new Circle(p1, radius);
                                    user.Figures.Add(circle);
                                    Console.WriteLine($"Создан круг:{Environment.NewLine}{circle}");
                                    Console.WriteLine();
                                    ShowMenu();
                                }
                                catch
                                {
                                    throw new Exception();
                                }
                                break;
                            case "3":
                                p1 = InputPoint("Центральная");
                                Console.Write("Введите внешний радиус: ");
                                //radius = double.Parse(Console.ReadLine());
                                double.TryParse(Console.ReadLine(), out radius);
                                Console.Write("Введите внутренний радиус: ");
                                //radius2 = double.Parse(Console.ReadLine());
                                double.TryParse(Console.ReadLine(), out radius2);
                                try
                                {
                                    Ring ring = new Ring(p1, radius, radius2);
                                    user.Figures.Add(ring);
                                    Console.WriteLine($"Создано кольцо:{Environment.NewLine}{ring}");
                                    Console.WriteLine();
                                    ShowMenu();
                                }
                                catch
                                {
                                    throw new Exception();
                                }
                                break;
                            case "4":
                                p1 = InputPoint("Первая");
                                p2 = InputPoint("Вторая");
                                p3 = InputPoint("Третья");
                                try
                                {
                                    Triangle triangle = new Triangle(p1, p2, p3);
                                    user.Figures.Add(triangle);
                                    Console.WriteLine($"Создан треугольник:{Environment.NewLine}{triangle}");
                                    Console.WriteLine();
                                    ShowMenu();
                                }
                                catch
                                {
                                    throw new Exception();
                                }
                                break;
                            case "5":
                                p1 = InputPoint("Первая");
                                p2 = InputPoint("Вторая");
                                p3 = InputPoint("Третья");
                                p4 = InputPoint("Четвёртая");
                                try
                                {
                                    Rectangle rectangle = new Rectangle(p1, p2, p3, p4);
                                    user.Figures.Add(rectangle);
                                    Console.WriteLine($"Создан четырёхугольник:{Environment.NewLine}{rectangle}");
                                    Console.WriteLine();
                                    ShowMenu();
                                }
                                catch
                                {
                                    throw new Exception();
                                }
                                break;
                            case "6":
                                p1 = InputPoint("Первая");
                                p2 = InputPoint("Вторая");
                                p3 = InputPoint("Третья");
                                p4 = InputPoint("Четвёртая");
                                try
                                {
                                    SquareFigure squareFigure = new SquareFigure(p1, p2, p3, p4);
                                    user.Figures.Add(squareFigure);
                                    Console.WriteLine($"Создан квадрат:{Environment.NewLine}{squareFigure}");
                                    Console.WriteLine();
                                    ShowMenu();
                                }
                                catch
                                {
                                    throw new Exception();
                                }
                                break;
                            default:
                                ShowMenu();
                                break;
                        }
                        break;
                    }
                case "2":
                    int i = 0;
                    foreach (var item in user.Figures)
                    {
                        Console.WriteLine($"Id - {i} {item}");
                        i++;
                    }
                    Console.WriteLine();
                    ShowMenu();
                    break;
                case "3":
                    Console.Write("Введите id фигуры: ");
                    int id;
                    int.TryParse(Console.ReadLine(), out id);
                    if (user.Figures.Contains(user.Figures.ElementAt(id)))
                    {
                        Figure figure = user.Figures.ElementAt(id);

                        if (figure is Side)
                        {
                            Side side = figure as Side;
                            Console.WriteLine($"{side}" +
                                $"{Environment.NewLine}Длина линии: {side.Length}");
                        }
                        else if (figure is Circle)
                        {
                            Circle circle = figure as Circle;
                            Console.WriteLine($"{circle}" +
                                $"{Environment.NewLine}Длина круга: {circle.Length}" +
                                $"{Environment.NewLine}Площадь круга: {circle.Square}");
                        }
                        else if (figure is Ring)
                        {
                            Ring ring = figure as Ring;
                            Console.WriteLine($"{ring}" +
                                $"{Environment.NewLine}Длина кольца: {ring.Length}" +
                                $"{Environment.NewLine}Площадь кольца: {ring.Square}");
                        }
                        else if (figure is Triangle)
                        {
                            Triangle triangle = figure as Triangle;
                            Console.WriteLine($"{triangle}" +
                                $"{Environment.NewLine}Периметр треугольника: {triangle.Perimeter}" +
                                $"{Environment.NewLine}Площадь треугольника: {triangle.Square}");
                        }
                        else if (figure is Rectangle)
                        {
                            Rectangle rectangle = figure as Rectangle;
                            Console.WriteLine($"{rectangle}" +
                                $"{Environment.NewLine}Периметр четырёхугольника: {rectangle.Perimeter}" +
                                $"{Environment.NewLine}Площадь четырёхугольника: {rectangle.Square}");
                        }
                        else if (figure is SquareFigure)
                        {
                            SquareFigure squareFigure = figure as SquareFigure;
                            Console.WriteLine($"{squareFigure}" +
                                $"{Environment.NewLine}Периметр квадрата: {squareFigure.Perimeter}" +
                                $"{Environment.NewLine}Площадь квадрата: {squareFigure.Square}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Фигуры с таким id не существует");
                    }
                    ShowMenu();
                    break;
                case "4":
                    user.Figures.Clear();
                    Console.WriteLine("Все фигуры были удалены");
                    Console.WriteLine();
                    ShowMenu();
                    break;
                case "5":
                    SignIn();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Неверный параметр выбора");
                    Console.WriteLine();
                    ShowMenu();
                    break;

            }
        }
    }
}
