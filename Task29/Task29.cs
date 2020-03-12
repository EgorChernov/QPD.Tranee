using System;

namespace Task29
{
    public static class Solution
    {
        /// <summary>
        /// Разделить строку на элементы массива
        /// - Первый рабочий день прошел на ура
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var arg1 = "Первый рабочий день прошел на ура";
            var array = arg1.Split(' ');
            foreach (var value in array)
                Console.WriteLine(value);
        }
    }
}