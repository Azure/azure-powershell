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
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Hyak.Common;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Common;
using Microsoft.Azure.Common.Authentication.Factories;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure;
using System.IO;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Mocks
{
    public class MockClientFactory : IClientFactory
    {
        private readonly bool throwWhenNotAvailable;

        public List<object> ManagementClients { get; private set; }

        public MockClientFactory(IEnumerable<object> clients, bool throwIfClientNotSpecified = true)
        {
            UserAgents = new List<ProductInfoHeaderValue>();
            ManagementClients = clients.ToList();
            throwWhenNotAvailable = throwIfClientNotSpecified;
        }

        public TClient CreateClient<TClient>(AzureContext context, AzureEnvironment.Endpoint endpoint) where TClient : ServiceClient<TClient>
        {
            Debug.Assert(context != null);

            SubscriptionCloudCredentials creds = AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(context);
            TClient client = CreateCustomClient<TClient>(creds, context.Environment.GetEndpointAsUri(endpoint));

            return client;
        }

        public TClient CreateClient<TClient>(AzureProfile profile, AzureEnvironment.Endpoint endpoint) where TClient : ServiceClient<TClient>
        {
            throw new NotImplementedException();
        }

        public TClient CreateClient<TClient>(AzureProfile profile, AzureSubscription subscription, AzureEnvironment.Endpoint endpoint) where TClient : ServiceClient<TClient>
        {
            if (subscription == null)
            {
                throw new ArgumentException(Commands.Common.Properties.Resources.InvalidDefaultSubscription);
            }

            if (profile == null)
            {
                profile = new AzureProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            }

            SubscriptionCloudCredentials creds = new TokenCloudCredentials(subscription.Id.ToString(), "fake_token");
            if (HttpMockServer.GetCurrentMode() != HttpRecorderMode.Playback)
            {
                ProfileClient profileClient = new ProfileClient(profile);
                AzureContext context = new AzureContext(
                    subscription,
                    profileClient.GetAccount(subscription.Account),
                    profileClient.GetEnvironmentOrDefault(subscription.Environment)
                );

                creds = AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(context);
            }

            Uri endpointUri = profile.Environments[subscription.Environment].GetEndpointAsUri(endpoint);
            return CreateCustomClient<TClient>(creds, endpointUri);
        }

        public TClient CreateCustomClient<TClient>(params object[] parameters) where TClient : ServiceClient<TClient>
        {
            TClient client = ManagementClients.FirstOrDefault(o => o is TClient) as TClient;
            if (client == null)
            {
                if (throwWhenNotAvailable)
                {
                    throw new ArgumentException(
                        string.Format("TestManagementClientHelper class wasn't initialized with the {0} client.",
                            typeof(TClient).Name));
                }
                else
                {
                    var realClientFactory = new ClientFactory();
                    var realClient = realClientFactory.CreateCustomClient<TClient>(parameters);
                    var newRealClient = realClient.WithHandler(HttpMockServer.CreateInstance());
                    realClient.Dispose();
                    return newRealClient;
                }
            }

            return client;
        }

        public HttpClient CreateHttpClient(string endpoint, ICredentials credentials)
        {
            return CreateHttpClient(endpoint, ClientFactory.CreateHttpClientHandler(endpoint, credentials));
        }

        public HttpClient CreateHttpClient(string serviceUrl, HttpMessageHandler effectiveHandler)
        {
            if (serviceUrl == null)
            {
                throw new ArgumentNullException("serviceUrl");
            }
            if (effectiveHandler == null)
            {
                throw new ArgumentNullException("effectiveHandler");
            }
            var mockHandler = HttpMockServer.CreateInstance();
            mockHandler.InnerHandler = effectiveHandler;

            HttpClient client = new HttpClient(mockHandler)
            {
                BaseAddress = new Uri(serviceUrl),
                MaxResponseContentBufferSize = 30 * 1024 * 1024
            };

            client.DefaultRequestHeaders.Accept.Clear();

            return client;
        }

        public void AddAction(IClientAction action)
        {
            // Do nothing
        }

        public void RemoveAction(Type actionType)
        {
            // Do nothing
        }

        public List<ProductInfoHeaderValue> UserAgents { get; set; }
    }
}
