using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Properties;


namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    [Cmdlet("Move", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationHybridRunbookWorker", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(Management.Automation.Models.HybridRunbookWorker))]
    public class MoveAzureAutomationHybridWorker : AzureAutomationBaseCmdlet
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
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 3, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The hybrid runbook worker group name")]
        [Alias("RunbookWorkerGroup", "WorkerGroup")]
        [ValidateNotNullOrEmpty]
        public string HybridRunbookWorkerGroupName { get; set; }

        /// <summary>
        /// Gets or sets the target hybrid worker group name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 4, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The target hybrid runbook worker group name")]
        [Alias("TargetRunbookWorkerGroup", "TargetWorkerGroup")]
        [ValidateNotNullOrEmpty]
        public string TargetHybridRunbookWorkerGroupName { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            ConfirmAction(
                       string.Format(Resources.MoveAzureAutomationHybridRunbookWorkerDescription, this.Name, this.HybridRunbookWorkerGroupName, this.TargetHybridRunbookWorkerGroupName), 
                       Name,
                       () =>
                       {
                           this.AutomationClient.MoveRunbookWorker(this.ResourceGroupName, this.AutomationAccountName, this.HybridRunbookWorkerGroupName, this.TargetHybridRunbookWorkerGroupName, this.Name);
                       });
        }
    }
}
