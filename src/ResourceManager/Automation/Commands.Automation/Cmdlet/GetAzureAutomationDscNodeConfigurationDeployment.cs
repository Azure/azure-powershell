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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Properties;
using System.Collections;
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, "AzureRmAutomationDscNodeConfigurationDeployment", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(NodeConfigurationDeployment))]
    public class GetAzureAutomationDscNodeConfigurationDeployment : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the job id.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByJobId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The deployment job id.")]
        public Guid JobId { get; set; }

        /// <summary> 
        /// Gets or sets the status of a job. 
        /// </summary> 
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByAll, Mandatory = false, HelpMessage = "Filter deployment jobs based on their status.")]
        [ValidateSet("Completed", "Failed", "Queued", "Starting", "Resuming", "Running", "Stopped", "Stopping", "Suspended", "Suspending", "Activating")]
        public string Status { get; set; }

        /// <summary> 
        /// Gets or sets the start time filter. 
        /// </summary> 
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByAll, Mandatory = false, HelpMessage = "Filter deployment jobs so that job start time >= StartTime.")]
        public DateTimeOffset? StartTime { get; set; }

        /// <summary> 
        /// Gets or sets the end time filter. 
        /// </summary> 
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByAll, Mandatory = false, HelpMessage = "Filter deployment jobs so that job end time <= EndTime.")]
        public DateTimeOffset? EndTime { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            if (this.ParameterSetName == AutomationCmdletParameterSets.ByJobId)
            {
                var returnNodeStatus = this.AutomationClient.GetNodeConfigurationDeployment(this.ResourceGroupName, this.AutomationAccountName, this.JobId);
                this.GenerateCmdletOutput(returnNodeStatus);
            } else {
                // ByAll 
                var nextLink = string.Empty;
                IEnumerable<NodeConfigurationDeployment> deployments = null;

                do
                {
                    deployments = this.AutomationClient.ListNodeConfigurationDeployment(this.ResourceGroupName, this.AutomationAccountName, this.StartTime, this.EndTime, this.Status, ref nextLink);
                    this.WriteObject(deployments, true);

                } while (!string.IsNullOrEmpty(nextLink));
            }
        }
    }
}
