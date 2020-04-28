namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>
    /// Result of the request to list Resource Provider operations. It contains a list of operations and a URL link to get the
    /// next set of results.
    /// </summary>
    public partial class OperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IOperationListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IOperationListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IOperation[] _value;

        /// <summary>
        /// List of Resource Provider operations supported by the Resource Provider resource provider.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IOperation[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="OperationListResult" /> instance.</summary>
        public OperationListResult()
        {

        }
    }
    /// Result of the request to list Resource Provider operations. It contains a list of operations and a URL link to get the
    /// next set of results.
    public partial interface IOperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.IJsonSerializable
    {
        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL to get the next set of operation list results if there are any.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>
        /// List of Resource Provider operations supported by the Resource Provider resource provider.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of Resource Provider operations supported by the Resource Provider resource provider.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IOperation) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IOperation[] Value { get; set; }

    }
    /// Result of the request to list Resource Provider operations. It contains a list of operations and a URL link to get the
    /// next set of results.
    internal partial interface IOperationListResultInternal

    {
        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        string NextLink { get; set; }
        /// <summary>
        /// List of Resource Provider operations supported by the Resource Provider resource provider.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IOperation[] Value { get; set; }

    }
}