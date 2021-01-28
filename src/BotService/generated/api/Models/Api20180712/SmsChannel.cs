namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Sms channel definition</summary>
    public partial class SmsChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannel,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelInternal,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel __channel = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.Channel();

        /// <summary>
        /// The Sms account SID. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string AccountSid { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelPropertiesInternal)Property).AccountSid; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelPropertiesInternal)Property).AccountSid = value ?? null; }

        /// <summary>
        /// The Sms auth token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string AuthToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelPropertiesInternal)Property).AuthToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelPropertiesInternal)Property).AuthToken = value ?? null; }

        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? IsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelPropertiesInternal)Property).IsEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelPropertiesInternal)Property).IsEnabled = value ?? default(bool); }

        /// <summary>Whether this channel is validated for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? IsValidated { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelPropertiesInternal)Property).IsValidated; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelPropertiesInternal)Property).IsValidated = value ?? default(bool); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelProperties Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.SmsChannelProperties()); set { {_property = value;} } }

        /// <summary>The channel name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name = value ; }

        /// <summary>The Sms phone</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string Phone { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelPropertiesInternal)Property).Phone; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelPropertiesInternal)Property).Phone = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelProperties _property;

        /// <summary>The set of properties specific to Sms channel resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.SmsChannelProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="SmsChannel" /> instance.</summary>
        public SmsChannel()
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
    /// Sms channel definition
    public partial interface ISmsChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel
    {
        /// <summary>
        /// The Sms account SID. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Sms account SID. Value only returned through POST to the action Channel List API, otherwise empty.",
        SerializedName = @"accountSID",
        PossibleTypes = new [] { typeof(string) })]
        string AccountSid { get; set; }
        /// <summary>
        /// The Sms auth token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Sms auth token. Value only returned through POST to the action Channel List API, otherwise empty.",
        SerializedName = @"authToken",
        PossibleTypes = new [] { typeof(string) })]
        string AuthToken { get; set; }
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
        /// <summary>The Sms phone</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Sms phone",
        SerializedName = @"phone",
        PossibleTypes = new [] { typeof(string) })]
        string Phone { get; set; }

    }
    /// Sms channel definition
    internal partial interface ISmsChannelInternal :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal
    {
        /// <summary>
        /// The Sms account SID. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        string AccountSid { get; set; }
        /// <summary>
        /// The Sms auth token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        string AuthToken { get; set; }
        /// <summary>Whether this channel is enabled for the bot</summary>
        bool? IsEnabled { get; set; }
        /// <summary>Whether this channel is validated for the bot</summary>
        bool? IsValidated { get; set; }
        /// <summary>The Sms phone</summary>
        string Phone { get; set; }
        /// <summary>The set of properties specific to Sms channel resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISmsChannelProperties Property { get; set; }

    }
}