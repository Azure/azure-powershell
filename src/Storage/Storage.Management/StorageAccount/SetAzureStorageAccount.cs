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

        /// <summary>
        /// Set ActiveDirectoryDomainServicesForFile parameter set name
        /// </summary>
        private const string ActiveDirectoryDomainServicesForFileParameterSet = "ActiveDirectoryDomainServicesForFile";

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
        [ValidateSet(StorageModels.SkuName.StandardLRS,
            StorageModels.SkuName.StandardZRS,
            StorageModels.SkuName.StandardGRS,
            StorageModels.SkuName.StandardRAGRS,
            StorageModels.SkuName.PremiumLRS,
            StorageModels.SkuName.StandardGZRS,
            StorageModels.SkuName.StandardRAGZRS,
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
        Mandatory = false,
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

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable Azure Files Azure Active Directory Domain Service Authentication for the storage account.",
            ParameterSetName = StorageEncryptionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable Azure Files Azure Active Directory Domain Service Authentication for the storage account.",
            ParameterSetName = KeyvaultEncryptionParameterSet)]
        [ValidateNotNullOrEmpty]
        public bool EnableAzureActiveDirectoryDomainServicesForFile
        {
            get
            {
                return enableAzureActiveDirectoryDomainServicesForFile.Value;
            }
            set
            {
                enableAzureActiveDirectoryDomainServicesForFile = value;
            }
        }
        private bool? enableAzureActiveDirectoryDomainServicesForFile = null;

        [Parameter(Mandatory = false, HelpMessage = "Indicates whether or not the storage account can support large file shares with more than 5 TiB capacity. Once the account is enabled, the feature cannot be disabled. Currently only supported for LRS and ZRS replication types, hence account conversions to geo-redundant accounts would not be possible. Learn more in https://go.microsoft.com/fwlink/?linkid=2086047")]
        public SwitchParameter EnableLargeFileShare { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Routing Choice defines the kind of network routing opted by the user. Possible values include: 'MicrosoftRouting', 'InternetRouting'")]
        [ValidateSet(
            Microsoft.Azure.Management.Storage.Models.RoutingChoice.MicrosoftRouting,
            Microsoft.Azure.Management.Storage.Models.RoutingChoice.InternetRouting,
            IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string RoutingChoice;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Indicates whether microsoft routing storage endpoints are to be published")]
        [ValidateNotNullOrEmpty]
        public bool PublishMicrosoftEndpoint
        {
            get
            {
                return publishMicrosoftEndpoint.Value;
            }
            set
            {
                publishMicrosoftEndpoint = value;
            }
        }
        private bool? publishMicrosoftEndpoint = null;
        
        [Parameter(
            Mandatory = false,
            HelpMessage = "Indicates whether internet  routing storage endpoints are to be published")]
        [ValidateNotNullOrEmpty]
        public bool PublishInternetEndpoint
        {
            get
            {
                return publishInternetEndpoint.Value;
            }
            set
            {
                publishInternetEndpoint = value;
            }
        }
        private bool? publishInternetEndpoint = null;
        
        [Parameter(
            Mandatory = true,
            HelpMessage = "Enable Azure Files Active Directory Domain Service Authentication for the storage account.",
            ParameterSetName = ActiveDirectoryDomainServicesForFileParameterSet)]
        [ValidateNotNullOrEmpty]
        public bool EnableActiveDirectoryDomainServicesForFile
        {
            get
            {
                return enableActiveDirectoryDomainServicesForFile.Value;
            }
            set
            {
                enableActiveDirectoryDomainServicesForFile = value;
            }
        }
        private bool? enableActiveDirectoryDomainServicesForFile = null;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies the primary domain that the AD DNS server is authoritative for. This parameter must be set when -EnableActiveDirectoryDomainServicesForFile is set to true.",
            ParameterSetName = ActiveDirectoryDomainServicesForFileParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ActiveDirectoryDomainName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies the NetBIOS domain name. This parameter must be set when -EnableActiveDirectoryDomainServicesForFile is set to true.",
            ParameterSetName = ActiveDirectoryDomainServicesForFileParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ActiveDirectoryNetBiosDomainName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies the Active Directory forest to get. This parameter must be set when -EnableActiveDirectoryDomainServicesForFile is set to true.",
            ParameterSetName = ActiveDirectoryDomainServicesForFileParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ActiveDirectoryForestName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies the domain GUID. This parameter must be set when -EnableActiveDirectoryDomainServicesForFile is set to true.",
            ParameterSetName = ActiveDirectoryDomainServicesForFileParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ActiveDirectoryDomainGuid { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies the security identifier (SID). This parameter must be set when -EnableActiveDirectoryDomainServicesForFile is set to true.",
            ParameterSetName = ActiveDirectoryDomainServicesForFileParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ActiveDirectoryDomainSid { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies the security identifier (SID) for Azure Storage. This parameter must be set when -EnableActiveDirectoryDomainServicesForFile is set to true.",
            ParameterSetName = ActiveDirectoryDomainServicesForFileParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ActiveDirectoryAzureStorageSid { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Allow or disallow public access to all blobs or containers in the storage account.")]
        [ValidateNotNullOrEmpty]
        public bool AllowBlobPublicAccess
        {
            get
            {
                return allowBlobPublicAccess.Value;
            }
            set
            {
                allowBlobPublicAccess = value;
            }
        }
        private bool? allowBlobPublicAccess = null;

        [Parameter(
            Mandatory = false,
            HelpMessage = "The minimum TLS version to be permitted on requests to storage.")]
        [ValidateSet(StorageModels.MinimumTlsVersion.TLS10,
            StorageModels.MinimumTlsVersion.TLS11,
            StorageModels.MinimumTlsVersion.TLS12,
            IgnoreCase = true)]
        public string MinimumTlsVersion
        {
            get
            {
                return minimumTlsVersion;
            }
            set
            {
                minimumTlsVersion = value;
            }
        }
        private string minimumTlsVersion = null;


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
                        updateParameters.Sku = new Sku(this.SkuName);
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
                    if (enableAzureActiveDirectoryDomainServicesForFile != null)
                    {
                        if (enableAzureActiveDirectoryDomainServicesForFile.Value) // enable AADDS
                        {
                            //if user want to enable AADDS, must first disable AD
                            var originStorageAccount = this.StorageClient.StorageAccounts.GetProperties(this.ResourceGroupName, this.Name);
                            if (originStorageAccount.AzureFilesIdentityBasedAuthentication != null 
                                && originStorageAccount.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions == DirectoryServiceOptions.AD)
                            {
                                throw new System.ArgumentException("The Storage account already enabled ActiveDirectoryDomainServicesForFile, please disable it by run this cmdlets with \"-EnableActiveDirectoryDomainServicesForFile $false\" before enable AzureActiveDirectoryDomainServicesForFile.");
                            }
                            updateParameters.AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication();
                            updateParameters.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions = DirectoryServiceOptions.AADDS;
                        }
                        else //Disable AADDS
                        {
                            // Only disable AADDS; else keep unchanged
                            var originStorageAccount = this.StorageClient.StorageAccounts.GetProperties(this.ResourceGroupName, this.Name);
                            if (originStorageAccount.AzureFilesIdentityBasedAuthentication == null
                                || originStorageAccount.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions == DirectoryServiceOptions.AADDS)
                            {
                                updateParameters.AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication();
                                updateParameters.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions = DirectoryServiceOptions.None;
                            }
                            else
                            {
                                updateParameters.AzureFilesIdentityBasedAuthentication = originStorageAccount.AzureFilesIdentityBasedAuthentication;
                            }
                        }
                    }
                    if (enableActiveDirectoryDomainServicesForFile != null)
                    {

                        if (enableActiveDirectoryDomainServicesForFile.Value) // Enable AD
                        {
                            if (string.IsNullOrEmpty(this.ActiveDirectoryDomainName)
                                || string.IsNullOrEmpty(this.ActiveDirectoryNetBiosDomainName)
                                || string.IsNullOrEmpty(this.ActiveDirectoryForestName)
                                || string.IsNullOrEmpty(this.ActiveDirectoryDomainGuid)
                                || string.IsNullOrEmpty(this.ActiveDirectoryDomainSid)
                                || string.IsNullOrEmpty(this.ActiveDirectoryAzureStorageSid)
                                )
                            {
                                throw new System.ArgumentNullException("ActiveDirectoryDomainName, ActiveDirectoryNetBiosDomainName, ActiveDirectoryForestName, ActiveDirectoryDomainGuid, ActiveDirectoryDomainSid, ActiveDirectoryAzureStorageSid",
                                    "To enable ActiveDirectoryDomainServicesForFile, user must specify all of: ActiveDirectoryDomainName, ActiveDirectoryNetBiosDomainName, ActiveDirectoryForestName, ActiveDirectoryDomainGuid, ActiveDirectoryDomainSid, ActiveDirectoryAzureStorageSid.");
                            }

                            //if user want to enable AD, must first disable AADDS
                            var originStorageAccount = this.StorageClient.StorageAccounts.GetProperties(this.ResourceGroupName, this.Name);
                            if (originStorageAccount.AzureFilesIdentityBasedAuthentication != null
                                && originStorageAccount.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions == DirectoryServiceOptions.AADDS)
                            {
                                throw new System.ArgumentException("The Storage account already enabled AzureActiveDirectoryDomainServicesForFile, please disable it by run this cmdlets with \"-EnableAzureActiveDirectoryDomainServicesForFile $false\" before enable ActiveDirectoryDomainServicesForFile.");
                            }

                            updateParameters.AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication();
                            updateParameters.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions = DirectoryServiceOptions.AD;
                            updateParameters.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties = new ActiveDirectoryProperties()
                            {
                                DomainName = this.ActiveDirectoryDomainName,
                                NetBiosDomainName = this.ActiveDirectoryNetBiosDomainName,
                                ForestName = this.ActiveDirectoryForestName,
                                DomainGuid = this.ActiveDirectoryDomainGuid,
                                DomainSid = this.ActiveDirectoryDomainSid,
                                AzureStorageSid = this.ActiveDirectoryAzureStorageSid
                            };
                        }
                        else // Disable AD
                        {
                            if (!string.IsNullOrEmpty(this.ActiveDirectoryDomainName)
                                || !string.IsNullOrEmpty(this.ActiveDirectoryNetBiosDomainName)
                                || !string.IsNullOrEmpty(this.ActiveDirectoryForestName)
                                || !string.IsNullOrEmpty(this.ActiveDirectoryDomainGuid)
                                || !string.IsNullOrEmpty(this.ActiveDirectoryDomainSid)
                                || !string.IsNullOrEmpty(this.ActiveDirectoryAzureStorageSid)
                                )
                            {
                                throw new System.ArgumentException("To Disable ActiveDirectoryDomainServicesForFile, user can't specify any of: ActiveDirectoryDomainName, ActiveDirectoryNetBiosDomainName, ActiveDirectoryForestName, ActiveDirectoryDomainGuid, ActiveDirectoryDomainSid, ActiveDirectoryAzureStorageSid.");
                            }

                            // Only disable AD; else keep unchanged
                            var originStorageAccount = this.StorageClient.StorageAccounts.GetProperties(this.ResourceGroupName, this.Name);
                            if (originStorageAccount.AzureFilesIdentityBasedAuthentication == null
                                || originStorageAccount.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions == DirectoryServiceOptions.AD)
                            {
                                updateParameters.AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication();
                                updateParameters.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions = DirectoryServiceOptions.None;
                            }
                            else
                            {
                                updateParameters.AzureFilesIdentityBasedAuthentication = originStorageAccount.AzureFilesIdentityBasedAuthentication;
                            }
                        }
                    }
                    if (this.EnableLargeFileShare.IsPresent)
                    {
                        updateParameters.LargeFileSharesState = LargeFileSharesState.Enabled;
                    }
                    if (this.minimumTlsVersion != null)
                    {
                        updateParameters.MinimumTlsVersion = this.minimumTlsVersion;
                    }
                    if (this.allowBlobPublicAccess != null)
                    {
                        updateParameters.AllowBlobPublicAccess = this.allowBlobPublicAccess;
                    }
                    if (this.RoutingChoice != null || this.publishMicrosoftEndpoint != null || this.publishInternetEndpoint != null)
                    { 
                        updateParameters.RoutingPreference = new RoutingPreference(this.RoutingChoice, this.publishMicrosoftEndpoint, this.publishInternetEndpoint);
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
