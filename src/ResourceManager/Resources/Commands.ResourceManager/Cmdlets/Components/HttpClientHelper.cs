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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Handlers;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;

    /// <summary>
    /// Factory class for creating <see cref="HttpClient"/> objects with custom headers.
    /// </summary>
    public abstract class HttpClientHelper
    {
        /// <summary>
        /// The subscription cloud credentials.
        /// </summary>
        private readonly SubscriptionCloudCredentials credentials;

        /// <summary>
        /// The header values.
        /// </summary>
        private readonly IEnumerable<ProductInfoHeaderValue> headerValues;

        /// <summary>
        /// The cmdlet info header values.
        /// </summary>
        private readonly Dictionary<string, string> cmdletHeaderValues;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientHelper"/> class.
        /// </summary>
        /// <param name="credentials">The subscription cloud credentials.</param>
        /// <param name="headerValues">The header values.</param>
        protected HttpClientHelper(SubscriptionCloudCredentials credentials, IEnumerable<ProductInfoHeaderValue> headerValues, Dictionary<string, string> cmdletHeaderValues)
        {
            this.credentials = credentials;
            this.headerValues = headerValues;
            this.cmdletHeaderValues = cmdletHeaderValues;
        }

        /// <summary>
        /// Creates an <see cref="HttpClient"/>
        /// </summary>
        /// <param name="primaryHandlers">The handlers that will be added to the top of the chain.</param>
        public virtual HttpClient CreateHttpClient(params DelegatingHandler[] primaryHandlers)
        {
            var delegateHandlers = new DelegatingHandler[]
            {
                new AuthenticationHandler(cloudCredentials: credentials),
                new UserAgentHandler(headerValues: headerValues),
                new CmdletInfoHandler(cmdletHeaderValues: cmdletHeaderValues),
                new TracingHandler(),
                new RetryHandler(),
            };

            var pipeline = (HttpMessageHandler)(new HttpClientHandler());
            var reversedHandlers = primaryHandlers.CoalesceEnumerable().Concat(delegateHandlers).ToArray().Reverse();
            foreach (var handler in reversedHandlers)
            {
                handler.InnerHandler = pipeline;
                pipeline = handler;
            }

            return new HttpClient(pipeline);
        }
    }
}
