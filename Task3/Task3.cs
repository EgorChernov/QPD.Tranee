using System;

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
            int n;
            var isParseSuccess = false;

            Console.Write("n = : ");
            do
            {
                var readConsole = Console.ReadLine();
                isParseSuccess = int.TryParse(readConsole, out n);
                if (isParseSuccess)
                    isParseSuccess = n > 3;

                if (!isParseSuccess)
                    Console.Write("n = : ");
            } while (!isParseSuccess);

            Console.WriteLine($"Сумма трех первых нечетных  =  {Solver(n)}");
        }

        private static int Solver(int length)
        {
            if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));

            //Только для получения данных
            var array = GetRandomArray(length);
            var firstValue = int.MinValue;
            var secondValue = int.MinValue;
            var thirdValue = int.MinValue;

            foreach (var value in array)
            {
                if (value % 2 == 0) continue;

                if (firstValue == int.MinValue)
                    firstValue = value;
                else if (secondValue == int.MinValue)
                    secondValue = value;
                else if (thirdValue == int.MinValue)
                    thirdValue = value;
                else
                    return firstValue + secondValue + thirdValue;
            }
            
            Console.WriteLine("В введенной последовательнасти нет трех нечетных");
            return -1;
        }


        private static int[] GetRandomArray(int length)
        {
            if (length < 1) throw new ArgumentOutOfRangeException(nameof(length));
            var array = new int[length];
            var random = new Random();
            for (var i = 0; i < array.Length; i++) array[i] = random.Next(100);
            foreach (var value in array) Console.Write(value + " ");
            Console.WriteLine();
            return array;
        }

    }
}