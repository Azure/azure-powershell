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

using Azure.Identity;

using Microsoft.Identity.Client;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class InMemoryTokenCacheProvider : PowerShellTokenCacheProvider
    {
        private InMemoryTokenCacheOptions InMemoryTokenCacheOptions { get; set; }

        public InMemoryTokenCacheProvider(byte[] tokenCache)
        {
            InMemoryTokenCacheOptions = new InMemoryTokenCacheOptions(tokenCache);
        }

        public InMemoryTokenCacheProvider(InMemoryTokenCacheOptions options = null)
        {
            InMemoryTokenCacheOptions = options ?? new InMemoryTokenCacheOptions();
        }

        public override byte[] ReadTokenData()
        {
            return InMemoryTokenCacheOptions.CachedToken.ToArray();
        }

        public override void FlushTokenData()
        {
            if (_tokenCacheDataToFlush != null)
            {
                InMemoryTokenCacheOptions = new InMemoryTokenCacheOptions(_tokenCacheDataToFlush);
                _tokenCacheDataToFlush = null;
            }
        }

        public override void ClearCache()
        {
            InMemoryTokenCacheOptions = new InMemoryTokenCacheOptions();
        }

        protected override void RegisterCache(IPublicClientApplication client)
        {
        }

        public override TokenCachePersistenceOptions GetTokenCachePersistenceOptions()
        {
            return InMemoryTokenCacheOptions;
        }
    }
}
