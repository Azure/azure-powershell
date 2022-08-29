using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Common;


namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationHybridRunbookWorker", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(Management.Automation.Models.HybridRunbookWorker))]
    public class NewAzureAutomationHybridWorker : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the hybrid worker name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 2, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Hybrid Runbook Worker name")]
        [Alias("RunbookWorker", "RunbookWorkerId")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the hybrid worker group name.
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The hybrid runbook worker group name")]
        [Alias("RunbookWorkerGroup", "WorkerGroup")]
        [ValidateNotNullOrEmpty]
        public string HybridRunbookWorkerGroupName { get; set; }

        /// <summary>
        /// Gets or sets the hybrid worker group name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 4, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The resource id of the vm to be added to the hybrid worker group")]
        [Alias("VMId")]
        [ValidateNotNullOrEmpty]
        public string VmResourceId { get; set; }


        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            var worker = this.AutomationClient.CreateOrUpdateRunbookWorker(this.ResourceGroupName, this.AutomationAccountName, this.HybridRunbookWorkerGroupName, this.Name, this.VmResourceId);
            this.GenerateCmdletOutput(worker);
        }
    }
}
