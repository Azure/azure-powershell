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

using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Interfaces;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// Implementation for a class to acquire HTTP operations.
    /// </summary>
    public class HttpClientOperationsFactory : IHttpOperationsFactory
    {
        public const string Name = "HttpClientOperations";
        private static readonly HttpClient Client = new HttpClient();

        public static IHttpOperationsFactory Create()
        {
            return new HttpClientOperationsFactory();
        }

        public IHttpOperations GetHttpOperations()
        {
            return new HttpClientOperations(Client);
        }

        private class HttpClientOperations : IHttpOperations
        {
            private readonly HttpClient _client;

            public HttpClientOperations(HttpClient client)
            {
                _client = client;
            }

            public async Task<HttpResponseMessage> GetAsync(string requestUri)
            {
                return await _client.GetAsync(requestUri);
            }
        }
    }
}