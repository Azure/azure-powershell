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
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Marketplace.Models;
    using Microsoft.Azure.Commands.Marketplace.Models.PrivateStore;
    using Microsoft.Azure.Commands.Marketplace.Utilities;
    using Microsoft.Azure.Management.Marketplace;
    using Microsoft.Azure.Management.Marketplace.Models;

    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "MarketplacePrivateStoreOffer", SupportsShouldProcess = true), OutputType(typeof(PSPrivateStoreOffer))]
    public class SetAzMarketplacePrivateStoreOffer : ResourceMarketplaceBaseCmdlet
    {

        [Parameter(Mandatory = true, HelpMessage = "Required Azure Marketplace privateStore offers")]
        [ValidateNotNullOrEmpty]
        public string PrivateStoreId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Required Azure Marketplace privateStore offer")]
        [ValidateNotNullOrEmpty]
        public string OfferId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Required Azure Marketplace privateStore offer's specific plan ids limitation")]
        [ValidateNotNullOrEmpty]
        public List<string> SpecificPlanIdsLimitation { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure Marketplace privateStore offer's eTag for update")]
        [ValidateNotNullOrEmpty]
        public string ETag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Azure subscription id")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        public override void ExecuteCmdlet()
        {
            var isSubscriptionScope = !string.IsNullOrEmpty(SubscriptionId);

            var offerToUpdate = new Offer
            {
                SpecificPlanIdsLimitation = this.SpecificPlanIdsLimitation
            };

            if (!string.IsNullOrEmpty(this.ETag))
            {
                offerToUpdate.ETag = this.ETag;
            }

            if (ShouldProcess(OfferId, $"Adding offer {OfferId} under private store {PrivateStoreId}"))
            {
                var updatedOffer = isSubscriptionScope ? ResourceMarketplaceClient.PrivateStorePrivateOffer.CreateOrUpdate(SubscriptionId, PrivateStoreId, OfferId, offerToUpdate.ETag, offerToUpdate.SpecificPlanIdsLimitation) : 
                                                         ResourceMarketplaceClient.PrivateStoreOffer.CreateOrUpdate(PrivateStoreId, OfferId, offerToUpdate.ETag, offerToUpdate.SpecificPlanIdsLimitation);

                WriteObject(updatedOffer.ToPSPrivateStoreOffer());
            }

        }
    }
}
