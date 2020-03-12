using System;

namespace Task20
{
    public static class Solution
    {
        /// <summary>
        ///     1. Даны переменные
        ///     hello = "Привет!"
        ///     name = "Меня зовут ..."
        ///     age = "Мне ... лет"
        ///     Оперируя переменными составить полноценное предложение всеми возможными способами (форматирование, интерполяция)
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var hello = "Привет!";
            var name = "Меня зовут ";
            var age = "Мне  лет";

            var testName = "Иван";
            var testAge = 98;

            Console.WriteLine($"{hello} {name + testName}. {age.Insert(age.IndexOf(' ') + 1, testAge.ToString())}.");

            Console.WriteLine("{0} {1}. {2}.", hello, name + testName,
                age.Insert(age.IndexOf(' ') + 1, testAge.ToString()));
        }
    }
}