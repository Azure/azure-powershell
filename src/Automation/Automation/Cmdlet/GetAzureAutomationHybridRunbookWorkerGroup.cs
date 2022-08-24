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
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationHybridRunbookWorkerGroup", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(HybridRunbookWorkerGroupData))]
    public class GetAzureAutomationHybridRunbookWorkerGroup : AzureAutomationBaseCmdlet
    {
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 2,  Mandatory = false, ValueFromPipeline = true, HelpMessage = "The Hybrid Runbook Worker Group name")]
        [Alias("Group")]
        public string Name { get; set; }

        protected override void AutomationProcessRecord()
        {
            SubscriptionResource subResource = this.ArmClient.GetDefaultSubscription(new System.Threading.CancellationToken());
            var subId = subResource.Data.SubscriptionId;

            var automationAccountResourceId = AutomationAccountResource.CreateResourceIdentifier(subId, this.ResourceGroupName, this.AutomationAccountName);

            if (this.ParameterSetName == AutomationCmdletParameterSets.ByName)
            {
                var hybridWorkerGroupResource = this.ArmClient.GetAutomationAccountResource(automationAccountResourceId).GetHybridRunbookWorkerGroup(this.Name).Value;
                this.GenerateCmdletOutput(hybridWorkerGroupResource.Data);
            }
            else if(this.ParameterSetName == AutomationCmdletParameterSets.ByAll)
            {
                var results = this.ArmClient.GetAutomationAccountResource(automationAccountResourceId).GetHybridRunbookWorkerGroups();
                this.GenerateCmdletOutput(results.GetAll().Select(x => x.Data));
            }
        }
    }
}
