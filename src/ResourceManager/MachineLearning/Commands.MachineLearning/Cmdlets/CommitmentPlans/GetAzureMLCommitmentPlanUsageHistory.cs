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

using System.Management.Automation;
using Microsoft.Azure.Management.MachineLearning.CommitmentPlans.Models;

namespace Microsoft.Azure.Commands.MachineLearning
{
    using ResourceManager.Common.ArgumentCompleters;
    using Rest.Azure;

    [Cmdlet(VerbsCommon.Get, CommitmentPlansCmdletBase.CommitmentPlanUsageHistorySuffix)]
    [OutputType(typeof(PlanUsageHistory[]))]
    public class GetAzureMLCommitmentPlanUsageHistory : CommitmentPlansCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the resource group for the Azure ML commitment plan.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the Azure ML commitment plan.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        protected override void RunCmdlet()
        {
            IPage<PlanUsageHistory> usageHistories =
                this.CommitmentPlansClient.GetAzureMlCommitmentPlanUsageHistoryAsync(
                    this.ResourceGroupName,
                    this.Name,
                    null,
                    this.CancellationToken).Result;

            foreach (var usageHistory in usageHistories)
            {
                this.WriteObject(usageHistory, true);
            }
        }
    }
}
