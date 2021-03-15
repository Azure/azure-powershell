namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>Represents a server.</summary>
    public partial class Server :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServer,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerInternal,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.TrackedResource();

        /// <summary>
        /// The administrator's login name of a server. Can only be specified when the server is being created (and is required for
        /// creation).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.FormatTable(Index = 2)]
        public string AdministratorLogin { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).AdministratorLogin; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).AdministratorLogin = value ?? null; }

        /// <summary>
        /// Status showing whether the server data encryption is enabled with customer-managed keys.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public string ByokEnforcement { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).ByokEnforcement; }

        /// <summary>Earliest restore point creation time (ISO8601 format)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public global::System.DateTime? EarliestRestoreDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).EarliestRestoreDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).EarliestRestoreDate = value ?? default(global::System.DateTime); }

        /// <summary>The fully qualified domain name of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public string FullyQualifiedDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).FullyQualifiedDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).FullyQualifiedDomainName = value ?? null; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)__trackedResource).Id; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IResourceIdentity _identity;

        /// <summary>The Azure Active Directory identity of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IResourceIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ResourceIdentity()); set => this._identity = value; }

        /// <summary>The Azure Active Directory principal id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IResourceIdentityInternal)Identity).PrincipalId; }

        /// <summary>The Azure Active Directory tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IResourceIdentityInternal)Identity).TenantId; }

        /// <summary>
        /// The identity type. Set this to 'SystemAssigned' in order to automatically create and assign an Azure Active Directory
        /// principal for the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.IdentityType? IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IResourceIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IResourceIdentityInternal)Identity).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.IdentityType)""); }

        /// <summary>Status showing whether the server enabled infrastructure encryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.InfrastructureEncryption? InfrastructureEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).InfrastructureEncryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).InfrastructureEncryption = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.InfrastructureEncryption)""); }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.FormatTable(Index = 1)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.ITrackedResourceInternal)__trackedResource).Location = value ; }

        /// <summary>The master server id of a replica server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public string MasterServerId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).MasterServerId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).MasterServerId = value ?? null; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)__trackedResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)__trackedResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)__trackedResource).Type = value; }

        /// <summary>Internal Acessors for ByokEnforcement</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerInternal.ByokEnforcement { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).ByokEnforcement; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).ByokEnforcement = value; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IResourceIdentity Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ResourceIdentity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IResourceIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IResourceIdentityInternal)Identity).PrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IResourceIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IResourceIdentityInternal)Identity).TenantId = value; }

        /// <summary>Internal Acessors for PrivateEndpointConnection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateEndpointConnection[] Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerInternal.PrivateEndpointConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).PrivateEndpointConnection; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).PrivateEndpointConnection = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerProperties Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ServerProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISku Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.Sku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for StorageProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IStorageProfile Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerInternal.StorageProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).StorageProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).StorageProfile = value; }

        /// <summary>Enforce a minimal Tls version for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.MinimalTlsVersionEnum? MinimalTlsVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).MinimalTlsVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).MinimalTlsVersion = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.MinimalTlsVersionEnum)""); }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)__trackedResource).Name; }

        /// <summary>List of private endpoint connections on a server</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateEndpointConnection[] PrivateEndpointConnection { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).PrivateEndpointConnection; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerProperties _property;

        /// <summary>Properties of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ServerProperties()); set => this._property = value; }

        /// <summary>
        /// Whether or not public network access is allowed for this server. Value is optional but if passed in, must be 'Enabled'
        /// or 'Disabled'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PublicNetworkAccessEnum? PublicNetworkAccess { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).PublicNetworkAccess; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).PublicNetworkAccess = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PublicNetworkAccessEnum)""); }

        /// <summary>The maximum number of replicas that a master server can have.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public int? ReplicaCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).ReplicaCapacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).ReplicaCapacity = value ?? default(int); }

        /// <summary>The replication role of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public string ReplicationRole { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).ReplicationRole; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).ReplicationRole = value ?? null; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISku _sku;

        /// <summary>The SKU (pricing tier) of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.Sku()); set => this._sku = value; }

        /// <summary>The scale up/out capacity, representing server's compute units.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public int? SkuCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISkuInternal)Sku).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISkuInternal)Sku).Capacity = value ?? default(int); }

        /// <summary>The family of hardware.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public string SkuFamily { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISkuInternal)Sku).Family; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISkuInternal)Sku).Family = value ?? null; }

        /// <summary>
        /// The name of the sku, typically, tier + family + cores, e.g. B_Gen4_1, GP_Gen5_8.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.FormatTable(Index = 5)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISkuInternal)Sku).Name = value ?? null; }

        /// <summary>The size code, to be interpreted by resource as appropriate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public string SkuSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISkuInternal)Sku).Size; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISkuInternal)Sku).Size = value ?? null; }

        /// <summary>The tier of the particular SKU, e.g. Basic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.FormatTable(Index = 6)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.SkuTier? SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISkuInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISkuInternal)Sku).Tier = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.SkuTier)""); }

        /// <summary>Enable ssl enforcement or not when connect to server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.FormatTable(Index = 7)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.SslEnforcementEnum? SslEnforcement { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).SslEnforcement; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).SslEnforcement = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.SslEnforcementEnum)""); }

        /// <summary>Backup retention days for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public int? StorageProfileBackupRetentionDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).StorageProfileBackupRetentionDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).StorageProfileBackupRetentionDay = value ?? default(int); }

        /// <summary>Enable Geo-redundant or not for server backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.GeoRedundantBackup? StorageProfileGeoRedundantBackup { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).StorageProfileGeoRedundantBackup; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).StorageProfileGeoRedundantBackup = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.GeoRedundantBackup)""); }

        /// <summary>Enable Storage Auto Grow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.StorageAutogrow? StorageProfileStorageAutogrow { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).StorageProfileStorageAutogrow; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).StorageProfileStorageAutogrow = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.StorageAutogrow)""); }

        /// <summary>Max storage allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.FormatTable(Index = 4)]
        public int? StorageProfileStorageMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).StorageProfileStorageMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).StorageProfileStorageMb = value ?? default(int); }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.ITrackedResourceInternal)__trackedResource).Tag = value ?? null /* model class */; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IResourceInternal)__trackedResource).Type; }

        /// <summary>A state of a server that is visible to user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerState? UserVisibleState { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).UserVisibleState; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).UserVisibleState = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerState)""); }

        /// <summary>Server version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.FormatTable(Index = 3)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerVersion? Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPropertiesInternal)Property).Version = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerVersion)""); }

        /// <summary>Creates an new <see cref="Server" /> instance.</summary>
        public Server()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// Represents a server.
    public partial interface IServer :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.ITrackedResource
    {
        /// <summary>
        /// The administrator's login name of a server. Can only be specified when the server is being created (and is required for
        /// creation).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The administrator's login name of a server. Can only be specified when the server is being created (and is required for creation).",
        SerializedName = @"administratorLogin",
        PossibleTypes = new [] { typeof(string) })]
        string AdministratorLogin { get; set; }
        /// <summary>
        /// Status showing whether the server data encryption is enabled with customer-managed keys.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status showing whether the server data encryption is enabled with customer-managed keys.",
        SerializedName = @"byokEnforcement",
        PossibleTypes = new [] { typeof(string) })]
        string ByokEnforcement { get;  }
        /// <summary>Earliest restore point creation time (ISO8601 format)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Earliest restore point creation time (ISO8601 format)",
        SerializedName = @"earliestRestoreDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EarliestRestoreDate { get; set; }
        /// <summary>The fully qualified domain name of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The fully qualified domain name of a server.",
        SerializedName = @"fullyQualifiedDomainName",
        PossibleTypes = new [] { typeof(string) })]
        string FullyQualifiedDomainName { get; set; }
        /// <summary>The Azure Active Directory principal id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Azure Active Directory principal id.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get;  }
        /// <summary>The Azure Active Directory tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Azure Active Directory tenant id.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get;  }
        /// <summary>
        /// The identity type. Set this to 'SystemAssigned' in order to automatically create and assign an Azure Active Directory
        /// principal for the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity type. Set this to 'SystemAssigned' in order to automatically create and assign an Azure Active Directory principal for the resource.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.IdentityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.IdentityType? IdentityType { get; set; }
        /// <summary>Status showing whether the server enabled infrastructure encryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Status showing whether the server enabled infrastructure encryption.",
        SerializedName = @"infrastructureEncryption",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.InfrastructureEncryption) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.InfrastructureEncryption? InfrastructureEncryption { get; set; }
        /// <summary>The master server id of a replica server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The master server id of a replica server.",
        SerializedName = @"masterServerId",
        PossibleTypes = new [] { typeof(string) })]
        string MasterServerId { get; set; }
        /// <summary>Enforce a minimal Tls version for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enforce a minimal Tls version for the server.",
        SerializedName = @"minimalTlsVersion",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.MinimalTlsVersionEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.MinimalTlsVersionEnum? MinimalTlsVersion { get; set; }
        /// <summary>List of private endpoint connections on a server</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of private endpoint connections on a server",
        SerializedName = @"privateEndpointConnections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateEndpointConnection) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateEndpointConnection[] PrivateEndpointConnection { get;  }
        /// <summary>
        /// Whether or not public network access is allowed for this server. Value is optional but if passed in, must be 'Enabled'
        /// or 'Disabled'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether or not public network access is allowed for this server. Value is optional but if passed in, must be 'Enabled' or 'Disabled'",
        SerializedName = @"publicNetworkAccess",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PublicNetworkAccessEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PublicNetworkAccessEnum? PublicNetworkAccess { get; set; }
        /// <summary>The maximum number of replicas that a master server can have.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum number of replicas that a master server can have.",
        SerializedName = @"replicaCapacity",
        PossibleTypes = new [] { typeof(int) })]
        int? ReplicaCapacity { get; set; }
        /// <summary>The replication role of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The replication role of the server.",
        SerializedName = @"replicationRole",
        PossibleTypes = new [] { typeof(string) })]
        string ReplicationRole { get; set; }
        /// <summary>The scale up/out capacity, representing server's compute units.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The scale up/out capacity, representing server's compute units.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? SkuCapacity { get; set; }
        /// <summary>The family of hardware.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The family of hardware.",
        SerializedName = @"family",
        PossibleTypes = new [] { typeof(string) })]
        string SkuFamily { get; set; }
        /// <summary>
        /// The name of the sku, typically, tier + family + cores, e.g. B_Gen4_1, GP_Gen5_8.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the sku, typically, tier + family + cores, e.g. B_Gen4_1, GP_Gen5_8.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }
        /// <summary>The size code, to be interpreted by resource as appropriate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The size code, to be interpreted by resource as appropriate.",
        SerializedName = @"size",
        PossibleTypes = new [] { typeof(string) })]
        string SkuSize { get; set; }
        /// <summary>The tier of the particular SKU, e.g. Basic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The tier of the particular SKU, e.g. Basic.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.SkuTier) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.SkuTier? SkuTier { get; set; }
        /// <summary>Enable ssl enforcement or not when connect to server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable ssl enforcement or not when connect to server.",
        SerializedName = @"sslEnforcement",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.SslEnforcementEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.SslEnforcementEnum? SslEnforcement { get; set; }
        /// <summary>Backup retention days for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Backup retention days for the server.",
        SerializedName = @"backupRetentionDays",
        PossibleTypes = new [] { typeof(int) })]
        int? StorageProfileBackupRetentionDay { get; set; }
        /// <summary>Enable Geo-redundant or not for server backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable Geo-redundant or not for server backup.",
        SerializedName = @"geoRedundantBackup",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.GeoRedundantBackup) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.GeoRedundantBackup? StorageProfileGeoRedundantBackup { get; set; }
        /// <summary>Enable Storage Auto Grow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable Storage Auto Grow.",
        SerializedName = @"storageAutogrow",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.StorageAutogrow) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.StorageAutogrow? StorageProfileStorageAutogrow { get; set; }
        /// <summary>Max storage allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Max storage allowed for a server.",
        SerializedName = @"storageMB",
        PossibleTypes = new [] { typeof(int) })]
        int? StorageProfileStorageMb { get; set; }
        /// <summary>A state of a server that is visible to user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A state of a server that is visible to user.",
        SerializedName = @"userVisibleState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerState) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerState? UserVisibleState { get; set; }
        /// <summary>Server version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Server version.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerVersion) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerVersion? Version { get; set; }

    }
    /// Represents a server.
    internal partial interface IServerInternal :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.ITrackedResourceInternal
    {
        /// <summary>
        /// The administrator's login name of a server. Can only be specified when the server is being created (and is required for
        /// creation).
        /// </summary>
        string AdministratorLogin { get; set; }
        /// <summary>
        /// Status showing whether the server data encryption is enabled with customer-managed keys.
        /// </summary>
        string ByokEnforcement { get; set; }
        /// <summary>Earliest restore point creation time (ISO8601 format)</summary>
        global::System.DateTime? EarliestRestoreDate { get; set; }
        /// <summary>The fully qualified domain name of a server.</summary>
        string FullyQualifiedDomainName { get; set; }
        /// <summary>The Azure Active Directory identity of the server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IResourceIdentity Identity { get; set; }
        /// <summary>The Azure Active Directory principal id.</summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>The Azure Active Directory tenant id.</summary>
        string IdentityTenantId { get; set; }
        /// <summary>
        /// The identity type. Set this to 'SystemAssigned' in order to automatically create and assign an Azure Active Directory
        /// principal for the resource.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.IdentityType? IdentityType { get; set; }
        /// <summary>Status showing whether the server enabled infrastructure encryption.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.InfrastructureEncryption? InfrastructureEncryption { get; set; }
        /// <summary>The master server id of a replica server.</summary>
        string MasterServerId { get; set; }
        /// <summary>Enforce a minimal Tls version for the server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.MinimalTlsVersionEnum? MinimalTlsVersion { get; set; }
        /// <summary>List of private endpoint connections on a server</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerPrivateEndpointConnection[] PrivateEndpointConnection { get; set; }
        /// <summary>Properties of the server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IServerProperties Property { get; set; }
        /// <summary>
        /// Whether or not public network access is allowed for this server. Value is optional but if passed in, must be 'Enabled'
        /// or 'Disabled'
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.PublicNetworkAccessEnum? PublicNetworkAccess { get; set; }
        /// <summary>The maximum number of replicas that a master server can have.</summary>
        int? ReplicaCapacity { get; set; }
        /// <summary>The replication role of the server.</summary>
        string ReplicationRole { get; set; }
        /// <summary>The SKU (pricing tier) of the server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISku Sku { get; set; }
        /// <summary>The scale up/out capacity, representing server's compute units.</summary>
        int? SkuCapacity { get; set; }
        /// <summary>The family of hardware.</summary>
        string SkuFamily { get; set; }
        /// <summary>
        /// The name of the sku, typically, tier + family + cores, e.g. B_Gen4_1, GP_Gen5_8.
        /// </summary>
        string SkuName { get; set; }
        /// <summary>The size code, to be interpreted by resource as appropriate.</summary>
        string SkuSize { get; set; }
        /// <summary>The tier of the particular SKU, e.g. Basic.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.SkuTier? SkuTier { get; set; }
        /// <summary>Enable ssl enforcement or not when connect to server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.SslEnforcementEnum? SslEnforcement { get; set; }
        /// <summary>Storage profile of a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IStorageProfile StorageProfile { get; set; }
        /// <summary>Backup retention days for the server.</summary>
        int? StorageProfileBackupRetentionDay { get; set; }
        /// <summary>Enable Geo-redundant or not for server backup.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.GeoRedundantBackup? StorageProfileGeoRedundantBackup { get; set; }
        /// <summary>Enable Storage Auto Grow.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.StorageAutogrow? StorageProfileStorageAutogrow { get; set; }
        /// <summary>Max storage allowed for a server.</summary>
        int? StorageProfileStorageMb { get; set; }
        /// <summary>A state of a server that is visible to user.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerState? UserVisibleState { get; set; }
        /// <summary>Server version.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerVersion? Version { get; set; }

    }
}