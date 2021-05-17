namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Api error.</summary>
    public partial class ApiError :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IApiError,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IApiErrorInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>The error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IApiErrorBase[] _detail;

        /// <summary>The Api error details</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IApiErrorBase[] Detail { get => this._detail; set => this._detail = value; }

        /// <summary>Backing field for <see cref="Innererror" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInnerError _innererror;

        /// <summary>The Api inner error</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInnerError Innererror { get => (this._innererror = this._innererror ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.InnerError()); set => this._innererror = value; }

        /// <summary>The internal error message or exception dump.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string InnererrorErrordetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInnerErrorInternal)Innererror).Errordetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInnerErrorInternal)Innererror).Errordetail = value ?? null; }

        /// <summary>The exception type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string InnererrorExceptiontype { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInnerErrorInternal)Innererror).Exceptiontype; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInnerErrorInternal)Innererror).Exceptiontype = value ?? null; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Internal Acessors for Innererror</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInnerError Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IApiErrorInternal.Innererror { get => (this._innererror = this._innererror ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.InnerError()); set { {_innererror = value;} } }

        /// <summary>Backing field for <see cref="Target" /> property.</summary>
        private string _target;

        /// <summary>The target of the particular error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Target { get => this._target; set => this._target = value; }

        /// <summary>Creates an new <see cref="ApiError" /> instance.</summary>
        public ApiError()
        {

        }
    }
    /// Api error.
    public partial interface IApiError :
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IApiErrorBase) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IApiErrorBase[] Detail { get; set; }
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
    /// Api error.
    internal partial interface IApiErrorInternal

    {
        /// <summary>The error code.</summary>
        string Code { get; set; }
        /// <summary>The Api error details</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IApiErrorBase[] Detail { get; set; }
        /// <summary>The Api inner error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInnerError Innererror { get; set; }
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