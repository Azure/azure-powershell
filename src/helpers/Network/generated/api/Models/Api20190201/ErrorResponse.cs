namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>The error object.</summary>
    public partial class ErrorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IErrorResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IErrorResponseInternal
    {

        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IErrorDetailsInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IErrorDetailsInternal)Error).Code = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IErrorDetails _error;

        /// <summary>The error details object.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IErrorDetails Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ErrorDetails()); set => this._error = value; }

        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IErrorDetailsInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IErrorDetailsInternal)Error).Message = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IErrorDetails Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IErrorResponseInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ErrorDetails()); set { {_error = value;} } }

        /// <summary>Error target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IErrorDetailsInternal)Error).Target; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IErrorDetailsInternal)Error).Target = value; }

        /// <summary>Creates an new <see cref="ErrorResponse" /> instance.</summary>
        public ErrorResponse()
        {

        }
    }
    /// The error object.
    public partial interface IErrorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Error target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error target.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get; set; }

    }
    /// The error object.
    internal partial interface IErrorResponseInternal

    {
        /// <summary>Error code.</summary>
        string Code { get; set; }
        /// <summary>The error details object.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IErrorDetails Error { get; set; }
        /// <summary>Error message.</summary>
        string Message { get; set; }
        /// <summary>Error target.</summary>
        string Target { get; set; }

    }
}