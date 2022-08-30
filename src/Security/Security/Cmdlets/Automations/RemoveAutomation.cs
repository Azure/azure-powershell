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
using Microsoft.Azure.Commands.Security.Models.Automations;
using Microsoft.Azure.Commands.SecurityCenter.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Security.Cmdlets.Automations
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityAutomation", DefaultParameterSetName = ParameterSetNames.ResourceGroupLevelResource, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAutomation : SecurityCenterCmdletBase
    {
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

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNull]
        public PSSecurityAutomation InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            var resourceGroupName = "";
            var name = "";

            switch (ParameterSetName)
            {
                case ParameterSetNames.ResourceGroupLevelResource:
                    resourceGroupName = ResourceGroupName;
                    name = Name;
                    break;
                case ParameterSetNames.ResourceId:
                    name = AzureIdUtilities.GetResourceName(ResourceId);
                    resourceGroupName = AzureIdUtilities.GetResourceGroup(ResourceId);
                    break;
                case ParameterSetNames.InputObject:
                    name = InputObject.Name;
                    resourceGroupName = AzureIdUtilities.GetResourceGroup(InputObject.Id);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }

            if (ShouldProcess(name, VerbsCommon.Remove))
            {
                SecurityCenterClient.Automations.DeleteWithHttpMessagesAsync(resourceGroupName, name).GetAwaiter().GetResult();
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
