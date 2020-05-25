namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>Describes the error information.</summary>
    public partial class ErrorResponseError :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseError,
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>Provides information about the error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorDetailsItem[] _detail;

        /// <summary>Describes the error details if present.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorDetailsItem[] Detail { get => this._detail; set => this._detail = value; }

        /// <summary>Backing field for <see cref="Innererror" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInnererror _innererror;

        /// <summary>Inner error object if present.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInnererror Innererror { get => (this._innererror = this._innererror ?? new Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.ErrorResponseErrorInnererror()); set => this._innererror = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Provides information about the error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="Target" /> property.</summary>
        private string _target;

        /// <summary>Provides information about the error target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string Target { get => this._target; set => this._target = value; }

        /// <summary>Creates an new <see cref="ErrorResponseError" /> instance.</summary>
        public ErrorResponseError()
        {

        }
    }
    /// Describes the error information.
    public partial interface IErrorResponseError :
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
    /// Describes the error information.
    internal partial interface IErrorResponseErrorInternal

    {
        /// <summary>Provides information about the error code.</summary>
        string Code { get; set; }
        /// <summary>Describes the error details if present.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorDetailsItem[] Detail { get; set; }
        /// <summary>Inner error object if present.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IErrorResponseErrorInnererror Innererror { get; set; }
        /// <summary>Provides information about the error message.</summary>
        string Message { get; set; }
        /// <summary>Provides information about the error target.</summary>
        string Target { get; set; }

    }
}