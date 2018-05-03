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
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.MachineLearning
{

    [Cmdlet(VerbsCommon.Get, CommitmentPlansCmdletBase.CommitmentAssociationCommandletSuffix)]
    [OutputType(typeof(CommitmentPlan), typeof(CommitmentPlan[]))]
    public class GetAzureMLCommitmentAssociation : CommitmentPlansCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the resource group for the Azure ML commitment association.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the Azure ML commitment plan.")]
        [ValidateNotNullOrEmpty]
        public string CommitmentPlanName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the Azure ML commitment association.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        protected override void RunCmdlet()
        {
            // If this is a simple get commitment association by name operation, resolve it as such
            if (!string.IsNullOrWhiteSpace(this.ResourceGroupName) &&
                !string.IsNullOrWhiteSpace(this.Name))
            {
                CommitmentAssociation commitmentAssociation =
                    this.CommitmentPlansClient.GetAzureMlCommitmentAssociation(this.ResourceGroupName, this.CommitmentPlanName, this.Name);
                this.WriteObject(commitmentAssociation);
            }
            else
            {
                IPage<CommitmentAssociation> commitmentAssociations =
                    this.CommitmentPlansClient.ListAzureMlCommitmentAssociationsAsync(
                        this.ResourceGroupName,
                        this.CommitmentPlanName,
                        null,
                        this.CancellationToken).Result;

                foreach (var commitmentAssociation in commitmentAssociations)
                {
                    this.WriteObject(commitmentAssociation, true);
                }
            }
        }
    }
}
