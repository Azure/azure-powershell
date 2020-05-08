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
using Microsoft.Azure.Management.Security.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Cmdlets.DeviceSecurityGroups
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeviceSecurityGroup", DefaultParameterSetName = ParameterSetNames.ResourceIdLevelResource, SupportsShouldProcess = true), OutputType(typeof(PSDeviceSecurityGroup))]
    public class SetDeviceSecurityGroup : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.HubResourceId)]
        [ValidateNotNullOrEmpty]
        public string HubResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.ThresholdRules)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.ThresholdRules)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.ThresholdRules)]
        public PSThresholdCustomAlertRule[] ThresholdRule { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.TimeWindowRules)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.TimeWindowRules)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.TimeWindowRules)]
        public PSTimeWindowCustomAlertRule[] TimeWindowRule { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.AllowlistRules)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.AllowlistRules)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.AllowlistRules)]
        public PSAllowlistCustomAlertRule[] AllowlistRule { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.DenylistRules)]
        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.DenylistRules)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = false, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.DenylistRules)]
        public PSDenylistCustomAlertRule[] DenylistRule { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.InputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNullOrEmpty]
        public PSDeviceSecurityGroup InputObject { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSetNames.ResourceIdLevelResource:
                    break;
                case ParameterSetNames.InputObject:
                    Name = InputObject.Name;
                    var subscription = AzureIdUtilities.GetResourceSubscription(InputObject.Id);
                    var rg = AzureIdUtilities.GetResourceGroup(InputObject.Id);
                    var hubName = AzureIdUtilities.GetIotHubResourceName(InputObject.Id);
                    HubResourceId = $"/subscriptions/{subscription}/resourceGroups/{rg}/providers/Microsoft.Devices/iotHubs/{hubName}";

                    AllowlistRule = AllowlistRule ?? ((List<PSAllowlistCustomAlertRule>)InputObject.AllowlistRules).ToArray();
                    DenylistRule = DenylistRule ?? ((List<PSDenylistCustomAlertRule>)InputObject.DenylistRules).ToArray();
                    ThresholdRule = ThresholdRule ?? ((List<PSThresholdCustomAlertRule>)InputObject.ThresholdRules).ToArray();
                    TimeWindowRule = TimeWindowRule ?? ((List<PSTimeWindowCustomAlertRule>)InputObject.TimeWindowRules).ToArray();
                    break;
                case ParameterSetNames.ResourceId:
                    Name = AzureIdUtilities.GetResourceName(ResourceId);
                    subscription = AzureIdUtilities.GetResourceSubscription(ResourceId);
                    rg = AzureIdUtilities.GetResourceGroup(ResourceId);
                    hubName = AzureIdUtilities.GetIotHubResourceName(ResourceId);
                    HubResourceId = $"/subscriptions/{subscription}/resourceGroups/{rg}/providers/Microsoft.Devices/iotHubs/{hubName}";
                    break;
                default:
                    throw new PSInvalidOperationException();
            }

            DeviceSecurityGroup group = new DeviceSecurityGroup
            {
                AllowlistRules = AllowlistRule?.CreatePSType(),
                DenylistRules = DenylistRule?.CreatePSType(),
                ThresholdRules = ThresholdRule?.CreatePSType(),
                TimeWindowRules = TimeWindowRule?.CreatePSType()
            };

            if (ShouldProcess(Name, VerbsCommon.Set))
            {
                var outputGroup = SecurityCenterClient.DeviceSecurityGroups.CreateOrUpdateWithHttpMessagesAsync(HubResourceId, Name, group).GetAwaiter().GetResult().Body;

                WriteObject(outputGroup?.ConvertToPSType(), enumerateCollection: false);
            }
        }
    }
}

