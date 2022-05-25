using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FriendlyId.Net
{
    internal static class BigIntPairing
    {
        private static BigInteger HALF => BigInteger.One << 64;
        private static BigInteger MAX_LONG => new BigInteger(long.MaxValue);


        private static BigInteger ToUnsiged(this BigInteger value) => value.Sign < 0 ? value + HALF : value;
        private static BigInteger ToSigned(this BigInteger value) => MAX_LONG.CompareTo(value) < 0 ? value - HALF : value;

        internal static BigInteger Pair(BigInteger hi, BigInteger lo)
        {
            var unsignedLo = lo.ToUnsiged();
            var unsignedHi = hi.ToUnsiged();
            return unsignedLo + (unsignedHi * HALF);
        }

        internal static BigInteger[] UnPair(BigInteger value)
        {
            BigInteger quotient = BigInteger.DivRem(value, HALF, out var remainder);
            var signedHi = quotient.ToSigned();
            var signedLo = remainder.ToSigned();
            return new BigInteger[2] { signedHi, signedLo };
        }
    }
}
