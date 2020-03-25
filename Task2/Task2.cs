using System;
using Utils;

namespace Task2
{
    public static class Solution
    {
        /// <summary>
        /// 2.	Вводить числа, пока не будет введен ноль. Вывести число с максимальной суммой цифр в нем
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int number;
            var maxNumber = int.MinValue;
            var maxSum = int.MinValue;
            do
            {
                number = Util.GetNumberFromConsole();

                if (Util.GetSumDigitInNumber(number) < maxSum) continue;
                maxNumber = number;
                maxSum = Util.GetSumDigitInNumber(number);
            } while (number != 0);

            Console.WriteLine($"Максимальная сумма в числе {maxNumber}  =  {maxSum}");
        }
    }
}