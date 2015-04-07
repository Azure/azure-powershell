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

using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;
using Job = Microsoft.Azure.Commands.Automation.Model.Job;


namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Starts an Azure automation runbook.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureAutomationRunbook", DefaultParameterSetName = AutomationCmdletParameterSets.ByRunbookName)]
    [OutputType(typeof(Job))]
    public class StartAzureAutomationRunbook : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the runbook name
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByRunbookName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook name.")]
        [ValidateNotNullOrEmpty]
        [Alias("RunbookName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the runbook parameters.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The runbook parameters.")]
        public IDictionary Parameters { get; set; }

        /// <summary>
        /// Gets or sets the optional hybrid agent friendly name upon which the runbook should be executed.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Optional name of the hybrid agent which should execute the runbook")]
        [Alias("HybridWorker")]
        public string RunOn { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            Job job = null;

            job = this.AutomationClient.StartRunbook(this.AutomationAccountName, this.Name, this.Parameters, this.RunOn);

            this.WriteObject(job);
        }
    }
}
