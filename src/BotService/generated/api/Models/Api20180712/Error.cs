namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Bot Service error object.</summary>
    public partial class Error :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IError,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IErrorInternal
    {

        /// <summary>error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IErrorBodyInternal)Error1).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IErrorBodyInternal)Error1).Code = value ?? null; }

        /// <summary>Backing field for <see cref="Error1" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IErrorBody _error1;

        /// <summary>The error body.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IErrorBody Error1 { get => (this._error1 = this._error1 ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ErrorBody()); set => this._error1 = value; }

        /// <summary>error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IErrorBodyInternal)Error1).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IErrorBodyInternal)Error1).Message = value ?? null; }

        /// <summary>Internal Acessors for Error1</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IErrorBody Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IErrorInternal.Error1 { get => (this._error1 = this._error1 ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ErrorBody()); set { {_error1 = value;} } }

        /// <summary>Creates an new <see cref="Error" /> instance.</summary>
        public Error()
        {

        }
    }
    /// Bot Service error object.
    public partial interface IError :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"error code",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"error message",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }

    }
    /// Bot Service error object.
    internal partial interface IErrorInternal

    {
        /// <summary>error code</summary>
        string Code { get; set; }
        /// <summary>The error body.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IErrorBody Error1 { get; set; }
        /// <summary>error message</summary>
        string Message { get; set; }

    }
}