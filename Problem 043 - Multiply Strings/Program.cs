using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Problem_43___Multiply_Strings
{
    public class Solution
    {
        public static LinkedList<char> Multiply(string num, char digit1, int numZeroes = 0)
        {
            if (digit1 == '0' || (num.Length == 1 && num[0] == '0'))
                return new LinkedList<char>(new []{'0'});
            var x = digit1 - '0';
            var output = new LinkedList<char>();
            var carry = 0;
            foreach (var digit2 in num.Reverse())
            {
                var y = digit2 - '0';
                var z = x * y + carry;
                int remainder;
                carry = Math.DivRem(z, 10, out remainder);

                output.AddFirst((char) (remainder + '0'));
            }

            if (output.Count == 0)
                output.AddFirst('0');
            else
            {
                for (var i = 0; i < numZeroes; i++)
                    output.AddLast('0');
            }

            if (carry > 0)
            {
                output.AddFirst((char) (carry + '0'));
            }

            return output;
        }

        public static LinkedList<char> Add(LinkedList<char> num1, LinkedList<char> num2)
        {
            var result = new LinkedList<char>();

            using (var num1Enumerator = num1.Reverse().GetEnumerator())
            {
                using (var num2Enumerator = num2.Reverse().GetEnumerator())
                {
                    var carry = 0;
                    while (true)
                    {
                        var isNextNum1 = num1Enumerator.MoveNext();
                        var isNextNum2 = num2Enumerator.MoveNext();
                        if (!isNextNum1 && !isNextNum2 && carry == 0)
                            break;
                        var x = isNextNum1 ? num1Enumerator.Current - '0' : 0;
                        var y = isNextNum2 ? num2Enumerator.Current - '0' : 0;
                        var z = x + y + carry;
                        int remainder;
                        carry = Math.DivRem(z, 10, out remainder);
                        result.AddFirst((char) (remainder + '0'));
                    }
                }
            }

            if (result.Count == 0)
                result.AddLast('0');
            return result;
        }

        public string Multiply(string num1, string num2)
        {
            var result = new LinkedList<char>();
            for (int i = 0; i < num2.Length; i++)
            {
                var x = Multiply(num1, num2[num2.Length - i - 1], i);
                result = Add(result, x);
            }

            return string.Join("", result);
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var num1 = "9";
            var num2 = "9";
            Console.WriteLine($"{new Solution().Multiply(num1, num2)} | {int.Parse(num1) * int.Parse(num2)}");
        }
    }
}