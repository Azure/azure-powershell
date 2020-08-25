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

using Microsoft.Azure.Management.ResourceManager.Version2019_06_01;
using Microsoft.Azure.Management.ResourceManager.Version2019_06_01.Models;
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
        public static Queue<Func<AzureOperationResponse<Subscription>>> SubGetQueueVer2019 { get; set; } = null;
        public static Queue<Func<AzureOperationResponse<IPage<Subscription>>>> SubListQueueVer2019 { get; set; } = null;
        public static Queue<Func<AzureOperationResponse<IPage<TenantIdDescription>>>> TenantListQueueVer2019 { get; set; } = null;

        public DeGetAsyncQueue<Subscription> GetSubQueueDequeueVer2019 = () => Task.FromResult(SubGetQueueVer2019.Dequeue().Invoke());
        public DeListAsyncQueue<Subscription> ListSubQueueDequeueVer2019 = () => Task.FromResult(SubListQueueVer2019.Dequeue().Invoke());
        public DeListAsyncQueue<TenantIdDescription> ListTenantQueueDequeueVer2019 = () => Task.FromResult(TenantListQueueVer2019.Dequeue().Invoke());

        public SubscriptionClient GetSubscriptionClientVer2019()
        {
            var tenantMock = new Mock<ITenantsOperations>();
            tenantMock.Setup(t => t.ListWithHttpMessagesAsync(It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(
                    (Dictionary<string, List<string>> ch, CancellationToken token) =>
                    {
                        if(TenantListQueueVer2019 != null && TenantListQueueVer2019.Any())
                        {
                            return ListTenantQueueDequeueVer2019();
                        }
                        var tenants = _tenants.Select((k) => new TenantIdDescription(id: k, tenantId: k));
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
                        if (SubGetQueueVer2019 != null && SubGetQueueVer2019.Any())
                        {
                            return GetSubQueueDequeueVer2019();
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
                        if (SubListQueueVer2019 != null && SubListQueueVer2019.Any())
                        {
                            return ListSubQueueDequeueVer2019();
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
                        if (TenantListQueueVer2019 != null && TenantListQueueVer2019.Any())
                        {
                            return ListTenantQueueDequeueVer2019();
                        }
                        var mockPage = new MockPage<TenantIdDescription>(tenants);

                        AzureOperationResponse<IPage<TenantIdDescription>> r = new AzureOperationResponse<IPage<TenantIdDescription>>
                        {
                            Body = mockPage
                        };

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
            if (subscriptionGetList != null)
            {
                subscriptionMock.Setup(
                    s => s.GetWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>())).Returns(
                        (string subId, Dictionary<string, List<string>> ch, CancellationToken token) =>
                        {
                            if (SubGetQueueVer2019 != null && SubGetQueueVer2019.Any())
                            {
                                return GetSubQueueDequeueVer2019();
                            }
                            AzureOperationResponse<Subscription> result = new AzureOperationResponse<Subscription>()
                            {
                                RequestId = Guid.NewGuid().ToString()
                            };
                            if (subscriptionGetList.Any())
                            {
                                result.Body = subscriptionGetList.First();
                                subscriptionGetList.RemoveAt(0);
                            }
                            return Task.FromResult(result);
                        });
            }
            subscriptionMock.Setup(
                (s) => s.ListWithHttpMessagesAsync(null, It.IsAny<CancellationToken>())).Returns(
                    (Dictionary<string, List<string>> ch, CancellationToken token) =>
                    {
                        if (SubListQueueVer2019 != null && SubListQueueVer2019.Any())
                        {
                            return ListSubQueueDequeueVer2019();
                        }

                        AzureOperationResponse<IPage<Subscription>> result = null;
                        if (subscriptionListLists.Any() && HasNextPage.Any())
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

        public SubscriptionClient GetSubscriptionClientVer2019(List<TenantIdDescription> tenants, List<Subscription> subscriptionGetList, List<List<Subscription>> subscriptionListLists, List<bool> HasNextPage = null)
        {
            var client = new Mock<SubscriptionClient>() { CallBase = true };
            if (subscriptionGetList != null || subscriptionListLists != null)
            {
                client.SetupGet(c => c.Subscriptions).Returns(GetSubscriptionMock(subscriptionGetList, subscriptionListLists, HasNextPage));
            }
            if(tenants != null)
            {
                client.SetupGet(c => c.Tenants).Returns(GetTenantMock(tenants));
            }
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
