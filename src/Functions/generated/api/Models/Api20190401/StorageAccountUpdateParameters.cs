namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// The parameters that can be provided when updating the storage account properties.
    /// </summary>
    public partial class StorageAccountUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal
    {

        /// <summary>
        /// Required for storage accounts where kind = BlobStorage. The access tier used for billing.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessTier? AccessTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).AccessTier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).AccessTier = value; }

        /// <summary>Specifies the security identifier (SID) for Azure Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyAzureStorageSid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ActiveDirectoryPropertyAzureStorageSid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ActiveDirectoryPropertyAzureStorageSid = value; }

        /// <summary>Specifies the domain GUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyDomainGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ActiveDirectoryPropertyDomainGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ActiveDirectoryPropertyDomainGuid = value; }

        /// <summary>Specifies the primary domain that the AD DNS server is authoritative for.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ActiveDirectoryPropertyDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ActiveDirectoryPropertyDomainName = value; }

        /// <summary>Specifies the security identifier (SID).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyDomainSid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ActiveDirectoryPropertyDomainSid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ActiveDirectoryPropertyDomainSid = value; }

        /// <summary>Specifies the Active Directory forest to get.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyForestName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ActiveDirectoryPropertyForestName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ActiveDirectoryPropertyForestName = value; }

        /// <summary>Specifies the NetBIOS domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyNetBiosDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ActiveDirectoryPropertyNetBiosDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ActiveDirectoryPropertyNetBiosDomainName = value; }

        /// <summary>Indicates the directory service used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DirectoryServiceOptions AzureFileIdentityBasedAuthenticationDirectoryServiceOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).AzureFileIdentityBasedAuthenticationDirectoryServiceOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).AzureFileIdentityBasedAuthenticationDirectoryServiceOption = value; }

        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? BlobEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).BlobEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).BlobEnabled = value; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? BlobLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).BlobLastEnabledTime; }

        /// <summary>
        /// Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).CustomDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).CustomDomainName = value; }

        /// <summary>
        /// Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? CustomDomainUseSubDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).CustomDomainUseSubDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).CustomDomainUseSubDomainName = value; }

        /// <summary>Allows https traffic only to storage service if sets to true.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? EnableHttpsTrafficOnly { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).EnableHttpsTrafficOnly; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).EnableHttpsTrafficOnly = value; }

        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive): Microsoft.Storage, Microsoft.Keyvault
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeySource EncryptionKeySource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).EncryptionKeySource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).EncryptionKeySource = value; }

        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? FileEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).FileEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).FileEnabled = value; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? FileLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).FileLastEnabledTime; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentity _identity;

        /// <summary>The identity of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Identity()); set => this._identity = value; }

        /// <summary>The principal ID of resource identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentityInternal)Identity).PrincipalId; }

        /// <summary>The tenant ID of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentityInternal)Identity).TenantId; }

        /// <summary>The identity type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentityInternal)Identity).Type; }

        /// <summary>The name of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).KeyVaultPropertyKeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).KeyVaultPropertyKeyName = value; }

        /// <summary>The Uri of KeyVault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyVaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).KeyVaultPropertyKeyVaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).KeyVaultPropertyKeyVaultUri = value; }

        /// <summary>The version of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).KeyVaultPropertyKeyVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).KeyVaultPropertyKeyVersion = value; }

        /// <summary>Backing field for <see cref="Kind" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? _kind;

        /// <summary>
        /// Optional. Indicates the type of storage account. Currently only StorageV2 value supported by server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? Kind { get => this._kind; set => this._kind = value; }

        /// <summary>
        /// Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LargeFileSharesState? LargeFileSharesState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).LargeFileSharesState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).LargeFileSharesState = value; }

        /// <summary>
        /// Internal Acessors for AzureFileIdentityBasedAuthenticationActiveDirectoryProperty
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.AzureFileIdentityBasedAuthenticationActiveDirectoryProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).AzureFileIdentityBasedAuthenticationActiveDirectoryProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).AzureFileIdentityBasedAuthenticationActiveDirectoryProperty = value; }

        /// <summary>Internal Acessors for AzureFilesIdentityBasedAuthentication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthentication Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.AzureFilesIdentityBasedAuthentication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).AzureFilesIdentityBasedAuthentication; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).AzureFilesIdentityBasedAuthentication = value; }

        /// <summary>Internal Acessors for BlobLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.BlobLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).BlobLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).BlobLastEnabledTime = value; }

        /// <summary>Internal Acessors for CustomDomain</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICustomDomain Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.CustomDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).CustomDomain; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).CustomDomain = value; }

        /// <summary>Internal Acessors for Encryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryption Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.Encryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).Encryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).Encryption = value; }

        /// <summary>Internal Acessors for EncryptionKeyVaultProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.EncryptionKeyVaultProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).EncryptionKeyVaultProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).EncryptionKeyVaultProperty = value; }

        /// <summary>Internal Acessors for EncryptionService</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServices Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.EncryptionService { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).EncryptionService; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).EncryptionService = value; }

        /// <summary>Internal Acessors for FileLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.FileLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).FileLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).FileLastEnabledTime = value; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentity Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Identity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentityInternal)Identity).PrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentityInternal)Identity).TenantId = value; }

        /// <summary>Internal Acessors for IdentityType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentityInternal)Identity).Type = value; }

        /// <summary>Internal Acessors for NetworkRuleSet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSet Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.NetworkRuleSet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).NetworkRuleSet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).NetworkRuleSet = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParameters Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.StorageAccountPropertiesUpdateParameters()); set { {_property = value;} } }

        /// <summary>Internal Acessors for QueueLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.QueueLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).QueueLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).QueueLastEnabledTime = value; }

        /// <summary>Internal Acessors for ServiceBlob</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.ServiceBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ServiceBlob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ServiceBlob = value; }

        /// <summary>Internal Acessors for ServiceFile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.ServiceFile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ServiceFile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ServiceFile = value; }

        /// <summary>Internal Acessors for ServiceQueue</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.ServiceQueue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ServiceQueue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ServiceQueue = value; }

        /// <summary>Internal Acessors for ServiceTable</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.ServiceTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ServiceTable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).ServiceTable = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Sku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for SkuCapability</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapability[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.SkuCapability { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Capability; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Capability = value; }

        /// <summary>Internal Acessors for SkuKind</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.SkuKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Kind = value; }

        /// <summary>Internal Acessors for SkuLocation</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.SkuLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Location = value; }

        /// <summary>Internal Acessors for SkuResourceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.SkuResourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).ResourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).ResourceType = value; }

        /// <summary>Internal Acessors for SkuTier</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuTier? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Tier = value; }

        /// <summary>Internal Acessors for TableLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersInternal.TableLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).TableLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).TableLastEnabledTime = value; }

        /// <summary>
        /// Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices
        /// (For example, "Logging, Metrics"), or None to bypass none of those traffics.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass? NetworkRuleSetBypass { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).NetworkRuleSetBypass; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).NetworkRuleSetBypass = value; }

        /// <summary>Specifies the default action of allow or deny when no other rules match.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction NetworkRuleSetDefaultAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).NetworkRuleSetDefaultAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).NetworkRuleSetDefaultAction = value; }

        /// <summary>Sets the IP ACL rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule[] NetworkRuleSetIPRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).NetworkRuleSetIPRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).NetworkRuleSetIPRule = value; }

        /// <summary>Sets the virtual network rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule[] NetworkRuleSetVirtualNetworkRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).NetworkRuleSetVirtualNetworkRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).NetworkRuleSetVirtualNetworkRule = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParameters _property;

        /// <summary>The parameters used when updating a storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParameters Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.StorageAccountPropertiesUpdateParameters()); set => this._property = value; }

        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? QueueEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).QueueEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).QueueEnabled = value; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? QueueLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).QueueLastEnabledTime; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku _sku;

        /// <summary>
        /// Gets or sets the SKU name. Note that the SKU name cannot be updated to Standard_ZRS, Premium_LRS or Premium_ZRS, nor can
        /// accounts of those SKU names be updated to any other value.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Sku()); set => this._sku = value; }

        /// <summary>
        /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapability[] SkuCapability { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Capability; }

        /// <summary>Indicates the type of storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? SkuKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Kind; }

        /// <summary>
        /// The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US,
        /// East US, Southeast Asia, etc.).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] SkuLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Location; }

        /// <summary>
        /// Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was
        /// called accountType.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuName SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Name = value; }

        /// <summary>The type of the resource, usually it is 'storageAccounts'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SkuResourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).ResourceType; }

        /// <summary>
        /// The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IRestriction[] SkuRestriction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Restriction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Restriction = value; }

        /// <summary>Gets the SKU tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuTier? SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Tier; }

        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? TableEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).TableEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).TableEnabled = value; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? TableLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParametersInternal)Property).TableLastEnabledTime; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersTags _tag;

        /// <summary>
        /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
        /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
        /// in length than 128 characters and a value no greater in length than 256 characters.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.StorageAccountUpdateParametersTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="StorageAccountUpdateParameters" /> instance.</summary>
        public StorageAccountUpdateParameters()
        {

        }
    }
    /// The parameters that can be provided when updating the storage account properties.
    public partial interface IStorageAccountUpdateParameters :
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
        /// <summary>The principal ID of resource identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The principal ID of resource identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get;  }
        /// <summary>The tenant ID of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The tenant ID of resource.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get;  }
        /// <summary>The identity type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"The identity type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityType { get;  }
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
        /// Optional. Indicates the type of storage account. Currently only StorageV2 value supported by server.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional. Indicates the type of storage account. Currently only StorageV2 value supported by server.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? Kind { get; set; }
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
        /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.",
        SerializedName = @"capabilities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapability) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapability[] SkuCapability { get;  }
        /// <summary>Indicates the type of storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Indicates the type of storage account.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? SkuKind { get;  }
        /// <summary>
        /// The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US,
        /// East US, Southeast Asia, etc.).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.).",
        SerializedName = @"locations",
        PossibleTypes = new [] { typeof(string) })]
        string[] SkuLocation { get;  }
        /// <summary>
        /// Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was
        /// called accountType.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuName SkuName { get; set; }
        /// <summary>The type of the resource, usually it is 'storageAccounts'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of the resource, usually it is 'storageAccounts'.",
        SerializedName = @"resourceType",
        PossibleTypes = new [] { typeof(string) })]
        string SkuResourceType { get;  }
        /// <summary>
        /// The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.",
        SerializedName = @"restrictions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IRestriction) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IRestriction[] SkuRestriction { get; set; }
        /// <summary>Gets the SKU tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the SKU tier. This is based on the SKU name.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuTier) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuTier? SkuTier { get;  }
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
        /// <summary>
        /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
        /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
        /// in length than 128 characters and a value no greater in length than 256 characters.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater in length than 128 characters and a value no greater in length than 256 characters.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersTags Tag { get; set; }

    }
    /// The parameters that can be provided when updating the storage account properties.
    internal partial interface IStorageAccountUpdateParametersInternal

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
        /// <summary>The identity of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentity Identity { get; set; }
        /// <summary>The principal ID of resource identity.</summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>The tenant ID of resource.</summary>
        string IdentityTenantId { get; set; }
        /// <summary>The identity type.</summary>
        string IdentityType { get; set; }
        /// <summary>The name of KeyVault key.</summary>
        string KeyVaultPropertyKeyName { get; set; }
        /// <summary>The Uri of KeyVault.</summary>
        string KeyVaultPropertyKeyVaultUri { get; set; }
        /// <summary>The version of KeyVault key.</summary>
        string KeyVaultPropertyKeyVersion { get; set; }
        /// <summary>
        /// Optional. Indicates the type of storage account. Currently only StorageV2 value supported by server.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? Kind { get; set; }
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
        /// <summary>The parameters used when updating a storage account.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesUpdateParameters Property { get; set; }
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
        /// Gets or sets the SKU name. Note that the SKU name cannot be updated to Standard_ZRS, Premium_LRS or Premium_ZRS, nor can
        /// accounts of those SKU names be updated to any other value.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku Sku { get; set; }
        /// <summary>
        /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapability[] SkuCapability { get; set; }
        /// <summary>Indicates the type of storage account.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? SkuKind { get; set; }
        /// <summary>
        /// The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US,
        /// East US, Southeast Asia, etc.).
        /// </summary>
        string[] SkuLocation { get; set; }
        /// <summary>
        /// Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was
        /// called accountType.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuName SkuName { get; set; }
        /// <summary>The type of the resource, usually it is 'storageAccounts'.</summary>
        string SkuResourceType { get; set; }
        /// <summary>
        /// The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IRestriction[] SkuRestriction { get; set; }
        /// <summary>Gets the SKU tier. This is based on the SKU name.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuTier? SkuTier { get; set; }
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        bool? TableEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        global::System.DateTime? TableLastEnabledTime { get; set; }
        /// <summary>
        /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
        /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
        /// in length than 128 characters and a value no greater in length than 256 characters.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountUpdateParametersTags Tag { get; set; }

    }
}