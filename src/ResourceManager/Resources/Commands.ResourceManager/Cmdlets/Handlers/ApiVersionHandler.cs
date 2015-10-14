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
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using System;

    /// <summary>
    /// The api version agent handler.
    /// </summary>
    public class ApiVersionHandler : DelegatingHandler
    {
        /// <summary>
        /// The product info to add as headers.
        /// </summary>
        private readonly string apiVersion;
        private const string ApiVersionQueryParamTemplate = "api-version={0}";

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAgentHandler" /> class.
        /// </summary>
        /// <param name="headerValues">The product info to add as headers.</param>
        public ApiVersionHandler(string apiVersion)
        {
            this.apiVersion = apiVersion;
        }

        /// <summary>
        /// Adds the apiVersion to the outgoing request.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestUri = new UriBuilder(request.RequestUri.AbsoluteUri);

            var apiVersionQuery = string.Format(ApiVersionQueryParamTemplate, this.apiVersion);

            if (string.IsNullOrEmpty(requestUri.Query))
            {
                requestUri.Query = apiVersionQuery;
            }
            else if (!requestUri.Query.ToLower().Contains("api-version"))
            {
                requestUri.Query = requestUri.Query.TrimStart(new char[] { '?' }) + "&" + apiVersionQuery;
            }
            request.RequestUri = requestUri.Uri;

            return await base
                .SendAsync(request, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
