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
using System.Threading.Tasks;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    /// <summary>
    /// Options controlling the storage of the token cache.
    /// </summary>
    public abstract class UnsafeTokenCacheOptions : TokenCachePersistenceOptions
    {
        /// <summary>
        /// The delegate to be called when the Updated event fires.
        /// </summary>
        /// <value></value>
        protected internal abstract Task TokenCacheUpdatedAsync(TokenCacheUpdatedArgs tokenCacheUpdatedArgs);

        /// <summary>
        /// The bytes used to initialize the token cache. This would most likely have come from the <see cref="TokenCacheUpdatedArgs"/>.
        /// </summary>
        /// <value></value>
        protected internal abstract Task<ReadOnlyMemory<byte>> RefreshCacheAsync();
    }
}
