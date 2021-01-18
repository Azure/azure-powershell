namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Kik channel definition</summary>
    public partial class KikChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IKikChannel,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IKikChannelInternal,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel __channel = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.Channel();

        /// <summary>
        /// Kik API key. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string ApiKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IKikChannelPropertiesInternal)Property).ApiKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IKikChannelPropertiesInternal)Property).ApiKey = value ?? null; }

        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? IsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IKikChannelPropertiesInternal)Property).IsEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IKikChannelPropertiesInternal)Property).IsEnabled = value ?? default(bool); }

        /// <summary>Whether this channel is validated for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? IsValidated { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IKikChannelPropertiesInternal)Property).IsValidated; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IKikChannelPropertiesInternal)Property).IsValidated = value ?? default(bool); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IKikChannelProperties Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IKikChannelInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.KikChannelProperties()); set { {_property = value;} } }

        /// <summary>The channel name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name = value ; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IKikChannelProperties _property;

        /// <summary>The set of properties specific to Kik channel resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IKikChannelProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.KikChannelProperties()); set => this._property = value; }

        /// <summary>The Kik user name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string UserName { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IKikChannelPropertiesInternal)Property).UserName; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IKikChannelPropertiesInternal)Property).UserName = value ?? null; }

        /// <summary>Creates an new <see cref="KikChannel" /> instance.</summary>
        public KikChannel()
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
    /// Kik channel definition
    public partial interface IKikChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel
    {
        /// <summary>
        /// Kik API key. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Kik API key. Value only returned through POST to the action Channel List API, otherwise empty.",
        SerializedName = @"apiKey",
        PossibleTypes = new [] { typeof(string) })]
        string ApiKey { get; set; }
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
        /// <summary>The Kik user name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Kik user name",
        SerializedName = @"userName",
        PossibleTypes = new [] { typeof(string) })]
        string UserName { get; set; }

    }
    /// Kik channel definition
    internal partial interface IKikChannelInternal :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal
    {
        /// <summary>
        /// Kik API key. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        string ApiKey { get; set; }
        /// <summary>Whether this channel is enabled for the bot</summary>
        bool? IsEnabled { get; set; }
        /// <summary>Whether this channel is validated for the bot</summary>
        bool? IsValidated { get; set; }
        /// <summary>The set of properties specific to Kik channel resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IKikChannelProperties Property { get; set; }
        /// <summary>The Kik user name</summary>
        string UserName { get; set; }

    }
}