using System;
using System.Collections.Generic;
using System.Linq;
using Library.Files;

namespace Library
{
    public class ConsoleLibraryAction : LibraryAction
    {
        public ConsoleLibraryAction()
        {
            this.library = new List<TextFile>();
        }

        public override bool CreateItem(string parameter)
        {
            if (string.IsNullOrEmpty(parameter)) return false;

            CommandParametersSplit(parameter, out var textFileType, out var parameters);

            var parametersDictionary = SplitCommand(parameters);
            if (parameters == null)
                return false;

            switch (textFileType.ToLower())
            {
                case "-b":
                {
                    var book = new Book();
                    var fillFieldsWarning = book.FillFields(parametersDictionary);

                    if (string.IsNullOrEmpty(fillFieldsWarning))
                    {
                        library.Add(book);
                        Console.WriteLine("Книга добавлена");
                        return true;
                    }

                    Console.WriteLine(fillFieldsWarning);
                    return false;
                }
                case "-m":
                {
                    var magazine = new Magazine();
                    var fillFieldsWarning = magazine.FillFields(parametersDictionary);
                    if (string.IsNullOrEmpty(fillFieldsWarning))
                    {
                        library.Add(magazine);
                        Console.WriteLine("Журнал добавлен");
                        return true;
                    }

                    Console.WriteLine(fillFieldsWarning);
                    return false;

                }
                default:
                {
                    return false;
                }
            }
        }

        public override bool EditItem(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;
            if (library.Count == 0)
            {
                Console.WriteLine("Фонд пуст");
            }

            var searchByName = GetListItemByName(name);

            TextFile oldItem;
            switch (searchByName.Count)
            {
                case 0:
                {
                    Console.WriteLine("Позиций с таким названием в фонде нет");
                    return true;
                }
                case 1:
                {
                    oldItem = searchByName.ElementAt(0);
                    break;
                }
                default:
                {
                    Console.WriteLine($"Найдено файлов : {searchByName.Count}");

                    foreach (var file in searchByName)
                    {
                        Console.WriteLine(file);
                    }

                    Console.WriteLine($"Какой из файлов удалить? 1 - {searchByName.Count}");

                    if (int.TryParse(Console.ReadLine(), out var value) && value > 0 && value <= searchByName.Count)
                    {
                        oldItem = searchByName.ElementAt(value - 1);
                        break;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            Console.WriteLine("Введите изменения в формате -field1 newValue1 -field2 newValue2");
            var newValueDictionary = SplitCommand(Console.ReadLine());
            if (newValueDictionary == null) return false;

            var newItem = oldItem.Clone() as TextFile;
            if (newItem == null) return false;
            var warningMessage = newItem.FillFields(newValueDictionary);

            if (!string.IsNullOrEmpty(warningMessage))
            {
                Console.WriteLine(warningMessage);
                return false;
            }
            else
            {
                var result = library.Remove(oldItem);
                if (result)
                {
                    library.Add(newItem);
                    Console.WriteLine("Изменения сохранены");
                }
                else
                {
                    return result;
                }
            }

            return true;
        }

        public override bool DeleteItem(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;
            if (library.Count == 0)
            {
                Console.WriteLine("Фонд пуст");
            }

            var searchByName = GetListItemByName(name);

            switch (searchByName.Count)
            {
                case 0:
                    Console.WriteLine("Позиций с таким названием в фонде нет");
                    return true;
                case 1:
                {
                    var result = library.Remove(searchByName.ElementAt(0));
                    Console.WriteLine(result ? "Файл успешно удален" : "Ошибка удаления файла");
                    return result;
                }
            }

            Console.WriteLine($"Найдено файлов : {searchByName.Count}");

            foreach (var item in searchByName)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Какой из файлов удалить? 1 - {searchByName.Count}");

            if (int.TryParse(Console.ReadLine(), out var value) && value > 0 && value <= searchByName.Count)
            {
                var result = library.Remove(searchByName.ElementAt(value - 1));
                Console.WriteLine(result ? "Файл успешно удален" : "Ошибка удаления файла");
                return result;
            }
            else
            {
                return false;
            }
        }

        public override bool SearchItem(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;
            if (library.Count == 0)
            {
                Console.WriteLine("Фонд пуст");
                return true;
            }

            var searchByName = GetListItemByName(name);

            if (searchByName.Count == 0)
            {
                Console.WriteLine("Позиций с таким названием в фонде нет");
                return true;
            }

            foreach (var item in searchByName)
            {
                Console.WriteLine(item);
            }

            return true;
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
                        isCommandSuccess = CreateItem(parameters);
                        break;
                    }
                    case "-search":
                    {
                        isCommandSuccess = SearchItem(parameters);
                        break;
                    }

                    case "-edit":
                    {
                        isCommandSuccess = EditItem(parameters);
                        break;
                    }

                    case "-delete":
                    {
                        isCommandSuccess = DeleteItem(parameters);
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
            if (library.Count == 0)
            {
                Console.WriteLine("Фонд пуст");
                return true;
            }

            foreach (var item in library)
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

        private List<TextFile> GetListItemByName(string name) => library
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
                if (!value.Contains("\""))
                {
                    //there is -command value
                    //should be just one space
                    var splitAction = value.Split(' ');

                    if (splitAction.Length == 2)
                    {
                        commandDictionary.Add(splitAction[0].ToLower(), splitAction[1]);
                    }
                    else
                    {
                        //incorrect input
                        //-command value with spaces
                        return null;
                    }
                }
                else
                {
                    //there is -command "value with spaces"

                    if (value.Count(c => c.Equals('"')) == 2)
                    {
                        //Check if there no -com"mand value with spaces"
                        if (value.Substring(0, value.IndexOf(' ')).Contains("\""))
                            return null;

                        var dictionaryKey = value.Substring(0, value.IndexOf(' '));
                        var dictionaryValue = value.Substring(value.IndexOf("\"", StringComparison.Ordinal),
                            value.LastIndexOf("\"", StringComparison.Ordinal) -
                            value.IndexOf("\"", StringComparison.Ordinal) + 1);

                        commandDictionary.Add(dictionaryKey.ToLower(), dictionaryValue);
                    }
                    else
                        return null;
                }
            }

            return commandDictionary;
        }
    }
}