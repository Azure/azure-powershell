namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>
    /// Common error response for all Azure Resource Manager APIs to return error details for failed operations. (This also follows
    /// the OData error response format.)
    /// </summary>
    public partial class ErrorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal
    {

        /// <summary>Backing field for <see cref="AdditionalInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorAdditionalInfo[] _additionalInfo;

        /// <summary>The error additional info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorAdditionalInfo[] AdditionalInfo { get => this._additionalInfo; }

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>The error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string Code { get => this._code; }

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse[] _detail;

        /// <summary>The error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse[] Detail { get => this._detail; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string Message { get => this._message; }

        /// <summary>Internal Acessors for AdditionalInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorAdditionalInfo[] Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal.AdditionalInfo { get => this._additionalInfo; set { {_additionalInfo = value;} } }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal.Code { get => this._code; set { {_code = value;} } }

        /// <summary>Internal Acessors for Detail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse[] Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal.Detail { get => this._detail; set { {_detail = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal.Message { get => this._message; set { {_message = value;} } }

        /// <summary>Internal Acessors for Target</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponseInternal.Target { get => this._target; set { {_target = value;} } }

        /// <summary>Backing field for <see cref="Target" /> property.</summary>
        private string _target;

        /// <summary>The error target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string Target { get => this._target; }

        /// <summary>Creates an new <see cref="ErrorResponse" /> instance.</summary>
        public ErrorResponse()
        {

        }
    }
    /// Common error response for all Azure Resource Manager APIs to return error details for failed operations. (This also follows
    /// the OData error response format.)
    public partial interface IErrorResponse :
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
    /// Common error response for all Azure Resource Manager APIs to return error details for failed operations. (This also follows
    /// the OData error response format.)
    internal partial interface IErrorResponseInternal

    {
        /// <summary>The error additional info.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorAdditionalInfo[] AdditionalInfo { get; set; }
        /// <summary>The error code.</summary>
        string Code { get; set; }
        /// <summary>The error details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api10.IErrorResponse[] Detail { get; set; }
        /// <summary>The error message.</summary>
        string Message { get; set; }
        /// <summary>The error target.</summary>
        string Target { get; set; }

    }
}