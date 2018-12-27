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
    using System.Collections.Generic;
    using System.Net.Http.Headers;

    /// <summary>
    /// Factory class for creating http client helpers.
    /// </summary>
    public class HttpClientHelperFactory
    {
        /// <summary>
        /// Gets an instance of the facotry.
        /// </summary>
        public static HttpClientHelperFactory Instance { get; internal set; }

        /// <summary>
        /// Initializes static members of the <see cref="HttpClientHelperFactory"/> class.
        /// </summary>
        static HttpClientHelperFactory()
        {
            HttpClientHelperFactory.Instance = new HttpClientHelperFactory();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientHelperFactory"/> class.
        /// </summary>
        protected HttpClientHelperFactory()
        {
        }

        /// <summary>
        /// Creates new instances of the <see cref="HttpClientHelper"/> class.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <param name="headerValues">The headers.</param>
        public virtual HttpClientHelper CreateHttpClientHelper(SubscriptionCloudCredentials credentials, IEnumerable<ProductInfoHeaderValue> headerValues, Dictionary<string, string> cmdletHeaderValues)
        {
            return new HttpClientHelperImpl(credentials: credentials, headerValues: headerValues, cmdletHeaderValues: cmdletHeaderValues);
        }

        /// <summary>
        /// An implementation of the <see cref="HttpClientHelper"/> abstract class.
        /// </summary>
        private class HttpClientHelperImpl : HttpClientHelper
        {
            /// <summary>
            /// Initializes new instances of the <see cref="HttpClientHelperImpl"/> class.
            /// </summary>
            /// <param name="credentials">The credentials.</param>
            /// <param name="headerValues">The headers.</param>
            public HttpClientHelperImpl(SubscriptionCloudCredentials credentials, IEnumerable<ProductInfoHeaderValue> headerValues, Dictionary<string, string> cmdletHeaderValues)
                : base(credentials: credentials, headerValues: headerValues, cmdletHeaderValues: cmdletHeaderValues)
            {
            }
        }
    }
}
