// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

namespace ExCSS.Model.TextBlocks
{
    internal abstract class CharacterBlock : Block
    {
        private readonly char _value;

        protected CharacterBlock()
        {
            _value = Specification.Null;
        }

        protected CharacterBlock(char value)
        {
            _value = value;
        }

        internal char Value => _value;
    }
}
