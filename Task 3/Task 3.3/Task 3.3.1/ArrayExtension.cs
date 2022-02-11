using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3._1
{
    public static class ArrayExtension
    {
        public static int[] DoWithElements(this int[] array, Func<int, int> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }

            return array;
        }

        // сумма и среднее значение уже реализованы же

        public static int Frequent(this int[] array)
        {
            if (array is null || array.Length == 0)
            {
                // если массив пустой то получим NullReferenceException
            }

            var res = array.GroupBy(x => x).OrderByDescending(x => x.Count()).FirstOrDefault();
            
            return res.Key;
        }
    }
}
