namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>The properties of a server.</summary>
    public partial class ServerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerProperties,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AdministratorLogin" /> property.</summary>
        private string _administratorLogin;

        /// <summary>
        /// The administrator's login name of a server. Can only be specified when the server is being created (and is required for
        /// creation).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string AdministratorLogin { get => this._administratorLogin; set => this._administratorLogin = value; }

        /// <summary>Backing field for <see cref="ByokEnforcement" /> property.</summary>
        private string _byokEnforcement;

        /// <summary>
        /// Status showing whether the server data encryption is enabled with customer-managed keys.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string ByokEnforcement { get => this._byokEnforcement; }

        /// <summary>Backing field for <see cref="EarliestRestoreDate" /> property.</summary>
        private global::System.DateTime? _earliestRestoreDate;

        /// <summary>Earliest restore point creation time (ISO8601 format)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public global::System.DateTime? EarliestRestoreDate { get => this._earliestRestoreDate; set => this._earliestRestoreDate = value; }

        /// <summary>Backing field for <see cref="FullyQualifiedDomainName" /> property.</summary>
        private string _fullyQualifiedDomainName;

        /// <summary>The fully qualified domain name of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string FullyQualifiedDomainName { get => this._fullyQualifiedDomainName; set => this._fullyQualifiedDomainName = value; }

        /// <summary>Backing field for <see cref="InfrastructureEncryption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.InfrastructureEncryption? _infrastructureEncryption;

        /// <summary>Status showing whether the server enabled infrastructure encryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.InfrastructureEncryption? InfrastructureEncryption { get => this._infrastructureEncryption; set => this._infrastructureEncryption = value; }

        /// <summary>Backing field for <see cref="MasterServerId" /> property.</summary>
        private string _masterServerId;

        /// <summary>The master server id of a replica server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string MasterServerId { get => this._masterServerId; set => this._masterServerId = value; }

        /// <summary>Internal Acessors for ByokEnforcement</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesInternal.ByokEnforcement { get => this._byokEnforcement; set { {_byokEnforcement = value;} } }

        /// <summary>Internal Acessors for PrivateEndpointConnection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnection[] Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesInternal.PrivateEndpointConnection { get => this._privateEndpointConnection; set { {_privateEndpointConnection = value;} } }

        /// <summary>Internal Acessors for StorageProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfile Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPropertiesInternal.StorageProfile { get => (this._storageProfile = this._storageProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.StorageProfile()); set { {_storageProfile = value;} } }

        /// <summary>Backing field for <see cref="MinimalTlsVersion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.MinimalTlsVersionEnum? _minimalTlsVersion;

        /// <summary>Enforce a minimal Tls version for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.MinimalTlsVersionEnum? MinimalTlsVersion { get => this._minimalTlsVersion; set => this._minimalTlsVersion = value; }

        /// <summary>Backing field for <see cref="PrivateEndpointConnection" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnection[] _privateEndpointConnection;

        /// <summary>List of private endpoint connections on a server</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnection[] PrivateEndpointConnection { get => this._privateEndpointConnection; }

        /// <summary>Backing field for <see cref="PublicNetworkAccess" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PublicNetworkAccessEnum? _publicNetworkAccess;

        /// <summary>
        /// Whether or not public network access is allowed for this server. Value is optional but if passed in, must be 'Enabled'
        /// or 'Disabled'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PublicNetworkAccessEnum? PublicNetworkAccess { get => this._publicNetworkAccess; set => this._publicNetworkAccess = value; }

        /// <summary>Backing field for <see cref="ReplicaCapacity" /> property.</summary>
        private int? _replicaCapacity;

        /// <summary>The maximum number of replicas that a master server can have.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public int? ReplicaCapacity { get => this._replicaCapacity; set => this._replicaCapacity = value; }

        /// <summary>Backing field for <see cref="ReplicationRole" /> property.</summary>
        private string _replicationRole;

        /// <summary>The replication role of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string ReplicationRole { get => this._replicationRole; set => this._replicationRole = value; }

        /// <summary>Backing field for <see cref="SslEnforcement" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum? _sslEnforcement;

        /// <summary>Enable ssl enforcement or not when connect to server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum? SslEnforcement { get => this._sslEnforcement; set => this._sslEnforcement = value; }

        /// <summary>Backing field for <see cref="StorageProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfile _storageProfile;

        /// <summary>Storage profile of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfile StorageProfile { get => (this._storageProfile = this._storageProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.StorageProfile()); set => this._storageProfile = value; }

        /// <summary>Backup retention days for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public int? StorageProfileBackupRetentionDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfileInternal)StorageProfile).BackupRetentionDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfileInternal)StorageProfile).BackupRetentionDay = value; }

        /// <summary>Enable Geo-redundant or not for server backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup? StorageProfileGeoRedundantBackup { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfileInternal)StorageProfile).GeoRedundantBackup; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfileInternal)StorageProfile).GeoRedundantBackup = value; }

        /// <summary>Enable Storage Auto Grow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow? StorageProfileStorageAutogrow { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfileInternal)StorageProfile).StorageAutogrow; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfileInternal)StorageProfile).StorageAutogrow = value; }

        /// <summary>Max storage allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public int? StorageProfileStorageMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfileInternal)StorageProfile).StorageMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfileInternal)StorageProfile).StorageMb = value; }

        /// <summary>Backing field for <see cref="UserVisibleState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerState? _userVisibleState;

        /// <summary>A state of a server that is visible to user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerState? UserVisibleState { get => this._userVisibleState; set => this._userVisibleState = value; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion? _version;

        /// <summary>Server version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion? Version { get => this._version; set => this._version = value; }

        /// <summary>Creates an new <see cref="ServerProperties" /> instance.</summary>
        public ServerProperties()
        {

        }
    }
    /// The properties of a server.
    public partial interface IServerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The administrator's login name of a server. Can only be specified when the server is being created (and is required for
        /// creation).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The administrator's login name of a server. Can only be specified when the server is being created (and is required for creation).",
        SerializedName = @"administratorLogin",
        PossibleTypes = new [] { typeof(string) })]
        string AdministratorLogin { get; set; }
        /// <summary>
        /// Status showing whether the server data encryption is enabled with customer-managed keys.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status showing whether the server data encryption is enabled with customer-managed keys.",
        SerializedName = @"byokEnforcement",
        PossibleTypes = new [] { typeof(string) })]
        string ByokEnforcement { get;  }
        /// <summary>Earliest restore point creation time (ISO8601 format)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Earliest restore point creation time (ISO8601 format)",
        SerializedName = @"earliestRestoreDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EarliestRestoreDate { get; set; }
        /// <summary>The fully qualified domain name of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The fully qualified domain name of a server.",
        SerializedName = @"fullyQualifiedDomainName",
        PossibleTypes = new [] { typeof(string) })]
        string FullyQualifiedDomainName { get; set; }
        /// <summary>Status showing whether the server enabled infrastructure encryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Status showing whether the server enabled infrastructure encryption.",
        SerializedName = @"infrastructureEncryption",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.InfrastructureEncryption) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.InfrastructureEncryption? InfrastructureEncryption { get; set; }
        /// <summary>The master server id of a replica server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The master server id of a replica server.",
        SerializedName = @"masterServerId",
        PossibleTypes = new [] { typeof(string) })]
        string MasterServerId { get; set; }
        /// <summary>Enforce a minimal Tls version for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enforce a minimal Tls version for the server.",
        SerializedName = @"minimalTlsVersion",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.MinimalTlsVersionEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.MinimalTlsVersionEnum? MinimalTlsVersion { get; set; }
        /// <summary>List of private endpoint connections on a server</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of private endpoint connections on a server",
        SerializedName = @"privateEndpointConnections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnection) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnection[] PrivateEndpointConnection { get;  }
        /// <summary>
        /// Whether or not public network access is allowed for this server. Value is optional but if passed in, must be 'Enabled'
        /// or 'Disabled'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether or not public network access is allowed for this server. Value is optional but if passed in, must be 'Enabled' or 'Disabled'",
        SerializedName = @"publicNetworkAccess",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PublicNetworkAccessEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PublicNetworkAccessEnum? PublicNetworkAccess { get; set; }
        /// <summary>The maximum number of replicas that a master server can have.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum number of replicas that a master server can have.",
        SerializedName = @"replicaCapacity",
        PossibleTypes = new [] { typeof(int) })]
        int? ReplicaCapacity { get; set; }
        /// <summary>The replication role of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The replication role of the server.",
        SerializedName = @"replicationRole",
        PossibleTypes = new [] { typeof(string) })]
        string ReplicationRole { get; set; }
        /// <summary>Enable ssl enforcement or not when connect to server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable ssl enforcement or not when connect to server.",
        SerializedName = @"sslEnforcement",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum? SslEnforcement { get; set; }
        /// <summary>Backup retention days for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Backup retention days for the server.",
        SerializedName = @"backupRetentionDays",
        PossibleTypes = new [] { typeof(int) })]
        int? StorageProfileBackupRetentionDay { get; set; }
        /// <summary>Enable Geo-redundant or not for server backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable Geo-redundant or not for server backup.",
        SerializedName = @"geoRedundantBackup",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup? StorageProfileGeoRedundantBackup { get; set; }
        /// <summary>Enable Storage Auto Grow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable Storage Auto Grow.",
        SerializedName = @"storageAutogrow",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow? StorageProfileStorageAutogrow { get; set; }
        /// <summary>Max storage allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Max storage allowed for a server.",
        SerializedName = @"storageMB",
        PossibleTypes = new [] { typeof(int) })]
        int? StorageProfileStorageMb { get; set; }
        /// <summary>A state of a server that is visible to user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A state of a server that is visible to user.",
        SerializedName = @"userVisibleState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerState) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerState? UserVisibleState { get; set; }
        /// <summary>Server version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Server version.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion? Version { get; set; }

    }
    /// The properties of a server.
    internal partial interface IServerPropertiesInternal

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
        /// <summary>Status showing whether the server enabled infrastructure encryption.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.InfrastructureEncryption? InfrastructureEncryption { get; set; }
        /// <summary>The master server id of a replica server.</summary>
        string MasterServerId { get; set; }
        /// <summary>Enforce a minimal Tls version for the server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.MinimalTlsVersionEnum? MinimalTlsVersion { get; set; }
        /// <summary>List of private endpoint connections on a server</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnection[] PrivateEndpointConnection { get; set; }
        /// <summary>
        /// Whether or not public network access is allowed for this server. Value is optional but if passed in, must be 'Enabled'
        /// or 'Disabled'
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PublicNetworkAccessEnum? PublicNetworkAccess { get; set; }
        /// <summary>The maximum number of replicas that a master server can have.</summary>
        int? ReplicaCapacity { get; set; }
        /// <summary>The replication role of the server.</summary>
        string ReplicationRole { get; set; }
        /// <summary>Enable ssl enforcement or not when connect to server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum? SslEnforcement { get; set; }
        /// <summary>Storage profile of a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfile StorageProfile { get; set; }
        /// <summary>Backup retention days for the server.</summary>
        int? StorageProfileBackupRetentionDay { get; set; }
        /// <summary>Enable Geo-redundant or not for server backup.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup? StorageProfileGeoRedundantBackup { get; set; }
        /// <summary>Enable Storage Auto Grow.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow? StorageProfileStorageAutogrow { get; set; }
        /// <summary>Max storage allowed for a server.</summary>
        int? StorageProfileStorageMb { get; set; }
        /// <summary>A state of a server that is visible to user.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerState? UserVisibleState { get; set; }
        /// <summary>Server version.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion? Version { get; set; }

    }
}