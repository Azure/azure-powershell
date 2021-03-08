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
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using StorageModels = Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;

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
        [ValidateSet(StorageModels.SkuName.StandardLRS,
            StorageModels.SkuName.StandardZRS,
            StorageModels.SkuName.StandardGRS,
            StorageModels.SkuName.StandardRAGRS,
            StorageModels.SkuName.PremiumLRS,
            StorageModels.SkuName.PremiumZRS,
            StorageModels.SkuName.StandardGZRS,
            StorageModels.SkuName.StandardRAGZRS,
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
        public SwitchParameter  RequireInfrastructureEncryption { get; set; }

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

            if (AssignIdentity.IsPresent)
            {
                createParameters.Identity = new Identity();
            }
            if (NetworkRuleSet != null)
            {
                createParameters.NetworkRuleSet = PSNetworkRuleSet.ParseStorageNetworkRule(NetworkRuleSet);
            }
            if (enableHierarchicalNamespace != null)
            {
                createParameters.IsHnsEnabled = enableHierarchicalNamespace;
            }
            if (enableAzureActiveDirectoryDomainServicesForFile !=null || enableActiveDirectoryDomainServicesForFile != null)
            {
                createParameters.AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication();
                if (enableAzureActiveDirectoryDomainServicesForFile != null && enableAzureActiveDirectoryDomainServicesForFile.Value)
                {
                    createParameters.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions = DirectoryServiceOptions.AADDS;
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
                        AzureStorageSid = this.ActiveDirectoryAzureStorageSid
                    };
                }
                else
                {
                    createParameters.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions = DirectoryServiceOptions.None;
                }
            }
            if(this.EnableLargeFileShare.IsPresent)
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

            var createAccountResponse = this.StorageClient.StorageAccounts.Create(
                this.ResourceGroupName,
                this.Name,
                createParameters);

            var storageAccount = this.StorageClient.StorageAccounts.GetProperties(this.ResourceGroupName, this.Name);

            this.WriteStorageAccount(storageAccount);
        }
    }
}
