// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class TermList : Term, IEnumerable<Term>
    {
        private readonly List<GrammarSegment> _separator = new List<GrammarSegment>();
        private readonly List<Term> _items = new List<Term>();

        public TermList()
        {
        }

        public TermList(params Term[] terms)
            : this(TermSeparator.Comma, terms)
        {
        }

        public TermList(TermSeparator separator, params Term[] terms)
        {
            for (var i = 0; i < terms.Length; ++i)
            {
                AddTerm(terms[i]);
                if (i != terms.Length - 1)
                {
                    AddSeparator(separator);
                }
            }
        }

        public void AddTerm(Term term)
        {
            _items.Add(term);
        }

        internal void AddSeparator(GrammarSegment termSepertor)
        {
            _separator.Add(termSepertor);
        }

        public void AddSeparator(TermSeparator termSepertor)
        {
            switch (termSepertor)
            {
                case TermSeparator.Comma:
                    _separator.Add(GrammarSegment.Comma);
                    break;
                case TermSeparator.Space:
                    _separator.Add(GrammarSegment.Whitespace);
                    break;
                case TermSeparator.Colon:
                    _separator.Add(GrammarSegment.Colon);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("termSepertor");
            }
        }

        public TermSeparator GetSeparatorAt(int index)
        {
            if (index >= _separator.Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            GrammarSegment grammarSegment = _separator[index];
            switch (grammarSegment)
            {
                case GrammarSegment.Whitespace:
                    return TermSeparator.Space;

                case GrammarSegment.Comma:
                    return TermSeparator.Comma;

                case GrammarSegment.Colon:
                    return TermSeparator.Colon;

                default:
                    throw new NotImplementedException();
            }
        }

        public int Length => _items.Count;

        [IndexerName("ListItems")]
        public Term this[int index] => index >= 0 && index < _items.Count ? _items[index] : null;

        public Term Item(int index)
        {
            return this[index];
        }

        public IEnumerator<Term> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            for (var i = 0; i < _items.Count; i++)
            {
                builder.Append(_items[i]);

                if (_separator.Count - 1 < i)
                {
                    continue;
                }

                switch (_separator[i])
                {
                    case GrammarSegment.Whitespace:
                        builder.Append(" ");
                        break;

                    case GrammarSegment.Comma:
                        builder.Append(",");
                        break;

                    case GrammarSegment.Colon:
                        builder.Append(":");
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }

            return builder.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /// <summary>
        /// exposed enumeration for the adding of separators into term lists
        /// </summary>
        public enum TermSeparator
        {
            Comma,
            Space,
            Colon,
        }

        #region Internal Methods
        internal void SetLastTerm(Term term)
        {
            if (Length == 0)
            {
                AddTerm(term);
            }
            else
            {
                _items[Length - 1] = term;
            }
        }
        #endregion
    }
}
