using System;
using System.Linq;
using System.Text;

namespace TableConvert
{
    public static class Convertor
    {
        public static string Convert(string[][] table, Formats format)
        {
            var builder = new StringBuilder();

            if ((format == Formats.Markdown) && (table.Length < 2))
            {
                throw new Exception("There are not enough lines.");
            }

            for (int i = 0; i < table.Length; ++i)
            {
                string[] line = table[i];

                switch (format)
                {
                    case Formats.Csv:
                        builder.AppendLine(ConvertToLine(line, ','));
                        continue;
                    case Formats.Markdown:
                        string markdown = ConvertToMarkdown(line);
                        builder.AppendLine(markdown);

                        if (i == 0)
                        {
                            builder.Append('|');
                            
                            for (int j = 0; j < line.Length; ++j)
                            {
                                builder.Append("---|");
                            }
                            
                            builder.AppendLine();
                        }

                        break;
                    case Formats.Tsv:
                        builder.AppendLine(ConvertToLine(line, '\t'));
                        continue;
                    default:
                        return string.Empty;
                }
            }

            return builder.ToString();
        }

        private static string ConvertToLine(string[] columns, char splitter)
        {
            int columnLength = columns.Length;
            var results = new string[columnLength];

            for (int i = 0; i < columnLength; ++i)
            {
                string column = columns[i];

                if (column.Contains(splitter))
                {
                    column = $"\"{column}\"";
                }

                results[i] = column;
            }

            return string.Join(splitter.ToString(), results);
        }

        private static string ConvertToMarkdown(string[] columns)
        {
            int columnLength = columns.Length;
            var results = new string[columnLength];

            for (int i = 0; i < columnLength; ++i)
            {
                results[i] = columns[i].Replace("|", "\\|");
            }

            return $"|{string.Join("|", results)}|";
        }
    }
}
