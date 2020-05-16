namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The storage account.</summary>
    public partial class StorageAccount :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccount,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.TrackedResource();

        /// <summary>
        /// Required for storage accounts where kind = BlobStorage. The access tier used for billing.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessTier? AccessTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).AccessTier; }

        /// <summary>Specifies the security identifier (SID) for Azure Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyAzureStorageSid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ActiveDirectoryPropertyAzureStorageSid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ActiveDirectoryPropertyAzureStorageSid = value; }

        /// <summary>Specifies the domain GUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyDomainGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ActiveDirectoryPropertyDomainGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ActiveDirectoryPropertyDomainGuid = value; }

        /// <summary>Specifies the primary domain that the AD DNS server is authoritative for.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ActiveDirectoryPropertyDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ActiveDirectoryPropertyDomainName = value; }

        /// <summary>Specifies the security identifier (SID).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyDomainSid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ActiveDirectoryPropertyDomainSid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ActiveDirectoryPropertyDomainSid = value; }

        /// <summary>Specifies the Active Directory forest to get.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyForestName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ActiveDirectoryPropertyForestName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ActiveDirectoryPropertyForestName = value; }

        /// <summary>Specifies the NetBIOS domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyNetBiosDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ActiveDirectoryPropertyNetBiosDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ActiveDirectoryPropertyNetBiosDomainName = value; }

        /// <summary>Indicates the directory service used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DirectoryServiceOptions AzureFileIdentityBasedAuthenticationDirectoryServiceOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).AzureFileIdentityBasedAuthenticationDirectoryServiceOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).AzureFileIdentityBasedAuthenticationDirectoryServiceOption = value; }

        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? BlobEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).BlobEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).BlobEnabled = value; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? BlobLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).BlobLastEnabledTime; }

        /// <summary>Gets the creation date and time of the storage account in UTC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? CreationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).CreationTime; }

        /// <summary>
        /// Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).CustomDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).CustomDomainName = value; }

        /// <summary>
        /// Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? CustomDomainUseSubDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).CustomDomainUseSubDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).CustomDomainUseSubDomainName = value; }

        /// <summary>Allows https traffic only to storage service if sets to true.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? EnableHttpsTrafficOnly { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).EnableHttpsTrafficOnly; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).EnableHttpsTrafficOnly = value; }

        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive): Microsoft.Storage, Microsoft.Keyvault
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeySource EncryptionKeySource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).EncryptionKeySource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).EncryptionKeySource = value; }

        /// <summary>
        /// If the failover is in progress, the value will be true, otherwise, it will be null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? FailoverInProgress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).FailoverInProgress; }

        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? FileEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).FileEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).FileEnabled = value; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? FileLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).FileLastEnabledTime; }

        /// <summary>
        /// A boolean flag which indicates whether or not account failover is supported for the account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? GeoReplicationStatCanFailover { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).GeoReplicationStatCanFailover; }

        /// <summary>
        /// All primary writes preceding this UTC date/time value are guaranteed to be available for read operations. Primary writes
        /// following this point in time may or may not be available for reads. Element may be default value if value of LastSyncTime
        /// is not available, this can happen if secondary is offline or we are in bootstrap.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? GeoReplicationStatLastSyncTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).GeoReplicationStatLastSyncTime; }

        /// <summary>
        /// The status of the secondary location. Possible values are: - Live: Indicates that the secondary location is active and
        /// operational. - Bootstrap: Indicates initial synchronization from the primary location to the secondary location is in
        /// progress.This typically occurs when replication is first enabled. - Unavailable: Indicates that the secondary location
        /// is temporarily unavailable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.GeoReplicationStatus? GeoReplicationStatStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).GeoReplicationStatStatus; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__trackedResource).Id; }

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

        /// <summary>Account HierarchicalNamespace enabled if sets to true.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsHnsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).IsHnsEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).IsHnsEnabled = value; }

        /// <summary>The name of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyvaultpropertyKeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).KeyvaultpropertyKeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).KeyvaultpropertyKeyName = value; }

        /// <summary>The Uri of KeyVault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyvaultpropertyKeyVaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).KeyvaultpropertyKeyVaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).KeyvaultpropertyKeyVaultUri = value; }

        /// <summary>The version of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyvaultpropertyKeyVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).KeyvaultpropertyKeyVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).KeyvaultpropertyKeyVersion = value; }

        /// <summary>Backing field for <see cref="Kind" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? _kind;

        /// <summary>Gets the Kind.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? Kind { get => this._kind; }

        /// <summary>
        /// Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LargeFileSharesState? LargeFileSharesState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).LargeFileSharesState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).LargeFileSharesState = value; }

        /// <summary>
        /// Gets the timestamp of the most recent instance of a failover to the secondary location. Only the most recent timestamp
        /// is retained. This element is not returned if there has never been a failover instance. Only available if the accountType
        /// is Standard_GRS or Standard_RAGRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastGeoFailoverTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).LastGeoFailoverTime; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.ITrackedResourceInternal)__trackedResource).Location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__trackedResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__trackedResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__trackedResource).Type = value; }

        /// <summary>Internal Acessors for AccessTier</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessTier? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.AccessTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).AccessTier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).AccessTier = value; }

        /// <summary>
        /// Internal Acessors for AzureFileIdentityBasedAuthenticationActiveDirectoryProperty
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.AzureFileIdentityBasedAuthenticationActiveDirectoryProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).AzureFileIdentityBasedAuthenticationActiveDirectoryProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).AzureFileIdentityBasedAuthenticationActiveDirectoryProperty = value; }

        /// <summary>Internal Acessors for AzureFilesIdentityBasedAuthentication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthentication Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.AzureFilesIdentityBasedAuthentication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).AzureFilesIdentityBasedAuthentication; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).AzureFilesIdentityBasedAuthentication = value; }

        /// <summary>Internal Acessors for BlobLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.BlobLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).BlobLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).BlobLastEnabledTime = value; }

        /// <summary>Internal Acessors for CreationTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.CreationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).CreationTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).CreationTime = value; }

        /// <summary>Internal Acessors for CustomDomain</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICustomDomain Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.CustomDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).CustomDomain; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).CustomDomain = value; }

        /// <summary>Internal Acessors for Encryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryption Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.Encryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).Encryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).Encryption = value; }

        /// <summary>Internal Acessors for EncryptionKeyvaultproperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.EncryptionKeyvaultproperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).EncryptionKeyvaultproperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).EncryptionKeyvaultproperty = value; }

        /// <summary>Internal Acessors for EncryptionService</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServices Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.EncryptionService { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).EncryptionService; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).EncryptionService = value; }

        /// <summary>Internal Acessors for FailoverInProgress</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.FailoverInProgress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).FailoverInProgress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).FailoverInProgress = value; }

        /// <summary>Internal Acessors for FileLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.FileLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).FileLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).FileLastEnabledTime = value; }

        /// <summary>Internal Acessors for GeoReplicationStat</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStats Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.GeoReplicationStat { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).GeoReplicationStat; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).GeoReplicationStat = value; }

        /// <summary>Internal Acessors for GeoReplicationStatCanFailover</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.GeoReplicationStatCanFailover { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).GeoReplicationStatCanFailover; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).GeoReplicationStatCanFailover = value; }

        /// <summary>Internal Acessors for GeoReplicationStatLastSyncTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.GeoReplicationStatLastSyncTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).GeoReplicationStatLastSyncTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).GeoReplicationStatLastSyncTime = value; }

        /// <summary>Internal Acessors for GeoReplicationStatStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.GeoReplicationStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.GeoReplicationStatStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).GeoReplicationStatStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).GeoReplicationStatStatus = value; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentity Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Identity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentityInternal)Identity).PrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentityInternal)Identity).TenantId = value; }

        /// <summary>Internal Acessors for IdentityType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentityInternal)Identity).Type = value; }

        /// <summary>Internal Acessors for Kind</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.Kind { get => this._kind; set { {_kind = value;} } }

        /// <summary>Internal Acessors for LastGeoFailoverTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.LastGeoFailoverTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).LastGeoFailoverTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).LastGeoFailoverTime = value; }

        /// <summary>Internal Acessors for NetworkAcls</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSet Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.NetworkAcls { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).NetworkAcls; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).NetworkAcls = value; }

        /// <summary>Internal Acessors for PrimaryEndpoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpoints Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.PrimaryEndpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpoint = value; }

        /// <summary>Internal Acessors for PrimaryEndpointBlob</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.PrimaryEndpointBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointBlob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointBlob = value; }

        /// <summary>Internal Acessors for PrimaryEndpointDf</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.PrimaryEndpointDf { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointDf; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointDf = value; }

        /// <summary>Internal Acessors for PrimaryEndpointFile</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.PrimaryEndpointFile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointFile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointFile = value; }

        /// <summary>Internal Acessors for PrimaryEndpointQueue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.PrimaryEndpointQueue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointQueue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointQueue = value; }

        /// <summary>Internal Acessors for PrimaryEndpointTable</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.PrimaryEndpointTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointTable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointTable = value; }

        /// <summary>Internal Acessors for PrimaryEndpointWeb</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.PrimaryEndpointWeb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointWeb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointWeb = value; }

        /// <summary>Internal Acessors for PrimaryLocation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.PrimaryLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryLocation = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.StorageAccountProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for QueueLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.QueueLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).QueueLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).QueueLastEnabledTime = value; }

        /// <summary>Internal Acessors for SecondaryEndpoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpoints Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.SecondaryEndpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpoint = value; }

        /// <summary>Internal Acessors for SecondaryEndpointBlob</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.SecondaryEndpointBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointBlob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointBlob = value; }

        /// <summary>Internal Acessors for SecondaryEndpointDf</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.SecondaryEndpointDf { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointDf; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointDf = value; }

        /// <summary>Internal Acessors for SecondaryEndpointFile</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.SecondaryEndpointFile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointFile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointFile = value; }

        /// <summary>Internal Acessors for SecondaryEndpointQueue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.SecondaryEndpointQueue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointQueue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointQueue = value; }

        /// <summary>Internal Acessors for SecondaryEndpointTable</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.SecondaryEndpointTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointTable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointTable = value; }

        /// <summary>Internal Acessors for SecondaryEndpointWeb</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.SecondaryEndpointWeb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointWeb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointWeb = value; }

        /// <summary>Internal Acessors for SecondaryLocation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.SecondaryLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryLocation = value; }

        /// <summary>Internal Acessors for ServiceBlob</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.ServiceBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ServiceBlob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ServiceBlob = value; }

        /// <summary>Internal Acessors for ServiceFile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.ServiceFile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ServiceFile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ServiceFile = value; }

        /// <summary>Internal Acessors for ServiceQueue</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.ServiceQueue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ServiceQueue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ServiceQueue = value; }

        /// <summary>Internal Acessors for ServiceTable</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.ServiceTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ServiceTable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ServiceTable = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Sku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for SkuCapability</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapability[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.SkuCapability { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Capability; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Capability = value; }

        /// <summary>Internal Acessors for SkuKind</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.SkuKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Kind = value; }

        /// <summary>Internal Acessors for SkuLocation</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.SkuLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Location = value; }

        /// <summary>Internal Acessors for SkuResourceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.SkuResourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).ResourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).ResourceType = value; }

        /// <summary>Internal Acessors for SkuTier</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuTier? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal)Sku).Tier = value; }

        /// <summary>Internal Acessors for StatusOfPrimary</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccountStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.StatusOfPrimary { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).StatusOfPrimary; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).StatusOfPrimary = value; }

        /// <summary>Internal Acessors for StatusOfSecondary</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccountStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.StatusOfSecondary { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).StatusOfSecondary; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).StatusOfSecondary = value; }

        /// <summary>Internal Acessors for TableLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountInternal.TableLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).TableLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).TableLastEnabledTime = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__trackedResource).Name; }

        /// <summary>
        /// Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices
        /// (For example, "Logging, Metrics"), or None to bypass none of those traffics.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass? NetworkAclsBypass { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).NetworkAclsBypass; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).NetworkAclsBypass = value; }

        /// <summary>Specifies the default action of allow or deny when no other rules match.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction NetworkAclsDefaultAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).NetworkAclsDefaultAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).NetworkAclsDefaultAction = value; }

        /// <summary>Sets the IP ACL rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule[] NetworkAclsIPRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).NetworkAclsIPRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).NetworkAclsIPRule = value; }

        /// <summary>Sets the virtual network rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule[] NetworkAclsVirtualNetworkRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).NetworkAclsVirtualNetworkRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).NetworkAclsVirtualNetworkRule = value; }

        /// <summary>Gets the blob endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrimaryEndpointBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointBlob; }

        /// <summary>Gets the dfs endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrimaryEndpointDf { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointDf; }

        /// <summary>Gets the file endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrimaryEndpointFile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointFile; }

        /// <summary>Gets the queue endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrimaryEndpointQueue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointQueue; }

        /// <summary>Gets the table endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrimaryEndpointTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointTable; }

        /// <summary>Gets the web endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrimaryEndpointWeb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryEndpointWeb; }

        /// <summary>Gets the location of the primary data center for the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrimaryLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).PrimaryLocation; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountProperties _property;

        /// <summary>Properties of the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.StorageAccountProperties()); set => this._property = value; }

        /// <summary>Gets the status of the storage account at the time the operation was called.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? QueueEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).QueueEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).QueueEnabled = value; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? QueueLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).QueueLastEnabledTime; }

        /// <summary>Gets the blob endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SecondaryEndpointBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointBlob; }

        /// <summary>Gets the dfs endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SecondaryEndpointDf { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointDf; }

        /// <summary>Gets the file endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SecondaryEndpointFile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointFile; }

        /// <summary>Gets the queue endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SecondaryEndpointQueue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointQueue; }

        /// <summary>Gets the table endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SecondaryEndpointTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointTable; }

        /// <summary>Gets the web endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SecondaryEndpointWeb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryEndpointWeb; }

        /// <summary>
        /// Gets the location of the geo-replicated secondary for the storage account. Only available if the accountType is Standard_GRS
        /// or Standard_RAGRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SecondaryLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).SecondaryLocation; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku _sku;

        /// <summary>Gets the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Sku()); }

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
        /// Gets the status indicating whether the primary location of the storage account is available or unavailable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccountStatus? StatusOfPrimary { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).StatusOfPrimary; }

        /// <summary>
        /// Gets the status indicating whether the secondary location of the storage account is available or unavailable. Only available
        /// if the SKU name is Standard_GRS or Standard_RAGRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccountStatus? StatusOfSecondary { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).StatusOfSecondary; }

        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? TableEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).TableEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).TableEnabled = value; }

        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? TableLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal)Property).TableLastEnabledTime; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.ITrackedResourceInternal)__trackedResource).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__trackedResource).Type; }

        /// <summary>Creates an new <see cref="StorageAccount" /> instance.</summary>
        public StorageAccount()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// The storage account.
    public partial interface IStorageAccount :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.ITrackedResource
    {
        /// <summary>
        /// Required for storage accounts where kind = BlobStorage. The access tier used for billing.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Required for storage accounts where kind = BlobStorage. The access tier used for billing.",
        SerializedName = @"accessTier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessTier) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessTier? AccessTier { get;  }
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
        /// <summary>Gets the creation date and time of the storage account in UTC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the creation date and time of the storage account in UTC.",
        SerializedName = @"creationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreationTime { get;  }
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
        /// If the failover is in progress, the value will be true, otherwise, it will be null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"If the failover is in progress, the value will be true, otherwise, it will be null.",
        SerializedName = @"failoverInProgress",
        PossibleTypes = new [] { typeof(bool) })]
        bool? FailoverInProgress { get;  }
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
        /// <summary>
        /// A boolean flag which indicates whether or not account failover is supported for the account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A boolean flag which indicates whether or not account failover is supported for the account.",
        SerializedName = @"canFailover",
        PossibleTypes = new [] { typeof(bool) })]
        bool? GeoReplicationStatCanFailover { get;  }
        /// <summary>
        /// All primary writes preceding this UTC date/time value are guaranteed to be available for read operations. Primary writes
        /// following this point in time may or may not be available for reads. Element may be default value if value of LastSyncTime
        /// is not available, this can happen if secondary is offline or we are in bootstrap.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"All primary writes preceding this UTC date/time value are guaranteed to be available for read operations. Primary writes following this point in time may or may not be available for reads. Element may be default value if value of LastSyncTime is not available, this can happen if secondary is offline or we are in bootstrap.",
        SerializedName = @"lastSyncTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? GeoReplicationStatLastSyncTime { get;  }
        /// <summary>
        /// The status of the secondary location. Possible values are: - Live: Indicates that the secondary location is active and
        /// operational. - Bootstrap: Indicates initial synchronization from the primary location to the secondary location is in
        /// progress.This typically occurs when replication is first enabled. - Unavailable: Indicates that the secondary location
        /// is temporarily unavailable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The status of the secondary location. Possible values are: - Live: Indicates that the secondary location is active and operational. - Bootstrap: Indicates initial synchronization from the primary location to the secondary location is in progress.This typically occurs when replication is first enabled. - Unavailable: Indicates that the secondary location is temporarily unavailable.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.GeoReplicationStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.GeoReplicationStatus? GeoReplicationStatStatus { get;  }
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
        /// <summary>Account HierarchicalNamespace enabled if sets to true.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Account HierarchicalNamespace enabled if sets to true.",
        SerializedName = @"isHnsEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsHnsEnabled { get; set; }
        /// <summary>The name of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of KeyVault key.",
        SerializedName = @"keyname",
        PossibleTypes = new [] { typeof(string) })]
        string KeyvaultpropertyKeyName { get; set; }
        /// <summary>The Uri of KeyVault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Uri of KeyVault.",
        SerializedName = @"keyvaulturi",
        PossibleTypes = new [] { typeof(string) })]
        string KeyvaultpropertyKeyVaultUri { get; set; }
        /// <summary>The version of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The version of KeyVault key.",
        SerializedName = @"keyversion",
        PossibleTypes = new [] { typeof(string) })]
        string KeyvaultpropertyKeyVersion { get; set; }
        /// <summary>Gets the Kind.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the Kind.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? Kind { get;  }
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
        /// Gets the timestamp of the most recent instance of a failover to the secondary location. Only the most recent timestamp
        /// is retained. This element is not returned if there has never been a failover instance. Only available if the accountType
        /// is Standard_GRS or Standard_RAGRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the timestamp of the most recent instance of a failover to the secondary location. Only the most recent timestamp is retained. This element is not returned if there has never been a failover instance. Only available if the accountType is Standard_GRS or Standard_RAGRS.",
        SerializedName = @"lastGeoFailoverTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastGeoFailoverTime { get;  }
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
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass? NetworkAclsBypass { get; set; }
        /// <summary>Specifies the default action of allow or deny when no other rules match.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the default action of allow or deny when no other rules match.",
        SerializedName = @"defaultAction",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction NetworkAclsDefaultAction { get; set; }
        /// <summary>Sets the IP ACL rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets the IP ACL rules",
        SerializedName = @"ipRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule[] NetworkAclsIPRule { get; set; }
        /// <summary>Sets the virtual network rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets the virtual network rules",
        SerializedName = @"virtualNetworkRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule[] NetworkAclsVirtualNetworkRule { get; set; }
        /// <summary>Gets the blob endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the blob endpoint.",
        SerializedName = @"blob",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryEndpointBlob { get;  }
        /// <summary>Gets the dfs endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the dfs endpoint.",
        SerializedName = @"dfs",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryEndpointDf { get;  }
        /// <summary>Gets the file endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the file endpoint.",
        SerializedName = @"file",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryEndpointFile { get;  }
        /// <summary>Gets the queue endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the queue endpoint.",
        SerializedName = @"queue",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryEndpointQueue { get;  }
        /// <summary>Gets the table endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the table endpoint.",
        SerializedName = @"table",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryEndpointTable { get;  }
        /// <summary>Gets the web endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the web endpoint.",
        SerializedName = @"web",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryEndpointWeb { get;  }
        /// <summary>Gets the location of the primary data center for the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the location of the primary data center for the storage account.",
        SerializedName = @"primaryLocation",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryLocation { get;  }
        /// <summary>Gets the status of the storage account at the time the operation was called.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the status of the storage account at the time the operation was called.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get;  }
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
        /// <summary>Gets the blob endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the blob endpoint.",
        SerializedName = @"blob",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryEndpointBlob { get;  }
        /// <summary>Gets the dfs endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the dfs endpoint.",
        SerializedName = @"dfs",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryEndpointDf { get;  }
        /// <summary>Gets the file endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the file endpoint.",
        SerializedName = @"file",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryEndpointFile { get;  }
        /// <summary>Gets the queue endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the queue endpoint.",
        SerializedName = @"queue",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryEndpointQueue { get;  }
        /// <summary>Gets the table endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the table endpoint.",
        SerializedName = @"table",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryEndpointTable { get;  }
        /// <summary>Gets the web endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the web endpoint.",
        SerializedName = @"web",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryEndpointWeb { get;  }
        /// <summary>
        /// Gets the location of the geo-replicated secondary for the storage account. Only available if the accountType is Standard_GRS
        /// or Standard_RAGRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the location of the geo-replicated secondary for the storage account. Only available if the accountType is Standard_GRS or Standard_RAGRS.",
        SerializedName = @"secondaryLocation",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryLocation { get;  }
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
        /// Gets the status indicating whether the primary location of the storage account is available or unavailable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the status indicating whether the primary location of the storage account is available or unavailable.",
        SerializedName = @"statusOfPrimary",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccountStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccountStatus? StatusOfPrimary { get;  }
        /// <summary>
        /// Gets the status indicating whether the secondary location of the storage account is available or unavailable. Only available
        /// if the SKU name is Standard_GRS or Standard_RAGRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the status indicating whether the secondary location of the storage account is available or unavailable. Only available if the SKU name is Standard_GRS or Standard_RAGRS.",
        SerializedName = @"statusOfSecondary",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccountStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccountStatus? StatusOfSecondary { get;  }
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
    /// The storage account.
    internal partial interface IStorageAccountInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.ITrackedResourceInternal
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
        /// <summary>Gets the creation date and time of the storage account in UTC.</summary>
        global::System.DateTime? CreationTime { get; set; }
        /// <summary>Gets the custom domain the user assigned to this storage account.</summary>
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
        /// Gets the encryption settings on the account. If unspecified, the account is unencrypted.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryption Encryption { get; set; }
        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive): Microsoft.Storage, Microsoft.Keyvault
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeySource EncryptionKeySource { get; set; }
        /// <summary>Properties provided by key vault.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultProperties EncryptionKeyvaultproperty { get; set; }
        /// <summary>List of services which support encryption.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServices EncryptionService { get; set; }
        /// <summary>
        /// If the failover is in progress, the value will be true, otherwise, it will be null.
        /// </summary>
        bool? FailoverInProgress { get; set; }
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        bool? FileEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        global::System.DateTime? FileLastEnabledTime { get; set; }
        /// <summary>Geo Replication Stats</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStats GeoReplicationStat { get; set; }
        /// <summary>
        /// A boolean flag which indicates whether or not account failover is supported for the account.
        /// </summary>
        bool? GeoReplicationStatCanFailover { get; set; }
        /// <summary>
        /// All primary writes preceding this UTC date/time value are guaranteed to be available for read operations. Primary writes
        /// following this point in time may or may not be available for reads. Element may be default value if value of LastSyncTime
        /// is not available, this can happen if secondary is offline or we are in bootstrap.
        /// </summary>
        global::System.DateTime? GeoReplicationStatLastSyncTime { get; set; }
        /// <summary>
        /// The status of the secondary location. Possible values are: - Live: Indicates that the secondary location is active and
        /// operational. - Bootstrap: Indicates initial synchronization from the primary location to the secondary location is in
        /// progress.This typically occurs when replication is first enabled. - Unavailable: Indicates that the secondary location
        /// is temporarily unavailable.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.GeoReplicationStatus? GeoReplicationStatStatus { get; set; }
        /// <summary>The identity of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIdentity Identity { get; set; }
        /// <summary>The principal ID of resource identity.</summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>The tenant ID of resource.</summary>
        string IdentityTenantId { get; set; }
        /// <summary>The identity type.</summary>
        string IdentityType { get; set; }
        /// <summary>Account HierarchicalNamespace enabled if sets to true.</summary>
        bool? IsHnsEnabled { get; set; }
        /// <summary>The name of KeyVault key.</summary>
        string KeyvaultpropertyKeyName { get; set; }
        /// <summary>The Uri of KeyVault.</summary>
        string KeyvaultpropertyKeyVaultUri { get; set; }
        /// <summary>The version of KeyVault key.</summary>
        string KeyvaultpropertyKeyVersion { get; set; }
        /// <summary>Gets the Kind.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? Kind { get; set; }
        /// <summary>
        /// Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LargeFileSharesState? LargeFileSharesState { get; set; }
        /// <summary>
        /// Gets the timestamp of the most recent instance of a failover to the secondary location. Only the most recent timestamp
        /// is retained. This element is not returned if there has never been a failover instance. Only available if the accountType
        /// is Standard_GRS or Standard_RAGRS.
        /// </summary>
        global::System.DateTime? LastGeoFailoverTime { get; set; }
        /// <summary>Network rule set</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSet NetworkAcls { get; set; }
        /// <summary>
        /// Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices
        /// (For example, "Logging, Metrics"), or None to bypass none of those traffics.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass? NetworkAclsBypass { get; set; }
        /// <summary>Specifies the default action of allow or deny when no other rules match.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction NetworkAclsDefaultAction { get; set; }
        /// <summary>Sets the IP ACL rules</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule[] NetworkAclsIPRule { get; set; }
        /// <summary>Sets the virtual network rules</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule[] NetworkAclsVirtualNetworkRule { get; set; }
        /// <summary>
        /// Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object. Note that Standard_ZRS and
        /// Premium_LRS accounts only return the blob endpoint.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpoints PrimaryEndpoint { get; set; }
        /// <summary>Gets the blob endpoint.</summary>
        string PrimaryEndpointBlob { get; set; }
        /// <summary>Gets the dfs endpoint.</summary>
        string PrimaryEndpointDf { get; set; }
        /// <summary>Gets the file endpoint.</summary>
        string PrimaryEndpointFile { get; set; }
        /// <summary>Gets the queue endpoint.</summary>
        string PrimaryEndpointQueue { get; set; }
        /// <summary>Gets the table endpoint.</summary>
        string PrimaryEndpointTable { get; set; }
        /// <summary>Gets the web endpoint.</summary>
        string PrimaryEndpointWeb { get; set; }
        /// <summary>Gets the location of the primary data center for the storage account.</summary>
        string PrimaryLocation { get; set; }
        /// <summary>Properties of the storage account.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountProperties Property { get; set; }
        /// <summary>Gets the status of the storage account at the time the operation was called.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>
        /// A boolean indicating whether or not the service encrypts the data as it is stored.
        /// </summary>
        bool? QueueEnabled { get; set; }
        /// <summary>
        /// Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption
        /// is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate.
        /// </summary>
        global::System.DateTime? QueueLastEnabledTime { get; set; }
        /// <summary>
        /// Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object from the secondary location
        /// of the storage account. Only available if the SKU name is Standard_RAGRS.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpoints SecondaryEndpoint { get; set; }
        /// <summary>Gets the blob endpoint.</summary>
        string SecondaryEndpointBlob { get; set; }
        /// <summary>Gets the dfs endpoint.</summary>
        string SecondaryEndpointDf { get; set; }
        /// <summary>Gets the file endpoint.</summary>
        string SecondaryEndpointFile { get; set; }
        /// <summary>Gets the queue endpoint.</summary>
        string SecondaryEndpointQueue { get; set; }
        /// <summary>Gets the table endpoint.</summary>
        string SecondaryEndpointTable { get; set; }
        /// <summary>Gets the web endpoint.</summary>
        string SecondaryEndpointWeb { get; set; }
        /// <summary>
        /// Gets the location of the geo-replicated secondary for the storage account. Only available if the accountType is Standard_GRS
        /// or Standard_RAGRS.
        /// </summary>
        string SecondaryLocation { get; set; }
        /// <summary>The encryption function of the blob storage service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService ServiceBlob { get; set; }
        /// <summary>The encryption function of the file storage service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService ServiceFile { get; set; }
        /// <summary>The encryption function of the queue storage service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService ServiceQueue { get; set; }
        /// <summary>The encryption function of the table storage service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService ServiceTable { get; set; }
        /// <summary>Gets the SKU.</summary>
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
        /// Gets the status indicating whether the primary location of the storage account is available or unavailable.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccountStatus? StatusOfPrimary { get; set; }
        /// <summary>
        /// Gets the status indicating whether the secondary location of the storage account is available or unavailable. Only available
        /// if the SKU name is Standard_GRS or Standard_RAGRS.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccountStatus? StatusOfSecondary { get; set; }
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