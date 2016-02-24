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
using System.Net;
using System.Net.Http;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Factories;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites
{
    public abstract class KuduRemoteClientBase
    {
        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        protected KuduRemoteClientBase()
        {

        }

        protected KuduRemoteClientBase(
            string serviceUrl,
            ICredentials credentials = null,
            HttpMessageHandler handler = null)
        {
            if (serviceUrl == null)
            {
                throw new ArgumentNullException("serviceUrl");
            }

            ServiceUrl = GeneralUtilities.EnsureTrailingSlash(serviceUrl);
            Credentials = credentials;
         
            if (credentials != null)
            {
                Client = AzureSession.ClientFactory.CreateHttpClient(serviceUrl, ClientFactory.CreateHttpClientHandler(serviceUrl, credentials));
            }
            else
            {
                Client = AzureSession.ClientFactory.CreateHttpClient(serviceUrl, handler);
            }
        }

        public string ServiceUrl { get; private set; }

        public ICredentials Credentials { get; private set; }

        public HttpClient Client { get; private set; }
    }
}
