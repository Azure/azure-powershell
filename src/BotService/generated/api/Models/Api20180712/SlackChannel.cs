namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Slack channel definition</summary>
    public partial class SlackChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannel,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelInternal,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel __channel = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.Channel();

        /// <summary>The Slack client id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string ClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).ClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).ClientId = value ?? null; }

        /// <summary>
        /// The Slack client secret. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string ClientSecret { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).ClientSecret; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).ClientSecret = value ?? null; }

        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? IsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).IsEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).IsEnabled = value ?? default(bool); }

        /// <summary>Whether this channel is validated for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? IsValidated { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).IsValidated; }

        /// <summary>The Slack landing page Url</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string LandingPageUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).LandingPageUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).LandingPageUrl = value ?? null; }

        /// <summary>The Sms auth token</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string LastSubmissionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).LastSubmissionId; }

        /// <summary>Internal Acessors for IsValidated</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelInternal.IsValidated { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).IsValidated; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).IsValidated = value; }

        /// <summary>Internal Acessors for LastSubmissionId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelInternal.LastSubmissionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).LastSubmissionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).LastSubmissionId = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelProperties Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.SlackChannelProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for RedirectAction</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelInternal.RedirectAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).RedirectAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).RedirectAction = value; }

        /// <summary>Internal Acessors for RegisterBeforeOAuthFlow</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelInternal.RegisterBeforeOAuthFlow { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).RegisterBeforeOAuthFlow; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).RegisterBeforeOAuthFlow = value; }

        /// <summary>The channel name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name = value ; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelProperties _property;

        /// <summary>The set of properties specific to Slack channel resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.SlackChannelProperties()); set => this._property = value; }

        /// <summary>The Slack redirect action</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string RedirectAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).RedirectAction; }

        /// <summary>
        /// Whether to register the settings before OAuth validation is performed. Recommended to True.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public bool? RegisterBeforeOAuthFlow { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).RegisterBeforeOAuthFlow; }

        /// <summary>
        /// The Slack verification token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string VerificationToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).VerificationToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)Property).VerificationToken = value ?? null; }

        /// <summary>Creates an new <see cref="SlackChannel" /> instance.</summary>
        public SlackChannel()
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
    /// Slack channel definition
    public partial interface ISlackChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel
    {
        /// <summary>The Slack client id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Slack client id",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientId { get; set; }
        /// <summary>
        /// The Slack client secret. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Slack client secret. Value only returned through POST to the action Channel List API, otherwise empty.",
        SerializedName = @"clientSecret",
        PossibleTypes = new [] { typeof(string) })]
        string ClientSecret { get; set; }
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
        ReadOnly = true,
        Description = @"Whether this channel is validated for the bot",
        SerializedName = @"isValidated",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsValidated { get;  }
        /// <summary>The Slack landing page Url</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Slack landing page Url",
        SerializedName = @"landingPageUrl",
        PossibleTypes = new [] { typeof(string) })]
        string LandingPageUrl { get; set; }
        /// <summary>The Sms auth token</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Sms auth token",
        SerializedName = @"lastSubmissionId",
        PossibleTypes = new [] { typeof(string) })]
        string LastSubmissionId { get;  }
        /// <summary>The Slack redirect action</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Slack redirect action",
        SerializedName = @"redirectAction",
        PossibleTypes = new [] { typeof(string) })]
        string RedirectAction { get;  }
        /// <summary>
        /// Whether to register the settings before OAuth validation is performed. Recommended to True.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Whether to register the settings before OAuth validation is performed. Recommended to True.",
        SerializedName = @"registerBeforeOAuthFlow",
        PossibleTypes = new [] { typeof(bool) })]
        bool? RegisterBeforeOAuthFlow { get;  }
        /// <summary>
        /// The Slack verification token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Slack verification token. Value only returned through POST to the action Channel List API, otherwise empty.",
        SerializedName = @"verificationToken",
        PossibleTypes = new [] { typeof(string) })]
        string VerificationToken { get; set; }

    }
    /// Slack channel definition
    internal partial interface ISlackChannelInternal :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal
    {
        /// <summary>The Slack client id</summary>
        string ClientId { get; set; }
        /// <summary>
        /// The Slack client secret. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        string ClientSecret { get; set; }
        /// <summary>Whether this channel is enabled for the bot</summary>
        bool? IsEnabled { get; set; }
        /// <summary>Whether this channel is validated for the bot</summary>
        bool? IsValidated { get; set; }
        /// <summary>The Slack landing page Url</summary>
        string LandingPageUrl { get; set; }
        /// <summary>The Sms auth token</summary>
        string LastSubmissionId { get; set; }
        /// <summary>The set of properties specific to Slack channel resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelProperties Property { get; set; }
        /// <summary>The Slack redirect action</summary>
        string RedirectAction { get; set; }
        /// <summary>
        /// Whether to register the settings before OAuth validation is performed. Recommended to True.
        /// </summary>
        bool? RegisterBeforeOAuthFlow { get; set; }
        /// <summary>
        /// The Slack verification token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        string VerificationToken { get; set; }

    }
}