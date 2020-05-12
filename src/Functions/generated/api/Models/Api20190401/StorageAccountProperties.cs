namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Properties of the storage account.</summary>
    public partial class StorageAccountProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AccessTier" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessTier? _accessTier;

        /// <summary>
        /// Required for storage accounts where kind = BlobStorage. The access tier used for billing.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessTier? AccessTier { get => this._accessTier; }

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

        /// <summary>Backing field for <see cref="CreationTime" /> property.</summary>
        private global::System.DateTime? _creationTime;

        /// <summary>Gets the creation date and time of the storage account in UTC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? CreationTime { get => this._creationTime; }

        /// <summary>Backing field for <see cref="CustomDomain" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICustomDomain _customDomain;

        /// <summary>Gets the custom domain the user assigned to this storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICustomDomain CustomDomain { get => (this._customDomain = this._customDomain ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.CustomDomain()); }

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
        /// Gets the encryption settings on the account. If unspecified, the account is unencrypted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryption Encryption { get => (this._encryption = this._encryption ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Encryption()); }

        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive): Microsoft.Storage, Microsoft.Keyvault
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeySource EncryptionKeySource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeySource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeySource = value; }

        /// <summary>Backing field for <see cref="FailoverInProgress" /> property.</summary>
        private bool? _failoverInProgress;

        /// <summary>
        /// If the failover is in progress, the value will be true, otherwise, it will be null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? FailoverInProgress { get => this._failoverInProgress; }

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

        /// <summary>Backing field for <see cref="GeoReplicationStat" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStats _geoReplicationStat;

        /// <summary>Geo Replication Stats</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStats GeoReplicationStat { get => (this._geoReplicationStat = this._geoReplicationStat ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.GeoReplicationStats()); }

        /// <summary>
        /// A boolean flag which indicates whether or not account failover is supported for the account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? GeoReplicationStatCanFailover { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStatsInternal)GeoReplicationStat).CanFailover; }

        /// <summary>
        /// All primary writes preceding this UTC date/time value are guaranteed to be available for read operations. Primary writes
        /// following this point in time may or may not be available for reads. Element may be default value if value of LastSyncTime
        /// is not available, this can happen if secondary is offline or we are in bootstrap.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? GeoReplicationStatLastSyncTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStatsInternal)GeoReplicationStat).LastSyncTime; }

        /// <summary>
        /// The status of the secondary location. Possible values are: - Live: Indicates that the secondary location is active and
        /// operational. - Bootstrap: Indicates initial synchronization from the primary location to the secondary location is in
        /// progress.This typically occurs when replication is first enabled. - Unavailable: Indicates that the secondary location
        /// is temporarily unavailable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.GeoReplicationStatus? GeoReplicationStatStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStatsInternal)GeoReplicationStat).Status; }

        /// <summary>Backing field for <see cref="IsHnsEnabled" /> property.</summary>
        private bool? _isHnsEnabled;

        /// <summary>Account HierarchicalNamespace enabled if sets to true.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsHnsEnabled { get => this._isHnsEnabled; set => this._isHnsEnabled = value; }

        /// <summary>The name of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyvaultpropertyKeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeyvaultpropertyKeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeyvaultpropertyKeyName = value; }

        /// <summary>The Uri of KeyVault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyvaultpropertyKeyVaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeyvaultpropertyKeyVaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeyvaultpropertyKeyVaultUri = value; }

        /// <summary>The version of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyvaultpropertyKeyVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeyvaultpropertyKeyVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).KeyvaultpropertyKeyVersion = value; }

        /// <summary>Backing field for <see cref="LargeFileSharesState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LargeFileSharesState? _largeFileSharesState;

        /// <summary>
        /// Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LargeFileSharesState? LargeFileSharesState { get => this._largeFileSharesState; set => this._largeFileSharesState = value; }

        /// <summary>Backing field for <see cref="LastGeoFailoverTime" /> property.</summary>
        private global::System.DateTime? _lastGeoFailoverTime;

        /// <summary>
        /// Gets the timestamp of the most recent instance of a failover to the secondary location. Only the most recent timestamp
        /// is retained. This element is not returned if there has never been a failover instance. Only available if the accountType
        /// is Standard_GRS or Standard_RAGRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? LastGeoFailoverTime { get => this._lastGeoFailoverTime; }

        /// <summary>Internal Acessors for AccessTier</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccessTier? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.AccessTier { get => this._accessTier; set { {_accessTier = value;} } }

        /// <summary>
        /// Internal Acessors for AzureFileIdentityBasedAuthenticationActiveDirectoryProperty
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.AzureFileIdentityBasedAuthenticationActiveDirectoryProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).ActiveDirectoryProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal)AzureFilesIdentityBasedAuthentication).ActiveDirectoryProperty = value; }

        /// <summary>Internal Acessors for AzureFilesIdentityBasedAuthentication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthentication Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.AzureFilesIdentityBasedAuthentication { get => (this._azureFilesIdentityBasedAuthentication = this._azureFilesIdentityBasedAuthentication ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.AzureFilesIdentityBasedAuthentication()); set { {_azureFilesIdentityBasedAuthentication = value;} } }

        /// <summary>Internal Acessors for BlobLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.BlobLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).BlobLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).BlobLastEnabledTime = value; }

        /// <summary>Internal Acessors for CreationTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.CreationTime { get => this._creationTime; set { {_creationTime = value;} } }

        /// <summary>Internal Acessors for CustomDomain</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ICustomDomain Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.CustomDomain { get => (this._customDomain = this._customDomain ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.CustomDomain()); set { {_customDomain = value;} } }

        /// <summary>Internal Acessors for Encryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryption Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.Encryption { get => (this._encryption = this._encryption ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Encryption()); set { {_encryption = value;} } }

        /// <summary>Internal Acessors for EncryptionKeyvaultproperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.EncryptionKeyvaultproperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).Keyvaultproperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).Keyvaultproperty = value; }

        /// <summary>Internal Acessors for EncryptionService</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServices Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.EncryptionService { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).Service; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).Service = value; }

        /// <summary>Internal Acessors for FailoverInProgress</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.FailoverInProgress { get => this._failoverInProgress; set { {_failoverInProgress = value;} } }

        /// <summary>Internal Acessors for FileLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.FileLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).FileLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).FileLastEnabledTime = value; }

        /// <summary>Internal Acessors for GeoReplicationStat</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStats Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.GeoReplicationStat { get => (this._geoReplicationStat = this._geoReplicationStat ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.GeoReplicationStats()); set { {_geoReplicationStat = value;} } }

        /// <summary>Internal Acessors for GeoReplicationStatCanFailover</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.GeoReplicationStatCanFailover { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStatsInternal)GeoReplicationStat).CanFailover; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStatsInternal)GeoReplicationStat).CanFailover = value; }

        /// <summary>Internal Acessors for GeoReplicationStatLastSyncTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.GeoReplicationStatLastSyncTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStatsInternal)GeoReplicationStat).LastSyncTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStatsInternal)GeoReplicationStat).LastSyncTime = value; }

        /// <summary>Internal Acessors for GeoReplicationStatStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.GeoReplicationStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.GeoReplicationStatStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStatsInternal)GeoReplicationStat).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStatsInternal)GeoReplicationStat).Status = value; }

        /// <summary>Internal Acessors for LastGeoFailoverTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.LastGeoFailoverTime { get => this._lastGeoFailoverTime; set { {_lastGeoFailoverTime = value;} } }

        /// <summary>Internal Acessors for NetworkAcls</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSet Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.NetworkAcls { get => (this._networkAcls = this._networkAcls ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.NetworkRuleSet()); set { {_networkAcls = value;} } }

        /// <summary>Internal Acessors for PrimaryEndpoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpoints Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.PrimaryEndpoint { get => (this._primaryEndpoint = this._primaryEndpoint ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Endpoints()); set { {_primaryEndpoint = value;} } }

        /// <summary>Internal Acessors for PrimaryEndpointBlob</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.PrimaryEndpointBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).Blob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).Blob = value; }

        /// <summary>Internal Acessors for PrimaryEndpointDf</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.PrimaryEndpointDf { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).Df; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).Df = value; }

        /// <summary>Internal Acessors for PrimaryEndpointFile</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.PrimaryEndpointFile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).File; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).File = value; }

        /// <summary>Internal Acessors for PrimaryEndpointQueue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.PrimaryEndpointQueue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).Queue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).Queue = value; }

        /// <summary>Internal Acessors for PrimaryEndpointTable</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.PrimaryEndpointTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).Table; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).Table = value; }

        /// <summary>Internal Acessors for PrimaryEndpointWeb</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.PrimaryEndpointWeb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).Web; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).Web = value; }

        /// <summary>Internal Acessors for PrimaryLocation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.PrimaryLocation { get => this._primaryLocation; set { {_primaryLocation = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for QueueLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.QueueLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).QueueLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).QueueLastEnabledTime = value; }

        /// <summary>Internal Acessors for SecondaryEndpoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpoints Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.SecondaryEndpoint { get => (this._secondaryEndpoint = this._secondaryEndpoint ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Endpoints()); set { {_secondaryEndpoint = value;} } }

        /// <summary>Internal Acessors for SecondaryEndpointBlob</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.SecondaryEndpointBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).Blob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).Blob = value; }

        /// <summary>Internal Acessors for SecondaryEndpointDf</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.SecondaryEndpointDf { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).Df; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).Df = value; }

        /// <summary>Internal Acessors for SecondaryEndpointFile</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.SecondaryEndpointFile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).File; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).File = value; }

        /// <summary>Internal Acessors for SecondaryEndpointQueue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.SecondaryEndpointQueue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).Queue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).Queue = value; }

        /// <summary>Internal Acessors for SecondaryEndpointTable</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.SecondaryEndpointTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).Table; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).Table = value; }

        /// <summary>Internal Acessors for SecondaryEndpointWeb</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.SecondaryEndpointWeb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).Web; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).Web = value; }

        /// <summary>Internal Acessors for SecondaryLocation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.SecondaryLocation { get => this._secondaryLocation; set { {_secondaryLocation = value;} } }

        /// <summary>Internal Acessors for ServiceBlob</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.ServiceBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).ServiceBlob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).ServiceBlob = value; }

        /// <summary>Internal Acessors for ServiceFile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.ServiceFile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).ServiceFile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).ServiceFile = value; }

        /// <summary>Internal Acessors for ServiceQueue</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.ServiceQueue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).ServiceQueue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).ServiceQueue = value; }

        /// <summary>Internal Acessors for ServiceTable</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.ServiceTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).ServiceTable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).ServiceTable = value; }

        /// <summary>Internal Acessors for StatusOfPrimary</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccountStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.StatusOfPrimary { get => this._statusOfPrimary; set { {_statusOfPrimary = value;} } }

        /// <summary>Internal Acessors for StatusOfSecondary</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccountStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.StatusOfSecondary { get => this._statusOfSecondary; set { {_statusOfSecondary = value;} } }

        /// <summary>Internal Acessors for TableLastEnabledTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountPropertiesInternal.TableLastEnabledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).TableLastEnabledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)Encryption).TableLastEnabledTime = value; }

        /// <summary>Backing field for <see cref="NetworkAcls" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSet _networkAcls;

        /// <summary>Network rule set</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSet NetworkAcls { get => (this._networkAcls = this._networkAcls ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.NetworkRuleSet()); }

        /// <summary>
        /// Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices
        /// (For example, "Logging, Metrics"), or None to bypass none of those traffics.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass? NetworkAclsBypass { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)NetworkAcls).Bypass; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)NetworkAcls).Bypass = value; }

        /// <summary>Specifies the default action of allow or deny when no other rules match.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction NetworkAclsDefaultAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)NetworkAcls).DefaultAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)NetworkAcls).DefaultAction = value; }

        /// <summary>Sets the IP ACL rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule[] NetworkAclsIPRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)NetworkAcls).IPRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)NetworkAcls).IPRule = value; }

        /// <summary>Sets the virtual network rules</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule[] NetworkAclsVirtualNetworkRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)NetworkAcls).VirtualNetworkRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)NetworkAcls).VirtualNetworkRule = value; }

        /// <summary>Backing field for <see cref="PrimaryEndpoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpoints _primaryEndpoint;

        /// <summary>
        /// Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object. Note that Standard_ZRS and
        /// Premium_LRS accounts only return the blob endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpoints PrimaryEndpoint { get => (this._primaryEndpoint = this._primaryEndpoint ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Endpoints()); }

        /// <summary>Gets the blob endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrimaryEndpointBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).Blob; }

        /// <summary>Gets the dfs endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrimaryEndpointDf { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).Df; }

        /// <summary>Gets the file endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrimaryEndpointFile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).File; }

        /// <summary>Gets the queue endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrimaryEndpointQueue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).Queue; }

        /// <summary>Gets the table endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrimaryEndpointTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).Table; }

        /// <summary>Gets the web endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrimaryEndpointWeb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)PrimaryEndpoint).Web; }

        /// <summary>Backing field for <see cref="PrimaryLocation" /> property.</summary>
        private string _primaryLocation;

        /// <summary>Gets the location of the primary data center for the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PrimaryLocation { get => this._primaryLocation; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? _provisioningState;

        /// <summary>Gets the status of the storage account at the time the operation was called.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

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

        /// <summary>Backing field for <see cref="SecondaryEndpoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpoints _secondaryEndpoint;

        /// <summary>
        /// Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object from the secondary location
        /// of the storage account. Only available if the SKU name is Standard_RAGRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpoints SecondaryEndpoint { get => (this._secondaryEndpoint = this._secondaryEndpoint ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Endpoints()); }

        /// <summary>Gets the blob endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SecondaryEndpointBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).Blob; }

        /// <summary>Gets the dfs endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SecondaryEndpointDf { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).Df; }

        /// <summary>Gets the file endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SecondaryEndpointFile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).File; }

        /// <summary>Gets the queue endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SecondaryEndpointQueue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).Queue; }

        /// <summary>Gets the table endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SecondaryEndpointTable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).Table; }

        /// <summary>Gets the web endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SecondaryEndpointWeb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)SecondaryEndpoint).Web; }

        /// <summary>Backing field for <see cref="SecondaryLocation" /> property.</summary>
        private string _secondaryLocation;

        /// <summary>
        /// Gets the location of the geo-replicated secondary for the storage account. Only available if the accountType is Standard_GRS
        /// or Standard_RAGRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SecondaryLocation { get => this._secondaryLocation; }

        /// <summary>Backing field for <see cref="StatusOfPrimary" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccountStatus? _statusOfPrimary;

        /// <summary>
        /// Gets the status indicating whether the primary location of the storage account is available or unavailable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccountStatus? StatusOfPrimary { get => this._statusOfPrimary; }

        /// <summary>Backing field for <see cref="StatusOfSecondary" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccountStatus? _statusOfSecondary;

        /// <summary>
        /// Gets the status indicating whether the secondary location of the storage account is available or unavailable. Only available
        /// if the SKU name is Standard_GRS or Standard_RAGRS.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AccountStatus? StatusOfSecondary { get => this._statusOfSecondary; }

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

        /// <summary>Creates an new <see cref="StorageAccountProperties" /> instance.</summary>
        public StorageAccountProperties()
        {

        }
    }
    /// Properties of the storage account.
    public partial interface IStorageAccountProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
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
    /// Properties of the storage account.
    internal partial interface IStorageAccountPropertiesInternal

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
        /// <summary>Account HierarchicalNamespace enabled if sets to true.</summary>
        bool? IsHnsEnabled { get; set; }
        /// <summary>The name of KeyVault key.</summary>
        string KeyvaultpropertyKeyName { get; set; }
        /// <summary>The Uri of KeyVault.</summary>
        string KeyvaultpropertyKeyVaultUri { get; set; }
        /// <summary>The version of KeyVault key.</summary>
        string KeyvaultpropertyKeyVersion { get; set; }
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