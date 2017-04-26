using System;
using NUnit.Framework;

namespace ExCSS.Tests
{
    [TestFixture]
    public class RuleLineFixture
    {
        [Test]
        public void Parser_Reads_One_Line()
        {
            var parser = new Parser();
            var css = parser.Parse("html{color:#000000;}");

            Assert.AreEqual(css.StyleRules[0].line, 1);
        }

        [Test]
        public void Parser_Does_Not_Throw_On_Empty_Document()
        {
            var parser = new Parser();

            Assert.DoesNotThrow(() => parser.Parse(String.Empty));
        }

        [TestCase("\n")]
        [TestCase("\r\n")]
        [TestCase("\r")]
        public void Parser_Reads_Correct_Line_Numbers_With_Line_Breaks(string lineEnding)
        {
            var parser = new Parser();
            var css = parser.Parse(string.Format("{0}html{{color:#000000;}}{0}{0}div{{color:#ffffff;}}{0}{0}", lineEnding));

            Assert.AreEqual(2, css.StyleRules[0].line);
            Assert.AreEqual(4, css.StyleRules[1].line);
        }
    }
}
