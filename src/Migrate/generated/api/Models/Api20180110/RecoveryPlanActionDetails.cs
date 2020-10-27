namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan action custom details.</summary>
    public partial class RecoveryPlanActionDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetailsInternal
    {

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>
        /// Gets the type of action details (see RecoveryPlanActionDetailsTypes enum for possible values).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanActionDetailsInternal.InstanceType { get => this._instanceType; set { {_instanceType = value;} } }

        /// <summary>Creates an new <see cref="RecoveryPlanActionDetails" /> instance.</summary>
        public RecoveryPlanActionDetails()
        {

        }
    }
    /// Recovery plan action custom details.
    public partial interface IRecoveryPlanActionDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Gets the type of action details (see RecoveryPlanActionDetailsTypes enum for possible values).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the type of action details (see RecoveryPlanActionDetailsTypes enum for possible values).",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceType { get;  }

    }
    /// Recovery plan action custom details.
    internal partial interface IRecoveryPlanActionDetailsInternal

    {
        /// <summary>
        /// Gets the type of action details (see RecoveryPlanActionDetailsTypes enum for possible values).
        /// </summary>
        string InstanceType { get; set; }

    }
}