using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Files
{
    public class Magazine : TextFile
    {
        public string Period { get; set; }
        public int Number { get; set; }

        public override void FillFields(Dictionary<string, string> commandValueDictionary, out string result)
        {
            base.FillFields(commandValueDictionary, out result);
            var stringBuilder = new StringBuilder(result);

            stringBuilder.Append(FillNumberField(commandValueDictionary));
            stringBuilder.Append(FillPeriodField(commandValueDictionary));

            result = stringBuilder.ToString();
        }

        public override void EditFields(Dictionary<string, string> commandValueDictionary, out string result)
        {
            base.EditFields(commandValueDictionary, out result);
            var stringBuilder = new StringBuilder(result);

            stringBuilder.Append(FillNumberField(commandValueDictionary));
            stringBuilder.Append(FillPeriodField(commandValueDictionary));

            result = stringBuilder.ToString();
        }

        #region Validation

        private string FillNumberField(IReadOnlyDictionary<string, string> commandValueDictionary)
        {
            if (!commandValueDictionary.ContainsKey("number")) return string.Empty;

            if (!(int.TryParse(commandValueDictionary["number"], out var value) && value > 0))
            {
                return "Не удалось получить значение поля \"Номер\" - положительное число\n";
            }

            Number = value;
            return string.Empty;
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