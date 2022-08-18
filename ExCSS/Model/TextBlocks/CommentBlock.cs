// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

namespace ExCSS.Model.TextBlocks
{
    internal class CommentBlock : Block
    {
        private readonly static CommentBlock OpenBlock;
        private readonly static CommentBlock CloseBlock;

        static CommentBlock()
        {
            OpenBlock = new CommentBlock { GrammarSegment = GrammarSegment.CommentOpen };
            CloseBlock = new CommentBlock { GrammarSegment = GrammarSegment.CommentClose };
        }

        private CommentBlock()
        {
        }


        internal static CommentBlock Open => OpenBlock;

        internal static CommentBlock Close => CloseBlock;

        public override string ToString()
        {
            return GrammarSegment == GrammarSegment.CommentOpen ? "<!--" : "-->";
        }
    }
}
