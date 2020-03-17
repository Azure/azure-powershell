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
using Microsoft.Azure.Management.Security.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Cmdlets.DeviceSecurityGroups
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeviceSecurityGroups", DefaultParameterSetName = ParameterSetNames.ResourceIdLevelResource), OutputType(typeof(PSDeviceSecurityGroup))]
    public class SetDeviceSecurityGroups : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.HubResourceId)]
        [ValidateNotNullOrEmpty]
        public string HubResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.ThresholdRules)]
        public List<PSThresholdCustomAlertRule> ThresholdRules { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.TimeWindowRules)]
        public List<PSTimeWindowCustomAlertRule> TimeWindowRules { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.AllowlistRules)]
        public List<PSAllowlistCustomAlertRule> AllowlistRules { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = false, HelpMessage = ParameterHelpMessages.DenylistRules)]
        public List<PSDenylistCustomAlertRule> DenylistRules { get; set; }

        public override void ExecuteCmdlet()
        {
            DeviceSecurityGroup group = new DeviceSecurityGroup();
            group.AllowlistRules = AllowlistRules?.CreatePSType();
            group.DenylistRules = DenylistRules?.CreatePSType();
            group.ThresholdRules = ThresholdRules?.CreatePSType();
            group.TimeWindowRules = TimeWindowRules?.CreatePSType();

            if (ShouldProcess(Name, VerbsCommon.Set))
            {
                var outputGroup = SecurityCenterClient.DeviceSecurityGroups.CreateOrUpdateWithHttpMessagesAsync(HubResourceId, Name, group).GetAwaiter().GetResult().Body;

                WriteObject(outputGroup.ConvertToPSType(), enumerateCollection: false);
            }
        }
    }
}

