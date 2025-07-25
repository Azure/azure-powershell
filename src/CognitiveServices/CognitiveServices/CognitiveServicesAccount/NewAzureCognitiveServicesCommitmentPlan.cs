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
using Microsoft.Azure.Commands.Management.CognitiveServices.Models;
using Microsoft.Azure.Commands.Management.CognitiveServices.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using CognitiveServicesModels = Microsoft.Azure.Commands.Management.CognitiveServices.Models;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesCommitmentPlan", SupportsShouldProcess = true), OutputType(typeof(CognitiveServicesModels.PSCognitiveServicesAccount))]
    public class NewAzureCognitiveServicesCommitmentPlanCommand : CognitiveServicesAccountBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Name.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^[a-zA-Z0-9][a-zA-Z0-9_.-]*$")]
        [ValidateLength(2, 64)]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account/CommitmentPlan Type.")]
        [Alias(KindAlias)]
        [AccountTypeCompleter()]
        public string Type { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account/CommitmentPlan Sku Name.")]
        [AccountSkuCompleter()]
        public string SkuName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services CommitmentPlan Location.")]
        [LocationCompleter("Microsoft.CognitiveServices/accounts")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Cognitive Services CommitmentPlan Tags.")]
        [Alias(TagsAlias)]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public Hashtable[] Tag { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services CommitmentPlan Properties.")]
        public CommitmentPlanProperties Properties { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                var createParameters = new CommitmentPlan()
                {
                    Location = Location,
                    Kind = Type,
                    Sku = new Sku(SkuName, null),
                    Properties = Properties,
                    Tags = TagsConversionHelper.CreateTagDictionary(Tag),
                };

                var createResponse = CognitiveServicesClient.CommitmentPlans.CreateOrUpdatePlan(
                                ResourceGroupName,
                                Name,
                                createParameters);

                var plan = CognitiveServicesClient.CommitmentPlans.GetPlan(ResourceGroupName, Name);

                WriteObject(plan);
            });
        }
    }
}
