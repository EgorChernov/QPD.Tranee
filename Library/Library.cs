using System;

namespace Library
{
    public static class ConsoleLibrary
    {
        public static void Main(string[] args)
        {
            var strorage = new ConsoleLibraryAction();
            strorage.ListenConsole();
        }
    }
}