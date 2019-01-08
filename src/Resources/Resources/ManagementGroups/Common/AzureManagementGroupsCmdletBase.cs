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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.ManagementGroups;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Resources.ManagementGroups.Common
{
    /// <summary>
    /// Base class of Azure Management Groups Cmdlet.
    /// </summary>
    public abstract class AzureManagementGroupsCmdletBase : AzureRMCmdlet
    {
        private IManagementGroupsAPIClient _managementGroupsApiClient;

        /// <summary>
        /// Gets or sets the Groups RP client.
        /// </summary>
        public IManagementGroupsAPIClient ManagementGroupsApiClient
        {
            get
            {
                return _managementGroupsApiClient ??
                       (_managementGroupsApiClient =
                           AzureSession.Instance.ClientFactory.CreateArmClient<ManagementGroupsAPIClient>(
                               DefaultProfile.DefaultContext,
                               AzureEnvironment.Endpoint.ResourceManager));
            }
            set { _managementGroupsApiClient = value; }

        }

        public void PreregisterSubscription(string subscriptionId)
        {
            IAzureContext context;
            if (TryGetDefaultContext(out context)
                && context.Account != null
                && context.Subscription != null)
            {
                if (subscriptionId == context.Subscription.Id)
                {
                    return;
                }

                short RetryCount = 10;
                string providerName = "Microsoft.Management";
                try
                {
                    var rmclient = new ResourceManagementClient(
                        context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                        AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context, AzureEnvironment.Endpoint.ResourceManager))
                    {
                        SubscriptionId = subscriptionId
                    };
                    var provider = rmclient.Providers.Get(providerName);
                    if (provider.RegistrationState != RegistrationState.Registered)
                    {
                        short retryCount = 0;
                        do
                        {
                            if (retryCount++ > RetryCount)
                            {
                                throw new TimeoutException();
                            }
                            provider = rmclient.Providers.Register(providerName);
                            TestMockSupport.Delay(2000);
                        } while (provider.RegistrationState != RegistrationState.Registered);
                    }
                }
                catch (Exception e)
                {
                    if (e.Message?.IndexOf("does not have authorization") >= 0 && e.Message?.IndexOf("register/action",
                            StringComparison.InvariantCultureIgnoreCase) >= 0)
                    {
                        throw new CloudException(e.Message);
                    }
                }
            }
        }

        public void PreregisterSubscription()
        {
            IAzureContext context;
            if (TryGetDefaultContext(out context)
                && context.Account != null
                && context.Subscription != null)
            {
                short RetryCount = 10;
                string providerName = "Microsoft.Management";
                try
                {
                    var rmclient = new ResourceManagementClient(
                        context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                        AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context, AzureEnvironment.Endpoint.ResourceManager))
                    {
                        SubscriptionId = context.Subscription.Id
                    };
                    var provider = rmclient.Providers.Get(providerName);
                    if (provider.RegistrationState != RegistrationState.Registered)
                    {
                        short retryCount = 0;
                        do
                        {
                            if (retryCount++ > RetryCount)
                            {
                                throw new TimeoutException();
                            }
                            provider = rmclient.Providers.Register(providerName);
                            TestMockSupport.Delay(2000);
                        } while (provider.RegistrationState != RegistrationState.Registered);
                    }
                }
                catch (Exception e)
                {
                    if (e.Message?.IndexOf("does not have authorization") >= 0 && e.Message?.IndexOf("register/action",
                            StringComparison.InvariantCultureIgnoreCase) >= 0)
                    {
                        throw new CloudException(e.Message);
                    }
                }
            }
        }
    }
}
