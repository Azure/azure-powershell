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

using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using System.Linq;
using Xunit;
using System;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Test
{

    public class AzureRMProfileTests
    {
        private const string DefaultAccount = "admin@contoso.com";
        private static Guid DefaultSubscription = Guid.NewGuid();
        private static string DefaultSubscriptionName = "Contoso Subscription";
        private static string DefaultDomain = "contoso.com";
        private static Guid DefaultTenant = Guid.NewGuid();

        private static RMProfileClient SetupTestEnvironment(List<string> tenants, params List<string>[] subscriptionLists)
        {
            AzureSession.AuthenticationFactory = new MockTokenAuthenticationFactory(DefaultAccount,
                Guid.NewGuid().ToString(), DefaultTenant.ToString());
            var subscriptionList = new Queue<List<string>>(subscriptionLists);
            var clientFactory = new MockSubscriptionClientFactory(tenants, subscriptionList);
            var mock = new MockClientFactory(new List<object>
            {
                clientFactory.GetSubscriptionClient()
            }, true);
            mock.MoqClients = true;
            AzureSession.ClientFactory = mock;
            var context = new AzureContext(new AzureSubscription()
            {
                Account = DefaultAccount,
                Environment = EnvironmentName.AzureCloud,
                Id = DefaultSubscription,
                Name = DefaultSubscriptionName
            },
                new AzureAccount() { Id = DefaultAccount, Type = AzureAccount.AccountType.User },
                AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                new AzureTenant() { Domain = DefaultDomain, Id = DefaultTenant });
            var profile = new AzureRMProfile();
            profile.Context = context;
            return new RMProfileClient(profile);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultipleTenantsAndSubscriptionsSucceed()
        {
            var tenants = new List<string> {Guid.NewGuid().ToString(), DefaultTenant.ToString()};
            var firstList = new List<string> { DefaultSubscription.ToString(), Guid.NewGuid().ToString() };
            var secondList = new List<string> { Guid.NewGuid().ToString()};
            var client = SetupTestEnvironment(tenants, firstList, secondList);
            var subResults = new List<AzureSubscription>(client.ListSubscriptions());
            Assert.Equal(3, subResults.Count);
            var tenantResults = client.ListTenants();
            Assert.Equal(2, tenantResults.Count());
            tenantResults = client.ListTenants(DefaultTenant.ToString());
            Assert.Equal(1, tenantResults.Count());
            AzureSubscription subValue;
            Assert.True(client.TryGetSubscription(DefaultTenant.ToString(), DefaultSubscription.ToString(), out subValue));
            Assert.Equal(DefaultSubscription.ToString(), subValue.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SingleTenantAndSubscriptionSucceeds()
        {
            var tenants = new List<string> {DefaultTenant.ToString()};
            var subscriptions = new List<string> {DefaultSubscription.ToString()};
            var client = SetupTestEnvironment(tenants, subscriptions);
            var subResults = new List<AzureSubscription>(client.ListSubscriptions());
            Assert.Equal(1, subResults.Count);
            var tenantResults = client.ListTenants();
            Assert.Equal(1, tenantResults.Count());
            tenantResults = client.ListTenants(DefaultTenant.ToString());
            Assert.Equal(1, tenantResults.Count());
            AzureSubscription subValue;
            Assert.True(client.TryGetSubscription(DefaultTenant.ToString(), DefaultSubscription.ToString(), out subValue));
            Assert.Equal(DefaultSubscription.ToString(), subValue.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionNotFoundDoesNotThrow()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var subscriptions = new List<string> { Guid.NewGuid().ToString() };
            var client = SetupTestEnvironment(tenants, subscriptions);
            var subResults = new List<AzureSubscription>(client.ListSubscriptions());
            Assert.Equal(1, subResults.Count);
            AzureSubscription subValue;
            Assert.False(client.TryGetSubscription(DefaultTenant.ToString(), DefaultSubscription.ToString(), out subValue));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NoTenantsDoesNotThrow()
        {
            var tenants = new List<string> {  };
            var subscriptions = new List<string> { Guid.NewGuid().ToString() };
            var client = SetupTestEnvironment(tenants, subscriptions);
            Assert.Equal(0, client.ListSubscriptions().Count());
            Assert.Equal(0, client.ListTenants().Count());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NoSubscriptionsInListThrows()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var subscriptions = new List<string> () ;
            var client = SetupTestEnvironment(tenants, subscriptions);
            Assert.Equal(0, client.ListSubscriptions().Count());
            AzureSubscription subValue;
            Assert.False(client.TryGetSubscription(DefaultTenant.ToString(), DefaultSubscription.ToString(), out subValue));
        }
    }
}
