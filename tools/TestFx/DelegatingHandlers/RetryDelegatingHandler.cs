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

using Microsoft.Azure.Common.Properties;
using Microsoft.Rest.TransientFaultHandling;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.TestFx.DelegatingHandlers
{
    internal class RetryDelegatingHandler : DelegatingHandler
    {
        private const int DefaultNumberOfAttempts = 3;
        private readonly TimeSpan DefaultBackoffDelta = new TimeSpan(0, 0, 10);
        private readonly TimeSpan DefaultMaxBackoff = new TimeSpan(0, 0, 10);
        private readonly TimeSpan DefaultMinBackoff = new TimeSpan(0, 0, 1);

        public RetryPolicy RetryPolicy { get; set; }

        public RetryDelegatingHandler() : base()
        {
            Init();
        }

        public RetryDelegatingHandler(DelegatingHandler innerHandler)
            : this((HttpMessageHandler)innerHandler)
        {
        }

        public RetryDelegatingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            Init();
        }

        public RetryDelegatingHandler(RetryPolicy retryPolicy, HttpMessageHandler innerHandler)
            : this(innerHandler)
        {
            RetryPolicy = retryPolicy ?? throw new ArgumentNullException("retryPolicy");
        }

        private void Init()
        {
            var retryStrategy = new ExponentialBackoffRetryStrategy(
                DefaultNumberOfAttempts,
                DefaultMinBackoff,
                DefaultMaxBackoff,
                DefaultBackoffDelta);

            RetryPolicy = new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(retryStrategy);
        }

        /// <summary>
        /// Get delegate count associated with the event
        /// </summary>
        public int EventCallbackCount => this.RetryPolicy.EventCallbackCount;

        /// <summary>
        /// Sends an HTTP request to the inner handler to send to the server as an asynchronous
        /// operation. Retries request if needed based on Retry Policy.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <returns>Returns System.Threading.Tasks.Task&lt;TResult&gt;. The
        /// task object representing the asynchronous operation.</returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage = null;
            HttpResponseMessage lastErrorResponseMessage = null;
            try
            {
                await RetryPolicy.ExecuteAsync(async () =>
                {
                    responseMessage = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        try
                        {
                            // Save off the response message and read back its content so it does not go away as this
                            // response will be used if retries continue to fail.
                            // NOTE: If the content is not read and this message is returned later, an IO Exception will end up
                            //       happening indicating that the stream has been aborted.
                            if (responseMessage.Content != null)
                            {
                                await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                            }

                            var oldResponse = lastErrorResponseMessage;
                            lastErrorResponseMessage = responseMessage;
                            oldResponse?.Dispose();
                        }
                        catch
                        {
                            // We can end up getting errors reading the content of the message if the connection was closed.
                            // These errors will be ignored and the previous last error response will continue to be used.
                            if (lastErrorResponseMessage != null)
                            {
                                responseMessage = lastErrorResponseMessage;
                            }
                        }

                        throw new HttpRequestWithStatusException(string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.ResponseStatusCodeError,
                            (int)responseMessage.StatusCode,
                            responseMessage.StatusCode))
                        { StatusCode = responseMessage.StatusCode };
                    }

                    return responseMessage;
                }, cancellationToken).ConfigureAwait(false);

                return responseMessage;
            }
            catch (Exception) when (responseMessage != null || lastErrorResponseMessage != null)
            {
                return responseMessage ?? lastErrorResponseMessage;
            }
        }
    }
}
