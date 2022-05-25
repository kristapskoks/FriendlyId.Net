using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FriendlyId.Net
{
    internal class UUID
    {
        private BigInteger _mostSigBits;
        private BigInteger _leastSigBits;
        public UUID(BigInteger mostSigBits, BigInteger leastSigBits)
        {
            _mostSigBits = mostSigBits;
            _leastSigBits = leastSigBits;
        }

        public override string ToString()
        {
            return (Reverse(Digits((long)_mostSigBits >> 32, 8)) + "-" +
                    Reverse(Digits((long)_mostSigBits >> 16, 4)) + "-" +
                    Reverse(Digits((long)_mostSigBits, 4)) + "-" +
                    Digits((long)_leastSigBits >> 48, 4) + "-" +
                    Digits((long)_leastSigBits, 12));
        }
        private string Reverse(string str)
        {
            var subArray = SplitInParts(str, 2);
            subArray = subArray.Reverse();
            var result = "";
            foreach (var subString in subArray)
            {
                result += subString;
            }
            return result;
        }

        private static IEnumerable<string> SplitInParts(string s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", nameof(partLength));

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }
        private static string Digits(long val, int digits)
        {
            long hi = 1L << (digits * 4);
            return string.Format("{0:X}", (hi | (val & (hi - 1)))).Substring(1);
        }
    }
}
