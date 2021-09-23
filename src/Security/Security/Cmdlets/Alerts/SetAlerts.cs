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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.Alerts;
using Microsoft.Azure.Commands.SecurityCenter.Common;
using Microsoft.Azure.Commands.SecurityCenter.Models.Alerts;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Security.Cmdlets.Alerts
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityAlert", DefaultParameterSetName = ParameterSetNames.SubscriptionLevelResource, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class SetAlerts : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.Location)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.Location)]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Security/alerts")]
        public string Location { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, HelpMessage = ParameterHelpMessages.ActionType)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ActionType)]
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ActionType)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = false, HelpMessage = ParameterHelpMessages.ActionType)]
        [ValidateNotNullOrEmpty]
        public string ActionType { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [CmdletParameterBreakingChange("InputObject", OldParamaterType = typeof(PSSecurityAlert), NewParameterTypeName = "PSSecurityAlertV3")]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNullOrEmpty]
        public PSSecurityAlert InputObject { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InputObjectV3, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObjectV3)]
        [ValidateNotNullOrEmpty]
        public PSSecurityAlertV3 InputObjectV3 { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            var rg = ResourceGroupName;
            var name = Name;
            var actionType = ActionType;
            var location = Location;
            var status = "";

            switch (ParameterSetName)
            {
                case ParameterSetNames.SubscriptionLevelResource:
                case ParameterSetNames.ResourceGroupLevelResource:
                    break;
                case ParameterSetNames.ResourceId:
                    location = AzureIdUtilities.GetResourceLocation(ResourceId);
                    name = AzureIdUtilities.GetResourceName(ResourceId);
                    break;
                case ParameterSetNames.InputObject:
                    status = InputObject.State;
                    name = InputObject.Name;
                    rg = AzureIdUtilities.GetResourceGroup(InputObject.Id);
                    location = AzureIdUtilities.GetResourceLocation(InputObject.Id);
                    break;
                case ParameterSetNames.InputObjectV3:
                    status = InputObjectV3.Status;
                    name = InputObjectV3.Name;
                    rg = AzureIdUtilities.GetResourceGroup(InputObjectV3.Id);
                    location = AzureIdUtilities.GetResourceLocation(InputObjectV3.Id);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }

            if (!string.IsNullOrEmpty(status))
            {
                switch (status.ToLower())
                {
                    case "dismissed":
                        actionType = "Dismiss";
                        break;
                    case "active":
                        actionType = "Activate";
                        break;
                    case "resolved":
                        actionType = "Resolve";
                        break;
                    default:
                        break;
                }
            }

            SecurityCenterClient.AscLocation = location;

            if (string.IsNullOrEmpty(rg))
            {
                if (ShouldProcess(name, VerbsCommon.Set))
                {
                    if (actionType == "Dismiss")
                    {
                        SecurityCenterClient.Alerts.UpdateSubscriptionLevelStateToDismissWithHttpMessagesAsync(name).GetAwaiter().GetResult();
                    }
                    else if (actionType == "Activate")
                    {
                        SecurityCenterClient.Alerts.UpdateSubscriptionLevelStateToActivateWithHttpMessagesAsync(name).GetAwaiter().GetResult();
                    }
                    else if (actionType == "Resolve")
                    {
                        SecurityCenterClient.Alerts.UpdateSubscriptionLevelStateToResolveWithHttpMessagesAsync(name).GetAwaiter().GetResult();
                    }
                }
            }
            else
            {
                if (ShouldProcess(name, VerbsCommon.Set))
                {
                    if (actionType == "Dismiss")
                    {
                        SecurityCenterClient.Alerts.UpdateResourceGroupLevelStateToDismissWithHttpMessagesAsync(name, rg).GetAwaiter().GetResult();
                    }
                    else if (actionType == "Activate")
                    {
                        SecurityCenterClient.Alerts.UpdateResourceGroupLevelStateToActivateWithHttpMessagesAsync(name, rg).GetAwaiter().GetResult();
                    }
                    else if (actionType == "Resolve")
                    {
                        SecurityCenterClient.Alerts.UpdateResourceGroupLevelStateToResolveWithHttpMessagesAsync(name, rg).GetAwaiter().GetResult();
                    }
                }
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}