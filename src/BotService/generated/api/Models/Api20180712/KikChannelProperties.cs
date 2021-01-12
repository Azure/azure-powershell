namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The parameters to provide for the Kik channel.</summary>
    public partial class KikChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IKikChannelProperties,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IKikChannelPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ApiKey" /> property.</summary>
        private string _apiKey;

        /// <summary>
        /// Kik API key. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string ApiKey { get => this._apiKey; set => this._apiKey = value; }

        /// <summary>Backing field for <see cref="IsEnabled" /> property.</summary>
        private bool _isEnabled;

        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool IsEnabled { get => this._isEnabled; set => this._isEnabled = value; }

        /// <summary>Backing field for <see cref="IsValidated" /> property.</summary>
        private bool? _isValidated;

        /// <summary>Whether this channel is validated for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool? IsValidated { get => this._isValidated; set => this._isValidated = value; }

        /// <summary>Backing field for <see cref="UserName" /> property.</summary>
        private string _userName;

        /// <summary>The Kik user name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string UserName { get => this._userName; set => this._userName = value; }

        /// <summary>Creates an new <see cref="KikChannelProperties" /> instance.</summary>
        public KikChannelProperties()
        {

        }
    }
    /// The parameters to provide for the Kik channel.
    public partial interface IKikChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Kik API key. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Kik API key. Value only returned through POST to the action Channel List API, otherwise empty.",
        SerializedName = @"apiKey",
        PossibleTypes = new [] { typeof(string) })]
        string ApiKey { get; set; }
        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Whether this channel is enabled for the bot",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool IsEnabled { get; set; }
        /// <summary>Whether this channel is validated for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether this channel is validated for the bot",
        SerializedName = @"isValidated",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsValidated { get; set; }
        /// <summary>The Kik user name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Kik user name",
        SerializedName = @"userName",
        PossibleTypes = new [] { typeof(string) })]
        string UserName { get; set; }

    }
    /// The parameters to provide for the Kik channel.
    internal partial interface IKikChannelPropertiesInternal

    {
        /// <summary>
        /// Kik API key. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        string ApiKey { get; set; }
        /// <summary>Whether this channel is enabled for the bot</summary>
        bool IsEnabled { get; set; }
        /// <summary>Whether this channel is validated for the bot</summary>
        bool? IsValidated { get; set; }
        /// <summary>The Kik user name</summary>
        string UserName { get; set; }

    }
}