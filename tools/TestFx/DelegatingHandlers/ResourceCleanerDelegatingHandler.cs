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

using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.TestFx.DelegatingHandlers
{
    public class ResourceCleanerDelegatingHandler : DelegatingHandler
    {
        private readonly Regex _resourceGroupPattern = new Regex(@"/subscriptions/[^/]+/resourcegroups/([^?]+)\?api-version");
        private readonly HashSet<string> _resourceGroupsCreated = new HashSet<string>();
        private readonly TokenCredentials _tokenCredentials;

        public ResourceCleanerDelegatingHandler(TokenCredentials tokenCredentials)
        {
            _tokenCredentials = tokenCredentials;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_resourceGroupPattern.IsMatch(request.RequestUri.AbsoluteUri) && request.Method == HttpMethod.Put)
            {
                _resourceGroupsCreated.Add(request.RequestUri.AbsoluteUri);
            }

            return base.SendAsync(request, cancellationToken);
        }

        public async Task DeleteResourceGroups()
        {
            HttpClient httpClient = new HttpClient();
            foreach (var resourceGroupUri in _resourceGroupsCreated)
            {
                HttpRequestMessage httpRequest = new HttpRequestMessage
                {
                    Method = new HttpMethod("DELETE"),
                    RequestUri = new Uri(resourceGroupUri)
                };

                _tokenCredentials.ProcessHttpRequestAsync(httpRequest, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();

                HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest).ConfigureAwait(false);
                string groupName = _resourceGroupPattern.Match(resourceGroupUri).Groups[1].Value;
                string message = FormattableString.Invariant($"Started deletion of resource group '{groupName}'. Server responded with status code {httpResponse.StatusCode}.");
                Console.WriteLine(message);
                Debug.WriteLine(message);
            }
        }
    }
}
