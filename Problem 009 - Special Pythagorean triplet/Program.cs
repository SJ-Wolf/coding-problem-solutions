using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_9___Special_Pythagorean_triplet
{
    internal class Program
    {
        public static List<Tuple<int, int, int, int, int>> GetTriplets(int n)
        {
            var squares = new int[n];
            for (int i = 0; i < n; i++)
                squares[i] = i * i;
            var triplets = new List<Tuple<int, int, int, int, int>>();

            for (int a = 1;; a++)
            {
                for (int b = a + 1;; b++)
                {
                    var c_sqr = a * a + b * b;
                    var c_idx = Array.BinarySearch(squares, c_sqr);
                    if (c_idx >= 0)
                    {
                        triplets.Add(new Tuple<int, int, int, int, int>(a, b, c_idx, a + b + c_idx, a * b * c_idx));
                    }
                    else
                    {
                        c_idx = ~c_idx - 1;
                    }

                    if (a + b + c_idx > n)
                    {
                        break;
                    }
                }

                if (a + 1 + 1 > n)
                {
                    break;
                }
            }

            return triplets;
        }

        public static void Main(string[] args)
        {
            var triplets = GetTriplets(3000);
            triplets.Sort((tuple, tuple1) => tuple.Item4.CompareTo(tuple1.Item4));
            
            int testCases = Convert.ToInt32(Console.ReadLine());
            for(int a0 = 0; a0 < testCases; a0++){
                int n = Convert.ToInt32(Console.ReadLine());
                var relevantTriplets = triplets.Where(t => t.Item4 == n).ToArray();
                if (relevantTriplets.Length > 0)
                {
                    Console.WriteLine(relevantTriplets.Max(t => t.Item5));
                }
                else
                {
                    Console.WriteLine(-1);
                }
            }
           
        }
    }
}