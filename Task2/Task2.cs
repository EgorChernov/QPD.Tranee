using System;

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
            int _m;
            var isParseSuccess = false;
            var maxnumber = Int32.MinValue;
            var maxsum = Int32.MinValue;

            Console.Write("Ввести числа : ");
            do
            {
                var readConsole = Console.ReadLine();
                isParseSuccess = int.TryParse(readConsole, out _m);
                
                if (isParseSuccess && _m != 0)
                {
                    var currentsum = GetSum(_m);
                    if (currentsum > maxsum)
                    {
                        maxsum = currentsum;
                        maxnumber = _m;
                    }
                }
            } while (_m != 0);
            
            Console.WriteLine($"Максимальная сумма в числе {maxnumber}  =  {maxsum}");

        }
        private static int GetSum(int value)
        {
            if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
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