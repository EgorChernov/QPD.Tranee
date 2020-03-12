using System;

namespace Task10
{
    public static class Solution
    {
        /// <summary>
        ///     10.	Посчитать сумму  6 + 10 + 14 + ..................., Остановиться, когда сумма превысит 100. Сколько слагаемых?
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var count = 1;
            var sum = 6;
            do
            {
                count++;
                sum += 4;
            } while (sum <= 100);
            
            Console.WriteLine($"Сумма = {sum}");
            Console.WriteLine($"Количество слагаемых = {count}");
        }
    }
}