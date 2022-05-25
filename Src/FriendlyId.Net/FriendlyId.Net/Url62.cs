using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyId.Net
{
    internal static class Url62
    {
        internal static string Encode(Guid guid)
        {
            var pair = GuidConverter.ToBigInteger(guid);
            return Base62.Encode(pair);
        }

        internal static Guid Decode(string id)
        {
            var decoded = Base62.Decode(id);
            return GuidConverter.ToGuid(decoded);
        }
    }
}
