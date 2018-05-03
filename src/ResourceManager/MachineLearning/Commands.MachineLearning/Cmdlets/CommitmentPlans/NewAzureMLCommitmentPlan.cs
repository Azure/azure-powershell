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
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Management.MachineLearning.CommitmentPlans.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.MachineLearning.Cmdlets
{

    [Cmdlet(VerbsCommon.New, CommitmentPlansCmdletBase.CommitmentPlanCommandletSuffix, SupportsShouldProcess = true)]
    [OutputType(typeof(CommitmentPlan))]
    public class NewAzureMLCommitmentPlan : CommitmentPlansCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the resource group for the Azure ML commitment plan.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The location of the Azure ML commitment plan.")]
        [LocationCompleter("Microsoft.MachineLearning/commitmentPlans")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }
        
        [Parameter(Mandatory = true, HelpMessage = "The name of the Azure ML commitment plan.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the SKU to use when provisioning the Azure ML commitment plan.")]
        [ValidateNotNullOrEmpty]
        public string SkuName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The tier of the SKU to use when provisioning the Azure ML commitment plan.")]
        [ValidateNotNullOrEmpty]
        public string SkuTier { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The capacity of the SKU to use when provisioning the Azure ML commitment plan.")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(1, int.MaxValue)]
        public int SkuCapacity { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates if the user should be prompted for confirmation.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        protected override void RunCmdlet()
        {
            this.ConfirmAction(
                this.Force.IsPresent,
                Resources.NewServiceWarning.FormatInvariant(this.Name), 
                "Creating the new commitment plan", 
                this.Name, 
                () =>
                {
                    int skuCapacity = this.SkuCapacity == 0 ? 1 : this.SkuCapacity;
                    ResourceSku sku = new ResourceSku(skuCapacity, this.SkuName, this.SkuTier);

                    CommitmentPlan newCommitmentPlan = this.CommitmentPlansClient.CreateOrUpdateAzureMlCommitmentPlan(
                                                    this.ResourceGroupName,
                                                    this.Location,
                                                    this.Name,
                                                    sku);

                    this.WriteObject(newCommitmentPlan);
                });
        }
    }
}
