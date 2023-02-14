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
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Marketplace.Utilities;
    using Microsoft.Azure.Management.Marketplace;

    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "MarketplacePrivateStoreOffer", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzMarketplacePrivateStoreOffer : ResourceMarketplaceBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Required Azure Marketplace privateStore")]
        [ValidateNotNullOrEmpty]
        public string PrivateStoreId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Required Azure Marketplace privateStore offer")]
        [ValidateNotNullOrEmpty]
        public string OfferId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {

            if (ShouldProcess(OfferId, $"Deleting offer {OfferId} under private store {PrivateStoreId}"))
            {
                ResourceMarketplaceClient.PrivateStoreOffer.Delete(PrivateStoreId, OfferId);
            }
            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}
