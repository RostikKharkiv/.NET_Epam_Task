using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class Figure { }
    public struct Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public double Length(Point point)
            => Math.Sqrt((point.X - this.X) * (point.X - this.X) 
                + (point.Y - this.Y) * (point.Y - this.Y));

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point point)
        {
            return (this.X == point.X) && (this.Y == point.Y);
        }

        public override string ToString()
        {
            return $"({X}; {Y})";
        }
    } 

    public class Side : Figure
    {
        public Point FirstPoint { get; private set; }
        public Point SecondPoint { get; private set; }
        public double Length => FirstPoint.Length(SecondPoint);

        public double AlphaAngle(Side side)
        {
            if (this.SecondPoint.Equals(side.FirstPoint))
            {
                double numerator = (this.FirstPoint.X - this.SecondPoint.X)
                    * (side.SecondPoint.X - side.FirstPoint.X)
                    + (this.FirstPoint.Y - this.SecondPoint.Y)
                    * (side.SecondPoint.Y - side.FirstPoint.Y);
                double denominator = Math.Abs(this.SecondPoint.Length(FirstPoint))
                    * Math.Abs(side.Length);
                return Math.Acos(numerator / denominator);
            }
            else
                throw new Exception();
        }
        public Side(Point first, Point second)
        {
            FirstPoint = first;
            SecondPoint = second;
        }

        public override string ToString()
        {
            return $"Side: ({FirstPoint}; {SecondPoint})";
        }
    }
    public class Circle : Figure
    {
        private double _radius;
        public Point Center { get; private set; }
        public double Length => 2 * Math.PI * Radius;
        public double Square => Math.PI * Radius * Radius;
        public double Radius
        {
            get
            {
                return _radius;
            }
            private set
            {
                if (value > 0)
                    _radius = value;
                else 
                    throw new Exception();
            }
        }

        public Circle(double x, double y, double radius)
        {
            Center = new Point(x, y);
            Radius = radius;
        }

        public Circle(Point point, double radius)
        {
            Center = point;
            Radius = radius;
        }

        public override string ToString()
        {
            return $"Circle: (Center: {Center}; Radius: {Radius})";
        }
    }

    public class Ring : Figure
    {
        public Circle Outer { get; private set; }
        public Circle Inner { get; private set; }
        public double Length => Outer.Length + Inner.Length;
        public double Square => Math.PI * (Outer.Square - Inner.Square);

        public Ring(double x, double y, double outerRadius, double innerRadius)
        {
            Outer = new Circle(x, y, outerRadius);
            Inner = new Circle(x, y, innerRadius);
        }

        public Ring(Point point, double outerRadius, double innerRadius)
        {
            Outer = new Circle(point, outerRadius);
            Inner = new Circle(point, innerRadius);
        }

        public override string ToString()
        {
            return $"Ring: (Center: {Outer.Center}; " +
                $"OuterRadius: {Outer.Radius}; " +
                $"InnerRadius: {Inner.Radius})";
        }
    }

    public class Triangle : Figure
    {
        public Point FirstPoint { get; private set; }
        public Point SecondPoint { get; private set; }
        public Point ThirdPoint { get; private set; }

        public Side FirstSide { get; private set; }
        public Side SecondSide { get; private set; }
        public Side ThirdSide { get; private set; }

        public virtual double Perimeter => FirstSide.Length + SecondSide.Length + ThirdSide.Length;

        public virtual double Square => Math.Sqrt((Perimeter / 2) 
            * ((Perimeter / 2) - FirstSide.Length) 
            * ((Perimeter / 2) - SecondSide.Length) 
            * ((Perimeter / 2) - ThirdSide.Length));
        public Triangle(Point first, Point second, Point third)
        {
            FirstPoint = first;
            SecondPoint = second;
            ThirdPoint = third;

            FirstSide = new Side(FirstPoint, SecondPoint);
            SecondSide = new Side(SecondPoint, ThirdPoint);
            ThirdSide = new Side(ThirdPoint, FirstPoint);
        }

        public override string ToString()
        {
            return $"Triangle: ({FirstPoint}; {SecondPoint}; {ThirdPoint})";
        }
    }

    public class Rectangle : Triangle
    {
        public Point FourthPoint { get; private set; }
        public Side FourthSide { get; private set; }
        public Side DiagonalFirst { get; private set; }
        public Side DiagonalSecond { get; private set; }

        public override double Perimeter => FirstSide.Length + SecondSide.Length
            + ThirdSide.Length + FourthSide.Length;
        public override double Square => 0.5 * DiagonalFirst.AlphaAngle(DiagonalSecond)
            * DiagonalFirst.Length * DiagonalSecond.Length;

        public Rectangle(Point first, Point second, Point third, Point fourth) : base(first, second, third)
        {
            FourthPoint = fourth;
            FourthSide = new Side(FourthPoint, FirstPoint);

            DiagonalFirst = new Side(FirstPoint, ThirdPoint);
            DiagonalSecond = new Side(SecondPoint, FourthPoint);
        }

        public override string ToString()
        {
            return $"Rectangle: ({FirstPoint}; {SecondPoint}; {ThirdPoint}; {FourthPoint})";
        }
    }

    public class SquareFigure : Rectangle
    {
        public override double Perimeter => 4 * FirstSide.Length;
        public override double Square => FirstSide.Length * FirstSide.Length;

        public SquareFigure(Point first, Point second, Point third, Point fourth) : base(first, second, third, fourth)
        {
            if (!(FirstSide.Length == SecondSide.Length 
                && SecondSide.Length == ThirdSide.Length 
                && ThirdSide.Length == FourthSide.Length
                && FourthSide.Length == FirstSide.Length))
            {
                throw new Exception();
            }
        }

        public override string ToString()
        {
            return $"SquareFigure: ({FirstPoint}; {SecondPoint}; {ThirdPoint}; {FourthPoint})";
        }
    }
}
