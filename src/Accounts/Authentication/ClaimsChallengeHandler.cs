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

using Azure.Identity;
using Microsoft.Azure.Commands.Common.Exceptions;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class ClaimsChallengeHandler : DelegatingHandler, ICloneable
    {
        //TokenCredential doesn't support CAE for SP, MSI.
        private IClaimsChallengeProcessor ClaimsChallengeProcessor { get; set; }

        public ClaimsChallengeHandler(IClaimsChallengeProcessor claimsChallengeProcessor)
        {
            ClaimsChallengeProcessor = claimsChallengeProcessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            if (response.MatchClaimsChallengePattern(out var claimsChallenge))
            {
                try
                {
                    if (await OnChallengeAsync(claimsChallenge, request, response, cancellationToken))
                    {
                        return await base.SendAsync(request, cancellationToken);
                    }
                }
                catch (AuthenticationFailedException e)
                {
                    string additionalErrorMessage = ClaimsChallengeUtilities.FormatClaimsChallengeErrorMessage(claimsChallenge, await response?.Content?.ReadAsStringAsync());
                    throw new AzPSAuthenticationFailedException(additionalErrorMessage, null, e);
                }
            }
            return response;
        }

        public virtual object Clone()
        {
            return new ClaimsChallengeHandler(ClaimsChallengeProcessor);
        }
        /// <summary>
        /// Executed in the event a 401 response with a WWW-Authenticate authentication challenge header is received after the initial request.
        /// </summary>
        /// <remarks>This implementation handles common authentication challenges such as claims challenges. Service client libraries may derive from this and extend to handle service specific authentication challenges.</remarks>
        /// <param name="claimsChallenge"></param>
        /// <param name="requestMessage">The HttpMessage to be authenticated.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="responseMessage"></param>
        /// <returns>A boolean indicated whether the request should be retried</returns>
        protected virtual async Task<bool> OnChallengeAsync(string claimsChallenge, HttpRequestMessage requestMessage, HttpResponseMessage responseMessage, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(claimsChallenge))
            {
                return await ClaimsChallengeProcessor.OnClaimsChallenageAsync(requestMessage, claimsChallenge, cancellationToken).ConfigureAwait(false);
            }

            return false;
        }
    }
}
