// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

using ExCSS.Model.Extensions;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class Property
    {
        private Term _term;
        private bool _important;
        private readonly int _line;

        public Property(string name, int line)
        {
            Name = name;
            _line = line;
        }

        public string Name { get; private set; }

        public Term Term
        {
            get => _term;
            set => _term = value;
        }

        public bool Important
        {
            get => _important;
            set => _important = value;
        }

        public int Line => _line;

        public override string ToString()
        {
            return ToString(false);
        }

        public string ToString(bool friendlyFormat, int indentation = 0)
        {
            var value = Name + ":" + _term;

            if (_important)
            {
                value += " !important";
            }

            return value.Indent(friendlyFormat, indentation);
        }
    }
}
