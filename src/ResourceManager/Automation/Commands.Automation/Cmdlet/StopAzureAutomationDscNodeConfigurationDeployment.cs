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
using DayOfWeek = Microsoft.Azure.Commands.Automation.Model.DayOfWeek;


namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    [Cmdlet(VerbsLifecycle.Stop, "AzureRmAutomationDscNodeConfigurationDeployment", SupportsShouldProcess = true, 
        DefaultParameterSetName = AutomationCmdletParameterSets.ByJobId), OutputType(typeof(bool))]
    public class StopAzureAutomationDscNodeConfigurationDeployment : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the configuration name.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The deployment job id.", 
            ParameterSetName = AutomationCmdletParameterSets.ByJobId)]
        public Guid JobId { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter not to confirm on removing the runbook.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Forces the command to run without asking for user confirmation.",
            ParameterSetName = AutomationCmdletParameterSets.ByJobId)]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter to print the output when done.
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter to confirm on deploying the node configuration.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = AutomationCmdletParameterSets.ByInputObject,
            HelpMessage = "Input object for Piping.")]
        public NodeConfigurationDeployment InputObject { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            if (this.ParameterSetName == AutomationCmdletParameterSets.ByInputObject)
            {
                if (this.ShouldProcess(JobId.ToString(), VerbsLifecycle.Stop))
                {
                    if (Force ||
                        ShouldContinue(Resources.StopAzureAutomationNodeConfigurationWarning, Resources.StopAzureAutomationNodeConfigurationDescription))
                    {
                        this.AutomationClient.StopNodeConfigurationDeployment(this.InputObject.ResourceGroupName, 
                            this.InputObject.AutomationAccountName, 
                            this.InputObject.JobId);

                        if (PassThru.IsPresent)
                        {
                            WriteObject(true);
                        }
                    }
                }
            }
            else
            {
                if (this.ShouldProcess(JobId.ToString(), VerbsLifecycle.Stop))
                {
                    if (Force ||
                        ShouldContinue(Resources.StopAzureAutomationNodeConfigurationWarning, Resources.StopAzureAutomationNodeConfigurationDescription))
                    {
                        this.AutomationClient.StopNodeConfigurationDeployment(this.ResourceGroupName, this.AutomationAccountName, this.JobId);

                        if (PassThru.IsPresent)
                        {
                            WriteObject(true);
                        }
                    }
                }
            }
        }
    }
}
