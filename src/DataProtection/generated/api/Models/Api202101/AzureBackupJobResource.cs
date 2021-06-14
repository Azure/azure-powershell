namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>AzureBackup Job Resource Class</summary>
    public partial class AzureBackupJobResource :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobResource,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResource __dppResource = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DppResource();

        /// <summary>Job Activity Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string ActivityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ActivityId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ActivityId = value ?? null; }

        /// <summary>Name of the Backup Instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string BackupInstanceFriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).BackupInstanceFriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).BackupInstanceFriendlyName = value ?? null; }

        /// <summary>ARM ID of the Backup Instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string BackupInstanceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).BackupInstanceId; }

        /// <summary>ARM ID of the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string DataSourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).DataSourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).DataSourceId = value ?? null; }

        /// <summary>Location of the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string DataSourceLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).DataSourceLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).DataSourceLocation = value ?? null; }

        /// <summary>User Friendly Name of the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string DataSourceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).DataSourceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).DataSourceName = value ?? null; }

        /// <summary>Data Source Set Name of the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string DataSourceSetName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).DataSourceSetName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).DataSourceSetName = value ?? null; }

        /// <summary>Type of DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string DataSourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).DataSourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).DataSourceType = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string DestinationDataStoreName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).DestinationDataStoreName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).DestinationDataStoreName = value ?? null; }

        /// <summary>Total run time of the job. ISO 8601 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string Duration { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).Duration; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).Duration = value ?? null; }

        /// <summary>EndTime of the job(in UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public global::System.DateTime? EndTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).EndTime; }

        /// <summary>A List, detailing the errors related to the job</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError[] ErrorDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ErrorDetail; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string Etag { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).Etag = value ?? null; }

        /// <summary>Job's Additional Details</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IJobExtendedInfoAdditionalDetails ExtendedInfoAdditionalDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoAdditionalDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoAdditionalDetail = value ?? null /* model class */; }

        /// <summary>State of the Backup Instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string ExtendedInfoBackupInstanceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoBackupInstanceState; }

        /// <summary>Number of bytes transferred</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public double? ExtendedInfoDataTransferredInByte { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoDataTransferredInByte; }

        /// <summary>Destination where restore is done</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string ExtendedInfoRecoveryDestination { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoRecoveryDestination; }

        /// <summary>List of Sub Tasks of the job</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IJobSubTask[] ExtendedInfoSubTask { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoSubTask; }

        /// <summary>Resource Id represents the complete path to the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Id; }

        /// <summary>Indicated that whether the job is adhoc(true) or scheduled(false)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public bool? IsUserTriggered { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).IsUserTriggered; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).IsUserTriggered = value ?? default(bool); }

        /// <summary>Internal Acessors for BackupInstanceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobResourceInternal.BackupInstanceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).BackupInstanceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).BackupInstanceId = value; }

        /// <summary>Internal Acessors for EndTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobResourceInternal.EndTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).EndTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).EndTime = value; }

        /// <summary>Internal Acessors for ErrorDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError[] Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobResourceInternal.ErrorDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ErrorDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ErrorDetail = value; }

        /// <summary>Internal Acessors for ExtendedInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IJobExtendedInfo Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobResourceInternal.ExtendedInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfo = value; }

        /// <summary>Internal Acessors for ExtendedInfoBackupInstanceState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobResourceInternal.ExtendedInfoBackupInstanceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoBackupInstanceState; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoBackupInstanceState = value; }

        /// <summary>Internal Acessors for ExtendedInfoDataTransferredInByte</summary>
        double? Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobResourceInternal.ExtendedInfoDataTransferredInByte { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoDataTransferredInByte; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoDataTransferredInByte = value; }

        /// <summary>Internal Acessors for ExtendedInfoRecoveryDestination</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobResourceInternal.ExtendedInfoRecoveryDestination { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoRecoveryDestination; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoRecoveryDestination = value; }

        /// <summary>Internal Acessors for ExtendedInfoSourceRecoverPoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreJobRecoveryPointDetails Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobResourceInternal.ExtendedInfoSourceRecoverPoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoSourceRecoverPoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoSourceRecoverPoint = value; }

        /// <summary>Internal Acessors for ExtendedInfoSubTask</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IJobSubTask[] Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobResourceInternal.ExtendedInfoSubTask { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoSubTask; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoSubTask = value; }

        /// <summary>Internal Acessors for ExtendedInfoTargetRecoverPoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreJobRecoveryPointDetails Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobResourceInternal.ExtendedInfoTargetRecoverPoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoTargetRecoverPoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ExtendedInfoTargetRecoverPoint = value; }

        /// <summary>Internal Acessors for PolicyId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobResourceInternal.PolicyId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).PolicyId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).PolicyId = value; }

        /// <summary>Internal Acessors for PolicyName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobResourceInternal.PolicyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).PolicyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).PolicyName = value; }

        /// <summary>Internal Acessors for ProgressUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobResourceInternal.ProgressUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ProgressUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ProgressUrl = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJob Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupJob()); set { {_property = value;} } }

        /// <summary>Internal Acessors for RestoreType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobResourceInternal.RestoreType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).RestoreType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).RestoreType = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Name = value; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ISystemData Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).SystemData = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Type = value; }

        /// <summary>Resource name associated with the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Name; }

        /// <summary>
        /// It indicates the type of Job i.e. Backup:full/log/diff ;Restore:ALR/OLR; Tiering:Backup/Archive ; Management:ConfigureProtection/UnConfigure
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string Operation { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).Operation = value ?? null; }

        /// <summary>It indicates the type of Job i.e. Backup/Restore/Tiering/Management</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string OperationCategory { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).OperationCategory; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).OperationCategory = value ?? null; }

        /// <summary>ARM ID of the policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string PolicyId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).PolicyId; }

        /// <summary>Name of the policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string PolicyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).PolicyName; }

        /// <summary>Indicated whether progress is enabled for the job</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public bool? ProgressEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ProgressEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ProgressEnabled = value ?? default(bool); }

        /// <summary>Url which contains job's progress</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string ProgressUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).ProgressUrl; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJob _property;

        /// <summary>AzureBackupJobResource properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJob Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupJob()); set => this._property = value; }

        /// <summary>
        /// It indicates the sub type of operation i.e. in case of Restore it can be ALR/OLR
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string RestoreType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).RestoreType; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string SourceDataStoreName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).SourceDataStoreName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).SourceDataStoreName = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string SourceRecoverPointRecoveryPointId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).SourceRecoverPointRecoveryPointId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).SourceRecoverPointRecoveryPointId = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public global::System.DateTime? SourceRecoverPointRecoveryPointTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).SourceRecoverPointRecoveryPointTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).SourceRecoverPointRecoveryPointTime = value ?? default(global::System.DateTime); }

        /// <summary>Resource Group Name of the Datasource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string SourceResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).SourceResourceGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).SourceResourceGroup = value ?? null; }

        /// <summary>SubscriptionId corresponding to the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string SourceSubscriptionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).SourceSubscriptionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).SourceSubscriptionId = value ?? null; }

        /// <summary>StartTime of the job(in UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public global::System.DateTime? StartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).StartTime = value ?? default(global::System.DateTime); }

        /// <summary>Status of the job like InProgress/Success/Failed/Cancelled/SuccessWithWarning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).Status = value ?? null; }

        /// <summary>Subscription Id of the corresponding backup vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string SubscriptionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).SubscriptionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).SubscriptionId = value ?? null; }

        /// <summary>List of supported actions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string[] SupportedAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).SupportedAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).SupportedAction = value ?? null /* arrayOf */; }

        /// <summary>Metadata pertaining to creation and last modification of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).SystemData; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string TargetRecoverPointRecoveryPointId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).TargetRecoverPointRecoveryPointId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).TargetRecoverPointRecoveryPointId = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public global::System.DateTime? TargetRecoverPointRecoveryPointTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).TargetRecoverPointRecoveryPointTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).TargetRecoverPointRecoveryPointTime = value ?? default(global::System.DateTime); }

        /// <summary>
        /// Resource type represents the complete path of the form Namespace/ResourceType/ResourceType/...
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal)__dppResource).Type; }

        /// <summary>Name of the vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string VaultName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).VaultName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJobInternal)Property).VaultName = value ?? null; }

        /// <summary>Creates an new <see cref="AzureBackupJobResource" /> instance.</summary>
        public AzureBackupJobResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__dppResource), __dppResource);
            await eventListener.AssertObjectIsValid(nameof(__dppResource), __dppResource);
        }
    }
    /// AzureBackup Job Resource Class
    public partial interface IAzureBackupJobResource :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResource
    {
        /// <summary>Job Activity Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job Activity Id",
        SerializedName = @"activityID",
        PossibleTypes = new [] { typeof(string) })]
        string ActivityId { get; set; }
        /// <summary>Name of the Backup Instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
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
        Required = false,
        ReadOnly = false,
        Description = @"ARM ID of the DataSource",
        SerializedName = @"dataSourceId",
        PossibleTypes = new [] { typeof(string) })]
        string DataSourceId { get; set; }
        /// <summary>Location of the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Location of the DataSource",
        SerializedName = @"dataSourceLocation",
        PossibleTypes = new [] { typeof(string) })]
        string DataSourceLocation { get; set; }
        /// <summary>User Friendly Name of the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"User Friendly Name of the DataSource",
        SerializedName = @"dataSourceName",
        PossibleTypes = new [] { typeof(string) })]
        string DataSourceName { get; set; }
        /// <summary>Data Source Set Name of the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Data Source Set Name of the DataSource",
        SerializedName = @"dataSourceSetName",
        PossibleTypes = new [] { typeof(string) })]
        string DataSourceSetName { get; set; }
        /// <summary>Type of DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of DataSource",
        SerializedName = @"dataSourceType",
        PossibleTypes = new [] { typeof(string) })]
        string DataSourceType { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"destinationDataStoreName",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationDataStoreName { get; set; }
        /// <summary>Total run time of the job. ISO 8601 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Total run time of the job. ISO 8601 format.",
        SerializedName = @"duration",
        PossibleTypes = new [] { typeof(string) })]
        string Duration { get; set; }
        /// <summary>EndTime of the job(in UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"EndTime of the job(in UTC)",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get;  }
        /// <summary>A List, detailing the errors related to the job</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A List, detailing the errors related to the job",
        SerializedName = @"errorDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError[] ErrorDetail { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>Job's Additional Details</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job's Additional Details",
        SerializedName = @"additionalDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IJobExtendedInfoAdditionalDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IJobExtendedInfoAdditionalDetails ExtendedInfoAdditionalDetail { get; set; }
        /// <summary>State of the Backup Instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"State of the Backup Instance",
        SerializedName = @"backupInstanceState",
        PossibleTypes = new [] { typeof(string) })]
        string ExtendedInfoBackupInstanceState { get;  }
        /// <summary>Number of bytes transferred</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Number of bytes transferred",
        SerializedName = @"dataTransferredInBytes",
        PossibleTypes = new [] { typeof(double) })]
        double? ExtendedInfoDataTransferredInByte { get;  }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IJobSubTask) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IJobSubTask[] ExtendedInfoSubTask { get;  }
        /// <summary>Indicated that whether the job is adhoc(true) or scheduled(false)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicated that whether the job is adhoc(true) or scheduled(false)",
        SerializedName = @"isUserTriggered",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsUserTriggered { get; set; }
        /// <summary>
        /// It indicates the type of Job i.e. Backup:full/log/diff ;Restore:ALR/OLR; Tiering:Backup/Archive ; Management:ConfigureProtection/UnConfigure
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"It indicates the type of Job i.e. Backup:full/log/diff ;Restore:ALR/OLR; Tiering:Backup/Archive ; Management:ConfigureProtection/UnConfigure",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string Operation { get; set; }
        /// <summary>It indicates the type of Job i.e. Backup/Restore/Tiering/Management</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"It indicates the type of Job i.e. Backup/Restore/Tiering/Management",
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
        Required = false,
        ReadOnly = false,
        Description = @"Indicated whether progress is enabled for the job",
        SerializedName = @"progressEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ProgressEnabled { get; set; }
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
        SerializedName = @"sourceDataStoreName",
        PossibleTypes = new [] { typeof(string) })]
        string SourceDataStoreName { get; set; }

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
        /// <summary>Resource Group Name of the Datasource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource Group Name of the Datasource",
        SerializedName = @"sourceResourceGroup",
        PossibleTypes = new [] { typeof(string) })]
        string SourceResourceGroup { get; set; }
        /// <summary>SubscriptionId corresponding to the DataSource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SubscriptionId corresponding to the DataSource",
        SerializedName = @"sourceSubscriptionID",
        PossibleTypes = new [] { typeof(string) })]
        string SourceSubscriptionId { get; set; }
        /// <summary>StartTime of the job(in UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"StartTime of the job(in UTC)",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }
        /// <summary>Status of the job like InProgress/Success/Failed/Cancelled/SuccessWithWarning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Status of the job like InProgress/Success/Failed/Cancelled/SuccessWithWarning",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get; set; }
        /// <summary>Subscription Id of the corresponding backup vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Subscription Id of the corresponding backup vault",
        SerializedName = @"subscriptionId",
        PossibleTypes = new [] { typeof(string) })]
        string SubscriptionId { get; set; }
        /// <summary>List of supported actions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
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
        Required = false,
        ReadOnly = false,
        Description = @"Name of the vault",
        SerializedName = @"vaultName",
        PossibleTypes = new [] { typeof(string) })]
        string VaultName { get; set; }

    }
    /// AzureBackup Job Resource Class
    internal partial interface IAzureBackupJobResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppResourceInternal
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

        string DestinationDataStoreName { get; set; }
        /// <summary>Total run time of the job. ISO 8601 format.</summary>
        string Duration { get; set; }
        /// <summary>EndTime of the job(in UTC)</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>A List, detailing the errors related to the job</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError[] ErrorDetail { get; set; }

        string Etag { get; set; }
        /// <summary>Extended Information about the job</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IJobExtendedInfo ExtendedInfo { get; set; }
        /// <summary>Job's Additional Details</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IJobExtendedInfoAdditionalDetails ExtendedInfoAdditionalDetail { get; set; }
        /// <summary>State of the Backup Instance</summary>
        string ExtendedInfoBackupInstanceState { get; set; }
        /// <summary>Number of bytes transferred</summary>
        double? ExtendedInfoDataTransferredInByte { get; set; }
        /// <summary>Destination where restore is done</summary>
        string ExtendedInfoRecoveryDestination { get; set; }
        /// <summary>Details of the Source Recovery Point</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreJobRecoveryPointDetails ExtendedInfoSourceRecoverPoint { get; set; }
        /// <summary>List of Sub Tasks of the job</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IJobSubTask[] ExtendedInfoSubTask { get; set; }
        /// <summary>Details of the Target Recovery Point</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreJobRecoveryPointDetails ExtendedInfoTargetRecoverPoint { get; set; }
        /// <summary>Indicated that whether the job is adhoc(true) or scheduled(false)</summary>
        bool? IsUserTriggered { get; set; }
        /// <summary>
        /// It indicates the type of Job i.e. Backup:full/log/diff ;Restore:ALR/OLR; Tiering:Backup/Archive ; Management:ConfigureProtection/UnConfigure
        /// </summary>
        string Operation { get; set; }
        /// <summary>It indicates the type of Job i.e. Backup/Restore/Tiering/Management</summary>
        string OperationCategory { get; set; }
        /// <summary>ARM ID of the policy</summary>
        string PolicyId { get; set; }
        /// <summary>Name of the policy</summary>
        string PolicyName { get; set; }
        /// <summary>Indicated whether progress is enabled for the job</summary>
        bool? ProgressEnabled { get; set; }
        /// <summary>Url which contains job's progress</summary>
        string ProgressUrl { get; set; }
        /// <summary>AzureBackupJobResource properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupJob Property { get; set; }
        /// <summary>
        /// It indicates the sub type of operation i.e. in case of Restore it can be ALR/OLR
        /// </summary>
        string RestoreType { get; set; }

        string SourceDataStoreName { get; set; }

        string SourceRecoverPointRecoveryPointId { get; set; }

        global::System.DateTime? SourceRecoverPointRecoveryPointTime { get; set; }
        /// <summary>Resource Group Name of the Datasource</summary>
        string SourceResourceGroup { get; set; }
        /// <summary>SubscriptionId corresponding to the DataSource</summary>
        string SourceSubscriptionId { get; set; }
        /// <summary>StartTime of the job(in UTC)</summary>
        global::System.DateTime? StartTime { get; set; }
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