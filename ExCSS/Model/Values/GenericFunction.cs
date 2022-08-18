// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.


// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class GenericFunction : Term
    {
        public string Name { get; set; }
        public TermList Arguments { get; set; }

        public GenericFunction(string name, IEnumerable<Term> arguments)
        {
            Name = name;
            var list = new TermList();
            foreach (Term term in arguments)
            {
                list.AddTerm(term);
            }
            Arguments = list;
        }

        public override string ToString()
        {
            return Name + "(" + Arguments + ")";
        }
    }
}