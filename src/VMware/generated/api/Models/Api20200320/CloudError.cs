namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>API error response</summary>
    public partial class CloudError :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICloudError,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICloudErrorInternal
    {

        /// <summary>The error additional info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorAdditionalInfo[] AdditionalInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal)Error).AdditionalInfo; }

        /// <summary>The error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal)Error).Code; }

        /// <summary>The error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse[] Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal)Error).Detail; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse _error;

        /// <summary>An error returned by the API</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.ErrorResponse()); set => this._error = value; }

        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal)Error).Message; }

        /// <summary>Internal Acessors for AdditionalInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorAdditionalInfo[] Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICloudErrorInternal.AdditionalInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal)Error).AdditionalInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal)Error).AdditionalInfo = value; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICloudErrorInternal.Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal)Error).Code = value; }

        /// <summary>Internal Acessors for Detail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse[] Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICloudErrorInternal.Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal)Error).Detail; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal)Error).Detail = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICloudErrorInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.ErrorResponse()); set { {_error = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICloudErrorInternal.Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal)Error).Message = value; }

        /// <summary>Internal Acessors for Target</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICloudErrorInternal.Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal)Error).Target; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal)Error).Target = value; }

        /// <summary>The error target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public string Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal)Error).Target; }

        /// <summary>Creates an new <see cref="CloudError" /> instance.</summary>
        public CloudError()
        {

        }
    }
    /// API error response
    public partial interface ICloudError :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable
    {
        /// <summary>The error additional info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error additional info.",
        SerializedName = @"additionalInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorAdditionalInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorAdditionalInfo[] AdditionalInfo { get;  }
        /// <summary>The error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>The error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error details.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse[] Detail { get;  }
        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>The error target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error target.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get;  }

    }
    /// API error response
    internal partial interface ICloudErrorInternal

    {
        /// <summary>The error additional info.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorAdditionalInfo[] AdditionalInfo { get; set; }
        /// <summary>The error code.</summary>
        string Code { get; set; }
        /// <summary>The error details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse[] Detail { get; set; }
        /// <summary>An error returned by the API</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse Error { get; set; }
        /// <summary>The error message.</summary>
        string Message { get; set; }
        /// <summary>The error target.</summary>
        string Target { get; set; }

    }
}