using System;

namespace Task22
{
    public static class Solution
    {
        /// <summary>
        ///     Сравнить две строки и вывести результат сравнения
        ///     - "привет" и "здравствуйте"
        ///     - "двацдать" и "двенадцать"
        ///     - "синус" и "синусоида"
        ///     - "14" и "81"
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Результат сравнения {0} и {1} = {2}", "привет", "здравствуйте",
                string.Compare("привет", "здравствуйте"));

            Console.WriteLine("Результат сравнения {0} и {1} = {2}", "двацдать", "двенадцать",
                string.Compare("двацдать", "двенадцать"));

            Console.WriteLine("Результат сравнения {0} и {1} = {2}", "синус", "здравствуйте",
                string.Compare("синус", "синусоида"));

            Console.WriteLine("Результат сравнения {0} и {1} = {2}", "14", "81",
                string.Compare("14", "81"));
        }
    }
}