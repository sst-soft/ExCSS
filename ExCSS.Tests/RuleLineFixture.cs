using System;
using NUnit.Framework;

namespace ExCSS.Tests {
    [TestFixture]
    public class RuleLineFixture
    {
        [Test]
        public void Parser_Reads_One_Line()
        {
            var parser = new Parser();
            var css = parser.Parse("html{color:#000000;}");
            foreach (var rule in css.StyleRules)
            {
                Console.WriteLine("{0}:{1} {2}", rule.Line, rule.Col, rule);
            }
            Assert.AreEqual(css.StyleRules[0].Line, 1);
        }
        [Test]
        public void Parser_Reads_Two_Lines_With_Line_Breaks()
        {
            var parser = new Parser();
            var css = parser.Parse("\nhtml{color:#000000;}\n\ndiv{color:#ffffff;}");
            foreach (var rule in css.StyleRules)
            {
                Console.WriteLine("{0}:{1} {2}", rule.Line, rule.Col, rule);
            }
            Assert.AreEqual(css.StyleRules[0].Line, 2);
            Assert.AreEqual(css.StyleRules[1].Line, 4);
        }
    }
}