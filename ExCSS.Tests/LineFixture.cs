using System;
using NUnit.Framework;

namespace ExCSS.Tests
{
    [TestFixture]
    public class LineFixture
    {
        [Test]
        public void Parser_Reads_One_Line()
        {
            var parser = new Parser();
            var css = parser.Parse("html{color:#000000;}");

            var rule = css.StyleRules[0];
            var property = rule.Declarations[0];
            Assert.AreEqual(1, rule.Line);
            Assert.AreEqual(1, property.Line);
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
        public void Parser_Reads_Correct_RuleLine_Numbers_With_Line_Breaks(string lineEnding)
        {
            var parser = new Parser();
            var css = parser.Parse(string.Format("{0}html{{color:#000000;}}{0}{0}div{{color:#ffffff;}}{0}{0}", lineEnding));

            Assert.AreEqual(2, css.StyleRules[0].Line);
            Assert.AreEqual(4, css.StyleRules[1].Line);
        }

        [TestCase("\n")]
        [TestCase("\r\n")]
        [TestCase("\r")]
        public void Parser_Reads_Correct_PropertyLine_Numbers_With_Line_Breaks(string lineEnding)
        {
            var parser = new Parser();
            var css = parser.Parse(string.Format("{0}html{{{0}color:#000000;{0}top:10px;{0}margin:2px auto;{0}}}{0}div{{{0}color:#ffffff;{0}left:0;{0}width:10px{0}}}{0}{0}", lineEnding));

            var rule = css.StyleRules[0];
            var property1 = rule.Declarations[0];
            var property2 = rule.Declarations[1];
            var property3 = rule.Declarations[2];

            Assert.AreEqual(2, rule.Line);
            Assert.AreEqual(3, property1.Line);
            Assert.AreEqual(4, property2.Line);
            Assert.AreEqual(5, property3.Line);

            rule = css.StyleRules[1];
            property1 = rule.Declarations[0];
            property2 = rule.Declarations[1];
            property3 = rule.Declarations[2];

            Assert.AreEqual(7, rule.Line);
            Assert.AreEqual(8, property1.Line);
            Assert.AreEqual(9, property2.Line);
            Assert.AreEqual(10, property3.Line);
        }
    }
}
