namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Skype channel definition</summary>
    public partial class SkypeChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannel,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelInternal,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel __channel = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.Channel();

        /// <summary>Calling web hook for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string CallingWebHook { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).CallingWebHook; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).CallingWebHook = value ?? null; }

        /// <summary>Enable calling for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? EnableCalling { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).EnableCalling; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).EnableCalling = value ?? default(bool); }

        /// <summary>Enable groups for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? EnableGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).EnableGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).EnableGroup = value ?? default(bool); }

        /// <summary>Enable media cards for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? EnableMediaCard { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).EnableMediaCard; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).EnableMediaCard = value ?? default(bool); }

        /// <summary>Enable messaging for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? EnableMessaging { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).EnableMessaging; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).EnableMessaging = value ?? default(bool); }

        /// <summary>Enable screen sharing for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? EnableScreenSharing { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).EnableScreenSharing; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).EnableScreenSharing = value ?? default(bool); }

        /// <summary>Enable video for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? EnableVideo { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).EnableVideo; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).EnableVideo = value ?? default(bool); }

        /// <summary>Group mode for Skype channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string GroupsMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).GroupsMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).GroupsMode = value ?? null; }

        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? IsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).IsEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)Property).IsEnabled = value ?? default(bool); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelProperties Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.SkypeChannelProperties()); set { {_property = value;} } }

        /// <summary>The channel name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name = value ; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelProperties _property;

        /// <summary>The set of properties specific to Skype channel resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.SkypeChannelProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="SkypeChannel" /> instance.</summary>
        public SkypeChannel()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__channel), __channel);
            await eventListener.AssertObjectIsValid(nameof(__channel), __channel);
        }
    }
    /// Skype channel definition
    public partial interface ISkypeChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel
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
        Required = false,
        ReadOnly = false,
        Description = @"Whether this channel is enabled for the bot",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsEnabled { get; set; }

    }
    /// Skype channel definition
    internal partial interface ISkypeChannelInternal :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal
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
        bool? IsEnabled { get; set; }
        /// <summary>The set of properties specific to Skype channel resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelProperties Property { get; set; }

    }
}