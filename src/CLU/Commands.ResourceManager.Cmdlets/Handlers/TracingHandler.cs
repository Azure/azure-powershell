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
    using Rest;
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Tracing handler.
    /// </summary>
    public class TracingHandler : DelegatingHandler
    {
        /// <summary>
        /// Trace the outgoing request.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!ServiceClientTracing.IsEnabled)
            {
                return await base.SendAsync(request: request, cancellationToken: cancellationToken)
                    .ConfigureAwait(continueOnCapturedContext: false);
            }

            var invocationId = ServiceClientTracing.NextInvocationId.ToString();
            try
            {
                ServiceClientTracing.SendRequest(invocationId: invocationId, request: request);
                var response = await base.SendAsync(request: request, cancellationToken: cancellationToken)
                    .ConfigureAwait(continueOnCapturedContext: false);
                ServiceClientTracing.ReceiveResponse(invocationId: invocationId, response: response);
                return response;
            }
            catch (Exception ex)
            {
                if (ex.IsFatal())
                {
                    throw;
                }

                ServiceClientTracing.Error(invocationId: invocationId, ex: ex);
                throw;
            }
        }
    }
}
