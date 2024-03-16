namespace TableConvertTests
{
    internal static class Common
    {
        public static string[][] ToTable(string csv)
        {
            string[] lines = csv.Replace("\r", string.Empty).Split('\n');
            var result = new string[lines.Length][];

            for (int i = 0; i < lines.Length; ++i)
            {
                result[i] = lines[i].Split(',');
            }

            return result;
        }
    }
}
