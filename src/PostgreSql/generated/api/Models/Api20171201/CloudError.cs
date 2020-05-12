namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>An error response from the Batch service.</summary>
    public partial class CloudError :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ICloudError,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ICloudErrorInternal
    {

        /// <summary>The error additional info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorAdditionalInfo[] AdditionalInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponseInternal)Error).AdditionalInfo; }

        /// <summary>The error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponseInternal)Error).Code; }

        /// <summary>The error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponse[] Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponseInternal)Error).Detail; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponse _error;

        /// <summary>The resource management error response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponse Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.ErrorResponse()); set => this._error = value; }

        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponseInternal)Error).Message; }

        /// <summary>Internal Acessors for AdditionalInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorAdditionalInfo[] Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ICloudErrorInternal.AdditionalInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponseInternal)Error).AdditionalInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponseInternal)Error).AdditionalInfo = value; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ICloudErrorInternal.Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponseInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponseInternal)Error).Code = value; }

        /// <summary>Internal Acessors for Detail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponse[] Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ICloudErrorInternal.Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponseInternal)Error).Detail; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponseInternal)Error).Detail = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponse Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ICloudErrorInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.ErrorResponse()); set { {_error = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ICloudErrorInternal.Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponseInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponseInternal)Error).Message = value; }

        /// <summary>Internal Acessors for Target</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ICloudErrorInternal.Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponseInternal)Error).Target; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponseInternal)Error).Target = value; }

        /// <summary>The error target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Inlined)]
        public string Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponseInternal)Error).Target; }

        /// <summary>Creates an new <see cref="CloudError" /> instance.</summary>
        public CloudError()
        {

        }
    }
    /// An error response from the Batch service.
    public partial interface ICloudError :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable
    {
        /// <summary>The error additional info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error additional info.",
        SerializedName = @"additionalInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorAdditionalInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorAdditionalInfo[] AdditionalInfo { get;  }
        /// <summary>The error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>The error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error details.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponse) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponse[] Detail { get;  }
        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>The error target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error target.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get;  }

    }
    /// An error response from the Batch service.
    internal partial interface ICloudErrorInternal

    {
        /// <summary>The error additional info.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorAdditionalInfo[] AdditionalInfo { get; set; }
        /// <summary>The error code.</summary>
        string Code { get; set; }
        /// <summary>The error details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponse[] Detail { get; set; }
        /// <summary>The resource management error response.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.IErrorResponse Error { get; set; }
        /// <summary>The error message.</summary>
        string Message { get; set; }
        /// <summary>The error target.</summary>
        string Target { get; set; }

    }
}