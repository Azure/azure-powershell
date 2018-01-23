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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Properties;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models
{
    public interface IAsAzureHttpClient
    {
        HttpClient HttpClient { get; set; }

        Task<HttpResponseMessage> CallPostAsync(Uri baseURI, string requestURL, string accessToken, HttpContent content = null);

        Task<HttpResponseMessage> CallPostAsync(Uri baseURI, string requestURL, string accessToken, Guid correlationId, HttpContent content = null);

        Task<HttpResponseMessage> CallGetAsync(Uri baseURI, string requestURL, string accessToken);

        Task<HttpResponseMessage> CallGetAsync(Uri baseURI, string requestURL, string accessToken, Guid correlationId);

        void resetHttpClient();
    }

    public class AsAzureHttpClient : IAsAzureHttpClient
    {
        public const string ParentActivityId = "x-ms-parent-activity-id";

        public HttpClient HttpClient { get; set; }

        private Func<HttpClient> HttpClientProvider { get; set; } 

        public AsAzureHttpClient(Func<HttpClient> httpClientProvider)
        {
            this.HttpClientProvider = httpClientProvider;
            this.HttpClient = this.HttpClientProvider();
        }

        public async Task<HttpResponseMessage> CallGetAsync(Uri baseURI, string requestURL, string accessToken)
        {
            return await CallGetAsync(baseURI, requestURL, accessToken, new Guid());
        }

        public async Task<HttpResponseMessage> CallGetAsync(Uri baseURI, string requestURL, string accessToken, Guid correlationId)
        {
            return await CallAsync(HttpMethod.Get, baseURI, requestURL, accessToken, correlationId);
        }

        public async Task<HttpResponseMessage> CallPostAsync(Uri baseURI, string requestURL, string accessToken, HttpContent content = null)
        {
            return await CallPostAsync(baseURI, requestURL, accessToken, new Guid(), content);
        }

        public async Task<HttpResponseMessage> CallPostAsync(Uri baseURI, string requestURL, string accessToken, Guid correlationId, HttpContent content = null)
        {
            return await CallAsync(HttpMethod.Post, baseURI, requestURL, accessToken, correlationId, content);
        }

        public void resetHttpClient()
        {
            this.HttpClient = this.HttpClientProvider();
        }

        private async Task<HttpResponseMessage> CallAsync(HttpMethod method, Uri baseURI, string requestURL, string accessToken, Guid correlationId, HttpContent content = null)
        {
            using (HttpClient)
            {
                if (accessToken == null)
                {
                    throw new PSArgumentNullException("accessToken", string.Format(Resources.NotLoggedInMessage, ""));
                }
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                if (correlationId == null || correlationId == Guid.Empty)
                {
                    correlationId = new Guid();
                }

                HttpClient.DefaultRequestHeaders.Add(ParentActivityId, new List<string>() { correlationId.ToString() });

                HttpClient.BaseAddress = baseURI;
                if (method == HttpMethod.Get)
                {
                    return await HttpClient.GetAsync(requestURL);
                }

                if (content == null)
                {
                    content = new StringContent("");
                }
                return await HttpClient.PostAsync(requestURL, content);
            }
        } 
    }
}
