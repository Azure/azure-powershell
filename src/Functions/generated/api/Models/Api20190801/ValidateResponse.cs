namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Describes the result of resource validation.</summary>
    public partial class ValidateResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateResponseInternal
    {

        /// <summary>Validation error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateResponseErrorInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateResponseErrorInternal)Error).Code = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateResponseError _error;

        /// <summary>Error details for the case when validation fails.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateResponseError Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ValidateResponseError()); set => this._error = value; }

        /// <summary>Validation error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateResponseErrorInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateResponseErrorInternal)Error).Message = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateResponseError Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateResponseInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ValidateResponseError()); set { {_error = value;} } }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Result of validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Status { get => this._status; set => this._status = value; }

        /// <summary>Creates an new <see cref="ValidateResponse" /> instance.</summary>
        public ValidateResponse()
        {

        }
    }
    /// Describes the result of resource validation.
    public partial interface IValidateResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Validation error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Validation error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>Validation error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Validation error message.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Result of validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Result of validation.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get; set; }

    }
    /// Describes the result of resource validation.
    internal partial interface IValidateResponseInternal

    {
        /// <summary>Validation error code.</summary>
        string Code { get; set; }
        /// <summary>Error details for the case when validation fails.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateResponseError Error { get; set; }
        /// <summary>Validation error message.</summary>
        string Message { get; set; }
        /// <summary>Result of validation.</summary>
        string Status { get; set; }

    }
}