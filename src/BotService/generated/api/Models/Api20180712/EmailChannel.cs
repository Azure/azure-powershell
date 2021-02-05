namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Email channel definition</summary>
    public partial class EmailChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEmailChannel,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEmailChannelInternal,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel __channel = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.Channel();

        /// <summary>The email address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string EmailAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEmailChannelPropertiesInternal)Property).EmailAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEmailChannelPropertiesInternal)Property).EmailAddress = value ?? null; }

        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? IsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEmailChannelPropertiesInternal)Property).IsEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEmailChannelPropertiesInternal)Property).IsEnabled = value ?? default(bool); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEmailChannelProperties Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEmailChannelInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.EmailChannelProperties()); set { {_property = value;} } }

        /// <summary>The channel name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name = value ; }

        /// <summary>
        /// The password for the email address. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string Password { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEmailChannelPropertiesInternal)Property).Password; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEmailChannelPropertiesInternal)Property).Password = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEmailChannelProperties _property;

        /// <summary>The set of properties specific to email channel resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEmailChannelProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.EmailChannelProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="EmailChannel" /> instance.</summary>
        public EmailChannel()
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
    /// Email channel definition
    public partial interface IEmailChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel
    {
        /// <summary>The email address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The email address",
        SerializedName = @"emailAddress",
        PossibleTypes = new [] { typeof(string) })]
        string EmailAddress { get; set; }
        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether this channel is enabled for the bot",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsEnabled { get; set; }
        /// <summary>
        /// The password for the email address. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The password for the email address. Value only returned through POST to the action Channel List API, otherwise empty.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(string) })]
        string Password { get; set; }

    }
    /// Email channel definition
    internal partial interface IEmailChannelInternal :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal
    {
        /// <summary>The email address</summary>
        string EmailAddress { get; set; }
        /// <summary>Whether this channel is enabled for the bot</summary>
        bool? IsEnabled { get; set; }
        /// <summary>
        /// The password for the email address. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        string Password { get; set; }
        /// <summary>The set of properties specific to email channel resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEmailChannelProperties Property { get; set; }

    }
}