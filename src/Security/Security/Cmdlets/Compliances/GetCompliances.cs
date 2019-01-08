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

using System.Linq;
using System.Management.Automation;
using Commands.Security;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.Compliances;
using Microsoft.Azure.Commands.SecurityCenter.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Security.Cmdlets.Compliances
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityCompliance", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSSecurityCompliance))]
    public class GetCompliances : SecurityCenterCmdletBase
    {
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
                    var apsl = SecurityCenterClient.Compliances.ListWithHttpMessagesAsync(GetScope()).GetAwaiter().GetResult().Body;
                    WriteObject(apsl.ConvertToPSType(), enumerateCollection: true);
                    break;
                case ParameterSetNames.SubscriptionLevelResource:
                    SecurityCenterClient.AscLocation = SecurityCenterClient.Locations.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body.First().Name;

                    var aps = SecurityCenterClient.Compliances.GetWithHttpMessagesAsync(GetScope(), Name).GetAwaiter().GetResult().Body;
                    WriteObject(aps.ConvertToPSType(), enumerateCollection: false);
                    break;
                case ParameterSetNames.ResourceId:
                    SecurityCenterClient.AscLocation = AzureIdUtilities.GetResourceLocation(ResourceId);

                    aps = SecurityCenterClient.Compliances.GetWithHttpMessagesAsync(GetScope(AzureIdUtilities.GetResourceSubscription(ResourceId)), AzureIdUtilities.GetResourceName(ResourceId)).GetAwaiter().GetResult().Body;
                    WriteObject(aps.ConvertToPSType(), enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }

        private string GetScope(string subscriptionId = null)
        {
            if (subscriptionId == null)
                subscriptionId = DefaultContext.Subscription.Id;

            return $"subscriptions/{subscriptionId}";
        }
    }
}
