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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.Automations;
using Microsoft.Azure.Commands.SecurityCenter.Common;

namespace Microsoft.Azure.Commands.Security.Cmdlets.Automations
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityAutomation", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSSecurityAutomation))]
    public class GetAutomation : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupScope, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Security/automations", nameof(ResourceGroupName))]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            string nextLink = null;
            switch (ParameterSetName)
            {
                case ParameterSetNames.SubscriptionScope:
                    var automations = SecurityCenterClient.Automations.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body;
                    var PSTypeAutomations = automations.ConvertToPSType();
                    WriteObject(PSTypeAutomations, enumerateCollection: true);
                    nextLink = automations?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink))
                    {
                        automations = SecurityCenterClient.Automations.ListNextWithHttpMessagesAsync(nextLink).GetAwaiter().GetResult().Body;
                        PSTypeAutomations = automations.ConvertToPSType();
                        WriteObject(PSTypeAutomations, enumerateCollection: true);
                        nextLink = automations?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.ResourceGroupScope:
                    automations = SecurityCenterClient.Automations.ListByResourceGroupWithHttpMessagesAsync(ResourceGroupName).GetAwaiter().GetResult().Body;
                    PSTypeAutomations = automations.ConvertToPSType();
                    WriteObject(PSTypeAutomations, enumerateCollection: true);
                    nextLink = automations?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink))
                    {
                        automations = SecurityCenterClient.Automations.ListByResourceGroupNextWithHttpMessagesAsync(nextLink).GetAwaiter().GetResult().Body;
                        PSTypeAutomations = automations.ConvertToPSType();
                        WriteObject(PSTypeAutomations, enumerateCollection: true);
                        nextLink = automations?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.ResourceGroupLevelResource:
                    var automation = SecurityCenterClient.Automations.GetWithHttpMessagesAsync(ResourceGroupName, Name).GetAwaiter().GetResult().Body;
                    var PSTypeAutomation = automation.ConvertToPSType();
                    WriteObject(PSTypeAutomation, enumerateCollection: false);
                    break;
                case ParameterSetNames.ResourceId:
                    automation = SecurityCenterClient.Automations.GetWithHttpMessagesAsync(AzureIdUtilities.GetResourceGroup(ResourceId), AzureIdUtilities.GetResourceName(ResourceId)).GetAwaiter().GetResult().Body;
                    PSTypeAutomation = automation.ConvertToPSType();
                    WriteObject(PSTypeAutomation, enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}
