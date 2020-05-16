namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>BackupRequest resource specific properties</summary>
    public partial class BackupRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal
    {

        /// <summary>Backing field for <see cref="BackupName" /> property.</summary>
        private string _backupName;

        /// <summary>Name of the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string BackupName { get => this._backupName; set => this._backupName = value; }

        /// <summary>Backing field for <see cref="BackupSchedule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupSchedule _backupSchedule;

        /// <summary>Schedule for the backup if it is executed periodically.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupSchedule BackupSchedule { get => (this._backupSchedule = this._backupSchedule ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupSchedule()); set => this._backupSchedule = value; }

        /// <summary>
        /// How often the backup should be executed (e.g. for weekly backup, this should be set to 7 and FrequencyUnit should be set
        /// to Day)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int BackupScheduleFrequencyInterval { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)BackupSchedule).FrequencyInterval; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)BackupSchedule).FrequencyInterval = value; }

        /// <summary>
        /// The unit of time for how often the backup should be executed (e.g. for weekly backup, this should be set to Day and FrequencyInterval
        /// should be set to 7)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FrequencyUnit BackupScheduleFrequencyUnit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)BackupSchedule).FrequencyUnit; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)BackupSchedule).FrequencyUnit = value; }

        /// <summary>
        /// True if the retention policy should always keep at least one backup in the storage account, regardless how old it is;
        /// false otherwise.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool BackupScheduleKeepAtLeastOneBackup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)BackupSchedule).KeepAtLeastOneBackup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)BackupSchedule).KeepAtLeastOneBackup = value; }

        /// <summary>Last time when this schedule was triggered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? BackupScheduleLastExecutionTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)BackupSchedule).LastExecutionTime; }

        /// <summary>After how many days backups should be deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int BackupScheduleRetentionPeriodInDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)BackupSchedule).RetentionPeriodInDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)BackupSchedule).RetentionPeriodInDay = value; }

        /// <summary>When the schedule should start working.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? BackupScheduleStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)BackupSchedule).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)BackupSchedule).StartTime = value; }

        /// <summary>Backing field for <see cref="Database" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] _database;

        /// <summary>Databases included in the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] Database { get => this._database; set => this._database = value; }

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool? _enabled;

        /// <summary>
        /// True if the backup schedule is enabled (must be included in that case), false if the backup schedule should be disabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Internal Acessors for BackupSchedule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupSchedule Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal.BackupSchedule { get => (this._backupSchedule = this._backupSchedule ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupSchedule()); set { {_backupSchedule = value;} } }

        /// <summary>Internal Acessors for BackupScheduleLastExecutionTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal.BackupScheduleLastExecutionTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)BackupSchedule).LastExecutionTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal)BackupSchedule).LastExecutionTime = value; }

        /// <summary>Backing field for <see cref="StorageAccountUrl" /> property.</summary>
        private string _storageAccountUrl;

        /// <summary>SAS URL to the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string StorageAccountUrl { get => this._storageAccountUrl; set => this._storageAccountUrl = value; }

        /// <summary>Creates an new <see cref="BackupRequestProperties" /> instance.</summary>
        public BackupRequestProperties()
        {

        }
    }
    /// BackupRequest resource specific properties
    public partial interface IBackupRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Name of the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the backup.",
        SerializedName = @"backupName",
        PossibleTypes = new [] { typeof(string) })]
        string BackupName { get; set; }
        /// <summary>
        /// How often the backup should be executed (e.g. for weekly backup, this should be set to 7 and FrequencyUnit should be set
        /// to Day)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"How often the backup should be executed (e.g. for weekly backup, this should be set to 7 and FrequencyUnit should be set to Day)",
        SerializedName = @"frequencyInterval",
        PossibleTypes = new [] { typeof(int) })]
        int BackupScheduleFrequencyInterval { get; set; }
        /// <summary>
        /// The unit of time for how often the backup should be executed (e.g. for weekly backup, this should be set to Day and FrequencyInterval
        /// should be set to 7)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The unit of time for how often the backup should be executed (e.g. for weekly backup, this should be set to Day and FrequencyInterval should be set to 7)",
        SerializedName = @"frequencyUnit",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FrequencyUnit) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FrequencyUnit BackupScheduleFrequencyUnit { get; set; }
        /// <summary>
        /// True if the retention policy should always keep at least one backup in the storage account, regardless how old it is;
        /// false otherwise.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"True if the retention policy should always keep at least one backup in the storage account, regardless how old it is; false otherwise.",
        SerializedName = @"keepAtLeastOneBackup",
        PossibleTypes = new [] { typeof(bool) })]
        bool BackupScheduleKeepAtLeastOneBackup { get; set; }
        /// <summary>Last time when this schedule was triggered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Last time when this schedule was triggered.",
        SerializedName = @"lastExecutionTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? BackupScheduleLastExecutionTime { get;  }
        /// <summary>After how many days backups should be deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"After how many days backups should be deleted.",
        SerializedName = @"retentionPeriodInDays",
        PossibleTypes = new [] { typeof(int) })]
        int BackupScheduleRetentionPeriodInDay { get; set; }
        /// <summary>When the schedule should start working.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"When the schedule should start working.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? BackupScheduleStartTime { get; set; }
        /// <summary>Databases included in the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Databases included in the backup.",
        SerializedName = @"databases",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] Database { get; set; }
        /// <summary>
        /// True if the backup schedule is enabled (must be included in that case), false if the backup schedule should be disabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"True if the backup schedule is enabled (must be included in that case), false if the backup schedule should be disabled.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Enabled { get; set; }
        /// <summary>SAS URL to the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"SAS URL to the container.",
        SerializedName = @"storageAccountUrl",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountUrl { get; set; }

    }
    /// BackupRequest resource specific properties
    internal partial interface IBackupRequestPropertiesInternal

    {
        /// <summary>Name of the backup.</summary>
        string BackupName { get; set; }
        /// <summary>Schedule for the backup if it is executed periodically.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupSchedule BackupSchedule { get; set; }
        /// <summary>
        /// How often the backup should be executed (e.g. for weekly backup, this should be set to 7 and FrequencyUnit should be set
        /// to Day)
        /// </summary>
        int BackupScheduleFrequencyInterval { get; set; }
        /// <summary>
        /// The unit of time for how often the backup should be executed (e.g. for weekly backup, this should be set to Day and FrequencyInterval
        /// should be set to 7)
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FrequencyUnit BackupScheduleFrequencyUnit { get; set; }
        /// <summary>
        /// True if the retention policy should always keep at least one backup in the storage account, regardless how old it is;
        /// false otherwise.
        /// </summary>
        bool BackupScheduleKeepAtLeastOneBackup { get; set; }
        /// <summary>Last time when this schedule was triggered.</summary>
        global::System.DateTime? BackupScheduleLastExecutionTime { get; set; }
        /// <summary>After how many days backups should be deleted.</summary>
        int BackupScheduleRetentionPeriodInDay { get; set; }
        /// <summary>When the schedule should start working.</summary>
        global::System.DateTime? BackupScheduleStartTime { get; set; }
        /// <summary>Databases included in the backup.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] Database { get; set; }
        /// <summary>
        /// True if the backup schedule is enabled (must be included in that case), false if the backup schedule should be disabled.
        /// </summary>
        bool? Enabled { get; set; }
        /// <summary>SAS URL to the container.</summary>
        string StorageAccountUrl { get; set; }

    }
}