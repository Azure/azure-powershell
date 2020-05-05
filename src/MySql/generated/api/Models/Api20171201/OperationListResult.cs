namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>A list of resource provider operations.</summary>
    public partial class OperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IOperationListResult,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IOperationListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IOperation[] _value;

        /// <summary>The list of resource provider operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IOperation[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="OperationListResult" /> instance.</summary>
        public OperationListResult()
        {

        }
    }
    /// A list of resource provider operations.
    public partial interface IOperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>The list of resource provider operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of resource provider operations.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IOperation) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IOperation[] Value { get; set; }

    }
    /// A list of resource provider operations.
    internal partial interface IOperationListResultInternal

    {
        /// <summary>The list of resource provider operations.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IOperation[] Value { get; set; }

    }
}