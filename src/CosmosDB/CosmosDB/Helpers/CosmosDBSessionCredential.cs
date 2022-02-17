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

using Azure.Core;
using Azure.Identity;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.CosmosDB.Helpers
{
    public class CosmosDBSessionCredential : TokenCredential
    {
        public CosmosDBSessionCredential(IAzureContext DefaultContext, string endPointResourceId)
        {
            if (DefaultContext == null || DefaultContext.Account == null)
            {
                throw new InvalidOperationException();
            }

            IAccessToken accessToken1 = AzureSession.Instance.AuthenticationFactory.Authenticate(
               DefaultContext.Account,
               DefaultContext.Environment,
               DefaultContext.Tenant.Id,
               null,
               ShowDialog.Never,
               null,
               endPointResourceId);
            accessToken = accessToken1;
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            AccessToken token;
            accessToken.AuthorizeRequest((tokenType, tokenValue) =>
            {
                token = new AccessToken(tokenValue, DateTimeOffset.UtcNow);
            });

            return token;
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            AccessToken token;
            accessToken.AuthorizeRequest((tokenType, tokenValue) =>
            {
                token = new AccessToken(tokenValue, DateTimeOffset.UtcNow);
            });

            return new ValueTask<AccessToken>(token);
        }

        private IAccessToken accessToken;
    }
}