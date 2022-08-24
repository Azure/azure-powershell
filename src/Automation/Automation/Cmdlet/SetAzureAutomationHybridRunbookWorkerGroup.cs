using Azure;
using Azure.ResourceManager.Automation;
using Azure.ResourceManager.Automation.Models;
using Azure.ResourceManager.Resources;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationHybridRunbookWorkerGroup")]
    [OutputType(typeof(HybridRunbookWorkerGroupData))]
    public class SetAzureAutomationHybridRunbookWorkerGroup : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the hybrid worker group name.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The hybrid runbook worker group name")]
        [ValidateNotNullOrEmpty]
        [Alias("Group")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the hybrid worker group Credential.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The credential present in the automation account.")]
        public string CredentialName { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            HybridRunbookWorkerGroupCreateOrUpdateParameters data = new HybridRunbookWorkerGroupCreateOrUpdateParameters()
            {
                CredentialName = this.CredentialName,
                Name = this.Name,
            };

            SubscriptionResource subResource = this.ArmClient.GetDefaultSubscription(new System.Threading.CancellationToken());
            var subId = subResource.Data.SubscriptionId;

            var automationAccountResourceId = AutomationAccountResource.CreateResourceIdentifier(subId, this.ResourceGroupName, this.AutomationAccountName);
            var operation = this.ArmClient.GetAutomationAccountResource(automationAccountResourceId).GetHybridRunbookWorkerGroups().CreateOrUpdate(WaitUntil.Completed, this.Name, data);

            this.GenerateCmdletOutput(operation.Value.Data);
        }
    }
}
