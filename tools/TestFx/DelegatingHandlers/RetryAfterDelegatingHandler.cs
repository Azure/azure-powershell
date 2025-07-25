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
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.TestFx.DelegatingHandlers
{
    public class RetryAfterDelegatingHandler : DelegatingHandler
    {
        public int MaxRetries { get; set; } = int.MaxValue;

        public RetryAfterDelegatingHandler()
        {
        }

        public RetryAfterDelegatingHandler(DelegatingHandler innerHandler)
            : this((HttpMessageHandler)innerHandler)
        {
        }

        public RetryAfterDelegatingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            int attempts = 0;
            HttpResponseMessage previousResponseMessage = null;
            do
            {
                HttpResponseMessage response = null;

                try
                {
                    attempts++;
                    response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

                    // if they send back a 429 and there is a retry-after header
                    if (attempts < MaxRetries &&
                        response.StatusCode == (HttpStatusCode)429 &&
                        response.Headers.Contains("Retry-After"))
                    {
                        try
                        {
                            // Read back the response message content so it does not go away as this response could be
                            // used if retries continue to fail.
                            // NOTE: If the content is not read and this message is returned later, an IO Exception will end up
                            //       happening indicating that request has been aborted.
                            if (response.Content != null)
                            {
                                await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            }

                            var oldResponse = previousResponseMessage;
                            previousResponseMessage = response;
                            oldResponse?.Dispose();
                        }
                        catch
                        {
                            // We can end up getting errors reading the content of the message if the connection was closed.
                            // These errors will be ignored and the previous response will continue to be used.
                            if (previousResponseMessage != null)
                            {
                                response = previousResponseMessage;
                            }
                        }

                        try
                        {
                            // and we get a number of seconds from the header
                            string retryValue = response.Headers.GetValues("Retry-After").FirstOrDefault();
                            var retryAfter = int.Parse(retryValue, CultureInfo.InvariantCulture);

                            // wait for that duration
                            await Task.Delay(TimeSpan.FromSeconds(retryAfter), cancellationToken).ConfigureAwait(false);

                            // and try again
                            continue;
                        }
                        catch
                        {
                            // if something throws while trying to get the retry-after
                            // we're just going to suppress it. let the response go
                            // back to the consumer.
                        }
                    }
                }
                catch (TaskCanceledException) when (previousResponseMessage != null)
                {
                    // We can get Task Canceled Exceptions while calling the base.SendAsync(...) and
                    // we do not want to let these bubble out when we have a previous response message to return.
                }

                // if we haven't hit continue, then return the response up the stream
                return response ?? previousResponseMessage;
            } while (true);
        }
    }
}
