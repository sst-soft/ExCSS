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
        public void Parser_Reads_Two_Lines_With_Line_Breaks()
        {
            var parser = new Parser();
            var css = parser.Parse("\nhtml{color:#000000;}\n\ndiv{color:#ffffff;}");
            Assert.AreEqual(css.StyleRules[0].line, 2);
            Assert.AreEqual(css.StyleRules[1].line, 4);
        }
    }
}
