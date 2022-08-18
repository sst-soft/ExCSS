// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

using System.Text;
using ExCSS.Model.Extensions;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public sealed class StyleSheet
    {
        private readonly List<RuleSet> _rules;

        public StyleSheet()
        {
            _rules = new List<RuleSet>();
            Errors = new List<StylesheetParseError>();
        }

        public List<RuleSet> Rules => _rules;

        public StyleSheet RemoveRule(int index)
        {
            if (index >= 0 && index < _rules.Count)
            {
                _rules.RemoveAt(index);
            }

            return this;
        }

        public StyleSheet InsertRule(string rule, int index)
        {
            if (index < 0 || index > _rules.Count)
            {
                return this;
            }

            RuleSet value = Parser.ParseRule(rule);
            _rules.Insert(index, value);

            return this;
        }

        public IList<StyleRule> StyleRules => Rules.Where(r => r is StyleRule).Cast<StyleRule>().ToList();

        public IList<CharacterSetRule> CharsetDirectives => GetDirectives<CharacterSetRule>(RuleType.Charset);

        public IList<ImportRule> ImportDirectives => GetDirectives<ImportRule>(RuleType.Import);

        public IList<FontFaceRule> FontFaceDirectives => GetDirectives<FontFaceRule>(RuleType.FontFace);

        public IList<KeyframesRule> KeyframeDirectives => GetDirectives<KeyframesRule>(RuleType.Keyframes);

        public IList<MediaRule> MediaDirectives => GetDirectives<MediaRule>(RuleType.Media);

        public IList<PageRule> PageDirectives => GetDirectives<PageRule>(RuleType.Page);

        public IList<SupportsRule> SupportsDirectives => GetDirectives<SupportsRule>(RuleType.Supports);

        public IList<NamespaceRule> NamespaceDirectives => GetDirectives<NamespaceRule>(RuleType.Namespace);

        private IList<T> GetDirectives<T>(RuleType ruleType)
        {
            return Rules.Where(r => r.RuleType == ruleType).Cast<T>().ToList();
        }

        public List<StylesheetParseError> Errors { get; private set; }

        public override string ToString()
        {
            return ToString(false);
        }

        public string ToString(bool friendlyFormat, int indentation = 0)
        {
            var builder = new StringBuilder();

            foreach (RuleSet rule in _rules)
            {
                builder.Append(rule.ToString(friendlyFormat, indentation).TrimStart() + (friendlyFormat ? Environment.NewLine : ""));
            }

            return builder.TrimFirstLine().TrimLastLine().ToString();
        }
    }
}
