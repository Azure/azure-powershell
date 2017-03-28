using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.Common.Authentication.Abstractions
{
    public class TokenStore : TokenCache
    {
        public override IEnumerable<TokenCacheItem> ReadItems()
        {
            return base.ReadItems();
        }

        public override void Clear()
        {
            base.Clear();
        }

        public override void DeleteItem(TokenCacheItem item)
        {
            base.DeleteItem(item);
        }

        public void HandleBeforeAccess(TokenCacheNotificationArgs args)
        {

        }

        public void HandleAfterAccess(TokenCacheNotificationArgs args)
        {

        }
    }
}
