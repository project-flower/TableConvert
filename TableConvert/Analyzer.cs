using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TableConvert
{
    public static class Analyzer
    {
        public static string[][] GetTable(string text)
        {
            string[] lines = text.Replace("\r", string.Empty).Split('\n');
            Formats formats = Formats.None;
            var result = new List<string[]>(lines.Length);
            int columnLength = -1;

            for (int i = 0; i < lines.Length; ++i)
            {
                string line = lines[i];
                string[] columns;
                Formats prevFormats = formats;

                try
                {
                    formats = GetColumns(line, out columns);

                    if ((prevFormats != Formats.None) && (prevFormats != formats))
                    {
                        throw new Exception("The format is incorrect.");
                    }

                    formats = prevFormats;

                    if (columns == null)
                    {
                        continue;
                    }

                    if ((columnLength > 0) && (columnLength != columns.Length))
                    {
                        throw new Exception($"The number of {i + 1} column does not match.");
                    }

                    columnLength = columns.Length;
                    result.Add(columns);
                }
                catch
                {
                    throw;
                }
            }

            return result.ToArray();
        }

        private static Formats GetColumns(string line, out string[] columns)
        {
            Formats result;
            MatchCollection matches;

            do
            {
                if (line.StartsWith("|") && line.StartsWith("|"))
                {
                    result = Formats.Markdown;

                    if (Regex.IsMatch(line, "\\|(\\s*\\:*-{2,}\\:*\\s*)\\|"))
                    {
                        columns = null;
                        return result;
                    }

                    matches = Regex.Matches(line, "(?<=\\|)([^\\|]*?)(?=(\\|))");
                    break;
                }

                matches = Regex.Matches(line, "(?<=(^|,))((\"[^\"\\t]*?\")|[^,\\t]*?)(?=($|,))");

                if (matches.Count > 0)
                {
                    result = Formats.Csv;
                    break;
                }

                matches = Regex.Matches(line, "(?<=(^|\\t))((\"[^\"]*?\")|[^,]*?)(?=($|\\t))");

                if (matches.Count > 0)
                {
                    result = Formats.Tsv;
                    break;
                }

                throw new Exception("The format is incorrect.");
            } while (true);

            int count = matches.Count;
            columns = new string[count];

            for (int i = 0; i < count; ++i)
            {
                columns[i] = matches[i].Value;
            }

            return result;
        }
    }
}
