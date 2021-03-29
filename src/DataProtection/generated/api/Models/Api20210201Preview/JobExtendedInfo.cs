namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Extended Information about the job</summary>
    public partial class JobExtendedInfo :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobExtendedInfo,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobExtendedInfoInternal
    {

        /// <summary>Backing field for <see cref="AdditionalDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobExtendedInfoAdditionalDetails _additionalDetail;

        /// <summary>Job's Additional Details</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobExtendedInfoAdditionalDetails AdditionalDetail { get => (this._additionalDetail = this._additionalDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.JobExtendedInfoAdditionalDetails()); set => this._additionalDetail = value; }

        /// <summary>Backing field for <see cref="BackupInstanceState" /> property.</summary>
        private string _backupInstanceState;

        /// <summary>State of the Backup Instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string BackupInstanceState { get => this._backupInstanceState; }

        /// <summary>Backing field for <see cref="DataTransferredInByte" /> property.</summary>
        private double? _dataTransferredInByte;

        /// <summary>Number of bytes transferred</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public double? DataTransferredInByte { get => this._dataTransferredInByte; }

        /// <summary>Internal Acessors for BackupInstanceState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobExtendedInfoInternal.BackupInstanceState { get => this._backupInstanceState; set { {_backupInstanceState = value;} } }

        /// <summary>Internal Acessors for DataTransferredInByte</summary>
        double? Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobExtendedInfoInternal.DataTransferredInByte { get => this._dataTransferredInByte; set { {_dataTransferredInByte = value;} } }

        /// <summary>Internal Acessors for RecoveryDestination</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobExtendedInfoInternal.RecoveryDestination { get => this._recoveryDestination; set { {_recoveryDestination = value;} } }

        /// <summary>Internal Acessors for SourceRecoverPoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestoreJobRecoveryPointDetails Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobExtendedInfoInternal.SourceRecoverPoint { get => (this._sourceRecoverPoint = this._sourceRecoverPoint ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.RestoreJobRecoveryPointDetails()); set { {_sourceRecoverPoint = value;} } }

        /// <summary>Internal Acessors for SubTask</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobSubTask[] Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobExtendedInfoInternal.SubTask { get => this._subTask; set { {_subTask = value;} } }

        /// <summary>Internal Acessors for TargetRecoverPoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestoreJobRecoveryPointDetails Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobExtendedInfoInternal.TargetRecoverPoint { get => (this._targetRecoverPoint = this._targetRecoverPoint ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.RestoreJobRecoveryPointDetails()); set { {_targetRecoverPoint = value;} } }

        /// <summary>Backing field for <see cref="RecoveryDestination" /> property.</summary>
        private string _recoveryDestination;

        /// <summary>Destination where restore is done</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string RecoveryDestination { get => this._recoveryDestination; }

        /// <summary>Backing field for <see cref="SourceRecoverPoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestoreJobRecoveryPointDetails _sourceRecoverPoint;

        /// <summary>Details of the Source Recovery Point</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestoreJobRecoveryPointDetails SourceRecoverPoint { get => (this._sourceRecoverPoint = this._sourceRecoverPoint ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.RestoreJobRecoveryPointDetails()); }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string SourceRecoverPointRecoveryPointId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestoreJobRecoveryPointDetailsInternal)SourceRecoverPoint).RecoveryPointId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestoreJobRecoveryPointDetailsInternal)SourceRecoverPoint).RecoveryPointId = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public global::System.DateTime? SourceRecoverPointRecoveryPointTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestoreJobRecoveryPointDetailsInternal)SourceRecoverPoint).RecoveryPointTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestoreJobRecoveryPointDetailsInternal)SourceRecoverPoint).RecoveryPointTime = value ?? default(global::System.DateTime); }

        /// <summary>Backing field for <see cref="SubTask" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobSubTask[] _subTask;

        /// <summary>List of Sub Tasks of the job</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobSubTask[] SubTask { get => this._subTask; }

        /// <summary>Backing field for <see cref="TargetRecoverPoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestoreJobRecoveryPointDetails _targetRecoverPoint;

        /// <summary>Details of the Target Recovery Point</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestoreJobRecoveryPointDetails TargetRecoverPoint { get => (this._targetRecoverPoint = this._targetRecoverPoint ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.RestoreJobRecoveryPointDetails()); }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string TargetRecoverPointRecoveryPointId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestoreJobRecoveryPointDetailsInternal)TargetRecoverPoint).RecoveryPointId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestoreJobRecoveryPointDetailsInternal)TargetRecoverPoint).RecoveryPointId = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public global::System.DateTime? TargetRecoverPointRecoveryPointTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestoreJobRecoveryPointDetailsInternal)TargetRecoverPoint).RecoveryPointTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestoreJobRecoveryPointDetailsInternal)TargetRecoverPoint).RecoveryPointTime = value ?? default(global::System.DateTime); }

        /// <summary>Creates an new <see cref="JobExtendedInfo" /> instance.</summary>
        public JobExtendedInfo()
        {

        }
    }
    /// Extended Information about the job
    public partial interface IJobExtendedInfo :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Job's Additional Details</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Job's Additional Details",
        SerializedName = @"additionalDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobExtendedInfoAdditionalDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobExtendedInfoAdditionalDetails AdditionalDetail { get; set; }
        /// <summary>State of the Backup Instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"State of the Backup Instance",
        SerializedName = @"backupInstanceState",
        PossibleTypes = new [] { typeof(string) })]
        string BackupInstanceState { get;  }
        /// <summary>Number of bytes transferred</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Number of bytes transferred",
        SerializedName = @"dataTransferredInBytes",
        PossibleTypes = new [] { typeof(double) })]
        double? DataTransferredInByte { get;  }
        /// <summary>Destination where restore is done</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Destination where restore is done",
        SerializedName = @"recoveryDestination",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryDestination { get;  }

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
        /// <summary>List of Sub Tasks of the job</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of Sub Tasks of the job",
        SerializedName = @"subTasks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobSubTask) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobSubTask[] SubTask { get;  }

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

    }
    /// Extended Information about the job
    internal partial interface IJobExtendedInfoInternal

    {
        /// <summary>Job's Additional Details</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobExtendedInfoAdditionalDetails AdditionalDetail { get; set; }
        /// <summary>State of the Backup Instance</summary>
        string BackupInstanceState { get; set; }
        /// <summary>Number of bytes transferred</summary>
        double? DataTransferredInByte { get; set; }
        /// <summary>Destination where restore is done</summary>
        string RecoveryDestination { get; set; }
        /// <summary>Details of the Source Recovery Point</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestoreJobRecoveryPointDetails SourceRecoverPoint { get; set; }

        string SourceRecoverPointRecoveryPointId { get; set; }

        global::System.DateTime? SourceRecoverPointRecoveryPointTime { get; set; }
        /// <summary>List of Sub Tasks of the job</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IJobSubTask[] SubTask { get; set; }
        /// <summary>Details of the Target Recovery Point</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestoreJobRecoveryPointDetails TargetRecoverPoint { get; set; }

        string TargetRecoverPointRecoveryPointId { get; set; }

        global::System.DateTime? TargetRecoverPointRecoveryPointTime { get; set; }

    }
}