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
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Test
{
    public partial class MockSubscriptionClientFactory
    {
        private IList<string> _tenants;
        private Queue<List<string>> _subscriptions;
        private HashSet<string> _subscriptionSet;

        public delegate Task<AzureOperationResponse<T>> DeGetAsyncQueue<T>();
        public delegate Task<AzureOperationResponse<IPage<T>>> DeListAsyncQueue<T>();

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

        public MockSubscriptionClientFactory()
        {
        }

        public static void Reset()
        {
            _getAsyncQueueVer2016?.Clear();
            _listAsyncQueueVer2016?.Clear();
            SubGetQueueVerLatest?.Clear();
            SubListQueueVerLatest?.Clear();
            TenantListQueueVerLatest?.Clear();

        }

        public static string GetTenantDomainFromId(string id)
        {
            return id.Substring(3)+".com";
        }

        public static string GetSubscriptionNameFromId(string id)
        {
            if(id == "a11a11aa-aaaa-aaaa-aaaa-aaaa1111aaaa" || id == "aaaa11aa-aaaa-aaaa-aaaa-aaaa1111aaaa")
            {
                return "SameNameForGetSubscriptionByName";
            }
            return "Sub-" + id;
        }

        internal class MockPage<T> : IPage<T>
        {
            public MockPage(IList<T> Items)
            {
                this.Items = Items;
            }

            public MockPage(IList<T> Items, string NextPageLink)
            {
                this.Items = Items;
                this.NextPageLink = NextPageLink;
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
