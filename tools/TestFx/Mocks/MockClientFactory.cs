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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.TestFx.DelegatingHandlers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;
#if NETSTANDARD
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
#endif

namespace Microsoft.Azure.Commands.TestFx.Mocks
{
    public class MockClientFactory : IClientFactory
    {
        private readonly MockContext _mockContext;

        private readonly List<object> _serviceClients;

        public bool MoqClients { get; set; }

        public HashSet<ProductInfoHeaderValue> UniqueUserAgents { get; set; } = new HashSet<ProductInfoHeaderValue>();
        public ProductInfoHeaderValue[] UserAgents => UniqueUserAgents.ToArray();

        public MockClientFactory(MockContext mockContext, IEnumerable<object> serviceClients)
        {
            _mockContext = mockContext;
            _serviceClients = serviceClients?.ToList() ?? new List<object>();
        }

        public void AddUserAgent(string productName)
        {
            AddUserAgent(productName, "");
        }

        public void AddUserAgent(string productName, string productVersion)
        {
            if (string.IsNullOrEmpty(productName))
                return;

            UniqueUserAgents.Add(new ProductInfoHeaderValue(productName, productVersion ?? ""));
        }

        public void RemoveUserAgent(string name)
        {
            UniqueUserAgents.RemoveWhere(p => string.Equals(p.Product.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public TClient CreateArmClient<TClient>(IAzureContext context, string endpoint) where TClient : Microsoft.Rest.ServiceClient<TClient>
        {
            Debug.Assert(context != null);
            var credentials = AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context, endpoint);
            return CreateCustomArmClient<TClient>(context.Environment.GetEndpointAsUri(endpoint), credentials);
        }

        public TClient CreateCustomArmClient<TClient>(params object[] parameters) where TClient : Microsoft.Rest.ServiceClient<TClient>
        {
            if (!(_serviceClients.FirstOrDefault(o => o is TClient) is TClient client))
            {
                client = _mockContext?.GetServiceClient<TClient>(TestEnvironmentFactory.GetTestEnvironment());
            }

            if (client == null)
            {
                var realClientFactory = new ClientFactory();
                var newParameters = new object[parameters.Length + 1];
                Array.Copy(parameters, 0, newParameters, 1, parameters.Length);
                newParameters[0] = HttpMockServer.CreateInstance();
                client = realClientFactory.CreateCustomArmClient<TClient>(newParameters);
            }

            if (TestMockSupport.RunningMocked && HttpMockServer.GetCurrentMode() != HttpRecorderMode.Record)
            {
                if (client is IAzureClient azureClient)
                {
                    azureClient.LongRunningOperationRetryTimeout = 0;
                }
            }

            return client;
        }

        public HttpClient CreateHttpClient(string endpoint, ICredentials credentials)
        {
            throw new NotImplementedException();
        }

        public HttpClient CreateHttpClient(string endpoint, HttpMessageHandler effectiveHandler)
        {
            throw new NotImplementedException();
        }

        public DelegatingHandler[] GetCustomHandlers()
        {
            // Do nothing
            return new DelegatingHandler[0];
        }

        public void AddHandler<T>(T handler) where T : DelegatingHandler, ICloneable
        {
            // Do nothing
        }

        public void RemoveHandler(Type handlerType)
        {
            // Do nothing
        }

        public void AddAction(IClientAction action)
        {
            // Do nothing
        }

        public void RemoveAction(Type actionType)
        {
            // Do nothing
        }

        #region Hyak

        public TClient CreateClient<TClient>(IAzureContext context, string endpoint) where TClient : Hyak.Common.ServiceClient<TClient>
        {
            Debug.Assert(context != null);

            SubscriptionCloudCredentials creds = AzureSession.Instance.AuthenticationFactory.GetSubscriptionCloudCredentials(context, AzureEnvironment.Endpoint.ResourceManager);
            TClient client = CreateCustomClient<TClient>(creds, context.Environment.GetEndpointAsUri(endpoint));

            return client;
        }

        public TClient CreateClient<TClient>(IAzureContextContainer profile, string endpoint) where TClient : Hyak.Common.ServiceClient<TClient>
        {
            return CreateClient<TClient>(profile, profile.DefaultContext.Subscription, endpoint);
        }

        public TClient CreateClient<TClient>(IAzureContextContainer profile, IAzureSubscription subscription, string endpoint) where TClient : Hyak.Common.ServiceClient<TClient>
        {
#if !NETSTANDARD
            if (subscription == null)
            {
                throw new ArgumentException(Microsoft.Azure.Commands.ResourceManager.Common.Properties.Resources.InvalidDefaultSubscription);
            }

            if (profile == null)
            {
                profile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            }

            SubscriptionCloudCredentials creds = new TokenCloudCredentials(subscription.Id.ToString(), "fake_token");
            if (HttpMockServer.GetCurrentMode() != HttpRecorderMode.Playback)
            {
                ProfileClient profileClient = new ProfileClient(profile as AzureSMProfile);
                AzureContext context = new AzureContext(subscription, profileClient.GetAccount(subscription.GetAccount()), profileClient.GetEnvironmentOrDefault(subscription.GetEnvironment()));
                creds = AzureSession.Instance.AuthenticationFactory.GetSubscriptionCloudCredentials(context);
            }

            Uri endpointUri = profile.Environments.FirstOrDefault((e) => e.Name.Equals(subscription.GetEnvironment(), StringComparison.OrdinalIgnoreCase)).GetEndpointAsUri(endpoint);
            return CreateCustomClient<TClient>(creds, endpointUri);
#else
            throw new NotSupportedException("AzureSMProfile is not supported in Azure PS on .Net Core.");
#endif
        }

        public TClient CreateCustomClient<TClient>(params object[] parameters) where TClient : Hyak.Common.ServiceClient<TClient>
        {
            if (!(_serviceClients.FirstOrDefault(o => o is TClient) is TClient client))
            {
                var realClientFactory = new ClientFactory();
                var realClient = realClientFactory.CreateCustomClient<TClient>(parameters);
                var newRealClient = realClient.WithHandler(HttpMockServer.CreateInstance());

                var initialTimeoutPropInfo = typeof(TClient).GetProperty("LongRunningOperationInitialTimeout", BindingFlags.Public | BindingFlags.Instance);
                if (initialTimeoutPropInfo != null && initialTimeoutPropInfo.CanWrite)
                {
                    initialTimeoutPropInfo.SetValue(newRealClient, 0, null);
                }

                var retryTimeoutPropInfo = typeof(TClient).GetProperty("LongRunningOperationRetryTimeout", BindingFlags.Public | BindingFlags.Instance);
                if (retryTimeoutPropInfo != null && retryTimeoutPropInfo.CanWrite)
                {
                    retryTimeoutPropInfo.SetValue(newRealClient, 0, null);
                }

                realClient.Dispose();
                return newRealClient;
            }
            else
            {
                if (!MoqClients && !client.GetType().Namespace.Contains("Castle."))
                {
                    // Use the WithHandler method to create an extra reference to the http client
                    // this will prevent the httpClient from being disposed in a long-running test using 
                    // the same client for multiple cmdlets
                    client = client.WithHandler(new PassThroughDelegatingHandler());
                }
            }

            return client;
        }

        class PassThroughDelegatingHandler : DelegatingHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return base.SendAsync(request, cancellationToken);
            }
        }

        #endregion
    }
}
