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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Identity.Client;
using System;
using System.Threading;

#if NETSTANDARD
namespace Microsoft.Azure.Commands.Common.Authentication.Core
#else
namespace Microsoft.Azure.Commands.Common.Authentication
#endif
{
    [Serializable]
    public class AuthenticationStoreTokenCache : IAzureTokenCache, IDisposable
    {
        private object _tokenCache;

        public object GetUserCache()
        {
            if (_tokenCache == null)
            {
                var tokenCache = new TokenCache();
                tokenCache.SetAfterAccess(HandleAfterAccess);
                _tokenCache = tokenCache;
            }

            return _tokenCache;
        }

        private TokenCache UserCache
        {
            get
            {
                return (TokenCache)GetUserCache();
            }
        }

        IAzureTokenCache _store = new AzureTokenCache();
        public byte[] CacheData
        {
            get
            {
               return UserCache.SerializeMsalV3();
            }

            set
            {
                UserCache.DeserializeMsalV3(value);
            }
        }

        public AuthenticationStoreTokenCache(AzureTokenCache store) : base()
        {
            if (null == store)
            {
                throw new ArgumentNullException("store");
            }

            if (store.CacheData != null && store.CacheData.Length > 0)
            {
                CacheData = store.CacheData;
            }

            UserCache.SetAfterAccess(HandleAfterAccess);
        }

        /// <summary>
        /// Create a token cache, copying any data from the given token cache
        /// </summary>
        /// <param name="cache">The cache to copy</param>
        /// <param name="store">The store to use for persisting state</param>
        public AuthenticationStoreTokenCache(TokenCache cache) : base()
        {
            if (null == cache)
            {
                throw new ArgumentNullException("Cache");
            }

            CacheData = cache.SerializeMsalV3();
            UserCache.SetAfterAccess(HandleAfterAccess);
        }

        public void HandleAfterAccess(TokenCacheNotificationArgs args)
        {
            if (args.HasStateChanged)
            {
                _store.CacheData = args.TokenCache.SerializeMsalV3();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                var cache = Interlocked.Exchange(ref _store, null);
                if (cache != null)
                {
                    cache.CacheData = UserCache.SerializeMsalV3();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Clear()
        {
            _tokenCache = null;
        }
    }
}
