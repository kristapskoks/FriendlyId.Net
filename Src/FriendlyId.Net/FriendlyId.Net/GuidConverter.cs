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
            byte[] guidBytes = guid.ToByteArray();
            byte[] uuidBytes =
            {
                guidBytes[6],
                guidBytes[7],
                guidBytes[4],
                guidBytes[5],
                guidBytes[0],
                guidBytes[1],
                guidBytes[2],
                guidBytes[3],
                guidBytes[15],
                guidBytes[14],
                guidBytes[13],
                guidBytes[12],
                guidBytes[11],
                guidBytes[10],
                guidBytes[9],
                guidBytes[8]
            };
            var most = BitConverter.ToInt64(uuidBytes, 0);
            var least = BitConverter.ToInt64(uuidBytes, 8);
            return BigIntPairing.Pair(most, least);
        }
        public static Guid ToGuid(this BigInteger value)
        {
            var unpaired = BigIntPairing.UnPair(value);

            byte[] uuidMostSignificantBytes = BitConverter.GetBytes((long)unpaired[0]);
            byte[] uuidLeastSignificantBytes = BitConverter.GetBytes((long)unpaired[1]);
            byte[] guidBytes =
            {
                uuidMostSignificantBytes[4],
                uuidMostSignificantBytes[5],
                uuidMostSignificantBytes[6],
                uuidMostSignificantBytes[7],
                uuidMostSignificantBytes[2],
                uuidMostSignificantBytes[3],
                uuidMostSignificantBytes[0],
                uuidMostSignificantBytes[1],
                uuidLeastSignificantBytes[7],
                uuidLeastSignificantBytes[6],
                uuidLeastSignificantBytes[5],
                uuidLeastSignificantBytes[4],
                uuidLeastSignificantBytes[3],
                uuidLeastSignificantBytes[2],
                uuidLeastSignificantBytes[1],
                uuidLeastSignificantBytes[0]
            };
            return new Guid(guidBytes);
        }
    }
}
