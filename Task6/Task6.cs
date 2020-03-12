using System;

namespace Task6
{
    public static class Solver
    {
        /// <summary>
        /// 6.	Посчитать сумму ряда
        ///    а) 1 + 2 + 3 + .................. + 50
        ///    б)  2+4+6+8+10 + .....  +50
        ///    в)  1+3+5+7+9....
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine($"Сумма ряда 1+2+3+..................+ 50 = {SumA()}");
            Console.WriteLine($"Сумма ряда 2+4+6+8+10+.....+50 = {SumB()}");
            Console.WriteLine($"Сумма ряда 1+3+5+7+9.... = {SumC()}");
        }

        private static int SumA()
        {
            var sum = 0;
            for (var i = 1; i <= 50; i++)
                sum += i;
            return sum;
        }

        private static int SumB()
        {
            var sum = 0;
            for (var i = 2; i <= 50; i += 2)
                sum += i;

            return sum;
        }

        private static int SumC()
        {
            var sum = 0;
            for (var i = 1; i <= 50; i += 2)
                sum += i;

            return sum;
        }
    }
}