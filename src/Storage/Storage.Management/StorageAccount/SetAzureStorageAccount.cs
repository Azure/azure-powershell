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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using StorageModels = Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;

namespace Microsoft.Azure.Commands.Management.Storage
{
    /// <summary>
    /// Lists all storage services underneath the subscription.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageAccount", SupportsShouldProcess = true, DefaultParameterSetName = StorageEncryptionParameterSet), OutputType(typeof(PSStorageAccount))]
    public class SetAzureStorageAccountCommand : StorageAccountBaseCmdlet
    {

        /// <summary>
        /// Storage Encryption parameter set name
        /// </summary>
        private const string StorageEncryptionParameterSet = "StorageEncryption";

        /// <summary>
        /// Keyvault Encryption parameter set name
        /// </summary>
        private const string KeyvaultEncryptionParameterSet = "KeyvaultEncryption";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Name.")]
        [Alias(StorageAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Force to Set the Account")]
        public SwitchParameter Force
        {
            get { return force; }
            set { force = value; }
        }
        private bool force = false;

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Sku Name.")]
        [Alias(StorageAccountTypeAlias, AccountTypeAlias, Account_TypeAlias)]
        [ValidateSet(AccountTypeString.StandardLRS,
            AccountTypeString.StandardZRS,
            AccountTypeString.StandardGRS,
            AccountTypeString.StandardRAGRS,
            AccountTypeString.PremiumLRS,
            IgnoreCase = true)]
        public string SkuName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account Access Tier.")]
        [ValidateSet(AccountAccessTier.Hot,
            AccountAccessTier.Cool,
            IgnoreCase = true)]
        public string AccessTier { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account Custom Domain.")]
        [ValidateNotNull]
        public string CustomDomainName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "To Use Sub Domain.")]
        [ValidateNotNullOrEmpty]
        public bool? UseSubDomain { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Tags.")]
        [AllowEmptyCollection]
        [ValidateNotNull]
        [Alias(TagsAlias)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account EnableHttpsTrafficOnly.")]
        public bool EnableHttpsTrafficOnly
        {
            get
            {
                return enableHttpsTrafficOnly != null ? enableHttpsTrafficOnly.Value : false;
            }
            set
            {
                enableHttpsTrafficOnly = value;
            }
        }
        private bool? enableHttpsTrafficOnly = null;

        [Parameter(HelpMessage = "Whether to set Storage Account Encryption KeySource to Microsoft.Storage or not.", Mandatory = false, ParameterSetName = StorageEncryptionParameterSet)]
        public SwitchParameter StorageEncryption
        {
            get { return storageEncryption; }
            set { storageEncryption = value; }
        }
        private bool storageEncryption = false;

        [Parameter(HelpMessage = "Whether to set Storage Account encryption keySource to Microsoft.Keyvault or not. " +
            "If you specify KeyName, KeyVersion and KeyvaultUri, Storage Account Encryption KeySource will also be set to Microsoft.Keyvault weather this parameter is set or not.",
            Mandatory = false, ParameterSetName = KeyvaultEncryptionParameterSet)]
        public SwitchParameter KeyvaultEncryption
        {
            get { return keyvaultEncryption; }
            set { keyvaultEncryption = value; }
        }
        private bool keyvaultEncryption = false;

        [Parameter(HelpMessage = "Storage Account encryption keySource KeyVault KeyName",
                    Mandatory = true,
                    ParameterSetName = KeyvaultEncryptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(HelpMessage = "Storage Account encryption keySource KeyVault KeyVersion",
        Mandatory = true,
        ParameterSetName = KeyvaultEncryptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyVersion { get; set; }

        [Parameter(HelpMessage = "Storage Account encryption keySource KeyVault KeyVaultUri",
        Mandatory = true,
        ParameterSetName = KeyvaultEncryptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string KeyVaultUri
        {
            get; set;
        }

        [Parameter(
        Mandatory = false,
        HelpMessage = "Generate and assign a new Storage Account Identity for this storage account for use with key management services like Azure KeyVault.")]
        public SwitchParameter AssignIdentity { get; set; }

        [Parameter(HelpMessage = "Storage Account NetworkRule",
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public PSNetworkRuleSet NetworkRuleSet
        {
            get; set;
        }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Upgrade Storage Account Kind to StorageV2.")]
        public SwitchParameter UpgradeToStorageV2 { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.Name, "Set Storage Account"))
            {
                if (this.force || this.AccessTier == null || ShouldContinue("Changing the access tier may result in additional charges. See (http://go.microsoft.com/fwlink/?LinkId=786482) to learn more.", ""))
                {
                    StorageAccountUpdateParameters updateParameters = new StorageAccountUpdateParameters();
                    if (this.SkuName != null)
                    {
                        updateParameters.Sku = new Sku(ParseSkuName(this.SkuName));
                    }

                    if (this.Tag != null)
                    {
                        Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);
                        updateParameters.Tags = tagDictionary ?? new Dictionary<string, string>();
                    }

                    if (this.CustomDomainName != null)
                    {
                        updateParameters.CustomDomain = new CustomDomain()
                        {
                            Name = CustomDomainName,
                            UseSubDomainName = UseSubDomain
                        };
                    }
                    else if (UseSubDomain != null)
                    {
                        throw new System.ArgumentException(string.Format("UseSubDomain must be set together with CustomDomainName."));
                    }

                    if (this.AccessTier != null)
                    {
                        updateParameters.AccessTier = ParseAccessTier(AccessTier);
                    }
                    if (enableHttpsTrafficOnly != null)
                    {
                        updateParameters.EnableHttpsTrafficOnly = enableHttpsTrafficOnly;
                    }

                    if (AssignIdentity.IsPresent)
                    {
                        updateParameters.Identity = new Identity();
                    }

                    if (StorageEncryption || (ParameterSetName == KeyvaultEncryptionParameterSet))
                    {
                        if (ParameterSetName == KeyvaultEncryptionParameterSet)
                        {
                            keyvaultEncryption = true;
                        }
                        updateParameters.Encryption = ParseEncryption(StorageEncryption, keyvaultEncryption, KeyName, KeyVersion, KeyVaultUri);
                    }
                    if (NetworkRuleSet != null)
                    {
                        updateParameters.NetworkRuleSet = PSNetworkRuleSet.ParseStorageNetworkRule(NetworkRuleSet);
                    }

                    if (UpgradeToStorageV2.IsPresent)
                    {
                        updateParameters.Kind = Kind.StorageV2;
                    }

                    var updatedAccountResponse = this.StorageClient.StorageAccounts.Update(
                        this.ResourceGroupName,
                        this.Name,
                        updateParameters);

                    var storageAccount = this.StorageClient.StorageAccounts.GetProperties(this.ResourceGroupName, this.Name);

                    WriteStorageAccount(storageAccount);
                }
            }
        }
    }
}
