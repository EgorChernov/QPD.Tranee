using System;

namespace Task14
{
    public static class Solution
    {
        public static void Main(string[] args)
        {
                 var isParseSuccess = false;
                 int length;
                 Console.Write("Введите длину массива : ");
                 do
                 {
                     var readConsole = Console.ReadLine();
                     isParseSuccess = int.TryParse(readConsole, out length);
                     if (isParseSuccess)
                         isParseSuccess = length > 0;
            
                     if (!isParseSuccess)
                         Console.Write("Введите длину массива : ");
                 } while (!isParseSuccess);

                 var array = GetRandomArray(length);
                 Solve(array, out var isAsc, out var isDesc);
            Console.WriteLine($"Массив {(isAsc ? "" : "не")}упорядочен по возрастанию");
            Console.WriteLine($"Массив {(isDesc ? "" : "не")}упорядочен по убыванию");
        }

        private static int[] GetRandomArray(int length)
        {
            if (length < 1) throw new ArgumentOutOfRangeException(nameof(length));
            var array = new int[length];
            var random = new Random();
            for (var i = 0; i < array.Length; i++) array[i] = random.Next(100);
            // array[0] = random.Next(10);
            // for (var i = 1; i < array.Length; i++)
            //     array[i] = array[i - 1] + random.Next(6);
             foreach (var value in array) Console.Write(value + " ");
            Console.WriteLine();
            return array;
        }

        private static void Solve(int[] array, out bool isAsc, out bool isDesc)
        {
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
                if (!(isAsc || isDesc))
                    break;
            }
        }
    }
}