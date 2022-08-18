// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

namespace ExCSS
{
    public abstract class ConditionalRule : AggregateRule
    {
        public virtual string Condition
        {
            get => string.Empty;
            set { }
        }
    }
}
