using System;

namespace Task21
{
    public static class Solution
    {
        /// <summary>
        ///     2. Дан массив строк ["apple", "banana", "orange", "kiwi", "mango"]
        ///     - Вывести все значения через ", "
        ///     - Вывести все значения построчно
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            string[] array = {"apple", "banana", "orange", "kiwi", "mango"};

            Console.WriteLine("Вывести все значения через \", \"");
            for (var i = 0; i < array.Length; i++)
                Console.Write($"{array[i]}{(i == array.Length - 1 ? "\n" : ", ")}");

            Console.WriteLine("Вывести все значения построчно");
            foreach (var value in array)
                Console.WriteLine(value);
        }
    }
}