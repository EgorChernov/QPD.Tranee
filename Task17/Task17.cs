using System.IO;
using System.Linq;

namespace Task17
{
    public static class Solution
    {
        public static void Main(string[] args)
        {
            var file = File.ReadAllText(@"in.txt");

            var array = file.Trim()
                .Split(' ')
                .Select(value => int.Parse(value))
                .OrderBy(value => value)
                .ToArray();

            File.WriteAllText("out.txt", string.Join(" ", array.Select(value => value.ToString())));
        }
    }
}