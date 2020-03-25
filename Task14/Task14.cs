using System;
using Utils;

namespace Task14
{
    public static class Solution
    {
        public static void Main(string[] args)
        {
            int length;
            do
            {
                length = Util.GetNumberFromConsole();
            } while (length < 0);

            var array = Util.GetRandomArray(length);
            Util.WriteLineArray(array);

            Solve(array, out var isAsc, out var isDesc);
            Console.WriteLine($"Массив {(isAsc ? "" : "не")}упорядочен по возрастанию");
            Console.WriteLine($"Массив {(isDesc ? "" : "не")}упорядочен по убыванию");
        }

        private static void Solve(int[] array, out bool isAsc, out bool isDesc)
        {
            //FIXME:
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(array));

            isAsc = true;
            isDesc = true;

            for (var i = 1; i < array.Length; i++)
            {
                if (isAsc)
                    isAsc = array[i - 1] <= array[i];
                if (isDesc)
                    isDesc = array[i - 1] >= array[i];

                //true only if both are false
                if (!isAsc && !isDesc)
                    break;
            }
        }
    }
}