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
    public class PowerShellTokenCache
    {
        public TokenCache TokenCache { get; private set; }

        public PowerShellTokenCache(TokenCache tokenCache)
        {
            TokenCache = tokenCache;
        }

        public PowerShellTokenCache(Stream stream)
        {
            TokenCache = TokenCache.Deserialize(stream);
        }

        public static PowerShellTokenCache Deserialize(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            var cache = TokenCache.Deserialize(stream);
            return new PowerShellTokenCache(cache);
        }

        public void Serialize(Stream stream)
        {
            TokenCache.Serialize(stream);
        }

        public bool IsPersistentCache
        {
            get
            {
                return TokenCache is PersistentTokenCache;
            }
        }
    }
}
