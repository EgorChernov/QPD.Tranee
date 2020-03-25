using System.IO;
using System.Linq;

namespace Task17
{
    public static class Solution
    {
        /// <summary>
        /// 5. Считать из файла массив целых чисел. Упорядочить по возрастанию. Вывести обратно в файл.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var file = File.ReadAllText("in.txt");
            if (string.IsNullOrEmpty(file)) return;
            
            var array = file.Trim()
                .Split(' ')
                .Select(value => int.Parse(value))
                .OrderBy(value => value)
                .Select(value => value.ToString())
                .ToArray();
            var some = string.Join(" ", array);
            
            File.WriteAllText("out.txt", some);
        }
    }
}