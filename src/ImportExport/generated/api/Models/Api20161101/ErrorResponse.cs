namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>Response when errors occurred</summary>
    public partial class ErrorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponse,
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseInternal
    {

        /// <summary>Provides information about the error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInternal)Error).Code = value; }

        /// <summary>Describes the error details if present.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorDetailsItem[] Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInternal)Error).Detail; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInternal)Error).Detail = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseError _error;

        /// <summary>Describes the error information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseError Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ErrorResponseError()); set => this._error = value; }

        /// <summary>Inner error object if present.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInnererror Innererror { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInternal)Error).Innererror; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInternal)Error).Innererror = value; }

        /// <summary>Provides information about the error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInternal)Error).Message = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseError Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ErrorResponseError()); set { {_error = value;} } }

        /// <summary>Provides information about the error target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Inlined)]
        public string Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInternal)Error).Target; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInternal)Error).Target = value; }

        /// <summary>Creates an new <see cref="ErrorResponse" /> instance.</summary>
        public ErrorResponse()
        {

        }
    }
    /// Response when errors occurred
    public partial interface IErrorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.IJsonSerializable
    {
        /// <summary>Provides information about the error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provides information about the error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>Describes the error details if present.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes the error details if present.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorDetailsItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorDetailsItem[] Detail { get; set; }
        /// <summary>Inner error object if present.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Inner error object if present.",
        SerializedName = @"innererror",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInnererror) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInnererror Innererror { get; set; }
        /// <summary>Provides information about the error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provides information about the error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Provides information about the error target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provides information about the error target.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get; set; }

    }
    /// Response when errors occurred
    internal partial interface IErrorResponseInternal

    {
        /// <summary>Provides information about the error code.</summary>
        string Code { get; set; }
        /// <summary>Describes the error details if present.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorDetailsItem[] Detail { get; set; }
        /// <summary>Describes the error information.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseError Error { get; set; }
        /// <summary>Inner error object if present.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInnererror Innererror { get; set; }
        /// <summary>Provides information about the error message.</summary>
        string Message { get; set; }
        /// <summary>Provides information about the error target.</summary>
        string Target { get; set; }

    }
}