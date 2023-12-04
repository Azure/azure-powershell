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

using Microsoft.Azure.Commands.Management.CognitiveServices.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using System.Collections;
using System.Management.Automation;
using CognitiveServicesModels = Microsoft.Azure.Commands.Management.CognitiveServices.Models;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesCommitmentPlanAssociation", SupportsShouldProcess = true), OutputType(typeof(CognitiveServicesModels.PSCognitiveServicesAccount))]
    public class NewAzureCognitiveServicesCommitmentPlanAssociationCommand : CognitiveServicesAccountBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services CommitmentPlan Name.")]
        [ValidateNotNullOrEmpty]
        public string CommitmentPlanName { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services CommitmentPlan Association Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Resource ID.")]
        [AccountSkuCompleter()]
        public string AccountId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                var createAccountResponse = CognitiveServicesClient.CommitmentPlans.CreateOrUpdateAssociation(
                                ResourceGroupName,
                                CommitmentPlanName,
                                Name,
                                null,
                                AccountId);

                var cognitiveServicesAccount = CognitiveServicesClient.CommitmentPlans.GetAssociation(ResourceGroupName, CommitmentPlanName, Name);

                WriteObject(cognitiveServicesAccount);
            });
        }
    }
}
