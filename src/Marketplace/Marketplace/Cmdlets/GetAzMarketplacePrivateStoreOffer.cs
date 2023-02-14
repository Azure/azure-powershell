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

namespace Microsoft.Azure.Commands.Marketplace.Cmdlets
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Marketplace.Models;
    using Microsoft.Azure.Commands.Marketplace.Models.PrivateStore;
    using Microsoft.Azure.Commands.Marketplace.Utilities;
    using Microsoft.Azure.Management.Marketplace;

    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "MarketplacePrivateStoreOffer"), OutputType(typeof(PSPrivateStoreOffer))]
    public class GetAzMarketplacePrivateStoreOffer : ResourceMarketplaceBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Required Azure Marketplace privateStore offers")]
        [ValidateNotNullOrEmpty]
        public string PrivateStoreId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Required Azure Marketplace privateStore offer")]
        [ValidateNotNullOrEmpty]
        public string OfferId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure subscription id")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        public override void ExecuteCmdlet()
        {
            var isSubscriptionScope = !string.IsNullOrEmpty(SubscriptionId);

            if (!string.IsNullOrEmpty(OfferId))
            {
                var privateStoresOffer = isSubscriptionScope ? ResourceMarketplaceClient.PrivateStorePrivateOffer.Get(SubscriptionId, PrivateStoreId, OfferId) :
                                                               ResourceMarketplaceClient.PrivateStoreOffer.Get(PrivateStoreId, OfferId);
                if (privateStoresOffer == null)
                {
                    WriteObject(new PSPrivateStoreOffer());
                    return;
                }
                WriteObject(privateStoresOffer.ToPSPrivateStoreOffer());
                return;
            }

            var privateStoresOffers = isSubscriptionScope ? ResourceMarketplaceClient.PrivateStorePrivateOffers.List(SubscriptionId, PrivateStoreId) :
                                                            ResourceMarketplaceClient.PrivateStoreOffers.List(PrivateStoreId);

            if (privateStoresOffers == null || !privateStoresOffers.Any())
            {
                WriteObject(new List<PSPrivateStoreOffer>(), true);
                return;
            }

            var psPrivateStoresOffers = privateStoresOffers.Select(ps => ps.ToPSPrivateStoreOffer()).ToList();
            WriteObject(psPrivateStoresOffers, true);
        }
    }
}
