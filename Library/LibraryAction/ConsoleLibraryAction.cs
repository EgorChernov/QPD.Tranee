using System;
using System.Collections.Generic;
using System.Linq;
using Library.Files;

namespace Library
{
    public class ConsoleLibraryAction : IAction<TextFile>
    {
        public List<TextFile> FilesList { get; set; }
        public ConsoleLibraryAction()
        {
            this.FilesList = new List<TextFile>();
        }

        public void CreateItem(string parameter, out bool success)
        {
            if (string.IsNullOrEmpty(parameter)){success = false; return;}

            CommandParametersSplit(parameter, out var textFileType, out var parameters);

            var parametersDictionary = SplitCommand(parameters);
            if (parametersDictionary == null)
            {
                success = false;
                return;
            }

            switch (textFileType.ToLower())
            {
                case "-b":
                {
                    var book = new Book();
                    book.FillFields(parametersDictionary, out var fillFieldsWarning);

                    if (string.IsNullOrEmpty(fillFieldsWarning))
                    {
                        FilesList.Add(book);
                        Console.WriteLine("Книга добавлена");
                        success = true;
                        return;
                    }

                    Console.WriteLine(fillFieldsWarning);
                    success = false;
                    break;
                }
                case "-m":
                {
                    var magazine = new Magazine();
                    magazine.FillFields(parametersDictionary, out var fillFieldsWarning);
                    if (string.IsNullOrEmpty(fillFieldsWarning))
                    {
                        FilesList.Add(magazine);
                        Console.WriteLine("Журнал добавлен");
                        success = true;
                        return;
                    }

                    Console.WriteLine(fillFieldsWarning);
                    success = false;
                    break;
                }
                default:
                {
                    success = false;
                    break;
                }
            }
        }

        public void EditItem(string name, out bool success)
        {
            if (string.IsNullOrEmpty(name))
            {
                success = false;
                return;
            }

            if (FilesList.Count == 0)
            {
                Console.WriteLine("Фонд пуст");
                success = true;
                return;
            }

            var searchByName = GetListItemByName(name);

            TextFile oldItem;
            switch (searchByName.Count)
            {
                case 0:
                {
                    Console.WriteLine("Позиций с таким названием в фонде нет");
                    success = true;
                    return;
                }
                case 1:
                {
                    oldItem = searchByName.ElementAt(0);
                    break;
                }
                default:
                {
                    Console.WriteLine($"Найдено файлов : {searchByName.Count}");

                    foreach (var file in searchByName) Console.WriteLine(file);

                    Console.WriteLine($"Какой из файлов удалить? 1 - {searchByName.Count}");

                    if (!(int.TryParse(Console.ReadLine(), out var value) && value > 0 && value <= searchByName.Count))
                    {
                        success = false;
                        return;
                    }

                    oldItem = searchByName.ElementAt(value - 1);
                    break;
                }
            }

            Console.WriteLine("Введите изменения в формате -field1 newValue1 -field2 newValue2");
            var newValueDictionary = SplitCommand(Console.ReadLine());
            if (newValueDictionary == null)
            {
                success = false;
                return;
            }

            var newItem = oldItem.Clone() as TextFile;

            if (newItem == null)
            {
                success = false;
                return;
            }

            newItem.EditFields(newValueDictionary, out var warningMessage);

            if (!string.IsNullOrEmpty(warningMessage))
            {
                Console.WriteLine(warningMessage);
                success = false;
            }
            else
            {
                success = FilesList.Remove(oldItem);
                if (!success) return;
                FilesList.Add(newItem);
                Console.WriteLine("Изменения сохранены");
            }
        }

        public void DeleteItem(string name, out bool success)
        {
            if (string.IsNullOrEmpty(name))
            {
                success = false;
                return;
            }

            if (FilesList.Count == 0)
            {
                Console.WriteLine("Фонд пуст");
                success = true;
                return;
            }

            var searchByName = GetListItemByName(name);

            switch (searchByName.Count)
            {
                case 0:
                {
                    Console.WriteLine("Позиций с таким названием в фонде нет");
                    success = true;
                    return;
                }
                case 1:
                {
                    var result = FilesList.Remove(searchByName.ElementAt(0));
                    Console.WriteLine(result ? "Файл успешно удален" : "Ошибка удаления файла");
                    success = result;
                    return;
                }
            }

            Console.WriteLine($"Найдено файлов : {searchByName.Count}");

            foreach (var item in searchByName)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Какой из файлов удалить? 1 - {searchByName.Count}");


            if (!(int.TryParse(Console.ReadLine(), out var value) && value > 0 && value <= searchByName.Count))
            {
                success = false;
                return;
            }

            success = FilesList.Remove(searchByName.ElementAt(value - 1));
            Console.WriteLine(success ? "Файл успешно удален" : "Ошибка удаления файла");
        }

