// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Automation.Common;


namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationHybridRunbookWorker", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(Management.Automation.Models.HybridRunbookWorker))]
    public class GetAzureAutomationHybridRunbookWorker : AzureAutomationBaseCmdlet
    {
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 2, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Hybrid Runbook Worker name")]
        [Alias("RunbookWorker", "RunbookWorkerId")]
        public string Name { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Hybrid Runbook Worker Group name")]
        [Alias("WorkerGroup", "RunbookWorkerGroup")]
        [ValidateNotNullOrEmpty]
        public string HybridRunbookWorkerGroupName { get; set; }

        protected override void AutomationProcessRecord()
        {
            if (this.ParameterSetName == AutomationCmdletParameterSets.ByName)
            {
                IEnumerable<Management.Automation.Models.HybridRunbookWorker> ret = null;
                ret = new List<Management.Automation.Models.HybridRunbookWorker> {

                    this.AutomationClient.GetHybridRunbookWorkers(this.ResourceGroupName, this.AutomationAccountName, this.HybridRunbookWorkerGroupName, this.Name)
                };
                this.GenerateCmdletOutput(ret);
            }
            else if(this.ParameterSetName == AutomationCmdletParameterSets.ByAll)
            {
                var nextLink = string.Empty;
                do
                {
                    var results = this.AutomationClient.ListHybridRunbookWorkers(this.ResourceGroupName, this.AutomationAccountName, this.HybridRunbookWorkerGroupName, ref nextLink);
                    this.GenerateCmdletOutput(results);
                }while (!string.IsNullOrEmpty(nextLink));
            }
        }
    }
}
