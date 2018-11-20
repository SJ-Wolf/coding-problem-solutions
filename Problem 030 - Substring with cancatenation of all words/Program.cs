using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_30___Substring_with_cancatenation_of_all_words
{
    public class Solution
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            var output = new List<int>();
            if (words.Length == 0)
                return output;
            var wordLength = words[0].Length;
            if (wordLength == 0)
                return output;

            // check if answer is possible
            if (s.Length < words.Length * wordLength)
                return output;

            //check word lengths are same
            if (words.Any(s1 => s1.Length != wordLength))
                return output;
            
            var curSubstr = new StringBuilder(s.Substring(0, wordLength));
            var wordsSet = new HashSet<string>(words);
            var wordsSeen = new HashSet<string>();
            var firstWordIndex = -1;

            for (var i = wordLength; i <= s.Length; i++)
            {
                var curSubstrString = curSubstr.ToString();
                if (wordsSet.Contains(curSubstrString))
                {
                    if (firstWordIndex == -1)
                        firstWordIndex = i - wordLength;

                    wordsSeen.Add(curSubstrString);
                    if (wordsSeen.Count == wordsSet.Count)
                    {
                        output.Add(firstWordIndex);
                    }

                    curSubstr.Clear();
                    if (i + wordLength > s.Length)
                        break;
                    curSubstr.Insert(0, s.Substring(i, wordLength));
                    i += wordLength - 1;
                }
                else
                {
                    if (i >= s.Length)
                        break;
                    var letter = s[i];
                    curSubstr.Remove(0, 1);
                    curSubstr.Append(letter);
                    firstWordIndex = -1;
                    wordsSeen.Clear();
                }
            }

            return output;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = new Solution();
            Console.WriteLine(string.Join(", ", s.FindSubstring("wordgoodgoodgoodbestword", new string[] {"4"})));
        }
    }
}