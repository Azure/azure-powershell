namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Error model.</summary>
    public partial class DefaultErrorResponseError :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseError,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>Standardized string to programmatically identify the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Code { get => this._code; }

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorDetailsItem[] _detail;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorDetailsItem[] Detail { get => this._detail; set => this._detail = value; }

        /// <summary>Backing field for <see cref="Innererror" /> property.</summary>
        private string _innererror;

        /// <summary>More information to debug error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Innererror { get => this._innererror; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Detailed error description and debugging information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Message { get => this._message; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal.Code { get => this._code; set { {_code = value;} } }

        /// <summary>Internal Acessors for Innererror</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal.Innererror { get => this._innererror; set { {_innererror = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal.Message { get => this._message; set { {_message = value;} } }

        /// <summary>Internal Acessors for Target</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorInternal.Target { get => this._target; set { {_target = value;} } }

        /// <summary>Backing field for <see cref="Target" /> property.</summary>
        private string _target;

        /// <summary>Detailed error description and debugging information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Target { get => this._target; }

        /// <summary>Creates an new <see cref="DefaultErrorResponseError" /> instance.</summary>
        public DefaultErrorResponseError()
        {

        }
    }
    /// Error model.
    public partial interface IDefaultErrorResponseError :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Standardized string to programmatically identify the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Standardized string to programmatically identify the error.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorDetailsItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorDetailsItem[] Detail { get; set; }
        /// <summary>More information to debug error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"More information to debug error.",
        SerializedName = @"innererror",
        PossibleTypes = new [] { typeof(string) })]
        string Innererror { get;  }
        /// <summary>Detailed error description and debugging information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Detailed error description and debugging information.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>Detailed error description and debugging information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Detailed error description and debugging information.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get;  }

    }
    /// Error model.
    internal partial interface IDefaultErrorResponseErrorInternal

    {
        /// <summary>Standardized string to programmatically identify the error.</summary>
        string Code { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDefaultErrorResponseErrorDetailsItem[] Detail { get; set; }
        /// <summary>More information to debug error.</summary>
        string Innererror { get; set; }
        /// <summary>Detailed error description and debugging information.</summary>
        string Message { get; set; }
        /// <summary>Detailed error description and debugging information.</summary>
        string Target { get; set; }

    }
}