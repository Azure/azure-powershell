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
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Resources;

namespace Microsoft.Azure.Common.Authentication.Models
{
    public class RPRegistrationDelegatingHandler : DelegatingHandler
    {
        /// <summary>
        /// Contains all providers we have attempted to register 
        /// </summary>
        private HashSet<string> registeredProviders;

        private ResourceManagementClient client;

        private Action<string> writeVerbose;

        public RPRegistrationDelegatingHandler(IClientFactory clientFactory, AzureContext context, Action<string> writeVerbose)
        {
            client = clientFactory.CreateClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
            registeredProviders = new HashSet<string>();
            this.writeVerbose = writeVerbose;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            if (IsProviderNotRegistereError(responseMessage))
            {
                var providerName = GetProviderName(request.RequestUri);
                if (!string.IsNullOrEmpty(providerName) && !registeredProviders.Contains(providerName))
                {
                    registeredProviders.Add(providerName);
                    try
                    {
                        writeVerbose(string.Format("Attempting to register resource provider '{0}'", providerName));
                        // Assume registration is instantanuous.
                        client.Providers.Register(providerName);
                        writeVerbose(string.Format("Succeeded to register resource provider '{0}'", providerName));
                    }
                    catch
                    {
                        writeVerbose(string.Format("Failed to register resource provider '{0}'", providerName));
                        // Ignore RP registration errors.
                    }

                    responseMessage = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
                }
            }
            return responseMessage;
        }

        private bool IsProviderNotRegistereError(HttpResponseMessage responseMessage)
        {
            return responseMessage.StatusCode == System.Net.HttpStatusCode.Conflict &&
                responseMessage.Content.ReadAsStringAsync().Result.Contains("registered to use namespace");
        }

        /// <summary>
        /// Extract provider name from request uri such as
        /// "https://management.azure.com/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/{resource-provider-name}"
        /// We analyze the uri's segments and check the index of 5 is "providers/" and return the next segment.    
        /// </summary>
        /// <param name="requestUri">request uri to extract provider out</param>
        /// <returns>provider name, or null on unexpected format</returns>
        private string GetProviderName(Uri requestUri)
        {
            return (requestUri.Segments.Length > 7 && requestUri.Segments[5].ToLower() == "providers/") ?
                requestUri.Segments[6].ToLower().Trim('/') : null;
        }
    }
}
