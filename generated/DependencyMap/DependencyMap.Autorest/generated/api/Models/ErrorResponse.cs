// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Extensions;

    /// <summary>
    /// Common error response for all Azure Resource Manager APIs to return error details for failed operations.
    /// </summary>
    public partial class ErrorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorResponse,
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorResponseInternal
    {

        /// <summary>The error additional info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorAdditionalInfo> AdditionalInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetailInternal)Error).AdditionalInfo; }

        /// <summary>The error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetailInternal)Error).Code; }

        /// <summary>The error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetail> Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetailInternal)Error).Detail; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetail _error;

        /// <summary>The error object.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetail Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.ErrorDetail()); set => this._error = value; }

        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetailInternal)Error).Message; }

        /// <summary>Internal Acessors for AdditionalInfo</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorAdditionalInfo> Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorResponseInternal.AdditionalInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetailInternal)Error).AdditionalInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetailInternal)Error).AdditionalInfo = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorResponseInternal.Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetailInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetailInternal)Error).Code = value ?? null; }

        /// <summary>Internal Acessors for Detail</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetail> Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorResponseInternal.Detail { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetailInternal)Error).Detail; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetailInternal)Error).Detail = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetail Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorResponseInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.ErrorDetail()); set { {_error = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorResponseInternal.Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetailInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetailInternal)Error).Message = value ?? null; }

        /// <summary>Internal Acessors for Target</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorResponseInternal.Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetailInternal)Error).Target; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetailInternal)Error).Target = value ?? null; }

        /// <summary>The error target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Inlined)]
        public string Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetailInternal)Error).Target; }

        /// <summary>Creates an new <see cref="ErrorResponse" /> instance.</summary>
        public ErrorResponse()
        {

        }
    }
    /// Common error response for all Azure Resource Manager APIs to return error details for failed operations.
    public partial interface IErrorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.IJsonSerializable
    {
        /// <summary>The error additional info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The error additional info.",
        SerializedName = @"additionalInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorAdditionalInfo) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorAdditionalInfo> AdditionalInfo { get;  }
        /// <summary>The error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>The error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The error details.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetail) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetail> Detail { get;  }
        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>The error target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The error target.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get;  }

    }
    /// Common error response for all Azure Resource Manager APIs to return error details for failed operations.
    internal partial interface IErrorResponseInternal

    {
        /// <summary>The error additional info.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorAdditionalInfo> AdditionalInfo { get; set; }
        /// <summary>The error code.</summary>
        string Code { get; set; }
        /// <summary>The error details.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetail> Detail { get; set; }
        /// <summary>The error object.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IErrorDetail Error { get; set; }
        /// <summary>The error message.</summary>
        string Message { get; set; }
        /// <summary>The error target.</summary>
        string Target { get; set; }

    }
}