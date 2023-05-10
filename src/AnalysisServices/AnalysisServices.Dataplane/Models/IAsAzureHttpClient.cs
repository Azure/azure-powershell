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
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models
{
    /// <summary>
    /// Interface for the necessary httpclient methods for dataplane cmdlets.
    /// </summary>
    public interface IAsAzureHttpClient
    {
        /// <summary>
        /// Calls SendRequestAsync() for a GET using the default BaseUri and a blank correlationId.
        /// </summary>
        /// <param name="requestURL">The Request Url.</param>
        /// <returns>The http response message.</returns>
        Task<HttpResponseMessage> CallGetAsync(string requestURL);

        /// <summary>
        /// Calls SendRequestAsync() for a GET.
        /// </summary>
        /// <param name="baseUri">The base Uri to call.</param>
        /// <param name="requestURL">The request Url.</param>
        /// <param name="correlationId">The CorrelationId</param>
        /// <returns>The http response message.</returns>
        Task<HttpResponseMessage> CallGetAsync(Uri baseUri, string requestURL, Guid correlationId);

        /// <summary>
        /// Calls SendRequestAsync() for a POST using the default BaseUri and a blank correlationId.
        /// </summary>
        /// <param name="requestURL">The Request Url.</param>
        /// <param name="content">The content to post (optional).</param>
        /// <returns>The http response message.</returns>
        Task<HttpResponseMessage> CallPostAsync(string requestURL, HttpContent content = null);

        /// <summary>
        /// Calls SendRequestAsync() for a POST using a blank correlationId.
        /// </summary>
        /// <param name="baseURI">The base Uri to call.</param>
        /// <param name="requestURL">The request Url.</param>
        /// <param name="content">The content to post (optional).</param>
        /// <returns>The http response message.</returns>
        Task<HttpResponseMessage> CallPostAsync(Uri baseURI, string requestURL, HttpContent content = null);

        /// <summary>
        /// Calls SendRequestAsync() for a POST.
        /// </summary>
        /// <param name="baseURI">The base Uri to call.</param>
        /// <param name="requestURL">The request Url.</param>
        /// <param name="correlationId">The CorrelationId</param>
        /// <param name="content">The content to post (optional).</param>
        /// <returns>The http response message.</returns>
        Task<HttpResponseMessage> CallPostAsync(Uri baseURI, string requestURL, Guid correlationId, HttpContent content = null);

        void ResetHttpClient();
    }
}
