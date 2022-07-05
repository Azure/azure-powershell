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
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using Track2 = Azure.ResourceManager.Models;
using Track2Models = Azure.ResourceManager.Storage.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Azure.Core;

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
        [ValidateSet(
            SkuNameType.StandardLRS,
            SkuNameType.StandardZRS,
            SkuNameType.StandardGRS,
            SkuNameType.StandardRagrs,
            SkuNameType.PremiumLRS,
            SkuNameType.StandardGzrs,
            SkuNameType.StandardRagzrs,
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
        [ValidateNotNull]
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

        [Parameter(
            Mandatory = false,
            HelpMessage = "Set resource ids for the the new Storage Account user assignedd Identity, the identity will be used with key management services like Azure KeyVault.")]
        [ValidateNotNull]
        public string UserAssignedIdentityId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Set resource id for user assigned Identity used to access Azure KeyVault of Storage Account Encryption, the id must in the storage account's UserAssignIdentityId.")]
        [ValidateNotNull]
        public string KeyVaultUserAssignedIdentityId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Set the new Storage Account Identity type, the idenetity is for use with key management services like Azure KeyVault.")]
        [ValidateSet(AccountIdentityType.SystemAssigned,
            AccountIdentityType.UserAssigned,
            AccountIdentityType.SystemAssignedUserAssigned,
            AccountIdentityType.None,
            IgnoreCase = true)]
        public string IdentityType { get; set; }

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
            RoutingChoiceType.MicrosoftRouting,
            RoutingChoiceType.InternetRouting,
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
            HelpMessage = "Specifies the Active Directory SAMAccountName for Azure Storage.",
            ParameterSetName = ActiveDirectoryDomainServicesForFileParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ActiveDirectorySamAccountName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies the Active Directory account type for Azure Storage. Possible values include: 'User', 'Computer'.",
            ParameterSetName = ActiveDirectoryDomainServicesForFileParameterSet)]
        [PSArgumentCompleter("User", "Computer")]
        [ValidateNotNullOrEmpty]
        public string ActiveDirectoryAccountType { get; set; }

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
        [ValidateSet(
            MinimumTlsVersionType.TLS10,
            MinimumTlsVersionType.TLS11,
            MinimumTlsVersionType.TLS12,
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

        [Parameter(
            Mandatory = false,
            HelpMessage = "Indicates whether the storage account permits requests to be authorized with the account access key via Shared Key. " +
            "If false, then all requests, including shared access signatures, must be authorized with Azure Active Directory (Azure AD). " +
            "The default value is null, which is equivalent to true.")]
        [ValidateNotNullOrEmpty]
        public bool AllowSharedKeyAccess
        {
            get
            {
                return allowSharedKeyAccess.Value;
            }
            set
            {
                allowSharedKeyAccess = value;
            }
        }
        private bool? allowSharedKeyAccess = null;

        [Parameter(Mandatory = false, HelpMessage = "The SAS expiration period of this account, it is a timespan and accurate to seconds.")]
        public TimeSpan SasExpirationPeriod
        {
            get
            {
                return sasExpirationPeriod is null ? TimeSpan.Zero : sasExpirationPeriod.Value;
            }
            set
            {
                sasExpirationPeriod = value;
            }
        }
        private TimeSpan? sasExpirationPeriod = null;

        [Parameter(Mandatory = false, HelpMessage = "The Key expiration period of this account, it is accurate to days.")]
        public int KeyExpirationPeriodInDay
        {
            get
            {
                return keyExpirationPeriodInDay.Value;
            }
            set
            {
                keyExpirationPeriodInDay = value;
            }
        }
        private int? keyExpirationPeriodInDay = null;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets allow or disallow cross AAD tenant object replication. The default interpretation is true for this property.")]
        [ValidateNotNullOrEmpty]
        public bool AllowCrossTenantReplication
        {
            get
            {
                return allowCrossTenantReplication.Value;
            }
            set
            {
                allowCrossTenantReplication = value;
            }
        }
        private bool? allowCrossTenantReplication = null;


        [Parameter(
            Mandatory = false,
            HelpMessage = "Default share permission for users using Kerberos authentication if RBAC role is not assigned.")]
        [ValidateSet(DefaultSharePermissionType.None,
            DefaultSharePermissionType.StorageFileDataSmbShareContributor,
            DefaultSharePermissionType.StorageFileDataSmbShareReader,
            DefaultSharePermissionType.StorageFileDataSmbShareElevatedContributor,
            IgnoreCase = true)]
        public string DefaultSharePermission { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Allow or disallow public network access to Storage Account.Possible values include: 'Enabled', 'Disabled'.")]
        [PSArgumentCompleter("Enabled", "Disabled")]
        [ValidateNotNullOrEmpty]
        public string PublicNetworkAccess { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The immutability period for the blobs in the container since the policy creation in days. This property can only be changed when account is created with '-EnableAccountLevelImmutability'.")]
        public int ImmutabilityPeriod
        {
            get
            {
                return immutabilityPeriod is null ? 0 : immutabilityPeriod.Value;
            }
            set
            {
                immutabilityPeriod = value;
            }
        }
        private int? immutabilityPeriod;

        [Parameter(
            Mandatory = false,
            HelpMessage = "The mode of the policy. Possible values include: 'Unlocked', 'Locked', 'Disabled. " +
            "Disabled state disablesthe policy. " +
            "Unlocked state allows increase and decrease of immutability retention time and also allows toggling allowProtectedAppendWrites property. " +
            "Locked state only allows the increase of the immutability retention time. " +
            "A policy can only be created in a Disabled or Unlocked state and can be toggled between the two states. Only a policy in an Unlocked state can transition to a Locked state which cannot be reverted. " +
            "This property can only be changed when account is created with '-EnableAccountLevelImmutability'.")]
        [PSArgumentCompleter("Disabled", "Unlocked", "Locked")]
        [ValidateNotNullOrEmpty]
        public string ImmutabilityPolicyState { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.Name, "Set Storage Account"))
            {
                if (this.force || this.AccessTier == null || ShouldContinue("Changing the access tier may result in additional charges. See (http://go.microsoft.com/fwlink/?LinkId=786482) to learn more.", ""))
                {

                    Track2Models.StorageAccountPatch storageAccountPatch = new Track2Models.StorageAccountPatch();

                    if (this.SkuName != null)
                    {
                        storageAccountPatch.Sku = new Track2Models.StorageSku(new Track2Models.StorageSkuName(this.SkuName));
                    }

                    if (this.Tag != null)
                    {
                        Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);
                        tagDictionary.ForEach(kv => storageAccountPatch.Tags.Add(kv.Key, kv.Value));
                    }

                    if (this.CustomDomainName != null)
                    {
                        storageAccountPatch.CustomDomain = new Track2Models.CustomDomain(this.CustomDomainName);
                        storageAccountPatch.CustomDomain.UseSubDomainName = this.UseSubDomain;

                    }
                    else if (UseSubDomain != null)
                    {
                        throw new System.ArgumentException(string.Format("UseSubDomain must be set together with CustomDomainName."));
                    }

                    if (this.AccessTier != null)
                    {
                        storageAccountPatch.AccessTier = ParseAccessTier(this.AccessTier);
                    }
                    if (enableHttpsTrafficOnly != null)
                    {
                        storageAccountPatch.EnableHttpsTrafficOnly = enableHttpsTrafficOnly;
                    }

                    if (AssignIdentity.IsPresent || this.UserAssignedIdentityId != null || this.IdentityType != null)
                    {
                        storageAccountPatch.Identity = new Track2.ManagedServiceIdentity(Track2.ManagedServiceIdentityType.SystemAssigned);
                        if (this.IdentityType != null)
                        {
                            if (this.IdentityType == AccountIdentityType.SystemAssignedUserAssigned)
                            {
                                storageAccountPatch.Identity.ManagedServiceIdentityType = new Track2.ManagedServiceIdentityType(AccountIdentityType.SystemAssignedUserAssignedTrack2);
                            } else
                            {
                                storageAccountPatch.Identity.ManagedServiceIdentityType = new Track2.ManagedServiceIdentityType(this.IdentityType);
                            }
                        }
                        if (this.UserAssignedIdentityId != null)
                        {
                            if (storageAccountPatch.Identity.ManagedServiceIdentityType != AccountIdentityType.UserAssigned && storageAccountPatch.Identity.ManagedServiceIdentityType != AccountIdentityType.SystemAssignedUserAssignedTrack2)
                            {
                                throw new ArgumentException("UserAssignIdentityId should only be specified when AssignIdentityType is UserAssigned or SystemAssignedUserAssigned.", "UserAssignIdentityId");
                            }

                            storageAccountPatch.Identity.UserAssignedIdentities.Add(new ResourceIdentifier(this.UserAssignedIdentityId), new global::Azure.ResourceManager.Models.UserAssignedIdentity());

                            var accountProperties = this.StorageClientTrack2.GetSingleStorageAccount(this.ResourceGroupName, this.Name);


                            if (accountProperties.Data.Identity != null && accountProperties.Data.Identity.UserAssignedIdentities != null && accountProperties.Data.Identity.UserAssignedIdentities.Count > 0)
                            {
                                foreach (var uid in accountProperties.Data.Identity.UserAssignedIdentities)
                                {
                                    if (!uid.Key.ToString().Equals(this.UserAssignedIdentityId, StringComparison.OrdinalIgnoreCase))
                                    {
                                        storageAccountPatch.Identity.UserAssignedIdentities.Add(uid.Key, null);
                                    }
                                }
                            }
                        } 
                    }

                    if (StorageEncryption || ParameterSetName == KeyvaultEncryptionParameterSet || this.KeyVaultUserAssignedIdentityId != null)
                    {
                        if (ParameterSetName == KeyvaultEncryptionParameterSet)
                        {
                            keyvaultEncryption = true;
                        }

                        storageAccountPatch.Encryption = ParseEncryption(StorageEncryption, keyvaultEncryption, KeyName, KeyVersion, KeyVaultUri);

                        if (this.KeyVaultUserAssignedIdentityId != null)
                        {
                            storageAccountPatch.Encryption.EncryptionIdentity = new Track2Models.EncryptionIdentity
                            {
                                EncryptionUserAssignedIdentity = this.KeyVaultUserAssignedIdentityId
                            };
                        }
                    }

                    if (NetworkRuleSet != null)
                    {
                        storageAccountPatch.NetworkRuleSet = PSNetworkRuleSet.ParseStorageNetworkRule(NetworkRuleSet);
                    }

                    if (UpgradeToStorageV2.IsPresent)
                    {
                        storageAccountPatch.Kind = Track2Models.StorageKind.StorageV2;
                    }
                    if (enableAzureActiveDirectoryDomainServicesForFile != null)
                    {
                        if (enableAzureActiveDirectoryDomainServicesForFile.Value) // enable AADDS
                        {
                            //if user want to enable AADDS, must first disable AD

                            var originStorageAccount = this.StorageClientTrack2.GetSingleStorageAccount(this.ResourceGroupName, this.Name);

                            if (originStorageAccount.Data.AzureFilesIdentityBasedAuthentication != null
                                && originStorageAccount.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions == Track2Models.DirectoryServiceOption.AD)
                            {
                                throw new System.ArgumentException("The Storage account already enabled ActiveDirectoryDomainServicesForFile, please disable it by run this cmdlets with \"-EnableActiveDirectoryDomainServicesForFile $false\" before enable AzureActiveDirectoryDomainServicesForFile.");
                            }

                            storageAccountPatch.AzureFilesIdentityBasedAuthentication =
                                new Track2Models.AzureFilesIdentityBasedAuthentication(Track2Models.DirectoryServiceOption.Aadds);

                        }
                        else //Disable AADDS
                        {
                            // Only disable AADDS; else keep unchanged

                            var originStorageAccount = this.StorageClientTrack2.GetSingleStorageAccount(this.ResourceGroupName, this.Name);

                            if (originStorageAccount.Data.AzureFilesIdentityBasedAuthentication == null
                                || originStorageAccount.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions == Track2Models.DirectoryServiceOption.Aadds)
                            {
                                storageAccountPatch.AzureFilesIdentityBasedAuthentication =
                                    new Track2Models.AzureFilesIdentityBasedAuthentication(Track2Models.DirectoryServiceOption.None);
                            }
                            else
                            {
                                storageAccountPatch.AzureFilesIdentityBasedAuthentication = originStorageAccount.Data.AzureFilesIdentityBasedAuthentication;

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

                            var originStorageAccount = this.StorageClientTrack2.GetSingleStorageAccount(this.ResourceGroupName, this.Name);



                            if (originStorageAccount.Data.AzureFilesIdentityBasedAuthentication != null
                                && originStorageAccount.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions == Track2Models.DirectoryServiceOption.Aadds)
                            {
                                throw new System.ArgumentException("The Storage account already enabled AzureActiveDirectoryDomainServicesForFile, please disable it by run this cmdlets with \"-EnableAzureActiveDirectoryDomainServicesForFile $false\" before enable ActiveDirectoryDomainServicesForFile.");
                            }

                            storageAccountPatch.AzureFilesIdentityBasedAuthentication =
                                new Track2Models.AzureFilesIdentityBasedAuthentication(Track2Models.DirectoryServiceOption.AD);

                            storageAccountPatch.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties =
                                new Track2Models.ActiveDirectoryProperties(this.ActiveDirectoryDomainName, this.ActiveDirectoryNetBiosDomainName,
                                this.ActiveDirectoryForestName, this.ActiveDirectoryDomainGuid, this.ActiveDirectoryDomainSid, this.ActiveDirectoryAzureStorageSid);
                            storageAccountPatch.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.SamAccountName = this.ActiveDirectorySamAccountName;
                            if (this.ActiveDirectoryAccountType != null)
                            {
                                storageAccountPatch.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.AccountType = this.ActiveDirectoryAccountType;
                            }
                        }
                        else // Disable AD
                        {
                            if (!string.IsNullOrEmpty(this.ActiveDirectoryDomainName)
                                || !string.IsNullOrEmpty(this.ActiveDirectoryNetBiosDomainName)
                                || !string.IsNullOrEmpty(this.ActiveDirectoryForestName)
                                || !string.IsNullOrEmpty(this.ActiveDirectoryDomainGuid)
                                || !string.IsNullOrEmpty(this.ActiveDirectoryDomainSid)
                                || !string.IsNullOrEmpty(this.ActiveDirectoryAzureStorageSid)
                                || !string.IsNullOrEmpty(this.ActiveDirectorySamAccountName)
                                || !string.IsNullOrEmpty(this.ActiveDirectoryAccountType)
                                )
                            {
                                throw new System.ArgumentException("To Disable ActiveDirectoryDomainServicesForFile, user can't specify any of: ActiveDirectoryDomainName, ActiveDirectoryNetBiosDomainName, ActiveDirectoryForestName, ActiveDirectoryDomainGuid, ActiveDirectoryDomainSid, ActiveDirectoryAzureStorageSid, ActiveDirectorySamAccountName, ActiveDirectoryAccountType.");
                            }

                            // Only disable AD; else keep unchanged
                            var originStorageAccount = this.StorageClientTrack2.GetSingleStorageAccount(this.ResourceGroupName, this.Name);

                            if (originStorageAccount.Data.AzureFilesIdentityBasedAuthentication == null
                                || originStorageAccount.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions == Track2Models.DirectoryServiceOption.AD)
                            {
                                storageAccountPatch.AzureFilesIdentityBasedAuthentication =
                                    new Track2Models.AzureFilesIdentityBasedAuthentication(Track2Models.DirectoryServiceOption.None);

                            }
                            else
                            {
                                storageAccountPatch.AzureFilesIdentityBasedAuthentication = originStorageAccount.Data.AzureFilesIdentityBasedAuthentication;

                            }
                        }
                    }
                    if (this.DefaultSharePermission != null)
                    {
                        if (storageAccountPatch.AzureFilesIdentityBasedAuthentication == null)
                        {
                            storageAccountPatch.AzureFilesIdentityBasedAuthentication =
                                new Track2Models.AzureFilesIdentityBasedAuthentication(
                                    Track2Models.DirectoryServiceOption.None);
                        }

                        storageAccountPatch.AzureFilesIdentityBasedAuthentication.DefaultSharePermission = this.DefaultSharePermission;
                    }
                    if (this.EnableLargeFileShare.IsPresent)
                    {
                        storageAccountPatch.LargeFileSharesState = Track2Models.LargeFileSharesState.Enabled;
                    }
                    if (this.minimumTlsVersion != null)
                    {
                        storageAccountPatch.MinimumTlsVersion = this.minimumTlsVersion;
                    }
                    if (this.allowBlobPublicAccess != null)
                    {
                        storageAccountPatch.AllowBlobPublicAccess = this.allowBlobPublicAccess;
                    }
                    if (this.RoutingChoice != null || this.publishMicrosoftEndpoint != null || this.publishInternetEndpoint != null)
                    {
                        storageAccountPatch.RoutingPreference = new Track2Models.RoutingPreference
                        {
                            PublishInternetEndpoints = this.publishInternetEndpoint,
                            PublishMicrosoftEndpoints = this.publishMicrosoftEndpoint,

                        };
                        if (this.RoutingChoice != null)
                        {
                            storageAccountPatch.RoutingPreference.RoutingChoice = new Track2Models.RoutingChoice(this.RoutingChoice);
                        }
                    }
                    if (allowSharedKeyAccess != null)
                    {
                        storageAccountPatch.AllowSharedKeyAccess = this.allowSharedKeyAccess;
                    }
                    if (sasExpirationPeriod != null)
                    {
                        storageAccountPatch.SasPolicy = new Track2Models.SasPolicy(
                            this.sasExpirationPeriod.Value.ToString(@"d\.hh\:mm\:ss"), Track2Models.ExpirationAction.Log);
                    }
                    if (keyExpirationPeriodInDay != null)
                    {

                        storageAccountPatch.KeyExpirationPeriodInDays = keyExpirationPeriodInDay.Value;


                    }
                    if (allowCrossTenantReplication != null)
                    {
                        storageAccountPatch.AllowCrossTenantReplication = this.allowCrossTenantReplication;
                    }
                    if (this.PublicNetworkAccess != null)
                    {
                        storageAccountPatch.PublicNetworkAccess = this.PublicNetworkAccess;
                    }
                    if (this.immutabilityPeriod != null || this.ImmutabilityPolicyState != null)
                    {
                        storageAccountPatch.ImmutableStorageWithVersioning = new Track2Models.ImmutableStorageAccount();
                        storageAccountPatch.ImmutableStorageWithVersioning.ImmutabilityPolicy = new Track2Models.AccountImmutabilityPolicyProperties();
                        if (this.immutabilityPeriod != null)
                        {
                            storageAccountPatch.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays = this.immutabilityPeriod;
                        }
                        if (this.ImmutabilityPolicyState != null)
                        {
                            storageAccountPatch.ImmutableStorageWithVersioning.ImmutabilityPolicy.State = this.ImmutabilityPolicyState;
                        }

                    }


                    var updatedAccountResponse = this.StorageClientTrack2.UpdateStorageAccount(this.ResourceGroupName, this.Name, storageAccountPatch);
                    var storageAccount = this.StorageClientTrack2.GetSingleStorageAccount(this.ResourceGroupName, this.Name, null);

                    WriteStorageAccount(storageAccount);
                }
            }
        }
    }
}
