using System;
using Microsoft.VisualBasic.CompilerServices;
using Utils;

namespace Task19
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            int length;
            do
            {
                length = Util.GetNumberFromConsole();
            } while (length <= 0);

            int shift;
            do
            {
                shift = Util.GetNumberFromConsole();
            } while (!(shift < length && shift >= 0));

            var array = Util.GetRandomArray(length);
            Util.WriteLineArray(array);

            var rightShift = Solve(array, shift);
            Util.WriteLineArray(rightShift);

            var leftShift = Solve(array, shift, false);
            Util.WriteLineArray(leftShift);
        }

        private static int[] Solve(int[] array, int shift, bool isRigthShift = true)
        {

            for (var i = 0; i < shift; i++)
            {
                var temp = isRigthShift ? array[^1] : array[0];
                if (isRigthShift)
                {
                    for (var j = array.Length - 1; j > 0; j--)
                    {
                        array[j] = array[j - 1];
                    }

                    array[0] = temp;
                }
                else
                {
                    for (var j = 0; j < array.Length - 1; j++)
                    {
                        array[j] = array[j + 1];
                    }

                    array[^1] = temp;
                }
            }

            return array;

        }
    }
}