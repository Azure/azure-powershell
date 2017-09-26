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
    [Cmdlet(VerbsCommon.Get, "AzureRmAutomationDscNodeConfigurationDeploymentSchedule",
        DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(NodeConfigurationDeploymentSchedule))]
    public class GetAzureAutomationDscNodeConfigurationDeploymentSchedule : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the job schedule id.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByJobScheduleId, Mandatory = true, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The deployment job schedule id.")]
        public Guid JobScheduleId { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            if (this.ParameterSetName == AutomationCmdletParameterSets.ByJobScheduleId)
            {
                var jobSchedules = this.AutomationClient.GetNodeConfigurationDeploymentSchedule(this.ResourceGroupName, this.AutomationAccountName, this.JobScheduleId);
                this.GenerateCmdletOutput(jobSchedules);
            }
            else
            {
                // ByAll 
                var nextLink = string.Empty;
                IEnumerable<NodeConfigurationDeploymentSchedule> deployments = null;

                do
                {
                    deployments = this.AutomationClient.ListNodeConfigurationDeploymentSchedules(this.ResourceGroupName, this.AutomationAccountName, ref nextLink);
                    if (deployments != null)
                    {
                        this.GenerateCmdletOutput(deployments);
                    }

                } while (!string.IsNullOrEmpty(nextLink));
            }
        }
    }
}
