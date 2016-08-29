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

using Microsoft.Azure.Commands.ResourceManager.Common.Properties;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication.Models
{
    public class RPRegistrationDelegatingHandler : DelegatingHandler, ICloneable
    {
        private const short RetryCount = 3;

        /// <summary>
        /// Contains all providers we have attempted to register 
        /// </summary>
        private HashSet<string> registeredProviders;

        private Func<ResourceManagementClient> createClient;

        private Action<string> writeDebug;

        public ResourceManagementClient ResourceManagementClient { get; set; }

        public RPRegistrationDelegatingHandler(Func<ResourceManagementClient> createClient, Action<string> writeDebug)
        {
            registeredProviders = new HashSet<string>();
            this.writeDebug = writeDebug;
            this.createClient = createClient;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            if (IsProviderNotRegistereError(responseMessage))
            {
                var providerName = GetProviderName(request.RequestUri);
                if (!string.IsNullOrEmpty(providerName) && !registeredProviders.Contains(providerName))
                {
                    // Force dispose for response messages to reclaim the used socket connection.
                    responseMessage.Dispose();
                    registeredProviders.Add(providerName);
                    try
                    {
                        ResourceManagementClient = createClient();
                        writeDebug(string.Format(Resources.ResourceProviderRegisterAttempt, providerName));
                        ResourceManagementClient.Providers.Register(providerName);
                        Provider provider = null;
                        short retryCount = 0;
                        do
                        {
                            if (retryCount++ > RetryCount)
                            {
                                throw new TimeoutException();
                            }
                            provider = ResourceManagementClient.Providers.Get(providerName).Provider;
                            TestMockSupport.Delay(1000);
                        } while (provider.RegistrationState != RegistrationState.Registered.ToString());
                        writeDebug(string.Format(Resources.ResourceProviderRegisterSuccessful, providerName));
                    }
                    catch (Exception e)
                    {
                        writeDebug(string.Format(Resources.ResourceProviderRegisterFailure, providerName, e.Message));
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

        public object Clone()
        {
            return new RPRegistrationDelegatingHandler(createClient, writeDebug);
        }
    }
}
