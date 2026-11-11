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
using System.Reflection;
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
        /// <summary>
        /// Az.Accounts credentials implement this interface to get a new token for a claims challenge.
        /// It is defined in an Az.Accounts assembly that service modules do not reference, so it is found by name.
        /// </summary>
        internal const string ClaimsChallengeProcessorInterface = "Microsoft.Azure.Commands.Common.Authentication.IClaimsChallengeProcessor";

        private const string OnClaimsChallengeMethod = "OnClaimsChallenageAsync";

        private static readonly Uri AttestationUri = new Uri("https://attest.azure.net");

        private readonly ServiceClientCredentials _credentials;

        public AttestationTokenCredential(IAuthenticationFactory authFactory, IAzureContext context)
            : this(GetServiceClientCredentials(authFactory, context))
        {
        }

        internal AttestationTokenCredential(ServiceClientCredentials credentials)
        {
            _credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
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

                // Azure.Core asks for a token with claims after the service rejects a token with a claims challenge.
                if (!string.IsNullOrEmpty(requestContext.Claims))
                {
                    await ProcessClaimsChallengeAsync(request, requestContext.Claims, cancellationToken).ConfigureAwait(false);
                }

                return new AccessToken(request.Headers.Authorization?.Parameter, DateTimeOffset.UtcNow);
            }
        }

        private async Task ProcessClaimsChallengeAsync(HttpRequestMessage request, string claims, CancellationToken cancellationToken)
        {
            var onClaimsChallenge = _credentials.GetType().GetInterface(ClaimsChallengeProcessorInterface)?.GetMethod(OnClaimsChallengeMethod);
            if (onClaimsChallenge == null)
            {
                return;
            }

            try
            {
                await ((ValueTask<bool>)onClaimsChallenge.Invoke(_credentials, new object[] { request, claims, cancellationToken })).ConfigureAwait(false);
            }
            catch (TargetInvocationException ex) when (ex.InnerException != null)
            {
                System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            }
        }

        private static ServiceClientCredentials GetServiceClientCredentials(IAuthenticationFactory authFactory, IAzureContext context)
        {
            if (authFactory == null)
                throw new ArgumentNullException(nameof(authFactory));
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return authFactory.GetServiceClientCredentials(context, AzureEnvironment.ExtendedEndpoint.AzureAttestationServiceEndpointResourceId);
        }
    }
}
