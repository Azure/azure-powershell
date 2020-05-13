namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Description of a backup which will be performed.</summary>
    public partial class BackupRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Name of the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string BackupName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).BackupName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).BackupName = value; }

        /// <summary>
        /// How often the backup should be executed (e.g. for weekly backup, this should be set to 7 and FrequencyUnit should be set
        /// to Day)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int BackupScheduleFrequencyInterval { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).BackupScheduleFrequencyInterval; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).BackupScheduleFrequencyInterval = value; }

        /// <summary>
        /// The unit of time for how often the backup should be executed (e.g. for weekly backup, this should be set to Day and FrequencyInterval
        /// should be set to 7)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FrequencyUnit BackupScheduleFrequencyUnit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).BackupScheduleFrequencyUnit; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).BackupScheduleFrequencyUnit = value; }

        /// <summary>
        /// True if the retention policy should always keep at least one backup in the storage account, regardless how old it is;
        /// false otherwise.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool BackupScheduleKeepAtLeastOneBackup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).BackupScheduleKeepAtLeastOneBackup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).BackupScheduleKeepAtLeastOneBackup = value; }

        /// <summary>Last time when this schedule was triggered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? BackupScheduleLastExecutionTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).BackupScheduleLastExecutionTime; }

        /// <summary>After how many days backups should be deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int BackupScheduleRetentionPeriodInDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).BackupScheduleRetentionPeriodInDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).BackupScheduleRetentionPeriodInDay = value; }

        /// <summary>When the schedule should start working.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? BackupScheduleStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).BackupScheduleStartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).BackupScheduleStartTime = value; }

        /// <summary>Databases included in the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting[] Database { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).Database; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).Database = value; }

        /// <summary>
        /// True if the backup schedule is enabled (must be included in that case), false if the backup schedule should be disabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? Enabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).Enabled = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for BackupSchedule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupSchedule Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestInternal.BackupSchedule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).BackupSchedule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).BackupSchedule = value; }

        /// <summary>Internal Acessors for BackupScheduleLastExecutionTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestInternal.BackupScheduleLastExecutionTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).BackupScheduleLastExecutionTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).BackupScheduleLastExecutionTime = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupRequestProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestProperties _property;

        /// <summary>BackupRequest resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.BackupRequestProperties()); set => this._property = value; }

        /// <summary>SAS URL to the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string StorageAccountUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).StorageAccountUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestPropertiesInternal)Property).StorageAccountUrl = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="BackupRequest" /> instance.</summary>
        public BackupRequest()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// Description of a backup which will be performed.
    public partial interface IBackupRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
    /// Description of a backup which will be performed.
    internal partial interface IBackupRequestInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
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
        /// <summary>BackupRequest resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IBackupRequestProperties Property { get; set; }
        /// <summary>SAS URL to the container.</summary>
        string StorageAccountUrl { get; set; }

    }
}