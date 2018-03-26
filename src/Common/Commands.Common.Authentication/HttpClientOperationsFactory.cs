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
using System.Collections.Concurrent;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class HttpClientOperationsFactory : IHttpOperationsFactory
    {
        public const string Name = "HttpClientOperations";
        static HttpClient _client = new HttpClient();
        static ConcurrentDictionary<string, ICacheable> _cachedItems = new ConcurrentDictionary<string, ICacheable>();

        public static IHttpOperationsFactory Create()
        {
            return new HttpClientOperationsFactory();
        }

        public IHttpOperations<T> GetHttpOperations<T>() where T : class, ICacheable
        {
            return new HttpClientOperations<T>(_client);
        }

        public IHttpOperations<T> GetHttpOperations<T>(bool useCaching) where T : class, ICacheable
        {
            return new HttpClientOperations<T>(_client, _cachedItems);
        }

        class HttpClientOperations<T> : IHttpOperations<T> where T : class, ICacheable
        {
            HttpClient _client;
            ConcurrentDictionary<string, IEnumerable<string>> _headers = new ConcurrentDictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase);
            ConcurrentDictionary<string, ICacheable> _cache;
            public HttpClientOperations(HttpClient client, ConcurrentDictionary<string, ICacheable> cache = null)
            {
                _client = client;
                ServiceClientTracing.IsEnabled = true;
                _cache = cache;
            }

            public Task DeleteAsync(string requestUri, CancellationToken token)
            {
                InvalidateCache(requestUri);
                return SafeSendRequestAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri), token);
            }

            public async Task<T> GetAsync(string requestUri, CancellationToken token)
            {
                T result;
                if (!TryGetFromCache(requestUri, out result))
                {
                    var response = await SafeSendRequestAsync(new HttpRequestMessage(HttpMethod.Get, requestUri), token);
                    var stringContent = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T>(stringContent);
                    SaveInCache(requestUri, result);
                }

                return result;
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
                InvalidateCache(requestUri);
                T result = JsonConvert.DeserializeObject<T>(stringContent);
                SaveInCache(requestUri, result);
                return result;
            }

            public IHttpOperations<T> WithHeader(string name, IEnumerable<string> value)
            {
                ServiceClientTracing.Information(Resources.HttpClientAddingHeader, name);
                _headers.TryAdd(name, value);
                return this;
            }

            /// <summary>
            /// Invalidate a cache value due to an event (for example, the cache value was aritten)
            /// </summary>
            /// <param name="requestUri">The uri of the entity to cache</param>
            protected virtual void InvalidateCache(string requestUri)
            {
                ICacheable removed;
                _cache?.TryRemove(requestUri, out removed);
            }

            /// <summary>
            /// Get The value from the cache
            /// </summary>
            /// <param name="requestUri"></param>
            /// <param name="value"></param>
            /// <returns></returns>
            protected virtual bool TryGetFromCache(string requestUri, out T value)
            {
                bool result = false;
                value = null;
                ICacheable cacheValue;
                ServiceClientTracing.Information(string.Format(Resources.CacheCheck, requestUri));
                if (_cache != null && _cache.TryGetValue(requestUri, out cacheValue))
                {
                    ServiceClientTracing.Information(Resources.CacheHit);
                    if (cacheValue.IsExpired())
                    {
                        _cache.TryRemove(requestUri, out cacheValue);
                    }
                    else
                    {
                        result = true;
                        value = cacheValue as T;
                    }
                }

                return result;
            }

            /// <summary>
            /// Save the given request payload in the cache
            /// </summary>
            /// <param name="requestUri">The request uri to save</param>
            /// <param name="value">The payload value to save</param>
            protected virtual void SaveInCache(string requestUri, T value)
            {
                if (_cache!= null && value != null && value.ShouldCache())
                {
                    _cache.TryAdd(requestUri, value);
                }
            }

            async Task<HttpResponseMessage> SafeSendRequestAsync(HttpRequestMessage request, CancellationToken token)
            {
                var invocationId = string.Format(Resources.HttpClientOperationsInvocationId, ServiceClientTracing.NextInvocationId);
                foreach (var header in _headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }

                ServiceClientTracing.SendRequest(invocationId, request);
                var client = new HttpClientWithRetry(_client);
                var response = await client.SendAsync(request, token);
                ServiceClientTracing.ReceiveResponse(invocationId, response);
                if (!response.IsSuccessStatusCode)
                {
                    var exception = new CloudException(string.Format(Resources.HttpRequestExceptionMessage, 
                        response.StatusCode, request.Method, request.RequestUri, response.Content.ReadAsStringAsync().GetAwaiter().GetResult()));
                    exception.Request = new HttpRequestMessageWrapper(request, "");
                    exception.Response = new HttpResponseMessageWrapper(response, "");
                    ServiceClientTracing.Error(invocationId, exception);
                    throw exception;
                }

                return response;
            }
        }
    }
}
