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
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient
{
    public class SubscriptionSdkClient
    {
        public ISubscriptionClient SubscriptionClient { get; set; }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        /// <summary>
        /// Creates new SubscriptionsClient
        /// </summary>
        /// <param name="context">Profile containing resources to manipulate</param>
        public SubscriptionSdkClient(AzureContext context)
            : this(
                AzureSession.ClientFactory.CreateArmClient<SubscriptionClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {

        }

        /// <summary>
        /// Creates new SubscriptionsClient instance
        /// </summary>
        /// <param name="subscriptionClient">The subscription client instance</param>
        public SubscriptionSdkClient(ISubscriptionClient subscriptionClient)
        {
            this.SubscriptionClient = subscriptionClient;
        }

        public List<Location> ListLocations(string subscriptionId)
        {
            var locationList = new List<Location>();

            var tempResult = this.SubscriptionClient.Subscriptions.ListLocations(subscriptionId);
            locationList.AddRange(tempResult);

            return locationList;
        }
    }
}
