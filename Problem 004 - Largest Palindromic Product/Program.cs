using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4___Largest_Palindromic_Product
{
    internal class Program
    {
        public static bool IsPalindrome(int n)
        {
            var s = n.ToString();
            var curIndex = 0;
            foreach (var row in Enumerable.Zip(s, s.Reverse(), (c, c1) => new {c, c1}))
            {
                if (row.c != row.c1)
                    return false;

                curIndex++;
                if (curIndex >= s.Length / 2)
                    break;
            }

            return true;
        }

        public static int LargestPalindrome(int n)
        {
            int largestPal = 0;
            var minNum = 100;

            for (int i = 999; i >= minNum; i--)
            {
                for (int j = Math.Min((n - 1) / i, 999); j >= i; j--)
                {
                    var z = i * j;
                    if (IsPalindrome(z))
                    {
                        largestPal = Math.Max(largestPal, z);
                        minNum = largestPal / 999;
                        break;
                    }
                }
            }

            return largestPal;
        }

        public static int[] Palindromes(int max)
        {
            var results = new List<int>();

            for (int i = 999; i >= 100; i--)
            {
                for (int j = Math.Min((max - 1) / i, 999); j >= i; j--)
                {
                    var z = i * j;
                    if (z < max && IsPalindrome(z))
                    {
                        results.Add(z);
//                        break;
                    }
                }
            }

            var resultsArr = results.Distinct().ToArray();
            Array.Sort(resultsArr);
            return resultsArr;
        }

        public static List<int> LargestPalindromes(int[] largestNums)
        {
            var results = new List<int>();
            var max = largestNums.Max();
            var palindromes = Palindromes(max);
            
            foreach (var n in largestNums)
            {
                var idx = Array.BinarySearch(palindromes, n-1);
                if (idx < 0)
                    idx = ~idx - 1;
                results.Add(palindromes[idx]);
            }

            return results;
        }

        public static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            var inputN = new int[t];
            for (int a0 = 0; a0 < t; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                if (t > 2)
                    inputN[a0] = n;
                else
                {
                    Console.WriteLine(LargestPalindrome(n));
                }
            }

            if (t > 2)
                foreach (var p in LargestPalindromes(inputN))
                    Console.WriteLine(p);
            
//            Random r = new Random();
//            var inputArr = new int[50];
//            for (int i = 0; i < inputArr.Length; i++)
//            {
//                var n = r.Next(101101, 1000000);
//                inputArr[i] = n;
//            }
//
//            var results1 = LargestPalindromes(inputArr);
//            var results2 = inputArr.Select(LargestPalindrome).ToList();
//            for (int i = 0; i < results1.Count; i++)
//                if (results1[i] != results2[i])
//                    Console.WriteLine(i);
        }

        public static int LargestPalindrome_Debug(int n)
        {
            int largestPal = 0;
            var minNum = 10;
            var d = new SortedSet<string>();

            for (int i = 99; i >= minNum; i--)
            {
                for (int j = Math.Min(n / i, 99); j >= i; j--)
                {
                    var z = i * j;

                    var s = $"{z:0000}={i:00}*{j:00}";
                    d.Add(s);

                    if (IsPalindrome(z))
                    {
                        largestPal = Math.Max(largestPal, z);
                        minNum = largestPal / 99;
                        break;
                    }
                }
            }

//            foreach (var x in d)
//            {
//                Console.WriteLine(x);
//            }
            Console.WriteLine(d.Count);

            return largestPal;
        }
    }
}