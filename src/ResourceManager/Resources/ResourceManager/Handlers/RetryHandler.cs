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
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
    
    /// <summary>
    /// A basic retry handler.
    /// </summary>
    public class RetryHandler : DelegatingHandler
    {
        /// <summary>
        /// The max number of attempts.
        /// </summary>
        private const int MaxAttempts = 3;

        /// <summary>
        /// The delta back-off.
        /// </summary>
        private static readonly TimeSpan DeltaBackoff = TimeSpan.FromSeconds(3);

        /// <summary>
        /// The max back-off.
        /// </summary>
        private static readonly TimeSpan MaxBackoff = TimeSpan.FromSeconds(10);

        /// <summary>
        /// The min back-off.
        /// </summary>
        private static readonly TimeSpan MinBackoff = TimeSpan.FromSeconds(1);

        /// <summary>
        /// Add the authentication token to the outgoing request.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;

            for (int attempt = 1; attempt <= RetryHandler.MaxAttempts; ++attempt)
            {
                try
                {
                    response = await base
                        .SendAsync(request: request, cancellationToken: cancellationToken)
                        .ConfigureAwait(continueOnCapturedContext: false);
                    
                    if (attempt == RetryHandler.MaxAttempts ||
                        (!response.StatusCode.IsServerFailureRequest() &&
                         response.StatusCode != HttpStatusCode.RequestTimeout &&
                         response.StatusCode != HttpStatusCodeExt.TooManyRequests))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    if (ex.IsFatal() || attempt == RetryHandler.MaxAttempts)
                    {
                        throw;
                    }
                }

                if (response != null)
                {
                    response.Dispose();
                }

                await Task.Delay(delay: RetryHandler.GetDelay(attempt), cancellationToken: cancellationToken)
                    .ConfigureAwait(continueOnCapturedContext: false);
            }

            return response;
        }

        /// <summary>
        /// Gets the delay for the task following an exponential back-off strategy
        /// </summary>
        /// <param name="attempt">The current attempt.</param>
        private static TimeSpan GetDelay(int attempt)
        {
            var random = new Random((int)(DateTime.UtcNow.Ticks & 0xFFFF));
            int num = (int)((Math.Pow(2.0, attempt) - 1.0) * (double)random.Next((int)(RetryHandler.DeltaBackoff.TotalMilliseconds * 0.8), (int)(RetryHandler.DeltaBackoff.TotalMilliseconds * 1.2)));
            int num2 = (int)Math.Min(RetryHandler.MinBackoff.TotalMilliseconds + num, RetryHandler.MaxBackoff.TotalMilliseconds);
            return TimeSpan.FromMilliseconds(num2);
        }
    }
}
