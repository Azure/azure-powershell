namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Validate for backup request</summary>
    public partial class ValidateForBackupRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IValidateForBackupRequest,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IValidateForBackupRequestInternal
    {

        /// <summary>Backing field for <see cref="BackupInstance" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBackupInstance _backupInstance;

        /// <summary>Backup instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBackupInstance BackupInstance { get => (this._backupInstance = this._backupInstance ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.BackupInstance()); set => this._backupInstance = value; }

        /// <summary>Creates an new <see cref="ValidateForBackupRequest" /> instance.</summary>
        public ValidateForBackupRequest()
        {

        }
    }
    /// Validate for backup request
    public partial interface IValidateForBackupRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Backup instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Backup instance",
        SerializedName = @"backupInstance",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBackupInstance) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBackupInstance BackupInstance { get; set; }

    }
    /// Validate for backup request
    internal partial interface IValidateForBackupRequestInternal

    {
        /// <summary>Backup instance</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IBackupInstance BackupInstance { get; set; }

    }
}