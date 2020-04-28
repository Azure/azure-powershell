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
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Cmdlets.DeviceSecurityGroups
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeviceSecurityGroup", DefaultParameterSetName = ParameterSetNames.ResourceIdScope), OutputType(typeof(PSDeviceSecurityGroup))]
    public class GetDeviceSecurityGroup : SecurityCenterCmdletBase
    {
        private const int MaxGroupsToFetch = 1500;

        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdScope, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string HubResourceId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceIdLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            int numberOfFetchedGroups = 0;
            string nextLink = null;

            switch (ParameterSetName)
            {
                case ParameterSetNames.ResourceIdScope:
                    var groups = SecurityCenterClient.DeviceSecurityGroups.ListWithHttpMessagesAsync(HubResourceId).GetAwaiter().GetResult().Body;
                    var PSTypeGroups = groups?.ConvertToPSType();
                    WriteObject(PSTypeGroups, enumerateCollection: true);
                    numberOfFetchedGroups += PSTypeGroups.Count;
                    nextLink = groups?.NextPageLink;
                    while (!string.IsNullOrWhiteSpace(nextLink) && numberOfFetchedGroups < MaxGroupsToFetch)
                    {
                        groups = SecurityCenterClient.DeviceSecurityGroups.ListNextWithHttpMessagesAsync(groups.NextPageLink).GetAwaiter().GetResult().Body;
                        PSTypeGroups = groups?.ConvertToPSType();
                        WriteObject(PSTypeGroups, enumerateCollection: true);
                        numberOfFetchedGroups += PSTypeGroups.Count;
                        nextLink = groups?.NextPageLink;
                    }
                    break;
                case ParameterSetNames.ResourceIdLevelResource:
                    var group = SecurityCenterClient.DeviceSecurityGroups.GetWithHttpMessagesAsync(HubResourceId, Name).GetAwaiter().GetResult().Body;
                    WriteObject(group?.ConvertToPSType(), enumerateCollection: false);
                    break;
                default:
                    throw new PSInvalidOperationException();
            }
        }
    }
}

