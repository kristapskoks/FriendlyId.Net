using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FriendlyId.Net
{
    internal static class Base62
    {
        private static BigInteger BASE = new BigInteger(62);
        private static string DIGITS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";


        internal static string Encode(BigInteger number)
        {
            if (number.CompareTo(BigInteger.Zero) < 0)
            {
                throw new ArgumentException("number must not be negative");
            }
            StringBuilder result = new StringBuilder();

            while (number.CompareTo(BigInteger.Zero) > 0)
            {
                number = BigInteger.DivRem(number, BASE, out var remainder);
                int digit = ((int)remainder);
                result.Insert(0, DIGITS[digit]);

            }
            return result.Length == 0 ? DIGITS.Substring(0, 1) : result.ToString();
        }

        internal static BigInteger Decode(string idString) => Decode(idString, 128);

        private static BigInteger Decode(string idString, int bitLimit)
        {
            if (string.IsNullOrEmpty(idString))
            {
                throw new ArgumentException("Friendly Id string cannot be empty");
            }

            return Enumerable.Range(0, idString.Length)
                   .Select(x => BigInteger.Multiply(DIGITS.IndexOf(idString[idString.Length - x - 1]), BigInteger.Pow(BASE, x)))
                   .Aggregate(BigInteger.Zero, (acc, value) =>
                   {
                       BigInteger sum = acc + value;
                       if (bitLimit > 0 && sum.GetBitLength() > bitLimit)
                       {
                           throw new ArgumentException($"String '{idString}' contains more than 128bit information");
                       }
                       return sum;
                   });

        }

    }
}
