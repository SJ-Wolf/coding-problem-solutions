using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Problem_057___Instert_Interval
{
    internal class Program
    {
        public static void Main(string[] args)
        {
//            var intervals = new List<Interval>()
//            {
//                new Interval(1, 3),
//                new Interval(6, 9),
//            };
//            var intervals = new List<Interval>()
//            {
//                new Interval(1, 2),
//                new Interval(3, 5),
//                new Interval(6, 7),
//                new Interval(8, 10),
//                new Interval(12, 16),
//            };
            var intervals = new List<Interval>()
            {
                new Interval(3, 5),
                new Interval(12, 15),
            };
            foreach (var x in new Solution().Insert(intervals, new Interval(6, 6)))
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

    public class IntervalComparator : IComparer<Interval>
    {
        public int Compare(Interval a, Interval b)
        {
            return a.start.CompareTo(b.start);
        }
    }

    public class Solution
    {
        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
        {
            if (intervals.Count == 0)
            {
                return new List<Interval>() {newInterval};
            }

            var firstCombinableIndex = -1;
            var lastCombinableIndex = -1;

            var insertPosition = -1;
            var prevIntervalStart = int.MinValue;
            for (var i = 0; i < intervals.Count; i++)
            {
                if (newInterval.start > prevIntervalStart && newInterval.start < intervals[i].start)
                    insertPosition = i;
                if (Combinable(intervals[i], newInterval))
                {
                    firstCombinableIndex = i;
                    break;
                }

                prevIntervalStart = intervals[i].start;
            }

            if (firstCombinableIndex == -1)
            {
                var output1 = new List<Interval>(intervals);
                if (insertPosition == -1)
                    if (newInterval.start > intervals[0].start)
                        insertPosition = intervals.Count;
                    else
                        insertPosition = 0;
                output1.Insert(insertPosition, newInterval);
                return output1;
            }

            lastCombinableIndex = firstCombinableIndex;
            while (lastCombinableIndex + 1 < intervals.Count &&
                   Combinable(intervals[lastCombinableIndex + 1], newInterval))
                lastCombinableIndex++;

            if (firstCombinableIndex == lastCombinableIndex)
            {
                intervals[firstCombinableIndex] = Combine(newInterval, intervals[firstCombinableIndex]);
                return intervals;
            }

            var output = new Interval[intervals.Count - (lastCombinableIndex - firstCombinableIndex)];
            var outputIdx = 0;
            for (int i = 0; i < intervals.Count; i++)
            {
                if (i == firstCombinableIndex)
                {
                    output[outputIdx] = newInterval;
                }

                if (i >= firstCombinableIndex && i <= lastCombinableIndex)
                {
                    output[outputIdx] = Combine(output[outputIdx], intervals[i]);
                    if (i == lastCombinableIndex)
                        outputIdx++;
                    if (outputIdx == output.Length)
                        break;
                }
                else
                {
                    output[outputIdx] = intervals[i];
                    outputIdx++;
                }
            }

            return output;
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