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
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Compute.Common
{
    public class ComputeTokenCredential : TokenCredential
    {
        public IAccessToken accessToken { get; set; }
        public ComputeTokenCredential(IAzureContext Context, string customAudience)
        {

            if (Context == null || Context.Account == null)
            {
                throw new InvalidOperationException();
            }

            accessToken = AzureSession.Instance.AuthenticationFactory.Authenticate(
                   Context.Account,
                   EnsureCustomAudienceSet(Context.Environment, customAudience),
                   Context.Tenant.Id,
                   null,
                   ShowDialog.Never,
                   null,
                   customAudience);

        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            AccessToken token = new AccessToken(accessToken.AccessToken, DateTimeOffset.UtcNow);
            //accessToken.AuthorizeRequest((tokenType, tokenValue) =>
            //{
            //    token = new AccessToken(tokenValue, DateTimeOffset.UtcNow);
            //});
            return token;
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<AccessToken>(this.GetToken(requestContext, cancellationToken));
        }

        private IAzureEnvironment EnsureCustomAudienceSet(IAzureEnvironment environment, string customAudience)
        {
            if (environment != null)
            {
                if (!environment.IsPropertySet(customAudience))
                {
                    environment.SetProperty(customAudience, customAudience);
                }
            }
            return environment;
        }
    }
}