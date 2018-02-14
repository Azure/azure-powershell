﻿// ----------------------------------------------------------------------------------
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
// ----------------------------------------------------------------------------------

using System.Management.Automation;
using Microsoft.Azure.Commands.ManagementGroups.Common;
using Microsoft.Azure.Commands.ManagementGroups.Models;
using Microsoft.Azure.Management.ManagementGroups;
using Microsoft.Azure.Management.ManagementGroups.Models;

namespace Microsoft.Azure.Commands.ManagementGroups.Cmdlets
{
    [Cmdlet("Update", "AzureRmManagementGroup", DefaultParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSManagementGroupNoChildren))]
    public class UpdateAzureRmManagementGroup : AzureManagementGroupsCmdletBase
    {
        [Parameter(ParameterSetName = Constants.ParameterSetNames.ManagementGroupParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.InputObject, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSManagementGroup ManagementGroup { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.ManagementGroupNoChildrenParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.InputObject, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSManagementGroupNoChildren ManagementGroupNoChildren { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = true, HelpMessage = Constants.HelpMessages.GroupName, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.ManagementGroupParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.DisplayName)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.ManagementGroupNoChildrenParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.DisplayName)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.DisplayName)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; } = null;

        [Parameter(ParameterSetName = Constants.ParameterSetNames.ManagementGroupParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.ParentId)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.ManagementGroupNoChildrenParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.ParentId)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.ParentId)]
        [ValidateNotNullOrEmpty]
        public string ParentId { get; set; } = null;

        public override void ExecuteCmdlet()
        {
            try
            {
                if (ParameterSetName.Equals(Constants.ParameterSetNames.ManagementGroupParameterSet))
                {
                    GroupName = ManagementGroup.Name;
                }
                else if (ParameterSetName.Equals(Constants.ParameterSetNames.ManagementGroupNoChildrenParameterSet))
                {
                    GroupName = ManagementGroupNoChildren.Name;
                }

                if (ShouldProcess(
                        string.Format(Resource.UpdateManagementGroupShouldProcessTarget, GroupName),
                        string.Format(Resource.UpdateManagementGroupShouldProcessAction, GroupName)))
                {
                    CreateManagementGroupRequest createGroupRequest = new CreateManagementGroupRequest(DisplayName, ParentId);
                    var response = ManagementGroupsApiClient.ManagementGroups.Update(GroupName, createGroupRequest);
                    WriteObject(new PSManagementGroupNoChildren(response));

                }
            }
            catch (ErrorResponseException ex)
            {
                Utility.HandleErrorResponseException(ex);
            }
        }
    }
}
