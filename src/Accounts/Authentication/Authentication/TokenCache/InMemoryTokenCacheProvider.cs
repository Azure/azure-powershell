﻿// ----------------------------------------------------------------------------------
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
        public InMemoryTokenCacheProvider()
        {
        }

        public override byte[] ReadTokenData()
        {
            return null;
        }

        public override void FlushTokenData()
        {
        }

        public override void ClearCache()
        {
        }

        protected override void RegisterCache(IPublicClientApplication client)
        {

        }

        public override PowerShellTokenCache GetTokenCache()
        {
            return new PowerShellTokenCache(new global::Azure.Identity.TokenCache());
        }
    }
}
