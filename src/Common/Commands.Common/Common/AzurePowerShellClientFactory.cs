﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Management.Resources;
using Microsoft.WindowsAzure.Commands.Common.Factories;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Common;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Management;
using Microsoft.Azure.Management.Resources.Models;

namespace Microsoft.WindowsAzure.Commands.Common.Common
{
    public class AzurePowerShellClientFactory : ClientFactory
    {
        public override TClient CreateClient<TClient>(AzureContext context, AzureEnvironment.Endpoint endpoint)
        {
            TClient client = base.CreateClient<TClient>(context, endpoint);

            if (!TestMockSupport.RunningMocked)
            {
                if (endpoint == AzureEnvironment.Endpoint.ServiceManagement)
                {
                    RegisterServiceManagementProviders<TClient>(context);
                }
                else if (endpoint == AzureEnvironment.Endpoint.ResourceManager)
                {
                    RegisterResourceManagerProviders<TClient>(context);
                }
            }

            return client;
        }
                
        public override void RegisterCustomProviders(IEnumerable<string> providers)
        {
            var context = AzureSession.CurrentContext;
            var registeredProviders = context.Subscription.GetPropertyAsArray(
                                            AzureSubscription.Property.RegisteredResourceProviders);
            var successfullyRegisteredProvider = new List<string>();
            var creds = AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(context);

            var requiredProviders = providers.Where(p => !registeredProviders.Contains(p))
                                             .ToList();

            if (requiredProviders.Count > 0)
            {
                using (var client = AzureSession.ClientFactory.CreateCustomClient<ResourceManagementClient>(
                    creds,
                    context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager)))
                {
                    foreach (var provider in requiredProviders)
                    {
                        try
                        {
                            client.Providers.Register(provider);
                            successfullyRegisteredProvider.Add(provider);
                        }
                        catch
                        {
                            // Ignore this as the user may not have access to Sparta endpoint or the provider is already registered
                        }
                    }
                }

                UpdateSubscriptionRegisteredProviders(context.Subscription, successfullyRegisteredProvider);
            }
        }

        /// <summary>
        /// Registers resource providers for Sparta.
        /// </summary>
        /// <typeparam name="T">The client type</typeparam>
        private void RegisterResourceManagerProviders<T>(AzureContext context) where T : ServiceClient<T>
        {
            var providersToRegister = RequiredResourceLookup.RequiredProvidersForResourceManager<T>();
            var registeredProviders = context.Subscription.GetPropertyAsArray(AzureSubscription.Property.RegisteredResourceProviders);
            var unregisteredProviders = providersToRegister.Where(p => !registeredProviders.Contains(p)).ToList();
            var successfullyRegisteredProvider = new List<string>();
            SubscriptionCloudCredentials creds = AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(context);

            if (unregisteredProviders.Count > 0)
            {
                using (var client = CreateCustomClient<ResourceManagementClient>(creds, context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager)))
                {
                    foreach (string provider in unregisteredProviders)
                    {
                        try
                        {
                            client.Providers.Register(provider);
                            successfullyRegisteredProvider.Add(provider);
                        }
                        catch
                        {
                            // Ignore this as the user may not have access to service management endpoint or the provider is already registered
                        }
                    }
                }

                UpdateSubscriptionRegisteredProviders(context.Subscription, successfullyRegisteredProvider);
            }
        }

        /// <summary>
        /// Registers resource providers for RDFE.
        /// </summary>
        /// <typeparam name="T">The client type</typeparam>
        private void RegisterServiceManagementProviders<T>(AzureContext context) where T : ServiceClient<T>
        {
            var credentials = AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(context);
            var providersToRegister = RequiredResourceLookup.RequiredProvidersForServiceManagement<T>();
            var registeredProviders = context.Subscription.GetPropertyAsArray(AzureSubscription.Property.RegisteredResourceProviders);
            var unregisteredProviders = providersToRegister.Where(p => !registeredProviders.Contains(p)).ToList();
            var successfullyRegisteredProvider = new List<string>();

            if (unregisteredProviders.Count > 0)
            {
                using (var client = new ManagementClient(credentials, context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ServiceManagement)))
                {
                    foreach (var provider in unregisteredProviders)
                    {
                        try
                        {
                            client.Subscriptions.RegisterResource(provider);
                        }
                        catch (CloudException ex)
                        {
                            if (ex.Response.StatusCode != HttpStatusCode.Conflict && ex.Response.StatusCode != HttpStatusCode.NotFound)
                            {
                                // Conflict means already registered, that's OK.
                                // NotFound means there is no registration support, like Windows Azure Pack.
                                // Otherwise it's a failure.
                                throw;
                            }
                        }
                        successfullyRegisteredProvider.Add(provider);
                    }
                }

                UpdateSubscriptionRegisteredProviders(context.Subscription, successfullyRegisteredProvider);
            }
        }

        private void UpdateSubscriptionRegisteredProviders(AzureSubscription subscription, List<string> providers)
        {
            if (providers != null && providers.Count > 0)
            {
                subscription.SetOrAppendProperty(AzureSubscription.Property.RegisteredResourceProviders,
                    providers.ToArray());
                try
                {
                    ProfileClient profileClient = new ProfileClient();
                    profileClient.AddOrSetSubscription(subscription);
                    profileClient.Profile.Save();
                }
                catch (KeyNotFoundException)
                {
                    // if using a subscription data file, do not write registration to disk
                    // long term solution is using -Profile parameter
                }
            }
        }
    }
}
