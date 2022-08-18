// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

namespace ExCSS.Model.TextBlocks
{
    internal class SymbolBlock : Block
    {
        private SymbolBlock(GrammarSegment type)
        {
            GrammarSegment = type;
        }

        internal static SymbolBlock Function(string name)
        {
            return new SymbolBlock(GrammarSegment.Function) { Value = name };
        }

        internal static SymbolBlock Ident(string identifier)
        {
            return new SymbolBlock(GrammarSegment.Ident) { Value = identifier };
        }

        internal static SymbolBlock At(string name)
        {
            return new SymbolBlock(GrammarSegment.AtRule) { Value = name };
        }

        internal static SymbolBlock Hash(string characters)
        {
            return new SymbolBlock(GrammarSegment.Hash) { Value = characters };
        }

        internal string Value { get; private set; }

        public override string ToString()
        {
            switch (GrammarSegment)
            {
                case GrammarSegment.Hash:
                    return "#" + Value;

                case GrammarSegment.AtRule:
                    return "@" + Value;
            }

            return Value;
        }
    }
}
