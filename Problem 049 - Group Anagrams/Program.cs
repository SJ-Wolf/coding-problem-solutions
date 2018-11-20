using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_049___Group_Anagrams
{
    public class MyString
    {
        public readonly string Value;
        private string _valueSorted;
        private readonly int _hashCode;

        public MyString(string s)
        {
            Value = s;

            foreach (var c in Value)
            {
                _hashCode += c.GetHashCode();
            }

            _hashCode *= 486187739;
        }

        public override int GetHashCode()
        {
            return _hashCode;
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, this))
                return true;

            var other = o as MyString;

            if (null == other)
                return false;

            return other.ValueSorted.Equals(ValueSorted);
        }

        public string ValueSorted
        {
            get
            {
                if (_valueSorted == null)
                {
                    Console.WriteLine(Value);
                    var s = Value.ToCharArray();
                    Array.Sort(s);
                    _valueSorted = new string(s);
                }

                return _valueSorted;
            }
        }
    }

    internal class Program
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var d = new Dictionary<MyString, IList<string>>();
            foreach (var s in strs)
            {
                var hashSet = new MyString(s);
                IList<string> existing = null;
                d.TryGetValue(hashSet, out existing);
                if (existing == null)
                {
                    d.Add(hashSet, new List<string>(new[] {s}));
                }
                else
                {
                    d[hashSet].Add(s);
                }
            }

            return d.Values.ToList();
        }

        public static void Main(string[] args)
        {
            var input = new string[] {"eat", "tea", "tan", "ate", "nat", "bat"};
        }
    }
}