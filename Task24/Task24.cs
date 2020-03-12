using System;

namespace Task24
{

    public static class Solution
    {
        /// <summary>
        ///     Найти в строке индекс последнего вхождения буквы "у"
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Индекс последнего вхождения символа \'у\' в строку {0} : {1}",
                "Где такое интересное место?", Solve("Где такое интересное место?"));

            Console.WriteLine("Индекс последнего вхождения символа \'у\' в строку {0} : {1}",
                "У меня дома есть ноутбук.", Solve("У меня дома есть ноутбук."));

            Console.WriteLine("Индекс последнего вхождения символа \'у\' в строку {0} : {1}",
                "Винтажный стул", Solve("Винтажный стул"));

            Console.WriteLine("Индекс последнего вхождения символа \'у\' в строку {0} : {1}",
                "", Solve(""));
        }

        private static int Solve(string value) => value.LastIndexOf("у", StringComparison.CurrentCultureIgnoreCase);
    }
}