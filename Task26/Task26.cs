using System;

namespace Task26
{
    public static class Solution
    {
        /// <summary>
        /// 7. Заменить в строке слово "магазин" на "парк"
        /// - Привет, я иду в магазин
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var arg1 = "Привет, я иду в магазин";

            Console.WriteLine(arg1.Replace("магазин", "парк"));
        }
    }
}