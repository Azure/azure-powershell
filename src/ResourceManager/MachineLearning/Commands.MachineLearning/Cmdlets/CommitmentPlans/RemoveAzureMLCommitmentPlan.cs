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

namespace Microsoft.Azure.Commands.MachineLearning
{
    using System;
    using Management.MachineLearning.CommitmentPlans.Models;
    using Utilities;
    using Common.Authentication.Abstractions;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet(VerbsCommon.Remove, CommitmentPlansCmdletBase.CommitmentPlanCommandletSuffix, SupportsShouldProcess = true)]
    [OutputType(typeof(void))]
    public class RemoveAzureMLCommitmentPlan : CommitmentPlansCmdletBase
    {
        protected const string RemoveByNameGroupParameterSet = "RemoveByNameAndResourceGroup";
        protected const string RemoveByObjectParameterSet = "RemoveByObject";

        [Parameter(
            ParameterSetName = RemoveAzureMLCommitmentPlan.RemoveByNameGroupParameterSet,
            Mandatory = true,
            HelpMessage = "The name of the resource group for the Azure ML commitment plan.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = RemoveAzureMLCommitmentPlan.RemoveByNameGroupParameterSet,
            Mandatory = true,
            HelpMessage = "The name of the Azure ML commitment plan.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = RemoveAzureMLCommitmentPlan.RemoveByObjectParameterSet,
            Mandatory = true,
            HelpMessage = "The machine learning web service object.",
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public CommitmentPlan MlCommitmentPlan { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates if the user should be prompted for confirmation.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        protected override void RunCmdlet()
        {
            if (!ShouldProcess(this.Name, @"Deleting Azure ML commitment plan."))
            {
                return;
            }

            if (string.Equals(this.ParameterSetName, RemoveAzureMLCommitmentPlan.RemoveByObjectParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                string subscriptionId;
                string resourceGroup;
                string commitmentPlanName;

                if (!CmdletHelpers.TryParseMlResourceMetadataFromResourceId(
                                    this.MlCommitmentPlan.Id,
                                    out subscriptionId,
                                    out resourceGroup,
                                    out commitmentPlanName))
                {
                    throw new ValidationMetadataException(Resources.InvalidWebServiceIdOnObject);
                }

                this.ResourceGroupName = resourceGroup;
                this.Name = commitmentPlanName;
            }

            if (!this.Force.IsPresent && !ShouldContinue(Resources.RemoveMlServiceWarning.FormatInvariant(this.Name), string.Empty))
            {
                return;
            }

            this.CommitmentPlansClient.GetAzureMlCommitmentPlan(this.ResourceGroupName, this.Name);
            this.CommitmentPlansClient.RemoveAzureMlCommitmentPlan(this.ResourceGroupName, this.Name);
        }
    }
}
