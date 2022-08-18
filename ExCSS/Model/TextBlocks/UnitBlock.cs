// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

using System.Globalization;

namespace ExCSS.Model.TextBlocks
{
    internal class UnitBlock : Block
    {
        private string _value;

        private UnitBlock(GrammarSegment type)
        {
            GrammarSegment = type;
        }

        internal float Value => float.Parse(_value, CultureInfo.InvariantCulture);

        internal string Unit { get; private set; }

        internal static UnitBlock Percentage(string value)
        {
            return new UnitBlock(GrammarSegment.Percentage) { _value = value, Unit = "%" };
        }

        internal static UnitBlock Dimension(string value, string dimension)
        {
            return new UnitBlock(GrammarSegment.Dimension) { _value = value, Unit = dimension };
        }

        public override string ToString()
        {
            return _value + Unit;
        }
    }
}
