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

using System;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Identity;

using Microsoft.Azure.PowerShell.Authenticators;
using Microsoft.PowerShell.Commands;

namespace Microsoft.Azure.PowerShell.Authentication.Test.Mocks
{
    internal class MockManagedIdentityCredential : ManagedIdentityCredential
    {
        internal string AccountId { get; set; }

        internal TokenRequestContext TokenRequestContext { get; private set; }

        public Func<AccessToken> TokenFactory { get; set; }

        public MockManagedIdentityCredential(string accountId)
            : base(accountId)
        {
            AccountId = accountId;
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            TokenRequestContext = requestContext;
            return new ValueTask<AccessToken>(TokenFactory());
        }
    }
}
