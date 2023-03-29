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
//

using Azure.Core.Pipeline;
using Microsoft.Identity.Client;
using System.Net.Http;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    /// <summary>
    /// This class is an HttpClient factory which creates an HttpClient which delegates it's transport to an HttpPipeline, to enable MSAL to send requests through an Azure.Core HttpPipeline.
    /// </summary>
    internal class HttpPipelineClientFactory : IMsalHttpClientFactory
    {
        private readonly HttpPipeline _pipeline;

        public HttpPipelineClientFactory(HttpPipeline pipeline)
        {
            _pipeline = pipeline;
        }

        public HttpClient GetHttpClient()
        {
            return new HttpClient(new HttpPipelineMessageHandler(_pipeline));
        }
    }
}
