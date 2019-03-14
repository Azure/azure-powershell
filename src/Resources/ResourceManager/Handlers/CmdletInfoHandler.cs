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
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The cmdlet info handler.
    /// </summary>
    public class CmdletInfoHandler : DelegatingHandler
    {
        /// <summary>
        /// The product info to add as headers.
        /// </summary>
        private readonly Dictionary<string, string> cmdletHeaderValues;

        /// <summary>
        /// Initializes a new instance of the <see cref="CmdletInfoHandler" /> class.
        /// </summary>
        /// <param name="headerValues">The product info to add as headers.</param>
        public CmdletInfoHandler(Dictionary<string, string> cmdletHeaderValues)
        {
            this.cmdletHeaderValues = cmdletHeaderValues;
        }

        /// <summary>
        /// Add the custom headers to the outgoing request.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            foreach (KeyValuePair<string, string> kvp in cmdletHeaderValues)
            {
                request.Headers.Add(kvp.Key, kvp.Value);
            }

            return await base
                .SendAsync(request, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
