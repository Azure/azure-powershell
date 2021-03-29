namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>AzureBackup Restore with Rehydration Request</summary>
    public partial class AzureBackupRestoreWithRehydrationRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRestoreWithRehydrationRequest,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRestoreWithRehydrationRequestInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRecoveryPointBasedRestoreRequest"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRecoveryPointBasedRestoreRequest __azureBackupRecoveryPointBasedRestoreRequest = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.AzureBackupRecoveryPointBasedRestoreRequest();

        /// <summary>Internal Acessors for RestoreTargetInfoRecoveryOption</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRestoreRequestInternal.RestoreTargetInfoRecoveryOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRestoreRequestInternal)__azureBackupRecoveryPointBasedRestoreRequest).RestoreTargetInfoRecoveryOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRestoreRequestInternal)__azureBackupRecoveryPointBasedRestoreRequest).RestoreTargetInfoRecoveryOption = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRestoreRequestInternal)__azureBackupRecoveryPointBasedRestoreRequest).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRestoreRequestInternal)__azureBackupRecoveryPointBasedRestoreRequest).ObjectType = value ; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string RecoveryPointId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRecoveryPointBasedRestoreRequestInternal)__azureBackupRecoveryPointBasedRestoreRequest).RecoveryPointId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRecoveryPointBasedRestoreRequestInternal)__azureBackupRecoveryPointBasedRestoreRequest).RecoveryPointId = value ; }

        /// <summary>Backing field for <see cref="RehydrationPriority" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RehydrationPriority _rehydrationPriority;

        /// <summary>Priority to be used for rehydration. Values High or Standard</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RehydrationPriority RehydrationPriority { get => this._rehydrationPriority; set => this._rehydrationPriority = value; }

        /// <summary>Backing field for <see cref="RehydrationRetentionDuration" /> property.</summary>
        private string _rehydrationRetentionDuration;

        /// <summary>Retention duration in ISO 8601 format i.e P10D .</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string RehydrationRetentionDuration { get => this._rehydrationRetentionDuration; set => this._rehydrationRetentionDuration = value; }

        /// <summary>Gets or sets the restore target information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestoreTargetInfoBase RestoreTargetInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRestoreRequestInternal)__azureBackupRecoveryPointBasedRestoreRequest).RestoreTargetInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRestoreRequestInternal)__azureBackupRecoveryPointBasedRestoreRequest).RestoreTargetInfo = value ; }

        /// <summary>Type of Datasource object, used to initialize the right inherited type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string RestoreTargetInfoObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRestoreRequestInternal)__azureBackupRecoveryPointBasedRestoreRequest).RestoreTargetInfoObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRestoreRequestInternal)__azureBackupRecoveryPointBasedRestoreRequest).RestoreTargetInfoObjectType = value ; }

        /// <summary>Recovery Option</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string RestoreTargetInfoRecoveryOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRestoreRequestInternal)__azureBackupRecoveryPointBasedRestoreRequest).RestoreTargetInfoRecoveryOption; }

        /// <summary>Target Restore region</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string RestoreTargetInfoRestoreLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRestoreRequestInternal)__azureBackupRecoveryPointBasedRestoreRequest).RestoreTargetInfoRestoreLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRestoreRequestInternal)__azureBackupRecoveryPointBasedRestoreRequest).RestoreTargetInfoRestoreLocation = value ?? null; }

        /// <summary>Gets or sets the type of the source data store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SourceDataStoreType SourceDataStoreType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRestoreRequestInternal)__azureBackupRecoveryPointBasedRestoreRequest).SourceDataStoreType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRestoreRequestInternal)__azureBackupRecoveryPointBasedRestoreRequest).SourceDataStoreType = value ; }

        /// <summary>
        /// Creates an new <see cref="AzureBackupRestoreWithRehydrationRequest" /> instance.
        /// </summary>
        public AzureBackupRestoreWithRehydrationRequest()
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
            await eventListener.AssertNotNull(nameof(__azureBackupRecoveryPointBasedRestoreRequest), __azureBackupRecoveryPointBasedRestoreRequest);
            await eventListener.AssertObjectIsValid(nameof(__azureBackupRecoveryPointBasedRestoreRequest), __azureBackupRecoveryPointBasedRestoreRequest);
        }
    }
    /// AzureBackup Restore with Rehydration Request
    public partial interface IAzureBackupRestoreWithRehydrationRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRecoveryPointBasedRestoreRequest
    {
        /// <summary>Priority to be used for rehydration. Values High or Standard</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Priority to be used for rehydration. Values High or Standard",
        SerializedName = @"rehydrationPriority",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RehydrationPriority) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RehydrationPriority RehydrationPriority { get; set; }
        /// <summary>Retention duration in ISO 8601 format i.e P10D .</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Retention duration in ISO 8601 format i.e P10D .",
        SerializedName = @"rehydrationRetentionDuration",
        PossibleTypes = new [] { typeof(string) })]
        string RehydrationRetentionDuration { get; set; }

    }
    /// AzureBackup Restore with Rehydration Request
    internal partial interface IAzureBackupRestoreWithRehydrationRequestInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupRecoveryPointBasedRestoreRequestInternal
    {
        /// <summary>Priority to be used for rehydration. Values High or Standard</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RehydrationPriority RehydrationPriority { get; set; }
        /// <summary>Retention duration in ISO 8601 format i.e P10D .</summary>
        string RehydrationRetentionDuration { get; set; }

    }
}