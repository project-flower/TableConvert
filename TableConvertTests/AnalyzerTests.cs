using NUnit.Framework;
using TableConvertTests;
using TableConvertTests.Properties;

namespace TableConvert.Tests
{
    [TestFixture()]
    public class AnalyzerTests
    {
        [Test()]
        public void AnalyzeJiraTest001()
        {
            string[][] actual = Analyzer.GetTable(Resources.TableJira001);
            Assert.AreEqual(Common.ToTable(Resources.ExpectedTable001), actual);
        }

        [Test()]
        public void AnalyzeJiraTest002()
        {
            string[][] actual = Analyzer.GetTable(Resources.TableJira002);
            Assert.AreEqual(Common.ToTable(Resources.ExpectedTable001), actual);
        }

        [Test()]
        public void AnalyzeJiraTest003()
        {
            string[][] actual = Analyzer.GetTable(Resources.ExpectedJira001);
            Assert.AreEqual(Common.ToTable(Resources.InputJira001), actual);
        }

        [Test()]
        public void AnalyzeLattice001()
        {
            string[][] actual = Analyzer.GetTable(Resources.TableLattice001);
            Assert.AreEqual(Common.ToTable(Resources.ExpectedTable001), actual);
        }

        [Test()]
        public void AnalyzeMarkdown001()
        {
            string[][] actual = Analyzer.GetTable(Resources.TableMarkdown001);
            Assert.AreEqual(Common.ToTable(Resources.ExpectedTable001), actual);
        }

        [Test()]
        public void AnalyzeMarkdown002()
        {
            string[][] actual = Analyzer.GetTable(Resources.ExpectedMarkdown001);
            Assert.AreEqual(Common.ToTable(Resources.InputMarkdown001), actual);
        }
    }
}