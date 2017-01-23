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

using Microsoft.Azure.Internal.Subscriptions;
using Microsoft.Azure.Internal.Subscriptions.Models;
using Microsoft.Rest.Azure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Test
{
    public class MockSubscriptionClientFactory
    {
        private IList<string> _tenants;
        private Queue<List<string>> _subscriptions;
        private HashSet<string> _subscriptionSet;
        private static Queue<Func<AzureOperationResponse<Subscription>>> _getAsyncQueue;
        private static Queue<Func<AzureOperationResponse<IPage<Subscription>>>> _listAsyncQueue;

        public MockSubscriptionClientFactory(List<string> tenants, Queue<List<string>> subscriptions)
        {
            _tenants = tenants;
            _subscriptions = new Queue<List<string>>();
            _subscriptionSet = new HashSet<string>();
            foreach (var subscriptionList in subscriptions)
            {
                _subscriptions.Enqueue(subscriptionList);
                foreach (var subscription in subscriptionList)
                {
                    _subscriptionSet.Add(subscription);
                }
            }
        }

        public static string GetSubscriptionNameFromId(string id)
        {
            return "Sub-" + id;
        }

        public static void SetGetAsyncResponses(Queue<Func<AzureOperationResponse<Subscription>>> responses)
        {
            _getAsyncQueue = responses;
        }
        public static void SetListAsyncResponses(Queue<Func<AzureOperationResponse<IPage<Subscription>>>> responses)
        {
            _listAsyncQueue = responses;
        }

        public SubscriptionClient GetSubscriptionClient()
        {
            var tenantMock = new Mock<ITenantsOperations>();
            tenantMock.Setup(t => t.ListWithHttpMessagesAsync(null, It.IsAny<CancellationToken>()))
                .Returns(
                    (Dictionary<string, List<string>> ch, CancellationToken token) =>
                        {
                            var tenants = _tenants.Select((k) => new TenantIdDescription(id: k, tenantId: k));
                            IPage<TenantIdDescription> page = new Page<TenantIdDescription>();
                            page.Concat(tenants);

                            AzureOperationResponse<IPage<TenantIdDescription>> r = new AzureOperationResponse<IPage<TenantIdDescription>>
                            {
                                Body = page
                            };

                            return Task.FromResult(r);
                        }
                );
            var subscriptionMock = new Mock<ISubscriptionsOperations>();
            subscriptionMock.Setup(
                s => s.GetWithHttpMessagesAsync(It.IsAny<string>(), null, It.IsAny<CancellationToken>())).Returns(
                    (string subId, Dictionary<string, List<string>> ch, CancellationToken token) =>
                    {
                        if (_getAsyncQueue != null && _getAsyncQueue.Any())
                        {
                            return Task.FromResult(_getAsyncQueue.Dequeue().Invoke());
                        }
                        AzureOperationResponse<Subscription> result = new AzureOperationResponse<Subscription>
                        {
                            RequestId = Guid.NewGuid().ToString(),
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
                        if (_listAsyncQueue != null && _listAsyncQueue.Any())
                        {
                            return Task.FromResult(_listAsyncQueue.Dequeue().Invoke());
                        }

                        AzureOperationResponse<IPage<Subscription>> result = null;
                        if (_subscriptions.Count > 0)
                        {
                            var subscriptionList = _subscriptions.Dequeue();
                            result = new AzureOperationResponse<IPage<Subscription>>
                            {
                                RequestId = Guid.NewGuid().ToString(),
                                Body = (IPage<Subscription>)
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
                                                    authorizationSource: null)))
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
                                Body = (IPage<Subscription>)
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
                                                authorizationSource: null)))
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

}
