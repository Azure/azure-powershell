namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>An error response from the Compute service.</summary>
    public partial class CloudError :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudError,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudErrorInternal
    {

        /// <summary>The error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorInternal)Error).Code = value; }

        /// <summary>The Api error details</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorBase[] Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorInternal)Error).Detail; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorInternal)Error).Detail = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiError _error;

        /// <summary>Api error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiError Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ApiError()); set => this._error = value; }

        /// <summary>The internal error message or exception dump.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string InnererrorErrordetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorInternal)Error).InnererrorErrordetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorInternal)Error).InnererrorErrordetail = value; }

        /// <summary>The exception type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string InnererrorExceptiontype { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorInternal)Error).InnererrorExceptiontype; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorInternal)Error).InnererrorExceptiontype = value; }

        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorInternal)Error).Message = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiError Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudErrorInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ApiError()); set { {_error = value;} } }

        /// <summary>Internal Acessors for Innererror</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IInnerError Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudErrorInternal.Innererror { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorInternal)Error).Innererror; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorInternal)Error).Innererror = value; }

        /// <summary>The target of the particular error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorInternal)Error).Target; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorInternal)Error).Target = value; }

        /// <summary>Creates an new <see cref="CloudError" /> instance.</summary>
        public CloudError()
        {

        }
    }
    /// An error response from the Compute service.
    public partial interface ICloudError :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>The error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>The Api error details</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Api error details",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorBase) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorBase[] Detail { get; set; }
        /// <summary>The internal error message or exception dump.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The internal error message or exception dump.",
        SerializedName = @"errordetail",
        PossibleTypes = new [] { typeof(string) })]
        string InnererrorErrordetail { get; set; }
        /// <summary>The exception type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The exception type.",
        SerializedName = @"exceptiontype",
        PossibleTypes = new [] { typeof(string) })]
        string InnererrorExceptiontype { get; set; }
        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>The target of the particular error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The target of the particular error.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get; set; }

    }
    /// An error response from the Compute service.
    internal partial interface ICloudErrorInternal

    {
        /// <summary>The error code.</summary>
        string Code { get; set; }
        /// <summary>The Api error details</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiErrorBase[] Detail { get; set; }
        /// <summary>Api error.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IApiError Error { get; set; }
        /// <summary>The Api inner error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IInnerError Innererror { get; set; }
        /// <summary>The internal error message or exception dump.</summary>
        string InnererrorErrordetail { get; set; }
        /// <summary>The exception type.</summary>
        string InnererrorExceptiontype { get; set; }
        /// <summary>The error message.</summary>
        string Message { get; set; }
        /// <summary>The target of the particular error.</summary>
        string Target { get; set; }

    }
}