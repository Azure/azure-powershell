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
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.ActivityLogAlert
{
    /// <summary>
    /// Create or update an Activity Log Alert
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmActivityLogAlert", SupportsShouldProcess = true), OutputType(typeof(PSActivityLogAlertResource))]
    public class SetAzureRmActivityLogAlertCommand : ManagementCmdletBase
    {
        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the Location parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location of the activity log rule resource")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the alert name parameter of the cmdlet
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The activity log rule name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or set the resource group name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name of the activity log rule resource")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the scopes of the activity log alert
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The list scopes")]
        [ValidateNotNullOrEmpty]
        public List<string> Scope { get; set; }

        /// <summary>
        /// Gets or sets the conditions of the activity log alert
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of leaf conditions of the activity log alert")]
        [ValidateNotNullOrEmpty]
        public List<ActivityLogAlertLeafCondition> Condition { get; set; }

        /// <summary>
        /// Gets or sets the actions of the activity log alert
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The list actions of the activity log alert")]
        [ValidateNotNullOrEmpty]
        public List<ActivityLogAlertActionGroup> Action { get; set; }

        /// <summary>
        /// Gets or sets the DisableAlert flag.
        /// <para>If not given, the alert is created enabled, i.e. the default value.</para>
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The disable alert flag. Defaults to false, alerts are created enabled by default.")]
        public SwitchParameter DisableAlert { get; set; }

        /// <summary>
        /// Gets or set the alert description
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The description of the activity log rule resource")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Tags of the activity log alert resource
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The tags of the activity log alert resource")]
        [ValidateNotNullOrEmpty]
        public Dictionary<string, string> Tag { get; set; }

        #endregion

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            if (ShouldProcess(
                    target: string.Format("Create/update an activity logs alert: {0} from resource group: {1}", this.Name, this.ResourceGroupName),
                    action: "Create/update an activity logs alert"))
            {
                WriteObject(
                this.MonitorManagementClient.ActivityLogAlerts.CreateOrUpdate(
                    resourceGroupName: this.ResourceGroupName,
                    activityLogAlertName: this.Name,
                    activityLogAlert: this.CreateActivityLogAlertResource()));
            }
        }

        private ActivityLogAlertResource CreateActivityLogAlertResource()
        {
            ActivityLogAlertResource newAlert = new ActivityLogAlertResource(
                name: this.Name,
                location: this.Location,
                scopes: this.Scope,
                condition: new ActivityLogAlertAllOfCondition(this.Condition),
                actions: new ActivityLogAlertActionList(this.Action));

            // EnableAlert defaults to true
            newAlert.Enabled = !this.DisableAlert.IsPresent;
            newAlert.Description = this.Description;
            newAlert.Tags = this.Tag;

            return newAlert;
        }
    }
}
