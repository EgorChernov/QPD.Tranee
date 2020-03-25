using System;

namespace Task11
{
    internal class Program
    {
        /// <summary>
        ///     11.	Посчитать сумму  6 + 10 + 14 + ..................., последнюю, которая еще не превышает 100. Сколько слагаемых?
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var count = 1;
            var sum = 6;

            while (sum <= 100 - 4)
            {
                count++;
                sum += 4;
            }

            Console.WriteLine($"Сумма = {sum}\nКоличество слагаемых = {count}");
        }

    }
}