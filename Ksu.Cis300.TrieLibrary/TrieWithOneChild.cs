/* TrieWithOneChild.cs
 * Author: Luke Falk
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// A Trie node with one child
    /// </summary>
    class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Whether the node contains a word
        /// </summary>
        private bool _emptyString;

        /// <summary>
        /// the only child this node leads to
        /// </summary>
        private ITrie _onlyChild;

        /// <summary>
        /// The label of the only child
        /// </summary>
        private char _childLabel;

        /// <summary>
        /// Constructor of a one child Trie Node
        /// </summary>
        /// <param name="s">the string to add to the Trie</param>
        /// <param name="b">Whether this node holds a word</param>
        public TrieWithOneChild(string s, bool b)
        {
            if (s.Length == 0)
            {
                throw new ArgumentException();
            }
            _emptyString = b;
            _childLabel = s[0];
            _onlyChild = new TrieWithNoChildren();
            _onlyChild = _onlyChild.Add(s.Substring(1));
        }

        /// <summary>
        /// Adds a word to the Trie
        /// </summary>
        /// <param name="s">The word to add</param>
        /// <returns>The new Trie</returns>
        public ITrie Add(string s)
        {
            if (s.Length == 0)
            {
                _emptyString = true;
            }
            else if (s[0] == _childLabel)
            {
                _onlyChild = _onlyChild.Add(s.Substring(1));
            }
            else if (s[0] > 'z' || s[0] < 'a')
            {
                throw new ArgumentException();
            }
            else
            {
                return new TrieWithManyChildren(s, _emptyString, _childLabel, _onlyChild);
            }
            return this;
        }

        /// <summary>
        /// Finds a word inside the Trie
        /// </summary>
        /// <param name="s">Word to find</param>
        /// <returns>a bool if the word is in the Trie</returns>
        public bool Contains(string s)
        {
            if (s.Length == 0)
            {
                return _emptyString;
            }
            else if (s[0] == _childLabel)
            {
                return _onlyChild.Contains(s.Substring(1));
            }
            return false;
        }
    }
}
