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
        public static GameObject[,] Field { get; private set; } = new GameObject[30, 20];

        public static void GenerateField()
        {
            for (int i = 0; i < Field.GetUpperBound(1); i++)
            {
                for (int j = 0; j < Field.GetUpperBound(2); j++)
                {
                    if ((i == 0 || i == Field.GetUpperBound(1) - 1) 
                        || (j == 0 || j == Field.GetUpperBound(1) - 2))
                    {
                        Field[i, j] = new Border();
                    }
                }
            }
        }
    }
}
