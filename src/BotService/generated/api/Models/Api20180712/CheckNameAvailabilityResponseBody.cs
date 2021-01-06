namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>
    /// The response body returned for a request to Bot Service Management to check availability of a bot name.
    /// </summary>
    public partial class CheckNameAvailabilityResponseBody :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ICheckNameAvailabilityResponseBody,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ICheckNameAvailabilityResponseBodyInternal
    {

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>
        /// additional message from the bot management api showing why a bot name is not available
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="Valid" /> property.</summary>
        private bool? _valid;

        /// <summary>indicates if the bot name is valid.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool? Valid { get => this._valid; set => this._valid = value; }

        /// <summary>Creates an new <see cref="CheckNameAvailabilityResponseBody" /> instance.</summary>
        public CheckNameAvailabilityResponseBody()
        {

        }
    }
    /// The response body returned for a request to Bot Service Management to check availability of a bot name.
    public partial interface ICheckNameAvailabilityResponseBody :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>
        /// additional message from the bot management api showing why a bot name is not available
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"additional message from the bot management api showing why a bot name is not available",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>indicates if the bot name is valid.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"indicates if the bot name is valid.",
        SerializedName = @"valid",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Valid { get; set; }

    }
    /// The response body returned for a request to Bot Service Management to check availability of a bot name.
    internal partial interface ICheckNameAvailabilityResponseBodyInternal

    {
        /// <summary>
        /// additional message from the bot management api showing why a bot name is not available
        /// </summary>
        string Message { get; set; }
        /// <summary>indicates if the bot name is valid.</summary>
        bool? Valid { get; set; }

    }
}