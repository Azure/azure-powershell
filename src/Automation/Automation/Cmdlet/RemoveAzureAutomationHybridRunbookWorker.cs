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
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Properties;


namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationHybridRunbookWorker", SupportsShouldProcess = true)]
    [OutputType(typeof(void))]
    public class RemoveAzureAutomationHybridRunbookWorker : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the hybridworkergroup name.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The hybrid runbook worker name.")]
        [ValidateNotNullOrEmpty]
        [Alias("RunbookWorker", "RunbookWorkerId")]
        public string Name { get; set; }


        /// <summary>
        /// Gets or sets the hybrid worker group name.
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The hybrid runbook worker group name")]
        [Alias("RunbookWorkerGroup", "WorkerGroup")]
        [ValidateNotNullOrEmpty]
        public string HybridRunbookWorkerGroupName { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            ConfirmAction(
                       string.Format(Resources.RemoveAzureAutomationResourceDescription, "HybridRunbookWorker"),
                       Name,
                       () =>
                       {
                           this.AutomationClient.DeleteHybridRunbookWorker(this.ResourceGroupName, this.AutomationAccountName, this.HybridRunbookWorkerGroupName, Name);
                       });
        }
    }
}
