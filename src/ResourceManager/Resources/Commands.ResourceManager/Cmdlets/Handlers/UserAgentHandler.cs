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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The user agent handler.
    /// </summary>
    public class UserAgentHandler : DelegatingHandler
    {
        /// <summary>
        /// The product info to add as headers.
        /// </summary>
        private readonly IEnumerable<ProductInfoHeaderValue> headerValues;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAgentHandler" /> class.
        /// </summary>
        /// <param name="headerValues">The product info to add as headers.</param>
        public UserAgentHandler(IEnumerable<ProductInfoHeaderValue> headerValues)
        {
            this.headerValues = headerValues;
        }

        /// <summary>
        /// Add the user agent to the outgoing request.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var currentRequestHeaders = request.Headers.UserAgent
                .ToInsensitiveDictionary(header => header.Product.Name + header.Product.Version);

            var infosToAdd = this.headerValues
                .Where(productInfo => !currentRequestHeaders.ContainsKey(productInfo.Product.Name + productInfo.Product.Version));

            foreach (var infoToAdd in infosToAdd)
            {
                request.Headers.UserAgent.Add(infoToAdd);
            }

            return await base
                .SendAsync(request, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
