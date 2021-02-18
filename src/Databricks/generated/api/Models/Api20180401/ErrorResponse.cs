namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>Contains details when the response code indicates an error.</summary>
    public partial class ErrorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorResponseInternal
    {

        /// <summary>A machine readable error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorInfoInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorInfoInternal)Error).Code = value ; }

        /// <summary>error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorDetail[] Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorInfoInternal)Error).Detail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorInfoInternal)Error).Detail = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorInfo _error;

        /// <summary>The error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorInfo Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ErrorInfo()); set => this._error = value; }

        /// <summary>Inner error details if they exist.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string Innererror { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorInfoInternal)Error).Innererror; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorInfoInternal)Error).Innererror = value ?? null; }

        /// <summary>A human readable error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorInfoInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorInfoInternal)Error).Message = value ; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorInfo Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorResponseInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ErrorInfo()); set { {_error = value;} } }

        /// <summary>Creates an new <see cref="ErrorResponse" /> instance.</summary>
        public ErrorResponse()
        {

        }
    }
    /// Contains details when the response code indicates an error.
    public partial interface IErrorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.IJsonSerializable
    {
        /// <summary>A machine readable error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A machine readable error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"error details.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorDetail) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorDetail[] Detail { get; set; }
        /// <summary>Inner error details if they exist.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Inner error details if they exist.",
        SerializedName = @"innererror",
        PossibleTypes = new [] { typeof(string) })]
        string Innererror { get; set; }
        /// <summary>A human readable error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A human readable error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }

    }
    /// Contains details when the response code indicates an error.
    internal partial interface IErrorResponseInternal

    {
        /// <summary>A machine readable error code.</summary>
        string Code { get; set; }
        /// <summary>error details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorDetail[] Detail { get; set; }
        /// <summary>The error details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IErrorInfo Error { get; set; }
        /// <summary>Inner error details if they exist.</summary>
        string Innererror { get; set; }
        /// <summary>A human readable error message.</summary>
        string Message { get; set; }

    }
}