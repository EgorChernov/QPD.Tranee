using System;
using Utils;

namespace Task13
{
    public static class Solution
    {
        /// <summary>
        ///     1.	Ввести n целых чисел (n задается пользователем).
        ///     Какая цифра встречается чаще других? Если таких цифр несколько – вывести ту из них,
        ///     которая обозначает наибольшее число, а также сколько раз она встретилась.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int length;
            do
            {
                length = Util.GetNumberFromConsole();
            } while (length < 0);
                 
            var array = Util.GetRandomArray(length);
            Util.WriteLineArray(array);
            
            
            Solve(array, out var digit, out var count);
            Console.WriteLine("digit = {0}, count = {1}", digit, count);
        }

        private static void Solve(int[] array, out int digit, out int count)
        {
         //Массив распределения цифр в числах элементов массива
            var distribution = GetDistributionArray(array);
        
            digit = 0;
            count = distribution[0];

            for (var i = 1; i < distribution.Length; i++)
                if (distribution[i] >= count)
                {
                    count = distribution[i];
                    digit = i;
                }
        }

        /// <summary>
        /// Получить распределение цифр в массике
        /// </summary>
        /// <param name="array">Массив чисел</param>
        /// <returns>Масссив количесва цифр в массиве</returns>
        private static int[] GetDistributionArray(int[] array)
        {
            var distribution = new int[10];
            foreach (var number in array)
            {
                var temp = number < 0 ? -number : number;
                
                while (temp > 0)
                {
                    distribution[temp % 10]++;
                    temp /= 10;
                }
            }

            return distribution;
        }
    }
}