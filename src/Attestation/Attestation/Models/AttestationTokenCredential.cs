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
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.Attestation.Models
{
    /// <summary>
    /// Supplies tokens for the Azure Attestation data plane from the current Azure PowerShell context.
    /// </summary>
    /// <remarks>
    /// Tokens come from <see cref="IAuthenticationFactory.GetServiceClientCredentials(IAzureContext, string)"/>,
    /// as they did before this module used Azure.Core, so every account type is handled the same way.
    /// </remarks>
    internal class AttestationTokenCredential : TokenCredential
    {
        private static readonly Uri AttestationUri = new Uri("https://attest.azure.net");

        private readonly ServiceClientCredentials _credentials;

        public AttestationTokenCredential(IAuthenticationFactory authFactory, IAzureContext context)
        {
            if (authFactory == null)
                throw new ArgumentNullException(nameof(authFactory));
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _credentials = authFactory.GetServiceClientCredentials(context, AzureEnvironment.ExtendedEndpoint.AzureAttestationServiceEndpointResourceId);
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return GetTokenAsync(requestContext, cancellationToken).AsTask().GetAwaiter().GetResult();
        }

        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, AttestationUri))
            {
                await _credentials.ProcessHttpRequestAsync(request, cancellationToken).ConfigureAwait(false);
                return new AccessToken(request.Headers.Authorization?.Parameter, DateTimeOffset.UtcNow);
            }
        }
    }
}
