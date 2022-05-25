using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyId.Net
{
    public static class FriendlyId
    {
        public static string CreateFriendlyId()
        {
            return Url62.Encode(Guid.NewGuid());
        }

        public static string ToFriendlyId(Guid guid)
        {
            return Url62.Encode(guid);
        }

        public static Guid ToGuid(string friendlyId)
        {
            return Url62.Decode(friendlyId);
        }
    }
}
