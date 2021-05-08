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

using System.IO;
using System.Threading;

using Azure.Identity;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    //public class PowerShellTokenCache
    //{
    //    public TokenCachePersistenceOptions TokenCache { get; private set; }

    //    public PowerShellTokenCache(TokenCachePersistenceOptions tokenCache)
    //    {
    //        TokenCache = tokenCache;
    //    }

    //    public PowerShellTokenCache(Stream stream)
    //    {
    //        TokenCache = InMemoryTokenCacheOptions.Deserialize(stream);
    //    }

    //    public static PowerShellTokenCache Deserialize(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        var cache = InMemoryTokenCacheOptions.Deserialize(stream);
    //        return new PowerShellTokenCache(cache);
    //    }

    //    public void Serialize(Stream stream)
    //    {
    //        if(TokenCache is InMemoryTokenCacheOptions inMemoryTokenCacheOptions)
    //        {
    //            if(inMemoryTokenCacheOptions._cachedToken != null)
    //            {
    //                stream.Write(inMemoryTokenCacheOptions._cachedToken, 0, inMemoryTokenCacheOptions._cachedToken.Length);
    //            }
    //        }
    //        else
    //        {
    //            if (AzureSession.Instance.TryGetComponent(nameof(PowerShellTokenCache), out PowerShellTokenCache tokenCache))
    //            {
    //                if (tokenCache.IsPersistentCache)
    //                {
    //                    if (AzureSession.Instance.TryGetComponent(
    //                        PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey,
    //                        out PowerShellTokenCacheProvider tokenCacheProvider))
    //                    {
    //                        cacheData = tokenCacheProvider.ReadTokenData();
    //                    }
    //                }
    //        }
    //    }

    //    public bool IsPersistentCache
    //    {
    //        get
    //        {
    //            return !(TokenCache is InMemoryTokenCacheOptions);
    //        }
    //    }
    //}
}
