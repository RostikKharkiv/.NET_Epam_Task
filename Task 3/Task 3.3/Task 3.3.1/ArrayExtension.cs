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

        public static float[] DoWithElements(this float[] array, Func<float, float> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }

            return array;
        }

        public static double[] DoWithElements(this double[] array, Func<double, double> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }

            return array;
        }

        public static short[] DoWithElements(this short[] array, Func<short, short> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }

            return array;
        }

        public static byte[] DoWithElements(this byte[] array, Func<byte, byte> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }

            return array;
        }

        public static decimal[] DoWithElements(this decimal[] array, Func<decimal, decimal> func)
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
                throw new InvalidOperationException();
            }

            var res = array.GroupBy(x => x).OrderByDescending(x => x.Count()).FirstOrDefault();
            
            return res.Key;
        }

        public static float Frequent(this float[] array)
        {
            if (array is null || array.Length == 0)
            {
                throw new InvalidOperationException();
            }

            var res = array.GroupBy(x => x).OrderByDescending(x => x.Count()).FirstOrDefault();

            return res.Key;
        }

        public static double Frequent(this double[] array)
        {
            if (array is null || array.Length == 0)
            {
                throw new InvalidOperationException();
            }

            var res = array.GroupBy(x => x).OrderByDescending(x => x.Count()).FirstOrDefault();

            return res.Key;
        }

        public static short Frequent(this short[] array)
        {
            if (array is null || array.Length == 0)
            {
                throw new InvalidOperationException();
            }

            var res = array.GroupBy(x => x).OrderByDescending(x => x.Count()).FirstOrDefault();

            return res.Key;
        }

        public static byte Frequent(this byte[] array)
        {
            if (array is null || array.Length == 0)
            {
                throw new InvalidOperationException();
            }

            var res = array.GroupBy(x => x).OrderByDescending(x => x.Count()).FirstOrDefault();

            return res.Key;
        }

        public static decimal Frequent(this decimal[] array)
        {
            if (array is null || array.Length == 0)
            {
                throw new InvalidOperationException();
            }

            var res = array.GroupBy(x => x).OrderByDescending(x => x.Count()).FirstOrDefault();

            return res.Key;
        }
    }
}
