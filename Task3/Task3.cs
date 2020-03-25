using System;
using Utils;

namespace Task3
{
    public static class Solution
    {
        /// <summary>
        ///     3.	Ввести n чисел (n задается пользователем). Посчитать сумму трех первых нечетных.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int number;
 
            do
            {
                number = Util.GetNumberFromConsole();
            } while (number <= 0);

            var result = GetSumThreeFirstOdd(number);
            Console.WriteLine(result != -1
                ? $"Сумма трех первых нечетных  =  {result}"
                : "В введенной последовательности нет трех нечетных");
        }

        private static int GetSumThreeFirstOdd(int length)
        {
            var sum = 0;
            var count = 0;
            
            for (var i = 0; i < length; i++)
            {
                //3 odd numbers were entered already
                //So waiting until user entered all numbers
                if (count == 3)
                    continue;

                var nextNumber = Util.GetNumberFromConsole();
                
                //If number is even - do nothing
                if (nextNumber % 2 == 0) continue;

                sum += nextNumber;
                count++;
            }

            return count == 3 ? sum : -1;
        }

    }
}