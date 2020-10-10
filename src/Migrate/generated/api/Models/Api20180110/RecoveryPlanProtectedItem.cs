namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery plan protected item.</summary>
    public partial class RecoveryPlanProtectedItem :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProtectedItem,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryPlanProtectedItemInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The ARM Id of the recovery plan protected item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="VirtualMachineId" /> property.</summary>
        private string _virtualMachineId;

        /// <summary>The virtual machine Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VirtualMachineId { get => this._virtualMachineId; set => this._virtualMachineId = value; }

        /// <summary>Creates an new <see cref="RecoveryPlanProtectedItem" /> instance.</summary>
        public RecoveryPlanProtectedItem()
        {

        }
    }
    /// Recovery plan protected item.
    public partial interface IRecoveryPlanProtectedItem :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The ARM Id of the recovery plan protected item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM Id of the recovery plan protected item.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>The virtual machine Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The virtual machine Id.",
        SerializedName = @"virtualMachineId",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualMachineId { get; set; }

    }
    /// Recovery plan protected item.
    internal partial interface IRecoveryPlanProtectedItemInternal

    {
        /// <summary>The ARM Id of the recovery plan protected item.</summary>
        string Id { get; set; }
        /// <summary>The virtual machine Id.</summary>
        string VirtualMachineId { get; set; }

    }
}