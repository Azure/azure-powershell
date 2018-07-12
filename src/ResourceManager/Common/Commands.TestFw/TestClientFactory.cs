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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace  Microsoft.Azure.Commands.TestFw
{
    public class TestClientFactory : IClientFactory
    {
        private readonly MockContext _mockContext;

        public TestClientFactory(MockContext mockContext)
        {
            if (mockContext == null) throw new ArgumentNullException(nameof(mockContext));
            _mockContext = mockContext;
        }

        public TClient CreateArmClient<TClient>(IAzureContext context, string endpoint) where TClient : ServiceClient<TClient>
        {
            if (typeof(TClient) != typeof(GraphRbacManagementClient))
            {
                return _mockContext.GetServiceClient<TClient>();
            }

            var graphClient = _mockContext.GetGraphServiceClient<GraphRbacManagementClient>();
            graphClient.TenantID = context.Tenant.Id;
            return graphClient as TClient;
        }

        public TClient CreateCustomArmClient<TClient>(params object[] parameters) where TClient : ServiceClient<TClient>
        {
            return _mockContext.GetServiceClient<TClient>();
        }

        public HttpClient CreateHttpClient(string endpoint, ICredentials credentials)
        {
            throw new NotImplementedException();
        }

        public HttpClient CreateHttpClient(string endpoint, HttpMessageHandler effectiveHandler)
        {
            throw new NotImplementedException();
        }

        #region Action and Handler

        public void AddAction(IClientAction action)
        {
            // Do nothing
        }

        public void RemoveAction(Type actionType)
        {
            // Do nothing
        }

        public void AddHandler<T>(T handler) where T : DelegatingHandler, ICloneable
        {
            // Do nothing
        }

        public void RemoveHandler(Type handlerType)
        {
            // Do nothing
        }
        public DelegatingHandler[] GetCustomHandlers()
        {
            // Do nothing
            return new DelegatingHandler[0];
        }

        #endregion

        #region UserAgent

        public HashSet<ProductInfoHeaderValue> UniqueUserAgents { get; set; } = new HashSet<ProductInfoHeaderValue>();
        
        public void AddUserAgent(string productName, string productVersion)
        {
            UniqueUserAgents.Add(new ProductInfoHeaderValue(productName, productVersion));
        }

        public void AddUserAgent(string productName)
        {
            AddUserAgent(productName, string.Empty);
        }

        public void RemoveUserAgent(string name)
        {
            UniqueUserAgents.RemoveWhere(p => string.Equals(p.Product.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public ProductInfoHeaderValue[] UserAgents => UniqueUserAgents.ToArray();

        #endregion

        #region Hyak

        public TClient CreateClient<TClient>(IAzureContext context, string endpoint) where TClient : Hyak.Common.ServiceClient<TClient>
        {
            throw new NotImplementedException();
        }

        public TClient CreateClient<TClient>(IAzureContextContainer profile, string endpoint) where TClient : Hyak.Common.ServiceClient<TClient>
        {
            throw new NotImplementedException();
        }

        public TClient CreateClient<TClient>(IAzureContextContainer profile, IAzureSubscription subscription, string endpoint) where TClient : Hyak.Common.ServiceClient<TClient>
        {
            throw new NotImplementedException();
        }

        public TClient CreateCustomClient<TClient>(params object[] parameters) where TClient : Hyak.Common.ServiceClient<TClient>
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
