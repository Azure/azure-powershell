namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>
    /// A request to Bot Service Management to check availability of an Enterprise Channel name.
    /// </summary>
    public partial class EnterpriseChannelCheckNameAvailabilityResponse :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelCheckNameAvailabilityResponse,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelCheckNameAvailabilityResponseInternal
    {

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Additional information about why a bot name is not available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="Valid" /> property.</summary>
        private bool? _valid;

        /// <summary>Indicates if the Enterprise Channel name is valid.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool? Valid { get => this._valid; set => this._valid = value; }

        /// <summary>
        /// Creates an new <see cref="EnterpriseChannelCheckNameAvailabilityResponse" /> instance.
        /// </summary>
        public EnterpriseChannelCheckNameAvailabilityResponse()
        {

        }
    }
    /// A request to Bot Service Management to check availability of an Enterprise Channel name.
    public partial interface IEnterpriseChannelCheckNameAvailabilityResponse :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>Additional information about why a bot name is not available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Additional information about why a bot name is not available.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Indicates if the Enterprise Channel name is valid.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates if the Enterprise Channel name is valid.",
        SerializedName = @"valid",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Valid { get; set; }

    }
    /// A request to Bot Service Management to check availability of an Enterprise Channel name.
    internal partial interface IEnterpriseChannelCheckNameAvailabilityResponseInternal

    {
        /// <summary>Additional information about why a bot name is not available.</summary>
        string Message { get; set; }
        /// <summary>Indicates if the Enterprise Channel name is valid.</summary>
        bool? Valid { get; set; }

    }
}