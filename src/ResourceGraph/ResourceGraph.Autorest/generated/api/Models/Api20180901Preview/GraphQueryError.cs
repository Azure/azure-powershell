namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Extensions;

    /// <summary>Error message body that will indicate why the operation failed.</summary>
    public partial class GraphQueryError :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryError,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryErrorInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>
        /// Service-defined error code. This code serves as a sub-status for the HTTP error code specified in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Owned)]
        public string Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IErrorFieldContract[] _detail;

        /// <summary>The list of invalid fields send in request, in case of validation error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IErrorFieldContract[] Detail { get => this._detail; set => this._detail = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Human-readable representation of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Creates an new <see cref="GraphQueryError" /> instance.</summary>
        public GraphQueryError()
        {

        }
    }
    /// Error message body that will indicate why the operation failed.
    public partial interface IGraphQueryError :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Service-defined error code. This code serves as a sub-status for the HTTP error code specified in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Service-defined error code. This code serves as a sub-status for the HTTP error code specified in the response.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>The list of invalid fields send in request, in case of validation error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of invalid fields send in request, in case of validation error.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IErrorFieldContract) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IErrorFieldContract[] Detail { get; set; }
        /// <summary>Human-readable representation of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Human-readable representation of the error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }

    }
    /// Error message body that will indicate why the operation failed.
    internal partial interface IGraphQueryErrorInternal

    {
        /// <summary>
        /// Service-defined error code. This code serves as a sub-status for the HTTP error code specified in the response.
        /// </summary>
        string Code { get; set; }
        /// <summary>The list of invalid fields send in request, in case of validation error.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IErrorFieldContract[] Detail { get; set; }
        /// <summary>Human-readable representation of the error.</summary>
        string Message { get; set; }

    }
}