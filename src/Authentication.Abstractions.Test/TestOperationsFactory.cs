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

using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Interfaces;

namespace Authentication.Abstractions.Test
{
    internal class TestOperationsFactory : IHttpOperationsFactory
    {
        public const string Name = "HttpClientOperations";
        private static readonly HttpClient Client = new HttpClient();

        public static IHttpOperationsFactory Create()
        {
            return new TestOperationsFactory();
        }

        public IHttpOperations GetHttpOperations()
        {
            return new TestClientOperations(Client);
        }

        private class TestClientOperations : IHttpOperations
        {
            private readonly HttpClient _client;

            public TestClientOperations(HttpClient client)
            {
                _client = client;
            }

            public async Task<HttpResponseMessage> GetAsync(string responsePayloadFilename)
            {
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                    {Content = new StringContent(File.ReadAllText(responsePayloadFilename))};
                return await Task.FromResult(httpResponseMessage);
            }
        }
    }
}