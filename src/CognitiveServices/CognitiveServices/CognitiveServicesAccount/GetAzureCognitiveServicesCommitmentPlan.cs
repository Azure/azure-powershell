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

using Microsoft.Azure.Commands.Management.CognitiveServices.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Get Cognitive Services Account by name, all accounts under resource group or all accounts under the subscription
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesCommitmentPlan", DefaultParameterSetName = ResourceGroupParameterSet), OutputType(typeof(PSCognitiveServicesAccount))]
    public class GetAzureCognitiveServicesCommitmentPlanCommand : CognitiveServicesAccountBaseCmdlet
    {
        protected const string ResourceGroupParameterSet = "ResourceGroupParameterSet";
        protected const string CommitmentPlanNameParameterSet = "CommitmentPlanNameParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = ResourceGroupParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = CommitmentPlanNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CommitmentPlanNameParameterSet,
            HelpMessage = "Cognitive Services Account Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                switch (ParameterSetName)
                {
                    default:
                        if (string.IsNullOrEmpty(this.ResourceGroupName))
                        {
                            var plans = GetWithPaging(this.CognitiveServicesClient.CommitmentPlans.ListPlansBySubscription(), false);

                            WriteObject(plans, true);
                        }
                        else if (string.IsNullOrEmpty(this.Name))
                        {
                            var plans = GetWithPaging(this.CognitiveServicesClient.CommitmentPlans.ListPlansByResourceGroup(this.ResourceGroupName), true);

                            WriteObject(plans, true);
                        }
                        else
                        {
                            var plan = this.CognitiveServicesClient.CommitmentPlans.GetPlan(
                                this.ResourceGroupName,
                                this.Name);

                            WriteObject(plan);
                        }
                        break;
                }

            });
        }

        private IEnumerable<CommitmentPlan> GetWithPaging(IPage<CommitmentPlan> firstPage, bool isResourceGroup)
        {
            var plans = new List<CommitmentPlan>(firstPage);
            IPage<CommitmentPlan> nextPage;
            for (var nextLink = firstPage.NextPageLink; !string.IsNullOrEmpty(nextLink); nextLink = nextPage.NextPageLink)
            {
                if (isResourceGroup)
                {
                    nextPage = this.CognitiveServicesClient.CommitmentPlans.ListPlansByResourceGroupNext(nextLink);
                }
                else
                {
                    nextPage = this.CognitiveServicesClient.CommitmentPlans.ListPlansBySubscriptionNext(nextLink);
                }

                plans.AddRange(nextPage);
            }

            return plans;
        }
    }
}
