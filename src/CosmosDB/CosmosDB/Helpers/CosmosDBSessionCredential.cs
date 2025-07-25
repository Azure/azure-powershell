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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.CosmosDB.Helpers
{
    internal class CosmosDBSessionCredential : TokenCredential
    {
        private IAccessToken accessToken;

        public CosmosDBSessionCredential(IAzureContext defaultContext, string endPointResourceId)
        {
            if (defaultContext == null || defaultContext.Account == null)
            {
                throw new InvalidOperationException();
            }

            IAccessToken accessToken1 = AzureSession.Instance.AuthenticationFactory.Authenticate(
               account: defaultContext.Account,
               environment: defaultContext.Environment,
               tenant: defaultContext.Tenant.Id,
               password: null,
               promptBehavior: ShowDialog.Never,
               promptAction: null,
               resourceId: endPointResourceId);

            // set the access token.
            this.accessToken = accessToken1;
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            DateTimeOffset expiresOn;
            string token = string.Empty;
            accessToken.AuthorizeRequest((tokenType, tokenValue) =>
            {
                token = tokenValue;
                expiresOn = DateTimeOffset.UtcNow;
            });

            return new AccessToken(token, expiresOn);
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            DateTimeOffset expiresOn;
            string token = string.Empty;
            accessToken.AuthorizeRequest((tokenType, tokenValue) =>
            {
                token = tokenValue;
                expiresOn = DateTimeOffset.UtcNow;
            });

            return new ValueTask<AccessToken>(new AccessToken(token, expiresOn));
        }        
    }
}