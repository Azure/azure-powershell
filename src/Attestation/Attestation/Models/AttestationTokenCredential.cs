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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Attestation.Models
{
    /// <summary>
    /// Supplies tokens for the Azure Attestation data plane from the current Azure PowerShell context.
    /// </summary>
    internal class AttestationTokenCredential : TokenCredential
    {
        private readonly IAccessToken _accessToken;

        public AttestationTokenCredential(IAuthenticationFactory authFactory, IAzureContext context)
        {
            if (authFactory == null)
                throw new ArgumentNullException(nameof(authFactory));
            if (context?.Account == null)
                throw new ArgumentException(nameof(context));

            _accessToken = authFactory.Authenticate(
                context.Account,
                context.Environment,
                context.Tenant?.Id,
                null,
                ShowDialog.Never,
                null,
                AzureEnvironment.ExtendedEndpoint.AzureAttestationServiceEndpointResourceId);
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            string token = null;
            _accessToken.AuthorizeRequest((tokenType, tokenValue) => token = tokenValue);
            return new AccessToken(token, DateTimeOffset.UtcNow);
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
        }
    }
}
