namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Validate for backup request</summary>
    public partial class ValidateForBackupRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IValidateForBackupRequest,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IValidateForBackupRequestInternal
    {

        /// <summary>Backing field for <see cref="BackupInstance" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstance _backupInstance;

        /// <summary>Backup Instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstance BackupInstance { get => (this._backupInstance = this._backupInstance ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.BackupInstance()); set => this._backupInstance = value; }

        /// <summary>Creates an new <see cref="ValidateForBackupRequest" /> instance.</summary>
        public ValidateForBackupRequest()
        {

        }
    }
    /// Validate for backup request
    public partial interface IValidateForBackupRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Backup Instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Backup Instance",
        SerializedName = @"backupInstance",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstance) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstance BackupInstance { get; set; }

    }
    /// Validate for backup request
    internal partial interface IValidateForBackupRequestInternal

    {
        /// <summary>Backup Instance</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstance BackupInstance { get; set; }

    }
}