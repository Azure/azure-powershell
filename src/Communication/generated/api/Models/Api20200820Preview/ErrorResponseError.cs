namespace Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Extensions;

    /// <summary>The error</summary>
    public partial class ErrorResponseError :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponseError,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IErrorResponseErrorInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Error message indicating why the operation failed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Creates an new <see cref="ErrorResponseError" /> instance.</summary>
        public ErrorResponseError()
        {

        }
    }
    /// The error
    public partial interface IErrorResponseError :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IJsonSerializable
    {
        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>Error message indicating why the operation failed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error message indicating why the operation failed.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }

    }
    /// The error
    internal partial interface IErrorResponseErrorInternal

    {
        /// <summary>Error code.</summary>
        string Code { get; set; }
        /// <summary>Error message indicating why the operation failed.</summary>
        string Message { get; set; }

    }
}