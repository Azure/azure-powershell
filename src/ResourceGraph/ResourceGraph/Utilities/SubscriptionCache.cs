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

namespace Microsoft.Azure.Commands.ResourceGraph.Utilities
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Internal.Subscriptions.Version2018_06_01;

    /// <summary>
    /// Subscriptions cache
    /// </summary>
    public static class SubscriptionCache
    {
        /// <summary>
        /// The synchronize root
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// The subscriptions
        /// </summary>
        private static List<string> _subscriptions;

        /// <summary>
        /// Gets the subscriptions.
        /// </summary>
        /// <param name="azureContext">The azure context.</param>
        /// <returns></returns>
        public static List<string> GetSubscriptions(IAzureContext azureContext)
        {
            if (_subscriptions == null)
            {
                lock (SyncRoot)
                {
                    if (_subscriptions == null)
                    {
                        var subscriptionsClient =
                            AzureSession.Instance.ClientFactory.CreateArmClient<SubscriptionClient>(
                                azureContext, AzureEnvironment.Endpoint.ResourceManager);
                        
                        var subscriptionList = new List<string>();
                        var page = subscriptionsClient.Subscriptions.List();
                        subscriptionList.AddRange(page.ToList().Select(s => s.SubscriptionId));
                        while (!string.IsNullOrEmpty(page.NextPageLink))
                        {
                            page = subscriptionsClient.Subscriptions.ListNext(page.NextPageLink);
                            subscriptionList.AddRange(page.ToList().Select(s => s.SubscriptionId));
                        }

                        _subscriptions = subscriptionList;
                    }
                }
            }

            return _subscriptions;
        }
    }
}
