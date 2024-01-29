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

using Azure.Identity;

using System;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    /// <summary>
    /// Data regarding an update of a token cache.
    /// </summary>
    public class TokenCacheUpdatedArgs
    {
        internal TokenCacheUpdatedArgs(ReadOnlyMemory<byte> cacheData, bool enableCae)
        {
            UnsafeCacheData = cacheData;
            IsCaeEnabled = enableCae;
        }

        /// <summary>
        /// The <see cref="TokenCachePersistenceOptions"/> instance which was updated.
        /// </summary>
        public ReadOnlyMemory<byte> UnsafeCacheData { get; }

        /// <summary>
        /// Whether or not the cache is enabled for CAE. Note that this value should be used as an indicator for how the cache will be partitioned.
        /// Token cache refresh events with this value set to `true` will originate from a different cache instance than those with this value set to `false`.
        /// </summary>
        public bool IsCaeEnabled { get; }
    }
}
