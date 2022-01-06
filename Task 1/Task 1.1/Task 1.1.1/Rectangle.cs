using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1._1._1
{
    class Rectangle
    {
        private int firstSide;

        private int secondSide;
        public int FirstSide
        {
            get
            {
                return firstSide;
            }
            set
            {
                if (value > 0)
                    firstSide = value;
                else if (value < 1)
                    Console.WriteLine("Invalid value");
            }
        }

        public int SecondSide
        {
            get
            {
                return secondSide;
            }
            set
            {
                if (value > 0)
                    secondSide = value;
                else if (value < 0 || value == 0)
                    Console.WriteLine("Invalid value");
            }
        }

        public double Square => FirstSide * SecondSide;
    }
}
