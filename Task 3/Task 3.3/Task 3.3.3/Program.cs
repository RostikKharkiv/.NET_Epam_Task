﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3._3._3 // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Pizzeria pizzeria = new Pizzeria();

            Console.WriteLine(pizzeria.Menu());
        }
    }
}