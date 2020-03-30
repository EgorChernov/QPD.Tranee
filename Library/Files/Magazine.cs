using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Files
{
    public class Magazine : TextFile
    {
        public string Period { get; set; }
        public int Number { get; set; }

        public override string FillFields(Dictionary<string, string> commandValueDictionary)
        {
            var result = base.FillFields(commandValueDictionary);
            var stringBuilder = new StringBuilder(result);

            stringBuilder.Append(FillNumberField(commandValueDictionary));
            stringBuilder.Append(FillPeriodField(commandValueDictionary));

            return stringBuilder.ToString();
        }

        public override string EditFields(Dictionary<string, string> commandValueDictionary)
        {
            var result = base.FillFields(commandValueDictionary);
            var stringBuilder = new StringBuilder(result);

            stringBuilder.Append(FillNumberField(commandValueDictionary));
            stringBuilder.Append(FillPeriodField(commandValueDictionary));

            return stringBuilder.ToString();
        }

        #region Validation

        private string FillNumberField(IReadOnlyDictionary<string, string> commandValueDictionary)
        {
            if (!commandValueDictionary.ContainsKey("number")) return string.Empty;
            
            bool isParse = int.TryParse(commandValueDictionary["number"], out int value);
            if (isParse && value > 0)
            {
                this.Number = value;
                return string.Empty;
            }
            else
            {
                return "Не удалось получить значение поля \"Номер\" - положительное число\n";
            }
        }

        private string FillPeriodField(IReadOnlyDictionary<string, string> commandValueDictionary)
        {
            if (commandValueDictionary.ContainsKey("period"))
                this.Period = commandValueDictionary["period"];
            return string.Empty;
        }

        #endregion

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Журнал : ");
            stringBuilder.Append(base.ToString());
            stringBuilder.Append($" / Периодичность - {this.Period}");
            stringBuilder.Append($" / Номер - {this.Number}");
            return stringBuilder.ToString();
        }

    }
}