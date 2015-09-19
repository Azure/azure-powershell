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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Handlers
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The authentication handler.
    /// </summary>
    public class AuthenticationHandler : DelegatingHandler
    {
        /// <summary>
        /// The subscription cloud credentials.
        /// </summary>
        private readonly SubscriptionCloudCredentials cloudCredentials;


        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationHandler" /> class.
        /// </summary>
        /// <param name="cloudCredentials">The credentials.</param>
        public AuthenticationHandler(SubscriptionCloudCredentials cloudCredentials)
        {
            this.cloudCredentials = cloudCredentials;

        }

        /// <summary>
        /// Add the authentication token to the outgoing request.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            await this.cloudCredentials
                .ProcessHttpRequestAsync(request: request, cancellationToken: cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            return await base
                .SendAsync(request, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);
        }

    }
}
