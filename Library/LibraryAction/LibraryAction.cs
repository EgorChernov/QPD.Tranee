using System.Collections.Generic;
using Library.Files;

namespace Library
{
    public abstract class LibraryAction : IAction
    {
        protected List<TextFile> library;
        public abstract bool CreateItem(string parameter);

        public abstract bool EditItem(string name);

        public abstract bool DeleteItem(string name);

        public abstract bool SearchItem(string name);
    }
}