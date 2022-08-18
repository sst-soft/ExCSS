// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

namespace ExCSS.Model.TextBlocks
{
    internal abstract class Block
    {
        internal int Line { get; set; }
        internal GrammarSegment GrammarSegment { get; set; }

        internal static PipeBlock Column => PipeBlock.Token;

        internal static DelimiterBlock Delim(char value)
        {
            return new DelimiterBlock(value);
        }

        internal static NumericBlock Number(string value)
        {
            return new NumericBlock(value);
        }

        internal static RangeBlock Range(string start, string end)
        {
            return new RangeBlock().SetRange(start, end);
        }
    }
}
