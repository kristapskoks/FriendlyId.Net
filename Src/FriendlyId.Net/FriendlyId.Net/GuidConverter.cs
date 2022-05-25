using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using FriendlyId.Net;

namespace FriendlyId.Net
{
    internal static class GuidConverter
    {
        internal static BigInteger ToBigInteger(Guid guid)
        {
            var most = guid.GetMostSignificantBits();
            var least = guid.GetLeastSignificantBits();
            return BigIntPairing.Pair(most, least);
        }
        public static Guid ToGuid(this BigInteger value)
        {
            var unpaired = BigIntPairing.UnPair(value);
            var uuid = new UUID(unpaired[0], unpaired[1]);
            var uuidString = uuid.ToString();
            return Guid.Parse(uuidString);
        }


        internal static long GetMostSignificantBits(this Guid guid)
        {
            var bytes = guid.ToByteArray();
            if (bytes.Length != 16)
            {
                throw new Exception("data must be 16 bytes in length");
            }
            long msb = 0;
            for (int i = 0; i < 8; i++)
                msb = (msb << 8) | (bytes[i] & 0xff);

            return msb;
        }

        internal static long GetLeastSignificantBits(this Guid guid)
        {
            var bytes = guid.ToByteArray();
            if (bytes.Length != 16)
            {
                throw new Exception("data must be 16 bytes in length");
            }
            long lsb = 0;
            for (int i = 8; i < 16; i++)
                lsb = (lsb << 8) | (bytes[i] & 0xff);

            return lsb;
        }
    }
}
