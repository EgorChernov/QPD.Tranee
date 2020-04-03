using System.Collections.Generic;
using Library.Files;

namespace Library
{
    public interface IAction<T>
    {
        List<T> FilesList { get; set; }
        void CreateItem(string parameter, out bool success);
        void EditItem(string name, out bool success);
        void DeleteItem(string name, out bool success);
        void SearchItem(string name, out bool success);
    }
}