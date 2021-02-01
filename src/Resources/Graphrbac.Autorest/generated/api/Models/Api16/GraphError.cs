namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Active Directory error information.</summary>
    public partial class GraphError :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGraphError,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGraphErrorInternal
    {

        /// <summary>Error message value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inlined)]
        public string MessageValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOdataErrorInternal)OdataError).MessageValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOdataErrorInternal)OdataError).MessageValue = value; }

        /// <summary>Internal Acessors for OdataError</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOdataError Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGraphErrorInternal.OdataError { get => (this._odataError = this._odataError ?? new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OdataError()); set { {_odataError = value;} } }

        /// <summary>Internal Acessors for OdataErrorMessage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IErrorMessage Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGraphErrorInternal.OdataErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOdataErrorInternal)OdataError).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOdataErrorInternal)OdataError).Message = value; }

        /// <summary>Backing field for <see cref="OdataError" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOdataError _odataError;

        /// <summary>A Graph API error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOdataError OdataError { get => (this._odataError = this._odataError ?? new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OdataError()); set => this._odataError = value; }

        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inlined)]
        public string OdataErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOdataErrorInternal)OdataError).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOdataErrorInternal)OdataError).Code = value; }

        /// <summary>Creates an new <see cref="GraphError" /> instance.</summary>
        public GraphError()
        {

        }
    }
    /// Active Directory error information.
    public partial interface IGraphError :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>Error message value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error message value.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string MessageValue { get; set; }
        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string OdataErrorCode { get; set; }

    }
    /// Active Directory error information.
    internal partial interface IGraphErrorInternal

    {
        /// <summary>Error message value.</summary>
        string MessageValue { get; set; }
        /// <summary>A Graph API error.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOdataError OdataError { get; set; }
        /// <summary>Error code.</summary>
        string OdataErrorCode { get; set; }
        /// <summary>Error Message.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IErrorMessage OdataErrorMessage { get; set; }

    }
}