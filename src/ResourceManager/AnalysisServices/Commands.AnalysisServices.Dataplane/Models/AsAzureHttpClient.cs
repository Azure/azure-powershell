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

        Task<HttpResponseMessage> CallPostAsync(Uri baseURI, string requestURL, string accessToken);
    }

    public class AsAzureHttpClient : IAsAzureHttpClient
    {
        public HttpClient HttpClient { get; set; }

        public AsAzureHttpClient(Func<HttpClient> httpClientProvider)
        {
            HttpClient = httpClientProvider();
        }

        public async Task<HttpResponseMessage> CallPostAsync(Uri baseURI, string requestURL, string accessToken)
        {
            using (HttpClient)
            {
                if (accessToken == null)
                {
                    throw new PSArgumentNullException("accessToken", string.Format(Resources.NotLoggedInMessage, ""));
                }

                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                HttpClient.BaseAddress = baseURI;
                HttpResponseMessage response = await HttpClient.PostAsync(requestURL, new StringContent(""));
                return response;
            }
        }
    }
}
