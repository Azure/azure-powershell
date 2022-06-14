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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Collections.Generic;
using Track2Models = Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Models;
using Azure.Core;
using System.ComponentModel;
using System.Management.Automation.Remoting;
using Azure.ResourceManager.Storage;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageAccount", DefaultParameterSetName = AzureActiveDirectoryDomainServicesForFileParameterSet), OutputType(typeof(PSStorageAccount))]
    public class NewAzureStorageAccountCommand : StorageAccountBaseCmdlet
    {
        /// <summary>
        /// Set AzureActiveDirectoryDomainServicesForFile parameter set name
        /// </summary>
        private const string AzureActiveDirectoryDomainServicesForFileParameterSet = "AzureActiveDirectoryDomainServicesForFile";

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

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Sku Name.")]
        [Alias(StorageAccountTypeAlias, AccountTypeAlias, Account_TypeAlias)]
        [ValidateSet(
            SkuNameType.StandardLRS,
            SkuNameType.StandardZRS,
            SkuNameType.StandardGRS,
            SkuNameType.StandardRagrs,
            SkuNameType.PremiumLRS,
            SkuNameType.PremiumZRS,
            SkuNameType.StandardGzrs,
            SkuNameType.StandardRagzrs,
            IgnoreCase = true)]
        public string SkuName { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Location.")]
        [LocationCompleter("Microsoft.Storage/storageAccounts")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account Kind.")]
        [ValidateSet(
            StorageKindType.Storage,
            StorageKindType.StorageV2,
            StorageKindType.BlobStorage,
            StorageKindType.BlockBlobStorage,
            StorageKindType.FileStorage,
            IgnoreCase = true)]
        [PSDefaultValue(Help = "StorageV2", Value = StorageKindType.StorageV2)]
        public string Kind
        {
            get
            {
                return kind;
            }
            set
            {
                kind = value;
            }
        }
        private string kind = StorageKindType.StorageV2;

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
        [ValidateNotNullOrEmpty]
        public string CustomDomainName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "To Use Sub Domain.")]
        [ValidateNotNullOrEmpty]
        public bool? UseSubDomain { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account Tags.")]
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

        [Parameter(
            Mandatory = false,
            HelpMessage = "Generate and assign a new Storage Account Identity for this storage account for use with key management services like Azure KeyVault. If specify this paramter without \"-IdentityType\", will use system assigned identity.")]
        public SwitchParameter AssignIdentity { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Set resource ids for the the new Storage Account user assigned Identity, the identity will be used with key management services like Azure KeyVault.")]
        [ValidateNotNullOrEmpty]
        public string UserAssignedIdentityId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Set the new Storage Account Identity type, the idenetity is for use with key management services like Azure KeyVault.")]
        [ValidateSet(AccountIdentityType.SystemAssigned,
            AccountIdentityType.UserAssigned,
            AccountIdentityType.SystemAssignedUserAssigned,
            AccountIdentityType.None,
            IgnoreCase = true)]
        public string IdentityType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Set resource id for user assigned Identity used to access Azure KeyVault of Storage Account Encryption, the id must in UserAssignIdentityId.")]
        [ValidateNotNull]
        public string KeyVaultUserAssignedIdentityId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account encryption keySource KeyVault KeyName")]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account encryption keySource KeyVault KeyVersion")]
        [ValidateNotNullOrEmpty]
        public string KeyVersion { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account encryption keySource KeyVault KeyVaultUri")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultUri { get; set; }

        [Parameter(HelpMessage = "Storage Account NetworkRule",
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public PSNetworkRuleSet NetworkRuleSet
        {
            get; set;
        }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable HierarchicalNamespace for the Storage account.")]
        [ValidateNotNullOrEmpty]
        public bool EnableHierarchicalNamespace
        {
            get
            {
                return enableHierarchicalNamespace != null ? enableHierarchicalNamespace.Value : false;
            }
            set
            {
                enableHierarchicalNamespace = value;
            }
        }
        private bool? enableHierarchicalNamespace = null;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable Azure Files Azure Active Directory Domain Service Authentication for the storage account.",
            ParameterSetName = AzureActiveDirectoryDomainServicesForFileParameterSet)]
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

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Set the Encryption KeyType for Table. -Account, Table will be encrypted with account-scoped encryption key. -Service, Table will always be encrypted with Service-Managed keys. The default value is Service.")]
        [ValidateSet(
            KeyType.Service,
            KeyType.Account,
            IgnoreCase = true)]
        public string EncryptionKeyTypeForTable { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Set the Encryption KeyType for Queue. -Account, Queue will be encrypted with account-scoped encryption key. -Service, Queue will always be encrypted with Service-Managed keys. The default value is Service.")]
        [ValidateSet(
            KeyType.Service,
            KeyType.Account,
            IgnoreCase = true)]
        public string EncryptionKeyTypeForQueue { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The service will apply a secondary layer of encryption with platform managed keys for data at rest.")]
        public SwitchParameter RequireInfrastructureEncryption { get; set; }

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
            HelpMessage = "Allow public access to all blobs or containers in the storage account. The default interpretation is true for this property.")]
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
            HelpMessage = "The minimum TLS version to be permitted on requests to storage. The default interpretation is TLS 1.0 for this property.")]
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

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable NFS 3.0 protocol support if sets to true")]
        [ValidateNotNullOrEmpty]
        public bool EnableNfsV3
        {
            get
            {
                return enableNfsV3.Value;
            }
            set
            {
                enableNfsV3 = value;
            }
        }
        private bool? enableNfsV3 = null;

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

        [Parameter(Mandatory = false, HelpMessage = "Set the extended location name for EdgeZone. If not set, the storage account will be created in Azure main region. Otherwise it will be created in the specified extended location")]
        [ValidateNotNullOrEmpty]
        public string EdgeZone { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Allow or disallow public network access to Storage Account. Possible values include: 'Enabled', 'Disabled'.")]
        [PSArgumentCompleter("Enabled", "Disabled")]
        [ValidateNotNullOrEmpty]
        public string PublicNetworkAccess { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enables account-level immutability, then all the containers under this account will have object-level immutability enabled by default.")]
        public SwitchParameter EnableAccountLevelImmutability { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The immutability period for the blobs in the container since the policy creation in days. This property can only be only be specified with '-EnableAccountLevelImmutability'.")]
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
            HelpMessage = "The mode of the policy. Possible values include: 'Unlocked', 'Disabled. " +
            "Disabled state disablesthe policy. " +
            "Unlocked state allows increase and decrease of immutability retention time and also allows toggling allowProtectedAppendWrites property. " +
            "A policy can only be created in a Disabled or Unlocked state and can be toggled between the two states." +
            "This property can only be specified with '-EnableAccountLevelImmutability'.")]
        [PSArgumentCompleter("Disabled", "Unlocked")]
        [ValidateNotNullOrEmpty]
        public string ImmutabilityPolicyState { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            Track2Models.CheckNameAvailabilityResult checkNameAvailabilityResult =
                this.StorageClientTrack2.GetSubscription(this.SubscriptionId).CheckStorageAccountNameAvailability(
                    new Track2Models.StorageAccountCheckNameAvailabilityContent(this.Name));

            if (!checkNameAvailabilityResult.NameAvailable.Value)
            {
                throw new System.ArgumentException(checkNameAvailabilityResult.Message, "Name");
            }

            Track2Models.StorageKind kind = string.IsNullOrEmpty(this.Kind) ? null : new Track2Models.StorageKind(this.Kind);

            Track2Models.StorageAccountCreateOrUpdateContent createContent =
                new Track2Models.StorageAccountCreateOrUpdateContent(new Track2Models.StorageSku(this.SkuName), kind, this.Location);

            if (this.CustomDomainName != null)
            {

                createContent.CustomDomain = new Track2Models.CustomDomain(this.CustomDomainName);
                createContent.CustomDomain.UseSubDomainName = this.UseSubDomain;
            }
            else if (UseSubDomain != null)
            {
                throw new System.ArgumentException(string.Format("UseSubDomain must be set together with CustomDomainName."));
            }

            if (this.AccessTier != null)
            {
                createContent.AccessTier = ParseAccessTier(this.AccessTier);
            }
            if (enableHttpsTrafficOnly != null)
            {
                createContent.EnableHttpsTrafficOnly = enableHttpsTrafficOnly;
            }

            if (AssignIdentity.IsPresent || this.UserAssignedIdentityId != null || this.IdentityType != null)
            {
                createContent.Identity =
                    new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
                if (this.IdentityType != null)
                {
                    if (this.IdentityType == AccountIdentityType.SystemAssignedUserAssigned)
                    {
                        createContent.Identity.ManagedServiceIdentityType = new ManagedServiceIdentityType(AccountIdentityType.SystemAssignedUserAssignedTrack2);
                    } else
                    {
                        createContent.Identity.ManagedServiceIdentityType = new ManagedServiceIdentityType(this.IdentityType);
                    }
                }
                if (this.UserAssignedIdentityId != null)
                {
                    if (createContent.Identity.ManagedServiceIdentityType != AccountIdentityType.UserAssigned && createContent.Identity.ManagedServiceIdentityType != AccountIdentityType.SystemAssignedUserAssignedTrack2)
                    {
                        throw new ArgumentException("UserAssignIdentityId should only be specified when AssignIdentityType is UserAssigned or SystemAssignedUserAssigned.", "UserAssignIdentityId");
                    }

                    createContent.Identity.UserAssignedIdentities.Add(new ResourceIdentifier(this.UserAssignedIdentityId), new global::Azure.ResourceManager.Models.UserAssignedIdentity());

                }
            }
            if (NetworkRuleSet != null)
            {
                createContent.NetworkRuleSet = PSNetworkRuleSet.ParseStorageNetworkRule(NetworkRuleSet);
            }
            if (enableHierarchicalNamespace != null)
            {
                createContent.IsHnsEnabled = enableHierarchicalNamespace;
            }
            if (enableAzureActiveDirectoryDomainServicesForFile != null || enableActiveDirectoryDomainServicesForFile != null)
            {
                if (enableAzureActiveDirectoryDomainServicesForFile != null && enableAzureActiveDirectoryDomainServicesForFile.Value)
                {
                    createContent.AzureFilesIdentityBasedAuthentication = new Track2Models.AzureFilesIdentityBasedAuthentication(Track2Models.DirectoryServiceOptions.Aadds);
                }
                else if (enableActiveDirectoryDomainServicesForFile != null && enableActiveDirectoryDomainServicesForFile.Value)
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

                    createContent.AzureFilesIdentityBasedAuthentication =
                        new Track2Models.AzureFilesIdentityBasedAuthentication(Track2Models.DirectoryServiceOptions.AD);
                    createContent.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties =
                        new Track2Models.ActiveDirectoryProperties(this.ActiveDirectoryDomainName, this.ActiveDirectoryNetBiosDomainName,
                        this.ActiveDirectoryForestName, this.ActiveDirectoryDomainGuid, this.ActiveDirectoryDomainSid, this.ActiveDirectoryAzureStorageSid);
                    createContent.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.SamAccountName = this.ActiveDirectorySamAccountName;
                    if (this.ActiveDirectoryAccountType != null)
                    {
                        createContent.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.AccountType = this.ActiveDirectoryAccountType;
                    }
                }
                else
                {
                    createContent.AzureFilesIdentityBasedAuthentication =
                        new Track2Models.AzureFilesIdentityBasedAuthentication(Track2Models.DirectoryServiceOptions.None);
                }
            }

            if (this.DefaultSharePermission != null)
            {
                if (enableAzureActiveDirectoryDomainServicesForFile == null && enableActiveDirectoryDomainServicesForFile == null)
                {
                    throw new ArgumentException("'-DefaultSharePermission' need be specify together with '-EnableAzureActiveDirectoryDomainServicesForFile' or '-EnableActiveDirectoryDomainServicesForFile'.");
                }
                if (createContent.AzureFilesIdentityBasedAuthentication == null)
                {
                    createContent.AzureFilesIdentityBasedAuthentication =
                        new Track2Models.AzureFilesIdentityBasedAuthentication(Track2Models.DirectoryServiceOptions.None);
                }

                createContent.AzureFilesIdentityBasedAuthentication.DefaultSharePermission = this.DefaultSharePermission;
            }
            if (this.EnableLargeFileShare.IsPresent)
            {
                createContent.LargeFileSharesState = Track2Models.LargeFileSharesState.Enabled;
            }
            if (this.EncryptionKeyTypeForQueue != null || this.EncryptionKeyTypeForTable != null || this.RequireInfrastructureEncryption.IsPresent)
            {

                createContent.Encryption = new Track2Models.Encryption(Track2Models.KeySource.MicrosoftStorage);

                if (this.EncryptionKeyTypeForQueue != null || this.EncryptionKeyTypeForTable != null)
                {
                    createContent.Encryption.Services = new Track2Models.EncryptionServices();

                    if (this.EncryptionKeyTypeForQueue != null)
                    {
                        createContent.Encryption.Services.Queue = new Track2Models.EncryptionService
                        {
                            KeyType = this.EncryptionKeyTypeForQueue
                        };
                    }
                    if (this.EncryptionKeyTypeForTable != null)
                    {
                        createContent.Encryption.Services.Table = new Track2Models.EncryptionService
                        {
                            KeyType = this.EncryptionKeyTypeForTable
                        };
                    }
                }
                if (this.RequireInfrastructureEncryption.IsPresent)
                {
                    createContent.Encryption.RequireInfrastructureEncryption = true;

                    if (createContent.Encryption.Services == null)
                    {
                        createContent.Encryption.Services = new Track2Models.EncryptionServices();
                        createContent.Encryption.Services.Blob = new Track2Models.EncryptionService();
                    }
                }
            }
            if (this.KeyVaultUri != null || this.KeyName != null || this.KeyVersion != null || this.KeyVaultUserAssignedIdentityId != null)
            {
                if ((this.KeyVaultUri != null && this.KeyName == null) || (this.KeyVaultUri == null && this.KeyName != null))
                {
                    throw new ArgumentException("KeyVaultUri and KeyName must be specify together");
                }

                if (this.KeyVersion != null && (this.KeyVaultUri == null || this.KeyName == null))
                {
                    throw new ArgumentException("KeyVersion can only be specified when specify KeyVaultUri and KeyName together.", "KeyVersion");
                }

                if (this.KeyVaultUserAssignedIdentityId != null && (this.KeyVaultUri == null || this.KeyName == null))
                {
                    throw new ArgumentException("KeyVaultUserAssignedIdentityId can only be specified when specify KeyVaultUri and KeyName together.", "KeyVaultUserAssignedIdentityId");
                }


                if (createContent.Encryption == null)
                {
                    createContent.Encryption = new Track2Models.Encryption(
                        Track2Models.KeySource.MicrosoftStorage);
                }

                if (createContent.Encryption.Services == null)
                {
                    createContent.Encryption.Services = new Track2Models.EncryptionServices
                    {
                        Blob = new Track2Models.EncryptionService()
                    };
                }

                if (this.KeyVaultUri != null || this.KeyName != null || this.KeyVersion != null)
                {

                    createContent.Encryption.KeySource = Track2Models.KeySource.MicrosoftKeyvault;
                    createContent.Encryption.KeyVaultProperties = new Track2Models.KeyVaultProperties
                    {
                        KeyName = this.KeyName,
                        KeyVersion = this.KeyVersion,
                        KeyVaultUri = new Uri(this.KeyVaultUri)
                    };
                }

                if (this.KeyVaultUserAssignedIdentityId != null)
                {
                    createContent.Encryption.EncryptionIdentity = new Track2Models.EncryptionIdentity
                    {
                        EncryptionUserAssignedIdentity = this.KeyVaultUserAssignedIdentityId
                    };

                }
            }
            if (this.minimumTlsVersion != null)
            {
                createContent.MinimumTlsVersion = new Track2Models.MinimumTlsVersion(this.minimumTlsVersion);
            }
            if (this.allowBlobPublicAccess != null)
            {
                createContent.AllowBlobPublicAccess = this.allowBlobPublicAccess;
            }
            if (this.RoutingChoice != null || this.publishMicrosoftEndpoint != null || this.publishInternetEndpoint != null)
            {
                createContent.RoutingPreference = new Track2Models.RoutingPreference
                {
                    RoutingChoice = new Track2Models.RoutingChoice(this.RoutingChoice),
                    PublishMicrosoftEndpoints = this.publishMicrosoftEndpoint,
                    PublishInternetEndpoints = this.publishInternetEndpoint
                };
            }
            if (allowSharedKeyAccess != null)
            {
                createContent.AllowSharedKeyAccess = this.allowSharedKeyAccess;
            }
            if (enableNfsV3 != null)
            {
                createContent.EnableNfsV3 = this.enableNfsV3;
            }
            if (this.EdgeZone != null)
            {
                createContent.ExtendedLocation = new Track2Models.ExtendedLocation
                {
                    Name = this.EdgeZone,
                    ExtendedLocationType = Track2Models.ExtendedLocationTypes.EdgeZone,
                };
            }
            if (sasExpirationPeriod != null)
            {
                createContent.SasPolicy = new Track2Models.SasPolicy(sasExpirationPeriod.Value.ToString(@"d\.hh\:mm\:ss"), Track2Models.ExpirationAction.Log);
            }
            if (keyExpirationPeriodInDay != null)
            {
                createContent.KeyExpirationPeriodInDays = keyExpirationPeriodInDay.Value;

            }
            if (allowCrossTenantReplication != null)
            {
                createContent.AllowCrossTenantReplication = this.allowCrossTenantReplication;
            }
            if (this.PublicNetworkAccess != null)
            {
                createContent.PublicNetworkAccess = this.PublicNetworkAccess;
            }
            if (EnableAccountLevelImmutability.IsPresent || this.immutabilityPeriod != null || this.ImmutabilityPolicyState != null)
            {
                if (!EnableAccountLevelImmutability.IsPresent)
                {
                    throw new ArgumentException("ImmutabilityPeriod, ImmutabilityPolicyState and AllowProtectedAppendWrite, can only be specified with -EnableAccountLevelImmutability.");
                }

                createContent.ImmutableStorageWithVersioning = new Track2Models.ImmutableStorageAccount
                {
                    Enabled = this.EnableAccountLevelImmutability.IsPresent
                };

                if (this.immutabilityPeriod != null || this.ImmutabilityPolicyState != null)
                {
                    createContent.ImmutableStorageWithVersioning.ImmutabilityPolicy = new Track2Models.AccountImmutabilityPolicyProperties
                    {
                        ImmutabilityPeriodSinceCreationInDays = this.ImmutabilityPeriod,
                        State = this.ImmutabilityPolicyState,
                    };
                }
            }
            var createAccountResponse = this.StorageClientTrack2.CreateStorageAccount(this.ResourceGroupName, this.Name, createContent);
            var storageAccount = this.StorageClientTrack2.GetSingleStorageAccount(this.ResourceGroupName, this.Name);

            WriteStorageAccount(storageAccount);

        }
    }
}
