using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Properties;


namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationHybridRunbookWorker", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(void))]
    public class RemoveAzureAutomationHybridWorker : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the hybridworkergroup name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The hybrid runbook worker name.")]
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
