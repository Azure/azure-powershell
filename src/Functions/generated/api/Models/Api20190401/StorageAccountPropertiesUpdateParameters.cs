namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The parameters used when updating a storage account.</summary>
    public partial class StorageAccountPropertiesUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal
    {

        /// <summary>Backing field for <see cref="AccessTier" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessTier? _accessTier;

        /// <summary>
        /// Required for storage accounts where kind = BlobStorage. The access tier used for billing.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessTier? AccessTier { get => this._accessTier; set => this._accessTier = value; }

        /// <summary>Specifies the security identifier (SID) for Azure Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyAzureStorageSid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).ActiveDirectoryPropertyAzureStorageSid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).ActiveDirectoryPropertyAzureStorageSid = value; }

        /// <summary>Specifies the domain GUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyDomainGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).ActiveDirectoryPropertyDomainGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).ActiveDirectoryPropertyDomainGuid = value; }

        /// <summary>Specifies the primary domain that the AD DNS server is authoritative for.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).ActiveDirectoryPropertyDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).ActiveDirectoryPropertyDomainName = value; }

        /// <summary>Specifies the security identifier (SID).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyDomainSid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).ActiveDirectoryPropertyDomainSid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).ActiveDirectoryPropertyDomainSid = value; }

        /// <summary>Specifies the Active Directory forest to get.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyForestName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).ActiveDirectoryPropertyForestName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).ActiveDirectoryPropertyForestName = value; }

        /// <summary>Specifies the NetBIOS domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyNetBiosDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).ActiveDirectoryPropertyNetBiosDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).ActiveDirectoryPropertyNetBiosDomainName = value; }

        /// <summary>Indicates the directory service used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DirectoryServiceOptions AzureFileIdentityBasedAuthenticationDirectoryServiceOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).DirectoryServiceOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).DirectoryServiceOption = value; }

        /// <summary>
        /// Backing field for <see cref="AzureFilesIdentityBasedAuthentication" /> property.
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthentication _azureFilesIdentityBasedAuthentication;

        /// <summary>Provides the identity based authentication settings for Azure Files.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get => (this._azureFilesIdentityBasedAuthentication = this._azureFilesIdentityBasedAuthentication ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.AzureFilesIdentityBasedAuthentication()); set => this._azureFilesIdentityBasedAuthentication = value; }

        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? BlobEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).BlobEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).BlobEnabled = value; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? BlobLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).BlobLastEnabledTime; }

        /// <summary>Backing field for <see cref="CustomDomain" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICustomDomain _customDomain;

        /// <summary>
        /// Custom domain assigned to the storage account by the user. Name is the CNAME source. Only one custom domain is supported
        /// per storage account at this time. To clear the existing custom domain, use an empty string for the custom domain name
        /// property.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICustomDomain CustomDomain { get => (this._customDomain = this._customDomain ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.CustomDomain()); set => this._customDomain = value; }

        /// <summary>
        /// Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICustomDomainInternal)CustomDomain).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICustomDomainInternal)CustomDomain).Name = value; }

        /// <summary>
        /// Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? CustomDomainUseSubDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICustomDomainInternal)CustomDomain).UseSubDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICustomDomainInternal)CustomDomain).UseSubDomainName = value; }

        /// <summary>Backing field for <see cref="EnableHttpsTrafficOnly" /> property.</summary>
        private bool? _enableHttpsTrafficOnly;

        /// <summary>Allows https traffic only to storage service if sets to true.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? EnableHttpsTrafficOnly { get => this._enableHttpsTrafficOnly; set => this._enableHttpsTrafficOnly = value; }

        /// <summary>Backing field for <see cref="Encryption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryption _encryption;

        /// <summary>
        /// Provides the encryption settings on the account. The default setting is unencrypted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryption Encryption { get => (this._encryption = this._encryption ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Encryption()); set => this._encryption = value; }

        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive): Microsoft.Storage, Microsoft.Keyvault
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeySource EncryptionKeySource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeySource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeySource = value; }

        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? FileEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).FileEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).FileEnabled = value; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? FileLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).FileLastEnabledTime; }

        /// <summary>The name of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeyVaultPropertyKeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeyVaultPropertyKeyName = value; }

        /// <summary>The Uri of KeyVault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyVaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeyVaultPropertyKeyVaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeyVaultPropertyKeyVaultUri = value; }

        /// <summary>The version of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeyVaultPropertyKeyVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeyVaultPropertyKeyVersion = value; }

        /// <summary>Backing field for <see cref="LargeFileSharesState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LargeFileSharesState? _largeFileSharesState;

        /// <summary>
        /// Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LargeFileSharesState? LargeFileSharesState { get => this._largeFileSharesState; set => this._largeFileSharesState = value; }

        /// <summary>
        /// Internal Acessors for AzureFileIdentityBasedAuthenticationActiveDirectoryProperty
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal.AzureFileIdentityBasedAuthenticationActiveDirectoryProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).ActiveDirectoryProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).ActiveDirectoryProperty = value; }

        /// <summary>Internal Acessors for AzureFilesIdentityBasedAuthentication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthentication Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal.AzureFilesIdentityBasedAuthentication { get => (this._azureFilesIdentityBasedAuthentication = this._azureFilesIdentityBasedAuthentication ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.AzureFilesIdentityBasedAuthentication()); set { {_azureFilesIdentityBasedAuthentication = value;} } }

        /// <summary>Internal Acessors for BlobLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal.BlobLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).BlobLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).BlobLastEnabledTime = value; }

        /// <summary>Internal Acessors for CustomDomain</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICustomDomain Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal.CustomDomain { get => (this._customDomain = this._customDomain ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.CustomDomain()); set { {_customDomain = value;} } }

        /// <summary>Internal Acessors for Encryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryption Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal.Encryption { get => (this._encryption = this._encryption ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Encryption()); set { {_encryption = value;} } }

        /// <summary>Internal Acessors for EncryptionKeyVaultProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal.EncryptionKeyVaultProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeyVaultProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeyVaultProperty = value; }

        /// <summary>Internal Acessors for EncryptionService</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServices Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal.EncryptionService { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).Service; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).Service = value; }

        /// <summary>Internal Acessors for FileLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal.FileLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).FileLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).FileLastEnabledTime = value; }

        /// <summary>Internal Acessors for NetworkRuleSet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSet Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal.NetworkRuleSet { get => (this._networkRuleSet = this._networkRuleSet ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.NetworkRuleSet()); set { {_networkRuleSet = value;} } }

        /// <summary>Internal Acessors for QueueLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal.QueueLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).QueueLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).QueueLastEnabledTime = value; }

        /// <summary>Internal Acessors for ServiceBlob</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal.ServiceBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).ServiceBlob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).ServiceBlob = value; }

        /// <summary>Internal Acessors for ServiceFile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal.ServiceFile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).ServiceFile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).ServiceFile = value; }

        /// <summary>Internal Acessors for ServiceQueue</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal.ServiceQueue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).ServiceQueue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).ServiceQueue = value; }

        /// <summary>Internal Acessors for ServiceTable</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal.ServiceTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).ServiceTable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).ServiceTable = value; }

        /// <summary>Internal Acessors for TableLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal.TableLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).TableLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).TableLastEnabledTime = value; }

        /// <summary>Backing field for <see cref="NetworkRuleSet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSet _networkRuleSet;

        /// <summary>Network rule set</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSet NetworkRuleSet { get => (this._networkRuleSet = this._networkRuleSet ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.NetworkRuleSet()); set => this._networkRuleSet = value; }

        /// <summary>
        /// Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices
        /// (For example, "Logging, Metrics"), or None to bypass none of those traffics.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass? NetworkRuleSetBypass { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)NetworkRuleSet).Bypass; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)NetworkRuleSet).Bypass = value; }

        /// <summary>Specifies the default action of allow or deny when no other rules match.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction NetworkRuleSetDefaultAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)NetworkRuleSet).DefaultAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)NetworkRuleSet).DefaultAction = value; }

        /// <summary>Sets the IP ACL rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule[] NetworkRuleSetIPRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)NetworkRuleSet).IPRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)NetworkRuleSet).IPRule = value; }

        /// <summary>Sets the virtual network rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule[] NetworkRuleSetVirtualNetworkRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)NetworkRuleSet).VirtualNetworkRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)NetworkRuleSet).VirtualNetworkRule = value; }

        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? QueueEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).QueueEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).QueueEnabled = value; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? QueueLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).QueueLastEnabledTime; }

        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? TableEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).TableEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).TableEnabled = value; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? TableLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).TableLastEnabledTime; }

        /// <summary>
        /// Creates an new <see cref="StorageAccountPropertiesUpdateParameters" /> instance.
        /// </summary>
        public StorageAccountPropertiesUpdateParameters()
        {

        }
    }
    /// The parameters used when updating a storage account.
    public partial interface IStorageAccountPropertiesUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Required for storage accounts where kind = BlobStorage. The access tier used for billing.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Required for storage accounts where kind = BlobStorage. The access tier used for billing.",
        SerializedName = @"accessTier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessTier) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessTier? AccessTier { get; set; }
        /// <summary>Specifies the security identifier (SID) for Azure Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the security identifier (SID) for Azure Storage.",
        SerializedName = @"azureStorageSid",
        PossibleTypes = new [] { typeof(string) })]
        string ActiveDirectoryPropertyAzureStorageSid { get; set; }
        /// <summary>Specifies the domain GUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the domain GUID.",
        SerializedName = @"domainGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ActiveDirectoryPropertyDomainGuid { get; set; }
        /// <summary>Specifies the primary domain that the AD DNS server is authoritative for.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the primary domain that the AD DNS server is authoritative for.",
        SerializedName = @"domainName",
        PossibleTypes = new [] { typeof(string) })]
        string ActiveDirectoryPropertyDomainName { get; set; }
        /// <summary>Specifies the security identifier (SID).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the security identifier (SID).",
        SerializedName = @"domainSid",
        PossibleTypes = new [] { typeof(string) })]
        string ActiveDirectoryPropertyDomainSid { get; set; }
        /// <summary>Specifies the Active Directory forest to get.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the Active Directory forest to get.",
        SerializedName = @"forestName",
        PossibleTypes = new [] { typeof(string) })]
        string ActiveDirectoryPropertyForestName { get; set; }
        /// <summary>Specifies the NetBIOS domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the NetBIOS domain name.",
        SerializedName = @"netBiosDomainName",
        PossibleTypes = new [] { typeof(string) })]
        string ActiveDirectoryPropertyNetBiosDomainName { get; set; }
        /// <summary>Indicates the directory service used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Indicates the directory service used.",
        SerializedName = @"directoryServiceOptions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DirectoryServiceOptions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DirectoryServiceOptions AzureFileIdentityBasedAuthenticationDirectoryServiceOption { get; set; }
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A boolean indicating whether or not the service encrypts the data as it is stored.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? BlobEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.",
        SerializedName = @"lastEnabledTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? BlobLastEnabledTime { get;  }
        /// <summary>
        /// Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string CustomDomainName { get; set; }
        /// <summary>
        /// Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.",
        SerializedName = @"useSubDomainName",
        PossibleTypes = new [] { typeof(bool) })]
        bool? CustomDomainUseSubDomainName { get; set; }
        /// <summary>Allows https traffic only to storage service if sets to true.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Allows https traffic only to storage service if sets to true.",
        SerializedName = @"supportsHttpsTrafficOnly",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableHttpsTrafficOnly { get; set; }
        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive): Microsoft.Storage, Microsoft.Keyvault
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The encryption keySource (provider). Possible values (case-insensitive):  Microsoft.Storage, Microsoft.Keyvault",
        SerializedName = @"keySource",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeySource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeySource EncryptionKeySource { get; set; }
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A boolean indicating whether or not the service encrypts the data as it is stored.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? FileEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.",
        SerializedName = @"lastEnabledTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? FileLastEnabledTime { get;  }
        /// <summary>The name of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of KeyVault key.",
        SerializedName = @"keyname",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyKeyName { get; set; }
        /// <summary>The Uri of KeyVault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Uri of KeyVault.",
        SerializedName = @"keyvaulturi",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyKeyVaultUri { get; set; }
        /// <summary>The version of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The version of KeyVault key.",
        SerializedName = @"keyversion",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyKeyVersion { get; set; }
        /// <summary>
        /// Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled.",
        SerializedName = @"largeFileSharesState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LargeFileSharesState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LargeFileSharesState? LargeFileSharesState { get; set; }
        /// <summary>
        /// Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices
        /// (For example, "Logging, Metrics"), or None to bypass none of those traffics.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, ""Logging, Metrics""), or None to bypass none of those traffics.",
        SerializedName = @"bypass",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass? NetworkRuleSetBypass { get; set; }
        /// <summary>Specifies the default action of allow or deny when no other rules match.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the default action of allow or deny when no other rules match.",
        SerializedName = @"defaultAction",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction NetworkRuleSetDefaultAction { get; set; }
        /// <summary>Sets the IP ACL rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets the IP ACL rules",
        SerializedName = @"ipRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule[] NetworkRuleSetIPRule { get; set; }
        /// <summary>Sets the virtual network rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets the virtual network rules",
        SerializedName = @"virtualNetworkRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule[] NetworkRuleSetVirtualNetworkRule { get; set; }
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A boolean indicating whether or not the service encrypts the data as it is stored.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? QueueEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.",
        SerializedName = @"lastEnabledTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? QueueLastEnabledTime { get;  }
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A boolean indicating whether or not the service encrypts the data as it is stored.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? TableEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.",
        SerializedName = @"lastEnabledTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TableLastEnabledTime { get;  }

    }
    /// The parameters used when updating a storage account.
    internal partial interface IStorageAccountPropertiesUpdateParametersInternal

    {
        /// <summary>
        /// Required for storage accounts where kind = BlobStorage. The access tier used for billing.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessTier? AccessTier { get; set; }
        /// <summary>Specifies the security identifier (SID) for Azure Storage.</summary>
        string ActiveDirectoryPropertyAzureStorageSid { get; set; }
        /// <summary>Specifies the domain GUID.</summary>
        string ActiveDirectoryPropertyDomainGuid { get; set; }
        /// <summary>Specifies the primary domain that the AD DNS server is authoritative for.</summary>
        string ActiveDirectoryPropertyDomainName { get; set; }
        /// <summary>Specifies the security identifier (SID).</summary>
        string ActiveDirectoryPropertyDomainSid { get; set; }
        /// <summary>Specifies the Active Directory forest to get.</summary>
        string ActiveDirectoryPropertyForestName { get; set; }
        /// <summary>Specifies the NetBIOS domain name.</summary>
        string ActiveDirectoryPropertyNetBiosDomainName { get; set; }
        /// <summary>Required if choose AD.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryProperties AzureFileIdentityBasedAuthenticationActiveDirectoryProperty { get; set; }
        /// <summary>Indicates the directory service used.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DirectoryServiceOptions AzureFileIdentityBasedAuthenticationDirectoryServiceOption { get; set; }
        /// <summary>Provides the identity based authentication settings for Azure Files.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get; set; }
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        bool? BlobEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        global::System.DateTime? BlobLastEnabledTime { get; set; }
        /// <summary>
        /// Custom domain assigned to the storage account by the user. Name is the CNAME source. Only one custom domain is supported
        /// per storage account at this time. To clear the existing custom domain, use an empty string for the custom domain name
        /// property.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICustomDomain CustomDomain { get; set; }
        /// <summary>
        /// Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.
        /// </summary>
        string CustomDomainName { get; set; }
        /// <summary>
        /// Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.
        /// </summary>
        bool? CustomDomainUseSubDomainName { get; set; }
        /// <summary>Allows https traffic only to storage service if sets to true.</summary>
        bool? EnableHttpsTrafficOnly { get; set; }
        /// <summary>
        /// Provides the encryption settings on the account. The default setting is unencrypted.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryption Encryption { get; set; }
        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive): Microsoft.Storage, Microsoft.Keyvault
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeySource EncryptionKeySource { get; set; }
        /// <summary>Properties provided by key vault.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultProperties EncryptionKeyVaultProperty { get; set; }
        /// <summary>List of services which support encryption.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServices EncryptionService { get; set; }
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        bool? FileEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        global::System.DateTime? FileLastEnabledTime { get; set; }
        /// <summary>The name of KeyVault key.</summary>
        string KeyVaultPropertyKeyName { get; set; }
        /// <summary>The Uri of KeyVault.</summary>
        string KeyVaultPropertyKeyVaultUri { get; set; }
        /// <summary>The version of KeyVault key.</summary>
        string KeyVaultPropertyKeyVersion { get; set; }
        /// <summary>
        /// Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LargeFileSharesState? LargeFileSharesState { get; set; }
        /// <summary>Network rule set</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSet NetworkRuleSet { get; set; }
        /// <summary>
        /// Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices
        /// (For example, "Logging, Metrics"), or None to bypass none of those traffics.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass? NetworkRuleSetBypass { get; set; }
        /// <summary>Specifies the default action of allow or deny when no other rules match.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction NetworkRuleSetDefaultAction { get; set; }
        /// <summary>Sets the IP ACL rules</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule[] NetworkRuleSetIPRule { get; set; }
        /// <summary>Sets the virtual network rules</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule[] NetworkRuleSetVirtualNetworkRule { get; set; }
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        bool? QueueEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        global::System.DateTime? QueueLastEnabledTime { get; set; }
        /// <summary>The encryption function of the blob storage service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService ServiceBlob { get; set; }
        /// <summary>The encryption function of the file storage service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService ServiceFile { get; set; }
        /// <summary>The encryption function of the queue storage service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService ServiceQueue { get; set; }
        /// <summary>The encryption function of the table storage service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService ServiceTable { get; set; }
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        bool? TableEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        global::System.DateTime? TableLastEnabledTime { get; set; }

    }
}