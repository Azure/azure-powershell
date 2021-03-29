namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>
    /// Error object used by layers that have access to localized content, and propagate that to user
    /// </summary>
    public partial class UserFacingError :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IUserFacingError,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IUserFacingErrorInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>Unique code for this error</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IUserFacingError[] _detail;

        /// <summary>Additional related Errors</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IUserFacingError[] Detail { get => this._detail; set => this._detail = value; }

        /// <summary>Backing field for <see cref="InnerError" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IInnerError _innerError;

        /// <summary>Inner Error</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IInnerError InnerError { get => (this._innerError = this._innerError ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.InnerError()); set => this._innerError = value; }

        /// <summary>Backing field for <see cref="IsRetryable" /> property.</summary>
        private bool? _isRetryable;

        /// <summary>Whether the operation will be retryable or not</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public bool? IsRetryable { get => this._isRetryable; set => this._isRetryable = value; }

        /// <summary>Backing field for <see cref="IsUserError" /> property.</summary>
        private bool? _isUserError;

        /// <summary>Whether the operation is due to a user error or service error</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public bool? IsUserError { get => this._isUserError; set => this._isUserError = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IUserFacingErrorProperties _property;

        /// <summary>Any key value pairs that can be injected inside error object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IUserFacingErrorProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.UserFacingErrorProperties()); set => this._property = value; }

        /// <summary>Backing field for <see cref="RecommendedAction" /> property.</summary>
        private string[] _recommendedAction;

        /// <summary>RecommendedAction � localized.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string[] RecommendedAction { get => this._recommendedAction; set => this._recommendedAction = value; }

        /// <summary>Backing field for <see cref="Target" /> property.</summary>
        private string _target;

        /// <summary>Target of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Target { get => this._target; set => this._target = value; }

        /// <summary>Creates an new <see cref="UserFacingError" /> instance.</summary>
        public UserFacingError()
        {

        }
    }
    /// Error object used by layers that have access to localized content, and propagate that to user
    public partial interface IUserFacingError :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Unique code for this error</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Unique code for this error",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>Additional related Errors</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Additional related Errors",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IUserFacingError) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IUserFacingError[] Detail { get; set; }
        /// <summary>Inner Error</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Inner Error",
        SerializedName = @"innerError",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IInnerError) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IInnerError InnerError { get; set; }
        /// <summary>Whether the operation will be retryable or not</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the operation will be retryable or not",
        SerializedName = @"isRetryable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsRetryable { get; set; }
        /// <summary>Whether the operation is due to a user error or service error</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the operation is due to a user error or service error",
        SerializedName = @"isUserError",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsUserError { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Any key value pairs that can be injected inside error object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Any key value pairs that can be injected inside error object",
        SerializedName = @"properties",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IUserFacingErrorProperties) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IUserFacingErrorProperties Property { get; set; }
        /// <summary>RecommendedAction � localized.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"RecommendedAction � localized.",
        SerializedName = @"recommendedAction",
        PossibleTypes = new [] { typeof(string) })]
        string[] RecommendedAction { get; set; }
        /// <summary>Target of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target of the error.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get; set; }

    }
    /// Error object used by layers that have access to localized content, and propagate that to user
    internal partial interface IUserFacingErrorInternal

    {
        /// <summary>Unique code for this error</summary>
        string Code { get; set; }
        /// <summary>Additional related Errors</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IUserFacingError[] Detail { get; set; }
        /// <summary>Inner Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IInnerError InnerError { get; set; }
        /// <summary>Whether the operation will be retryable or not</summary>
        bool? IsRetryable { get; set; }
        /// <summary>Whether the operation is due to a user error or service error</summary>
        bool? IsUserError { get; set; }

        string Message { get; set; }
        /// <summary>Any key value pairs that can be injected inside error object</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IUserFacingErrorProperties Property { get; set; }
        /// <summary>RecommendedAction � localized.</summary>
        string[] RecommendedAction { get; set; }
        /// <summary>Target of the error.</summary>
        string Target { get; set; }

    }
}