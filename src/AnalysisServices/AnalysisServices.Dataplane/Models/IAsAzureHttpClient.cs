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
using System.Net.Http;
using System.Threading.Tasks;

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
}
