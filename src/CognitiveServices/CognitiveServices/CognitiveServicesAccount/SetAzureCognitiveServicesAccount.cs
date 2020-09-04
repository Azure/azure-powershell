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

using Microsoft.Azure.Commands.Management.CognitiveServices.Models;
using Microsoft.Azure.Commands.Management.CognitiveServices.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json.Linq;
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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesAccount", SupportsShouldProcess = true, DefaultParameterSetName = CognitiveServicesEncryptionParameterSet), OutputType(typeof(CognitiveServicesModels.PSCognitiveServicesAccount))]
    public class SetAzureCognitiveServicesAccountCommand : CognitiveServicesAccountBaseCmdlet
    {
        /// <summary>
        /// CognitiveServices Encryption parameter set name
        /// </summary>
        private const string CognitiveServicesEncryptionParameterSet = "CognitiveServicesEncryption";

        /// <summary>
        /// KeyVault Encryption parameter set name
        /// </summary>
        private const string KeyVaultEncryptionParameterSet = "KeyVaultEncryption";

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
            HelpMessage = "Cognitive Services Account Name.")]
        [Alias(CognitiveServicesAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Sku Name.")]
        [AllowNull]
        public string SkuName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Cognitive Services Account Tags.")]
        [Alias(TagsAlias)]
        [AllowNull]
        [AllowEmptyCollection]
        public Hashtable[] Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Cognitive Services Account Subdomain Name.")]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public string CustomSubdomainName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Generate and assign a new Cognitive Services Account Identity for this storage account for use with key management services like Azure KeyVault.")]
        public SwitchParameter AssignIdentity { get; set; }

        [Parameter(
            HelpMessage = "Type of managed service identity.",
            Mandatory = false)]
        public IdentityType? IdentityType { get; set; }

        [Parameter(HelpMessage = "List of User Owned Storage Accounts.", Mandatory = false)]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public string[] StorageAccountId { get; set; }

        [Parameter(
            HelpMessage = "Whether to set Cognitive Services Account Encryption KeySource to Microsoft.CognitiveServices or not.",
            Mandatory = false,
            ParameterSetName = CognitiveServicesEncryptionParameterSet)]
        public SwitchParameter CognitiveServicesEncryption { get; set; }

        [Parameter(HelpMessage = "Whether to set Cognitive Services Account encryption keySource to Microsoft.KeyVault or not.",
            Mandatory = false,
            ParameterSetName = KeyVaultEncryptionParameterSet)]
        public SwitchParameter KeyVaultEncryption { get; set; }

        [Parameter(HelpMessage = "Cognitive Services Account encryption keySource KeyVault KeyName",
                    Mandatory = true,
                    ParameterSetName = KeyVaultEncryptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(HelpMessage = "Cognitive Services Account encryption keySource KeyVault KeyVersion",
        Mandatory = true,
        ParameterSetName = KeyVaultEncryptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyVersion { get; set; }

        [Parameter(HelpMessage = "Cognitive Services Account encryption keySource KeyVault KeyVaultUri",
        Mandatory = true,
        ParameterSetName = KeyVaultEncryptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyVaultUri
        {
            get; set;
        }

        [Parameter(
            Mandatory = false,
            HelpMessage = "NetworkRuleSet is used to define a set of configuration rules for firewalls and virtual networks, as well as to set values for network properties such as how to handle requests that don't match any of the defined rules")]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public PSNetworkRuleSet NetworkRuleSet { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The network access type for Cognitive Services Account. Commonly `Enabled` or `Disabled`.")]
        [ValidateSet("Enabled", "Disabled", IgnoreCase = true)]
        public string PublicNetworkAccess { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The ApiProperties of Cognitive Services Account. Required by specific account types.")]
        public CognitiveServicesAccountApiProperties ApiProperties { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            bool hasPropertiesChange = false;
            var properties = new CognitiveServicesAccountProperties();
            if (!string.IsNullOrWhiteSpace(CustomSubdomainName))
            {
                hasPropertiesChange = true;
                properties.CustomSubDomainName = CustomSubdomainName;
            }
            if (NetworkRuleSet != null)
            {
                hasPropertiesChange = true;
                properties.NetworkAcls = NetworkRuleSet.ToNetworkRuleSet();
            }
            if (ApiProperties != null)
            {
                hasPropertiesChange = true;
                properties.ApiProperties = ApiProperties;
            }

            Sku sku = null;
            if (!string.IsNullOrWhiteSpace(this.SkuName))
            {
                sku = new Sku(this.SkuName);
            }
            
            Dictionary<string, string> tags = null;
            if (this.Tag != null)
            {
                Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(Tag);
                tags = tagDictionary ?? new Dictionary<string, string>();
            }

            CognitiveServicesAccount updateParameters = new CognitiveServicesAccount()
            {
                Sku = sku,
                Tags = tags,
                Properties = properties
            };

            if (!string.IsNullOrEmpty(PublicNetworkAccess))
            {
                hasPropertiesChange = true;
                updateParameters.Properties.PublicNetworkAccess = PublicNetworkAccess;
            }

            if (AssignIdentity.IsPresent)
            {
                hasPropertiesChange = true;
                updateParameters.Identity = new Identity(Microsoft.Azure.Management.CognitiveServices.Models.IdentityType.SystemAssigned);
            }

            if (this.IsParameterBound(c => c.IdentityType))
            {
                hasPropertiesChange = true;
                updateParameters.Identity = new Identity(this.IdentityType);
            }

            if (CognitiveServicesEncryption.IsPresent)
            {
                hasPropertiesChange = true;
                updateParameters.Properties.Encryption = new Encryption(null, KeySource.MicrosoftCognitiveServices);
            }

            if (ParameterSetName == KeyVaultEncryptionParameterSet)
            {
                hasPropertiesChange = true;
                updateParameters.Properties.Encryption = new Encryption(
                    new KeyVaultProperties()
                    {
                        KeyName = KeyName,
                        KeyVersion = KeyVersion,
                        KeyVaultUri = KeyVaultUri
                    },
                    KeySource.MicrosoftKeyVault);
            }

            if (StorageAccountId != null && StorageAccountId.Length > 0)
            {
                hasPropertiesChange = true;
                updateParameters.Properties.UserOwnedStorage = new List<UserOwnedStorage>();
                foreach (var storageAccountId in StorageAccountId)
                {
                    updateParameters.Properties.UserOwnedStorage.Add(new UserOwnedStorage(storageAccountId));
                }
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
                if (!hasPropertiesChange)
                {
                    // Not updating anything (this is allowed) - just return the account, no need for approval.
                    var cognitiveServicesAccount = this.CognitiveServicesClient.Accounts.GetProperties(this.ResourceGroupName, this.Name);
                    WriteCognitiveServicesAccount(cognitiveServicesAccount);
                    return;
                }
                else
                {
                    processMessage = string.Format(CultureInfo.CurrentCulture, Resources.SetAccount_ProcessMessage, this.Name);
                }
            }

            if (ShouldProcess(
                this.Name, processMessage)
                ||
                Force.IsPresent)
            {
                RunCmdLet(() =>
                {
                    var updatedAccount = this.CognitiveServicesClient.Accounts.Update(
                        this.ResourceGroupName,
                        this.Name,
                        updateParameters
                        );

                    WriteCognitiveServicesAccount(updatedAccount);
                });
            }
        }
    }
}
