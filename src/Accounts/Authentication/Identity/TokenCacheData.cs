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
//

using System;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    /// <summary>
    /// Details related to a <see cref="UnsafeTokenCacheOptions"/> cache delegate.
    /// </summary>
    public struct TokenCacheData
    {
        /// <summary>
        /// Constructs a new <see cref="TokenCacheData"/> instance with the specified cache bytes.
        /// </summary>
        /// <param name="cacheBytes">The serialized content of the token cache.</param>
        public TokenCacheData(ReadOnlyMemory<byte> cacheBytes)
        {
            CacheBytes = cacheBytes;
        }

        /// <summary>
        /// The bytes representing the state of the token cache.
        /// </summary>
        public ReadOnlyMemory<byte> CacheBytes { get; }
    }
}
