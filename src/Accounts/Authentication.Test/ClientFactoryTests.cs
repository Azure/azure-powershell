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

using Microsoft.Azure.Commands.Common.Authentication;
using System;
using System.Security;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System.Net.Http.Headers;
using Microsoft.Azure.Commands.TestFx.Mocks;

namespace Common.Authentication.Test
{
    public class ClientFactoryTests : IDisposable
    {
        private string subscriptionId;

        private string userAccount;

        private SecureString password;

        private bool runTest;

        public ClientFactoryTests()
        {
            // Example of environment variable: TEST_AZURE_CREDENTIALS=<subscription-id-value>;<email@domain.com>;<email-password>"
            AzureSessionInitializer.InitializeAzureSession();
            string credsEnvironmentVariable = Environment.GetEnvironmentVariable("TEST_AZURE_CREDENTIALS") ?? "";
            string[] creds = credsEnvironmentVariable.Split(';');

            if (creds.Length != 3)
            {
                // The test is not configured to run.
                runTest = false;
                return;
            }

            subscriptionId = creds[0];
            userAccount = creds[1];
            password = new SecureString();
            foreach (char letter in creds[2])
            {
                password.AppendChar(letter);
            }
            password = password.Length == 0 ? null : password;
            runTest = true;
            if (runTest) { return; }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VerifyProductInfoHeaderValueEquality()
        {
            ClientFactory factory = new ClientFactory();
            factory.AddUserAgent("test1", "123");
            factory.AddUserAgent("test2", "123");
            factory.AddUserAgent("test1", "123");
            factory.AddUserAgent("test1", "456");
            factory.AddUserAgent("test3");
            factory.AddUserAgent("tesT3");

            Assert.Equal(4, factory.UserAgents.Length);
            Assert.Contains(factory.UserAgents, u => u.Product.Name == "test1" && u.Product.Version == "123");
            Assert.Contains(factory.UserAgents, u => u.Product.Name == "test2" && u.Product.Version == "123");
            Assert.Contains(factory.UserAgents, u => u.Product.Name == "test1" && u.Product.Version == "456");
            Assert.Contains(factory.UserAgents, u => u.Product.Name == "test3" && u.Product.Version == null);
        }

        [Fact(Skip = "Need to determine a way to populate the cache with the given dummy account.")]
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
                foreach (var agent in factory.UserAgents)
                {
                    factory.RemoveUserAgent(agent.Product.Name);
                }

                factory.AddUserAgent("agent1");
                factory.AddUserAgent("agent1", "1.0.0");
                factory.AddUserAgent("agent1", "1.0.0");
                factory.AddUserAgent("agent1", "1.9.8");
                factory.AddUserAgent("agent2");
                Assert.Equal(4, factory.UserAgents.Length);
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
                Assert.Contains(new ProductInfoHeaderValue("agent1", ""), client.HttpClient.DefaultRequestHeaders.UserAgent);
                Assert.Contains(new ProductInfoHeaderValue("agent1", "1.0.0"), client.HttpClient.DefaultRequestHeaders.UserAgent);
                Assert.Contains(new ProductInfoHeaderValue("agent1", "1.9.8"), client.HttpClient.DefaultRequestHeaders.UserAgent);
                Assert.Contains(new ProductInfoHeaderValue("agent2", ""), client.HttpClient.DefaultRequestHeaders.UserAgent);
            }
            finally
            {
                AzureSession.Instance.ClientFactory = storedClientFactory;
                AzureSession.Instance.AuthenticationFactory = storedAuthFactory;
            }
        }

#if !NETSTANDARD
        public virtual void Dispose(bool disposing)
#else
        private void Dispose(bool disposing)
#endif
            {
            if (disposing && password != null)
            {
                password.Dispose();
                password = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
