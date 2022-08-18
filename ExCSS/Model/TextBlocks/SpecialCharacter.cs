// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

namespace ExCSS.Model.TextBlocks
{
    internal class SpecialCharacter : CharacterBlock
    {
        internal static readonly SpecialCharacter Colon = new SpecialCharacter(Specification.Colon, GrammarSegment.Colon);
        internal static readonly SpecialCharacter Comma = new SpecialCharacter(Specification.Comma, GrammarSegment.Comma);
        internal static readonly SpecialCharacter Semicolon = new SpecialCharacter(Specification.Simicolon, GrammarSegment.Semicolon);
        internal static readonly SpecialCharacter Whitespace = new SpecialCharacter(Specification.Space, GrammarSegment.Whitespace);

        private SpecialCharacter(char specialCharacter, GrammarSegment type) : base(specialCharacter)
        {
            GrammarSegment = type;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
