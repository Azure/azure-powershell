using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Common;


namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, "AzureRMAutomationHybridWorkerGroup", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(HybridRunbookWorkerGroup))]
    public class GetAzureAutomationHybridWorkerGroup : AzureAutomationBaseCmdlet
    {
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName,Position = 2,  Mandatory = false, ValueFromPipeline = true, HelpMessage = "The Hybrid Runbook Worker Group name")]
        [Alias("Group")]
        public string Name { get; set; }

        protected override void AutomationProcessRecord()
        {
            if (this.ParameterSetName == AutomationCmdletParameterSets.ByName)
            {
                IEnumerable<HybridRunbookWorkerGroup> ret = null;
                ret = new List<HybridRunbookWorkerGroup> {

                    this.AutomationClient.GetHybridRunbookWorkerGroup(this.ResourceGroupName, this.AutomationAccountName, this.Name)
                };
                this.GenerateCmdletOutput(ret);
            }
            else if(this.ParameterSetName == AutomationCmdletParameterSets.ByAll)
            {
                var nextLink = string.Empty;
                do
                {
                    var results = this.AutomationClient.ListHybridRunbookWorkerGroups(this.ResourceGroupName, this.AutomationAccountName, ref nextLink);
                    this.GenerateCmdletOutput(results);
                }while (!string.IsNullOrEmpty(nextLink));
            }
        }
    }
}
