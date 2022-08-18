// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

namespace ExCSS.Model.TextBlocks
{
    internal class PipeBlock : Block
    {
        private readonly static PipeBlock TokenBlock;

        static PipeBlock()
        {
            TokenBlock = new PipeBlock();
        }

        private PipeBlock()
        {
            GrammarSegment = GrammarSegment.Column;
        }

        internal static PipeBlock Token => TokenBlock;

        public override string ToString()
        {
            return "||";
        }
    }
}
