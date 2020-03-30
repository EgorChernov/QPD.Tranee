namespace Library
{
    public interface IAction
    {
        bool CreateItem(string parameter);
        bool EditItem(string name);
        bool DeleteItem(string name);
        bool SearchItem(string name);

    }
}