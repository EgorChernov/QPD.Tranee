using System;
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
            var isParseSuccess = false;
            int n;
            Console.Write("n = : ");
            do
            {
                var readConsole = Console.ReadLine();
                isParseSuccess = int.TryParse(readConsole, out n);
                if (isParseSuccess)
                    isParseSuccess = n > 0;
            
                if (!isParseSuccess)
                    Console.Write("n = : ");
            } while (!isParseSuccess);
            WriteLine(Solver(n));
        }

        private static int Solver(int value)
        {
            if (value <= 0)
                throw new ArgumentException(nameof(value));
            if (value == 1)
                return 1;
            if (value == 2)
                return 2;

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