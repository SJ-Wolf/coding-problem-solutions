using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_056___Merge_Intervals
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var intervals = new List<Interval>()
            {
//                new Interval(1, 3),
//                new Interval(2, 6),
//                new Interval(8, 10),
//                new Interval(15, 18),
            };
            foreach (var x in new Solution().Merge(intervals))
            {
                Console.WriteLine(x.ToString());
            }
        }
    }


    public class Interval
    {
        public int start;
        public int end;

        public Interval()
        {
            start = 0;
            end = 0;
        }

        public Interval(int s, int e)
        {
            start = s;
            end = e;
        }

        public override string ToString()
        {
            return $"[{start}, {end}]";
        }
    }

    public class Solution
    {
        public static bool CanCombine(Interval interval_1, Interval interval_2)
        {
            if (interval_1.end <= interval_2.start)
                return true;
            return false;
        }

        public IList<Interval> Merge(IList<Interval> intervals)
        {
//            intervals = intervals.OrderBy(i => i.start).ToArray();
            if (intervals == null || intervals.Count <= 1)
                return intervals;
            
            var combinedIntervals = new List<Interval>();

            Interval prevInterval = null;
            foreach (var interval in intervals.OrderBy(i => i.start))
            {
                var combination = Combine(prevInterval, interval);
                if (combination == null)
                {
                    combinedIntervals.Add(prevInterval);
                    prevInterval = interval;
                }
                else
                {
                    prevInterval = combination;
                }
            }

            if ((prevInterval != null && combinedIntervals.Count == 0)
                || combinedIntervals[combinedIntervals.Count - 1] != prevInterval)
                combinedIntervals.Add(prevInterval);

            return combinedIntervals;
        }

        public static Interval Combine(Interval interval1, Interval interval2)
        {
            if (interval1 == null)
                return interval2;
            if (interval2 == null)
                return interval1;
            if (Combinable(interval1, interval2))
                return new Interval(Math.Min(interval1.start, interval2.start),
                    Math.Max(interval1.end, interval2.end));
            return null;
        }

        public static bool Combinable(Interval interval1, Interval interval2)
        {
            if (interval1 == null || interval2 == null)
                return true;
            return interval1.start <= interval2.start && interval1.end >= interval2.start
                   || interval2.start <= interval1.start && interval2.end >= interval1.start;
        }
    }
}