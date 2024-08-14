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
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager.Common;
using Microsoft.Azure.Commands.Profile;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Test;
using Microsoft.Azure.Commands.Profile.Utilities;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.Azure.Management.ResourceManager.Version2021_01_01.Models;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using Moq;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

using SubscriptionOld = Microsoft.Azure.Internal.Subscriptions.Models.Subscription;

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

        private static RMProfileClient SetupTestEnvironment(List<string> tenants, List<string> SubscripitonGetList, params List<string>[] subscriptionLists)
        {
            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory(DefaultAccount,
                Guid.NewGuid().ToString(), DefaultTenant.ToString());
            var subscriptionList = new Queue<List<string>>(subscriptionLists);
            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory(tenants, subscriptionList);
            if (SubscripitonGetList != null)
            {
                MockSubscriptionClientFactory.SubGetQueueVerLatest = new Queue<Func<AzureOperationResponse<Subscription>>>();
                var subscriptionGetQueue = new Queue<Func<AzureOperationResponse<SubscriptionOld>>>();
                foreach (string subId in SubscripitonGetList)
                {
                    if (subId != string.Empty)
                    {
                        var result = new AzureOperationResponse<Subscription>()
                        {
                            RequestId = Guid.NewGuid().ToString(),
                            Body = new Subscription(
                                id: subId,
                                subscriptionId: subId,
                                tenantId: null,
                                displayName: MockSubscriptionClientFactory.GetSubscriptionNameFromId(subId),
                                state: SubscriptionState.Enabled,
                                subscriptionPolicies: null,
                                authorizationSource: null)
                        };
                        MockSubscriptionClientFactory.SubGetQueueVerLatest.Enqueue(() => result);
                        var resultOld = new AzureOperationResponse<SubscriptionOld>()
                        {
                            RequestId = Guid.NewGuid().ToString(),
                            Body = new SubscriptionOld(
                                id: subId,
                                subscriptionId: subId,
                                tenantId: null,
                                displayName: MockSubscriptionClientFactory.GetSubscriptionNameFromId(subId),
                                state: 0,
                                subscriptionPolicies: null,
                                authorizationSource: null)
                        };
                        subscriptionGetQueue.Enqueue(() => resultOld);
                    }
                    else
                    {
                        MockSubscriptionClientFactory.SubGetQueueVerLatest.Enqueue(() =>
                        {
                            throw new CloudException("Subscription is not in the tenenat.");
                        });
                        subscriptionGetQueue.Enqueue(() =>
                        {
                            throw new CloudException("Subscription is not in the tenenat.");
                        });
                    }
                }
                MockSubscriptionClientFactory.SetGetAsyncResponses(subscriptionGetQueue);
            }

            var mock = new MockClientFactory(null, new List<object>
            {
                clientFactory.GetSubscriptionClientVerLatest(),
                clientFactory.GetSubscriptionClientVer2016()
            });
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
            var profile = new AzureRmProfile();
            profile.TrySetDefaultContext(Context);
            return new RMProfileClient(profile);
        }

        private static AzureRmProfile SetupLogin(List<string> tenants, params List<string>[] subscriptionLists)
        {
            AzureSession.Instance.AuthenticationFactory = new AuthenticationFactory();
            var subscriptionList = new Queue<List<string>>(subscriptionLists);
            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory(tenants, subscriptionList);
            var mock = new MockClientFactory(null, new List<object>
            {
                clientFactory.GetSubscriptionClientVerLatest(),
                clientFactory.GetSubscriptionClientVer2016()
            });
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
            var profile = new AzureRmProfile();
            profile.TrySetDefaultContext(Context);
            return profile;
        }

        public AzureRMProfileTests(ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SpecifyTenantAndSubscriptionIdSucceed()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var firstList = new List<string> { DefaultSubscription.ToString(), Guid.NewGuid().ToString() };
            var secondList = new List<string> { Guid.NewGuid().ToString() };
            var client = SetupTestEnvironment(tenants, null,  firstList, secondList);

            ((MockTokenAuthenticationFactory)AzureSession.Instance.AuthenticationFactory).TokenProvider = (account, environment, tenant) =>
            new MockAccessToken
            {
                UserId = "aaa@contoso.com",
                LoginType = LoginType.OrgId,
                AccessToken = "bbb",
                TenantId = DefaultTenant.ToString()
            };

            var mockOpenIDConfig = new Mock<IOpenIDConfiguration>();
            mockOpenIDConfig.SetupGet(p => p.TenantId).Returns(DefaultTenant.ToString());

            var azureRmProfile = client.Login(
                Context.Account,
                Context.Environment,
                DefaultTenant.ToString(),
                DefaultSubscription.ToString(),
                null,
                null,
                false,
                mockOpenIDConfig.Object,
                null);
            Assert.Equal("2021-01-01", client.SubscriptionAndTenantClient.ApiVersion);
        }

        private const string uriPattern = "https://login.microsoftonline.com/{0}/.well-known/openid-configuration";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SpecifyTenantDomainAndSubscriptionIdSucceed()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var firstList = new List<string> { DefaultSubscription.ToString(), Guid.NewGuid().ToString() };
            var secondList = new List<string> { Guid.NewGuid().ToString() };
            var client = SetupTestEnvironment(tenants, null,  firstList, secondList);
            var debugMessages = new List<string>();
            client.DebugLog = e => debugMessages.Add(e);

            ((MockTokenAuthenticationFactory)AzureSession.Instance.AuthenticationFactory).TokenProvider = (account, environment, tenant) =>
            new MockAccessToken
            {
                UserId = "aaa@contoso.com",
                LoginType = LoginType.OrgId,
                AccessToken = "bbb",
                TenantId = DefaultTenant.ToString()
            };

            var tenantDomain = MockSubscriptionClientFactory.GetTenantDomainFromId(DefaultTenant.ToString());
            var mockOpenIDConfig = new Mock<IOpenIDConfiguration>();
            mockOpenIDConfig.SetupGet(p => p.AbsoluteUri).Returns(string.Format(uriPattern, tenantDomain));
            mockOpenIDConfig.SetupGet(p => p.TenantId).Returns(DefaultTenant.ToString());

            var azureRmProfile = client.Login(
                Context.Account,
                Context.Environment,
                MockSubscriptionClientFactory.GetTenantDomainFromId(DefaultTenant.ToString()),
                DefaultSubscription.ToString(),
                null,
                null,
                false,
                mockOpenIDConfig.Object,
                null);
            Assert.Equal("2021-01-01", client.SubscriptionAndTenantClient.ApiVersion);
            Assert.Equal(3, debugMessages.Count);
            client.DebugLog = null;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SpecifyTenantDomainAndFailed()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var firstList = new List<string> { DefaultSubscription.ToString(), Guid.NewGuid().ToString() };
            var secondList = new List<string> { Guid.NewGuid().ToString() };
            var client = SetupTestEnvironment(tenants, null, firstList, secondList);
            var debugMessages = new List<string>();
            client.DebugLog = e => debugMessages.Add(e);

            ((MockTokenAuthenticationFactory)AzureSession.Instance.AuthenticationFactory).TokenProvider = (account, environment, tenant) =>
            new MockAccessToken
            {
                UserId = "aaa@contoso.com",
                LoginType = LoginType.OrgId,
                AccessToken = "bbb",
                TenantId = DefaultTenant.ToString()
            };


            var tenantDomain = MockSubscriptionClientFactory.GetTenantDomainFromId(DefaultTenant.ToString());
            var mockOpenIDConfig = new Mock<IOpenIDConfiguration>();
            mockOpenIDConfig.SetupGet(p => p.AbsoluteUri).Returns(string.Format(uriPattern, tenantDomain));
            mockOpenIDConfig.SetupGet(p => p.TenantId).Throws(new InvalidOperationException("Internal OpenIDConfiguration Doc Error."));

            Assert.Throws<ArgumentNullException>(() => client.Login(
                Context.Account,
                Context.Environment,
                tenantDomain,
                DefaultSubscription.ToString(),
                null,
                null,
                false,
                mockOpenIDConfig.Object,
                null));

            Assert.Equal(2, debugMessages.Count);
            Assert.Equal("2021-01-01", client.SubscriptionAndTenantClient.ApiVersion);

            client.DebugLog = null;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionIdNotExist()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var firstList = new List<string> { Guid.NewGuid().ToString() };
            var client = SetupTestEnvironment(tenants, null,  firstList);

            ((MockTokenAuthenticationFactory)AzureSession.Instance.AuthenticationFactory).TokenProvider = (account, environment, tenant) =>
            new MockAccessToken
            {
                UserId = "aaa@contoso.com",
                LoginType = LoginType.OrgId,
                AccessToken = "bbb",
                TenantId = DefaultTenant.ToString()
            };

            MockSubscriptionClientFactory.SubGetQueueVerLatest = new Queue<Func<AzureOperationResponse<Subscription>>>();
            MockSubscriptionClientFactory.SubGetQueueVerLatest.Enqueue(() =>
            {
                throw new CloudException("InvalidAuthenticationTokenTenant: The access token is from the wrong issuer");
            });

            var mockOpenIDConfig = new Mock<IOpenIDConfiguration>();
            mockOpenIDConfig.SetupGet(p => p.TenantId).Returns(DefaultTenant.ToString());

            Assert.Throws<PSInvalidOperationException>(() => client.Login(
               Context.Account,
               Context.Environment,
               null,
               DefaultSubscription.ToString(),
               null,
               null,
               false,
               mockOpenIDConfig.Object,
               null));
            Assert.Equal("2021-01-01", client.SubscriptionAndTenantClient.ApiVersion);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SpecifyTenantAndNotExistingSubscriptionId()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var firstList = new List<string> { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            var secondList = new List<string> { Guid.NewGuid().ToString() };
            var client = SetupTestEnvironment(tenants, null,  firstList, secondList);

            ((MockTokenAuthenticationFactory)AzureSession.Instance.AuthenticationFactory).TokenProvider = (account, environment, tenant) =>
            new MockAccessToken
            {
                UserId = "aaa@contoso.com",
                LoginType = LoginType.OrgId,
                AccessToken = "bbb",
                TenantId = DefaultTenant.ToString()
            };

            var mockOpenIDConfig = new Mock<IOpenIDConfiguration>();
            mockOpenIDConfig.SetupGet(p => p.TenantId).Returns(DefaultTenant.ToString());

            Assert.Throws<PSInvalidOperationException>(() => client.Login(
               Context.Account,
               Context.Environment,
               DefaultTenant.ToString(),
               DefaultSubscription.ToString(),
               null,
               null,
               false,
               mockOpenIDConfig.Object,
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
            var client = SetupTestEnvironment(tenants, null,  firstList, secondList);

            ((MockTokenAuthenticationFactory)AzureSession.Instance.AuthenticationFactory).TokenProvider = (account, environment, tenant) =>
            new MockAccessToken
            {
                UserId = "aaa@contoso.com",
                LoginType = LoginType.OrgId,
                AccessToken = "bbb",
                TenantId = DefaultTenant.ToString()
            };

            MockSubscriptionClientFactory.SubGetQueueVerLatest = new Queue<Func<AzureOperationResponse<Subscription>>>();
            MockSubscriptionClientFactory.SubGetQueueVerLatest.Enqueue(() =>
            {
                throw new CloudException("InvalidAuthenticationTokenTenant: The access token is from the wrong issuer");
            });

            var mockOpenIDConfig = new Mock<IOpenIDConfiguration>();
            mockOpenIDConfig.SetupGet(p => p.TenantId).Returns(DefaultTenant.ToString());

            var azureRmProfile = client.Login(
                Context.Account,
                Context.Environment,
                null,
                subscriptionInSecondTenant,
                null,
                null,
                false,
                mockOpenIDConfig.Object,
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
            var client = SetupTestEnvironment(tenants, null,  firstList, secondList);

            ((MockTokenAuthenticationFactory)AzureSession.Instance.AuthenticationFactory).TokenProvider = (account, environment, tenant) =>
            new MockAccessToken
            {
                UserId = "aaa@contoso.com",
                LoginType = LoginType.OrgId,
                AccessToken = "bbb",
                TenantId = DefaultTenant.ToString()
            };

            MockSubscriptionClientFactory.SubListQueueVerLatest = new Queue<Func<AzureOperationResponse<IPage<Subscription>>>>();
            MockSubscriptionClientFactory.SubListQueueVerLatest.Enqueue(() =>
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

            var mockOpenIDConfig = new Mock<IOpenIDConfiguration>();
            mockOpenIDConfig.SetupGet(p => p.TenantId).Returns(DefaultTenant.ToString());

            var azureRmProfile = client.Login(
                Context.Account,
                Context.Environment,
                null,
                null,
                MockSubscriptionClientFactory.GetSubscriptionNameFromId(subscriptionInSecondTenant),
                null,
                false,
                mockOpenIDConfig.Object,
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
            var client = SetupTestEnvironment(tenants, null,  firstList, secondList, thirdList, fourthList);
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

            var mockOpenIDConfig = new Mock<IOpenIDConfiguration>();
            mockOpenIDConfig.SetupGet(p => p.TenantId).Returns(DefaultTenant.ToString());

            var azureRmProfile = client.Login(
                Context.Account,
                Context.Environment,
                null,
                secondsubscriptionInTheFirstTenant,
                null,
                null,
                false,
                mockOpenIDConfig.Object,
                null);

            var tenantsInAccount = azureRmProfile.DefaultContext.Account.GetPropertyAsArray(AzureAccount.Property.Tenants);
            Assert.Single(tenantsInAccount);
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
            var client = SetupTestEnvironment(tenants, null,  firstList, secondList, thirdList, fourthList);

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

            var mockOpenIDConfig = new Mock<IOpenIDConfiguration>();
            mockOpenIDConfig.SetupGet(p => p.TenantId).Returns(DefaultTenant.ToString());

            Assert.Throws<AadAuthenticationCanceledException>(() => client.Login(
               Context.Account,
               Context.Environment,
               null,
               secondsubscriptionInTheFirstTenant,
               null,
               null,
               false,
               mockOpenIDConfig.Object,
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
            var client = SetupTestEnvironment(tenants, null,  firstList, secondList,
                                                       thirdList, fourthList,
                                                       thirdList, fourthList,
                                                       thirdList, fourthList);
            var subResults = new List<IAzureSubscription>(client.ListSubscriptions());
            Assert.Equal(7, subResults.Count);
            var tenantResults = client.ListTenants();
            Assert.Equal(2, tenantResults.Count());
            tenantResults = client.ListTenants(DefaultTenant.ToString());
            Assert.Single(tenantResults);
            var subValues = client.TryGetSubscriptionById(DefaultTenant.ToString(), DefaultSubscription.ToString());
            Assert.True(subValues != null && subValues.Count() > 0);
            Assert.Equal(DefaultSubscription.ToString(), subValues.FirstOrDefault().Id.ToString());

            IAzureSubscription subValue = null;
            Assert.True(client.TryGetSubscriptionByName(DefaultTenant.ToString(),
                MockSubscriptionClientFactory.GetSubscriptionNameFromId(DefaultSubscription.ToString()),
                out subValue));
            Assert.Equal(DefaultSubscription.ToString(), subValue.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultipleTenantsSubscriptionListSucceed()
        {
            var tenants = new List<string> { Guid.NewGuid().ToString(), DefaultTenant.ToString() };
            var secondsubscriptionInTheFirstTenant = Guid.NewGuid().ToString();
            var firstList = new List<string> { DefaultSubscription.ToString(), secondsubscriptionInTheFirstTenant };
            var secondList = new List<string> { Guid.NewGuid().ToString() };
            var thirdList = new List<string> { DefaultSubscription.ToString(), secondsubscriptionInTheFirstTenant };
            var fourthList = new List<string> { DefaultSubscription.ToString(), secondsubscriptionInTheFirstTenant };
            var client = SetupTestEnvironment(tenants, null,  firstList, secondList,
                                                       thirdList, fourthList,
                                                       thirdList, fourthList,
                                                       thirdList, fourthList);
            var subResults = new List<IAzureSubscription>(client.ListSubscriptions());
            Assert.Equal(7, subResults.Count);
            var tenantResults = client.ListTenants();
            Assert.Equal(2, tenantResults.Count());
            tenantResults = client.ListTenants(DefaultTenant.ToString());
            Assert.Single(tenantResults);
            IEnumerable<IAzureSubscription> subValueList;
            subValueList = client.TryGetSubscriptionById(DefaultTenant.ToString(), DefaultSubscription.ToString());
            Assert.True(subValueList != null && subValueList.Count() > 0);
            Assert.Equal(DefaultSubscription.ToString(), subValueList.FirstOrDefault().Id.ToString());
            Assert.True(client.TryGetSubscriptionListByName(DefaultTenant.ToString(),
                MockSubscriptionClientFactory.GetSubscriptionNameFromId(DefaultSubscription.ToString()),
                out subValueList));
            Assert.Equal(DefaultSubscription.ToString(), subValueList.FirstOrDefault().Id.ToString());
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
            var client = SetupTestEnvironment(tenants, null,  firstList, secondList, thirdList, fourthList, firstList, firstList);
            var subResults = new List<IAzureSubscription>(client.ListSubscriptions());
            Assert.Equal(2, subResults.Count);
            var tenantResults = client.ListTenants();
            Assert.Single(tenantResults);
            tenantResults = client.ListTenants(DefaultTenant.ToString());
            Assert.Single(tenantResults);
            var subValues = client.TryGetSubscriptionById(DefaultTenant.ToString(), DefaultSubscription.ToString());
            Assert.True(subValues != null && subValues.Count() > 0);
            Assert.Equal(DefaultSubscription.ToString(), subValues.FirstOrDefault().Id.ToString());
            IAzureSubscription subValue;
            Assert.True(client.TryGetSubscriptionByName(DefaultTenant.ToString(),
                MockSubscriptionClientFactory.GetSubscriptionNameFromId(DefaultSubscription.ToString()),
                out subValue));
            Assert.Equal(DefaultSubscription.ToString(), subValue.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SingleTenantSubscriptionListSucceed()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var secondsubscriptionInTheFirstTenant = Guid.NewGuid().ToString();
            var firstList = new List<string> { DefaultSubscription.ToString()};
            var secondList = firstList;
            var thirdList = firstList;
            var fourthList = firstList;
            var client = SetupTestEnvironment(tenants, null,  firstList, secondList, thirdList, fourthList);
            var tenantResults = client.ListTenants();
            Assert.Single(tenantResults);
            IEnumerable<IAzureSubscription> subValueList;
            Assert.True(client.TryGetSubscriptionListByName(DefaultTenant.ToString(),
                MockSubscriptionClientFactory.GetSubscriptionNameFromId(DefaultSubscription.ToString()),
                out subValueList));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSubscriptionListByNameSameIdCorrect()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var firstList = new List<string> { DefaultSubscription.ToString() };
            var secondList = firstList;
            var thirdList = firstList;
            var fourthList = firstList;
            var client = SetupTestEnvironment(tenants, null,  firstList, secondList, thirdList, fourthList);
            var tenantResults = client.ListTenants();
            Assert.Single(tenantResults);
            IEnumerable<IAzureSubscription> subValueList;
            client.TryGetSubscriptionListByName(DefaultTenant.ToString(),
                MockSubscriptionClientFactory.GetSubscriptionNameFromId(DefaultSubscription.ToString()),
                out subValueList);
            Assert.Single(subValueList);
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSubscriptionListByNameCorrect()
        {
            var subId1 = "a11a11aa-aaaa-aaaa-aaaa-aaaa1111aaaa";
            var subId2 = "aaaa11aa-aaaa-aaaa-aaaa-aaaa1111aaaa";

            var tenants = new List<string> { DefaultTenant.ToString() };
            var firstList = new List<string> { subId1 };
            var secondList = new List<string> { subId2 };
            var thirdList = firstList;
            var fourthList = firstList;
            var client = SetupTestEnvironment(tenants, null,  firstList, secondList, thirdList, fourthList);
            var tenantResults = client.ListTenants();
            Assert.Single(tenantResults);
            IEnumerable<IAzureSubscription> subValueList;
            client.TryGetSubscriptionListByName(DefaultTenant.ToString(),
                "SameNameForGetSubscriptionByName",
                out subValueList);
            Assert.Equal(2, subValueList.Count());
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
            var client = SetupTestEnvironment(tenants, null,  firstList, secondList,
                                                       thirdList, fourthList,
                                                       thirdList, fourthList);
            var subResults = new List<IAzureSubscription>(client.ListSubscriptions());
            Assert.Equal(2, subResults.Count);
            var subValues = client.TryGetSubscriptionById(DefaultTenant.ToString(), DefaultSubscription.ToString());
            Assert.True(subValues == null || subValues.Count() == 0);
            IAzureSubscription subValue;
            Assert.False(client.TryGetSubscriptionByName("random-tenant", "random-subscription", out subValue));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionListNotFoundDoesNotThrow()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            string randomSubscriptionId = Guid.NewGuid().ToString();
            var firstList = new List<string> { randomSubscriptionId };
            var secondList = firstList;
            var thirdList = firstList;
            var fourthList = firstList;
            var client = SetupTestEnvironment(tenants, null,  firstList, secondList,
                                                       thirdList, fourthList,
                                                       thirdList, fourthList);
            IEnumerable<IAzureSubscription> subValueList;
            Assert.False(client.TryGetSubscriptionListByName("random-tenant", "random-subscription", out subValueList));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NoTenantsDoesNotThrow()
        {
            var tenants = new List<string> { };
            var subscriptions = new List<string> { Guid.NewGuid().ToString() };
            var client = SetupTestEnvironment(tenants, null,  subscriptions);
            Assert.Empty(client.ListSubscriptions());
            Assert.Empty(client.ListTenants());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NoSubscriptionsInListDoesNotThrow()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var subscriptions = new List<string>();
            var client = SetupTestEnvironment(tenants, null
                , subscriptions, subscriptions, subscriptions, subscriptions, subscriptions, subscriptions);
            Assert.Empty(client.ListSubscriptions());
            var subValues = client.TryGetSubscriptionById(DefaultTenant.ToString(), DefaultSubscription.ToString());
            Assert.True(subValues == null || subValues.Count() == 0);
            IAzureSubscription subValue = null;
            Assert.False(client.TryGetSubscriptionByName(DefaultTenant.ToString(), "random-name", out subValue));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NoSubscriptionsInListDoesNotThrowForList()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var subscriptions = new List<string>();
            var client = SetupTestEnvironment(tenants, null,  subscriptions, subscriptions,
                                                       subscriptions, subscriptions,
                                                       subscriptions, subscriptions);
            Assert.Empty(client.ListSubscriptions());
            IEnumerable<IAzureSubscription> subValueList;
            Assert.False(client.TryGetSubscriptionListByName(DefaultTenant.ToString(), "random-name", out subValueList));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetContextPreservesTokenCache()
        {
            AzureRmProfile profile = null;
            AzureContext context = new AzureContext(null, null, null, null);
            Assert.Throws<ArgumentNullException>(() => profile.SetContextWithCache(context));
            profile = new AzureRmProfile();
            Assert.Throws<ArgumentNullException>(() => profile.SetContextWithCache(null));
            profile.SetContextWithCache(context);
            Assert.Equal(AzureSession.Instance.TokenCache.CacheData, profile.DefaultContext.TokenCache.CacheData);
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
            var client = SetupTestEnvironment(tenants, null,  firstList, secondList, thirdList, fourthList);

            var dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            var commandRuntimeMock = new MockCommandRuntime();
            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory();
            var profile = new AzureRmProfile();
            profile.EnvironmentTable.Add("foo", new AzureEnvironment(AzureEnvironment.PublicEnvironments.Values.FirstOrDefault()));
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
            var targetSubscription = (PSAzureSubscription)commandRuntimeMock.OutputPipeline.Where(sub => ((PSAzureSubscription)sub).Id.Equals(secondList[0])).FirstOrDefault();

            Assert.True(commandRuntimeMock.OutputPipeline.Count == 7);
            Assert.Equal("Disabled", targetSubscription?.State);
            Assert.Equal(subscriptionName, targetSubscription?.Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureRmSubscriptionByIdMultiplePages()
        {
            var tenants = new List<string> { Guid.NewGuid().ToString(), DefaultTenant.ToString() };
            string subscriptionRef = Guid.NewGuid().ToString();

            var subscriptionGetList = new List<string>() { string.Empty, subscriptionRef};

            var client = SetupTestEnvironment(tenants, subscriptionGetList);

            var dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            var commandRuntimeMock = new MockCommandRuntime();
            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory();
            var profile = new AzureRmProfile();
            profile.EnvironmentTable.Add("foo", new AzureEnvironment(AzureEnvironment.PublicEnvironments.Values.FirstOrDefault()));
            profile.DefaultContext = Context;
            var cmdlt = new GetAzureRMSubscriptionCommand();
            // Setup
            cmdlt.DefaultProfile = profile;
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SubscriptionId = subscriptionRef;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.True(commandRuntimeMock.OutputPipeline.Count == 1);

            // Make sure we can get a subscription from the second page of the second tenant by subscription Id
            var resultSubscription = (PSAzureSubscription)commandRuntimeMock.OutputPipeline[0];
            Assert.Equal(subscriptionRef, resultSubscription.Id);
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

            var client = SetupTestEnvironment(tenants, null,  firstList, secondList, thirdList, fourthList);

            var subscriptionName = MockSubscriptionClientFactory.GetSubscriptionNameFromId(secondTenantSubscriptions[2]);

            var dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            var commandRuntimeMock = new MockCommandRuntime();
            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory();
            var profile = new AzureRmProfile();
            profile.EnvironmentTable.Add("foo", new AzureEnvironment(AzureEnvironment.PublicEnvironments.Values.FirstOrDefault()));
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
        public void GetAzureRmSubscriptionManagedService()
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

            var client = SetupTestEnvironment(tenants, null,  firstList, secondList, thirdList, fourthList);

            // TEST WITH USER TYPE
            var dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            var commandRuntimeMock = new MockCommandRuntime();
            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory();
            var profile = new AzureRmProfile();
            profile.EnvironmentTable.Add("foo", new AzureEnvironment(AzureEnvironment.PublicEnvironments.Values.FirstOrDefault()));
            profile.DefaultContext = Context;
            profile.DefaultContext.Account = new AzureAccount();
            profile.DefaultContext.Tenant.Id = DefaultTenant.ToString();

            profile.DefaultContext.Account.Type = "User";
            var cmdlt = new GetAzureRMSubscriptionCommand();
            // Setup
            cmdlt.DefaultProfile = profile;
            cmdlt.CommandRuntime = commandRuntimeMock;
            Assert.Null(cmdlt.TenantId);
            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();
            Assert.Null(cmdlt.TenantId);
            Assert.True(commandRuntimeMock.OutputPipeline.Count == 8);

            // TEST WITH MANAGEDSERVICE
            client = SetupTestEnvironment(tenants, null,  firstList, secondList, thirdList, fourthList);

            dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            commandRuntimeMock = new MockCommandRuntime();
            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory();
            profile = new AzureRmProfile();
            profile.EnvironmentTable.Add("foo", new AzureEnvironment(AzureEnvironment.PublicEnvironments.Values.FirstOrDefault()));
            profile.DefaultContext = Context;
            profile.DefaultContext.Account = new AzureAccount();
            profile.DefaultContext.Tenant.Id = DefaultTenant.ToString();

            profile.DefaultContext.Account.Type = "ManagedService";
            cmdlt = new GetAzureRMSubscriptionCommand();
            // Setup
            cmdlt.DefaultProfile = profile;
            cmdlt.CommandRuntime = commandRuntimeMock;
            Assert.Null(cmdlt.TenantId);
            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();
            Assert.NotNull(cmdlt.TenantId);
            Assert.True(commandRuntimeMock.OutputPipeline.Count == 4);
        }

#if NETSTANDARD
        [Fact(Skip = "ConcurrentDictionary is not marked as Serializable")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ProfileSerializeDeserializeWorks()
        {
            var dataStore = new MockDataStore();
            AzureSession.Instance.DataStore = dataStore;
            var profilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AzureSession.Instance.ARMProfileFile);
            var currentProfile = new AzureRmProfile(profilePath);
            var tenantId = Guid.NewGuid().ToString();
            var environment = new AzureEnvironment
            {
                Name = "testCloud",
                ActiveDirectoryAuthority = "http://contoso.com"
            };
            environment.SetProperty(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint, "http://contoso.io");
            environment.SetProperty(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId, "http://insights.contoso.io/");
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
            currentProfile.DefaultContext.TokenCache = new AzureTokenCache { CacheData = new byte[] { 1, 2, 3, 4, 5, 6, 8, 9, 0 } };

            // Round-trip the exception: Serialize and de-serialize with a BinaryFormatter
            var serializedProfile = JsonSerializer.Serialize(currentProfile);
            // Replace the original exception with de-serialized one
            var deserializedProfile = JsonSerializer.Deserialize<AzureRmProfile>(serializedProfile);
            Assert.NotNull(deserializedProfile);
            var jCurrentProfile = currentProfile.ToString();
            var jDeserializedProfile = deserializedProfile.ToString();
            Assert.Equal(jCurrentProfile, jDeserializedProfile);
            Assert.True(deserializedProfile.DefaultContext.Environment.IsPropertySet(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint));
            Assert.True(deserializedProfile.DefaultContext.Environment.IsPropertySet(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId));
            Assert.Equal("http://contoso.io", deserializedProfile.DefaultContext.Environment.GetProperty(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint));
            Assert.Equal("http://insights.contoso.io/", deserializedProfile.DefaultContext.Environment.GetProperty(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId));
        }

#if NETSTANDARD
        [Fact(Skip = "Serialized property order changes from NetCore 2.1.2 -> 2.1.200")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SavingProfileWorks()
        {
            string expected = @"{
  ""DefaultContextKey"": ""Default"",
  ""EnvironmentTable"": {
    ""testCloud"": {
      ""Name"": ""testCloud"",
      ""OnPremise"": false,
      ""ServiceManagementUrl"": null,
      ""ResourceManagerUrl"": null,
      ""ManagementPortalUrl"": null,
      ""PublishSettingsFileUrl"": null,
      ""ActiveDirectoryAuthority"": ""http://contoso.com"",
      ""GalleryUrl"": null,
      ""GraphUrl"": null,
      ""ActiveDirectoryServiceEndpointResourceId"": null,
      ""StorageEndpointSuffix"": null,
      ""SqlDatabaseDnsSuffix"": null,
      ""TrafficManagerDnsSuffix"": null,
      ""AzureKeyVaultDnsSuffix"": null,
      ""AzureKeyVaultServiceEndpointResourceId"": null,
      ""GraphEndpointResourceId"": null,
      ""DataLakeEndpointResourceId"": null,
      ""BatchEndpointResourceId"": null,
      ""AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix"": null,
      ""AzureDataLakeStoreFileSystemEndpointSuffix"": null,
      ""AdTenant"": null,
      ""VersionProfiles"": [],
      ""ExtendedProperties"": {
        ""OperationalInsightsEndpoint"": ""http://contoso.io"",
        ""OperationalInsightsEndpointResourceId"": ""http://insights.contoso.io/""
      }
    }
  },
  ""Contexts"": {
    ""Default"": {
      ""Account"": {
        ""Id"": ""me@contoso.com"",
        ""Credential"": null,
        ""Type"": ""User"",
        ""TenantMap"": {},
        ""ExtendedProperties"": {
          ""Tenants"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6""
        }
      },
      ""Tenant"": {
        ""Id"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6"",
        ""Directory"": ""contoso.com"",
        ""ExtendedProperties"": {}
      },
      ""Subscription"": {
        ""Id"": ""00000000-0000-0000-0000-000000000000"",
        ""Name"": ""Contoso Test Subscription"",
        ""State"": ""Enabled"",
        ""ExtendedProperties"": {
          ""Account"": ""me@contoso.com"",
          ""Tenants"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6"",
          ""Environment"": ""testCloud""
        }
      },
      ""Environment"": {
        ""Name"": ""testCloud"",
        ""OnPremise"": false,
        ""ServiceManagementUrl"": null,
        ""ResourceManagerUrl"": null,
        ""ManagementPortalUrl"": null,
        ""PublishSettingsFileUrl"": null,
        ""ActiveDirectoryAuthority"": ""http://contoso.com"",
        ""GalleryUrl"": null,
        ""GraphUrl"": null,
        ""ActiveDirectoryServiceEndpointResourceId"": null,
        ""StorageEndpointSuffix"": null,
        ""SqlDatabaseDnsSuffix"": null,
        ""TrafficManagerDnsSuffix"": null,
        ""AzureKeyVaultDnsSuffix"": null,
        ""AzureKeyVaultServiceEndpointResourceId"": null,
        ""GraphEndpointResourceId"": null,
        ""DataLakeEndpointResourceId"": null,
        ""BatchEndpointResourceId"": null,
        ""AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix"": null,
        ""AzureDataLakeStoreFileSystemEndpointSuffix"": null,
        ""AdTenant"": null,
        ""VersionProfiles"": [],
        ""ExtendedProperties"": {
          ""OperationalInsightsEndpoint"": ""http://contoso.io"",
          ""OperationalInsightsEndpointResourceId"": ""http://insights.contoso.io/""
        }
      },
      ""VersionProfile"": null,
      ""TokenCache"": {
        ""CacheData"": ""AgAAAAAAAAA=""
      },
      ""ExtendedProperties"": {}
    }
  },
  ""ExtendedProperties"": {}
}";
#if NETSTANDARD
            expected = expected.Replace("AgAAAAAAAAA=", "AwAAAAAAAAA=");
#endif
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AzureSession.Instance.ARMProfileFile);
            var dataStore = new MockDataStore();
            AzureSession.Instance.DataStore = dataStore;
            AzureRmProfile profile = new AzureRmProfile(path);
            var tenantId = new Guid("3c0ff8a7-e8bb-40e8-ae66-271343379af6");
            var environment = new AzureEnvironment
            {
                Name = "testCloud",
                ActiveDirectoryAuthority = "http://contoso.com"
            };
            environment.SetProperty(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint, "http://contoso.io");
            environment.SetProperty(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId, "http://insights.contoso.io/");
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
            //profile.DefaultContext.TokenCache = new AuthenticationStoreTokenCache(new AzureTokenCache { CacheData = new byte[] { 1, 2, 3, 4, 5, 6, 8, 9, 0 } });
            profile.Save();
            string actual = dataStore.ReadFileAsText(path).Substring(1).TrimEnd(new[] { '\0' });
#if NETSTANDARD
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                expected = expected.Replace("\r\n", "\n");
            }
#endif
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
    ""TokenCache"": ""AgAAAAAAAAA="",
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
            var expectedArray = new byte[] { 2, 0, 0, 0, 0, 0, 0, 0 };
#if NETSTANDARD
            contents = contents.Replace("AgAAAAAAAAA=", "AwAAAAAAAAA=");
            expectedArray = new byte[] { 3, 0, 0, 0, 0, 0, 0, 0 };
#endif
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AzureSession.Instance.ARMProfileFile);
            var dataStore = new MockDataStore();
            AzureSession.Instance.DataStore = dataStore;
            dataStore.WriteFile(path, contents);
            var profile = new AzureRmProfile(path);
            Assert.Equal(4, profile.Environments.Count());
            Assert.Equal("3c0ff8a7-e8bb-40e8-ae66-271343379af6", profile.DefaultContext.Tenant.Id.ToString());
            Assert.Equal("00000000-0000-0000-0000-000000000000", profile.DefaultContext.Subscription.Id.ToString());
            Assert.Equal("testCloud", profile.DefaultContext.Environment.Name);
            Assert.Equal("me@contoso.com", profile.DefaultContext.Account.Id);
            Assert.Equal(AzureAccount.AccountType.User, profile.DefaultContext.Account.Type);
            Assert.Equal(path, profile.ProfilePath);
        }


        [Fact(Skip = "It's a limitation of mocked command in test framework, which uses ICommandRuntime instead of ICommandRuntime2. Connect-AzAccount uses WriteInformation() while WriteInformation only is defined in ICommandRuntime2.")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void CanRenewTokenLogin()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var subscriptions = new List<string> { DefaultSubscription.ToString() };
            var profile = SetupLogin(tenants, subscriptions, subscriptions);
            var cmdlet = new ConnectAzureRmAccountCommand();
            cmdlet.CommandRuntime = new MockCommandRuntime();
            cmdlet.DefaultProfile = profile;
            var accessToken1 = Guid.NewGuid().ToString();
            var graphToken1 = Guid.NewGuid().ToString();
            var keyVaultToken1 = Guid.NewGuid().ToString();
            cmdlet.AccessToken = accessToken1;
            cmdlet.GraphAccessToken = graphToken1;
            cmdlet.KeyVaultAccessToken = keyVaultToken1;
            cmdlet.AccountId = "user1@contoso.org";
            cmdlet.SetParameterSet(ConnectAzureRmAccountCommand.AccessTokenParameterSet);
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.NotNull(profile);
            Assert.NotNull(profile.DefaultContext);
            Assert.NotNull(profile.DefaultContext.Account);
            var account = profile.DefaultContext.Account;
            Assert.True(account.IsPropertySet(AzureAccount.Property.AccessToken));
            Assert.Equal(accessToken1, account.GetAccessToken());
            Assert.True(account.IsPropertySet(AzureAccount.Property.GraphAccessToken));
            Assert.Equal(graphToken1, account.GetProperty(AzureAccount.Property.GraphAccessToken));
            Assert.True(account.IsPropertySet(AzureAccount.Property.KeyVaultAccessToken));
            Assert.Equal(keyVaultToken1, account.GetProperty(AzureAccount.Property.KeyVaultAccessToken));
            var toss = SetupLogin(tenants, subscriptions, subscriptions);
            var cmdlet2 = new ConnectAzureRmAccountCommand();
            cmdlet2.CommandRuntime = new MockCommandRuntime();
            cmdlet2.DefaultProfile = profile;
            var accessToken2 = Guid.NewGuid().ToString();
            var graphToken2 = Guid.NewGuid().ToString();
            var keyVaultToken2 = Guid.NewGuid().ToString();
            cmdlet2.AccessToken = accessToken2;
            cmdlet2.GraphAccessToken = graphToken2;
            cmdlet2.KeyVaultAccessToken = keyVaultToken2;
            cmdlet2.AccountId = "user1@contoso.org";
            cmdlet2.SetParameterSet(ConnectAzureRmAccountCommand.AccessTokenParameterSet);
            cmdlet2.InvokeBeginProcessing();
            cmdlet2.ExecuteCmdlet();
            Assert.NotNull(profile);
            Assert.NotNull(profile.DefaultContext);
            Assert.NotNull(profile.DefaultContext.Account);
            account = profile.DefaultContext.Account;
            Assert.True(account.IsPropertySet(AzureAccount.Property.AccessToken));
            Assert.Equal(accessToken2, account.GetAccessToken());
            Assert.True(account.IsPropertySet(AzureAccount.Property.GraphAccessToken));
            Assert.Equal(graphToken2, account.GetProperty(AzureAccount.Property.GraphAccessToken));
            Assert.True(account.IsPropertySet(AzureAccount.Property.KeyVaultAccessToken));
            Assert.Equal(keyVaultToken2, account.GetProperty(AzureAccount.Property.KeyVaultAccessToken));
            var factory = new ClientFactory();
            var rmClient = factory.CreateArmClient<MockServiceClient>(profile.DefaultContext, AzureEnvironment.Endpoint.ResourceManager, AzureCmdletContext.CmdletNone);
            var rmCred = rmClient.Credentials as RenewingTokenCredential;
            Assert.NotNull(rmCred);
            var message = new HttpRequestMessage(HttpMethod.Get, rmClient.BaseUri.ToString());
            rmCred.ProcessHttpRequestAsync(message, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(message.Headers.Authorization);
            Assert.NotNull(message.Headers.Authorization.Parameter);
            Assert.Contains(accessToken2, message.Headers.Authorization.Parameter);
            var graphClient = factory.CreateArmClient<MockServiceClient>(profile.DefaultContext, AzureEnvironment.Endpoint.Graph, AzureCmdletContext.CmdletNone);
            var graphCred = graphClient.Credentials as RenewingTokenCredential;
            Assert.NotNull(graphCred);
            var graphMessage = new HttpRequestMessage(HttpMethod.Get, rmClient.BaseUri.ToString());
            graphCred.ProcessHttpRequestAsync(graphMessage, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(graphMessage.Headers.Authorization);
            Assert.NotNull(graphMessage.Headers.Authorization.Parameter);
            Assert.Contains(graphToken2, graphMessage.Headers.Authorization.Parameter);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ShouldShallowCopy()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var subscriptions = new List<string> { DefaultSubscription.ToString() };
            var profile = SetupLogin(tenants, subscriptions, subscriptions);

            var utilities = new AzureRmSharedUtilities();
            var copy = utilities.CopyForContextOverriding(profile) as AzureRmProfile;

            // Should act as shallow copy
            // except for that `Contexts` should be a new dictionary
            Assert.NotSame(profile, copy);
            Assert.Same(profile.EnvironmentTable, copy.EnvironmentTable);
            Assert.Same(profile.DefaultContext, copy.DefaultContext);
            Assert.NotSame(profile.Contexts, copy.Contexts);

            // Then deep copy default context of copy profile
            copy.DefaultContext = copy.DefaultContext.DeepCopy();
            Assert.NotSame(profile.DefaultContext, copy.DefaultContext);
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
