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

using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using System.Linq;
using Xunit;
using System;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Hyak.Common;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Moq;
using Microsoft.Rest;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Subscriptions;
using Microsoft.Azure.Subscriptions.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Test
{

    public class MockSubscriptionClientFactory 
    {
        private IDictionary<string, List<string>> _map;
        private string _currentTenant;
        public MockSubscriptionClientFactory(IDictionary<string, List<string>> tenantSubscriptionMap)
        {
            _map = tenantSubscriptionMap;
        }

        public SubscriptionClient GetSubscriptionClient(string tenant)
        {
            var tenantMock = new Mock<ITenantOperations>();
            tenantMock.Setup(t => t.ListAsync(It.IsAny<CancellationToken>()))
                .Returns(
                    (CancellationToken token) =>
                        Task.FromResult(new TenantListResult()
                        {
                            StatusCode = HttpStatusCode.OK,
                            RequestId = Guid.NewGuid().ToString(),
                            TenantIds = _map.Keys.Select((k) => new TenantIdDescription() { Id = k, TenantId = k }).ToList()
                        }));
            var subscriptionMock = new Mock<ISubscriptionOperations>();
            subscriptionMock.Setup(
                s => s.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).Returns(
                    (string subId, CancellationToken token) =>
                    {
                        GetSubscriptionResult result = null;
                        if (_map.ContainsKey(_currentTenant) && _map[_currentTenant].Contains(subId))
                        {
                            result = new GetSubscriptionResult
                            {
                                RequestId = Guid.NewGuid().ToString(),
                                StatusCode = HttpStatusCode.OK,
                                Subscription =
                                    new Subscription
                                    {
                                        DisplayName = "Returned SUbscription",
                                        Id = subId,
                                        State = "Active",
                                        SubscriptionId = subId
                                    }
                            };
                        }

                        return Task.FromResult(result);
                    });
            subscriptionMock.Setup(
                (s) => s.ListAsync(It.IsAny<CancellationToken>())).Returns(
                    (CancellationToken token) =>
                    {
                        SubscriptionListResult result = null;
                        if (_map.ContainsKey(_currentTenant))
                        {
                            result = new SubscriptionListResult
                            {
                                StatusCode = HttpStatusCode.OK,
                                RequestId = Guid.NewGuid().ToString(),
                                Subscriptions =
                                    new List<Subscription>(
                                        _map[_currentTenant].Select(
                                            sub =>
                                                new Subscription
                                                {
                                                    DisplayName = "Contoso Subscription",
                                                    Id = sub,
                                                    State = "Active",
                                                    SubscriptionId = sub
                                                }))
                            };
                        }

                        return Task.FromResult(result);
                    });
            var client = new Mock<SubscriptionClient>();
            client.SetupGet(c => c.Subscriptions).Returns(subscriptionMock.Object);
            client.SetupGet(c => c.Tenants).Returns(tenantMock.Object);
            return client.Object;
        }
    }

    public class AzureRMProfileTests
    {
        private const string DefaultAccount = "admin@contoso.com";
        private static Guid DefaultSubscription = Guid.NewGuid();
        private static string DefaultSubscriptionName = "Contoso Subscription";
        private static string DefaultDomain = "contoso.com";
        private static Guid DefaultTenant = Guid.NewGuid();
        [Fact]
        public void TestListSubscriptionWithoutTenantsThrows()
        {
            AzureSession.AuthenticationFactory = new MockTokenAuthenticationFactory(DefaultAccount,
                Guid.NewGuid().ToString());
            var clientFactory = new MockSubscriptionClientFactory(new Dictionary<string, List<string>>());
            AzureSession.ClientFactory = new MockClientFactory( new List<object>
            {
                clientFactory.GetSubscriptionClient(DefaultTenant.ToString())
            }, true);
            var context = new AzureContext(new AzureSubscription() {Account=DefaultAccount,
                Environment =EnvironmentName.AzureCloud, Id = DefaultSubscription, Name=DefaultSubscriptionName },
                new AzureAccount() {Id = DefaultAccount, Type = AzureAccount.AccountType.User}, 
                AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud], 
                new AzureTenant() {Domain = DefaultDomain, Id = DefaultTenant});
            var profile = new AzureRMProfile();
            profile.DefaultContext = context;
            RMProfileClient client = new RMProfileClient( profile);

        }

        [Fact]
        public void TestListSubscriptionWithoutSubscriptionsThrows()
        {
        }

        [Fact]
        public void TestListSubscriptionWithSingleTenantSingleSubscription()
        {
        }

        [Fact]
        public void TestListSubscriptionWithMultipleTenantsAndSubscriptions()
        {
        }
    }
}
