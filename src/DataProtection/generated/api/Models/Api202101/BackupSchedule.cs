namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Schedule for backup</summary>
    public partial class BackupSchedule :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupSchedule,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupScheduleInternal
    {

        /// <summary>Backing field for <see cref="RepeatingTimeInterval" /> property.</summary>
        private string[] _repeatingTimeInterval;

        /// <summary>ISO 8601 repeating time interval format</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string[] RepeatingTimeInterval { get => this._repeatingTimeInterval; set => this._repeatingTimeInterval = value; }

        /// <summary>Creates an new <see cref="BackupSchedule" /> instance.</summary>
        public BackupSchedule()
        {

        }
    }
    /// Schedule for backup
    public partial interface IBackupSchedule :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>ISO 8601 repeating time interval format</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"ISO 8601 repeating time interval format",
        SerializedName = @"repeatingTimeIntervals",
        PossibleTypes = new [] { typeof(string) })]
        string[] RepeatingTimeInterval { get; set; }

    }
    /// Schedule for backup
    internal partial interface IBackupScheduleInternal

    {
        /// <summary>ISO 8601 repeating time interval format</summary>
        string[] RepeatingTimeInterval { get; set; }

    }
}