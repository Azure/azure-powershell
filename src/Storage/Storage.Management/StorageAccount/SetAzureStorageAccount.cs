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

using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using StorageModels = Microsoft.Azure.Management.Storage.Models;

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

        /// <summary>
        /// Set AzureActiveDirectoryKerberosForFile parameter set name
        /// </summary>
        private const string AzureActiveDirectoryKerberosForFileParameterSet = "AzureActiveDirectoryKerberosForFile";

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
            StorageModels.SkuName.StandardRagrs,
            StorageModels.SkuName.PremiumLRS,
            StorageModels.SkuName.StandardGzrs,
            StorageModels.SkuName.StandardRagzrs,
            IgnoreCase = true)]
        public string SkuName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account Access Tier.")]
        [ValidateSet(AccountAccessTier.Hot,
            AccountAccessTier.Cool,
            AccountAccessTier.Cold,
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
            HelpMessage = "Set ClientId of the multi-tenant application to be used in conjunction with the user-assigned identity for cross-tenant customer-managed-keys server-side encryption on the storage account.")]
        [ValidateNotNull]
        public string KeyVaultFederatedClientId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Set the new Storage Account Identity type, the idenetity is for use with key management services like Azure KeyVault.")]
        [ValidateSet(AccountIdentityType.systemAssigned,
            AccountIdentityType.userAssigned,
            AccountIdentityType.systemAssignedUserAssigned,
            AccountIdentityType.none,
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
            Mandatory = false,
            HelpMessage = "Enable Azure Files Active Directory Domain Service Kerberos Authentication for the storage account.",
            ParameterSetName = AzureActiveDirectoryKerberosForFileParameterSet)]
        [ValidateNotNullOrEmpty]
        public bool EnableAzureActiveDirectoryKerberosForFile
        {
            get
            {
                return enableAzureActiveDirectoryKerberosForFile.HasValue ? enableAzureActiveDirectoryKerberosForFile.Value : false;
            }
            set
            {
                enableAzureActiveDirectoryKerberosForFile = value;
            }
        }
        private bool? enableAzureActiveDirectoryKerberosForFile = null;

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
            HelpMessage = "Specifies the primary domain that the AD DNS server is authoritative for. This parameter must be set when -EnableActiveDirectoryDomainServicesForFile or -EnableAzureActiveDirectoryKerberosForFile is set to true.",
            ParameterSetName = ActiveDirectoryDomainServicesForFileParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies the primary domain that the AD DNS server is authoritative for. This parameter must be set when -EnableActiveDirectoryDomainServicesForFile or -EnableAzureActiveDirectoryKerberosForFile is set to true.",
            ParameterSetName = AzureActiveDirectoryKerberosForFileParameterSet)]
        [ValidateNotNull]
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
            HelpMessage = "Specifies the domain GUID. This parameter must be set when -EnableActiveDirectoryDomainServicesForFile or -EnableAzureActiveDirectoryKerberosForFile is set to true.",
            ParameterSetName = ActiveDirectoryDomainServicesForFileParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies the domain GUID. This parameter must be set when -EnableActiveDirectoryDomainServicesForFile or -EnableAzureActiveDirectoryKerberosForFile is set to true.",
            ParameterSetName = AzureActiveDirectoryKerberosForFileParameterSet)]
        [ValidateNotNull]
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
            HelpMessage = "Allow or disallow anonymous access to all blobs or containers in the storage account.")]
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
            StorageModels.MinimumTlsVersion.TLS13,
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
            "If false, then all requests, including shared access signatures, must be authorized with Microsoft Entra ID. " +
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
            HelpMessage = "Gets or sets allow or disallow cross Microsoft Entra tenant object replication. The default interpretation is true for this property.")]
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

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable Secure File Transfer Protocol for the Storage account.")]
        [ValidateNotNullOrEmpty]
        public bool EnableSftp
        {
            get
            {
                return enableSftp != null ? enableSftp.Value : false;
            }
            set
            {
                enableSftp = value;
            }
        }
        private bool? enableSftp = null;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable local users feature for the Storage account.")]
        [ValidateNotNullOrEmpty]
        public bool EnableLocalUser
        {
            get
            {
                return enableLocalUser != null ? enableLocalUser.Value : false;
            }
            set
            {
                enableLocalUser = value;
            }
        }
        private bool? enableLocalUser = null;

        [Parameter(Mandatory = false, HelpMessage = "Set restrict copy to and from Storage Accounts within a Microsoft Entra tenant or with Private Links to the same VNet. Possible values include: 'PrivateLink', 'AAD'")]
        [PSArgumentCompleter("PrivateLink", "AAD")]
        [ValidateNotNullOrEmpty]
        public string AllowedCopyScope { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.Name, "Set Storage Account"))
            {
                string shouldContinueMessage = null;
                if (this.UpgradeToStorageV2.IsPresent)
                {
                    if(!this.force && this.OriginStorageAccountProperties.Kind == Kind.Storage)
                    {
                        shouldContinueMessage = "Upgrading a General Purpose v1 storage account to a general-purpose v2 account is free. You may specify the desired account tier during the upgrade process. If an account tier is not specified on upgrade, the default account tier of the upgraded account will be Hot. " + 
                            "However, changing the storage access tier after the upgrade may result in changes to your bill so it is recommended to specify the new account tier during upgrade. See (http://go.microsoft.com/fwlink/?LinkId=786482) to learn more.";
                    }
                    else if (!this.force && this.OriginStorageAccountProperties.Kind == Kind.BlobStorage)
                    {
                        shouldContinueMessage = "Upgrading a BlobStorage account to a general-purpose v2 account is free as long as the upgraded account's tier remains unchanged. If an account tier is not specified on upgrade, the default account tier of the upgraded account will be Hot. " +
                            "If there are account access tier changes as part of the upgrade, there will be charges associated with moving blobs as part of the account access tier change. See (http://go.microsoft.com/fwlink/?LinkId=786482) to learn more.";
                    }
                    else if (this.AccessTier != null)
                    {
                        shouldContinueMessage = "Changing the access tier may result in additional charges. See (http://go.microsoft.com/fwlink/?LinkId=786482) to learn more.";
                    }
                }
                else
                {
                    if (this.AccessTier != null)
                    {
                        shouldContinueMessage = "Changing the access tier may result in additional charges. See (http://go.microsoft.com/fwlink/?LinkId=786482) to learn more.";
                    }

                }
                if (this.force || string.IsNullOrEmpty(shouldContinueMessage) || ShouldContinue(shouldContinueMessage, ""))
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

                    if (AssignIdentity.IsPresent || this.UserAssignedIdentityId != null || this.IdentityType != null)
                    {
                        updateParameters.Identity = new Identity() { Type = StorageModels.IdentityType.SystemAssigned };
                        if (this.IdentityType != null)
                        {
                            updateParameters.Identity.Type = GetIdentityTypeString(this.IdentityType);
                        }
                        if (this.UserAssignedIdentityId != null)
                        {
                            if (updateParameters.Identity.Type != StorageModels.IdentityType.UserAssigned && updateParameters.Identity.Type != StorageModels.IdentityType.SystemAssignedUserAssigned)
                            {
                                throw new ArgumentException("UserAssignIdentityId should only be specified when AssignIdentityType is UserAssigned or SystemAssignedUserAssigned.", "UserAssignIdentityId");
                            }
                            updateParameters.Identity.UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>();
                            updateParameters.Identity.UserAssignedIdentities.Add(this.UserAssignedIdentityId, new UserAssignedIdentity());

                            if (this.OriginStorageAccountProperties.Identity != null && this.OriginStorageAccountProperties.Identity.UserAssignedIdentities != null && this.OriginStorageAccountProperties.Identity.UserAssignedIdentities.Count > 0)
                            {
                                foreach (var uid in this.OriginStorageAccountProperties.Identity.UserAssignedIdentities)
                                {
                                    if (!uid.Key.Equals(this.UserAssignedIdentityId, StringComparison.OrdinalIgnoreCase))
                                    {
                                        updateParameters.Identity.UserAssignedIdentities.Add(uid.Key, null);
                                    }
                                }
                            }
                        }
                    }

                    if (StorageEncryption || ParameterSetName == KeyvaultEncryptionParameterSet || this.KeyVaultUserAssignedIdentityId != null || this.KeyVaultFederatedClientId != null)
                    {
                        if (ParameterSetName == KeyvaultEncryptionParameterSet)
                        {
                            keyvaultEncryption = true;
                        }
                        updateParameters.Encryption = ParseEncryption(StorageEncryption, keyvaultEncryption, KeyName, KeyVersion, KeyVaultUri);
                        if (this.KeyVaultUserAssignedIdentityId != null || this.KeyVaultFederatedClientId != null)
                        {
                            updateParameters.Encryption.EncryptionIdentity = new EncryptionIdentity();
                            updateParameters.Encryption.EncryptionIdentity.EncryptionUserAssignedIdentity = this.KeyVaultUserAssignedIdentityId;
                            updateParameters.Encryption.EncryptionIdentity.EncryptionFederatedIdentityClientId = this.KeyVaultFederatedClientId;
                        }
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
                            if (this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication != null
                                && this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions == DirectoryServiceOptions.AD)
                            {
                                throw new System.ArgumentException("The Storage account already enabled ActiveDirectoryDomainServicesForFile, please disable it by run this cmdlets with \"-EnableActiveDirectoryDomainServicesForFile $false\" before enable AzureActiveDirectoryDomainServicesForFile.");
                            }
                            //if user want to enable AADDS, must first disable AADKERB
                            if (this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication != null
                                && this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions == DirectoryServiceOptions.Aadkerb)
                            {
                                throw new System.ArgumentException("The Storage account already enabled AzureActiveDirectoryKerberosForFile, please disable it by run this cmdlets with \"-EnableAzureActiveDirectoryKerberosForFile $false\" before enable AzureActiveDirectoryDomainServicesForFile.");
                            }
                            updateParameters.AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication();
                            updateParameters.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions = DirectoryServiceOptions.Aadds;
                        }
                        else //Disable AADDS
                        {
                            // Only disable AADDS; else keep unchanged
                            if (this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication == null
                                || this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions == DirectoryServiceOptions.Aadds)
                            {
                                updateParameters.AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication();
                                updateParameters.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions = DirectoryServiceOptions.None;
                            }
                            else
                            {
                                updateParameters.AzureFilesIdentityBasedAuthentication = this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication;
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
                            if (this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication != null
                                && this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions == DirectoryServiceOptions.Aadds)
                            {
                                throw new System.ArgumentException("The Storage account already enabled AzureActiveDirectoryDomainServicesForFile, please disable it by run this cmdlets with \"-EnableAzureActiveDirectoryDomainServicesForFile $false\" before enable ActiveDirectoryDomainServicesForFile.");
                            }
                            //if user want to enable AD, must first disable AADKERB
                            if (this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication != null
                                && this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions == DirectoryServiceOptions.Aadkerb)
                            {
                                throw new System.ArgumentException("The Storage account already enabled AzureActiveDirectoryKerberosForFile, please disable it by run this cmdlets with \"-EnableAzureActiveDirectoryKerberosForFile $false\" before enable ActiveDirectoryDomainServicesForFile.");
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
                                AzureStorageSid = this.ActiveDirectoryAzureStorageSid,
                                SamAccountName = this.ActiveDirectorySamAccountName,
                                AccountType = this.ActiveDirectoryAccountType
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
                                || !string.IsNullOrEmpty(this.ActiveDirectorySamAccountName)
                                || !string.IsNullOrEmpty(this.ActiveDirectoryAccountType)
                                )
                            {
                                throw new System.ArgumentException("To Disable ActiveDirectoryDomainServicesForFile, user can't specify any of: ActiveDirectoryDomainName, ActiveDirectoryNetBiosDomainName, ActiveDirectoryForestName, ActiveDirectoryDomainGuid, ActiveDirectoryDomainSid, ActiveDirectoryAzureStorageSid, ActiveDirectorySamAccountName, ActiveDirectoryAccountType.");
                            }

                            // Only disable AD; else keep unchanged
                            if (this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication == null
                                || this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions == DirectoryServiceOptions.AD)
                            {
                                updateParameters.AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication();
                                updateParameters.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions = DirectoryServiceOptions.None;
                            }
                            else
                            {
                                updateParameters.AzureFilesIdentityBasedAuthentication = this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication;
                            }
                        }
                    }
                    if (enableAzureActiveDirectoryKerberosForFile != null)
                    {
                        if (enableAzureActiveDirectoryKerberosForFile.Value) // Enable AADKERB
                        {
                            //if user want to enable AADKERB, must first disable AADDS
                            if (this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication != null
                                && this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions == DirectoryServiceOptions.Aadds)
                            {
                                throw new System.ArgumentException("The Storage account already enabled AzureActiveDirectoryDomainServicesForFile, please disable it by run this cmdlets with \"-EnableAzureActiveDirectoryDomainServicesForFile $false\" before enable AzureActiveDirectoryKerberosForFile.");
                            }
                            //if user want to enable AADKERB, must first disable AD
                            if (this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication != null
                                && this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions == DirectoryServiceOptions.AD)
                            {
                                throw new System.ArgumentException("The Storage account already enabled ActiveDirectoryDomainServicesForFile, please disable it by run this cmdlets with \"-EnableActiveDirectoryDomainServicesForFile $false\" before enable AzureActiveDirectoryKerberosForFile.");
                            }

                            updateParameters.AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication();
                            updateParameters.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions = DirectoryServiceOptions.Aadkerb;
                            if (this.ActiveDirectoryDomainName != null || this.ActiveDirectoryDomainGuid != null)
                            {

                                updateParameters.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties = new ActiveDirectoryProperties()
                                {
                                    DomainName = this.ActiveDirectoryDomainName,
                                    DomainGuid = this.ActiveDirectoryDomainGuid
                                };
                            }
                        }
                        else // Disable AADKERB
                        {
                            // Only disable AADKERB; else keep unchanged
                            if (this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication == null
                                || this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions == DirectoryServiceOptions.Aadkerb)
                            {
                                updateParameters.AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication();
                                updateParameters.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions = DirectoryServiceOptions.None;
                            }
                            else
                            {
                                updateParameters.AzureFilesIdentityBasedAuthentication = this.OriginStorageAccountProperties.AzureFilesIdentityBasedAuthentication;
                            }
                        }
                    }
                    if (this.DefaultSharePermission != null)
                    {
                        if (updateParameters.AzureFilesIdentityBasedAuthentication == null)
                        {
                            updateParameters.AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication();
                        }
                        updateParameters.AzureFilesIdentityBasedAuthentication.DefaultSharePermission = this.DefaultSharePermission;
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
                    if (allowSharedKeyAccess != null)
                    {
                        updateParameters.AllowSharedKeyAccess = allowSharedKeyAccess;
                    }
                    if (sasExpirationPeriod != null)
                    {
                        updateParameters.SasPolicy = new SasPolicy(sasExpirationPeriod.Value.ToString(@"d\.hh\:mm\:ss"), "Log");
                    }
                    if (keyExpirationPeriodInDay != null)
                    {
                        updateParameters.KeyPolicy = new KeyPolicy(keyExpirationPeriodInDay.Value);
                    }
                    if (allowCrossTenantReplication != null)
                    {
                        updateParameters.AllowCrossTenantReplication = allowCrossTenantReplication;
                    }
                    if (this.PublicNetworkAccess != null)
                    {
                        updateParameters.PublicNetworkAccess = this.PublicNetworkAccess;
                    }
                    if(this.immutabilityPeriod !=null ||  this.ImmutabilityPolicyState != null)
                    {
                        updateParameters.ImmutableStorageWithVersioning = new ImmutableStorageAccount();
                        updateParameters.ImmutableStorageWithVersioning.ImmutabilityPolicy = new AccountImmutabilityPolicyProperties();
                        updateParameters.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays = this.immutabilityPeriod;
                        updateParameters.ImmutableStorageWithVersioning.ImmutabilityPolicy.State = this.ImmutabilityPolicyState;
                    }
                    if (this.enableSftp != null)
                    {
                        updateParameters.IsSftpEnabled = this.enableSftp;
                    }
                    if (this.enableLocalUser != null)
                    {
                        updateParameters.IsLocalUserEnabled = this.enableLocalUser;
                    }
                    if (this.AllowedCopyScope != null)
                    {
                        updateParameters.AllowedCopyScope = this.AllowedCopyScope;
                    }

                    var updatedAccountResponse = this.StorageClient.StorageAccounts.Update(
                        this.ResourceGroupName,
                        this.Name,
                        updateParameters);

                    var storageAccount = this.StorageClient.StorageAccounts.GetProperties(this.ResourceGroupName, this.Name);

                    WriteStorageAccount(storageAccount, DefaultContext);
                }
            }
        }

        private StorageModels.StorageAccount OriginStorageAccountProperties
        {
            get
            {
                if (this.originStorageAccountProperties == null)
                {
                    this.originStorageAccountProperties = this.StorageClient.StorageAccounts.GetProperties(this.ResourceGroupName, this.Name);
                }
                return this.originStorageAccountProperties;
            }
        }
        private StorageModels.StorageAccount originStorageAccountProperties = null;
    }
}
