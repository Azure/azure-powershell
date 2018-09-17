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

using Commands.Security;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.Pricings;
using Microsoft.Azure.Commands.SecurityCenter.Common;
using Microsoft.Rest.Azure;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Security.Cmdlets.Pricings
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSecurityPricing", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSSecurityPricing))]
    public class GetPricings : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.SubscriptionScope:
                    var pricings = SecurityCenterClient.Pricings.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body;
                    WriteObject(pricings.ConvertToPSType(), enumerateCollection: true);
                    break;
                case ParameterSetNames.ResourceGroupScope:
                    pricings = SecurityCenterClient.Pricings.ListByResourceGroupWithHttpMessagesAsync(ResourceGroupName).GetAwaiter().GetResult().Body;
                    WriteObject(pricings.ConvertToPSType(), enumerateCollection: true);
                    break;
                case ParameterSetNames.SubscriptionLevelResource:
                    var pricing = SecurityCenterClient.Pricings.GetSubscriptionPricingWithHttpMessagesAsync(Name).GetAwaiter().GetResult().Body;
                    WriteObject(pricing.ConvertToPSType(), enumerateCollection: false);
                    break;
                case ParameterSetNames.ResourceGroupLevelResource:
                    pricing = SecurityCenterClient.Pricings.GetResourceGroupPricingWithHttpMessagesAsync(ResourceGroupName, Name).GetAwaiter().GetResult().Body;
                    WriteObject(pricing.ConvertToPSType(), enumerateCollection: false);
                    break;
                case ParameterSetNames.ResourceId:
                    var rg = AzureIdUtilities.GetResourceGroup(ResourceId);

                    if (string.IsNullOrEmpty(rg))
                    {
                        pricing = SecurityCenterClient.Pricings.GetSubscriptionPricingWithHttpMessagesAsync(AzureIdUtilities.GetResourceName(ResourceId)).GetAwaiter().GetResult().Body;
                    }
                    else
                    {
                        pricing = SecurityCenterClient.Pricings.GetResourceGroupPricingWithHttpMessagesAsync(rg, AzureIdUtilities.GetResourceName(ResourceId)).GetAwaiter().GetResult().Body;
                    }

                    WriteObject(pricing.ConvertToPSType(), enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
