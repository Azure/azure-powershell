namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>Parameters allowed to update for a server.</summary>
    public partial class ServerForUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerForUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerForUpdateInternal
    {

        /// <summary>The password of the administrator login.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public string AdministratorLoginPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).AdministratorLoginPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).AdministratorLoginPassword = value ?? null; }

        /// <summary>delegated subnet arm resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public string DelegatedSubnetArgumentSubnetArmResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).DelegatedSubnetArgumentSubnetArmResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).DelegatedSubnetArgumentSubnetArmResourceId = value ?? null; }

        /// <summary>Enable HA or not for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.HaEnabledEnum? HaEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).HaEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).HaEnabled = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.HaEnabledEnum)""); }

        /// <summary>indicates whether custom window is enabled or disabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public string MaintenanceWindowCustomWindow { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).MaintenanceWindowCustomWindow; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).MaintenanceWindowCustomWindow = value ?? null; }

        /// <summary>day of week for maintenance window</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public int? MaintenanceWindowDayOfWeek { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).MaintenanceWindowDayOfWeek; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).MaintenanceWindowDayOfWeek = value ?? default(int); }

        /// <summary>start hour for maintenance window</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public int? MaintenanceWindowStartHour { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).MaintenanceWindowStartHour; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).MaintenanceWindowStartHour = value ?? default(int); }

        /// <summary>start minute for maintenance window</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public int? MaintenanceWindowStartMinute { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).MaintenanceWindowStartMinute; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).MaintenanceWindowStartMinute = value ?? default(int); }

        /// <summary>Internal Acessors for DelegatedSubnetArgument</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IDelegatedSubnetArguments Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerForUpdateInternal.DelegatedSubnetArgument { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).DelegatedSubnetArgument; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).DelegatedSubnetArgument = value; }

        /// <summary>Internal Acessors for MaintenanceWindow</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IMaintenanceWindow Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerForUpdateInternal.MaintenanceWindow { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).MaintenanceWindow; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).MaintenanceWindow = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdate Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerForUpdateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.ServerPropertiesForUpdate()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.ISkuAutoGenerated Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerForUpdateInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.SkuAutoGenerated()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for StorageProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageProfileAutoGenerated Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerForUpdateInternal.StorageProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).StorageProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).StorageProfile = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdate _property;

        /// <summary>The properties that can be updated for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdate Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.ServerPropertiesForUpdate()); set => this._property = value; }

        /// <summary>The replication role of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public string ReplicationRole { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).ReplicationRole; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).ReplicationRole = value ?? null; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.ISkuAutoGenerated _sku;

        /// <summary>The SKU (pricing tier) of the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.ISkuAutoGenerated Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.SkuAutoGenerated()); set => this._sku = value; }

        /// <summary>The name of the sku, e.g. Standard_D32s_v3.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.ISkuAutoGeneratedInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.ISkuAutoGeneratedInternal)Sku).Name = value ?? null; }

        /// <summary>The tier of the particular SKU, e.g. GeneralPurpose.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SkuTier? SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.ISkuAutoGeneratedInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.ISkuAutoGeneratedInternal)Sku).Tier = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SkuTier)""); }

        /// <summary>Enable ssl enforcement or not when connect to server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum? SslEnforcement { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).SslEnforcement; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).SslEnforcement = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum)""); }

        /// <summary>Backup retention days for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public int? StorageProfileBackupRetentionDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).StorageProfileBackupRetentionDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).StorageProfileBackupRetentionDay = value ?? default(int); }

        /// <summary>Enable Storage Auto Grow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow? StorageProfileStorageAutogrow { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).StorageProfileStorageAutogrow; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).StorageProfileStorageAutogrow = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow)""); }

        /// <summary>Storage IOPS for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public int? StorageProfileStorageIop { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).StorageProfileStorageIop; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).StorageProfileStorageIop = value ?? default(int); }

        /// <summary>Max storage allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public int? StorageProfileStorageMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).StorageProfileStorageMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdateInternal)Property).StorageProfileStorageMb = value ?? default(int); }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerForUpdateTags _tag;

        /// <summary>Application-specific metadata in the form of key-value pairs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerForUpdateTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.ServerForUpdateTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="ServerForUpdate" /> instance.</summary>
        public ServerForUpdate()
        {

        }
    }
    /// Parameters allowed to update for a server.
    public partial interface IServerForUpdate :
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
        /// <summary>The name of the sku, e.g. Standard_D32s_v3.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the sku, e.g. Standard_D32s_v3.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }
        /// <summary>The tier of the particular SKU, e.g. GeneralPurpose.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The tier of the particular SKU, e.g. GeneralPurpose.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SkuTier) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SkuTier? SkuTier { get; set; }
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
        /// <summary>Application-specific metadata in the form of key-value pairs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application-specific metadata in the form of key-value pairs.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerForUpdateTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerForUpdateTags Tag { get; set; }

    }
    /// Parameters allowed to update for a server.
    internal partial interface IServerForUpdateInternal

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
        /// <summary>The properties that can be updated for a server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerPropertiesForUpdate Property { get; set; }
        /// <summary>The replication role of the server.</summary>
        string ReplicationRole { get; set; }
        /// <summary>The SKU (pricing tier) of the server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.ISkuAutoGenerated Sku { get; set; }
        /// <summary>The name of the sku, e.g. Standard_D32s_v3.</summary>
        string SkuName { get; set; }
        /// <summary>The tier of the particular SKU, e.g. GeneralPurpose.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SkuTier? SkuTier { get; set; }
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
        /// <summary>Application-specific metadata in the form of key-value pairs.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerForUpdateTags Tag { get; set; }

    }
}