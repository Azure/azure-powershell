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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Get Available Skus for Cognitive Services Account
    /// </summary>
    [GenericBreakingChange("Get-AzCognitiveServicesAccountSkus alias will be removed in an upcoming breaking change release", "2.0.0")]
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesAccountSku", DefaultParameterSetName = GetSkusWithFilterParamSetName),
        OutputType(typeof(ResourceSku))]
    [Alias("Get-AzCognitiveServicesAccountSkus")]
    public class GetAzureCognitiveServicesAccountSkusCommand : CognitiveServicesAccountBaseCmdlet
    {
        protected const string GetSkusWithFilterParamSetName = "GetSkusWithFilter";

        [Parameter(
            ParameterSetName = GetSkusWithFilterParamSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Type.")]
        [Alias(CognitiveServicesAccountTypeAlias, AccountTypeAlias, KindAlias)]
        public string Type { get; set; }

        [Parameter(
            ParameterSetName = GetSkusWithFilterParamSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Location.")]
        [LocationCompleter("Microsoft.CognitiveServices/accounts")]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            RunCmdLet(() =>
            {
                var resourceSkus = this.CognitiveServicesClient.ResourceSkus.List().Where(
                    resourceSku =>
                    (string.IsNullOrWhiteSpace(this.Type) || resourceSku.Kind == this.Type)
                    && (string.IsNullOrWhiteSpace(this.Location) || resourceSku.Locations.Any(x => string.Compare(x, this.Location, StringComparison.OrdinalIgnoreCase) == 0))
                );

                WriteObject(resourceSkus, true);
            });
        }
    }
}
