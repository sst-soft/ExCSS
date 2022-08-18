// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

using System.Collections;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public abstract class SelectorList : BaseSelector, IEnumerable<BaseSelector>
    {
        protected List<BaseSelector> Selectors;

        protected SelectorList()
        {
            Selectors = new List<BaseSelector>();
        }

        public int Length => Selectors.Count;

        public BaseSelector this[int index]
        {
            get => Selectors[index];
            set => Selectors[index] = value;
        }

        public SelectorList AppendSelector(BaseSelector selector)
        {
            Selectors.Add(selector);
            return this;
        }

        public SelectorList RemoveSelector(SimpleSelector selector)
        {
            Selectors.Remove(selector);
            return this;
        }

        public SelectorList ClearSelectors()
        {
            Selectors.Clear();
            return this;
        }

        public IEnumerator<BaseSelector> GetEnumerator()
        {
            return Selectors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Selectors).GetEnumerator();
        }

        public override abstract string ToString(bool friendlyFormat, int indentation = 0);
    }
}
