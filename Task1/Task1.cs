using System;
using Utils;

namespace Task1
{
    public static class Solution
    {
        public static void Main(string[] args)
        {  
            int number;

            do
            {
                number = Util.GetNumberFromConsole();
            }
            while (!IsThreeDigitNumber(number));
         
            
            Console.WriteLine($"Сумма цифр в {number} = {Util.GetSumDigitInNumber(number)}");
        }

        private static bool IsThreeDigitNumber(int number) => Math.Abs(number) > 99 && Math.Abs(number) < 1000;
    }
}