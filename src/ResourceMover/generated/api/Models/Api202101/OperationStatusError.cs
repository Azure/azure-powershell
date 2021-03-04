namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Class for operation status errors.</summary>
    public partial class OperationStatusError :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationStatusError,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationStatusErrorInternal
    {

        /// <summary>Backing field for <see cref="AdditionalInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationErrorAdditionalInfo[] _additionalInfo;

        /// <summary>The additional info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationErrorAdditionalInfo[] AdditionalInfo { get => this._additionalInfo; }

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>The error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Code { get => this._code; }

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationStatusError[] _detail;

        /// <summary>The error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationStatusError[] Detail { get => this._detail; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Message { get => this._message; }

        /// <summary>Internal Acessors for AdditionalInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationErrorAdditionalInfo[] Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationStatusErrorInternal.AdditionalInfo { get => this._additionalInfo; set { {_additionalInfo = value;} } }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationStatusErrorInternal.Code { get => this._code; set { {_code = value;} } }

        /// <summary>Internal Acessors for Detail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationStatusError[] Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationStatusErrorInternal.Detail { get => this._detail; set { {_detail = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationStatusErrorInternal.Message { get => this._message; set { {_message = value;} } }

        /// <summary>Creates an new <see cref="OperationStatusError" /> instance.</summary>
        public OperationStatusError()
        {

        }
    }
    /// Class for operation status errors.
    public partial interface IOperationStatusError :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>The additional info.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The additional info.",
        SerializedName = @"additionalInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationErrorAdditionalInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationErrorAdditionalInfo[] AdditionalInfo { get;  }
        /// <summary>The error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>The error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error details.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationStatusError) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationStatusError[] Detail { get;  }
        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }

    }
    /// Class for operation status errors.
    internal partial interface IOperationStatusErrorInternal

    {
        /// <summary>The additional info.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationErrorAdditionalInfo[] AdditionalInfo { get; set; }
        /// <summary>The error code.</summary>
        string Code { get; set; }
        /// <summary>The error details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationStatusError[] Detail { get; set; }
        /// <summary>The error message.</summary>
        string Message { get; set; }

    }
}