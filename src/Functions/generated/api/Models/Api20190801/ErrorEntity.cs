namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Body of the error response returned from the API.</summary>
    public partial class ErrorEntity :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntityInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>Basic error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="ExtendedCode" /> property.</summary>
        private string _extendedCode;

        /// <summary>Type of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ExtendedCode { get => this._extendedCode; set => this._extendedCode = value; }

        /// <summary>Backing field for <see cref="InnerError" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity[] _innerError;

        /// <summary>Inner errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity[] InnerError { get => this._innerError; set => this._innerError = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Any details of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="MessageTemplate" /> property.</summary>
        private string _messageTemplate;

        /// <summary>Message template.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string MessageTemplate { get => this._messageTemplate; set => this._messageTemplate = value; }

        /// <summary>Backing field for <see cref="Parameter" /> property.</summary>
        private string[] _parameter;

        /// <summary>Parameters for the template.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] Parameter { get => this._parameter; set => this._parameter = value; }

        /// <summary>Creates an new <see cref="ErrorEntity" /> instance.</summary>
        public ErrorEntity()
        {

        }
    }
    /// Body of the error response returned from the API.
    public partial interface IErrorEntity :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Basic error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Basic error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>Type of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of error.",
        SerializedName = @"extendedCode",
        PossibleTypes = new [] { typeof(string) })]
        string ExtendedCode { get; set; }
        /// <summary>Inner errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Inner errors.",
        SerializedName = @"innerErrors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity[] InnerError { get; set; }
        /// <summary>Any details of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Any details of the error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Message template.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Message template.",
        SerializedName = @"messageTemplate",
        PossibleTypes = new [] { typeof(string) })]
        string MessageTemplate { get; set; }
        /// <summary>Parameters for the template.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Parameters for the template.",
        SerializedName = @"parameters",
        PossibleTypes = new [] { typeof(string) })]
        string[] Parameter { get; set; }

    }
    /// Body of the error response returned from the API.
    internal partial interface IErrorEntityInternal

    {
        /// <summary>Basic error code.</summary>
        string Code { get; set; }
        /// <summary>Type of error.</summary>
        string ExtendedCode { get; set; }
        /// <summary>Inner errors.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IErrorEntity[] InnerError { get; set; }
        /// <summary>Any details of the error.</summary>
        string Message { get; set; }
        /// <summary>Message template.</summary>
        string MessageTemplate { get; set; }
        /// <summary>Parameters for the template.</summary>
        string[] Parameter { get; set; }

    }
}