using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TableConvert.Properties;

namespace TableConvert
{
    public static class Convertor
    {
        #region Public Methods

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
                    case Formats.Jira:
                        builder.AppendLine(ConvertToJira(line, (i == 0)));
                        break;
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

        #endregion

        #region Private Methods

        private static string ConvertToJira(string[] columns, bool header)
        {
            int columnLength = columns.Length;
            var results = new string[columnLength];

            for (int i = 0; i < columnLength; ++i)
            {
                string column = Regex.Replace(columns[i], Resources.EscapesOfJira, "\\$0").Replace("|", "\\|");
                // Set White-space to empty columns in JIRA
                results[i] = (string.IsNullOrEmpty(column) ? " " : column);
            }

            string splitter = (header ? "||" : "|");
            return $"{splitter}{string.Join(splitter, results)}{splitter}";
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
                results[i] = Regex.Replace(columns[i], Resources.EscapesOfMarkdown, "\\$0").Replace("|", "\\|");
            }

            return $"|{string.Join("|", results)}|";
        }

        #endregion
    }
}
