// https://www.hackerrank.com/contests/projecteuler/challenges/euler008

using System;

namespace Problem_8___Largest_product_in_a_series
{
    internal class Program
    {
        public static int LargestConsecutiveProduct(string num, int k)
        {
            var largestProduct = 0;

            for (var i = 0; i < num.Length - k; i++)
            {
                var curProduct = 1;
                foreach (var s in num.Substring(i, k))
                    curProduct *= s - '0';
                largestProduct = Math.Max(curProduct, largestProduct);
            }

            return largestProduct;
        }

        public static void Main(string[] args)
        {
            var n = 10;
            var k = 5;
            string num = "3675356291";

            Console.WriteLine(LargestConsecutiveProduct(num, k));
        }
    }
}