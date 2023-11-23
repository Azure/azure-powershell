namespace Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Extensions;

    /// <summary>
    /// Result of the request to list Windows IoT Device Service operations. It contains a list of operations and a URL link to
    /// get the next set of results.
    /// </summary>
    public partial class OperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationListResult,
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntity[] Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntity[] _value;

        /// <summary>
        /// List of Windows IoT Device Service operations supported by the Microsoft.WindowsIoT resource provider.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntity[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="OperationListResult" /> instance.</summary>
        public OperationListResult()
        {

        }
    }
    /// Result of the request to list Windows IoT Device Service operations. It contains a list of operations and a URL link to
    /// get the next set of results.
    public partial interface IOperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.IJsonSerializable
    {
        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"URL to get the next set of operation list results if there are any.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>
        /// List of Windows IoT Device Service operations supported by the Microsoft.WindowsIoT resource provider.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of Windows IoT Device Service operations supported by the Microsoft.WindowsIoT resource provider.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntity) })]
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntity[] Value { get;  }

    }
    /// Result of the request to list Windows IoT Device Service operations. It contains a list of operations and a URL link to
    /// get the next set of results.
    internal partial interface IOperationListResultInternal

    {
        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        string NextLink { get; set; }
        /// <summary>
        /// List of Windows IoT Device Service operations supported by the Microsoft.WindowsIoT resource provider.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntity[] Value { get; set; }

    }
}