// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

using System.Text;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class AggregateSelectorList : SelectorList
    {
        public readonly string Delimiter;

        public AggregateSelectorList(string delimiter)
        {
            if (delimiter.Length > 1)
            {
                throw new ArgumentException("Expected single character delimiter or empty string", "delimiter");
            }

            Delimiter = delimiter;
        }

        public override string ToString(bool friendlyFormat, int indentation = 0)
        {
            var builder = new StringBuilder();

            foreach (BaseSelector selector in Selectors)
            {
                builder.Append(selector.ToString(friendlyFormat, indentation + 1));
                builder.Append(Delimiter);
            }

            if (Delimiter.Length <= 0)
            {
                return builder.ToString();
            }

            if (builder.Length > 0)
            {
                builder.Remove(builder.Length - 1, 1);
            }

            return builder.ToString();
        }
    }
}
