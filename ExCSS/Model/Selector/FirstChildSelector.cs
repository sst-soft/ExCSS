// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

namespace ExCSS
{
    internal sealed class FirstChildSelector : BaseSelector, IToString
    {
        private FirstChildSelector()
        { }

        private static FirstChildSelector _instance;

        public static FirstChildSelector Instance => _instance ?? (_instance = new FirstChildSelector());

        public override string ToString(bool friendlyFormat, int indentation = 0)
        {
            return ":" + PseudoSelectorPrefix.PseudoFirstchild;
        }
    }
}