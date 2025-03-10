﻿// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

using ExCSS.Model;
using ExCSS.Model.Extensions;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class FontFaceRule : RuleSet, ISupportsDeclarations
    {
        private readonly StyleDeclaration _declarations;

        public FontFaceRule()
        {
            _declarations = new StyleDeclaration();
            RuleType = RuleType.FontFace;
        }

        internal FontFaceRule AppendRule(Property rule)
        {
            _declarations.Properties.Add(rule);
            return this;
        }

        public StyleDeclaration Declarations => _declarations;

        public string FontFamily
        {
            get => _declarations.GetPropertyValue("font-family");
            set => _declarations.SetProperty("font-family", value);
        }

        public string Src
        {
            get => _declarations.GetPropertyValue("src");
            set => _declarations.SetProperty("src", value);
        }

        public string FontStyle
        {
            get => _declarations.GetPropertyValue("font-style");
            set => _declarations.SetProperty("font-style", value);
        }

        public string FontWeight
        {
            get => _declarations.GetPropertyValue("font-weight");
            set => _declarations.SetProperty("font-weight", value);
        }

        public string Stretch
        {
            get => _declarations.GetPropertyValue("stretch");
            set => _declarations.SetProperty("stretch", value);
        }

        public string UnicodeRange
        {
            get => _declarations.GetPropertyValue("unicode-range");
            set => _declarations.SetProperty("unicode-range", value);
        }

        public string FontVariant
        {
            get => _declarations.GetPropertyValue("font-variant");
            set => _declarations.SetProperty("font-variant", value);
        }

        public string FeatureSettings
        {
            get => _declarations.GetPropertyValue("font-feature-settings");
            set => _declarations.SetProperty("font-feature-settings", value);
        }

        public override string ToString()
        {
            return ToString(false);
        }

        public override string ToString(bool friendlyFormat, int indentation = 0)
        {
            return "@font-face{".NewLineIndent(friendlyFormat, indentation) +
                _declarations.ToString(friendlyFormat, indentation) +
                "}".NewLineIndent(friendlyFormat, indentation);
        }
    }
}
