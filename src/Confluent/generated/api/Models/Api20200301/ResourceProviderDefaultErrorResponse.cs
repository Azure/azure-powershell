namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Extensions;

    /// <summary>Default error response for resource provider</summary>
    public partial class ResourceProviderDefaultErrorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IResourceProviderDefaultErrorResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IResourceProviderDefaultErrorResponseInternal
    {

        /// <summary>Error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)Error).Code; }

        /// <summary>Error detail</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody[] Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)Error).Detail; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody _error;

        /// <summary>Response body of Error</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.ErrorResponseBody()); }

        /// <summary>Error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)Error).Message; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IResourceProviderDefaultErrorResponseInternal.Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)Error).Code = value; }

        /// <summary>Internal Acessors for Detail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody[] Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IResourceProviderDefaultErrorResponseInternal.Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)Error).Detail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)Error).Detail = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IResourceProviderDefaultErrorResponseInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.ErrorResponseBody()); set { {_error = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IResourceProviderDefaultErrorResponseInternal.Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)Error).Message = value; }

        /// <summary>Internal Acessors for Target</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IResourceProviderDefaultErrorResponseInternal.Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)Error).Target; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)Error).Target = value; }

        /// <summary>Error target</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBodyInternal)Error).Target; }

        /// <summary>Creates an new <see cref="ResourceProviderDefaultErrorResponse" /> instance.</summary>
        public ResourceProviderDefaultErrorResponse()
        {

        }
    }
    /// Default error response for resource provider
    public partial interface IResourceProviderDefaultErrorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IJsonSerializable
    {
        /// <summary>Error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error code",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>Error detail</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error detail",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody) })]
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody[] Detail { get;  }
        /// <summary>Error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error message",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>Error target</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error target",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get;  }

    }
    /// Default error response for resource provider
    internal partial interface IResourceProviderDefaultErrorResponseInternal

    {
        /// <summary>Error code</summary>
        string Code { get; set; }
        /// <summary>Error detail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody[] Detail { get; set; }
        /// <summary>Response body of Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IErrorResponseBody Error { get; set; }
        /// <summary>Error message</summary>
        string Message { get; set; }
        /// <summary>Error target</summary>
        string Target { get; set; }

    }
}