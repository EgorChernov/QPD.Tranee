using System;

namespace Task23
{
    public static class Solution
    {
        /// <summary>
        ///     Найти в строке индекс первого вхождения буквы "о"
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Индекс первого вхождения символа \'о\' в строку {0} : {1}",
                "Хорошо в лесу...", Solve("Хорошо в лесу..."));

            Console.WriteLine("Индекс первого вхождения символа \'о\' в строку {0} : {1}",
                "Эх, дороги, пыль да туман", Solve("Эх, дороги, пыль да туман"));

            Console.WriteLine("Индекс первого вхождения символа \'о\' в строку {0} : {1}",
                "Семнадцать вариантов решения", Solve("Семнадцать вариантов решения"));
        }

        private static int Solve(string value) => value.IndexOf("о", StringComparison.CurrentCultureIgnoreCase);
    }
}