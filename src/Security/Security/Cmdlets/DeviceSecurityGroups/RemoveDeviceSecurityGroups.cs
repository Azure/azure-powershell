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
using Microsoft.Azure.Commands.Security.Models.DeviceSecurityGroups;
using Microsoft.Azure.Commands.SecurityCenter.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Cmdlets.DeviceSecurityGroups
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeviceSecurityGroup", DefaultParameterSetName = ParameterSetNames.ResourceIdLevelResource, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveDeviceSecurityGroup : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string HubResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNullOrEmpty]
        public PSDeviceSecurityGroup InputObject { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.PassThru)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            var name = Name;
            var hubResourceId = HubResourceId;

            switch (ParameterSetName)
            {
                case ParameterSetNames.ResourceIdLevelResource:
                    break;
                case ParameterSetNames.InputObject:
                    name = InputObject.Name;
                    var subscription = AzureIdUtilities.GetResourceSubscription(InputObject.Id);
                    var rg = AzureIdUtilities.GetResourceGroup(InputObject.Id);
                    var hubName = AzureIdUtilities.GetIotHubResourceName(InputObject.Id);
                    hubResourceId = $"/subscriptions/{subscription}/resourceGroups/{rg}/providers/Microsoft.Devices/iotHubs/{hubName}";
                    break;
                case ParameterSetNames.ResourceId:
                    name = AzureIdUtilities.GetResourceName(ResourceId);
                    subscription = AzureIdUtilities.GetResourceSubscription(ResourceId);
                    rg = AzureIdUtilities.GetResourceGroup(ResourceId);
                    hubName = AzureIdUtilities.GetIotHubResourceName(ResourceId);
                    hubResourceId = $"/subscriptions/{subscription}/resourceGroups/{rg}/providers/Microsoft.Devices/iotHubs/{hubName}";
                    break;
                default:
                    throw new PSInvalidOperationException();
            }

            if (ShouldProcess(Name, VerbsCommon.Remove))
            {
                SecurityCenterClient.DeviceSecurityGroups.DeleteWithHttpMessagesAsync(hubResourceId, name).GetAwaiter().GetResult();
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
