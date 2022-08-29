using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Common;


namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationHybridRunbookWorkerGroup", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(Management.Automation.Models.HybridRunbookWorkerGroup))]
    public class SetAzureAutomationHybridWorkerGroup : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the hybrid worker group name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 2, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The hybrid runbook worker group name")]
        [Alias("WorkerGroup", "RunbookWorkerGroup")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the hybrid worker group Credential.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The credential present in the automation account.")]
        public string CredentialName { get; set; }

        protected override void AutomationProcessRecord()
        {
            var workerGroup = this.AutomationClient.CreateOrUpdateRunbookWorkerGroup(this.ResourceGroupName, this.AutomationAccountName, this.Name, this.CredentialName);
            this.GenerateCmdletOutput(workerGroup);
        }
    }
}
