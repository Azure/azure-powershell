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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using Microsoft.Azure.Commands.Management.CognitiveServices.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Get Available Skus for Cognitive Services Account
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesAccountSkus", DefaultParameterSetName = GetSkusWithAccountParamSetName),
        OutputType(typeof(PSCognitiveServicesSkus), typeof(ResourceSku))]
    public class GetAzureCognitiveServicesAccountSkusCommand : CognitiveServicesAccountBaseCmdlet
    {
        protected const string GetSkusWithAccountParamSetName = "GetSkusWithAccount";
        protected const string GetSkusWithFilterParamSetName = "GetSkusWithFilter";

        [Parameter(
            ParameterSetName = GetSkusWithFilterParamSetName,
            Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Type.")]
        [Alias(CognitiveServicesAccountTypeAlias, AccountTypeAlias, KindAlias)]
        public string Type { get; set; }

        [Parameter(
            ParameterSetName = GetSkusWithFilterParamSetName,
            Position = 1,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Location.")]
        [LocationCompleter("Microsoft.CognitiveServices/accounts")]
        public string Location { get; set; }

        [Parameter(
            ParameterSetName = GetSkusWithAccountParamSetName,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = GetSkusWithAccountParamSetName,
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Name.")]
        [Alias(CognitiveServicesAccountNameAlias, AccountNameAlias)]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            RunCmdLet(() =>
            {
                if (!string.IsNullOrEmpty(this.Name))
                {
                    if (string.IsNullOrEmpty(this.ResourceGroupName))
                    {
                        throw new ErrorException("ResourceGroupName must present when Name is indicated.");
                    }

                    // keep compatibility with old behavior but give warnings.
                    WriteWarningWithTimestamp("Get Available Skus with an existing Cognitive Services Account is deprecated and will be removed in a future version.");

                    var cognitiveServicesSkus = this.CognitiveServicesClient.Accounts.ListSkus(
                         this.ResourceGroupName,
                         this.Name);

                    WriteObject(cognitiveServicesSkus);
                }
                else
                {
                    var cognitiveServicesSkus = this.CognitiveServicesClient.ResourceSkus.List().Where(
                        resourceSku =>
                        (string.IsNullOrWhiteSpace(this.Type) || resourceSku.Kind == this.Type)
                        && (string.IsNullOrWhiteSpace(this.Location) || resourceSku.Locations.Any(x => string.Compare(x, this.Location, StringComparison.OrdinalIgnoreCase) == 0))
                    );

                    WriteObject(cognitiveServicesSkus);
                }
            });
        }
    }
}
