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

using Microsoft.Azure.Commands.Common.Authentication.Utilities;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class HttpClientWithRetry
    {
        HttpClient _client;
        Func<IHttpRetryAlgorithm> _retry;

        public HttpClientWithRetry()
            : this(new HttpClient(), () => HttpRetryAlgorithm.Default)
        {
            _client = new HttpClient();
        }

        public HttpClientWithRetry(TimeSpan interval, int multiplier, int maxTries) :
            this(new HttpClient(), () => HttpRetryAlgorithm.GetExponentialRetryAlgorithm(interval, multiplier, maxTries))
        {
        }

        public HttpClientWithRetry(HttpClient client):
            this(client, () => HttpRetryAlgorithm.Default)
        {

        }

        public HttpClientWithRetry(HttpClient client, Func<IHttpRetryAlgorithm> retry)
        {
            _client = client;
            _retry = retry;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token)
        {
            HttpResponseMessage response = null;
            var retry = _retry();
            do
            {
                if (response != null)
                {
                    response.Dispose();
                }
                await retry.WaitForRetry();
                var sentRequest = CopyRequest(request);
                response = await _client.SendAsync(sentRequest, token);
            }
            while (!response.IsSuccessStatusCode && retry.ShouldRetry(response));
            return response;
        }

        private HttpRequestMessage CopyRequest(HttpRequestMessage request)
        {
            var result = new HttpRequestMessage(request.Method, request.RequestUri);
            foreach(var header in request.Headers)
            {
                result.Headers.Add(header.Key, header.Value);
            }

            result.Content = request.Content;
            return result;
        }
    }
}
