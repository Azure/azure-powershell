namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>
    /// Result of the request to list REST API operations. It contains a list of operations and a URL nextLink to get the next
    /// set of results.
    /// </summary>
    public partial class OperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperationListResult,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperationListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperation[] _value;

        /// <summary>The list of operations supported by the resource provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperation[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="OperationListResult" /> instance.</summary>
        public OperationListResult()
        {

        }
    }
    /// Result of the request to list REST API operations. It contains a list of operations and a URL nextLink to get the next
    /// set of results.
    public partial interface IOperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable
    {
        /// <summary>The URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL to get the next set of operation list results if there are any.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The list of operations supported by the resource provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of operations supported by the resource provider.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperation) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperation[] Value { get; set; }

    }
    /// Result of the request to list REST API operations. It contains a list of operations and a URL nextLink to get the next
    /// set of results.
    public partial interface IOperationListResultInternal

    {
        /// <summary>The URL to get the next set of operation list results if there are any.</summary>
        string NextLink { get; set; }
        /// <summary>The list of operations supported by the resource provider.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IOperation[] Value { get; set; }

    }
}