using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Common;
using Azure.ResourceManager.Automation;
using Azure.ResourceManager.Resources;
using System.Linq;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationHybridRunbookWorker", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(HybridRunbookWorkerData))]
    public class GetAzureAutomationHybridRunbookWorker : AzureAutomationBaseCmdlet
    {
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 2,  Mandatory = false, ValueFromPipeline = true, HelpMessage = "The Hybrid Runbook Worker name")]
        [Alias("RunbookWorker")]
        public string Name { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 3, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Hybrid Runbook Worker Group name")]
        [Alias("WorkerGroup")]
        [ValidateNotNullOrEmpty]
        public string HybridRunbookWorkerGroupName { get; set; }

        protected override void AutomationProcessRecord()
        {
            SubscriptionResource subResource = this.ArmClient.GetDefaultSubscription(new System.Threading.CancellationToken());
            var subId = subResource.Data.SubscriptionId;

            var hybridWorkerGroupResourceId = HybridRunbookWorkerGroupResource.CreateResourceIdentifier(subId, this.ResourceGroupName, this.AutomationAccountName, this.HybridRunbookWorkerGroupName);
            var hybridWorkerGroupResource = this.ArmClient.GetHybridRunbookWorkerGroupResource(hybridWorkerGroupResourceId);

            if (this.ParameterSetName == AutomationCmdletParameterSets.ByName)
            {
                var hybridWorker = hybridWorkerGroupResource.GetHybridRunbookWorker(this.Name);
                this.GenerateCmdletOutput(hybridWorker.Value.Data);
            }
            else if(this.ParameterSetName == AutomationCmdletParameterSets.ByAll)
            {
                var hybridWorkers = hybridWorkerGroupResource.GetHybridRunbookWorkers();
                this.GenerateCmdletOutput(hybridWorkers.GetAll().Select(x => x.Data));
            }
        }
    }
}
