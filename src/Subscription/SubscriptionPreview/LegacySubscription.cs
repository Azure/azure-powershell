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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Subscription;
using Microsoft.Azure.Management.Subscription.Models;
using System.Linq;

namespace SubscriptionPreview
{
    public class LegacySubscription
    {
        private ISubscriptionClient _subscriptionClient;

        public AzureSubscription createSubscription(IAzureContext DefaultContext, string enrollmentAccountObjectId, string name, string offerType, string[] ownerList)
        {
            _subscriptionClient =
                Microsoft.Azure.Commands.Common.Authentication.AzureSession.Instance.ClientFactory
                    .CreateArmClient<SubscriptionClient>(DefaultContext, AzureEnvironment.Endpoint.ResourceManager);

            SubscriptionCreationResult result = new SubscriptionCreationResult();

            var owners = ownerList.Select(id => new AdPrincipal() { ObjectId = id }).ToArray();

            result = _subscriptionClient.Subscription.CreateSubscriptionInEnrollmentAccount(
                enrollmentAccountObjectId,new SubscriptionCreationParameters()
                {
                    DisplayName = name,
                    OfferType = offerType,
                    Owners = owners
                });

            var createdSubscription = new AzureSubscription()
            {
                // SubscriptionLink format is: "/subscriptions/{subscriptionid}"
                Id = result.SubscriptionLink.Split('/')[2],
                Name = name,
                // By definition, a new subscription is always in the enabled state.
                State = "Enabled",
            };

            return createdSubscription;
        }
    }
}
