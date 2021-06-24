namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    public partial class RestoreJobRecoveryPointDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreJobRecoveryPointDetails,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreJobRecoveryPointDetailsInternal
    {

        /// <summary>Backing field for <see cref="RecoveryPointId" /> property.</summary>
        private string _recoveryPointId;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string RecoveryPointId { get => this._recoveryPointId; set => this._recoveryPointId = value; }

        /// <summary>Backing field for <see cref="RecoveryPointTime" /> property.</summary>
        private global::System.DateTime? _recoveryPointTime;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public global::System.DateTime? RecoveryPointTime { get => this._recoveryPointTime; set => this._recoveryPointTime = value; }

        /// <summary>Creates an new <see cref="RestoreJobRecoveryPointDetails" /> instance.</summary>
        public RestoreJobRecoveryPointDetails()
        {

        }
    }
    public partial interface IRestoreJobRecoveryPointDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"recoveryPointID",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryPointId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"recoveryPointTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RecoveryPointTime { get; set; }

    }
    internal partial interface IRestoreJobRecoveryPointDetailsInternal

    {
        string RecoveryPointId { get; set; }

        global::System.DateTime? RecoveryPointTime { get; set; }

    }
}