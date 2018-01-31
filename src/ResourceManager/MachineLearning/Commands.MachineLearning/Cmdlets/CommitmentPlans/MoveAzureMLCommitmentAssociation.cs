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
using Microsoft.Azure.Management.MachineLearning.CommitmentPlans.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.MachineLearning
{
    [Cmdlet(VerbsCommon.Move, CommitmentPlansCmdletBase.CommitmentAssociationCommandletSuffix, SupportsShouldProcess = true)]
    [OutputType(typeof(CommitmentPlan), typeof(CommitmentPlan[]))]
    public class MoveAzureMLCommitmentAssociation : CommitmentPlansCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the resource group for the Azure ML commitment association.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the Azure ML commitment plan.")]
        [ValidateNotNullOrEmpty]
        public string CommitmentPlanName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the Azure ML commitment association.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The Azure resource ID of the destination Azure ML commitment plan.")]
        [ValidateNotNullOrEmpty]
        public string DestinationPlanId { get; set; }

        protected override void RunCmdlet()
        {
            if (!ShouldProcess(this.Name, @"Moving Azure ML commitment association."))
            {
                return;
            }

            CommitmentAssociation commitmentAssociation =
                this.CommitmentPlansClient.MoveCommitmentAssociationAsync(
                    this.ResourceGroupName,
                    this.CommitmentPlanName,
                    this.Name,
                    this.DestinationPlanId,
                    this.CancellationToken).Result;

            this.WriteObject(commitmentAssociation, true);
        }
    }
}
