using System;

namespace Task28
{
    public static class Solution
    {
        /// <summary>
        /// Привести предложение "ПрыгаЮщие БуквЫ" к нижнему, а затем к верхнему регистру
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var arg1 = "ПрыгаЮщие БуквЫ";

            Console.WriteLine(arg1.ToLower());
            Console.WriteLine(arg1.ToUpper());
        }
    }
}