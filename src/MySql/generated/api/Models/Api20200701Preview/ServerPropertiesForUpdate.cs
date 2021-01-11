namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>The properties that can be updated for a server.</summary>
    public partial class ServerPropertiesForUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal
    {

        /// <summary>Backing field for <see cref="AdministratorLoginPassword" /> property.</summary>
        private string _administratorLoginPassword;

        /// <summary>The password of the administrator login.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string AdministratorLoginPassword { get => this._administratorLoginPassword; set => this._administratorLoginPassword = value; }

        /// <summary>Backing field for <see cref="DelegatedSubnetArgument" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IDelegatedSubnetArguments _delegatedSubnetArgument;

        /// <summary>Delegated subnet arguments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IDelegatedSubnetArguments DelegatedSubnetArgument { get => (this._delegatedSubnetArgument = this._delegatedSubnetArgument ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.DelegatedSubnetArguments()); set => this._delegatedSubnetArgument = value; }

        /// <summary>delegated subnet arm resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public string DelegatedSubnetArgumentSubnetArmResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IDelegatedSubnetArgumentsInternal)DelegatedSubnetArgument).SubnetArmResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IDelegatedSubnetArgumentsInternal)DelegatedSubnetArgument).SubnetArmResourceId = value ?? null; }

        /// <summary>Backing field for <see cref="HaEnabled" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.HaEnabledEnum? _haEnabled;

        /// <summary>Enable HA or not for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.HaEnabledEnum? HaEnabled { get => this._haEnabled; set => this._haEnabled = value; }

        /// <summary>Backing field for <see cref="MaintenanceWindow" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IMaintenanceWindow _maintenanceWindow;

        /// <summary>Maintenance window of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IMaintenanceWindow MaintenanceWindow { get => (this._maintenanceWindow = this._maintenanceWindow ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.MaintenanceWindow()); set => this._maintenanceWindow = value; }

        /// <summary>indicates whether custom window is enabled or disabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public string MaintenanceWindowCustomWindow { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IMaintenanceWindowInternal)MaintenanceWindow).CustomWindow; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IMaintenanceWindowInternal)MaintenanceWindow).CustomWindow = value ?? null; }

        /// <summary>day of week for maintenance window</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public int? MaintenanceWindowDayOfWeek { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IMaintenanceWindowInternal)MaintenanceWindow).DayOfWeek; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IMaintenanceWindowInternal)MaintenanceWindow).DayOfWeek = value ?? default(int); }

        /// <summary>start hour for maintenance window</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public int? MaintenanceWindowStartHour { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IMaintenanceWindowInternal)MaintenanceWindow).StartHour; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IMaintenanceWindowInternal)MaintenanceWindow).StartHour = value ?? default(int); }

        /// <summary>start minute for maintenance window</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public int? MaintenanceWindowStartMinute { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IMaintenanceWindowInternal)MaintenanceWindow).StartMinute; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IMaintenanceWindowInternal)MaintenanceWindow).StartMinute = value ?? default(int); }

        /// <summary>Internal Acessors for DelegatedSubnetArgument</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IDelegatedSubnetArguments Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal.DelegatedSubnetArgument { get => (this._delegatedSubnetArgument = this._delegatedSubnetArgument ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.DelegatedSubnetArguments()); set { {_delegatedSubnetArgument = value;} } }

        /// <summary>Internal Acessors for MaintenanceWindow</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IMaintenanceWindow Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal.MaintenanceWindow { get => (this._maintenanceWindow = this._maintenanceWindow ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.MaintenanceWindow()); set { {_maintenanceWindow = value;} } }

        /// <summary>Internal Acessors for StorageProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageProfileAutoGenerated Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal.StorageProfile { get => (this._storageProfile = this._storageProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.StorageProfileAutoGenerated()); set { {_storageProfile = value;} } }

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
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageProfileAutoGenerated _storageProfile;

        /// <summary>Storage profile of a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageProfileAutoGenerated StorageProfile { get => (this._storageProfile = this._storageProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.StorageProfileAutoGenerated()); set => this._storageProfile = value; }

        /// <summary>Backup retention days for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public int? StorageProfileBackupRetentionDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageProfileAutoGeneratedInternal)StorageProfile).BackupRetentionDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageProfileAutoGeneratedInternal)StorageProfile).BackupRetentionDay = value ?? default(int); }

        /// <summary>Enable Storage Auto Grow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow? StorageProfileStorageAutogrow { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageProfileAutoGeneratedInternal)StorageProfile).StorageAutogrow; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageProfileAutoGeneratedInternal)StorageProfile).StorageAutogrow = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow)""); }

        /// <summary>Storage IOPS for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public int? StorageProfileStorageIop { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageProfileAutoGeneratedInternal)StorageProfile).StorageIop; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageProfileAutoGeneratedInternal)StorageProfile).StorageIop = value ?? default(int); }

        /// <summary>Max storage allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public int? StorageProfileStorageMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageProfileAutoGeneratedInternal)StorageProfile).StorageMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageProfileAutoGeneratedInternal)StorageProfile).StorageMb = value ?? default(int); }

        /// <summary>Creates an new <see cref="ServerPropertiesForUpdate" /> instance.</summary>
        public ServerPropertiesForUpdate()
        {

        }
    }
    /// The properties that can be updated for a server.
    public partial interface IServerPropertiesForUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>The password of the administrator login.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The password of the administrator login.",
        SerializedName = @"administratorLoginPassword",
        PossibleTypes = new [] { typeof(string) })]
        string AdministratorLoginPassword { get; set; }
        /// <summary>delegated subnet arm resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"delegated subnet arm resource id.",
        SerializedName = @"subnetArmResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string DelegatedSubnetArgumentSubnetArmResourceId { get; set; }
        /// <summary>Enable HA or not for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable HA or not for a server.",
        SerializedName = @"haEnabled",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.HaEnabledEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.HaEnabledEnum? HaEnabled { get; set; }
        /// <summary>indicates whether custom window is enabled or disabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"indicates whether custom window is enabled or disabled",
        SerializedName = @"customWindow",
        PossibleTypes = new [] { typeof(string) })]
        string MaintenanceWindowCustomWindow { get; set; }
        /// <summary>day of week for maintenance window</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"day of week for maintenance window",
        SerializedName = @"dayOfWeek",
        PossibleTypes = new [] { typeof(int) })]
        int? MaintenanceWindowDayOfWeek { get; set; }
        /// <summary>start hour for maintenance window</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"start hour for maintenance window",
        SerializedName = @"startHour",
        PossibleTypes = new [] { typeof(int) })]
        int? MaintenanceWindowStartHour { get; set; }
        /// <summary>start minute for maintenance window</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"start minute for maintenance window",
        SerializedName = @"startMinute",
        PossibleTypes = new [] { typeof(int) })]
        int? MaintenanceWindowStartMinute { get; set; }
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
        /// <summary>Enable Storage Auto Grow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable Storage Auto Grow.",
        SerializedName = @"storageAutogrow",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow? StorageProfileStorageAutogrow { get; set; }
        /// <summary>Storage IOPS for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Storage IOPS for a server.",
        SerializedName = @"storageIops",
        PossibleTypes = new [] { typeof(int) })]
        int? StorageProfileStorageIop { get; set; }
        /// <summary>Max storage allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Max storage allowed for a server.",
        SerializedName = @"storageMB",
        PossibleTypes = new [] { typeof(int) })]
        int? StorageProfileStorageMb { get; set; }

    }
    /// The properties that can be updated for a server.
    internal partial interface IServerPropertiesForUpdateInternal

    {
        /// <summary>The password of the administrator login.</summary>
        string AdministratorLoginPassword { get; set; }
        /// <summary>Delegated subnet arguments.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IDelegatedSubnetArguments DelegatedSubnetArgument { get; set; }
        /// <summary>delegated subnet arm resource id.</summary>
        string DelegatedSubnetArgumentSubnetArmResourceId { get; set; }
        /// <summary>Enable HA or not for a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.HaEnabledEnum? HaEnabled { get; set; }
        /// <summary>Maintenance window of a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IMaintenanceWindow MaintenanceWindow { get; set; }
        /// <summary>indicates whether custom window is enabled or disabled</summary>
        string MaintenanceWindowCustomWindow { get; set; }
        /// <summary>day of week for maintenance window</summary>
        int? MaintenanceWindowDayOfWeek { get; set; }
        /// <summary>start hour for maintenance window</summary>
        int? MaintenanceWindowStartHour { get; set; }
        /// <summary>start minute for maintenance window</summary>
        int? MaintenanceWindowStartMinute { get; set; }
        /// <summary>The replication role of the server.</summary>
        string ReplicationRole { get; set; }
        /// <summary>Enable ssl enforcement or not when connect to server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum? SslEnforcement { get; set; }
        /// <summary>Storage profile of a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageProfileAutoGenerated StorageProfile { get; set; }
        /// <summary>Backup retention days for the server.</summary>
        int? StorageProfileBackupRetentionDay { get; set; }
        /// <summary>Enable Storage Auto Grow.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow? StorageProfileStorageAutogrow { get; set; }
        /// <summary>Storage IOPS for a server.</summary>
        int? StorageProfileStorageIop { get; set; }
        /// <summary>Max storage allowed for a server.</summary>
        int? StorageProfileStorageMb { get; set; }

    }
}