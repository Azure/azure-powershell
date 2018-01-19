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

using System.Collections;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Management.MachineLearning.CommitmentPlans.Models;

namespace Microsoft.Azure.Commands.MachineLearning
{
    using Common.Authentication.Abstractions;
    using ResourceManager.Common.ArgumentCompleters;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Cmdlet(VerbsData.Update, CommitmentPlansCmdletBase.CommitmentPlanCommandletSuffix, SupportsShouldProcess = true)]
    [OutputType(typeof(CommitmentPlan))]
    public class UpdateAzureMLCommitmentPlan : CommitmentPlansCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the resource group for the Azure ML commitment plan.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the Azure ML commitment plan.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the SKU to use when updating the Azure ML commitment plan.")]
        [ValidateNotNullOrEmpty]
        public string SkuName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The tier of the SKU to use when updating the Azure ML commitment plan.")]
        [ValidateNotNullOrEmpty]
        public string SkuTier { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The capacity of the SKU to use when updating the Azure ML commitment plan.")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(1, int.MaxValue)]
        public int SkuCapacity { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Tags for the commitment plan resource.")]
        [Obsolete("Update-AzureRmMlCommitmentPlan: -Tags will be removed in favor of -Tag in an upcoming breaking change release.  Please start using the -Tag parameter to avoid breaking scripts.")]
        [Alias("Tags")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

            /// <summary>
        /// Gets or sets a value that indicates if the user should be prompted for confirmation.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }
        
        protected override void RunCmdlet()
        {
            if (!ShouldProcess(this.Name, @"Updating Azure ML commitment plan."))
            {
                return;
            }

            if (!this.Force.IsPresent && !ShouldContinue(Resources.UpdateServiceWarning.FormatInvariant(this.Name), string.Empty))
            {
                return;
            }

            int skuCapacity = this.SkuCapacity == 0 ? 1 : this.SkuCapacity;
            var sku = new ResourceSku(skuCapacity, this.SkuName, this.SkuTier);

#pragma warning disable CS0618
            var tags = this.Tag.Cast<DictionaryEntry>()
                .ToDictionary(kvp => (string) kvp.Key, kvp => (string) kvp.Value);
#pragma warning restore CS0618

            CommitmentPlanPatchPayload patchPayload = new CommitmentPlanPatchPayload
            {
                Sku = sku,
                Tags = tags
            };

            this.CommitmentPlansClient.PatchAzureMlCommitmentPlan(this.ResourceGroupName, this.Name, patchPayload);
        }
    }
}
