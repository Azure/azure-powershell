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
// ------------------------------------

using System.Management.Automation;
using Commands.Security;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.Pricings;
using Microsoft.Azure.Commands.SecurityCenter.Common;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Security.Cmdlets.Pricings
{
    [Cmdlet(VerbsCommon.Set, "AzureRmSecurityPricing", DefaultParameterSetName = ParameterSetNames.SubscriptionLevelResource, SupportsShouldProcess = true), OutputType(typeof(PSSecurityPricing))]
    public class SetPricings : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.PricingTier)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.PricingTier)]
        [ValidateNotNullOrEmpty]
        public string PricingTier { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNullOrEmpty]
        public PSSecurityPricing InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            var rg = ResourceGroupName;
            var name = Name;
            var tier = PricingTier;

            switch (ParameterSetName)
            {
                case ParameterSetNames.SubscriptionLevelResource:
                case ParameterSetNames.ResourceGroupLevelResource:
                    break;
                case ParameterSetNames.InputObject:
                    name = InputObject.Name;
                    tier = InputObject.PricingTier;
                    rg = AzureIdUtilities.GetResourceGroup(InputObject.Id);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }

            if (ShouldProcess(name, VerbsCommon.Set))
            {
                Pricing pricing;

                if (string.IsNullOrEmpty(rg))
                {
                    pricing = SecurityCenterClient.Pricings.UpdateSubscriptionPricingWithHttpMessagesAsync(name, tier).GetAwaiter().GetResult().Body;
                }
                else
                {
                    pricing = SecurityCenterClient.Pricings.CreateOrUpdateResourceGroupPricingWithHttpMessagesAsync(rg, name, tier).GetAwaiter().GetResult().Body;
                }

                WriteObject(pricing.ConvertToPSType(), enumerateCollection: false); 
            }
        }
    }
}
