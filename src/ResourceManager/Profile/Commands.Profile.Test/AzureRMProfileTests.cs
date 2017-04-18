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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Internal.Subscriptions.Models;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Test
{

    public class AzureRMProfileTests
    {
        private const string DefaultAccount = "admin@contoso.com";
        private static Guid DefaultSubscription = Guid.NewGuid();
        private static string DefaultSubscriptionName = "Contoso Subscription";
        private static string DefaultDomain = "contoso.com";
        private static Guid DefaultTenant = Guid.NewGuid();
        private static IAzureContext Context;

        private static RMProfileClient SetupTestEnvironment(List<string> tenants, params List<string>[] subscriptionLists)
        {
            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory(DefaultAccount,
                Guid.NewGuid().ToString(), DefaultTenant.ToString());
            var subscriptionList = new Queue<List<string>>(subscriptionLists);
            var clientFactory = new MockSubscriptionClientFactory(tenants, subscriptionList);
            var mock = new MockClientFactory(new List<object>
            {
                clientFactory.GetSubscriptionClient()
            }, true);
            mock.MoqClients = true;
            AzureSession.Instance.ClientFactory = mock;
            var sub = new AzureSubscription()
            {
                Id = DefaultSubscription.ToString(),
                Name = DefaultSubscriptionName
            };
            sub.SetAccount(DefaultAccount);
            sub.SetEnvironment(EnvironmentName.AzureCloud);
            Context = new AzureContext(sub,
                new AzureAccount() { Id = DefaultAccount, Type = AzureAccount.AccountType.User },
                AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                new AzureTenant() { Directory = DefaultDomain, Id = DefaultTenant.ToString() });
            var profile = new AzureRMProfile();
            profile.DefaultContext = Context;
            return new RMProfileClient(profile);
        }

        public AzureRMProfileTests(ITestOutputHelper output)
        {
            AzureSessionInitializer.InitializeAzureSession();
            ResourceManagerProfileProvider.InitializeResourceManagerProfile();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SpecifyTenantAndSubscriptionIdSucceed()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var firstList = new List<string> { DefaultSubscription.ToString(), Guid.NewGuid().ToString() };
            var secondList = new List<string> { Guid.NewGuid().ToString() };
            var client = SetupTestEnvironment(tenants, firstList, secondList);

            ((MockTokenAuthenticationFactory)AzureSession.Instance.AuthenticationFactory).TokenProvider = (account, environment, tenant) =>
            new MockAccessToken
            {
                UserId = "aaa@contoso.com",
                LoginType = LoginType.OrgId,
                AccessToken = "bbb",
                TenantId = DefaultTenant.ToString()
            };

            var azureRmProfile = client.Login(
                Context.Account,
                Context.Environment,
                DefaultTenant.ToString(),
                DefaultSubscription.ToString(),
                null,
                null);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionIdNotExist()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var firstList = new List<string> { Guid.NewGuid().ToString() };
            var client = SetupTestEnvironment(tenants, firstList);

            ((MockTokenAuthenticationFactory)AzureSession.Instance.AuthenticationFactory).TokenProvider = (account, environment, tenant) =>
            new MockAccessToken
            {
                UserId = "aaa@contoso.com",
                LoginType = LoginType.OrgId,
                AccessToken = "bbb",
                TenantId = DefaultTenant.ToString()
            };

            var getAsyncResponses = new Queue<Func<AzureOperationResponse<Subscription>>>();
            getAsyncResponses.Enqueue(() =>
            {
                throw new CloudException("InvalidAuthenticationTokenTenant: The access token is from the wrong issuer");
            });
            MockSubscriptionClientFactory.SetGetAsyncResponses(getAsyncResponses);

            Assert.Throws<PSInvalidOperationException>(() => client.Login(
               Context.Account,
               Context.Environment,
               null,
               DefaultSubscription.ToString(),
               null,
               null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SpecifyTenantAndNotExistingSubscriptionId()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var firstList = new List<string> { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            var secondList = new List<string> { Guid.NewGuid().ToString() };
            var client = SetupTestEnvironment(tenants, firstList, secondList);

            ((MockTokenAuthenticationFactory)AzureSession.Instance.AuthenticationFactory).TokenProvider = (account, environment, tenant) =>
            new MockAccessToken
            {
                UserId = "aaa@contoso.com",
                LoginType = LoginType.OrgId,
                AccessToken = "bbb",
                TenantId = DefaultTenant.ToString()
            };

            Assert.Throws<PSInvalidOperationException>(() => client.Login(
               Context.Account,
               Context.Environment,
               DefaultTenant.ToString(),
               DefaultSubscription.ToString(),
               null,
               null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionIdNotInFirstTenant()
        {
            var tenants = new List<string> { DefaultTenant.ToString(), Guid.NewGuid().ToString() };
            var subscriptionInSecondTenant = Guid.NewGuid().ToString();
            var firstList = new List<string> { DefaultSubscription.ToString() };
            var secondList = new List<string> { Guid.NewGuid().ToString(), subscriptionInSecondTenant };
            var client = SetupTestEnvironment(tenants, firstList, secondList);

            ((MockTokenAuthenticationFactory)AzureSession.Instance.AuthenticationFactory).TokenProvider = (account, environment, tenant) =>
            new MockAccessToken
            {
                UserId = "aaa@contoso.com",
                LoginType = LoginType.OrgId,
                AccessToken = "bbb",
                TenantId = DefaultTenant.ToString()
            };

            var getAsyncResponses = new Queue<Func<AzureOperationResponse<Subscription>>>();
            getAsyncResponses.Enqueue(() =>
            {
                throw new CloudException("InvalidAuthenticationTokenTenant: The access token is from the wrong issuer");
            });
            MockSubscriptionClientFactory.SetGetAsyncResponses(getAsyncResponses);

            var azureRmProfile = client.Login(
                Context.Account,
                Context.Environment,
                null,
                subscriptionInSecondTenant,
                null,
                null);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionNameNotInFirstTenant()
        {
            var tenants = new List<string> { DefaultTenant.ToString(), Guid.NewGuid().ToString() };
            var subscriptionInSecondTenant = Guid.NewGuid().ToString();
            var firstList = new List<string> { DefaultSubscription.ToString() };
            var secondList = new List<string> { Guid.NewGuid().ToString(), subscriptionInSecondTenant };
            var client = SetupTestEnvironment(tenants, firstList, secondList);

            ((MockTokenAuthenticationFactory)AzureSession.Instance.AuthenticationFactory).TokenProvider = (account, environment, tenant) =>
            new MockAccessToken
            {
                UserId = "aaa@contoso.com",
                LoginType = LoginType.OrgId,
                AccessToken = "bbb",
                TenantId = DefaultTenant.ToString()
            };

            var listAsyncResponses = new Queue<Func<AzureOperationResponse<IPage<Subscription>>>>();
            listAsyncResponses.Enqueue(() =>
            {
                var sub1 = new Subscription(
                    id: DefaultSubscription.ToString(),
                    subscriptionId: DefaultSubscription.ToString(),
                    tenantId: null,
                    displayName: DefaultSubscriptionName,
                    state: SubscriptionState.Enabled,
                    subscriptionPolicies: null,
                    authorizationSource: null);
                var sub2 = new Subscription(
                    id: subscriptionInSecondTenant,
                    subscriptionId: subscriptionInSecondTenant,
                    tenantId: null,
                    displayName: MockSubscriptionClientFactory.GetSubscriptionNameFromId(subscriptionInSecondTenant),
                    state: SubscriptionState.Enabled,
                    subscriptionPolicies: null,
                    authorizationSource: null);
                return new AzureOperationResponse<IPage<Subscription>>
                {
                    Body = new MockPage<Subscription>(new List<Subscription> { sub1, sub2 })
                };
            });
            MockSubscriptionClientFactory.SetListAsyncResponses(listAsyncResponses);

            var azureRmProfile = client.Login(
                Context.Account,
                Context.Environment,
                null,
                null,
                MockSubscriptionClientFactory.GetSubscriptionNameFromId(subscriptionInSecondTenant),
                null);
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

            ((MockTokenAuthenticationFactory)AzureSession.Instance.AuthenticationFactory).TokenProvider = (account, environment, tenant) =>
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

            var tenantsInAccount = azureRmProfile.DefaultContext.Account.GetPropertyAsArray(AzureAccount.Property.Tenants);
            Assert.Equal(1, tenantsInAccount.Length);
            Assert.Equal(tenants.First(), tenantsInAccount[0]);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AdalExceptionsArePropagatedToCaller()
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

            ((MockTokenAuthenticationFactory)AzureSession.Instance.AuthenticationFactory).TokenProvider = (account, environment, tenant) =>
            {
                throw new AadAuthenticationCanceledException("Login window was closed", null);
            };

            Assert.Throws<AadAuthenticationCanceledException>(() => client.Login(
               Context.Account,
               Context.Environment,
               null,
               secondsubscriptionInTheFirstTenant,
               null,
               null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultipleTenantsAndSubscriptionsSucceed()
        {
            var tenants = new List<string> { Guid.NewGuid().ToString(), DefaultTenant.ToString() };
            var secondsubscriptionInTheFirstTenant = Guid.NewGuid().ToString();
            var firstList = new List<string> { DefaultSubscription.ToString(), secondsubscriptionInTheFirstTenant };
            var secondList = new List<string> { Guid.NewGuid().ToString() };
            var thirdList = new List<string> { DefaultSubscription.ToString(), secondsubscriptionInTheFirstTenant };
            var fourthList = new List<string> { DefaultSubscription.ToString(), secondsubscriptionInTheFirstTenant };
            var client = SetupTestEnvironment(tenants, firstList, secondList, 
                                                       thirdList, fourthList, 
                                                       thirdList, fourthList,
                                                       thirdList, fourthList);
            var subResults = new List<IAzureSubscription>(client.ListSubscriptions());
            Assert.Equal(7, subResults.Count);
            var tenantResults = client.ListTenants();
            Assert.Equal(2, tenantResults.Count());
            tenantResults = client.ListTenants(DefaultTenant.ToString());
            Assert.Equal(1, tenantResults.Count());
            IAzureSubscription subValue;
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
            var tenants = new List<string> { DefaultTenant.ToString() };
            var firstList = new List<string> { DefaultSubscription.ToString() };
            var secondList = firstList;
            var thirdList = firstList;
            var fourthList = firstList;
            var client = SetupTestEnvironment(tenants, firstList, secondList, thirdList, fourthList, firstList, firstList);
            var subResults = new List<IAzureSubscription>(client.ListSubscriptions());
            Assert.Equal(2, subResults.Count);
            var tenantResults = client.ListTenants();
            Assert.Equal(1, tenantResults.Count());
            tenantResults = client.ListTenants(DefaultTenant.ToString());
            Assert.Equal(1, tenantResults.Count());
            IAzureSubscription subValue;
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
            var thirdList = firstList;
            var fourthList = firstList;
            var client = SetupTestEnvironment(tenants, firstList, secondList, 
                                                       thirdList, fourthList, 
                                                       thirdList, fourthList);
            var subResults = new List<IAzureSubscription>(client.ListSubscriptions());
            Assert.Equal(2, subResults.Count);
            IAzureSubscription subValue;

            Assert.False(client.TryGetSubscriptionById(DefaultTenant.ToString(), DefaultSubscription.ToString(), out subValue));
            Assert.False(client.TryGetSubscriptionByName("random-tenant", "random-subscription", out subValue));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NoTenantsDoesNotThrow()
        {
            var tenants = new List<string> { };
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
            var subscriptions = new List<string>();
            var client = SetupTestEnvironment(tenants, subscriptions, subscriptions, 
                                                       subscriptions, subscriptions,
                                                       subscriptions, subscriptions);
            Assert.Equal(0, client.ListSubscriptions().Count());
            IAzureSubscription subValue;
            Assert.False(client.TryGetSubscriptionById(DefaultTenant.ToString(), DefaultSubscription.ToString(), out subValue));
            Assert.False(client.TryGetSubscriptionByName(DefaultTenant.ToString(), "random-name", out subValue));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetContextPreservesTokenCache()
        {
            AzureRMProfile profile = null;
            AzureContext context = new AzureContext(null, null, null, null);
            Assert.Throws<ArgumentNullException>(() => profile.SetContextWithCache(context));
            profile = new AzureRMProfile();
            Assert.Throws<ArgumentNullException>(() => profile.SetContextWithCache(null));
            profile.SetContextWithCache(context);
            Assert.Equal(TokenCache.DefaultShared.Serialize(), profile.DefaultContext.TokenCache.CacheData);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzurePSComletMessageQueue()
        {
            ConcurrentQueue<string> queue = new ConcurrentQueue<string>();

            Parallel.For(0, 5, i =>
            {
                for (int j = 0; j < 300; j++)
                {
                    queue.CheckAndEnqueue(j.ToString());
                }
            });

            Assert.Equal(500, queue.Count);
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureRmSubscriptionPaginatedResult()
        {
            var tenants = new List<string> { Guid.NewGuid().ToString(), DefaultTenant.ToString() };
            var secondsubscriptionInTheFirstTenant = Guid.NewGuid().ToString();
            var firstList = new List<string> { DefaultSubscription.ToString(), secondsubscriptionInTheFirstTenant };
            var secondList = new List<string> { Guid.NewGuid().ToString() };
            var thirdList = new List<string> { DefaultSubscription.ToString(), secondsubscriptionInTheFirstTenant };
            var fourthList = new List<string> { DefaultSubscription.ToString(), secondsubscriptionInTheFirstTenant };
            var client = SetupTestEnvironment(tenants, firstList, secondList, thirdList, fourthList);

            var dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            var commandRuntimeMock = new MockCommandRuntime();
            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory();
            var profile = new AzureRMProfile();
            profile.EnvironmentTable.Add("foo", AzureEnvironment.PublicEnvironments.Values.FirstOrDefault());
            profile.DefaultContext = Context;
            var cmdlt = new GetAzureRMSubscriptionCommand();
            // Setup
            cmdlt.DefaultProfile = profile;
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            var subscriptionName = MockSubscriptionClientFactory.GetSubscriptionNameFromId(secondList[0]);

            Assert.True(commandRuntimeMock.OutputPipeline.Count == 7);
            Assert.Equal("Disabled", ((PSAzureSubscription)commandRuntimeMock.OutputPipeline[2]).State);
            Assert.Equal(subscriptionName, ((PSAzureSubscription)commandRuntimeMock.OutputPipeline[2]).Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureRmSubscriptionByIdMultiplePages()
        {
            var tenants = new List<string> { Guid.NewGuid().ToString(), DefaultTenant.ToString() };
            var firstTenantSubscriptions = new List<string> {  Guid.NewGuid().ToString(),
                                                               Guid.NewGuid().ToString(),
                                                               Guid.NewGuid().ToString(),
                                                               Guid.NewGuid().ToString() };
            var secondTenantSubscriptions = new List<string> { Guid.NewGuid().ToString(),
                                                               Guid.NewGuid().ToString(),
                                                               Guid.NewGuid().ToString(),
                                                               Guid.NewGuid().ToString() };

            var firstList = new List<string> { firstTenantSubscriptions[0], firstTenantSubscriptions[1] };
            var secondList = new List<string> {firstTenantSubscriptions[2], firstTenantSubscriptions[3] };

            var thirdList = new List<string> { secondTenantSubscriptions[0], secondTenantSubscriptions[1] };
            var fourthList = new List<string> { secondTenantSubscriptions[2], secondTenantSubscriptions[3] };

            var client = SetupTestEnvironment(tenants, firstList, secondList, thirdList, fourthList);

            var dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            var commandRuntimeMock = new MockCommandRuntime();
            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory();
            var profile = new AzureRMProfile();
            profile.EnvironmentTable.Add("foo", AzureEnvironment.PublicEnvironments.Values.FirstOrDefault());
            profile.DefaultContext = Context;
            var cmdlt = new GetAzureRMSubscriptionCommand();
            // Setup
            cmdlt.DefaultProfile = profile;
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SubscriptionId = secondTenantSubscriptions[2];

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.True(commandRuntimeMock.OutputPipeline.Count == 1);

            // Make sure we can get a subscription from the second page of the second tenant by subscription Id
            var resultSubscription = (PSAzureSubscription)commandRuntimeMock.OutputPipeline[0];
            Assert.Equal(secondTenantSubscriptions[2], resultSubscription.Id);
            Assert.Equal(tenants[1], resultSubscription.TenantId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureRmSubscriptionByNameMultiplePages()
        {
            var tenants = new List<string> { Guid.NewGuid().ToString(), DefaultTenant.ToString() };
            var firstTenantSubscriptions = new List<string> {  Guid.NewGuid().ToString(),
                                                               Guid.NewGuid().ToString(),
                                                               Guid.NewGuid().ToString(),
                                                               Guid.NewGuid().ToString() };
            var secondTenantSubscriptions = new List<string> { Guid.NewGuid().ToString(),
                                                               Guid.NewGuid().ToString(),
                                                               Guid.NewGuid().ToString(),
                                                               Guid.NewGuid().ToString() };

            var firstList = new List<string> { firstTenantSubscriptions[0], firstTenantSubscriptions[1] };
            var secondList = new List<string> { firstTenantSubscriptions[2], firstTenantSubscriptions[3] };

            var thirdList = new List<string> { secondTenantSubscriptions[0], secondTenantSubscriptions[1] };
            var fourthList = new List<string> { secondTenantSubscriptions[2], secondTenantSubscriptions[3] };

            var client = SetupTestEnvironment(tenants, firstList, secondList, thirdList, fourthList);

            var subscriptionName = MockSubscriptionClientFactory.GetSubscriptionNameFromId(secondTenantSubscriptions[2]);

            var dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            var commandRuntimeMock = new MockCommandRuntime();
            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory();
            var profile = new AzureRMProfile();
            profile.EnvironmentTable.Add("foo", AzureEnvironment.PublicEnvironments.Values.FirstOrDefault());
            profile.DefaultContext = Context;
            var cmdlt = new GetAzureRMSubscriptionCommand();
            // Setup
            cmdlt.DefaultProfile = profile;
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SubscriptionName = subscriptionName;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.True(commandRuntimeMock.OutputPipeline.Count == 1);

            // Make sure we can get a subscription from the second page of the second tenant by subscription name
            var resultSubscription = (PSAzureSubscription)commandRuntimeMock.OutputPipeline[0];
            Assert.Equal(subscriptionName, resultSubscription.Name);
            Assert.Equal(tenants[1], resultSubscription.TenantId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ProfileSerializeDeserializeWorks()
        {
            var dataStore = new MockDataStore();
            AzureSession.Instance.DataStore = dataStore;
            var profilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AzureSession.Instance.ProfileFile);
            var currentProfile = new AzureRMProfile(profilePath);
            var tenantId = Guid.NewGuid().ToString();
            var environment = new AzureEnvironment
            {
                Name = "testCloud",
                ActiveDirectory= new Uri("http://contoso.com")
            };
            var account = new AzureAccount
            {
                Id = "me@contoso.com",
                Type = AzureAccount.AccountType.User,
            };
            account.SetTenants(tenantId);
            var sub = new AzureSubscription
            {
                Id = new Guid().ToString(),
                Name = "Contoso Test Subscription",
            };
            sub.SetAccount(account.Id);
            sub.SetEnvironment(environment.Name);
            sub.SetTenant(tenantId);
            var tenant = new AzureTenant
            {
                Id = tenantId,
                Directory = "contoso.com"
            };

            currentProfile.DefaultContext = new AzureContext(sub, account, environment, tenant);
            currentProfile.EnvironmentTable[environment.Name] = environment;
            currentProfile.DefaultContext.TokenCache = new AuthenticationStoreTokenCache(new AzureTokenCache { CacheData = new byte[] { 1, 2, 3, 4, 5, 6, 8, 9, 0 } });

            AzureRMProfile deserializedProfile;
            // Round-trip the exception: Serialize and de-serialize with a BinaryFormatter
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                // "Save" object state
                bf.Serialize(ms, currentProfile);

                // Re-use the same stream for de-serialization
                ms.Seek(0, 0);

                // Replace the original exception with de-serialized one
                deserializedProfile = (AzureRMProfile)bf.Deserialize(ms);
            }
            Assert.NotNull(deserializedProfile);
            var jCurrentProfile = currentProfile.ToString();
            var jDeserializedProfile = deserializedProfile.ToString();
            Assert.Equal(jCurrentProfile, jDeserializedProfile);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SavingProfileWorks()
        {
            string expected = @"{
  ""Environments"": {
    ""testCloud"": {
      ""Name"": ""testCloud"",
      ""OnPremise"": false,
      ""Endpoints"": {
        ""ActiveDirectory"": ""http://contoso.com""
      }
    }
  },
  ""Context"": {
    ""Account"": {
      ""Id"": ""me@contoso.com"",
      ""Type"": 1,
      ""Properties"": {
        ""Tenants"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6""
      }
    },
    ""Subscription"": {
      ""Id"": ""00000000-0000-0000-0000-000000000000"",
      ""Name"": ""Contoso Test Subscription"",
      ""Environment"": ""testCloud"",
      ""Account"": ""me@contoso.com"",
      ""State"": ""Enabled"",
      ""Properties"": {
        ""Tenants"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6""
      }
    },
    ""Environment"": {
      ""Name"": ""testCloud"",
      ""OnPremise"": false,
      ""Endpoints"": {
        ""ActiveDirectory"": ""http://contoso.com""
      }
    },
    ""Tenant"": {
      ""Id"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6"",
      ""Domain"": ""contoso.com""
    },
    ""TokenCache"": ""AQIDBAUGCAkA""
  }
}";
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AzureSession.Instance.ProfileFile);
            var dataStore = new MockDataStore();
            AzureSession.Instance.DataStore = dataStore;
            AzureRMProfile profile = new AzureRMProfile(path);
            var tenantId = new Guid("3c0ff8a7-e8bb-40e8-ae66-271343379af6");
            var environment = new AzureEnvironment
            {
                Name = "testCloud",
                ActiveDirectory = new Uri("http://contoso.com")
            };
            var account = new AzureAccount
            {
                Id = "me@contoso.com",
                Type = AzureAccount.AccountType.User,
            };
            account.SetTenants(tenantId.ToString());
            var sub = new AzureSubscription
            {
                Id = new Guid().ToString(),
                Name = "Contoso Test Subscription",
                State = "Enabled",
            };
            sub.SetAccount(account.Id);
            sub.SetEnvironment(environment.Name);
            sub.SetTenant(tenantId.ToString());
            var tenant = new AzureTenant
            {
                Id = tenantId.ToString(),
                Directory = "contoso.com"
            };
            profile.DefaultContext = new AzureContext(sub, account, environment, tenant);
            profile.EnvironmentTable[environment.Name] = environment;
            profile.DefaultContext.TokenCache = new AuthenticationStoreTokenCache(new AzureTokenCache { CacheData = new byte[] { 1, 2, 3, 4, 5, 6, 8, 9, 0 } });
            profile.Save();
            string actual = dataStore.ReadFileAsText(path);
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoadingProfileWorks()
        {
            string contents = @"{
  ""Environments"": {
    ""testCloud"": {
      ""Name"": ""testCloud"",
      ""OnPremise"": false,
      ""Endpoints"": {
        ""ActiveDirectory"": ""http://contoso.com""
      }
    }
  },
  ""Context"": {
    ""TokenCache"": ""AQIDBAUGCAkA"",
    ""Account"": {
      ""Id"": ""me@contoso.com"",
      ""Type"": 1,
      ""Properties"": {
        ""Tenants"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6""
      }
    },
    ""Subscription"": {
      ""Id"": ""00000000-0000-0000-0000-000000000000"",
      ""Name"": ""Contoso Test Subscription"",
      ""Environment"": ""testCloud"",
      ""Account"": ""me@contoso.com"",
      ""Properties"": {
        ""Tenants"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6""
      }
    },
    ""Environment"": {
      ""Name"": ""testCloud"",
      ""OnPremise"": false,
      ""Endpoints"": {
        ""ActiveDirectory"": ""http://contoso.com""
      }
    },
    ""Tenant"": {
      ""Id"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6"",
      ""Domain"": ""contoso.com""
    }
  }
}";
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AzureSession.Instance.ProfileFile);
            var dataStore = new MockDataStore();
            AzureSession.Instance.DataStore = dataStore;
            dataStore.WriteFile(path, contents);
            var profile = new AzureRMProfile(path);
            Assert.Equal(5, profile.Environments.Count());
            Assert.Equal("3c0ff8a7-e8bb-40e8-ae66-271343379af6", profile.DefaultContext.Tenant.Id.ToString());
            Assert.Equal("contoso.com", profile.DefaultContext.Tenant.Directory);
            Assert.Equal("00000000-0000-0000-0000-000000000000", profile.DefaultContext.Subscription.Id.ToString());
            Assert.Equal("testCloud", profile.DefaultContext.Environment.Name);
            Assert.Equal("me@contoso.com", profile.DefaultContext.Account.Id);
            Assert.Equal(new byte[] { 1, 2, 3, 4, 5, 6, 8, 9, 0 }, profile.DefaultContext.TokenCache.CacheData);
            Assert.Equal(path, profile.ProfilePath);
        }

        private class MockPage<T> : IPage<T>
        {
            public MockPage(IList<T> Items)
            {
                this.Items = Items;
            }

            /// <summary>
            /// Gets the link to the next page.
            /// </summary>
            public string NextPageLink { get; private set; }

            public IList<T> Items { get; set; }

            /// <summary>
            /// Returns an enumerator that iterates through the collection.
            /// </summary>
            /// <returns>A an enumerator that can be used to iterate through the collection.</returns>
            public IEnumerator<T> GetEnumerator()
            {
                return (Items == null) ? Enumerable.Empty<T>().GetEnumerator() : Items.GetEnumerator();
            }

            /// <summary>
            /// Returns an enumerator that iterates through the collection.
            /// </summary>
            /// <returns>A an enumerator that can be used to iterate through the collection.</returns>
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
