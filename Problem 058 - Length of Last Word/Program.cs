using System;

namespace Problem_058___Length_of_Last_Word
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().LengthOfLastWord("Hello World"));
        }
    }

    public class Solution
    {
        public int LengthOfLastWord(string s)
        {
            s = s.TrimEnd();
            var idxLastSpace = s.LastIndexOf(' ');
            return (s.Length - idxLastSpace - 1);
        }
    }
}