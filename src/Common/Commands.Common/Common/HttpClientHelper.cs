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

using System.Net;
using System.Net.Http;
using Microsoft.WindowsAzure.Commands.Common.Factories;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class HttpClientHelper
    {
        public static HttpClient CreateClient(string serviceUrl, ICredentials credentials = null, HttpMessageHandler handler = null)
        {
            if (credentials != null)
            {
                return ClientFactory.CreateHttpClientBase(serviceUrl, ClientFactory.CreateHttpClientHandler(serviceUrl, credentials));
            }
            else
            {
                return ClientFactory.CreateHttpClientBase(serviceUrl, handler);
            }
        }
    }
}