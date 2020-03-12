using System;

namespace Task9
{
    public static class Solution
    {
        /// <summary>
        ///     9.	Посчитать сумму 1+2+4+8+16+....., всего 11 слагаемых.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var sum = 0;
            var counter = 1;
            for (var i = 0; i < 11; i++)
            {
                sum += counter;
                counter *= 2;
            }
            
            Console.WriteLine($"Сумма 11 слагаемых = {sum}");
        }
    }
}