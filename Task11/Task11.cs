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
            
            while (true)
                if (sum + 4 <= 100)
                {
                    count++;
                    sum += 4;
                }
                else
                    break;

            Console.WriteLine($"Сумма = {sum}");
            Console.WriteLine($"Количество слагаемых = {count}");
        }
        
    }
}