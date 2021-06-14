namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>Detailed errors.</summary>
    public partial class DefaultErrorResponseErrorDetailsItem :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IDefaultErrorResponseErrorDetailsItem,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IDefaultErrorResponseErrorDetailsItemInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>Standardized string to programmatically identify the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string Code { get => this._code; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Detailed error description and debugging information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string Message { get => this._message; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IDefaultErrorResponseErrorDetailsItemInternal.Code { get => this._code; set { {_code = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IDefaultErrorResponseErrorDetailsItemInternal.Message { get => this._message; set { {_message = value;} } }

        /// <summary>Internal Acessors for Target</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IDefaultErrorResponseErrorDetailsItemInternal.Target { get => this._target; set { {_target = value;} } }

        /// <summary>Backing field for <see cref="Target" /> property.</summary>
        private string _target;

        /// <summary>Detailed error description and debugging information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string Target { get => this._target; }

        /// <summary>Creates an new <see cref="DefaultErrorResponseErrorDetailsItem" /> instance.</summary>
        public DefaultErrorResponseErrorDetailsItem()
        {

        }
    }
    /// Detailed errors.
    public partial interface IDefaultErrorResponseErrorDetailsItem :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
    {
        /// <summary>Standardized string to programmatically identify the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Standardized string to programmatically identify the error.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>Detailed error description and debugging information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Detailed error description and debugging information.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>Detailed error description and debugging information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Detailed error description and debugging information.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get;  }

    }
    /// Detailed errors.
    internal partial interface IDefaultErrorResponseErrorDetailsItemInternal

    {
        /// <summary>Standardized string to programmatically identify the error.</summary>
        string Code { get; set; }
        /// <summary>Detailed error description and debugging information.</summary>
        string Message { get; set; }
        /// <summary>Detailed error description and debugging information.</summary>
        string Target { get; set; }

    }
}