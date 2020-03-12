using System;

namespace Task1
{
    public static class Solution
    {
        public static void Main(string[] args)
        {
            int _m;
            var isParseSuccess = false;
            Console.Write("Введите трехзначное число : ");
            do
            {
                string readConsole = Console.ReadLine();
                isParseSuccess = int.TryParse(readConsole, out _m);
                if (isParseSuccess)
                    isParseSuccess = (_m > 99) && (_m < 1000);

                if (!isParseSuccess)
                    Console.Write("Введите трехзначное число : ");
            } while (!isParseSuccess);

            Console.WriteLine("Сумма цифр в {0} = {1}", _m, GetThreeDigitSum(_m));
        }
        private static int GetThreeDigitSum(int value)
        {
            if (value < 100 || value > 999) throw new ArgumentOutOfRangeException(nameof(value));
            var sum = 0;
            while (value > 0)
            {
                sum += value % 10;
                value /= 10;
            }
            return sum;
        }
    }
}