using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Common;


namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationHybridWorkerGroup", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(HybridRunbookWorkerGroup))]
    public class GetAzureAutomationHybridWorkerGroup : AzureAutomationBaseCmdlet
    {
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 2, Mandatory = false, ValueFromPipeline = true, HelpMessage = "The Hybrid Runbook Worker Group name")]
        [Alias("Group")]
        public string Name { get; set; }

        protected override void AutomationProcessRecord()
        {
            if (this.ParameterSetName == AutomationCmdletParameterSets.ByName)
            {
                IEnumerable<HybridRunbookWorkerGroup> ret = null;
                ret = new List<HybridRunbookWorkerGroup> {

                    this.AutomationClient.GetHybridWorkerGroup(this.ResourceGroupName, this.AutomationAccountName, this.Name)
                };
            }
        }
    }
}