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
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName,Position = 2,  Mandatory = false, ValueFromPipeline = true, HelpMessage = "The Hybrid Runbook Worker Group Name")]
        [Alias("Group")]
        public string Name { get; set; }

        protected override void ProcessRecord()
        {
            IEnumerable<HybridRunbookWorkerGroup> ret = null;
            if (this.ParameterSetName == AutomationCmdletParameterSets.ByName)
            {
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
                    var results1 = this.AutomationClient.ListHybridRunbookWorkerGroups(this.ResourceGroupName, this.AutomationAccountName, ref nextLink);
                    // ret = this.AutomationClient.ListHybridRunbookWorkerGroups(this.ResourceGroupName, this.AutomationAccountName, ref nextLink);

                    this.GenerateCmdletOutput(results1);
                }while (!string.IsNullOrEmpty(nextLink));

            }
        }
    }
}
