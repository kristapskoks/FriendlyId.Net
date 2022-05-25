using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyId.Net
{
    public static class FriendlyId
    {
        /// <summary>
        /// Create new friendly id
        /// </summary>
        /// <returns>Friendly id encoded Guid</returns>
        public static string CreateFriendlyId()
        {
            return Url62.Encode(Guid.NewGuid());
        }

        /// <summary>
        /// Encode Guid to Friendly id
        /// </summary>
        /// <param name="guid">Guid to be encoded</param>
        /// <returns>Friendly id encoded Guid</returns>
        public static string ToFriendlyId(Guid guid)
        {
            return Url62.Encode(guid);
        }
        /// <summary>
        /// Decode friendly id to Guid
        /// </summary>
        /// <param name="friendlyId">Friendly id to decode</param>
        /// <returns>Decoded Guid</returns>
        public static Guid ToGuid(string friendlyId)
        {
            return Url62.Decode(friendlyId);
        }
    }
}
