namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Active Directory OData error information.</summary>
    public partial class OdataError :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOdataError,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOdataErrorInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Code { get => this._code; set => this._code = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IErrorMessage _message;

        /// <summary>Error Message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IErrorMessage Message { get => (this._message = this._message ?? new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ErrorMessage()); set => this._message = value; }

        /// <summary>Error message value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inlined)]
        public string MessageValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IErrorMessageInternal)Message).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IErrorMessageInternal)Message).Value = value; }

        /// <summary>Internal Acessors for Message</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IErrorMessage Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOdataErrorInternal.Message { get => (this._message = this._message ?? new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ErrorMessage()); set { {_message = value;} } }

        /// <summary>Creates an new <see cref="OdataError" /> instance.</summary>
        public OdataError()
        {

        }
    }
    /// Active Directory OData error information.
    public partial interface IOdataError :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>Error message value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error message value.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string MessageValue { get; set; }

    }
    /// Active Directory OData error information.
    internal partial interface IOdataErrorInternal

    {
        /// <summary>Error code.</summary>
        string Code { get; set; }
        /// <summary>Error Message.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IErrorMessage Message { get; set; }
        /// <summary>Error message value.</summary>
        string MessageValue { get; set; }

    }
}