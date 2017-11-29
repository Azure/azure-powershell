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

using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Monitor.Management;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.ActivityLogAlert
{
    /// <summary>
    /// Get an Activity Log Alert
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmActivityLogAlert"), OutputType(typeof(List<PSActivityLogAlertResource>))]
    public class GetAzureRmActivityLogAlertCommand : ManagementCmdletBase
    {
        internal const string GetActivityLogAlertDefaultParamGroup = "GetByNameAndResourceGroup";
        internal const string GetActivityLogAlertHelperParamGroup = "GetByResourceGroup";

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the ResourceGroupName parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetActivityLogAlertDefaultParamGroup, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [Parameter(ParameterSetName = GetActivityLogAlertHelperParamGroup, Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the rule name parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = GetActivityLogAlertDefaultParamGroup, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The activity log alert name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        #endregion

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            List<PSActivityLogAlertResource> output = null;
            if (string.IsNullOrWhiteSpace(this.ResourceGroupName))
            {
                if (string.IsNullOrWhiteSpace(this.Name))
                {
                    // Getting by SubscriptionId
                    output = this.MonitorManagementClient.ActivityLogAlerts.ListBySubscriptionId()
                        .Select(e => new PSActivityLogAlertResource(e))
                        .ToList();
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(this.Name))
                {
                    // Getting by resource group
                    output = this.MonitorManagementClient.ActivityLogAlerts.ListByResourceGroup(resourceGroupName: this.ResourceGroupName)
                        .Select(e => new PSActivityLogAlertResource(e))
                        .ToList();
                }
                else
                {
                    // Getting by alert name
                    output = new List<PSActivityLogAlertResource>
                    {
                        new PSActivityLogAlertResource(this.MonitorManagementClient.ActivityLogAlerts.Get(resourceGroupName: this.ResourceGroupName, activityLogAlertName: this.Name))
                    };
                }
            }

            WriteObject(sendToPipeline: output, enumerateCollection: true);
        }
    }
}
