namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>
    /// Error response indicates that the service is not able to process the incoming request. The reason is provided in the error
    /// message.
    /// Some Error responses:
    /// * 429 TooManyRequests - Request is throttled. Retry after waiting for the time specified in the "x-ms-ratelimit-microsoft.consumption-retry-after"
    /// header.
    /// * 503 ServiceUnavailable - Service is temporarily unavailable. Retry after waiting for the time specified in the "Retry-After"
    /// header.
    /// </summary>
    public partial class ErrorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorResponse,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorResponseInternal
    {

        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetailsInternal)Error).Code; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetails _error;

        /// <summary>The details of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetails Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ErrorDetails()); set => this._error = value; }

        /// <summary>Error message indicating why the operation failed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetailsInternal)Error).Message; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorResponseInternal.Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetailsInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetailsInternal)Error).Code = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetails Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorResponseInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ErrorDetails()); set { {_error = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorResponseInternal.Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetailsInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetailsInternal)Error).Message = value; }

        /// <summary>Creates an new <see cref="ErrorResponse" /> instance.</summary>
        public ErrorResponse()
        {

        }
    }
    /// Error response indicates that the service is not able to process the incoming request. The reason is provided in the error
    /// message.
    /// Some Error responses:
    /// * 429 TooManyRequests - Request is throttled. Retry after waiting for the time specified in the "x-ms-ratelimit-microsoft.consumption-retry-after"
    /// header.
    /// * 503 ServiceUnavailable - Service is temporarily unavailable. Retry after waiting for the time specified in the "Retry-After"
    /// header.
    public partial interface IErrorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>Error message indicating why the operation failed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error message indicating why the operation failed.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }

    }
    /// Error response indicates that the service is not able to process the incoming request. The reason is provided in the error
    /// message.
    /// Some Error responses:
    /// * 429 TooManyRequests - Request is throttled. Retry after waiting for the time specified in the "x-ms-ratelimit-microsoft.consumption-retry-after"
    /// header.
    /// * 503 ServiceUnavailable - Service is temporarily unavailable. Retry after waiting for the time specified in the "Retry-After"
    /// header.
    public partial interface IErrorResponseInternal

    {
        /// <summary>Error code.</summary>
        string Code { get; set; }
        /// <summary>The details of the error.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetails Error { get; set; }
        /// <summary>Error message indicating why the operation failed.</summary>
        string Message { get; set; }

    }
}