        public void SearchItem(string name, out bool success)
        {
            if (string.IsNullOrEmpty(name)){ success = false; return;}

            if (FilesList.Count == 0)
            {
                Console.WriteLine("Фонд пуст");
                success = true;
                return;
            }

            var searchByName = GetListItemByName(name);

            if (searchByName.Count == 0)
            {
                Console.WriteLine("Позиций с таким названием в фонде нет");
                success = true;
                return;
            }

            foreach (var item in searchByName)
            {
                Console.WriteLine(item);
            }

            success = true;
        }


        public void ListenConsole()
        {
            var isExitCommandInput = false;

            do
            {
                var currentConsoleRead = Console.ReadLine();

                CommandParametersSplit(currentConsoleRead, out string command, out string parameters);

                var isCommandSuccess = false;
                switch (command.ToLower())
                {
                    case "-help":
                    {
                        isCommandSuccess = WriteConsoleAllowedCommand();
                        break;
                    }
                    case "-exit":
                    {
                        isExitCommandInput = true;
                        isCommandSuccess = true;
                        break;
                    }

                    case "-add":
                    {
                        CreateItem(parameters, out isCommandSuccess);
                        break;
                    }
                    case "-search":
                    {
                        SearchItem(parameters, out isCommandSuccess);
                        break;
                    }

                    case "-edit":
                    {
                        EditItem(parameters, out isCommandSuccess);
                        break;
                    }

                    case "-delete":
                    {
                        DeleteItem(parameters, out isCommandSuccess);
                        break;
                    }

                    case "-all":
                    {
                        isCommandSuccess = WriteConsoleAllItem();
                        break;
                    }
                }

                if (!isCommandSuccess)
                    Console.WriteLine("Wrong Input. Please, try again or use -help");

            } while (!isExitCommandInput);
        }

        private bool WriteConsoleAllItem()
        {
            if (FilesList.Count == 0)
            {
                Console.WriteLine("Фонд пуст");
                return true;
            }

            foreach (var item in FilesList)
            {
                Console.WriteLine(item);
            }

            return true;
        }


        private static bool WriteConsoleAllowedCommand()
        {
            Console.WriteLine("-add -b(-m) -field1 -value1 -field2 -value2");
            Console.WriteLine("-search item_name");
            Console.WriteLine("-edit item_name");
            Console.WriteLine("-delete item_name");
            Console.WriteLine("-all");
            Console.WriteLine("-exit");
            return true;
        }

        private List<TextFile> GetListItemByName(string name) => FilesList
            .Where(file => file.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToList();

        /// <summary>
        /// Разбивает строку, полученную из консоли, на команду и набор параметров
        /// </summary>
        /// <param name="consoleRead">строка, полученная из консоли</param>
        /// <param name="command">команда, которую нужно выполнить</param>
        /// <param name="parameters">набор параметров</param>
        private void CommandParametersSplit(string consoleRead, out string command, out string parameters)
        {
            if (consoleRead.Contains(' '))
            {
                command = consoleRead.Substring(0, consoleRead.IndexOf(' '));
                parameters = consoleRead.Substring(consoleRead.IndexOf(' ') + 1);
            }
            else
            {
                command = consoleRead;
                parameters = string.Empty;
            }
        }

        private static Dictionary<string, string> SplitCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
                return null;

            var splitCommand = command.Split('-', StringSplitOptions.RemoveEmptyEntries);

            var commandDictionary = new Dictionary<string, string>();
            foreach (var value in splitCommand.Select(x => x.Trim()))
            {
                if (string.IsNullOrEmpty(value)) return null;
                if (!value.Contains("\""))
                {
                    //there is -command value
                    //should be just one space
                    var splitAction = value.Split(' ');

                    //incorrect input
                    //-command value with spaces
                    if (splitAction.Length != 2) return null;
                    commandDictionary.Add(splitAction[0].ToLower(), splitAction[1]);
                }
                else
                {
                    //there is -command "value with spaces"

                    if (value.Count(c => c.Equals('"')) != 2) return null;

                    //Check if there no -com"mand value with spaces"
                    if (value.Substring(0, value.IndexOf(' ')).Contains("\""))
                        return null;

                    var dictionaryKey = value.Substring(0, value.IndexOf(' '));
                    var dictionaryValue = value.Substring(value.IndexOf("\"", StringComparison.Ordinal),
                        value.LastIndexOf("\"", StringComparison.Ordinal) -
                        value.IndexOf("\"", StringComparison.Ordinal) + 1);

                    commandDictionary.Add(dictionaryKey.ToLower(), dictionaryValue);
                }
            }

            return commandDictionary;
        }

    }
}