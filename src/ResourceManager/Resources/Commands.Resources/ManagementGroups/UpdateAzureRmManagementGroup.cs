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

namespace Microsoft.Azure.Commands.Resources.ManagementGroups
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagementGroup", DefaultParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSManagementGroup))]
    public class UpdateAzureRmManagementGroup : AzureManagementGroupsCmdletBase
    {
        [Parameter(ParameterSetName = Constants.ParameterSetNames.ParentGroupAndManagementGroupParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.InputObject, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.ManagementGroupParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.InputObject, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSManagementGroup InputObject { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.ParentGroupParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.InputObject, ValueFromPipeline = false)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = true, HelpMessage = Constants.HelpMessages.GroupName, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.ManagementGroupParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.DisplayName)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.DisplayName)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.ParentGroupParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.DisplayName, ValueFromPipeline = false)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.ParentGroupAndManagementGroupParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.InputObject, ValueFromPipeline = false)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; } = null;

        [Parameter(ParameterSetName = Constants.ParameterSetNames.ManagementGroupParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.ParentId)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.ParentId)]
        [ValidateNotNullOrEmpty]
        public string ParentId { get; set; } = null;


        [Parameter(ParameterSetName = Constants.ParameterSetNames.ParentGroupAndManagementGroupParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.InputObject, ValueFromPipeline = false)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.ParentGroupParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.ParentObject, ValueFromPipeline = false)]
        [ValidateNotNullOrEmpty]
        public PSManagementGroup ParentObject;

        public override void ExecuteCmdlet()
        {
            try
            {
                if (ParameterSetName.Equals(Constants.ParameterSetNames.ManagementGroupParameterSet) 
                    || ParameterSetName.Equals(Constants.ParameterSetNames.ParentGroupAndManagementGroupParameterSet))
                {
                    GroupName = InputObject.Name;
                }

                if (ParameterSetName.Equals(Constants.ParameterSetNames.ParentGroupParameterSet)
                    || ParameterSetName.Equals(Constants.ParameterSetNames.ParentGroupAndManagementGroupParameterSet))
                {
                    ParentId = ParentObject.Id;
                }

                if (ShouldProcess(
                        string.Format(Resource.UpdateManagementGroupShouldProcessTarget, GroupName),
                        string.Format(Resource.UpdateManagementGroupShouldProcessAction, GroupName)))
                {
                    PreregisterSubscription();

                    PatchManagementGroupRequest patchGroupRequest =
                        new PatchManagementGroupRequest(DisplayName, ParentId);
                    var response = ManagementGroupsApiClient.ManagementGroups.Update(GroupName, patchGroupRequest);
                    WriteObject(new PSManagementGroup(response));
                }
            }
            catch (ErrorResponseException ex)
            {
                Utility.HandleErrorResponseException(ex);
            }
        }
    }
}
