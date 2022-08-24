using Azure;
using Azure.ResourceManager.Automation;
using Azure.ResourceManager.Automation.Models;
using Azure.ResourceManager.Resources;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationHybridRunbookWorker")]
    [OutputType(typeof(HybridRunbookWorkerData))]
    public class NewAzureAutomationHybridRunbookWorker : AzureAutomationBaseCmdlet
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
            var hybridWorkerCreateOrUpdateParameters = new HybridRunbookWorkerCreateOrUpdateContent()
            {
                Name = this.Name,
                VmResourceId = this.VmResourceId
            };

            SubscriptionResource subResource = this.ArmClient.GetDefaultSubscription(new System.Threading.CancellationToken());
            var subId = subResource.Data.SubscriptionId;

            var hybridWorkerGroupResourceId = HybridRunbookWorkerGroupResource.CreateResourceIdentifier(subId, this.ResourceGroupName, this.AutomationAccountName,this.HybridRunbookWorkerGroupName);
            var operation = this.ArmClient.GetHybridRunbookWorkerGroupResource(hybridWorkerGroupResourceId).GetHybridRunbookWorkers().CreateOrUpdate(WaitUntil.Completed, this.Name, hybridWorkerCreateOrUpdateParameters);

            this.GenerateCmdletOutput(operation.Value.Data);
        }
    }
}
