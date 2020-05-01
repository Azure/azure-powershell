namespace Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Extensions;

    /// <summary>Storage Profile properties of a server</summary>
    public partial class StorageProfile :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfile,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IStorageProfileInternal
    {

        /// <summary>Backing field for <see cref="BackupRetentionDay" /> property.</summary>
        private int? _backupRetentionDay;

        /// <summary>Backup retention days for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public int? BackupRetentionDay { get => this._backupRetentionDay; set => this._backupRetentionDay = value; }

        /// <summary>Backing field for <see cref="GeoRedundantBackup" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup? _geoRedundantBackup;

        /// <summary>Enable Geo-redundant or not for server backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup? GeoRedundantBackup { get => this._geoRedundantBackup; set => this._geoRedundantBackup = value; }

        /// <summary>Backing field for <see cref="StorageAutogrow" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow? _storageAutogrow;

        /// <summary>Enable Storage Auto Grow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow? StorageAutogrow { get => this._storageAutogrow; set => this._storageAutogrow = value; }

        /// <summary>Backing field for <see cref="StorageMb" /> property.</summary>
        private int? _storageMb;

        /// <summary>Max storage allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public int? StorageMb { get => this._storageMb; set => this._storageMb = value; }

        /// <summary>Creates an new <see cref="StorageProfile" /> instance.</summary>
        public StorageProfile()
        {

        }
    }
    /// Storage Profile properties of a server
    public partial interface IStorageProfile :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IJsonSerializable
    {
        /// <summary>Backup retention days for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Backup retention days for the server.",
        SerializedName = @"backupRetentionDays",
        PossibleTypes = new [] { typeof(int) })]
        int? BackupRetentionDay { get; set; }
        /// <summary>Enable Geo-redundant or not for server backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable Geo-redundant or not for server backup.",
        SerializedName = @"geoRedundantBackup",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup) })]
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup? GeoRedundantBackup { get; set; }
        /// <summary>Enable Storage Auto Grow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable Storage Auto Grow.",
        SerializedName = @"storageAutogrow",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow) })]
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow? StorageAutogrow { get; set; }
        /// <summary>Max storage allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Max storage allowed for a server.",
        SerializedName = @"storageMB",
        PossibleTypes = new [] { typeof(int) })]
        int? StorageMb { get; set; }

    }
    /// Storage Profile properties of a server
    internal partial interface IStorageProfileInternal

    {
        /// <summary>Backup retention days for the server.</summary>
        int? BackupRetentionDay { get; set; }
        /// <summary>Enable Geo-redundant or not for server backup.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup? GeoRedundantBackup { get; set; }
        /// <summary>Enable Storage Auto Grow.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow? StorageAutogrow { get; set; }
        /// <summary>Max storage allowed for a server.</summary>
        int? StorageMb { get; set; }

    }
}