namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The parameters to provide for the Microsoft Teams channel.</summary>
    public partial class SkypeChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelProperties,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CallingWebHook" /> property.</summary>
        private string _callingWebHook;

        /// <summary>Calling web hook for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string CallingWebHook { get => this._callingWebHook; set => this._callingWebHook = value; }

        /// <summary>Backing field for <see cref="EnableCalling" /> property.</summary>
        private bool? _enableCalling;

        /// <summary>Enable calling for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool? EnableCalling { get => this._enableCalling; set => this._enableCalling = value; }

        /// <summary>Backing field for <see cref="EnableGroup" /> property.</summary>
        private bool? _enableGroup;

        /// <summary>Enable groups for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool? EnableGroup { get => this._enableGroup; set => this._enableGroup = value; }

        /// <summary>Backing field for <see cref="EnableMediaCard" /> property.</summary>
        private bool? _enableMediaCard;

        /// <summary>Enable media cards for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool? EnableMediaCard { get => this._enableMediaCard; set => this._enableMediaCard = value; }

        /// <summary>Backing field for <see cref="EnableMessaging" /> property.</summary>
        private bool? _enableMessaging;

        /// <summary>Enable messaging for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool? EnableMessaging { get => this._enableMessaging; set => this._enableMessaging = value; }

        /// <summary>Backing field for <see cref="EnableScreenSharing" /> property.</summary>
        private bool? _enableScreenSharing;

        /// <summary>Enable screen sharing for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool? EnableScreenSharing { get => this._enableScreenSharing; set => this._enableScreenSharing = value; }

        /// <summary>Backing field for <see cref="EnableVideo" /> property.</summary>
        private bool? _enableVideo;

        /// <summary>Enable video for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool? EnableVideo { get => this._enableVideo; set => this._enableVideo = value; }

        /// <summary>Backing field for <see cref="GroupsMode" /> property.</summary>
        private string _groupsMode;

        /// <summary>Group mode for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string GroupsMode { get => this._groupsMode; set => this._groupsMode = value; }

        /// <summary>Backing field for <see cref="IsEnabled" /> property.</summary>
        private bool _isEnabled;

        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool IsEnabled { get => this._isEnabled; set => this._isEnabled = value; }

        /// <summary>Creates an new <see cref="SkypeChannelProperties" /> instance.</summary>
        public SkypeChannelProperties()
        {

        }
    }
    /// The parameters to provide for the Microsoft Teams channel.
    public partial interface ISkypeChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>Calling web hook for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Calling web hook for Skype channel",
        SerializedName = @"callingWebHook",
        PossibleTypes = new [] { typeof(string) })]
        string CallingWebHook { get; set; }
        /// <summary>Enable calling for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable calling for Skype channel",
        SerializedName = @"enableCalling",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableCalling { get; set; }
        /// <summary>Enable groups for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable groups for Skype channel",
        SerializedName = @"enableGroups",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableGroup { get; set; }
        /// <summary>Enable media cards for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable media cards for Skype channel",
        SerializedName = @"enableMediaCards",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableMediaCard { get; set; }
        /// <summary>Enable messaging for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable messaging for Skype channel",
        SerializedName = @"enableMessaging",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableMessaging { get; set; }
        /// <summary>Enable screen sharing for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable screen sharing for Skype channel",
        SerializedName = @"enableScreenSharing",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableScreenSharing { get; set; }
        /// <summary>Enable video for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable video for Skype channel",
        SerializedName = @"enableVideo",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableVideo { get; set; }
        /// <summary>Group mode for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Group mode for Skype channel",
        SerializedName = @"groupsMode",
        PossibleTypes = new [] { typeof(string) })]
        string GroupsMode { get; set; }
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
    internal partial interface ISkypeChannelPropertiesInternal

    {
        /// <summary>Calling web hook for Skype channel</summary>
        string CallingWebHook { get; set; }
        /// <summary>Enable calling for Skype channel</summary>
        bool? EnableCalling { get; set; }
        /// <summary>Enable groups for Skype channel</summary>
        bool? EnableGroup { get; set; }
        /// <summary>Enable media cards for Skype channel</summary>
        bool? EnableMediaCard { get; set; }
        /// <summary>Enable messaging for Skype channel</summary>
        bool? EnableMessaging { get; set; }
        /// <summary>Enable screen sharing for Skype channel</summary>
        bool? EnableScreenSharing { get; set; }
        /// <summary>Enable video for Skype channel</summary>
        bool? EnableVideo { get; set; }
        /// <summary>Group mode for Skype channel</summary>
        string GroupsMode { get; set; }
        /// <summary>Whether this channel is enabled for the bot</summary>
        bool IsEnabled { get; set; }

    }
}