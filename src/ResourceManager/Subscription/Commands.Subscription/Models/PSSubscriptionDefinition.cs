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

using ApiSubscriptionDefinition = Microsoft.Azure.Management.Subscription.Models.SubscriptionDefinition;

namespace Microsoft.Azure.Commands.Subscription.Models
{
    public class PSSubscriptionDefinition
    {
        public string Name { get; private set; }

        public string SubscriptionId { get; private set; }
        
        public string SubscriptionDisplayName { get; private set; }

        public string OfferType { get; private set; }
        
        public PSSubscriptionDefinition()
        {
        }

        public PSSubscriptionDefinition(ApiSubscriptionDefinition subscriptionDefinition)
        {
            if (subscriptionDefinition != null)
            {
                this.Name = subscriptionDefinition.Name;
                this.SubscriptionId = subscriptionDefinition.SubscriptionId;
                this.SubscriptionDisplayName = subscriptionDefinition.SubscriptionDisplayName;
                this.OfferType = subscriptionDefinition.OfferType;
            }
        }
    }
}
