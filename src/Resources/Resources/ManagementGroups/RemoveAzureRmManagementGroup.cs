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
    /// <summary>
    /// Remove-AzManagementGroup Cmdlet
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagementGroup",DefaultParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet,SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRmManagementGroup : AzureManagementGroupsCmdletBase
    {

        [Parameter(ParameterSetName = Constants.ParameterSetNames.ManagementGroupParameterSet, Mandatory = true, 
            HelpMessage = Constants.HelpMessages.InputObject, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSManagementGroup InputObject { get; set; }

        [Alias("GroupId")]
        [CmdletParameterBreakingChange("GroupName", ReplaceMentCmdletParameterName = "GroupId", ChangeDescription = "We will repleace GroupName with GroupId to make it more clear.")]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.GroupName, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string GroupName { get; set; } = null;

        [Parameter(ParameterSetName = Constants.ParameterSetNames.ManagementGroupParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GroupOperationsParameterSet, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (ParameterSetName.Equals(Constants.ParameterSetNames.ManagementGroupParameterSet))
                {
                    GroupName = InputObject.Name;
                }

                if (ShouldProcess(
                        string.Format(Resource.RemoveManagementGroupShouldProcessTarget, GroupName),
                        string.Format(Resource.RemoveManagementGroupShouldProcessAction, GroupName)))
                {
                    PreregisterSubscription();

                    ManagementGroupsApiClient.ManagementGroups.Delete(GroupName);

                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                }
            }
            catch (ErrorResponseException ex)
            {
                Utility.HandleErrorResponseException(ex);
            }
        }
    }
}
