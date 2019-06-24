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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.AlertsManagement.OutputModels;
using Microsoft.Azure.Management.AlertsManagement.Models;

namespace Microsoft.Azure.Commands.AlertsManagement
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SmartGroupState", SupportsShouldProcess = true)]
    [OutputType(typeof(PSSmartGroup))]
    public class UpdateAzureSmartGroupState : AlertsManagementBaseCmdlet
    {
        #region Parameters declarations
        /// <summary>
        /// Smart Group Id
        /// </summary>
        [Parameter(Mandatory = true,
                   HelpMessage = "Unique Identifier of Smart Group / ResourceId of smart group.")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceId")]
        public string SmartGroupId { get; set; }

        /// <summary>
        /// Smart Group State
        /// </summary>
        [Parameter(Mandatory = true,
                   HelpMessage = "Updated Smart group State")]
        [PSArgumentCompleter("New", "Acknowledged", "Closed")]
        [ValidateNotNullOrEmpty]
        public string State { get; set; }

        #endregion

        protected override void ProcessRecordInternal()
        {
            if (ShouldProcess(
                       target: string.Format("Update smart group state to {0}", State),
                       action: "Update Smart group state"))
            {
                string id = CommonUtils.GetIdFromARMResourceId(SmartGroupId);
                PSSmartGroup smartGroup = new PSSmartGroup(
                    this.AlertsManagementClient.SmartGroups.ChangeStateWithHttpMessagesAsync(id, State).Result.Body);
                WriteObject(sendToPipeline: smartGroup);
            }
        }
    }
}
