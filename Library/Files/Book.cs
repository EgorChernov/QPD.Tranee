using System.Collections.Generic;
using System.Text;

namespace Library.Files
{
    public class Book : TextFile
    {
        public string Author { get; set; }
        public string Genre { get; set; }

        public override void FillFields(Dictionary<string, string> commandValueDictionary, out string result)
        {
            base.FillFields(commandValueDictionary, out result);
            var stringBuilder = new StringBuilder(result);

            stringBuilder.Append(FillAuthorField(commandValueDictionary));
            stringBuilder.Append(FillGenreField(commandValueDictionary));
            result = stringBuilder.ToString();
        }

        public override void EditFields(Dictionary<string, string> commandValueDictionary, out string result)
        {
            base.EditFields(commandValueDictionary, out result);
            var stringBuilder = new StringBuilder(result);

            stringBuilder.Append(FillAuthorField(commandValueDictionary));
            stringBuilder.Append(FillGenreField(commandValueDictionary));
            result = stringBuilder.ToString();
        }

        private string FillAuthorField(IReadOnlyDictionary<string, string> commandValueDictionary)
        {
            if (commandValueDictionary.ContainsKey("author"))
                this.Author = commandValueDictionary["author"];
            return string.Empty;
        }

        private string FillGenreField(IReadOnlyDictionary<string, string> commandValueDictionary)
        {
            if (commandValueDictionary.ContainsKey("genre"))
                this.Genre = commandValueDictionary["genre"];
            return string.Empty;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Книга : ");
            stringBuilder.Append(base.ToString());
            stringBuilder.Append($" / Автор - {this.Author}");
            stringBuilder.Append($" / Жанр - {this.Genre}");
            return stringBuilder.ToString();
        }
    }
}