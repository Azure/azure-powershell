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
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Threading;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class AuthenticationStoreTokenCache : TokenCache, IAzureTokenCache, IDisposable
    {
        AzureTokenCache _tokenStore;

        public byte[] CacheData
        {
            get
            {
                return _tokenStore.CacheData;
            }

            set
            {
                this.Clear();
                _tokenStore.CacheData = value;
            }
        }

        public AuthenticationStoreTokenCache(AzureTokenCache store) : base()
        {
            if (null == store)
            {
                throw new ArgumentNullException("store");
            }

            _tokenStore = store;
            if (_tokenStore != null && _tokenStore.CacheData != null && _tokenStore.CacheData.Length > 0)
            {
                base.Deserialize(_tokenStore.CacheData);
            }

            AfterAccess += HandleAfterAccess;
        }

        /// <summary>
        /// Create a token cache, copying any data from the given token cache
        /// </summary>
        /// <param name="cache">The cache to copy</param>
        /// <param name="store">The store to use for persisting state</param>
        public AuthenticationStoreTokenCache(TokenCache cache, AzureTokenCache store) : this(store)
        {
            if (null == cache)
            {
                throw new ArgumentNullException("Cache");
            }

            Deserialize(cache.Serialize());
        }

        /// <summary>
        /// Create a token cache, copying any data from the given token cache
        /// </summary>
        /// <param name="cache">The cache to copy</param>
        public AuthenticationStoreTokenCache(TokenCache cache) : this(cache, new AzureTokenCache())
        {
        }


        public void HandleAfterAccess(TokenCacheNotificationArgs args)
        {
            if (HasStateChanged)
            {
                _tokenStore.CacheData = Serialize();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                var cache = Interlocked.Exchange(ref _tokenStore, null);
                if (cache != null)
                {
                    cache.CacheData = base.Serialize();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
