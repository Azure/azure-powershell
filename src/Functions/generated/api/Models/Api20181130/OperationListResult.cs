namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>A list of operations supported by Microsoft.ManagedIdentity Resource Provider.</summary>
    public partial class OperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IOperationListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IOperationListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The url to get the next page of results, if any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IOperation[] _value;

        /// <summary>A list of operations supported by Microsoft.ManagedIdentity Resource Provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IOperation[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="OperationListResult" /> instance.</summary>
        public OperationListResult()
        {

        }
    }
    /// A list of operations supported by Microsoft.ManagedIdentity Resource Provider.
    public partial interface IOperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The url to get the next page of results, if any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The url to get the next page of results, if any.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>A list of operations supported by Microsoft.ManagedIdentity Resource Provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of operations supported by Microsoft.ManagedIdentity Resource Provider.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IOperation) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IOperation[] Value { get; set; }

    }
    /// A list of operations supported by Microsoft.ManagedIdentity Resource Provider.
    internal partial interface IOperationListResultInternal

    {
        /// <summary>The url to get the next page of results, if any.</summary>
        string NextLink { get; set; }
        /// <summary>A list of operations supported by Microsoft.ManagedIdentity Resource Provider.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.IOperation[] Value { get; set; }

    }
}