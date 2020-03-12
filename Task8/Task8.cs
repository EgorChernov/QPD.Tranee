using System;

namespace Task8
{
    public static class Solution
    {
        /// <summary>
        ///     8.	Посчитать сумму  6 + 10 + 14 + ...................   , всего 10 слагаемых.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var sum = 6;
            //На 10 слагаемых 9 сложений
            for (var i = 1; i < 10; i++)
                sum += 4;
            
            Console.WriteLine($"Сумма 10 слагаемых = {sum}");
        }
    }
}