namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>The List Compute Operation operation response.</summary>
    public partial class OperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationListResult,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationListResultInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValue[] Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValue[] _value;

        /// <summary>The list of compute operations</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValue[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="OperationListResult" /> instance.</summary>
        public OperationListResult()
        {

        }
    }
    /// The List Compute Operation operation response.
    public partial interface IOperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable
    {
        /// <summary>The list of compute operations</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The list of compute operations",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValue) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValue[] Value { get;  }

    }
    /// The List Compute Operation operation response.
    internal partial interface IOperationListResultInternal

    {
        /// <summary>The list of compute operations</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValue[] Value { get; set; }

    }
}