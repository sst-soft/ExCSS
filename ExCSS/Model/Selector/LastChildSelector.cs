// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

namespace ExCSS
{
    internal sealed class LastChildSelector : BaseSelector, IToString
    {
        private LastChildSelector()
        { }

        private static LastChildSelector _instance;

        public static LastChildSelector Instance => _instance ?? (_instance = new LastChildSelector());

        public override string ToString(bool friendlyFormat, int indentation = 0)
        {
            return ":" + PseudoSelectorPrefix.PseudoLastchild;
        }
    }
}