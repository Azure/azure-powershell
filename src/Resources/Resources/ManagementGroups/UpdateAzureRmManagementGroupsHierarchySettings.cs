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
// ----------------------------------------------------------------------------------

using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.ManagementGroups.Common;
using Microsoft.Azure.Commands.Resources.Models.ManagementGroups;
using Microsoft.Azure.Management.ManagementGroups;
using Microsoft.Azure.Management.ManagementGroups.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Resources.ManagementGroups
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagementGroupHierarchySetting", DefaultParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSHierarchySettings))]
    public class UpdateAzureRmManagementGroupsHierarchySettings : AzureManagementGroupsCmdletBase
    {
        [Alias("GroupId")]
        [CmdletParameterBreakingChange("GroupName", ReplaceMentCmdletParameterName = "GroupId", ChangeDescription = "We will replace GroupName with GroupId to make it more clear.")]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = true, HelpMessage = Constants.HelpMessages.GroupName, Position = 0)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.ParentGroupParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.ParentObject)]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        [Alias("RequireAuthorizationForGroupCreation")]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.DisplayName)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.ParentGroupParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.DisplayName, ValueFromPipeline = false)]
        [ValidateNotNullOrEmpty]
        public bool Authorization { get; set; } = false;

        [Alias("DefaultMG")]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.ParentId)]
        [ValidateNotNullOrEmpty]
        public string DefaultManagementGroup { get; set; } = null;


        public override void ExecuteCmdlet()
        {
            try
            {
                if (ShouldProcess(
                       string.Format(Resource.NewManagementGroupShouldProcessTarget, GroupName),
                       string.Format(Resource.NewManagementGroupShouldProcessAction, GroupName)))
                {
                    PreregisterSubscription();

                    var response = ManagementGroupsApiClient.HierarchySettings.Update(GroupName, new CreateOrUpdateSettingsRequest(Authorization, DefaultManagementGroup));

                    WriteObject(new PSHierarchySettings(response));
                }
            }
            catch (ErrorResponseException ex)
            {
                Utility.HandleErrorResponseException(ex);
            }
        }
    }
}
