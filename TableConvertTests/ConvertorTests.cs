using NUnit.Framework;
using TableConvertTests;
using TableConvertTests.Properties;

namespace TableConvert.Tests
{
    [TestFixture()]
    public class ConvertorTests
    {
        [Test()]
        public void ConvertJiraTest001()
        {
            string actual = Convertor.Convert(Common.ToTable(Resources.InputJira001), Formats.Jira);
            Assert.AreEqual(Resources.ExpectedJira001, actual);
        }

        [Test()]
        public void ConvertMarkdownTest001()
        {
            string actual = Convertor.Convert(Common.ToTable(Resources.InputMarkdown001), Formats.Markdown);
            Assert.AreEqual(Resources.ExpectedMarkdown001, actual);
        }
    }
}