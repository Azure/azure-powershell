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
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Common;
using Moq;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Test
{

    public class AzureRMProfileTests
    {
        private const string DefaultAccount = "admin@contoso.com";
        private static Guid DefaultSubscription = Guid.NewGuid();
        private static string DefaultSubscriptionName = "Contoso Subscription";
        private static string DefaultDomain = "contoso.com";
        private static Guid DefaultTenant = Guid.NewGuid();
        private static AzureContext Context;

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
            Context = new AzureContext(new AzureSubscription()
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
            profile.Context = Context;
            return new RMProfileClient(profile);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TokenIdAndAccountIdMismatch()
        {
            var tenants = new List<string> { Guid.NewGuid().ToString(), DefaultTenant.ToString() };
            var secondsubscriptionInTheFirstTenant = Guid.NewGuid().ToString();
            var firstList = new List<string> { DefaultSubscription.ToString(), secondsubscriptionInTheFirstTenant };
            var secondList = new List<string> { Guid.NewGuid().ToString() };
            var thirdList = new List<string> { DefaultSubscription.ToString(), secondsubscriptionInTheFirstTenant };
            var fourthList = new List<string> { DefaultSubscription.ToString(), secondsubscriptionInTheFirstTenant };
            var client = SetupTestEnvironment(tenants, firstList, secondList, thirdList, fourthList);

            var tokens = new Queue<MockAccessToken>();
            tokens.Enqueue(new MockAccessToken
            {
                UserId = "aaa@contoso.com",
                LoginType = LoginType.OrgId,
                AccessToken = "bbb"
            });
            tokens.Enqueue(new MockAccessToken
            {
                UserId = "bbb@contoso.com",
                LoginType = LoginType.OrgId,
                AccessToken = "bbb",
                TenantId = tenants.First()
            });
            tokens.Enqueue(new MockAccessToken
            {
                UserId = "ccc@notcontoso.com",
                LoginType = LoginType.OrgId,
                AccessToken = "bbb",
                TenantId = tenants.Last()
            });

            ((MockTokenAuthenticationFactory)AzureSession.AuthenticationFactory).TokenProvider = (account, environment, tenant) => 
                {
                    var token = tokens.Dequeue();
                    account.Id = token.UserId;
                    return token;
                };
            
            var azureRmProfile = client.Login(
                Context.Account,
                Context.Environment,
                null,
                secondsubscriptionInTheFirstTenant,
                null,
                null);

            var tenantsInAccount = azureRmProfile.Context.Account.GetPropertyAsArray( AzureAccount.Property.Tenants);
            Assert.Equal(1, tenantsInAccount.Length);
            Assert.Equal(tenants.First(), tenantsInAccount[0]);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultipleTenantsAndSubscriptionsSucceed()
        {
            var tenants = new List<string> {Guid.NewGuid().ToString(), DefaultTenant.ToString()};
            var secondsubscriptionInTheFirstTenant = Guid.NewGuid().ToString();
            var firstList = new List<string> { DefaultSubscription.ToString(), secondsubscriptionInTheFirstTenant};
            var secondList = new List<string> { Guid.NewGuid().ToString()};
            var thirdList = new List<string> { DefaultSubscription.ToString(), secondsubscriptionInTheFirstTenant };
            var fourthList = new List<string> { DefaultSubscription.ToString(), secondsubscriptionInTheFirstTenant };
            var client = SetupTestEnvironment(tenants, firstList, secondList, thirdList, fourthList);
            var subResults = new List<AzureSubscription>(client.ListSubscriptions());
            Assert.Equal(3, subResults.Count);
            var tenantResults = client.ListTenants();
            Assert.Equal(2, tenantResults.Count());
            tenantResults = client.ListTenants(DefaultTenant.ToString());
            Assert.Equal(1, tenantResults.Count());
            AzureSubscription subValue;
            Assert.True(client.TryGetSubscriptionById(DefaultTenant.ToString(), DefaultSubscription.ToString(), out subValue));
            Assert.Equal(DefaultSubscription.ToString(), subValue.Id.ToString());
            Assert.True(client.TryGetSubscriptionByName(DefaultTenant.ToString(), 
                MockSubscriptionClientFactory.GetSubscriptionNameFromId(DefaultSubscription.ToString()), 
                out subValue));
            Assert.Equal(DefaultSubscription.ToString(), subValue.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SingleTenantAndSubscriptionSucceeds()
        {
            var tenants = new List<string> {DefaultTenant.ToString()};
            var firstList = new List<string> {DefaultSubscription.ToString()};
            var secondList = firstList;
            var thirdList = firstList;
            var client = SetupTestEnvironment(tenants, firstList, secondList, thirdList);
            var subResults = new List<AzureSubscription>(client.ListSubscriptions());
            Assert.Equal(1, subResults.Count);
            var tenantResults = client.ListTenants();
            Assert.Equal(1, tenantResults.Count());
            tenantResults = client.ListTenants(DefaultTenant.ToString());
            Assert.Equal(1, tenantResults.Count());
            AzureSubscription subValue;
            Assert.True(client.TryGetSubscriptionById(DefaultTenant.ToString(), DefaultSubscription.ToString(), out subValue));
            Assert.Equal(DefaultSubscription.ToString(), subValue.Id.ToString());
            Assert.True(client.TryGetSubscriptionByName(DefaultTenant.ToString(), 
                MockSubscriptionClientFactory.GetSubscriptionNameFromId(DefaultSubscription.ToString()), 
                out subValue));
            Assert.Equal(DefaultSubscription.ToString(), subValue.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionNotFoundDoesNotThrow()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            string randomSubscriptionId = Guid.NewGuid().ToString();
            var firstList = new List<string> { randomSubscriptionId };
            var secondList = firstList;
            var client = SetupTestEnvironment(tenants, firstList, secondList);
            var subResults = new List<AzureSubscription>(client.ListSubscriptions());
            Assert.Equal(1, subResults.Count);
            AzureSubscription subValue;
            Assert.False(client.TryGetSubscriptionById(DefaultTenant.ToString(), DefaultSubscription.ToString(), out subValue));
            Assert.False(client.TryGetSubscriptionByName("random-tenant", "random-subscription", out subValue));
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
        public void NoSubscriptionsInListDoesNotThrow()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var subscriptions = new List<string> () ;
            var client = SetupTestEnvironment(tenants, subscriptions, subscriptions);
            Assert.Equal(0, client.ListSubscriptions().Count());
            AzureSubscription subValue;
            Assert.False(client.TryGetSubscriptionById(DefaultTenant.ToString(), DefaultSubscription.ToString(), out subValue));
            Assert.False(client.TryGetSubscriptionByName(DefaultTenant.ToString(), "random-name", out subValue));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
      public void SetContextPreservesTokenCache()
        {
            AzureRMProfile profile = null;
            AzureContext context = new AzureContext(null, null, null, null);
            Assert.Throws<ArgumentNullException>(() =>profile.SetContextWithCache(context));
            profile = new AzureRMProfile();
            Assert.Throws<ArgumentNullException>(() => profile.SetContextWithCache(null));
            profile.SetContextWithCache(context);
            Assert.Equal(TokenCache.DefaultShared.Serialize(), profile.Context.TokenCache);
        }
    }
}
