﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TableConvert
{
    public static class Analyzer
    {
        #region Public Methods

        public static string[][] GetTable(string text)
        {
            string[] lines = text.Replace("\r", string.Empty).TrimEnd('\n').Split('\n');
            Formats format = Formats.None;
            var result = new List<string[]>(lines.Length);
            int columnLength = -1;

            for (int i = 0; i < lines.Length; ++i)
            {
                string line = lines[i];
                Formats prevFormat = format;

                try
                {
                    format = GetColumns(line, out string[] columns);

                    if (i > 0)
                    {
                        if ((prevFormat == Formats.Markdown && format.HasFlag(Formats.Markdown))
                            || (prevFormat.HasFlag(Formats.Markdown) && format == Formats.Markdown))
                        {
                            // Markdown format is determined by the first and second lines.
                            format = Formats.Markdown;
                        }
                        else if (prevFormat == Formats.Lattice && format.HasFlag(Formats.Lattice))
                        {
                            format = Formats.Lattice;
                        }
                        else if (prevFormat.HasFlag(Formats.Jira) && format.HasFlag(Formats.Jira))
                        {
                            format = Formats.Jira;
                        }
                    }

                    if (i > 1)
                    {
                        if (prevFormat != format)
                        {
                            throw new Exception("The format is incorrect.");
                        }
                    }
                    else
                    {
                        prevFormat = format;
                    }

                    if (columns == null)
                    {
                        continue;
                    }

                    if ((columnLength > 0) && (columnLength != columns.Length))
                    {
                        throw new Exception($"The number of {i + 1} column does not match.");
                    }

                    columnLength = columns.Length;

                    if ((format & (Formats.Markdown | Formats.Jira)) != 0)
                    {
                        columns = columns.Select(n =>
                        {
                            if (n == " " && format.HasFlag(Formats.Jira))
                            {
                                // Set White-space to empty columns in JIRA
                                return string.Empty;
                            }

                            return Regex.Replace(n, "(\\\\)(\\S)", "$2");
                        }).ToArray();
                    }

                    if (format == Formats.Lattice)
                    {
                        columns = columns.Select(n => n.Trim()).ToArray();
                    }

                    result.Add(columns);
                }
                catch
                {
                    throw;
                }
            }

            return result.ToArray();
        }

        #endregion

        #region Private Methods

        private static Formats GetColumns(string line, out string[] columns)
        {
            Formats result;
            MatchCollection matches;

            do
            {
                if (Regex.IsMatch(line, "^\\+(\\-+\\+)+$"))
                {
                    columns = null;
                    return Formats.Lattice;
                }

                if (line.StartsWith("|") && line.EndsWith("|"))
                {
                    matches = Regex.Matches(line, "(?<=\\|{2})(.*?)(?=(\\|{2}))");

                    if (matches.Count > 0)
                    {
                        result = Formats.Jira;
                        break;
                    }

                    if (Regex.IsMatch(line, "\\|(\\s*\\:*-{2,}\\:*\\s*)\\|"))
                    {
                        columns = null;
                        return Formats.Markdown;
                    }
                    else
                    {
                        result = (Formats.Lattice | Formats.Markdown | Formats.Jira);
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

        #endregion
    }
}
