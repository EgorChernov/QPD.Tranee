using System.IO;
using System.Linq;

namespace Task18
{
    /// <summary>
    ///     6. Считать из файла массив целых чисел. Упорядочить по убыванию. Вывести обратно в файл.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var file = File.ReadAllText(@"in.txt");

            var array = file.Trim()
                .Split(' ')
                .Select(value => int.Parse(value))
                .OrderByDescending(value => value)
                .ToArray();


            File.WriteAllText("out.txt", string.Join(" ", array.Select(value => value.ToString())));
        }
    }
}