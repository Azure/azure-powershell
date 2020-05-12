namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>BackupItem resource specific properties</summary>
    public partial class BackupItemProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal
    {

        /// <summary>Backing field for <see cref="BackupId" /> property.</summary>
        private int? _backupId;

        /// <summary>Id of the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? BackupId { get => this._backupId; }

        /// <summary>Backing field for <see cref="BlobName" /> property.</summary>
        private string _blobName;

        /// <summary>Name of the blob which contains data for this backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string BlobName { get => this._blobName; }

        /// <summary>Backing field for <see cref="CorrelationId" /> property.</summary>
        private string _correlationId;

        /// <summary>
        /// Unique correlation identifier. Please use this along with the timestamp while communicating with Azure support.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string CorrelationId { get => this._correlationId; }

        /// <summary>Backing field for <see cref="Created" /> property.</summary>
        private global::System.DateTime? _created;

        /// <summary>Timestamp of the backup creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? Created { get => this._created; }

        /// <summary>Backing field for <see cref="Database" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] _database;

        /// <summary>List of databases included in the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] Database { get => this._database; }

        /// <summary>Backing field for <see cref="FinishedTimeStamp" /> property.</summary>
        private global::System.DateTime? _finishedTimeStamp;

        /// <summary>Timestamp when this backup finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? FinishedTimeStamp { get => this._finishedTimeStamp; }

        /// <summary>Backing field for <see cref="LastRestoreTimeStamp" /> property.</summary>
        private global::System.DateTime? _lastRestoreTimeStamp;

        /// <summary>Timestamp of a last restore operation which used this backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? LastRestoreTimeStamp { get => this._lastRestoreTimeStamp; }

        /// <summary>Backing field for <see cref="Log" /> property.</summary>
        private string _log;

        /// <summary>Details regarding this backup. Might contain an error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Log { get => this._log; }

        /// <summary>Internal Acessors for BackupId</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal.BackupId { get => this._backupId; set { {_backupId = value;} } }

        /// <summary>Internal Acessors for BlobName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal.BlobName { get => this._blobName; set { {_blobName = value;} } }

        /// <summary>Internal Acessors for CorrelationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal.CorrelationId { get => this._correlationId; set { {_correlationId = value;} } }

        /// <summary>Internal Acessors for Created</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal.Created { get => this._created; set { {_created = value;} } }

        /// <summary>Internal Acessors for Database</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal.Database { get => this._database; set { {_database = value;} } }

        /// <summary>Internal Acessors for FinishedTimeStamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal.FinishedTimeStamp { get => this._finishedTimeStamp; set { {_finishedTimeStamp = value;} } }

        /// <summary>Internal Acessors for LastRestoreTimeStamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal.LastRestoreTimeStamp { get => this._lastRestoreTimeStamp; set { {_lastRestoreTimeStamp = value;} } }

        /// <summary>Internal Acessors for Log</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal.Log { get => this._log; set { {_log = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Scheduled</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal.Scheduled { get => this._scheduled; set { {_scheduled = value;} } }

        /// <summary>Internal Acessors for SizeInByte</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal.SizeInByte { get => this._sizeInByte; set { {_sizeInByte = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupItemStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Internal Acessors for StorageAccountUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal.StorageAccountUrl { get => this._storageAccountUrl; set { {_storageAccountUrl = value;} } }

        /// <summary>Internal Acessors for WebsiteSizeInByte</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupItemPropertiesInternal.WebsiteSizeInByte { get => this._websiteSizeInByte; set { {_websiteSizeInByte = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of this backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Scheduled" /> property.</summary>
        private bool? _scheduled;

        /// <summary>True if this backup has been created due to a schedule being triggered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Scheduled { get => this._scheduled; }

        /// <summary>Backing field for <see cref="SizeInByte" /> property.</summary>
        private long? _sizeInByte;

        /// <summary>Size of the backup in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? SizeInByte { get => this._sizeInByte; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupItemStatus? _status;

        /// <summary>Backup status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupItemStatus? Status { get => this._status; }

        /// <summary>Backing field for <see cref="StorageAccountUrl" /> property.</summary>
        private string _storageAccountUrl;

        /// <summary>SAS URL for the storage account container which contains this backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string StorageAccountUrl { get => this._storageAccountUrl; }

        /// <summary>Backing field for <see cref="WebsiteSizeInByte" /> property.</summary>
        private long? _websiteSizeInByte;

        /// <summary>Size of the original web app which has been backed up.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? WebsiteSizeInByte { get => this._websiteSizeInByte; }

        /// <summary>Creates an new <see cref="BackupItemProperties" /> instance.</summary>
        public BackupItemProperties()
        {

        }
    }
    /// BackupItem resource specific properties
    public partial interface IBackupItemProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Id of the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Id of the backup.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(int) })]
        int? BackupId { get;  }
        /// <summary>Name of the blob which contains data for this backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the blob which contains data for this backup.",
        SerializedName = @"blobName",
        PossibleTypes = new [] { typeof(string) })]
        string BlobName { get;  }
        /// <summary>
        /// Unique correlation identifier. Please use this along with the timestamp while communicating with Azure support.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Unique correlation identifier. Please use this along with the timestamp while communicating with Azure support.",
        SerializedName = @"correlationId",
        PossibleTypes = new [] { typeof(string) })]
        string CorrelationId { get;  }
        /// <summary>Timestamp of the backup creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp of the backup creation.",
        SerializedName = @"created",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? Created { get;  }
        /// <summary>List of databases included in the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of databases included in the backup.",
        SerializedName = @"databases",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] Database { get;  }
        /// <summary>Timestamp when this backup finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp when this backup finished.",
        SerializedName = @"finishedTimeStamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? FinishedTimeStamp { get;  }
        /// <summary>Timestamp of a last restore operation which used this backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp of a last restore operation which used this backup.",
        SerializedName = @"lastRestoreTimeStamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastRestoreTimeStamp { get;  }
        /// <summary>Details regarding this backup. Might contain an error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Details regarding this backup. Might contain an error message.",
        SerializedName = @"log",
        PossibleTypes = new [] { typeof(string) })]
        string Log { get;  }
        /// <summary>Name of this backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of this backup.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>True if this backup has been created due to a schedule being triggered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"True if this backup has been created due to a schedule being triggered.",
        SerializedName = @"scheduled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Scheduled { get;  }
        /// <summary>Size of the backup in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Size of the backup in bytes.",
        SerializedName = @"sizeInBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? SizeInByte { get;  }
        /// <summary>Backup status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Backup status.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupItemStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupItemStatus? Status { get;  }
        /// <summary>SAS URL for the storage account container which contains this backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"SAS URL for the storage account container which contains this backup.",
        SerializedName = @"storageAccountUrl",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountUrl { get;  }
        /// <summary>Size of the original web app which has been backed up.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Size of the original web app which has been backed up.",
        SerializedName = @"websiteSizeInBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? WebsiteSizeInByte { get;  }

    }
    /// BackupItem resource specific properties
    internal partial interface IBackupItemPropertiesInternal

    {
        /// <summary>Id of the backup.</summary>
        int? BackupId { get; set; }
        /// <summary>Name of the blob which contains data for this backup.</summary>
        string BlobName { get; set; }
        /// <summary>
        /// Unique correlation identifier. Please use this along with the timestamp while communicating with Azure support.
        /// </summary>
        string CorrelationId { get; set; }
        /// <summary>Timestamp of the backup creation.</summary>
        global::System.DateTime? Created { get; set; }
        /// <summary>List of databases included in the backup.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] Database { get; set; }
        /// <summary>Timestamp when this backup finished.</summary>
        global::System.DateTime? FinishedTimeStamp { get; set; }
        /// <summary>Timestamp of a last restore operation which used this backup.</summary>
        global::System.DateTime? LastRestoreTimeStamp { get; set; }
        /// <summary>Details regarding this backup. Might contain an error message.</summary>
        string Log { get; set; }
        /// <summary>Name of this backup.</summary>
        string Name { get; set; }
        /// <summary>True if this backup has been created due to a schedule being triggered.</summary>
        bool? Scheduled { get; set; }
        /// <summary>Size of the backup in bytes.</summary>
        long? SizeInByte { get; set; }
        /// <summary>Backup status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BackupItemStatus? Status { get; set; }
        /// <summary>SAS URL for the storage account container which contains this backup.</summary>
        string StorageAccountUrl { get; set; }
        /// <summary>Size of the original web app which has been backed up.</summary>
        long? WebsiteSizeInByte { get; set; }

    }
}