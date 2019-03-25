/* TrieWithNoChildren.cs
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
    /// This holds a leaf of the Trie Tree
    /// </summary>
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Is the leaf the end of the string?
        /// </summary>
        private bool _emptyString;

        /// <summary>
        /// Adds a word to the Trie
        /// </summary>
        /// <param name="s">word to add</param>
        /// <returns>the new trie</returns>
        public ITrie Add(string s)
        {
            if (s.Length == 0)
            {
                _emptyString = true;
            }
            else if (s[0] > 'z' || s[0] < 'a')
            {
                throw new ArgumentException();
            }
            else
            {
                return new TrieWithOneChild(s, _emptyString);
            }
            return this;
        }

        /// <summary>
        /// checks if word is in Trie
        /// </summary>
        /// <param name="s">The word to find</param>
        /// <returns>bool if word is in Trie</returns>
        public bool Contains(string s)
        {
            if (s.Length == 0)
            {
                return _emptyString;
            }
            return false;
        }
    }
}
