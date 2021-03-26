namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Azure backup parameters</summary>
    public partial class AzureBackupParams :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupParams,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupParamsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupParameters"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupParameters __backupParameters = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.BackupParameters();

        /// <summary>Backing field for <see cref="BackupType" /> property.</summary>
        private string _backupType;

        /// <summary>BackupType ; Full/Incremental etc</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string BackupType { get => this._backupType; set => this._backupType = value; }

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupParametersInternal)__backupParameters).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupParametersInternal)__backupParameters).ObjectType = value ; }

        /// <summary>Creates an new <see cref="AzureBackupParams" /> instance.</summary>
        public AzureBackupParams()
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
            await eventListener.AssertNotNull(nameof(__backupParameters), __backupParameters);
            await eventListener.AssertObjectIsValid(nameof(__backupParameters), __backupParameters);
        }
    }
    /// Azure backup parameters
    public partial interface IAzureBackupParams :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupParameters
    {
        /// <summary>BackupType ; Full/Incremental etc</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"BackupType ; Full/Incremental etc",
        SerializedName = @"backupType",
        PossibleTypes = new [] { typeof(string) })]
        string BackupType { get; set; }

    }
    /// Azure backup parameters
    internal partial interface IAzureBackupParamsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupParametersInternal
    {
        /// <summary>BackupType ; Full/Incremental etc</summary>
        string BackupType { get; set; }

    }
}