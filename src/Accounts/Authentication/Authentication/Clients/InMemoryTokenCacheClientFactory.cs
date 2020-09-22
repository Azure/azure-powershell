// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Identity.Client;

namespace Microsoft.Azure.Commands.Common.Authentication.Authentication.Clients
{
    /// <summary>
    /// Factory that creates client app for authenticating with MSAL.
    /// Should be accessed using <see cref="AuthenticationClientFactory.AuthenticationClientFactoryKey"/>.
    /// </summary>
    public class InMemoryTokenCacheClientFactory : AuthenticationClientFactory
    {
        //private readonly IMemoryCache _memoryCache;
        //private readonly string _cacheId = "CacheId";
        //private static readonly object _lock = new object();

        public InMemoryTokenCacheClientFactory()
        {
            //_memoryCache = new MemoryCache(new MemoryCacheOptions());
        }

        public override void RegisterCache(IClientApplicationBase client)
        {
            client.UserTokenCache.SetBeforeAccess(BeforeAccessNotification);
            client.UserTokenCache.SetAfterAccess(AfterAccessNotification);
        }

        private void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            //lock (_lock)
            //{
            //    if (_memoryCache.TryGetValue(_cacheId, out byte[] blob))
            //    {
            //        args.TokenCache.DeserializeMsalV3(blob);
            //    }
            //}
        }

        private void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            //byte[] blob = args.TokenCache.SerializeMsalV3();
            //lock (_lock)
            //{
            //    _memoryCache.Set(_cacheId, blob);
            //}
        }

        public override byte[] ReadTokenData()
        {
            byte[] blob = null;
            //lock (_lock)
            //{
            //    _memoryCache.TryGetValue(_cacheId, out blob);
            //}
            return blob;
        }

        public override void FlushTokenData()
        {
            //lock (_lock)
            //{
            //    _memoryCache.Set(_cacheId, _tokenCacheDataToFlush);
            //}
        }

        public override void ClearCache()
        {
            //_memoryCache.Remove(_cacheId);
        }
    }
}
