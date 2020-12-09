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

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.ManagementGroups.Common;
using Microsoft.Azure.Commands.Resources.Models.ManagementGroups;
using Microsoft.Azure.Management.ManagementGroups;
using Microsoft.Azure.Management.ManagementGroups.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Resources.ManagementGroups
{
    /// <summary>
    /// Get-AzManagementGroup Cmdlet
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagementGroup", DefaultParameterSetName = Constants.ParameterSetNames.ListParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSManagementGroupInfo), typeof(PSManagementGroup))]
    public class GetAzureRmManagementGroup : AzureManagementGroupsCmdletBase
    {
        /// <summary>
        /// Get-AzManagementGroup Cmdlet
        /// </summary>
        [Alias("GroupId")]
        [CmdletParameterBreakingChange("GroupName", ReplaceMentCmdletParameterName = "GroupId", ChangeDescription = "We will repleace GroupName with GroupId to make it more clear.")]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.GetParameterSet, Mandatory = true, HelpMessage = Constants.HelpMessages.GroupName, Position = 0)]
        public string GroupName { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.GetParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.Expand)]
        public SwitchParameter Expand;

        [Parameter(ParameterSetName = Constants.ParameterSetNames.GetParameterSet, Mandatory = false,
            HelpMessage = Constants.HelpMessages.Recurse)]
        public SwitchParameter Recurse;

        public override void ExecuteCmdlet()
        {
            try
            {
                PreregisterSubscription();

                if (!string.IsNullOrEmpty(GroupName))
                {
                    var response = ManagementGroupsApiClient.ManagementGroups.Get(GroupName, Expand.IsPresent?"children":null, Recurse.IsPresent);
                        WriteObject(new PSManagementGroup(response));
                }
                else
                {
                    var response = ManagementGroupsApiClient.ManagementGroups.List();
                    var items = response.Select(managementGroup => new PSManagementGroupInfo(managementGroup))
                        .ToList();
                    WriteObject(items, true);
                }
            }
            catch (ErrorResponseException ex)
            {
                Utility.HandleErrorResponseException(ex);
            }
        }
    }
}
