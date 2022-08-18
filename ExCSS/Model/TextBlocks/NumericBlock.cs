// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

using System.Globalization;

namespace ExCSS.Model.TextBlocks
{
    internal class NumericBlock : Block
    {
        private readonly string _data;

        internal NumericBlock(string number)
        {
            _data = number;
            GrammarSegment = GrammarSegment.Number;
        }

        public float Value => float.Parse(_data, CultureInfo.InvariantCulture);

        public override string ToString()
        {
            return _data;
        }
    }
}
