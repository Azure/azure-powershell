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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ResourceManager.Profile.Test
{
    public class ClientFactoryTests
    {
        public ClientFactoryTests(ITestOutputHelper output)
        {
            AzureSessionInitializer.InitializeAzureSession();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VerifyUserAgentValuesAreTransmitted()
        {
            var storedClientFactory = AzureSession.Instance.ClientFactory;
            var storedAuthFactory = AzureSession.Instance.AuthenticationFactory;
            try
            {
                var authFactory = new AuthenticationFactory();
                authFactory.TokenProvider = new MockAccessTokenProvider(Guid.NewGuid().ToString(), "user@contoso.com");
                AzureSession.Instance.AuthenticationFactory = authFactory;
                var factory = new ClientFactory();
                AzureSession.Instance.ClientFactory = factory;
                factory.UserAgents.Clear();
                factory.AddUserAgent("agent1");
                factory.AddUserAgent("agent1", "1.0.0");
                factory.AddUserAgent("agent1", "1.0.0");
                factory.AddUserAgent("agent1", "1.9.8");
                factory.AddUserAgent("agent2");
                Assert.Equal(4, factory.UserAgents.Count);
                var sub = new AzureSubscription
                {
                    Id = Guid.NewGuid().ToString(),
                };
                sub.SetTenant("123");
                var account = new AzureAccount
                {
                    Id = "user@contoso.com",
                    Type = AzureAccount.AccountType.User,
                };
                account.SetTenants("123");
                var client = factory.CreateClient<NullClient>(new AzureContext(
                    sub,
                    account,
                    AzureEnvironment.PublicEnvironments["AzureCloud"]

                    ), AzureEnvironment.Endpoint.ResourceManager);
                Assert.Equal(5, client.HttpClient.DefaultRequestHeaders.UserAgent.Count);
                Assert.True(client.HttpClient.DefaultRequestHeaders.UserAgent.Contains(new ProductInfoHeaderValue("agent1", "")));
                Assert.True(client.HttpClient.DefaultRequestHeaders.UserAgent.Contains(new ProductInfoHeaderValue("agent1", "1.0.0")));
                Assert.True(client.HttpClient.DefaultRequestHeaders.UserAgent.Contains(new ProductInfoHeaderValue("agent1", "1.9.8")));
                Assert.True(client.HttpClient.DefaultRequestHeaders.UserAgent.Contains(new ProductInfoHeaderValue("agent2", "")));
            }
            finally
            {
                AzureSession.Instance.ClientFactory = storedClientFactory;
                AzureSession.Instance.AuthenticationFactory = storedAuthFactory;
            }
        }
    }
}