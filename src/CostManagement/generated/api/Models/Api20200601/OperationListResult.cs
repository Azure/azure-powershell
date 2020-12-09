namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>
    /// Result of listing cost management operations. It contains a list of operations and a URL link to get the next set of results.
    /// </summary>
    public partial class OperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IOperationListResult,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IOperationListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IOperationListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IOperation[] Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IOperationListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IOperation[] _value;

        /// <summary>
        /// List of cost management operations supported by the Microsoft.CostManagement resource provider.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IOperation[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="OperationListResult" /> instance.</summary>
        public OperationListResult()
        {

        }
    }
    /// Result of listing cost management operations. It contains a list of operations and a URL link to get the next set of results.
    public partial interface IOperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"URL to get the next set of operation list results if there are any.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>
        /// List of cost management operations supported by the Microsoft.CostManagement resource provider.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of cost management operations supported by the Microsoft.CostManagement resource provider.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IOperation) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IOperation[] Value { get;  }

    }
    /// Result of listing cost management operations. It contains a list of operations and a URL link to get the next set of results.
    public partial interface IOperationListResultInternal

    {
        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        string NextLink { get; set; }
        /// <summary>
        /// List of cost management operations supported by the Microsoft.CostManagement resource provider.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IOperation[] Value { get; set; }

    }
}