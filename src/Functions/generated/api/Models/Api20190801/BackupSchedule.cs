namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Description of a backup schedule. Describes how often should be the backup performed and what should be the retention
    /// policy.
    /// </summary>
    public partial class BackupSchedule :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupSchedule,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal
    {

        /// <summary>Backing field for <see cref="FrequencyInterval" /> property.</summary>
        private int _frequencyInterval;

        /// <summary>
        /// How often the backup should be executed (e.g. for weekly backup, this should be set to 7 and FrequencyUnit should be set
        /// to Day)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int FrequencyInterval { get => this._frequencyInterval; set => this._frequencyInterval = value; }

        /// <summary>Backing field for <see cref="FrequencyUnit" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FrequencyUnit _frequencyUnit;

        /// <summary>
        /// The unit of time for how often the backup should be executed (e.g. for weekly backup, this should be set to Day and FrequencyInterval
        /// should be set to 7)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FrequencyUnit FrequencyUnit { get => this._frequencyUnit; set => this._frequencyUnit = value; }

        /// <summary>Backing field for <see cref="KeepAtLeastOneBackup" /> property.</summary>
        private bool _keepAtLeastOneBackup;

        /// <summary>
        /// True if the retention policy should always keep at least one backup in the storage account, regardless how old it is;
        /// false otherwise.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool KeepAtLeastOneBackup { get => this._keepAtLeastOneBackup; set => this._keepAtLeastOneBackup = value; }

        /// <summary>Backing field for <see cref="LastExecutionTime" /> property.</summary>
        private global::System.DateTime? _lastExecutionTime;

        /// <summary>Last time when this schedule was triggered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? LastExecutionTime { get => this._lastExecutionTime; }

        /// <summary>Internal Acessors for LastExecutionTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupScheduleInternal.LastExecutionTime { get => this._lastExecutionTime; set { {_lastExecutionTime = value;} } }

        /// <summary>Backing field for <see cref="RetentionPeriodInDay" /> property.</summary>
        private int _retentionPeriodInDay;

        /// <summary>After how many days backups should be deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int RetentionPeriodInDay { get => this._retentionPeriodInDay; set => this._retentionPeriodInDay = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>When the schedule should start working.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Creates an new <see cref="BackupSchedule" /> instance.</summary>
        public BackupSchedule()
        {

        }
    }
    /// Description of a backup schedule. Describes how often should be the backup performed and what should be the retention
    /// policy.
    public partial interface IBackupSchedule :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
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
        int FrequencyInterval { get; set; }
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
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FrequencyUnit FrequencyUnit { get; set; }
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
        bool KeepAtLeastOneBackup { get; set; }
        /// <summary>Last time when this schedule was triggered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Last time when this schedule was triggered.",
        SerializedName = @"lastExecutionTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastExecutionTime { get;  }
        /// <summary>After how many days backups should be deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"After how many days backups should be deleted.",
        SerializedName = @"retentionPeriodInDays",
        PossibleTypes = new [] { typeof(int) })]
        int RetentionPeriodInDay { get; set; }
        /// <summary>When the schedule should start working.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"When the schedule should start working.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }

    }
    /// Description of a backup schedule. Describes how often should be the backup performed and what should be the retention
    /// policy.
    internal partial interface IBackupScheduleInternal

    {
        /// <summary>
        /// How often the backup should be executed (e.g. for weekly backup, this should be set to 7 and FrequencyUnit should be set
        /// to Day)
        /// </summary>
        int FrequencyInterval { get; set; }
        /// <summary>
        /// The unit of time for how often the backup should be executed (e.g. for weekly backup, this should be set to Day and FrequencyInterval
        /// should be set to 7)
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FrequencyUnit FrequencyUnit { get; set; }
        /// <summary>
        /// True if the retention policy should always keep at least one backup in the storage account, regardless how old it is;
        /// false otherwise.
        /// </summary>
        bool KeepAtLeastOneBackup { get; set; }
        /// <summary>Last time when this schedule was triggered.</summary>
        global::System.DateTime? LastExecutionTime { get; set; }
        /// <summary>After how many days backups should be deleted.</summary>
        int RetentionPeriodInDay { get; set; }
        /// <summary>When the schedule should start working.</summary>
        global::System.DateTime? StartTime { get; set; }

    }
}