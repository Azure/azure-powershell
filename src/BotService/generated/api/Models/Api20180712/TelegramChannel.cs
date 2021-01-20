namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Telegram channel definition</summary>
    public partial class TelegramChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ITelegramChannel,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ITelegramChannelInternal,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel __channel = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.Channel();

        /// <summary>
        /// The Telegram access token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string AccessToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ITelegramChannelPropertiesInternal)Property).AccessToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ITelegramChannelPropertiesInternal)Property).AccessToken = value ?? null; }

        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? IsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ITelegramChannelPropertiesInternal)Property).IsEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ITelegramChannelPropertiesInternal)Property).IsEnabled = value ?? default(bool); }

        /// <summary>Whether this channel is validated for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? IsValidated { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ITelegramChannelPropertiesInternal)Property).IsValidated; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ITelegramChannelPropertiesInternal)Property).IsValidated = value ?? default(bool); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ITelegramChannelProperties Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ITelegramChannelInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.TelegramChannelProperties()); set { {_property = value;} } }

        /// <summary>The channel name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name = value ; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ITelegramChannelProperties _property;

        /// <summary>The set of properties specific to Telegram channel resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ITelegramChannelProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.TelegramChannelProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="TelegramChannel" /> instance.</summary>
        public TelegramChannel()
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
    /// Telegram channel definition
    public partial interface ITelegramChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel
    {
        /// <summary>
        /// The Telegram access token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Telegram access token. Value only returned through POST to the action Channel List API, otherwise empty.",
        SerializedName = @"accessToken",
        PossibleTypes = new [] { typeof(string) })]
        string AccessToken { get; set; }
        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether this channel is enabled for the bot",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsEnabled { get; set; }
        /// <summary>Whether this channel is validated for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether this channel is validated for the bot",
        SerializedName = @"isValidated",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsValidated { get; set; }

    }
    /// Telegram channel definition
    internal partial interface ITelegramChannelInternal :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal
    {
        /// <summary>
        /// The Telegram access token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        string AccessToken { get; set; }
        /// <summary>Whether this channel is enabled for the bot</summary>
        bool? IsEnabled { get; set; }
        /// <summary>Whether this channel is validated for the bot</summary>
        bool? IsValidated { get; set; }
        /// <summary>The set of properties specific to Telegram channel resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ITelegramChannelProperties Property { get; set; }

    }
}