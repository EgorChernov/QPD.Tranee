using System;
using Utils;
using static System.Console;

namespace Task_12
{
    public static class Solution
    {
        /// <summary>
        /// 12.	Посчитать сумму первых n чисел Фиббоначи: 1 + 1 + 2 + 3 + 5 + 8 +  13 + … n задается пользователем
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int n;
            do
            {
                n = Util.GetNumberFromConsole();
            } while (n < 0);
        }

        private static int Solver(int value)
        {
            //if value = 1, then return 1
            //if value = 2, then return 1+1=2

            if (value < 3) return value;

            int first = 1, second = 1, sum = 2;
            for (var i = 3; i <= value; i++)
            {
                var third = first + second;

                sum += third;
                first = second;
                second = third;
            }

            return sum;
        }
    }
}