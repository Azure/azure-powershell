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

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Sku Name.")]
        [Alias(StorageAccountTypeAlias, AccountTypeAlias, Account_TypeAlias)]
        [ValidateSet(StorageModels.SkuName.StandardLRS,
            StorageModels.SkuName.StandardZRS,
            StorageModels.SkuName.StandardGRS,
            StorageModels.SkuName.StandardRagrs,
            StorageModels.SkuName.PremiumLRS,
            StorageModels.SkuName.PremiumZRS,
            StorageModels.SkuName.StandardGzrs,
            StorageModels.SkuName.StandardRagzrs,
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
        [ValidateSet(StorageModels.Kind.Storage,
            StorageModels.Kind.StorageV2,
            StorageModels.Kind.BlobStorage,
            StorageModels.Kind.BlockBlobStorage,
            StorageModels.Kind.FileStorage,
            IgnoreCase = true)]
        [PSDefaultValue(Help = "StorageV2", Value = StorageModels.Kind.StorageV2)]
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
        private string kind = StorageModels.Kind.StorageV2;

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
        [ValidateSet(AccountIdentityType.systemAssigned,
            AccountIdentityType.userAssigned,
            AccountIdentityType.systemAssignedUserAssigned,
            AccountIdentityType.none,
            IgnoreCase = true)]
        public string IdentityType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Set resource id for user assigned Identity used to access Azure KeyVault of Storage Account Encryption, the id must in UserAssignIdentityId.")]
        [ValidateNotNull]
        public string KeyVaultUserAssignedIdentityId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Set ClientId of the multi-tenant application to be used in conjunction with the user-assigned identity for cross-tenant customer-managed-keys server-side encryption on the storage account.")]
        [ValidateNotNull]
        public string KeyVaultFederatedClientId { get; set; }

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
            HelpMessage = "Enable Azure Files Microsoft Entra Domain Service Authentication for the storage account.",
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
            Microsoft.Azure.Management.Storage.Models.RoutingChoice.MicrosoftRouting,
            Microsoft.Azure.Management.Storage.Models.RoutingChoice.InternetRouting,
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
            Mandatory = true,
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
            HelpMessage = "Specifies the primary domain that the AD DNS server is authoritative for. This parameter must be set when -EnableActiveDirectoryDomainServicesForFile or -EnableAzureActiveDirectoryKerberosForFile is set to true.",
            ParameterSetName = ActiveDirectoryDomainServicesForFileParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies the primary domain that the AD DNS server is authoritative for. This parameter must be set when -EnableActiveDirectoryDomainServicesForFile or -EnableAzureActiveDirectoryKerberosForFile is set to true.",
            ParameterSetName = AzureActiveDirectoryKerberosForFileParameterSet)]
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
            HelpMessage = "Specifies the domain GUID. This parameter must be set when -EnableActiveDirectoryDomainServicesForFile or -EnableAzureActiveDirectoryKerberosForFile is set to true.",
            ParameterSetName = ActiveDirectoryDomainServicesForFileParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Specifies the domain GUID. This parameter must be set when -EnableActiveDirectoryDomainServicesForFile or -EnableAzureActiveDirectoryKerberosForFile is set to true.",
            ParameterSetName = AzureActiveDirectoryKerberosForFileParameterSet)]
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
        [ValidateSet(StorageModels.KeyType.Service, 
            StorageModels.KeyType.Account, 
            IgnoreCase = true)]
        public string EncryptionKeyTypeForTable { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Set the Encryption KeyType for Queue. -Account, Queue will be encrypted with account-scoped encryption key. -Service, Queue will always be encrypted with Service-Managed keys. The default value is Service.")]
        [ValidateSet(StorageModels.KeyType.Service,
            StorageModels.KeyType.Account,
            IgnoreCase = true)]
        public string EncryptionKeyTypeForQueue { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The service will apply a secondary layer of encryption with platform managed keys for data at rest.")]
        public SwitchParameter RequireInfrastructureEncryption { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The SAS expiration period of this account, it is a timespan and accurate to seconds.")]
        public TimeSpan SasExpirationPeriod
        {
            get
            {
                return sasExpirationPeriod is null? TimeSpan.Zero : sasExpirationPeriod.Value;
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
            HelpMessage = "Allow anonymous access to all blobs or containers in the storage account. The default interpretation is false for this property.")]
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
            HelpMessage = "Gets or sets allow or disallow cross Microsoft Entra tenant object replication. The default interpretation is false for this property.")]
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

        [Parameter(Mandatory = false, HelpMessage = "Set restrict copy to and from Storage Accounts within a Microsoft Entra tenant or with Private Links to the same VNet. Possible values include: 'PrivateLink', 'AAD'")]
        [PSArgumentCompleter("PrivateLink", "AAD")]
        [ValidateNotNullOrEmpty]
        public string AllowedCopyScope { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "Specify the type of endpoint. Set this to AzureDNSZone to create a large number of accounts in a single subscription, " +
            "which creates accounts in an Azure DNS Zone and the endpoint URL will have an alphanumeric DNS Zone identifier. Possible values include: 'Standard', 'AzureDnsZone'.")]
        [PSArgumentCompleter("Standard", "AzureDnsZone")]
        [ValidateNotNullOrEmpty]
        public string DnsEndpointType { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            CheckNameAvailabilityResult checkNameAvailabilityResult = this.StorageClient.StorageAccounts.CheckNameAvailability(this.Name);
            if (!checkNameAvailabilityResult.NameAvailable.Value)
            {
                throw new System.ArgumentException(checkNameAvailabilityResult.Message, "Name");
            }

            StorageAccountCreateParameters createParameters = new StorageAccountCreateParameters()
            {
                Location = this.Location,
                Sku = new Sku(this.SkuName),
                Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true),
            };

            if (this.CustomDomainName != null)
            {
                createParameters.CustomDomain = new CustomDomain()
                {
                    Name = CustomDomainName,
                    UseSubDomainName = UseSubDomain
                };
            }
            else if (UseSubDomain != null)
            {
                throw new System.ArgumentException(string.Format("UseSubDomain must be set together with CustomDomainName."));
            }

            if (kind != null)
            {
                createParameters.Kind = kind;
            }

            if (this.AccessTier != null)
            {
                createParameters.AccessTier = ParseAccessTier(AccessTier);
            }
            if (enableHttpsTrafficOnly != null)
            {
                createParameters.EnableHttpsTrafficOnly = enableHttpsTrafficOnly;
            }

            if (AssignIdentity.IsPresent || this.UserAssignedIdentityId != null || this.IdentityType != null)
            {
                createParameters.Identity = new Identity() { Type = StorageModels.IdentityType.SystemAssigned };
                if (this.IdentityType != null)
                {
                    createParameters.Identity.Type = GetIdentityTypeString(this.IdentityType);
                }
                if (this.UserAssignedIdentityId != null)
                {
                    if (createParameters.Identity.Type != StorageModels.IdentityType.UserAssigned && createParameters.Identity.Type != StorageModels.IdentityType.SystemAssignedUserAssigned)
                    {
                        throw new ArgumentException("UserAssignIdentityId should only be specified when AssignIdentityType is UserAssigned or SystemAssignedUserAssigned.", "UserAssignIdentityId");
                    }
                    createParameters.Identity.UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>();
                    createParameters.Identity.UserAssignedIdentities.Add(this.UserAssignedIdentityId, new UserAssignedIdentity());
                }
            }
            if (NetworkRuleSet != null)
            {
                createParameters.NetworkRuleSet = PSNetworkRuleSet.ParseStorageNetworkRule(NetworkRuleSet);
            }
            if (enableHierarchicalNamespace != null)
            {
                createParameters.IsHnsEnabled = enableHierarchicalNamespace;
            }
            if (enableAzureActiveDirectoryDomainServicesForFile !=null || enableActiveDirectoryDomainServicesForFile != null || enableAzureActiveDirectoryKerberosForFile != null)
            {
                createParameters.AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication();
                if (enableAzureActiveDirectoryDomainServicesForFile != null && enableAzureActiveDirectoryDomainServicesForFile.Value)
                {
                    createParameters.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions = DirectoryServiceOptions.Aadds;
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
                    createParameters.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions = DirectoryServiceOptions.AD;
                    createParameters.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties = new ActiveDirectoryProperties()
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
                else if (enableAzureActiveDirectoryKerberosForFile != null && enableAzureActiveDirectoryKerberosForFile.Value)
                {
                    createParameters.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions = DirectoryServiceOptions.Aadkerb;
                    if (this.ActiveDirectoryDomainName != null || this.ActiveDirectoryDomainGuid != null)
                    {
                        createParameters.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties = new ActiveDirectoryProperties()
                        {
                            DomainName = this.ActiveDirectoryDomainName,
                            DomainGuid = this.ActiveDirectoryDomainGuid
                        };
                    }
                }
                else
                {
                    createParameters.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions = DirectoryServiceOptions.None;
                }
            }

            if (this.DefaultSharePermission != null)
            {
                if (enableAzureActiveDirectoryDomainServicesForFile == null && enableActiveDirectoryDomainServicesForFile == null)
                {
                    throw new ArgumentException("'-DefaultSharePermission' need be specify together with '-EnableAzureActiveDirectoryDomainServicesForFile' or '-EnableActiveDirectoryDomainServicesForFile'.");
                }
                if (createParameters.AzureFilesIdentityBasedAuthentication == null)
                {
                    createParameters.AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication();
                }
                createParameters.AzureFilesIdentityBasedAuthentication.DefaultSharePermission = this.DefaultSharePermission;
            }
            if (this.EnableLargeFileShare.IsPresent)
            {
                createParameters.LargeFileSharesState = LargeFileSharesState.Enabled;
            }
            if(this.EncryptionKeyTypeForQueue != null || this.EncryptionKeyTypeForTable != null || this.RequireInfrastructureEncryption.IsPresent)
            {
                createParameters.Encryption = new Encryption();
                createParameters.Encryption.KeySource = KeySource.MicrosoftStorage;
                if (this.EncryptionKeyTypeForQueue != null || this.EncryptionKeyTypeForTable != null)
                {
                    createParameters.Encryption.Services = new EncryptionServices();
                    if (this.EncryptionKeyTypeForQueue != null)
                    {
                        createParameters.Encryption.Services.Queue = new EncryptionService(keyType: this.EncryptionKeyTypeForQueue);
                    }
                    if (this.EncryptionKeyTypeForTable != null)
                    {
                        createParameters.Encryption.Services.Table = new EncryptionService(keyType: this.EncryptionKeyTypeForTable);
                    }
                }
                if (this.RequireInfrastructureEncryption.IsPresent)
                {
                    createParameters.Encryption.RequireInfrastructureEncryption = true;
                    if (createParameters.Encryption.Services is null)
                    {
                        createParameters.Encryption.Services = new EncryptionServices();
                        createParameters.Encryption.Services.Blob = new EncryptionService();
                    }
                }
            }
            if (this.KeyVaultUri !=null || this.KeyName != null || this.KeyVersion != null || this.KeyVaultUserAssignedIdentityId != null || this.KeyVaultFederatedClientId != null)
            {
                if ((this.KeyVaultUri != null && this.KeyName == null) || (this.KeyVaultUri == null && this.KeyName != null))
                {
                    throw new ArgumentException("KeyVaultUri and KeyName must be specify together"); 
                }

                if (this.KeyVersion != null && (this.KeyVaultUri == null || this.KeyName == null))
                {
                    throw new ArgumentException("KeyVersion can only be specified when specify KeyVaultUri and KeyName together.", "KeyVersion"); 
                }

                if ((this.KeyVaultUserAssignedIdentityId != null || this.KeyVaultFederatedClientId != null) && (this.KeyVaultUri == null || this.KeyName == null))
                {
                    throw new ArgumentException("KeyVaultUserAssignedIdentityId, KeyVaultFederatedClientId can only be specified when specify KeyVaultUri and KeyName together.", "KeyVaultUserAssignedIdentityId, KeyVaultFederatedClientId");
                }

                if (createParameters.Encryption == null)
                {
                    createParameters.Encryption = new Encryption();
                    createParameters.Encryption.KeySource = KeySource.MicrosoftStorage;
                }

                if (createParameters.Encryption.Services is null)
                {
                    createParameters.Encryption.Services = new EncryptionServices();
                    createParameters.Encryption.Services.Blob = new EncryptionService();
                }

                if (this.KeyVaultUri != null || this.KeyName != null || this.KeyVersion != null)
                {
                    createParameters.Encryption.KeySource = KeySource.MicrosoftKeyvault;
                    createParameters.Encryption.KeyVaultProperties = new KeyVaultProperties(this.KeyName, this.KeyVersion, this.KeyVaultUri);
                }

                if (this.KeyVaultUserAssignedIdentityId != null || this.KeyVaultFederatedClientId != null)
                {
                    createParameters.Encryption.EncryptionIdentity = new EncryptionIdentity();
                    createParameters.Encryption.EncryptionIdentity.EncryptionUserAssignedIdentity = this.KeyVaultUserAssignedIdentityId;
                    createParameters.Encryption.EncryptionIdentity.EncryptionFederatedIdentityClientId = this.KeyVaultFederatedClientId;
                }
            }
            if (this.minimumTlsVersion != null)
            {
                createParameters.MinimumTlsVersion = this.minimumTlsVersion;
            }
            if (this.allowBlobPublicAccess != null)
            {
                createParameters.AllowBlobPublicAccess = this.allowBlobPublicAccess;
            }
            if (this.RoutingChoice != null || this.publishMicrosoftEndpoint != null || this.publishInternetEndpoint != null)
            {
                createParameters.RoutingPreference = new RoutingPreference(this.RoutingChoice, this.publishMicrosoftEndpoint, this.publishInternetEndpoint);
            }
            if (allowSharedKeyAccess != null)
            {
                createParameters.AllowSharedKeyAccess = allowSharedKeyAccess;
            }
            if (enableNfsV3 != null)
            {
                createParameters.EnableNfsV3 = enableNfsV3;
            }
            if (this.EdgeZone != null)
            {
                createParameters.ExtendedLocation = new ExtendedLocation()
                {
                    Type = ExtendedLocationTypes.EdgeZone,
                    Name = this.EdgeZone
                };
            }
            if (sasExpirationPeriod != null)
            {
                createParameters.SasPolicy = new SasPolicy(sasExpirationPeriod.Value.ToString(@"d\.hh\:mm\:ss"), "Log");
            }
            if (keyExpirationPeriodInDay != null)
            {
                createParameters.KeyPolicy = new KeyPolicy(keyExpirationPeriodInDay.Value);
            }
            if(allowCrossTenantReplication != null)
            {
                createParameters.AllowCrossTenantReplication = allowCrossTenantReplication;
            }
            if (this.PublicNetworkAccess != null)
            {
                createParameters.PublicNetworkAccess = this.PublicNetworkAccess;
            }
            if (EnableAccountLevelImmutability.IsPresent || this.immutabilityPeriod != null ||  this.ImmutabilityPolicyState != null)
            {
                if (!EnableAccountLevelImmutability.IsPresent)
                {
                    throw new ArgumentException("ImmutabilityPeriod, ImmutabilityPolicyState and AllowProtectedAppendWrite, can only be specified with -EnableAccountLevelImmutability.");
                }
                createParameters.ImmutableStorageWithVersioning = new ImmutableStorageAccount();
                createParameters.ImmutableStorageWithVersioning.Enabled = this.EnableAccountLevelImmutability.IsPresent;
                if (this.immutabilityPeriod != null || this.ImmutabilityPolicyState != null)
                {
                    createParameters.ImmutableStorageWithVersioning.ImmutabilityPolicy = new AccountImmutabilityPolicyProperties();
                    createParameters.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays = this.immutabilityPeriod;
                    createParameters.ImmutableStorageWithVersioning.ImmutabilityPolicy.State = this.ImmutabilityPolicyState;
                }
            }
            if (this.enableSftp != null)
            {
                createParameters.IsSftpEnabled = this.enableSftp;
            }
            if (this.enableLocalUser != null)
            {
                createParameters.IsLocalUserEnabled = this.enableLocalUser;
            }
            if (this.AllowedCopyScope != null)
            {
                createParameters.AllowedCopyScope = this.AllowedCopyScope;
            }
            if (this.DnsEndpointType != null)
            {
                createParameters.DnsEndpointType = this.DnsEndpointType;
            }

            var createAccountResponse = this.StorageClient.StorageAccounts.Create(
                this.ResourceGroupName,
                this.Name,
                createParameters);

            var storageAccount = this.StorageClient.StorageAccounts.GetProperties(this.ResourceGroupName, this.Name);

            this.WriteStorageAccount(storageAccount, DefaultContext);
        }
    }
}
