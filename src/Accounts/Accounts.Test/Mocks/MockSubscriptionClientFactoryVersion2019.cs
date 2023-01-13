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

using Microsoft.Azure.Management.ResourceManager.Version2021_01_01;
using Microsoft.Azure.Management.ResourceManager.Version2021_01_01.Models;
using Microsoft.Rest.Azure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Language;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Test
{
    public partial class MockSubscriptionClientFactory
    {
        public static Queue<Func<AzureOperationResponse<Subscription>>> SubGetQueueVerLatest { get; set; } = null;
        public static Queue<Func<AzureOperationResponse<IPage<Subscription>>>> SubListQueueVerLatest { get; set; } = null;
        public static Queue<Func<AzureOperationResponse<IPage<TenantIdDescription>>>> TenantListQueueVerLatest { get; set; } = null;

        public DeGetAsyncQueue<Subscription> GetSubQueueDequeueVerLatest = () => Task.FromResult(SubGetQueueVerLatest.Dequeue().Invoke());
        public DeListAsyncQueue<Subscription> ListSubQueueDequeueVerLatest = () => Task.FromResult(SubListQueueVerLatest.Dequeue().Invoke());
        public DeListAsyncQueue<TenantIdDescription> ListTenantQueueDequeueVerLatest = () => Task.FromResult(TenantListQueueVerLatest.Dequeue().Invoke());

        public SubscriptionClient GetSubscriptionClientVerLatest()
        {
            var tenantMock = new Mock<ITenantsOperations>();
            tenantMock.Setup(t => t.ListWithHttpMessagesAsync(It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(
                    (Dictionary<string, List<string>> ch, CancellationToken token) =>
                    {
                        if(TenantListQueueVerLatest != null && TenantListQueueVerLatest.Any())
                        {
                            return ListTenantQueueDequeueVerLatest();
                        }
                        var tenants = _tenants.Select((k) => new TenantIdDescription(id: k, tenantId: k, domains: new List<string>{GetTenantDomainFromId(k)}));
                        var mockPage = new MockPage<TenantIdDescription>(tenants.ToList());

                        AzureOperationResponse<IPage<TenantIdDescription>> r = new AzureOperationResponse<IPage<TenantIdDescription>>
                        {
                            Body = mockPage
                        };

                        return Task.FromResult(r);
                    }
                );
            var subscriptionMock = new Mock<ISubscriptionsOperations>();
            subscriptionMock.Setup(
                s => s.GetWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>())).Returns(
                    (string subId, Dictionary<string, List<string>> ch, CancellationToken token) =>
                    {
                        if (SubGetQueueVerLatest != null && SubGetQueueVerLatest.Any())
                        {
                            return GetSubQueueDequeueVerLatest();
                        }
                        AzureOperationResponse<Subscription> result = new AzureOperationResponse<Subscription>
                        {
                            RequestId = Guid.NewGuid().ToString()
                        };
                        if (_subscriptionSet.Contains(subId))
                        {
                            result.Body =
                                new Subscription(
                                    id: subId,
                                    subscriptionId: subId,
                                    tenantId: null,
                                    displayName: GetSubscriptionNameFromId(subId),
                                    state: SubscriptionState.Enabled,
                                    subscriptionPolicies: null,
                                    authorizationSource: null);
                        }

                        return Task.FromResult(result);
                    });
            subscriptionMock.Setup(
                (s) => s.ListWithHttpMessagesAsync(null, It.IsAny<CancellationToken>())).Returns(
                    (Dictionary<string, List<string>> ch, CancellationToken token) =>
                    {
                        if (SubListQueueVerLatest != null && SubListQueueVerLatest.Any())
                        {
                            return ListSubQueueDequeueVerLatest();
                        }

                        AzureOperationResponse<IPage<Subscription>> result = null;
                        if (_subscriptions.Count > 0)
                        {
                            var subscriptionList = _subscriptions.Dequeue();
                            result = new AzureOperationResponse<IPage<Subscription>>
                            {
                                RequestId = Guid.NewGuid().ToString(),
                                Body = new MockPage<Subscription>(
                                    new List<Subscription>(
                                        subscriptionList.Select(
                                            sub =>
                                                new Subscription(
                                                    id: sub,
                                                    subscriptionId: sub,
                                                    tenantId: null,
                                                    displayName: GetSubscriptionNameFromId(sub),
                                                    state: SubscriptionState.Enabled,
                                                    subscriptionPolicies: null,
                                                    authorizationSource: null))), "LinkToNextPage")
                            };
                        }

                        return Task.FromResult(result);
                    });
            subscriptionMock.Setup(
                (s) => s.ListNextWithHttpMessagesAsync("LinkToNextPage", null, It.IsAny<CancellationToken>())).Returns(
                    (string nextLink, Dictionary<string, List<string>> ch, CancellationToken token) =>
                    {
                        AzureOperationResponse<IPage<Subscription>> result = null;
                        if (_subscriptions.Count > 0)
                        {
                            var subscriptionList = _subscriptions.Dequeue();
                            result = new AzureOperationResponse<IPage<Subscription>>
                            {
                                RequestId = Guid.NewGuid().ToString(),
                                Body = new MockPage<Subscription>(
                                    new List<Subscription>(
                                        subscriptionList.Select(
                                            sub =>
                                                new Subscription(
                                                id: sub,
                                                subscriptionId: sub,
                                                tenantId: null,
                                                displayName: GetSubscriptionNameFromId(sub),
                                                state: SubscriptionState.Disabled,
                                                subscriptionPolicies: null,
                                                authorizationSource: null))))
                            };
                        }
                        return Task.FromResult(result);
                    });
            var client = new Mock<SubscriptionClient>() { CallBase = true };
            client.SetupGet(c => c.Subscriptions).Returns(subscriptionMock.Object);
            client.SetupGet(c => c.Tenants).Returns(tenantMock.Object);
            return client.Object;
        }

        private ITenantsOperations GetTenantMock(List<TenantIdDescription> tenants)
        {
            var tenantMock = new Mock<ITenantsOperations>();
            tenantMock.Setup(t => t.ListWithHttpMessagesAsync(It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(
                    (Dictionary<string, List<string>> ch, CancellationToken token) =>
                    {
                        if (TenantListQueueVerLatest != null && TenantListQueueVerLatest.Any())
                        {
                            return ListTenantQueueDequeueVerLatest();
                        }

                        AzureOperationResponse<IPage<TenantIdDescription>> r = null;
                        if (tenants != null)
                        {
                            var mockPage = new MockPage<TenantIdDescription>(tenants);
                            r = new AzureOperationResponse<IPage<TenantIdDescription>>
                            {
                                Body = mockPage
                            };
                        }
                        return Task.FromResult(r);
                    }
                );
            return tenantMock.Object;
        }

        private ISubscriptionsOperations GetSubscriptionMock(List<Subscription> subscriptionGetList, List<List<Subscription>> subscriptionListLists, List<bool> HasNextPage)
        {
            if(HasNextPage == null && subscriptionListLists != null)
            {
                HasNextPage = Enumerable.Repeat(false, subscriptionListLists.Count).ToList();
            }
            var subscriptionMock = new Mock<ISubscriptionsOperations>();
            subscriptionMock.Setup(
                s => s.GetWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>())).Returns(
                    (string subId, Dictionary<string, List<string>> ch, CancellationToken token) =>
                    {
                        if (SubGetQueueVerLatest != null && SubGetQueueVerLatest.Any())
                        {
                            return GetSubQueueDequeueVerLatest();
                        }
                        if (subscriptionGetList == null || !subscriptionGetList.Any())
                        {
                            throw new CloudException("Subscripiton is not in the tenant.");
                        }
                        var result = new AzureOperationResponse<Subscription>()
                        {
                            RequestId = Guid.NewGuid().ToString(),
                            Body = subscriptionGetList.First()
                        };
                        subscriptionGetList.RemoveAt(0);
                        return Task.FromResult(result);
                    });
            subscriptionMock.Setup(
                (s) => s.ListWithHttpMessagesAsync(null, It.IsAny<CancellationToken>())).Returns(
                    (Dictionary<string, List<string>> ch, CancellationToken token) =>
                    {
                        if (SubListQueueVerLatest != null && SubListQueueVerLatest.Any())
                        {
                            return ListSubQueueDequeueVerLatest();
                        }

                        AzureOperationResponse<IPage<Subscription>> result = null;
                        if (subscriptionListLists!= null && subscriptionListLists.Any() && HasNextPage.Any())
                        {
                            result = new AzureOperationResponse<IPage<Subscription>>
                            {
                                RequestId = Guid.NewGuid().ToString(),
                                Body = HasNextPage.First() ? new MockPage<Subscription>(subscriptionListLists.FirstOrDefault(), "LinkToNextPage") : new MockPage<Subscription>(subscriptionListLists.FirstOrDefault())
                            };
                            subscriptionListLists.RemoveAt(0);
                            HasNextPage.RemoveAt(0);
                        }

                        return Task.FromResult(result);
                    });
            subscriptionMock.Setup(
                (s) => s.ListNextWithHttpMessagesAsync("LinkToNextPage", null, It.IsAny<CancellationToken>())).Returns(
                    (string nextLink, Dictionary<string, List<string>> ch, CancellationToken token) =>
                    {
                        AzureOperationResponse<IPage<Subscription>> result = null;
                        if (subscriptionListLists.Any() && HasNextPage.Any())
                        {
                            result = new AzureOperationResponse<IPage<Subscription>>
                            {
                                RequestId = Guid.NewGuid().ToString(),
                                Body = new MockPage<Subscription>(subscriptionListLists.LastOrDefault())
                            };
                            subscriptionListLists.RemoveAt(0);
                            HasNextPage.RemoveAt(0);
                        }
                        return Task.FromResult(result);
                    });
            return subscriptionMock.Object;
        }

        public SubscriptionClient GetSubscriptionClientVerLatest(List<TenantIdDescription> tenants, List<Subscription> subscriptionGetList, List<List<Subscription>> subscriptionListLists, List<bool> HasNextPage = null)
        {
            var client = new Mock<SubscriptionClient>() { CallBase = true };
            client.SetupGet(c => c.Subscriptions).Returns(GetSubscriptionMock(subscriptionGetList, subscriptionListLists, HasNextPage));
            client.SetupGet(c => c.Tenants).Returns(GetTenantMock(tenants));
            return client.Object;
        }

        public static List<TenantIdDescription> CreateTenantListFromJson(params string[] jsons)
        {
            List<TenantIdDescription> result = new List<TenantIdDescription>();
            if (jsons != null)
            {
                foreach (string json in jsons)
                {
                    result.Add(JsonConvert.DeserializeObject<TenantIdDescription>(json));
                }
            }
            return result;
        }

        public static List<List<Subscription>> CreateSubscriptionListsFromJson(params List<string>[] jsonLists)
        {
            List<List<Subscription>> result = new List<List<Subscription>>();
            if (jsonLists != null)
            {
                foreach (List<string> jsonList in jsonLists)
                {
                    result.Add(new List<Subscription>());
                    jsonList.ForEach(j => result.Last().Add(JsonConvert.DeserializeObject<Subscription>(j)));

                }
            }
            return result;
        }

        public static List<Subscription> CreateSubscripitonsFromJson(params string[] jsons)
        {
            List<Subscription> result = new List<Subscription>();
            if(jsons != null)
            {
                foreach (string json in jsons)
                {
                    result.Add(JsonConvert.DeserializeObject<Subscription>(json));
                }
            }
            return result;
        }
    }
}
