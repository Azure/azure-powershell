namespace Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Extensions;

    /// <summary>The properties of a server.</summary>
    public partial class ServerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerProperties,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AdministratorLogin" /> property.</summary>
        private string _administratorLogin;

        /// <summary>
        /// The administrator's login name of a server. Can only be specified when the server is being created (and is required for
        /// creation).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string AdministratorLogin { get => this._administratorLogin; set => this._administratorLogin = value; }

        /// <summary>Backing field for <see cref="EarliestRestoreDate" /> property.</summary>
        private global::System.DateTime? _earliestRestoreDate;

        /// <summary>Earliest restore point creation time (ISO8601 format)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public global::System.DateTime? EarliestRestoreDate { get => this._earliestRestoreDate; set => this._earliestRestoreDate = value; }

        /// <summary>Backing field for <see cref="FullyQualifiedDomainName" /> property.</summary>
        private string _fullyQualifiedDomainName;

        /// <summary>The fully qualified domain name of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string FullyQualifiedDomainName { get => this._fullyQualifiedDomainName; set => this._fullyQualifiedDomainName = value; }

        /// <summary>Backing field for <see cref="MasterServerId" /> property.</summary>
        private string _masterServerId;

        /// <summary>The master server id of a replica server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string MasterServerId { get => this._masterServerId; set => this._masterServerId = value; }

        /// <summary>Internal Acessors for StorageProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfile Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerPropertiesInternal.StorageProfile { get => (this._storageProfile = this._storageProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.StorageProfile()); set { {_storageProfile = value;} } }

        /// <summary>Backing field for <see cref="ReplicaCapacity" /> property.</summary>
        private int? _replicaCapacity;

        /// <summary>The maximum number of replicas that a master server can have.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public int? ReplicaCapacity { get => this._replicaCapacity; set => this._replicaCapacity = value; }

        /// <summary>Backing field for <see cref="ReplicationRole" /> property.</summary>
        private string _replicationRole;

        /// <summary>The replication role of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string ReplicationRole { get => this._replicationRole; set => this._replicationRole = value; }

        /// <summary>Backing field for <see cref="SslEnforcement" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum? _sslEnforcement;

        /// <summary>Enable ssl enforcement or not when connect to server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum? SslEnforcement { get => this._sslEnforcement; set => this._sslEnforcement = value; }

        /// <summary>Backing field for <see cref="StorageProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfile _storageProfile;

        /// <summary>Storage profile of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfile StorageProfile { get => (this._storageProfile = this._storageProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.StorageProfile()); set => this._storageProfile = value; }

        /// <summary>Backup retention days for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inlined)]
        public int? StorageProfileBackupRetentionDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfileInternal)StorageProfile).BackupRetentionDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfileInternal)StorageProfile).BackupRetentionDay = value; }

        /// <summary>Enable Geo-redundant or not for server backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup? StorageProfileGeoRedundantBackup { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfileInternal)StorageProfile).GeoRedundantBackup; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfileInternal)StorageProfile).GeoRedundantBackup = value; }

        /// <summary>Enable Storage Auto Grow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow? StorageProfileStorageAutogrow { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfileInternal)StorageProfile).StorageAutogrow; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfileInternal)StorageProfile).StorageAutogrow = value; }

        /// <summary>Max storage allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Inlined)]
        public int? StorageProfileStorageMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfileInternal)StorageProfile).StorageMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfileInternal)StorageProfile).StorageMb = value; }

        /// <summary>Backing field for <see cref="UserVisibleState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerState? _userVisibleState;

        /// <summary>A state of a server that is visible to user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerState? UserVisibleState { get => this._userVisibleState; set => this._userVisibleState = value; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion? _version;

        /// <summary>Server version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion? Version { get => this._version; set => this._version = value; }

        /// <summary>Creates an new <see cref="ServerProperties" /> instance.</summary>
        public ServerProperties()
        {

        }
    }
    /// The properties of a server.
    public partial interface IServerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The administrator's login name of a server. Can only be specified when the server is being created (and is required for
        /// creation).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The administrator's login name of a server. Can only be specified when the server is being created (and is required for creation).",
        SerializedName = @"administratorLogin",
        PossibleTypes = new [] { typeof(string) })]
        string AdministratorLogin { get; set; }
        /// <summary>Earliest restore point creation time (ISO8601 format)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Earliest restore point creation time (ISO8601 format)",
        SerializedName = @"earliestRestoreDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EarliestRestoreDate { get; set; }
        /// <summary>The fully qualified domain name of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The fully qualified domain name of a server.",
        SerializedName = @"fullyQualifiedDomainName",
        PossibleTypes = new [] { typeof(string) })]
        string FullyQualifiedDomainName { get; set; }
        /// <summary>The master server id of a replica server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The master server id of a replica server.",
        SerializedName = @"masterServerId",
        PossibleTypes = new [] { typeof(string) })]
        string MasterServerId { get; set; }
        /// <summary>The maximum number of replicas that a master server can have.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum number of replicas that a master server can have.",
        SerializedName = @"replicaCapacity",
        PossibleTypes = new [] { typeof(int) })]
        int? ReplicaCapacity { get; set; }
        /// <summary>The replication role of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The replication role of the server.",
        SerializedName = @"replicationRole",
        PossibleTypes = new [] { typeof(string) })]
        string ReplicationRole { get; set; }
        /// <summary>Enable ssl enforcement or not when connect to server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable ssl enforcement or not when connect to server.",
        SerializedName = @"sslEnforcement",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum? SslEnforcement { get; set; }
        /// <summary>Backup retention days for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Backup retention days for the server.",
        SerializedName = @"backupRetentionDays",
        PossibleTypes = new [] { typeof(int) })]
        int? StorageProfileBackupRetentionDay { get; set; }
        /// <summary>Enable Geo-redundant or not for server backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable Geo-redundant or not for server backup.",
        SerializedName = @"geoRedundantBackup",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup) })]
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup? StorageProfileGeoRedundantBackup { get; set; }
        /// <summary>Enable Storage Auto Grow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable Storage Auto Grow.",
        SerializedName = @"storageAutogrow",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow) })]
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow? StorageProfileStorageAutogrow { get; set; }
        /// <summary>Max storage allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Max storage allowed for a server.",
        SerializedName = @"storageMB",
        PossibleTypes = new [] { typeof(int) })]
        int? StorageProfileStorageMb { get; set; }
        /// <summary>A state of a server that is visible to user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A state of a server that is visible to user.",
        SerializedName = @"userVisibleState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerState) })]
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerState? UserVisibleState { get; set; }
        /// <summary>Server version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Server version.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion) })]
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion? Version { get; set; }

    }
    /// The properties of a server.
    internal partial interface IServerPropertiesInternal

    {
        /// <summary>
        /// The administrator's login name of a server. Can only be specified when the server is being created (and is required for
        /// creation).
        /// </summary>
        string AdministratorLogin { get; set; }
        /// <summary>Earliest restore point creation time (ISO8601 format)</summary>
        global::System.DateTime? EarliestRestoreDate { get; set; }
        /// <summary>The fully qualified domain name of a server.</summary>
        string FullyQualifiedDomainName { get; set; }
        /// <summary>The master server id of a replica server.</summary>
        string MasterServerId { get; set; }
        /// <summary>The maximum number of replicas that a master server can have.</summary>
        int? ReplicaCapacity { get; set; }
        /// <summary>The replication role of the server.</summary>
        string ReplicationRole { get; set; }
        /// <summary>Enable ssl enforcement or not when connect to server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum? SslEnforcement { get; set; }
        /// <summary>Storage profile of a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfile StorageProfile { get; set; }
        /// <summary>Backup retention days for the server.</summary>
        int? StorageProfileBackupRetentionDay { get; set; }
        /// <summary>Enable Geo-redundant or not for server backup.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup? StorageProfileGeoRedundantBackup { get; set; }
        /// <summary>Enable Storage Auto Grow.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow? StorageProfileStorageAutogrow { get; set; }
        /// <summary>Max storage allowed for a server.</summary>
        int? StorageProfileStorageMb { get; set; }
        /// <summary>A state of a server that is visible to user.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerState? UserVisibleState { get; set; }
        /// <summary>Server version.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion? Version { get; set; }

    }
}