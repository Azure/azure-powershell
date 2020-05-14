namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>App Service error response.</summary>
    public partial class DefaultErrorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseInternal
    {

        /// <summary>Standardized string to programmatically identify the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal)Error).Code; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorDetailsItem[] Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal)Error).Detail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal)Error).Detail = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseError _error;

        /// <summary>Error model.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseError Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DefaultErrorResponseError()); }

        /// <summary>More information to debug error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Innererror { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal)Error).Innererror; }

        /// <summary>Detailed error description and debugging information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal)Error).Message; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseInternal.Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal)Error).Code = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseError Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DefaultErrorResponseError()); set { {_error = value;} } }

        /// <summary>Internal Acessors for Innererror</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseInternal.Innererror { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal)Error).Innererror; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal)Error).Innererror = value; }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseInternal.Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal)Error).Message = value; }

        /// <summary>Internal Acessors for Target</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseInternal.Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal)Error).Target; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal)Error).Target = value; }

        /// <summary>Detailed error description and debugging information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal)Error).Target; }

        /// <summary>Creates an new <see cref="DefaultErrorResponse" /> instance.</summary>
        public DefaultErrorResponse()
        {

        }
    }
    /// App Service error response.
    public partial interface IDefaultErrorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Standardized string to programmatically identify the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Standardized string to programmatically identify the error.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorDetailsItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorDetailsItem[] Detail { get; set; }
        /// <summary>More information to debug error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"More information to debug error.",
        SerializedName = @"innererror",
        PossibleTypes = new [] { typeof(string) })]
        string Innererror { get;  }
        /// <summary>Detailed error description and debugging information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Detailed error description and debugging information.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>Detailed error description and debugging information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Detailed error description and debugging information.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get;  }

    }
    /// App Service error response.
    internal partial interface IDefaultErrorResponseInternal

    {
        /// <summary>Standardized string to programmatically identify the error.</summary>
        string Code { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorDetailsItem[] Detail { get; set; }
        /// <summary>Error model.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseError Error { get; set; }
        /// <summary>More information to debug error.</summary>
        string Innererror { get; set; }
        /// <summary>Detailed error description and debugging information.</summary>
        string Message { get; set; }
        /// <summary>Detailed error description and debugging information.</summary>
        string Target { get; set; }

    }
}