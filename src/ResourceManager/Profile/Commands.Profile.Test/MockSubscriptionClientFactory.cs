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

using Microsoft.Azure.Subscriptions;
using Microsoft.Azure.Subscriptions.Models;
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
        private static Queue<Func<GetSubscriptionResult>> _getAsyncQueue;
        private static Queue<Func<SubscriptionListResult>> _listAsyncQueue;

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

        public static void SetGetAsyncResponses(Queue<Func<GetSubscriptionResult>> responses)
        {
            _getAsyncQueue = responses;
        }
        public static void SetListAsyncResponses(Queue<Func<SubscriptionListResult>> responses)
        {
            _listAsyncQueue = responses;
        }

        public SubscriptionClient GetSubscriptionClient()
        {
            var tenantMock = new Mock<ITenantOperations>();
            tenantMock.Setup(t => t.ListAsync(It.IsAny<CancellationToken>()))
                .Returns(
                    (CancellationToken token) =>
                        Task.FromResult(new TenantListResult()
                        {
                            StatusCode = HttpStatusCode.OK,
                            RequestId = Guid.NewGuid().ToString(),
                            TenantIds = _tenants.Select((k) => new TenantIdDescription() { Id = k, TenantId = k }).ToList()
                        }));
            var subscriptionMock = new Mock<ISubscriptionOperations>();
            subscriptionMock.Setup(
                s => s.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).Returns(
                    (string subId, CancellationToken token) =>
                    {
                        if (_getAsyncQueue != null && _getAsyncQueue.Any())
                        {
                            return Task.FromResult(_getAsyncQueue.Dequeue().Invoke());
                        }
                        GetSubscriptionResult result = new GetSubscriptionResult
                        {
                            RequestId = Guid.NewGuid().ToString(),
                            StatusCode = HttpStatusCode.NotFound
                        };
                        if (_subscriptionSet.Contains(subId))
                        {
                            result.StatusCode = HttpStatusCode.OK;
                            result.Subscription =
                                new Subscription
                                {
                                    DisplayName = GetSubscriptionNameFromId(subId),
                                    Id = subId,
                                    State = "Active",
                                    SubscriptionId = subId
                                };

                        }

                        return Task.FromResult(result);
                    });
            subscriptionMock.Setup(
                (s) => s.ListAsync(It.IsAny<CancellationToken>())).Returns(
                    (CancellationToken token) =>
                    {
                        if (_listAsyncQueue != null && _listAsyncQueue.Any())
                        {
                            return Task.FromResult(_listAsyncQueue.Dequeue().Invoke());
                        }

                        SubscriptionListResult result = null;
                        if (_subscriptions.Count > 0)
                        {
                            var subscriptionList = _subscriptions.Dequeue();
                            result = new SubscriptionListResult
                            {
                                StatusCode = HttpStatusCode.OK,
                                RequestId = Guid.NewGuid().ToString(),
                                NextLink = "LinkToNextPage",
                                Subscriptions =
                                    new List<Subscription>(
                                        subscriptionList.Select(
                                            sub =>
                                                new Subscription
                                                {
                                                    DisplayName = GetSubscriptionNameFromId(sub),
                                                    Id = sub,
                                                    State = "enabled",
                                                    SubscriptionId = sub
                                                }))
                            };
                        }

                        return Task.FromResult(result);
                    });
            subscriptionMock.Setup(
                (s) => s.ListNextAsync("LinkToNextPage", It.IsAny<CancellationToken>())).Returns(
                    (string nextLink, CancellationToken token) =>
                    {
                        SubscriptionListResult result = null;
                        if (_subscriptions.Count > 0)
                        {
                            var subscriptionList = _subscriptions.Dequeue();
                            result = new SubscriptionListResult
                            {
                                StatusCode = HttpStatusCode.OK,
                                RequestId = Guid.NewGuid().ToString(),
                                Subscriptions =
                                    new List<Subscription>(
                                        subscriptionList.Select(
                                            sub =>
                                                new Subscription
                                                {
                                                    DisplayName = nextLink,
                                                    Id = sub,
                                                    State = "Disabled",
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

}
