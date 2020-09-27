namespace Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Extensions;

    /// <summary>
    /// Result of the request to list Dedicated HSM Provider operations. It contains a list of operations.
    /// </summary>
    public partial class DedicatedHsmOperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationListResult,
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperation[] _value;

        /// <summary>List of Dedicated HSM Resource Provider operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperation[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="DedicatedHsmOperationListResult" /> instance.</summary>
        public DedicatedHsmOperationListResult()
        {

        }
    }
    /// Result of the request to list Dedicated HSM Provider operations. It contains a list of operations.
    public partial interface IDedicatedHsmOperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.IJsonSerializable
    {
        /// <summary>List of Dedicated HSM Resource Provider operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of Dedicated HSM Resource Provider operations.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperation) })]
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperation[] Value { get; set; }

    }
    /// Result of the request to list Dedicated HSM Provider operations. It contains a list of operations.
    internal partial interface IDedicatedHsmOperationListResultInternal

    {
        /// <summary>List of Dedicated HSM Resource Provider operations.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperation[] Value { get; set; }

    }
}