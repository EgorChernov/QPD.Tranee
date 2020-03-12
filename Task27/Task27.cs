using System;

namespace Task27
{
    public static class Solution
    {
        /// <summary>
        /// 8. Удалить из строки слово "большого"
        /// - Сегодня в зоопарке я видел большого жирафа
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var arg1 = "Сегодня в зоопарке я видел большого жирафа";

            Console.WriteLine(arg1.Replace("большого", ""));
        }
    }
}