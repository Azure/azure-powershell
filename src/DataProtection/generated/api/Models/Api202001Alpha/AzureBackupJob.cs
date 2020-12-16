namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>AzureBackup Job Class</summary>
    public partial class AzureBackupJob :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupJob,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupJobInternal
    {

        /// <summary>Backing field for <see cref="ActivityId" /> property.</summary>
        private string _activityId;

        /// <summary>Job Activity Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ActivityId { get => this._activityId; set => this._activityId = value; }

        /// <summary>Backing field for <see cref="BackupInstanceFriendlyName" /> property.</summary>
        private string _backupInstanceFriendlyName;

        /// <summary>Name of the Backup Instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string BackupInstanceFriendlyName { get => this._backupInstanceFriendlyName; set => this._backupInstanceFriendlyName = value; }

        /// <summary>Backing field for <see cref="BackupInstanceId" /> property.</summary>
        private string _backupInstanceId;

        /// <summary>ARM ID of the Backup Instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string BackupInstanceId { get => this._backupInstanceId; }

        /// <summary>Backing field for <see cref="DataSourceId" /> property.</summary>
        private string _dataSourceId;

        /// <summary>ARM ID of the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string DataSourceId { get => this._dataSourceId; set => this._dataSourceId = value; }

        /// <summary>Backing field for <see cref="DataSourceLocation" /> property.</summary>
        private string _dataSourceLocation;

        /// <summary>Location of the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string DataSourceLocation { get => this._dataSourceLocation; set => this._dataSourceLocation = value; }

        /// <summary>Backing field for <see cref="DataSourceName" /> property.</summary>
        private string _dataSourceName;

        /// <summary>User Friendly Name of the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string DataSourceName { get => this._dataSourceName; set => this._dataSourceName = value; }

        /// <summary>Backing field for <see cref="DataSourceSetName" /> property.</summary>
        private string _dataSourceSetName;

        /// <summary>Data Source Set Name of the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string DataSourceSetName { get => this._dataSourceSetName; set => this._dataSourceSetName = value; }

        /// <summary>Backing field for <see cref="DataSourceType" /> property.</summary>
        private string _dataSourceType;

        /// <summary>Type of DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string DataSourceType { get => this._dataSourceType; set => this._dataSourceType = value; }

        /// <summary>Backing field for <see cref="Duration" /> property.</summary>
        private global::System.TimeSpan? _duration;

        /// <summary>Total run time of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public global::System.TimeSpan? Duration { get => this._duration; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>EndTime of the job(in UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; }

        /// <summary>Backing field for <see cref="ErrorDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IUserFacingError[] _errorDetail;

        /// <summary>A List, detatiling the errors related to the job</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IUserFacingError[] ErrorDetail { get => this._errorDetail; }

        /// <summary>Backing field for <see cref="ExtendedInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfo _extendedInfo;

        /// <summary>Extended Information about the job</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfo ExtendedInfo { get => (this._extendedInfo = this._extendedInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.JobExtendedInfo()); }

        /// <summary>Job's Additional Details</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoAdditionalDetails ExtendedInfoAdditionalDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).AdditionalDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).AdditionalDetail = value; }

        /// <summary>State of the Backup Instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string ExtendedInfoBackupInstanceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).BackupInstanceState; }

        /// <summary>Number of bytes transfered</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public double? ExtendedInfoDataTransferedInByte { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).DataTransferedInByte; }

        /// <summary>Destination where restore is done</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string ExtendedInfoRecoveryDestination { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).RecoveryDestination; }

        /// <summary>List of Sub Tasks of the job</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobSubTask[] ExtendedInfoSubTask { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).SubTask; }

        /// <summary>Backing field for <see cref="IsUserTriggered" /> property.</summary>
        private bool _isUserTriggered;

        /// <summary>Indicated that whether the job is adhoc(true) or scheduled(false)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public bool IsUserTriggered { get => this._isUserTriggered; set => this._isUserTriggered = value; }

        /// <summary>Internal Acessors for BackupInstanceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupJobInternal.BackupInstanceId { get => this._backupInstanceId; set { {_backupInstanceId = value;} } }

        /// <summary>Internal Acessors for Duration</summary>
        global::System.TimeSpan? Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupJobInternal.Duration { get => this._duration; set { {_duration = value;} } }

        /// <summary>Internal Acessors for EndTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupJobInternal.EndTime { get => this._endTime; set { {_endTime = value;} } }

        /// <summary>Internal Acessors for ErrorDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IUserFacingError[] Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupJobInternal.ErrorDetail { get => this._errorDetail; set { {_errorDetail = value;} } }

        /// <summary>Internal Acessors for ExtendedInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfo Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupJobInternal.ExtendedInfo { get => (this._extendedInfo = this._extendedInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.JobExtendedInfo()); set { {_extendedInfo = value;} } }

        /// <summary>Internal Acessors for ExtendedInfoBackupInstanceState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupJobInternal.ExtendedInfoBackupInstanceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).BackupInstanceState; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).BackupInstanceState = value; }

        /// <summary>Internal Acessors for ExtendedInfoDataTransferedInByte</summary>
        double? Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupJobInternal.ExtendedInfoDataTransferedInByte { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).DataTransferedInByte; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).DataTransferedInByte = value; }

        /// <summary>Internal Acessors for ExtendedInfoRecoveryDestination</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupJobInternal.ExtendedInfoRecoveryDestination { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).RecoveryDestination; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).RecoveryDestination = value; }

        /// <summary>Internal Acessors for ExtendedInfoSourceRecoverPoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreJobRecoveryPointDetails Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupJobInternal.ExtendedInfoSourceRecoverPoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).SourceRecoverPoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).SourceRecoverPoint = value; }

        /// <summary>Internal Acessors for ExtendedInfoSubTask</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobSubTask[] Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupJobInternal.ExtendedInfoSubTask { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).SubTask; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).SubTask = value; }

        /// <summary>Internal Acessors for ExtendedInfoTargetRecoverPoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreJobRecoveryPointDetails Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupJobInternal.ExtendedInfoTargetRecoverPoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).TargetRecoverPoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).TargetRecoverPoint = value; }

        /// <summary>Internal Acessors for PolicyId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupJobInternal.PolicyId { get => this._policyId; set { {_policyId = value;} } }

        /// <summary>Internal Acessors for PolicyName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupJobInternal.PolicyName { get => this._policyName; set { {_policyName = value;} } }

        /// <summary>Internal Acessors for ProgressUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupJobInternal.ProgressUrl { get => this._progressUrl; set { {_progressUrl = value;} } }

        /// <summary>Internal Acessors for RestoreType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IAzureBackupJobInternal.RestoreType { get => this._restoreType; set { {_restoreType = value;} } }

        /// <summary>Backing field for <see cref="Operation" /> property.</summary>
        private string _operation;

        /// <summary>
        /// It indicates the type of Job i.e. Backup:full/log/diff ;Restore:ALR/OLR; Retention:Backup/Archive ; Management:ConfigureProtection/UnConfigure
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Operation { get => this._operation; set => this._operation = value; }

        /// <summary>Backing field for <see cref="OperationCategory" /> property.</summary>
        private string _operationCategory;

        /// <summary>It indicates the type of Job i.e. Backup/Restore/Retention/Management</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string OperationCategory { get => this._operationCategory; set => this._operationCategory = value; }

        /// <summary>Backing field for <see cref="PolicyId" /> property.</summary>
        private string _policyId;

        /// <summary>ARM ID of the policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string PolicyId { get => this._policyId; }

        /// <summary>Backing field for <see cref="PolicyName" /> property.</summary>
        private string _policyName;

        /// <summary>Name of the policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string PolicyName { get => this._policyName; }

        /// <summary>Backing field for <see cref="ProgressEnabled" /> property.</summary>
        private bool _progressEnabled;

        /// <summary>Indicated whether progress is enabled for the job</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public bool ProgressEnabled { get => this._progressEnabled; set => this._progressEnabled = value; }

        /// <summary>Backing field for <see cref="ProgressUrl" /> property.</summary>
        private string _progressUrl;

        /// <summary>Url which contains job's progress</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ProgressUrl { get => this._progressUrl; }

        /// <summary>Backing field for <see cref="RestoreType" /> property.</summary>
        private string _restoreType;

        /// <summary>
        /// It indicates the sub type of operation i.e. in case of Restore it can be ALR/OLR
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string RestoreType { get => this._restoreType; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string SourceRecoverPointRecoveryPointId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).SourceRecoverPointRecoveryPointId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).SourceRecoverPointRecoveryPointId = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public global::System.DateTime? SourceRecoverPointRecoveryPointTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).SourceRecoverPointRecoveryPointTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).SourceRecoverPointRecoveryPointTime = value; }

        /// <summary>Backing field for <see cref="SourceResourceGroup" /> property.</summary>
        private string _sourceResourceGroup;

        /// <summary>Name of the Datasource's Resource Group</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string SourceResourceGroup { get => this._sourceResourceGroup; set => this._sourceResourceGroup = value; }

        /// <summary>Backing field for <see cref="SourceSubscriptionId" /> property.</summary>
        private string _sourceSubscriptionId;

        /// <summary>SubscriptionId corresponding to the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string SourceSubscriptionId { get => this._sourceSubscriptionId; set => this._sourceSubscriptionId = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime _startTime;

        /// <summary>StartTime of the job(in UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public global::System.DateTime StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Status of the job like InProgress/Success/Failed/Cancelled/SuccessWithWarning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Status { get => this._status; set => this._status = value; }

        /// <summary>Backing field for <see cref="SubscriptionId" /> property.</summary>
        private string _subscriptionId;

        /// <summary>Subscription Id of the corresponding backup vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string SubscriptionId { get => this._subscriptionId; set => this._subscriptionId = value; }

        /// <summary>Backing field for <see cref="SupportedAction" /> property.</summary>
        private string[] _supportedAction;

        /// <summary>List of supported actions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string[] SupportedAction { get => this._supportedAction; set => this._supportedAction = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string TargetRecoverPointRecoveryPointId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).TargetRecoverPointRecoveryPointId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).TargetRecoverPointRecoveryPointId = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public global::System.DateTime? TargetRecoverPointRecoveryPointTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).TargetRecoverPointRecoveryPointTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoInternal)ExtendedInfo).TargetRecoverPointRecoveryPointTime = value; }

        /// <summary>Backing field for <see cref="VaultName" /> property.</summary>
        private string _vaultName;

        /// <summary>Name of the vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string VaultName { get => this._vaultName; set => this._vaultName = value; }

        /// <summary>Creates an new <see cref="AzureBackupJob" /> instance.</summary>
        public AzureBackupJob()
        {

        }
    }
    /// AzureBackup Job Class
    public partial interface IAzureBackupJob :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Job Activity Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Job Activity Id",
        SerializedName = @"activityID",
        PossibleTypes = new [] { typeof(string) })]
        string ActivityId { get; set; }
        /// <summary>Name of the Backup Instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Name of the Backup Instance",
        SerializedName = @"backupInstanceFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string BackupInstanceFriendlyName { get; set; }
        /// <summary>ARM ID of the Backup Instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ARM ID of the Backup Instance",
        SerializedName = @"backupInstanceId",
        PossibleTypes = new [] { typeof(string) })]
        string BackupInstanceId { get;  }
        /// <summary>ARM ID of the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"ARM ID of the DataSource",
        SerializedName = @"dataSourceId",
        PossibleTypes = new [] { typeof(string) })]
        string DataSourceId { get; set; }
        /// <summary>Location of the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Location of the DataSource",
        SerializedName = @"dataSourceLocation",
        PossibleTypes = new [] { typeof(string) })]
        string DataSourceLocation { get; set; }
        /// <summary>User Friendly Name of the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"User Friendly Name of the DataSource",
        SerializedName = @"dataSourceName",
        PossibleTypes = new [] { typeof(string) })]
        string DataSourceName { get; set; }
        /// <summary>Data Source Set Name of the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Data Source Set Name of the DataSource",
        SerializedName = @"dataSourceSetName",
        PossibleTypes = new [] { typeof(string) })]
        string DataSourceSetName { get; set; }
        /// <summary>Type of DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Type of DataSource",
        SerializedName = @"dataSourceType",
        PossibleTypes = new [] { typeof(string) })]
        string DataSourceType { get; set; }
        /// <summary>Total run time of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Total run time of the job.",
        SerializedName = @"duration",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? Duration { get;  }
        /// <summary>EndTime of the job(in UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"EndTime of the job(in UTC)",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get;  }
        /// <summary>A List, detatiling the errors related to the job</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A List, detatiling the errors related to the job",
        SerializedName = @"errorDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IUserFacingError) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IUserFacingError[] ErrorDetail { get;  }
        /// <summary>Job's Additional Details</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job's Additional Details",
        SerializedName = @"additionalDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoAdditionalDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoAdditionalDetails ExtendedInfoAdditionalDetail { get; set; }
        /// <summary>State of the Backup Instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"State of the Backup Instance",
        SerializedName = @"backupInstanceState",
        PossibleTypes = new [] { typeof(string) })]
        string ExtendedInfoBackupInstanceState { get;  }
        /// <summary>Number of bytes transfered</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Number of bytes transfered",
        SerializedName = @"dataTransferedInBytes",
        PossibleTypes = new [] { typeof(double) })]
        double? ExtendedInfoDataTransferedInByte { get;  }
        /// <summary>Destination where restore is done</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Destination where restore is done",
        SerializedName = @"recoveryDestination",
        PossibleTypes = new [] { typeof(string) })]
        string ExtendedInfoRecoveryDestination { get;  }
        /// <summary>List of Sub Tasks of the job</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of Sub Tasks of the job",
        SerializedName = @"subTasks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobSubTask) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobSubTask[] ExtendedInfoSubTask { get;  }
        /// <summary>Indicated that whether the job is adhoc(true) or scheduled(false)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Indicated that whether the job is adhoc(true) or scheduled(false)",
        SerializedName = @"isUserTriggered",
        PossibleTypes = new [] { typeof(bool) })]
        bool IsUserTriggered { get; set; }
        /// <summary>
        /// It indicates the type of Job i.e. Backup:full/log/diff ;Restore:ALR/OLR; Retention:Backup/Archive ; Management:ConfigureProtection/UnConfigure
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"It indicates the type of Job i.e. Backup:full/log/diff ;Restore:ALR/OLR; Retention:Backup/Archive ; Management:ConfigureProtection/UnConfigure",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string Operation { get; set; }
        /// <summary>It indicates the type of Job i.e. Backup/Restore/Retention/Management</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"It indicates the type of Job i.e. Backup/Restore/Retention/Management",
        SerializedName = @"operationCategory",
        PossibleTypes = new [] { typeof(string) })]
        string OperationCategory { get; set; }
        /// <summary>ARM ID of the policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ARM ID of the policy",
        SerializedName = @"policyId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyId { get;  }
        /// <summary>Name of the policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the policy",
        SerializedName = @"policyName",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyName { get;  }
        /// <summary>Indicated whether progress is enabled for the job</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Indicated whether progress is enabled for the job",
        SerializedName = @"progressEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool ProgressEnabled { get; set; }
        /// <summary>Url which contains job's progress</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Url which contains job's progress",
        SerializedName = @"progressUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ProgressUrl { get;  }
        /// <summary>
        /// It indicates the sub type of operation i.e. in case of Restore it can be ALR/OLR
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"It indicates the sub type of operation i.e. in case of Restore it can be ALR/OLR",
        SerializedName = @"restoreType",
        PossibleTypes = new [] { typeof(string) })]
        string RestoreType { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"recoveryPointID",
        PossibleTypes = new [] { typeof(string) })]
        string SourceRecoverPointRecoveryPointId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"recoveryPointTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SourceRecoverPointRecoveryPointTime { get; set; }
        /// <summary>Name of the Datasource's Resource Group</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Name of the Datasource's Resource Group",
        SerializedName = @"sourceResourceGroup",
        PossibleTypes = new [] { typeof(string) })]
        string SourceResourceGroup { get; set; }
        /// <summary>SubscriptionId corresponding to the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"SubscriptionId corresponding to the DataSource",
        SerializedName = @"sourceSubscriptionID",
        PossibleTypes = new [] { typeof(string) })]
        string SourceSubscriptionId { get; set; }
        /// <summary>StartTime of the job(in UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"StartTime of the job(in UTC)",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime StartTime { get; set; }
        /// <summary>Status of the job like InProgress/Success/Failed/Cancelled/SuccessWithWarning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Status of the job like InProgress/Success/Failed/Cancelled/SuccessWithWarning",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get; set; }
        /// <summary>Subscription Id of the corresponding backup vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Subscription Id of the corresponding backup vault",
        SerializedName = @"subscriptionId",
        PossibleTypes = new [] { typeof(string) })]
        string SubscriptionId { get; set; }
        /// <summary>List of supported actions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"List of supported actions",
        SerializedName = @"supportedActions",
        PossibleTypes = new [] { typeof(string) })]
        string[] SupportedAction { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"recoveryPointID",
        PossibleTypes = new [] { typeof(string) })]
        string TargetRecoverPointRecoveryPointId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"recoveryPointTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TargetRecoverPointRecoveryPointTime { get; set; }
        /// <summary>Name of the vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Name of the vault",
        SerializedName = @"vaultName",
        PossibleTypes = new [] { typeof(string) })]
        string VaultName { get; set; }

    }
    /// AzureBackup Job Class
    internal partial interface IAzureBackupJobInternal

    {
        /// <summary>Job Activity Id</summary>
        string ActivityId { get; set; }
        /// <summary>Name of the Backup Instance</summary>
        string BackupInstanceFriendlyName { get; set; }
        /// <summary>ARM ID of the Backup Instance</summary>
        string BackupInstanceId { get; set; }
        /// <summary>ARM ID of the DataSource</summary>
        string DataSourceId { get; set; }
        /// <summary>Location of the DataSource</summary>
        string DataSourceLocation { get; set; }
        /// <summary>User Friendly Name of the DataSource</summary>
        string DataSourceName { get; set; }
        /// <summary>Data Source Set Name of the DataSource</summary>
        string DataSourceSetName { get; set; }
        /// <summary>Type of DataSource</summary>
        string DataSourceType { get; set; }
        /// <summary>Total run time of the job.</summary>
        global::System.TimeSpan? Duration { get; set; }
        /// <summary>EndTime of the job(in UTC)</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>A List, detatiling the errors related to the job</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IUserFacingError[] ErrorDetail { get; set; }
        /// <summary>Extended Information about the job</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfo ExtendedInfo { get; set; }
        /// <summary>Job's Additional Details</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobExtendedInfoAdditionalDetails ExtendedInfoAdditionalDetail { get; set; }
        /// <summary>State of the Backup Instance</summary>
        string ExtendedInfoBackupInstanceState { get; set; }
        /// <summary>Number of bytes transfered</summary>
        double? ExtendedInfoDataTransferedInByte { get; set; }
        /// <summary>Destination where restore is done</summary>
        string ExtendedInfoRecoveryDestination { get; set; }
        /// <summary>Details of the Source Recovery Point</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreJobRecoveryPointDetails ExtendedInfoSourceRecoverPoint { get; set; }
        /// <summary>List of Sub Tasks of the job</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IJobSubTask[] ExtendedInfoSubTask { get; set; }
        /// <summary>Details of the Target Recovery Point</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IRestoreJobRecoveryPointDetails ExtendedInfoTargetRecoverPoint { get; set; }
        /// <summary>Indicated that whether the job is adhoc(true) or scheduled(false)</summary>
        bool IsUserTriggered { get; set; }
        /// <summary>
        /// It indicates the type of Job i.e. Backup:full/log/diff ;Restore:ALR/OLR; Retention:Backup/Archive ; Management:ConfigureProtection/UnConfigure
        /// </summary>
        string Operation { get; set; }
        /// <summary>It indicates the type of Job i.e. Backup/Restore/Retention/Management</summary>
        string OperationCategory { get; set; }
        /// <summary>ARM ID of the policy</summary>
        string PolicyId { get; set; }
        /// <summary>Name of the policy</summary>
        string PolicyName { get; set; }
        /// <summary>Indicated whether progress is enabled for the job</summary>
        bool ProgressEnabled { get; set; }
        /// <summary>Url which contains job's progress</summary>
        string ProgressUrl { get; set; }
        /// <summary>
        /// It indicates the sub type of operation i.e. in case of Restore it can be ALR/OLR
        /// </summary>
        string RestoreType { get; set; }

        string SourceRecoverPointRecoveryPointId { get; set; }

        global::System.DateTime? SourceRecoverPointRecoveryPointTime { get; set; }
        /// <summary>Name of the Datasource's Resource Group</summary>
        string SourceResourceGroup { get; set; }
        /// <summary>SubscriptionId corresponding to the DataSource</summary>
        string SourceSubscriptionId { get; set; }
        /// <summary>StartTime of the job(in UTC)</summary>
        global::System.DateTime StartTime { get; set; }
        /// <summary>Status of the job like InProgress/Success/Failed/Cancelled/SuccessWithWarning</summary>
        string Status { get; set; }
        /// <summary>Subscription Id of the corresponding backup vault</summary>
        string SubscriptionId { get; set; }
        /// <summary>List of supported actions</summary>
        string[] SupportedAction { get; set; }

        string TargetRecoverPointRecoveryPointId { get; set; }

        global::System.DateTime? TargetRecoverPointRecoveryPointTime { get; set; }
        /// <summary>Name of the vault</summary>
        string VaultName { get; set; }

    }
}