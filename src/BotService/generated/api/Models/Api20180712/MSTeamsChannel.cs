namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Microsoft Teams channel definition</summary>
    public partial class MSTeamsChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IMSTeamsChannel,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IMSTeamsChannelInternal,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel __channel = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.Channel();

        /// <summary>Webhook for Microsoft Teams channel calls</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string CallingWebHook { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IMSTeamsChannelPropertiesInternal)Property).CallingWebHook; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IMSTeamsChannelPropertiesInternal)Property).CallingWebHook = value ?? null; }

        /// <summary>Enable calling for Microsoft Teams channel</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? EnableCalling { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IMSTeamsChannelPropertiesInternal)Property).EnableCalling; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IMSTeamsChannelPropertiesInternal)Property).EnableCalling = value ?? default(bool); }

        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? IsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IMSTeamsChannelPropertiesInternal)Property).IsEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IMSTeamsChannelPropertiesInternal)Property).IsEnabled = value ?? default(bool); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IMSTeamsChannelProperties Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IMSTeamsChannelInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.MSTeamsChannelProperties()); set { {_property = value;} } }

        /// <summary>The channel name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name = value ; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IMSTeamsChannelProperties _property;

        /// <summary>The set of properties specific to Microsoft Teams channel resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IMSTeamsChannelProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.MSTeamsChannelProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="MSTeamsChannel" /> instance.</summary>
        public MSTeamsChannel()
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
    /// Microsoft Teams channel definition
    public partial interface IMSTeamsChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel
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
        Required = false,
        ReadOnly = false,
        Description = @"Whether this channel is enabled for the bot",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsEnabled { get; set; }

    }
    /// Microsoft Teams channel definition
    internal partial interface IMSTeamsChannelInternal :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal
    {
        /// <summary>Webhook for Microsoft Teams channel calls</summary>
        string CallingWebHook { get; set; }
        /// <summary>Enable calling for Microsoft Teams channel</summary>
        bool? EnableCalling { get; set; }
        /// <summary>Whether this channel is enabled for the bot</summary>
        bool? IsEnabled { get; set; }
        /// <summary>The set of properties specific to Microsoft Teams channel resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IMSTeamsChannelProperties Property { get; set; }

    }
}