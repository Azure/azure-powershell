namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The parameters to provide for the Microsoft Teams channel.</summary>
    public partial class MSTeamsChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IMSTeamsChannelProperties,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IMSTeamsChannelPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CallingWebHook" /> property.</summary>
        private string _callingWebHook;

        /// <summary>Webhook for Microsoft Teams channel calls</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string CallingWebHook { get => this._callingWebHook; set => this._callingWebHook = value; }

        /// <summary>Backing field for <see cref="EnableCalling" /> property.</summary>
        private bool? _enableCalling;

        /// <summary>Enable calling for Microsoft Teams channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool? EnableCalling { get => this._enableCalling; set => this._enableCalling = value; }

        /// <summary>Backing field for <see cref="IsEnabled" /> property.</summary>
        private bool _isEnabled;

        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool IsEnabled { get => this._isEnabled; set => this._isEnabled = value; }

        /// <summary>Creates an new <see cref="MSTeamsChannelProperties" /> instance.</summary>
        public MSTeamsChannelProperties()
        {

        }
    }
    /// The parameters to provide for the Microsoft Teams channel.
    public partial interface IMSTeamsChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>Webhook for Microsoft Teams channel calls</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Webhook for Microsoft Teams channel calls",
        SerializedName = @"callingWebHook",
        PossibleTypes = new [] { typeof(string) })]
        string CallingWebHook { get; set; }
        /// <summary>Enable calling for Microsoft Teams channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable calling for Microsoft Teams channel",
        SerializedName = @"enableCalling",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableCalling { get; set; }
        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Whether this channel is enabled for the bot",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool IsEnabled { get; set; }

    }
    /// The parameters to provide for the Microsoft Teams channel.
    internal partial interface IMSTeamsChannelPropertiesInternal

    {
        /// <summary>Webhook for Microsoft Teams channel calls</summary>
        string CallingWebHook { get; set; }
        /// <summary>Enable calling for Microsoft Teams channel</summary>
        bool? EnableCalling { get; set; }
        /// <summary>Whether this channel is enabled for the bot</summary>
        bool IsEnabled { get; set; }

    }
}