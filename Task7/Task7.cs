using System;

namespace Task7
{
    public static class Solution
    {
        /// <summary>
        ///     7.	Посчитать сумму  6 + 10 + 14 + ................... + 46. Сколько слагаемых?
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            int sum = 0, count = 0;

            for (var i = 6; i <= 46; i += 4)
            {
                sum += i;
                count++;
            }

            Console.WriteLine("Сумма ряда = {0}\nКоличество слагаемых = {1}", sum, count);
        }
    }
}