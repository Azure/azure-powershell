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

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using Microsoft.Rest;
using System;
using Microsoft.Azure.Commands.Common.Authentication.Properties;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class HttpClientOperationsFactory : IHttpOperationsFactory
    {
        public const string Name = "HttpClientOperations";
        static HttpClient _client = new HttpClient();

        public static IHttpOperationsFactory Create()
        {
            return new HttpClientOperationsFactory();
        }

        public IHttpOperations<T> GetHttpOperations<T>()
        {
            return new HttpClientOperations<T>(_client);
        }

        class HttpClientOperations<T> : IHttpOperations<T>
        {
            HttpClient _client;
            IDictionary<string, IEnumerable<string>> _headers = new Dictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase);

            public HttpClientOperations(HttpClient client)
            {
                _client = client;
                ServiceClientTracing.IsEnabled = true;
            }

            public Task DeleteAsync(string requestUri, CancellationToken token)
            {
                return SafeSendRequestAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri), token);
            }

            public async Task<T> GetAsync(string requestUri, CancellationToken token)
            {
                var response = await SafeSendRequestAsync(new HttpRequestMessage(HttpMethod.Get, requestUri), token);
                var stringContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(stringContent);
            }

            public async Task<bool> HeadAsync(string requestUri, CancellationToken token)
            {
                var response = await SafeSendRequestAsync(new HttpRequestMessage(HttpMethod.Head, requestUri), token);
                return response.IsSuccessStatusCode;
            }

            public async Task<IEnumerable<T>> ListAsync(string requestUri, CancellationToken token)
            {
                var response = await SafeSendRequestAsync(new HttpRequestMessage(HttpMethod.Get, requestUri), token);
                var stringContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(stringContent);
            }

            public async Task<T> PutAsync(string requestUri, T payload, CancellationToken token)
            {
                var requestContent = JsonConvert.SerializeObject(payload);
                var request = new HttpRequestMessage(HttpMethod.Put, requestUri);
                request.Content = new StringContent(requestContent);
                var response = await SafeSendRequestAsync(request, token);
                var stringContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(stringContent);
            }

            public IHttpOperations<T> WithHeader(string name, IEnumerable<string> value)
            {
                ServiceClientTracing.Information(Resources.HttpClientAddingHeader, name);
                _headers.Add(name, value);
                return this;
            }

            async Task<HttpResponseMessage> SafeSendRequestAsync(HttpRequestMessage request, CancellationToken token)
            {
                var invocationId = string.Format(Resources.HttpClientOperationsInvocationId, ServiceClientTracing.NextInvocationId);
                foreach (var header in _headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }

                ServiceClientTracing.SendRequest(invocationId, request);
                var response = await _client.SendAsync(request, token);
                ServiceClientTracing.ReceiveResponse(invocationId, response);
                if (!response.IsSuccessStatusCode)
                {
                    var exception = new HttpRequestException(string.Format(Resources.HttpRequestExceptionMessage, 
                        response.StatusCode, request.Method, request.RequestUri, response.Content.ReadAsStringAsync().GetAwaiter().GetResult()));
                    ServiceClientTracing.Error(invocationId, exception);
                    throw exception;
                }

                return response;
            }
        }
    }
}
