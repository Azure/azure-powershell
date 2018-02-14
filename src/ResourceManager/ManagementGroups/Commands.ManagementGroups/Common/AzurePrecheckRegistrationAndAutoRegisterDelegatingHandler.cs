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

namespace Microsoft.Azure.Commands.ManagementGroups.Common
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.ResourceManager.Common.Properties;
    using Microsoft.Azure.Management.Internal.Resources;
    using Microsoft.Azure.Management.Internal.Resources.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    public class AzurePrecheckRegistrationAndAutoRegisterDelegatingHandler : DelegatingHandler, ICloneable
    {
        private const short RetryCount = 10;

        private Func<ResourceManagementClient> createClient;

        private Action<string> writeDebug;

        private string providerName;

        public ResourceManagementClient ResourceManagementClient { get; set; }

        public AzurePrecheckRegistrationAndAutoRegisterDelegatingHandler(string providerName, Func<ResourceManagementClient> createClient, Action<string> writeDebug)
        {
            this.providerName = providerName;
            this.writeDebug = writeDebug;
            this.createClient = createClient;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage = null;
            try
            {
                ResourceManagementClient = createClient();
                writeDebug($"Attempting to check if Subscription is registered with {this.providerName}");
                var provider = ResourceManagementClient.Providers.Get(this.providerName);
                if (provider.RegistrationState != RegistrationState.Registered)
                {
                    writeDebug(string.Format(Resources.ResourceProviderRegisterAttempt, this.providerName));
                    short retryCount = 0;
                    do
                    {
                        if (retryCount++ > RetryCount)
                        {
                            throw new TimeoutException();
                        }
                        provider = ResourceManagementClient.Providers.Register(this.providerName);
                        TestMockSupport.Delay(2000);
                    } while (provider.RegistrationState != RegistrationState.Registered);
                    writeDebug(string.Format(Resources.ResourceProviderRegisterSuccessful, this.providerName));
                }

                responseMessage = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                writeDebug(string.Format(Resources.ResourceProviderRegisterFailure, this.providerName, e.Message));

                if (e.Message?.IndexOf("does not have authorization") >= 0 && e.Message?.IndexOf("register/action",
                        StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    throw new CloudException(e.Message);
                }
            }

            return responseMessage;
        }

        public object Clone()
        {
            return new AzurePrecheckRegistrationAndAutoRegisterDelegatingHandler(this.providerName, createClient, writeDebug);
        }
    }
}