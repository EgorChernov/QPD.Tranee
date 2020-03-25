using System;
using Utils;

namespace Task4
{
    public static class Solution
    {
        /// <summary>
        ///     4.	Ввести n чисел (n задается пользователем). Посчитать сумму трех последних нечетных.
        /// </summary>
        /// <param name="args"></param>
        // public static void Main(string[] args)
        // {
        //     int n;
        //     var isParseSuccess = false;
        //
        //     Console.Write("n = : ");
        //     do
        //     {
        //         var readConsole = Console.ReadLine();
        //         isParseSuccess = int.TryParse(readConsole, out n);
        //         if (isParseSuccess)
        //             isParseSuccess = n > 3;
        //
        //         if (!isParseSuccess)
        //             Console.Write("n = : ");
        //     } while (!isParseSuccess);
        //
        //     Console.WriteLine($"Сумма трех последних нечетных  =  {Solver(n)}");
        // }
        //
        // private static int Solver(int length)
        // {
        //     if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));
        //
        //     //Только для получения данных
        //     var array = GetRandomArray(length);
        //     var firstValue = int.MinValue;
        //     var secondValue = int.MinValue;
        //     var thirdValue = int.MinValue;
        //
        //     foreach (var value in array)
        //     {
        //         if (value % 2 == 0) continue;
        //
        //         thirdValue = secondValue;
        //         secondValue = firstValue;
        //         firstValue = value;
        //     }
        //     
        //     if ((firstValue != int.MinValue) && (secondValue != int.MinValue) && (thirdValue != int.MinValue))
        //         return firstValue + secondValue + thirdValue;
        //     Console.WriteLine("В введенной последовательнасти нет трех нечетных");
        //     return -1;
        // }
        //
        //
        // private static int[] GetRandomArray(int length)
        // {
        //     if (length < 1) throw new ArgumentOutOfRangeException(nameof(length));
        //     var array = new int[length];
        //     var random = new Random();
        //     for (var i = 0; i < array.Length; i++) array[i] = random.Next(100);
        //     foreach (var value in array) Console.Write(value + " ");
        //     Console.WriteLine();
        //     return array;
        // }
        public static void Main(string[] args)
        {
            int number;

            do
            {
                number = Util.GetNumberFromConsole();
            } while (number <= 0);

            var result = GetSumThreeLastOdd(number);
            Console.WriteLine(result != -1
                ? $"Сумма трех первых нечетных  =  {result}"
                : "В введенной последовательнасти нет трех нечетных");
        }

        private static int GetSumThreeLastOdd(int length)
        {
            var firstValue = int.MinValue;
            var secondValue = int.MinValue;
            var thirdValue = int.MinValue;

            var count = 0;

            for (var i = 0; i < length; i++)
            {
                var nextNumber = Util.GetNumberFromConsole();

                //If number is even - do nothing
                if (nextNumber % 2 == 0) continue;

                if (count < 3)
                    count++;

                //define queue of last 3 even number
                //if this number is even, push it to queue and drop first value
                thirdValue = secondValue;
                secondValue = firstValue;
                firstValue = nextNumber;
            }

            var sum = firstValue + secondValue + thirdValue;
            return count == 3 ? sum : -1;
        }
    }
}