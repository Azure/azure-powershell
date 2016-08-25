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

using Microsoft.Azure.Commands.Management.CognitiveServices.Properties;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using CognitiveServicesModels = Microsoft.Azure.Commands.Management.CognitiveServices.Models;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Update a Cognitive Services Account (change SKU, Tags)
    /// </summary>
    [Cmdlet(VerbsCommon.Set, CognitiveServicesAccountNounStr, SupportsShouldProcess = true), OutputType(typeof(CognitiveServicesModels.PSCognitiveServicesAccount))]
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
        [ValidateSet(
            AccountSkuString.F0, 
            AccountSkuString.S0, 
            AccountSkuString.S1, 
            AccountSkuString.S2, 
            AccountSkuString.S3, 
            AccountSkuString.S4, 
            IgnoreCase = true)]
        public string SkuName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Tags.")]
        [Alias(TagsAlias)]
        [AllowNull]
        [AllowEmptyCollection]
        public Hashtable[] Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Sku sku = null;
            if (!string.IsNullOrWhiteSpace(this.SkuName))
            {
                sku = new Sku(ParseSkuName(this.SkuName));
            }
            
            Dictionary<string, string> tags = null;
            if (this.Tag != null)
            {
                Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(Tag);
                tags = tagDictionary ?? new Dictionary<string, string>();
            }

            string processMessage = string.Empty;
            if (sku != null && tags != null)
            {
                processMessage = string.Format(CultureInfo.CurrentCulture, Resources.SetAccount_ProcessMessage_UpdateSkuAndTags, this.Name, sku.Name);
            }
            else if (sku != null) 
            {
                processMessage = string.Format(CultureInfo.CurrentCulture, Resources.SetAccount_ProcessMessage_UpdateSku, this.Name, sku.Name);
            }
            else if (tags != null)
            {
                processMessage = string.Format(CultureInfo.CurrentCulture, Resources.SetAccount_ProcessMessage_UpdateTags, this.Name);
            }
            else
            {
                // Not updating anything (this is allowed) - just return the account, no need for approval.
                var cognitiveServicesAccount = this.CognitiveServicesClient.CognitiveServicesAccounts.GetProperties(this.ResourceGroupName, this.Name);
                WriteCognitiveServicesAccount(cognitiveServicesAccount);
                return;
            }

            if (ShouldProcess(
                this.Name, processMessage)
                ||
                Force.IsPresent)
            {
                RunCmdLet(() =>
                {
                    var updatedAccount = this.CognitiveServicesClient.CognitiveServicesAccounts.Update(
                        this.ResourceGroupName,
                        this.Name,
                        sku,
                        tags);

                    WriteCognitiveServicesAccount(updatedAccount);
                });
            }
        }
    }
}
