namespace Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Extensions;

    /// <summary>The properties that can be updated for a server.</summary>
    public partial class ServerUpdateParametersProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerUpdateParametersProperties,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerUpdateParametersPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AdministratorLoginPassword" /> property.</summary>
        private string _administratorLoginPassword;

        /// <summary>The password of the administrator login.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string AdministratorLoginPassword { get => this._administratorLoginPassword; set => this._administratorLoginPassword = value; }

        /// <summary>Internal Acessors for StorageProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfile Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerUpdateParametersPropertiesInternal.StorageProfile { get => (this._storageProfile = this._storageProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.StorageProfile()); set { {_storageProfile = value;} } }

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

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion? _version;

        /// <summary>The version of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion? Version { get => this._version; set => this._version = value; }

        /// <summary>Creates an new <see cref="ServerUpdateParametersProperties" /> instance.</summary>
        public ServerUpdateParametersProperties()
        {

        }
    }
    /// The properties that can be updated for a server.
    public partial interface IServerUpdateParametersProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IJsonSerializable
    {
        /// <summary>The password of the administrator login.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The password of the administrator login.",
        SerializedName = @"administratorLoginPassword",
        PossibleTypes = new [] { typeof(string) })]
        string AdministratorLoginPassword { get; set; }
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
        /// <summary>The version of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The version of a server.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion) })]
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion? Version { get; set; }

    }
    /// The properties that can be updated for a server.
    internal partial interface IServerUpdateParametersPropertiesInternal

    {
        /// <summary>The password of the administrator login.</summary>
        string AdministratorLoginPassword { get; set; }
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
        /// <summary>The version of a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion? Version { get; set; }

    }
}