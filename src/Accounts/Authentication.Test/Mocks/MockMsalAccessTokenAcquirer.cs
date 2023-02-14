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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.PowerShell.Authenticators;

namespace Microsoft.Azure.PowerShell.Authentication.Test.Mocks
{
    class MockMsalAccessTokenAcquirer : MsalAccessTokenAcquirer
    {
        public Func<TokenCredential, TokenRequestContext, IAccessToken> AccessTokenFactoryMethod { get; set; }

        public TokenCredential TokenCredential { get; set; }

        public TokenRequestContext TokenRequestContext { get; set; }

        internal override async Task<IAccessToken> GetAccessTokenAsync(string callerClassName, string parametersLog, TokenCredential tokenCredential, TokenRequestContext requestContext, CancellationToken cancellationToken, string tenantId = null, string userId = null, string homeAccountId = "")
        {
            TokenCredential = tokenCredential;
            TokenRequestContext = requestContext;

            return await Task.FromResult(AccessTokenFactoryMethod(tokenCredential, requestContext));
        }

        internal override async Task<IAccessToken> GetAccessTokenAsync(Task<AuthenticationRecord> authTask, TokenCredential tokenCredential, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            TokenCredential = tokenCredential;
            TokenRequestContext = requestContext;

            return await Task.FromResult(AccessTokenFactoryMethod(tokenCredential, requestContext));
        }
    }
}
