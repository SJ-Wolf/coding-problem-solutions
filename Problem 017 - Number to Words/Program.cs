using System;

namespace Problem_017___Number_to_Words
{
    internal class Program
    {
        public static string TwoDigitsToString(string numString)
        {
            var num = Convert.ToInt32(numString);
            var lookup = new string[]
            {
                "",
                "One",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven",
                "Eight",
                "Nine",
                "Ten",
                "Eleven",
                "Twelve",
                "Thirteen",
                "Fourteen",
                "Fifteen",
                "Sixteen",
                "Seventeen",
                "Eighteen",
                "Nineteen",
            };
            if (num < lookup.Length)
                return lookup[num];

            return "";
        }

        public static void Main(string[] args)
        {
        }
    }
}