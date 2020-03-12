using System;

namespace Task25
{
    public static class Solution
    {
        /// <summary>
        ///     6. Вставить в строку другую строку
        ///     - Какой ... день
        ///     - замечательный
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var arg1 = "Какой  день";
            var arg2 = "замечательный";
            Console.WriteLine(arg1.Insert(arg1.IndexOf(' ') + 1, arg2));
        }
    }
}