namespace Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Extensions;

    /// <summary>
    /// A list of DigitalTwins service operations. It contains a list of operations and a URL link to get the next set of results.
    /// </summary>
    public partial class OperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IOperationListResult,
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IOperationListResultInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IOperation[] Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IOperationListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link used to get the next page of DigitalTwins description objects.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Origin(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IOperation[] _value;

        /// <summary>
        /// A list of DigitalTwins operations supported by the Microsoft.DigitalTwins resource provider.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Origin(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IOperation[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="OperationListResult" /> instance.</summary>
        public OperationListResult()
        {

        }
    }
    /// A list of DigitalTwins service operations. It contains a list of operations and a URL link to get the next set of results.
    public partial interface IOperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.IJsonSerializable
    {
        /// <summary>The link used to get the next page of DigitalTwins description objects.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The link used to get the next page of DigitalTwins description objects.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>
        /// A list of DigitalTwins operations supported by the Microsoft.DigitalTwins resource provider.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of DigitalTwins operations supported by the Microsoft.DigitalTwins resource provider.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IOperation) })]
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IOperation[] Value { get;  }

    }
    /// A list of DigitalTwins service operations. It contains a list of operations and a URL link to get the next set of results.
    internal partial interface IOperationListResultInternal

    {
        /// <summary>The link used to get the next page of DigitalTwins description objects.</summary>
        string NextLink { get; set; }
        /// <summary>
        /// A list of DigitalTwins operations supported by the Microsoft.DigitalTwins resource provider.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IOperation[] Value { get; set; }

    }
}