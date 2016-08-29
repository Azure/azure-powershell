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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Subscriptions;
using Microsoft.Azure.Subscriptions.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Resources.Models
{
    public class SubscriptionsClient
    {
        public ISubscriptionClient SubscriptionClient { get; set; }

        /// <summary>
        /// Creates new SubscriptionsClient
        /// </summary>
        /// <param name="context">Profile containing resources to manipulate</param>
        public SubscriptionsClient(AzureContext context)
            : this(AzureSession.ClientFactory.CreateClient<SubscriptionClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {

        }

        /// <summary>
        /// Creates new SubscriptionsClient instance
        /// </summary>
        /// <param name="subscriptionClient">The subscription client instance</param>
        public SubscriptionsClient(ISubscriptionClient subscriptionClient)
        {
            this.SubscriptionClient = subscriptionClient;
        }

        public List<Location> ListLocations(string subscriptionId)
        {
            var locationList = new List<Location>();

            var tempResult = this.SubscriptionClient.Subscriptions.ListLocations(subscriptionId);
            locationList.AddRange(tempResult.Locations);

            return locationList;
        }
    }
}
