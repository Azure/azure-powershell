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

using System.Threading.Tasks;

using Microsoft.Identity.Client;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class InMemoryTokenCacheProvider : PowerShellTokenCacheProvider
    {
        //private IMemoryCache MemoryCache { get; }
        //private readonly string cacheId = "CacheId";
        //private static readonly object lockObject = new object();

        public InMemoryTokenCacheProvider()
        {
            //MemoryCache = new MemoryCache(new MemoryCacheOptions());
        }

        public override Task<byte[]> ReadAsync()
        {
            byte[] bytes = null;
            //lock(lockObject)
            //{
            //    MemoryCache.TryGetValue(cacheId, out bytes);
            //}
            return Task.FromResult(bytes);
        }

        public override Task WriteAsync(byte[] bytes)
        {
            //lock(lockObject)
            //{
            //    MemoryCache.Set(cacheId, bytes);
            //}
            return Task.CompletedTask;
        }

        public override byte[] ReadTokenData()
        {
            byte[] bytes = null;
            //lock (lockObject)
            //{
            //    MemoryCache.TryGetValue(cacheId, out bytes);
            //}
            return bytes;
        }

        public override void FlushTokenData()
        {
            //lock (lockObject)
            //{
            //    MemoryCache.Set(cacheId, _tokenCacheDataToFlush);
            //}
        }

        public override void ClearCache()
        {
            //MemoryCache.Remove(cacheId);
        }

        protected override void RegisterCache(IPublicClientApplication client)
        {

        }

    }
}
