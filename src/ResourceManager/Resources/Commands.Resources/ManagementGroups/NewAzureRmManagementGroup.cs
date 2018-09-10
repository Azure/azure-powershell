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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Resources.ManagementGroups
{
    /// <summary>
    /// New-AzureRmManagementGroup Cmdlet
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagementGroup", DefaultParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSManagementGroup))]
    public class NewAzureRmManagementGroup : AzureManagementGroupsCmdletBase
    {
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = true, HelpMessage = Constants.HelpMessages.GroupName, Position = 0)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.ParentGroupParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.ParentObject)]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.DisplayName)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.ParentGroupParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.DisplayName, ValueFromPipeline = false)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; } = null;

        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.ParentId)]
        [ValidateNotNullOrEmpty]
        public string ParentId { get; set; } = null;

        [Parameter(ParameterSetName = Constants.ParameterSetNames.ParentGroupParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.ParentObject, ValueFromPipeline = false)]
        public PSManagementGroup ParentObject;

        public override void ExecuteCmdlet()
        {
            try
            {
                if (ParameterSetName.Equals(Constants.ParameterSetNames.ParentGroupParameterSet))
                {
                    ParentId = ParentObject.Id;
                }

                if (ShouldProcess(
                        string.Format(Resource.NewManagementGroupShouldProcessTarget, GroupName), 
                        string.Format(Resource.NewManagementGroupShouldProcessAction, GroupName)))
                {
                    PreregisterSubscription();

                    CreateManagementGroupRequest createGroupRequest = new CreateManagementGroupRequest(
                        id: Constants.GroupUrlPrefix + GroupName, type: Constants.GroupType, name: GroupName,
                        displayName: DisplayName,
                        details: new CreateManagementGroupDetails()
                        {
                            Parent = new CreateParentGroupInfo() {Id = ParentId}
                        });

                    var response = ManagementGroupsApiClient.ManagementGroups.CreateOrUpdate(GroupName, createGroupRequest);
                    var managementGroup =
                        ((JObject) response).ToObject<ManagementGroup>(
                            JsonSerializer.Create(ManagementGroupsApiClient.DeserializationSettings));
                    WriteObject(new PSManagementGroup(managementGroup));
                }
            }
            catch (ErrorResponseException ex)
            {
                Utility.HandleErrorResponseException(ex);
            }
        }
    }
}
