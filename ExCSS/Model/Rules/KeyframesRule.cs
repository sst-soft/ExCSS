// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

using ExCSS.Model.Extensions;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class KeyframesRule : RuleSet, IRuleContainer
    {
        private readonly List<RuleSet> _ruleSets;
        private string _identifier;
        private readonly string _ruleName;

        public KeyframesRule(string ruleName = null)
        {
            _ruleName = ruleName ?? "keyframes";
            _ruleSets = new List<RuleSet>();
            RuleType = RuleType.Keyframes;
        }

        public string Identifier
        {
            get => _identifier;
            set => _identifier = value;
        }

        //TODO change to "keyframes"
        public List<RuleSet> Declarations => _ruleSets;

        public override string ToString()
        {
            return ToString(false);
        }

        public override string ToString(bool friendlyFormat, int indentation = 0)
        {
            var join = friendlyFormat ? "".NewLineIndent(true, indentation) : "";

            IEnumerable<string> declarationList = _ruleSets.Select(d => d.ToString(friendlyFormat, indentation + 1));
#if BUILD_FOR_UNITY
			var declarations = string.Join(join, declarationList.ToArray());
#else
            var declarations = string.Join(join, declarationList);
#endif

            return ("@" + _ruleName + " " + _identifier + "{").NewLineIndent(friendlyFormat, indentation) +
                declarations.NewLineIndent(friendlyFormat, indentation) +
                "}".NewLineIndent(friendlyFormat, indentation);
        }
    }
}
