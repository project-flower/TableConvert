using NUnit.Framework;
using TableConvertTests.Properties;

namespace TableConvert.Tests
{
    [TestFixture()]
    public class ConvertorTests
    {
        private static string[][] ToTable(string csv)
        {
            string[] lines = csv.Replace("\r", string.Empty).Split('\n');
            var result = new string[lines.Length][];

            for (int i = 0; i < lines.Length; ++i)
            {
                result[i] = lines[i].Split(',');
            }

            return result;
        }

        [Test()]
        public void ConvertTest()
        {
            string actual = Convertor.Convert(ToTable(Resources.Input001), Formats.Markdown);
            Assert.AreEqual(Resources.Expected001, actual);
        }
    }
}