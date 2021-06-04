namespace Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Extensions;

    /// <summary>The resource management error response.</summary>
    public partial class Error :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IError,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorInternal
    {

        /// <summary>The error additional info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorAdditionalInfo[] AdditionalInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponseInternal)Error1).AdditionalInfo; }

        /// <summary>The error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponseInternal)Error1).Code; }

        /// <summary>The error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponse[] Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponseInternal)Error1).Detail; }

        /// <summary>Backing field for <see cref="Error1" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponse _error1;

        /// <summary>RP error response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponse Error1 { get => (this._error1 = this._error1 ?? new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.ErrorResponse()); set => this._error1 = value; }

        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponseInternal)Error1).Message; }

        /// <summary>Internal Acessors for AdditionalInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorAdditionalInfo[] Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorInternal.AdditionalInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponseInternal)Error1).AdditionalInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponseInternal)Error1).AdditionalInfo = value; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorInternal.Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponseInternal)Error1).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponseInternal)Error1).Code = value; }

        /// <summary>Internal Acessors for Detail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponse[] Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorInternal.Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponseInternal)Error1).Detail; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponseInternal)Error1).Detail = value; }

        /// <summary>Internal Acessors for Error1</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponse Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorInternal.Error1 { get => (this._error1 = this._error1 ?? new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.ErrorResponse()); set { {_error1 = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorInternal.Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponseInternal)Error1).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponseInternal)Error1).Message = value; }

        /// <summary>Internal Acessors for Target</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorInternal.Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponseInternal)Error1).Target; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponseInternal)Error1).Target = value; }

        /// <summary>The error target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inlined)]
        public string Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponseInternal)Error1).Target; }

        /// <summary>Creates an new <see cref="Error" /> instance.</summary>
        public Error()
        {

        }
    }
    /// The resource management error response.
    public partial interface IError :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IJsonSerializable
    {
        /// <summary>The error additional info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error additional info.",
        SerializedName = @"additionalInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorAdditionalInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorAdditionalInfo[] AdditionalInfo { get;  }
        /// <summary>The error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>The error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error details.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponse) })]
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponse[] Detail { get;  }
        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>The error target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error target.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get;  }

    }
    /// The resource management error response.
    internal partial interface IErrorInternal

    {
        /// <summary>The error additional info.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorAdditionalInfo[] AdditionalInfo { get; set; }
        /// <summary>The error code.</summary>
        string Code { get; set; }
        /// <summary>The error details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponse[] Detail { get; set; }
        /// <summary>RP error response.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IErrorResponse Error1 { get; set; }
        /// <summary>The error message.</summary>
        string Message { get; set; }
        /// <summary>The error target.</summary>
        string Target { get; set; }

    }
}