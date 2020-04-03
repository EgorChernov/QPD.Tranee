using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Files
{
    public class TextFile : ICloneable
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Published { get; set; }
        public string Year { get; set; }

        /// <summary>
        /// Заполнить поля объекта из словаря с параметрами
        /// </summary>
        /// <param name="commandValueDictionary">словарь значений параметра</param>
        /// <returns>Ошибка сопоставления параментра</returns>
        public virtual void FillFields(Dictionary<string, string> commandValueDictionary, out string result)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(FillNameField(commandValueDictionary));

            stringBuilder.Append(FillCodeField(commandValueDictionary));
            stringBuilder.Append(FillCountField(commandValueDictionary));
            stringBuilder.Append(FillPublishedField(commandValueDictionary));
            stringBuilder.Append(FillYearField(commandValueDictionary));

            result = stringBuilder.ToString();
        }

        public virtual void EditFields(Dictionary<string, string> commandValueDictionary, out string result)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(EditNameField(commandValueDictionary));

            stringBuilder.Append(FillCodeField(commandValueDictionary));
            stringBuilder.Append(FillCountField(commandValueDictionary));
            stringBuilder.Append(FillPublishedField(commandValueDictionary));
            stringBuilder.Append(FillYearField(commandValueDictionary));

            result = stringBuilder.ToString();
        }


        public virtual object Clone() => this.MemberwiseClone();


        #region Validation
        
        protected string FillNameField(IReadOnlyDictionary<string, string> commandValueDictionary)
        {
            if (!commandValueDictionary.ContainsKey("name")) return "Не найдено поле Наименование -name\n";
            this.Name = commandValueDictionary["name"];
            return string.Empty;
        }

        private string EditNameField(Dictionary<string, string> commandValueDictionary)
        {
            if (commandValueDictionary.ContainsKey("name"))
                this.Name = Name;
            return string.Empty;
        }
        
        protected string FillCodeField(IReadOnlyDictionary<string, string> commandValueDictionary)
        {
            if (!commandValueDictionary.ContainsKey("code")) return string.Empty;
            
            var isParse = int.TryParse(commandValueDictionary["code"], out var value);
            if (isParse && value > 0)
            {
                this.Code = value;
                return string.Empty;
            }
            else
            {
                return "Не удалось получить значение поля \"Код\" - положительное число\n";
            }
        }

        protected string FillCountField(IReadOnlyDictionary<string, string> commandValueDictionary)
        {
            if (!commandValueDictionary.ContainsKey("count")) return string.Empty;
            
            var isParse = int.TryParse(commandValueDictionary["count"], out int value);
            if (isParse && value > 0)
            {
                this.Count = value;
                return string.Empty;
            }
            else
            {
                return "Не удалось получить значение поля \"Количество\" - положительное число\n";
            }
        }
        protected string FillPublishedField(IReadOnlyDictionary<string, string> commandValueDictionary)
        {
            if (commandValueDictionary.ContainsKey("published"))
            {
                this.Published = commandValueDictionary["published"];
            }

            return string.Empty;
        }
        protected string FillYearField(IReadOnlyDictionary<string, string> commandValueDictionary)
        {
            if (commandValueDictionary.ContainsKey("year"))
            {
                this.Year = commandValueDictionary["year"];
            }

            return string.Empty;
        }
        #endregion

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Название - {this.Name}");
            stringBuilder.Append($" / Код - {this.Code} ");
            stringBuilder.Append($" / Количество - {this.Count}");
            stringBuilder.Append($" / Издательство - {this.Published}");
            stringBuilder.Append($" / Год - {this.Year}");
            return stringBuilder.ToString();
        }

        
    }
}