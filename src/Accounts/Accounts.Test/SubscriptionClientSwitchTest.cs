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
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.Azure.Management.ResourceManager.Version2021_01_01.Models;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Test
{
    public class SubscriptionClientSwitchTest : IDisposable
    {
        private const string DefaultAccount = "admin@contoso.com";
        private static Guid DefaultSubscription = Guid.NewGuid();
        private static string DefaultSubscriptionName = "Contoso Subscription";
        private static string DefaultDomain = "contoso.com";
        private static Guid DefaultTenant = Guid.NewGuid();
        private static IAzureContext Context;

        static private Queue<object> subscriptionClients = new Queue<object>();

        public SubscriptionClientSwitchTest(ITestOutputHelper output)
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
                TenantId = DefaultTenant.ToString()
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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionClientListTenantFallback()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var firstList = new List<string> { Guid.NewGuid().ToString() };
            var subscriptionList = new Queue<List<string>>();
            subscriptionList.Enqueue(firstList);

            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory(tenants, subscriptionList);

            MockSubscriptionClientFactory.TenantListQueueVerLatest = new Queue<Func<AzureOperationResponse<IPage<TenantIdDescription>>>>();
            MockSubscriptionClientFactory.TenantListQueueVerLatest.Enqueue(() =>
            {
                var e = new CloudException("The api-version is invalid. The supported versions are '2018-09-01,2018-08-01,2018-07-01,2018-06-01,2018-05-01,2018-02-01,2018-01-01,2017-12-01,2017-08-01,2017-06-01,2017-05-10,2017-05-01,2017-03-01,2016-09-01,2016-07-01,2016-06-01,2016-02-01,2015-11-01,2015-01-01,2014-04-01-preview,2014-04-01,2014-01-01,2013-03-01,2014-02-26,2014-04'.");
                e.Body = new CloudError();
                e.Body.Code = "InvalidApiVersionParameter";
                throw e;
            });

            clientFactory.ListTenantQueueDequeueVerLatest = () =>
            {
                AzureOperationResponse<IPage<TenantIdDescription>> result = null;
                try
                {
                    result = MockSubscriptionClientFactory.TenantListQueueVerLatest.Dequeue().Invoke();
                }
                catch (CloudException e)
                {
                    if (e.Body != null && !string.IsNullOrEmpty(e.Body.Code) && e.Body.Code.Equals("InvalidApiVersionParameter"))
                    {
                        subscriptionClients.Dequeue();
                    }
                    throw e;
                }
                return Task.FromResult(result);
            };

            subscriptionClients.Clear();
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVerLatest());
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVer2016());

            var mock = new AccountMockClientFactory(() =>
            {
                return subscriptionClients.Peek();
            }, true);
            mock.MoqClients = true;
            AzureSession.Instance.ClientFactory = mock;

            var client = GetProfileClient();
            var azureRmProfile = client.Login(
                Context.Account,
                Context.Environment,
                null,
                firstList.First().ToString(),
                null,
                null,
                false,
                null);

            Assert.Equal("2016-06-01", client.SubscriptionAndTenantClient.ApiVersion);
            Assert.Equal(DefaultTenant.ToString(), azureRmProfile.DefaultContext.Tenant.Id.ToString());
            Assert.Equal(firstList.First().ToString(), azureRmProfile.DefaultContext.Subscription.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionClientGetSubFallback()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var firstList = new List<string> { Guid.NewGuid().ToString() };
            var subscriptionList = new Queue<List<string>>();
            subscriptionList.Enqueue(firstList);

            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory(tenants, subscriptionList);

            MockSubscriptionClientFactory.SubGetQueueVerLatest = new Queue<Func<AzureOperationResponse<Subscription>>>();
            MockSubscriptionClientFactory.SubGetQueueVerLatest.Enqueue(() =>
            {
                var e = new CloudException("The api-version is invalid. The supported versions are '2018-09-01,2018-08-01,2018-07-01,2018-06-01,2018-05-01,2018-02-01,2018-01-01,2017-12-01,2017-08-01,2017-06-01,2017-05-10,2017-05-01,2017-03-01,2016-09-01,2016-07-01,2016-06-01,2016-02-01,2015-11-01,2015-01-01,2014-04-01-preview,2014-04-01,2014-01-01,2013-03-01,2014-02-26,2014-04'.");
                e.Body = new CloudError();
                e.Body.Code = "InvalidApiVersionParameter";
                throw e;
            });

            clientFactory.GetSubQueueDequeueVerLatest = () =>
            {
                AzureOperationResponse<Subscription> result = null;
                try
                {
                    result = MockSubscriptionClientFactory.SubGetQueueVerLatest.Dequeue().Invoke();
                }
                catch (CloudException e)
                {
                    if (e.Body != null && !string.IsNullOrEmpty(e.Body.Code) && e.Body.Code.Equals("InvalidApiVersionParameter"))
                    {
                        subscriptionClients.Dequeue();
                    }
                    throw e;
                }
                return Task.FromResult(result);
            };

            subscriptionClients.Clear();
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVerLatest());
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVer2016());

            var mock = new AccountMockClientFactory(() =>
            {
                return subscriptionClients.Peek();
            }, true);
            mock.MoqClients = true;
            AzureSession.Instance.ClientFactory = mock;

            var client = GetProfileClient();
            var azureRmProfile = client.Login(
                Context.Account,
                Context.Environment,
                DefaultTenant.ToString(),
                firstList.First().ToString(),
                null,
                null,
                false,
                null);

            Assert.Equal("2016-06-01", client.SubscriptionAndTenantClient.ApiVersion);
            Assert.Equal(DefaultTenant.ToString(), azureRmProfile.DefaultContext.Tenant.Id.ToString());
            Assert.Equal(firstList.First().ToString(), azureRmProfile.DefaultContext.Subscription.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionClientListSubFallback()
        {
            var tenants = new List<string> { DefaultTenant.ToString() };
            var firstList = new List<string> { Guid.NewGuid().ToString() };
            var secondList = new List<string> { Guid.NewGuid().ToString() };
            var subscriptionList = new Queue<List<string>>();
            subscriptionList.Enqueue(firstList);
            subscriptionList.Enqueue(secondList);

            MockSubscriptionClientFactory.Reset();
            var clientFactory = new MockSubscriptionClientFactory(tenants, subscriptionList);

            MockSubscriptionClientFactory.SubListQueueVerLatest = new Queue<Func<AzureOperationResponse<IPage<Subscription>>>>();
            MockSubscriptionClientFactory.SubListQueueVerLatest.Enqueue(() =>
            {
                var e = new CloudException("The api-version is invalid. The supported versions are '2018-09-01,2018-08-01,2018-07-01,2018-06-01,2018-05-01,2018-02-01,2018-01-01,2017-12-01,2017-08-01,2017-06-01,2017-05-10,2017-05-01,2017-03-01,2016-09-01,2016-07-01,2016-06-01,2016-02-01,2015-11-01,2015-01-01,2014-04-01-preview,2014-04-01,2014-01-01,2013-03-01,2014-02-26,2014-04'.");
                e.Body = new CloudError();
                e.Body.Code = "InvalidApiVersionParameter";
                throw e;
            });

            clientFactory.ListSubQueueDequeueVerLatest = () =>
            {
                AzureOperationResponse<IPage<Subscription>> result = null;
                try
                {
                    result = MockSubscriptionClientFactory.SubListQueueVerLatest.Dequeue().Invoke();
                }
                catch (CloudException e)
                {
                    if (e.Body != null && !string.IsNullOrEmpty(e.Body.Code) && e.Body.Code.Equals("InvalidApiVersionParameter"))
                    {
                        subscriptionClients.Dequeue();
                    }
                    throw e;
                }
                return Task.FromResult(result);
            };

            subscriptionClients.Clear();
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVerLatest());
            subscriptionClients.Enqueue(clientFactory.GetSubscriptionClientVer2016());

            var mock = new AccountMockClientFactory(() =>
            {
                return subscriptionClients.Peek();
            }, true);
            mock.MoqClients = true;
            AzureSession.Instance.ClientFactory = mock;

            var client = GetProfileClient();
            var azureRmProfile = client.Login(
                Context.Account,
                Context.Environment,
                DefaultTenant.ToString(),
                null,
                null,
                null,
                false,
                null);

            Assert.Equal("2016-06-01", client.SubscriptionAndTenantClient.ApiVersion);
            Assert.Equal(DefaultTenant.ToString(), azureRmProfile.DefaultContext.Tenant.Id.ToString());
            Assert.Equal(firstList.First().ToString(), azureRmProfile.DefaultContext.Subscription.Id.ToString());
        }
    }
}
