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

using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using CognitiveServicesModels = Microsoft.Azure.Management.CognitiveServices.Models;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Update a Cognitive Services Account (change SKU, Tags)
    /// </summary>
    [Cmdlet(VerbsCommon.Set, CognitiveServicesAccountNounStr), OutputType(typeof(CognitiveServicesModels.CognitiveServicesAccount))]
    public class SetAzureCognitiveServicesAccountCommand : CognitiveServicesAccountBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Name.")]
        [Alias(CognitiveServicesAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Sku Name.")]
        [AllowNull]
        [ValidateSet(AccountSkuString.F0, AccountSkuString.S0, AccountSkuString.S1, AccountSkuString.S2, AccountSkuString.S3, AccountSkuString.S4, IgnoreCase = true)]
        public string SkuName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Tags.")]
        [AllowNull]
        [AllowEmptyCollection]
        public Hashtable[] Tags { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            Sku sku = null;
            if (!string.IsNullOrWhiteSpace(this.SkuName))
            {
                sku = new Sku(ParseSkuName(this.SkuName));
            }
            
            Dictionary<string, string> tags = null;
            if (this.Tags != null)
            {
                Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(Tags, validate: true);
                tags = tagDictionary ?? new Dictionary<string, string>();
            }

            var updatedAccountResponse = this.CognitiveServicesClient.CognitiveServicesAccounts.Update(
                this.ResourceGroupName,
                this.Name,
                sku,
                tags);

            var cognitiveServicesAccount = this.CognitiveServicesClient.CognitiveServicesAccounts.GetProperties(this.ResourceGroupName, this.Name);

            WriteCognitiveServicesAccount(cognitiveServicesAccount);
        }
    }
}
