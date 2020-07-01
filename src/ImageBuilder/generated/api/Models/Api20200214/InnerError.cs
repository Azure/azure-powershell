namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>Inner error details.</summary>
    public partial class InnerError :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IInnerError,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IInnerErrorInternal
    {

        /// <summary>Backing field for <see cref="ErrorDetail" /> property.</summary>
        private string _errorDetail;

        /// <summary>The internal error message or exception dump.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string ErrorDetail { get => this._errorDetail; set => this._errorDetail = value; }

        /// <summary>Backing field for <see cref="ExceptionType" /> property.</summary>
        private string _exceptionType;

        /// <summary>The exception type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string ExceptionType { get => this._exceptionType; set => this._exceptionType = value; }

        /// <summary>Creates an new <see cref="InnerError" /> instance.</summary>
        public InnerError()
        {

        }
    }
    /// Inner error details.
    public partial interface IInnerError :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable
    {
        /// <summary>The internal error message or exception dump.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The internal error message or exception dump.",
        SerializedName = @"errorDetail",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorDetail { get; set; }
        /// <summary>The exception type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The exception type.",
        SerializedName = @"exceptionType",
        PossibleTypes = new [] { typeof(string) })]
        string ExceptionType { get; set; }

    }
    /// Inner error details.
    public partial interface IInnerErrorInternal

    {
        /// <summary>The internal error message or exception dump.</summary>
        string ErrorDetail { get; set; }
        /// <summary>The exception type.</summary>
        string ExceptionType { get; set; }

    }
}