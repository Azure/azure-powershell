namespace Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Extensions;

    /// <summary>
    /// Result of the request to list REST API operations. It contains a list of operations.
    /// </summary>
    public partial class OperationList :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationList,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperationListInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>
        /// The URL the client should use to fetch the next page (per server side paging).
        /// It's null for now, added for future use.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperation[] _value;

        /// <summary>List of operations supported by the resource provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperation[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="OperationList" /> instance.</summary>
        public OperationList()
        {

        }
    }
    /// Result of the request to list REST API operations. It contains a list of operations.
    public partial interface IOperationList :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The URL the client should use to fetch the next page (per server side paging).
        /// It's null for now, added for future use.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL the client should use to fetch the next page (per server side paging).
        It's null for now, added for future use.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>List of operations supported by the resource provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of operations supported by the resource provider.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperation) })]
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperation[] Value { get; set; }

    }
    /// Result of the request to list REST API operations. It contains a list of operations.
    internal partial interface IOperationListInternal

    {
        /// <summary>
        /// The URL the client should use to fetch the next page (per server side paging).
        /// It's null for now, added for future use.
        /// </summary>
        string NextLink { get; set; }
        /// <summary>List of operations supported by the resource provider.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IOperation[] Value { get; set; }

    }
}