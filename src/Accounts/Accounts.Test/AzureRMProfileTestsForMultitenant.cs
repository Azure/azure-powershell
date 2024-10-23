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
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Test.Mocks;
using Microsoft.Azure.Commands.Profile.Utilities;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

using Moq;

using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

using Xunit;
using Xunit.Abstractions;

using SubscriptionLatest = Microsoft.Azure.Management.ResourceManager.Version2021_01_01.Models.Subscription;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Test
{
    public class AzureRMProfileTestsForMultitenant : IDisposable
    {
        private const string DefaultAccount = "admin@contoso.com";
        private static Guid DefaultSubscription = Guid.NewGuid();
        private static string DefaultSubscriptionName = "Contoso Subscription";
        private static string DefaultDomain = "contoso.com";
        private static Guid DefaultTenant = Guid.NewGuid();
        private static IAzureContext Context;

        static private Queue<object> subscriptionClients = new Queue<object>();

        public AzureRMProfileTestsForMultitenant(ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));

            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory(DefaultAccount,
    Guid.NewGuid().ToString(), DefaultTenant.ToString());
            ((MockTokenAuthenticationFactory)AzureSession.Instance.AuthenticationFactory).TokenProvider = (account, environment, tenant) =>
            new MockAccessToken
            {
                UserId = "aaa@contoso.com",
                LoginType = LoginType.OrgId,
                AccessToken = "bbb",
                TenantId = tenant
            };
        }

        public void Dispose()
        {
            SubscritpionClientCandidates.Reset();
        }

        private RMProfileClient GetProfileClient()
        {
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
            profile.DefaultContext = Context;
            return new RMProfileClient(profile);
        }

        static Dictionary<string, string> GetTenantsJson(string tenantA, string tenantB)
        {
            var pattern =
               @"[
                {{
                  ""id"": ""/tenants/{0}"",
                  ""tenantId"": ""{0}"",
                  ""countryCode"": ""US"",
                  ""displayName"": ""Microsoft"",
                  ""domains"": [
                    ""drawbridge.com"",
                    ""expresslogic.com"",
                    ""euevents.microsoft.com"",
                    ""nonprofits.microsoft.com"",
                    ""benefits.microsoft.com"",
                    ""forzaesports.com"",
                    ""bons.ai"",
                    ""bonsaiai.com"",
                    ""bonsai.ai"",
                    ""mileiq.com"",
                    ""idwebmail.microsoft.com"",
                    ""movere.io"",
                    ""experience.microsoft.com"",
                    ""thefightisinus.org"",
                    ""Unifiedlogic.com"",
                    ""mover.io""
                  ],
                  ""tenantCategory"": ""Home""
                }},
                {{
                  ""id"": ""/tenants/{1}"",
                  ""tenantId"": ""{1}"",
                  ""countryCode"": ""US"",
                  ""displayName"": ""Test Managed Services"",
                  ""domains"": [
                    ""testmanagedservices.onmicrosoft.com""
                  ],
                  ""tenantCategory"": ""Home""
                }}
              ]";
            pattern = string.Format(pattern, tenantA, tenantB);
            var patterns = JArray.Parse(pattern).ToArray();
            return new Dictionary<string, string>()
            {
                { tenantA, patterns[0].ToString() },
                { tenantB, patterns[1].ToString() }
            };
        }

        static Dictionary<string, string> GetFirstTenantSubscriptionsJson(string majorTenant, string subscriptionA, string subscriptionB, string subscriptionC, string otherTenant)
        {
            var pattern =
                @"[
                    {{
                      ""id"": ""/subscriptions/{0}"",
                      ""authorizationSource"": ""RoleBased"",
                      ""managedByTenants"": [
                        {{
                          ""tenantId"": ""{4}""
                        }},
                        {{
                          ""tenantId"": ""d6ad82f3-ffff-eeee-ffff-49e6c08f624e""
                        }}
                      ],
                      ""subscriptionId"": ""{0}"",
                      ""tenantId"": ""{3}"",
                      ""displayName"": ""Visual Studio Enterprise"",
                      ""state"": ""Enabled"",
                      ""subscriptionPolicies"": {{
                        ""locationPlacementId"": ""Public_2014-09-01"",
                        ""quotaId"": ""MSDN_2014-09-01"",
                        ""spendingLimit"": ""On""
                      }}
                    }},
                    {{
                      ""id"": ""/subscriptions/{1}"",
                      ""authorizationSource"": ""RoleBased"",
                      ""managedByTenants"": [
                        {{
                          ""tenantId"": ""{3}""
                        }}
                      ],
                      ""subscriptionId"": ""{1}"",
                      ""tenantId"": ""{4}"",
                      ""displayName"": ""Azure SDK Powershell Test - Automation"",
                      ""state"": ""Enabled"",
                      ""subscriptionPolicies"": {{
                        ""locationPlacementId"": ""Internal_2014-09-01"",
                        ""quotaId"": ""Internal_2014-09-01"",
                        ""spendingLimit"": ""Off""
                      }}
                    }},
                    {{
                      ""id"": ""/subscriptions/{2}"",
                      ""authorizationSource"": ""RoleBased"",
                      ""managedByTenants"": [
                        {{
                          ""tenantId"": ""{3}""
                        }}
                      ],
                      ""subscriptionId"": ""{2}"",
                      ""tenantId"": ""d6ad82f3-ffff-ddddd-ffff-49e6c08f624e"",
                      ""displayName"": ""Azure SDK Powershell Test - Manual"",
                      ""state"": ""Enabled"",
                      ""subscriptionPolicies"": {{
                        ""locationPlacementId"": ""Internal_2014-09-01"",
                        ""quotaId"": ""Internal_2014-09-01"",
                        ""spendingLimit"": ""Off""
                      }}
                    }},
                  ]";
            pattern = string.Format(pattern, subscriptionA, subscriptionB, subscriptionC, majorTenant, otherTenant);
            var patterns = JArray.Parse(pattern).ToArray();

            return new Dictionary<string, string>()
            {
                { subscriptionA, patterns[0].ToString() },
                { subscriptionB, patterns[1].ToString() },
                { subscriptionC, patterns[2].ToString() },
            };
        }
        static Dictionary<string, string> GetSecondTenantSubscriptionsJson(string majorTenant, string subscriptionA, string subscriptionB, string subscriptionC, string subscriptionD, string otherTenant)
        {
            var pattern =
                @"[
                    {{
                      ""id"": ""/subscriptions/{0}"",
                      ""authorizationSource"": ""RoleBased"",
                      ""managedByTenants"": [
                        {{
                          ""tenantId"": ""{4}""
                        }}
                      ],
                      ""subscriptionId"": ""{0}"",
                      ""tenantId"": ""{5}"",
                      ""displayName"": ""Visual Studio Enterprise"",
                      ""state"": ""Enabled"",
                      ""subscriptionPolicies"": {{
                        ""locationPlacementId"": ""Public_2014-09-01"",
                        ""quotaId"": ""MSDN_2014-09-01"",
                        ""spendingLimit"": ""On""
                      }}
                    }},
                    {{
                      ""id"": ""/subscriptions/{2}"",
                      ""authorizationSource"": ""RoleBased"",
                      ""managedByTenants"": [
                        {{
                          ""tenantId"": ""{4}""
                        }}
                      ],
                      ""subscriptionId"": ""{2}"",
                      ""tenantId"": ""d6ad82f3-ffff-ddddd-ffff-49e6c08f624e"",
                      ""displayName"": ""Azure SDK Powershell Test - Manual"",
                      ""state"": ""Enabled"",
                      ""subscriptionPolicies"": {{
                        ""locationPlacementId"": ""Internal_2014-09-01"",
                        ""quotaId"": ""Internal_2014-09-01"",
                        ""spendingLimit"": ""Off""
                      }}
                    }},
                    {{
                      ""id"": ""/subscriptions/{3}"",
                      ""authorizationSource"": ""RoleBased"",
                      ""managedByTenants"": [],
                      ""subscriptionId"": ""{3}"",
                      ""tenantId"": ""{4}"",
                      ""displayName"": ""Subscription Testing"",
                      ""state"": ""Enabled"",
                      ""subscriptionPolicies"": {{
                        ""locationPlacementId"": ""Internal_2014-09-01"",
                        ""quotaId"": ""Internal_2014-09-01"",
                        ""spendingLimit"": ""Off""
                      }}
                    }},
                  ]";
            pattern = string.Format(pattern, subscriptionA, subscriptionB, subscriptionC, subscriptionD, majorTenant, otherTenant);
            var patterns = JArray.Parse(pattern).ToArray();

            return new Dictionary<string, string>()
            {
                { subscriptionA, patterns[0].ToString() },
                { subscriptionC, patterns[1].ToString() },
                { subscriptionD, patterns[2].ToString() },
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoginByTenant()
        {
            string tenantA = Guid.NewGuid().ToString(), tenantB = Guid.NewGuid().ToString();
            string subscriptionA = Guid.NewGuid().ToString()
                , subscriptionB = Guid.NewGuid().ToString()
                , subscriptionC = Guid.NewGuid().ToString();
            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory();

            Dictionary<string, string> subscriptionList = GetFirstTenantSubscriptionsJson(tenantA, subscriptionA, subscriptionB, subscriptionC, tenantB);
            subscriptionClients.Clear();
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVerLatest(
                null
                , null
                , MockSubscriptionClientFactory.CreateSubscriptionListsFromJson(subscriptionList.Values.ToList())
                ));

            var mock = new AccountMockClientFactory(() =>
            {
                return subscriptionClients.Peek();
            }, true);
            mock.MoqClients = true;
            AzureSession.Instance.ClientFactory = mock;

            var mockOpenIDConfig = new Mock<IOpenIDConfiguration>();
            mockOpenIDConfig.SetupGet(p => p.TenantId).Returns(DefaultTenant.ToString());

            var client = GetProfileClient();
            var azureRmProfile = client.Login(
                Context.Account,
                Context.Environment,
                tenantA,
                null,
                null,
                null,
                false,
                mockOpenIDConfig.Object,
                null,
                IsInteractiveContextSelectionEnabled: false);

            Assert.Equal("2021-01-01", client.SubscriptionAndTenantClient.ApiVersion);
            Assert.Equal(tenantA, azureRmProfile.DefaultContext.Tenant.Id.ToString());
            Assert.Equal(subscriptionA, azureRmProfile.DefaultContext.Subscription.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoginBySubscriptionInMultitenantsHomeFirst()
        {
            string tenantA = Guid.NewGuid().ToString(), tenantB = Guid.NewGuid().ToString();
            string subscriptionA = Guid.NewGuid().ToString()
                , subscriptionB = Guid.NewGuid().ToString()
                , subscriptionC = Guid.NewGuid().ToString()
                , subscriptionD = Guid.NewGuid().ToString();
            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory();

            var subscriptionListA = GetFirstTenantSubscriptionsJson(tenantA, subscriptionA, subscriptionB, subscriptionC, tenantB);
            var subscriptionListB = GetSecondTenantSubscriptionsJson(tenantB, subscriptionA, subscriptionB, subscriptionC, subscriptionD, tenantA);
            subscriptionClients.Clear();
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVerLatest(
                MockSubscriptionClientFactory.CreateTenantListFromJson(GetTenantsJson(tenantA, tenantB).Values.ToArray())
                , MockSubscriptionClientFactory.CreateSubscripitonsFromJson(subscriptionListA[subscriptionA], subscriptionListB[subscriptionA])
                , null
                ));

            var mock = new AccountMockClientFactory(() =>
            {
                return subscriptionClients.Peek();
            }, true);
            mock.MoqClients = true;
            AzureSession.Instance.ClientFactory = mock;

            var mockOpenIDConfig = new Mock<IOpenIDConfiguration>();
            mockOpenIDConfig.SetupGet(p => p.TenantId).Returns(DefaultTenant.ToString());

            var client = GetProfileClient();
            var azureRmProfile = client.Login(
                Context.Account,
                Context.Environment,
                null,
                subscriptionA,
                null,
                null,
                false,
                mockOpenIDConfig.Object,
                null);

            Assert.Equal("2021-01-01", client.SubscriptionAndTenantClient.ApiVersion);
            Assert.Equal(tenantA, azureRmProfile.DefaultContext.Tenant.Id.ToString());
            Assert.Equal(subscriptionA, azureRmProfile.DefaultContext.Subscription.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoginBySubscriptionInMultitenantsHomeSecond()
        {
            string tenantA = Guid.NewGuid().ToString(), tenantB = Guid.NewGuid().ToString();
            string subscriptionA = Guid.NewGuid().ToString()
                , subscriptionB = Guid.NewGuid().ToString()
                , subscriptionC = Guid.NewGuid().ToString()
                , subscriptionD = Guid.NewGuid().ToString();
            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory();

            var tenantList = GetTenantsJson(tenantA, tenantB);
            var subscriptionListA = GetFirstTenantSubscriptionsJson(tenantA, subscriptionA, subscriptionB, subscriptionC, tenantB);
            var subscriptionListB = GetSecondTenantSubscriptionsJson(tenantB, subscriptionA, subscriptionB, subscriptionC, subscriptionD, tenantA);
            subscriptionClients.Clear();
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVerLatest(
                MockSubscriptionClientFactory.CreateTenantListFromJson(tenantList[tenantB], tenantList[tenantA])
                , null
                , MockSubscriptionClientFactory.CreateSubscriptionListsFromJson(subscriptionListB.Values.ToList(), subscriptionListA.Values.ToList())
                ));

            var mock = new AccountMockClientFactory(() =>
            {
                return subscriptionClients.Peek();
            }, true);
            mock.MoqClients = true;
            AzureSession.Instance.ClientFactory = mock;

            var subscriptionName = (JObject.Parse(subscriptionListA[subscriptionA]))["displayName"];

            var mockOpenIDConfig = new Mock<IOpenIDConfiguration>();
            mockOpenIDConfig.SetupGet(p => p.TenantId).Returns(DefaultTenant.ToString());

            var client = GetProfileClient();
            var azureRmProfile = client.Login(
                Context.Account,
                Context.Environment,
                null,
                null,
                subscriptionName.ToString(),
                null,
                false,
                mockOpenIDConfig.Object,
                null);

            Assert.Equal("2021-01-01", client.SubscriptionAndTenantClient.ApiVersion);
            Assert.Equal(tenantA, azureRmProfile.DefaultContext.Tenant.Id.ToString());
            Assert.Equal(subscriptionA, azureRmProfile.DefaultContext.Subscription.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoginBySubscriptionInManagedByTenants()
        {
            string tenantA = Guid.NewGuid().ToString(), tenantB = Guid.NewGuid().ToString();
            string subscriptionA = Guid.NewGuid().ToString()
                , subscriptionB = Guid.NewGuid().ToString()
                , subscriptionC = Guid.NewGuid().ToString()
                , subscriptionD = Guid.NewGuid().ToString();
            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory();

            Dictionary<string, string> subscriptionListA = GetFirstTenantSubscriptionsJson(tenantA, subscriptionA, subscriptionB, subscriptionC, tenantB);
            Dictionary<string, string> subscriptionListB = GetSecondTenantSubscriptionsJson(tenantB, subscriptionA, subscriptionB, subscriptionC, subscriptionD, tenantA);
            subscriptionClients.Clear();
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVerLatest(
                MockSubscriptionClientFactory.CreateTenantListFromJson(GetTenantsJson(tenantA, tenantB).Values.ToArray())
                , null
                , MockSubscriptionClientFactory.CreateSubscriptionListsFromJson(subscriptionListA.Values.ToList(), subscriptionListB.Values.ToList())
                ));

            var mock = new AccountMockClientFactory(() =>
            {
                return subscriptionClients.Peek();
            }, true);
            mock.MoqClients = true;
            AzureSession.Instance.ClientFactory = mock;

            var mockOpenIDConfig = new Mock<IOpenIDConfiguration>();
            mockOpenIDConfig.SetupGet(p => p.TenantId).Returns(DefaultTenant.ToString());

            var subscriptionName = (JObject.Parse(subscriptionListA[subscriptionC]))["displayName"];
            var client = GetProfileClient();
            var azureRmProfile = client.Login(
                Context.Account,
                Context.Environment,
                null,
                null,
                subscriptionName.ToString(),
                null,
                false,
                mockOpenIDConfig.Object,
                null);

            Assert.Equal("2021-01-01", client.SubscriptionAndTenantClient.ApiVersion);
            Assert.Equal(tenantB, azureRmProfile.DefaultContext.Tenant.Id.ToString());
            Assert.Equal(subscriptionC, azureRmProfile.DefaultContext.Subscription.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoginBySubscriptionTenant()
        {
            string tenantA = Guid.NewGuid().ToString(), tenantB = Guid.NewGuid().ToString();
            string subscriptionA = Guid.NewGuid().ToString()
                , subscriptionB = Guid.NewGuid().ToString()
                , subscriptionC = Guid.NewGuid().ToString()
                , subscriptionD = Guid.NewGuid().ToString();
            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory();

            Dictionary<string, string> subscriptionListA = GetFirstTenantSubscriptionsJson(tenantA, subscriptionA, subscriptionB, subscriptionC, tenantB);
            subscriptionClients.Clear();
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVerLatest(
                null
                , MockSubscriptionClientFactory.CreateSubscripitonsFromJson(subscriptionListA[subscriptionB])
                , null
                ));

            var mock = new AccountMockClientFactory(() =>
            {
                return subscriptionClients.Peek();
            }, true);
            mock.MoqClients = true;
            AzureSession.Instance.ClientFactory = mock;

            var mockOpenIDConfig = new Mock<IOpenIDConfiguration>();
            mockOpenIDConfig.SetupGet(p => p.TenantId).Returns(DefaultTenant.ToString());

            var client = GetProfileClient();
            var azureRmProfile = client.Login(
                Context.Account,
                Context.Environment,
                tenantA,
                subscriptionB,
                null,
                null,
                false,
                mockOpenIDConfig.Object,
                null);

            Assert.Equal("2021-01-01", client.SubscriptionAndTenantClient.ApiVersion);
            Assert.Equal(tenantA, azureRmProfile.DefaultContext.Tenant.Id.ToString());
            Assert.Equal(subscriptionB, azureRmProfile.DefaultContext.Subscription.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoginByTenantSubscriptionNotExist()
        {
            string tenantA = Guid.NewGuid().ToString(), tenantB = Guid.NewGuid().ToString();
            string subscriptionA = Guid.NewGuid().ToString()
                , subscriptionB = Guid.NewGuid().ToString()
                , subscriptionC = Guid.NewGuid().ToString()
                , subscriptionD = Guid.NewGuid().ToString();
            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory();

            Dictionary<string, string> subscriptionListA = GetFirstTenantSubscriptionsJson(tenantA, subscriptionA, subscriptionB, subscriptionC, tenantB);
            Dictionary<string, string> subscriptionListB = GetSecondTenantSubscriptionsJson(tenantB, subscriptionA, subscriptionB, subscriptionC, subscriptionD, tenantA);
            subscriptionClients.Clear();
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVerLatest(
                null
                , MockSubscriptionClientFactory.CreateSubscripitonsFromJson(null)
                , null
                ));

            var mock = new AccountMockClientFactory(() =>
            {
                return subscriptionClients.Peek();
            }, true);
            mock.MoqClients = true;
            AzureSession.Instance.ClientFactory = mock;

            var mockOpenIDConfig = new Mock<IOpenIDConfiguration>();
            mockOpenIDConfig.SetupGet(p => p.TenantId).Returns(DefaultTenant.ToString());

            var client = GetProfileClient();
            Assert.Throws<PSInvalidOperationException>(() =>
                client.Login(
                Context.Account,
                Context.Environment,
                tenantB,
                subscriptionB,
                null,
                null,
                false,
                mockOpenIDConfig.Object,
                null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoginSubscriptionNameNotExist()
        {
            string tenantA = Guid.NewGuid().ToString(), tenantB = Guid.NewGuid().ToString();
            string subscriptionA = Guid.NewGuid().ToString()
                , subscriptionB = Guid.NewGuid().ToString()
                , subscriptionC = Guid.NewGuid().ToString()
                , subscriptionD = Guid.NewGuid().ToString();
            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory();

            Dictionary<string, string> subscriptionListA = GetFirstTenantSubscriptionsJson(tenantA, subscriptionA, subscriptionB, subscriptionC, tenantB);
            Dictionary<string, string> subscriptionListB = GetSecondTenantSubscriptionsJson(tenantB, subscriptionA, subscriptionB, subscriptionC, subscriptionD, tenantA);
            subscriptionClients.Clear();
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVerLatest(
                MockSubscriptionClientFactory.CreateTenantListFromJson(GetTenantsJson(tenantA, tenantB).Values.ToArray())
                , null
                , MockSubscriptionClientFactory.CreateSubscriptionListsFromJson(subscriptionListA.Values.ToList(), subscriptionListB.Values.ToList())
                ));

            var mock = new AccountMockClientFactory(() =>
            {
                return subscriptionClients.Peek();
            }, true);
            mock.MoqClients = true;
            AzureSession.Instance.ClientFactory = mock;

            var mockOpenIDConfig = new Mock<IOpenIDConfiguration>();
            mockOpenIDConfig.SetupGet(p => p.TenantId).Returns(DefaultTenant.ToString());

            var client = GetProfileClient();
            Assert.Throws<PSInvalidOperationException>(() => client.Login(
                Context.Account,
                Context.Environment,
                null,
                null,
                "SubscriptionNotExits",
                null,
                false,
                mockOpenIDConfig.Object,
                null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetContextByValidTenant()
        {
            string tenantA = Guid.NewGuid().ToString(), tenantB = Guid.NewGuid().ToString();
            string subscriptionA = Guid.NewGuid().ToString()
                , subscriptionB = Guid.NewGuid().ToString()
                , subscriptionC = Guid.NewGuid().ToString();
            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory();

            Dictionary<string, string> subscriptionList = GetFirstTenantSubscriptionsJson(tenantA, subscriptionA, subscriptionB, subscriptionC, tenantB);
            subscriptionClients.Clear();
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVerLatest(
                null
                , null
                , MockSubscriptionClientFactory.CreateSubscriptionListsFromJson(subscriptionList.Values.ToList())
                ));

            var mock = new AccountMockClientFactory(() =>
            {
                return subscriptionClients.Peek();
            }, true);
            mock.MoqClients = true;
            AzureSession.Instance.ClientFactory = mock;


            var client = GetProfileClient();
            var context = client.SetCurrentContext(null, tenantA);

            Assert.Equal("2021-01-01", client.SubscriptionAndTenantClient.ApiVersion);
            Assert.Equal(tenantA, context.Tenant.Id.ToString());
            Assert.Equal(subscriptionA, context.Subscription.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetContextBySubscriptionIdInHomeTenant()
        {
            string tenantA = Guid.NewGuid().ToString(), tenantB = Guid.NewGuid().ToString();
            string subscriptionA = Guid.NewGuid().ToString()
                , subscriptionB = Guid.NewGuid().ToString()
                , subscriptionC = Guid.NewGuid().ToString()
                , subscriptionD = Guid.NewGuid().ToString();
            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory();

            var subscriptionListA = GetFirstTenantSubscriptionsJson(tenantA, subscriptionA, subscriptionB, subscriptionC, tenantB);
            var subscriptionListB = GetSecondTenantSubscriptionsJson(tenantB, subscriptionA, subscriptionB, subscriptionC, subscriptionD, tenantA);

            MockSubscriptionClientFactory.SubGetQueueVerLatest = new Queue<Func<AzureOperationResponse<SubscriptionLatest>>>();
            MockSubscriptionClientFactory.SubGetQueueVerLatest.Enqueue(() =>
            {
                throw new CloudException("Subscription not in the tenant.");
            });

            var resultLatest = new AzureOperationResponse<SubscriptionLatest>()
            {
                RequestId = Guid.NewGuid().ToString(),
                Body = MockSubscriptionClientFactory.CreateSubscripitonsFromJson(subscriptionListA[subscriptionA]).First()
            };
            MockSubscriptionClientFactory.SubGetQueueVerLatest.Enqueue(() => resultLatest);

            subscriptionClients.Clear();
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVerLatest(
                MockSubscriptionClientFactory.CreateTenantListFromJson(GetTenantsJson(tenantB, tenantA).Values.ToArray())
                , null, null));

            var mock = new AccountMockClientFactory(() =>
            {
                return subscriptionClients.Peek();
            }, true);
            mock.MoqClients = true;
            AzureSession.Instance.ClientFactory = mock;

            var client = GetProfileClient();
            var context = client.SetCurrentContext(subscriptionA, null);

            Assert.Equal("2021-01-01", client.SubscriptionAndTenantClient.ApiVersion);
            Assert.Equal(tenantA, context.Tenant.Id.ToString());
            Assert.Equal(subscriptionA, context.Subscription.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetContextBySubscriptionNameInHomeTenant()
        {
            string tenantA = Guid.NewGuid().ToString(), tenantB = Guid.NewGuid().ToString();
            string subscriptionA = Guid.NewGuid().ToString()
                , subscriptionB = Guid.NewGuid().ToString()
                , subscriptionC = Guid.NewGuid().ToString()
                , subscriptionD = Guid.NewGuid().ToString();
            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory();

            var tenantList = GetTenantsJson(tenantA, tenantB);
            var subscriptionListA = GetFirstTenantSubscriptionsJson(tenantA, subscriptionA, subscriptionB, subscriptionC, tenantB);
            var subscriptionListB = GetSecondTenantSubscriptionsJson(tenantB, subscriptionA, subscriptionB, subscriptionC, subscriptionD, tenantA);
            subscriptionClients.Clear();
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVerLatest(
                MockSubscriptionClientFactory.CreateTenantListFromJson(tenantList[tenantB], tenantList[tenantA])
                , null
                , MockSubscriptionClientFactory.CreateSubscriptionListsFromJson(subscriptionListA.Values.ToList(), subscriptionListB.Values.ToList())
                ));


            var mock = new AccountMockClientFactory(() =>
            {
                return subscriptionClients.Peek();
            }, true);
            mock.MoqClients = true;
            AzureSession.Instance.ClientFactory = mock;

            var subscriptionName = (JObject.Parse(subscriptionListA[subscriptionA]))["displayName"];
            var client = GetProfileClient();
            var context = client.SetCurrentContext(subscriptionName.ToString(), null);

            Assert.Equal("2021-01-01", client.SubscriptionAndTenantClient.ApiVersion);
            Assert.Equal(tenantA, context.Tenant.Id.ToString());
            Assert.Equal(subscriptionA, context.Subscription.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetContextBySubscriptionInManagedByTenants()
        {
            string tenantA = Guid.NewGuid().ToString(), tenantB = Guid.NewGuid().ToString();
            string subscriptionA = Guid.NewGuid().ToString()
                , subscriptionB = Guid.NewGuid().ToString()
                , subscriptionC = Guid.NewGuid().ToString()
                , subscriptionD = Guid.NewGuid().ToString();
            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory();

            Dictionary<string, string> subscriptionListA = GetFirstTenantSubscriptionsJson(tenantA, subscriptionA, subscriptionB, subscriptionC, tenantB);
            Dictionary<string, string> subscriptionListB = GetSecondTenantSubscriptionsJson(tenantB, subscriptionA, subscriptionB, subscriptionC, subscriptionD, tenantA);
            subscriptionClients.Clear();
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVerLatest(
                MockSubscriptionClientFactory.CreateTenantListFromJson(GetTenantsJson(tenantA, tenantB).Values.ToArray())
                , MockSubscriptionClientFactory.CreateSubscripitonsFromJson(subscriptionListA[subscriptionC])
                , null));

            var mock = new AccountMockClientFactory(() =>
            {
                return subscriptionClients.Peek();
            }, true);
            mock.MoqClients = true;
            AzureSession.Instance.ClientFactory = mock;

            var client = GetProfileClient();
            var context = client.SetCurrentContext(subscriptionC.ToString(), null);

            Assert.Equal("2021-01-01", client.SubscriptionAndTenantClient.ApiVersion);
            Assert.Equal(tenantA, context.Tenant.Id.ToString());
            Assert.Equal(subscriptionC, context.Subscription.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetContextBySubscriptionTenant()
        {
            string tenantA = Guid.NewGuid().ToString(), tenantB = Guid.NewGuid().ToString();
            string subscriptionA = Guid.NewGuid().ToString()
                , subscriptionB = Guid.NewGuid().ToString()
                , subscriptionC = Guid.NewGuid().ToString()
                , subscriptionD = Guid.NewGuid().ToString();
            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory();

            Dictionary<string, string> subscriptionListA = GetFirstTenantSubscriptionsJson(tenantA, subscriptionA, subscriptionB, subscriptionC, tenantB);
            subscriptionClients.Clear();
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVerLatest(
                null
                , null
                , MockSubscriptionClientFactory.CreateSubscriptionListsFromJson(subscriptionListA.Values.ToList())
                ));

            var mock = new AccountMockClientFactory(() =>
            {
                return subscriptionClients.Peek();
            }, true);
            mock.MoqClients = true;
            AzureSession.Instance.ClientFactory = mock;


            var client = GetProfileClient();
            var subscriptionName = (JObject.Parse(subscriptionListA[subscriptionB]))["displayName"];
            var context = client.SetCurrentContext(subscriptionName.ToString(), tenantA);

            Assert.Equal("2021-01-01", client.SubscriptionAndTenantClient.ApiVersion);
            Assert.Equal(tenantA, context.Tenant.Id.ToString());
            Assert.Equal(subscriptionB, context.Subscription.Id.ToString());
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetContextBySubscriptionTenantNotExist()
        {
            string tenantA = Guid.NewGuid().ToString(), tenantB = Guid.NewGuid().ToString();
            string subscriptionA = Guid.NewGuid().ToString()
                , subscriptionB = Guid.NewGuid().ToString()
                , subscriptionC = Guid.NewGuid().ToString()
                , subscriptionD = Guid.NewGuid().ToString();
            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory();

            Dictionary<string, string> subscriptionListB = GetSecondTenantSubscriptionsJson(tenantB, subscriptionA, subscriptionB, subscriptionC, subscriptionD, tenantA);
            subscriptionClients.Clear();
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVerLatest(null, null, null));

            var mock = new AccountMockClientFactory(() =>
            {
                return subscriptionClients.Peek();
            }, true);
            mock.MoqClients = true;
            AzureSession.Instance.ClientFactory = mock;

            var client = GetProfileClient();
            Assert.Throws<ArgumentException>(() => client.SetCurrentContext(subscriptionB, tenantB));
        }
    }
}
