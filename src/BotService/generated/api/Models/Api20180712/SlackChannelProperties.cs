namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The parameters to provide for the Slack channel.</summary>
    public partial class SlackChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelProperties,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ClientId" /> property.</summary>
        private string _clientId;

        /// <summary>The Slack client id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string ClientId { get => this._clientId; set => this._clientId = value; }

        /// <summary>Backing field for <see cref="ClientSecret" /> property.</summary>
        private string _clientSecret;

        /// <summary>
        /// The Slack client secret. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string ClientSecret { get => this._clientSecret; set => this._clientSecret = value; }

        /// <summary>Backing field for <see cref="IsEnabled" /> property.</summary>
        private bool _isEnabled;

        /// <summary>Whether this channel is enabled for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool IsEnabled { get => this._isEnabled; set => this._isEnabled = value; }

        /// <summary>Backing field for <see cref="IsValidated" /> property.</summary>
        private bool? _isValidated;

        /// <summary>Whether this channel is validated for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool? IsValidated { get => this._isValidated; }

        /// <summary>Backing field for <see cref="LandingPageUrl" /> property.</summary>
        private string _landingPageUrl;

        /// <summary>The Slack landing page Url</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string LandingPageUrl { get => this._landingPageUrl; set => this._landingPageUrl = value; }

        /// <summary>Backing field for <see cref="LastSubmissionId" /> property.</summary>
        private string _lastSubmissionId;

        /// <summary>The Sms auth token</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string LastSubmissionId { get => this._lastSubmissionId; }

        /// <summary>Internal Acessors for IsValidated</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal.IsValidated { get => this._isValidated; set { {_isValidated = value;} } }

        /// <summary>Internal Acessors for LastSubmissionId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal.LastSubmissionId { get => this._lastSubmissionId; set { {_lastSubmissionId = value;} } }

        /// <summary>Internal Acessors for RedirectAction</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal.RedirectAction { get => this._redirectAction; set { {_redirectAction = value;} } }

        /// <summary>Internal Acessors for RegisterBeforeOAuthFlow</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal.RegisterBeforeOAuthFlow { get => this._registerBeforeOAuthFlow; set { {_registerBeforeOAuthFlow = value;} } }

        /// <summary>Backing field for <see cref="RedirectAction" /> property.</summary>
        private string _redirectAction;

        /// <summary>The Slack redirect action</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string RedirectAction { get => this._redirectAction; }

        /// <summary>Backing field for <see cref="RegisterBeforeOAuthFlow" /> property.</summary>
        private bool? _registerBeforeOAuthFlow;

        /// <summary>
        /// Whether to register the settings before OAuth validation is performed. Recommended to True.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public bool? RegisterBeforeOAuthFlow { get => this._registerBeforeOAuthFlow; }

        /// <summary>Backing field for <see cref="VerificationToken" /> property.</summary>
        private string _verificationToken;

        /// <summary>
        /// The Slack verification token. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string VerificationToken { get => this._verificationToken; set => this._verificationToken = value; }

        /// <summary>Creates an new <see cref="SlackChannelProperties" /> instance.</summary>
        public SlackChannelProperties()
        {

        }
    }
    /// The parameters to provide for the Slack channel.
    public partial interface ISlackChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>The Slack client id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Slack client id",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientId { get; set; }
        /// <summary>
        /// The Slack client secret. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Slack client secret. Value only returned through POST to the action Channel List API, otherwise empty.",
        SerializedName = @"clientSecret",
        PossibleTypes = new [] { typeof(string) })]
        string ClientSecret { get; set; }
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
        Required = true,
        ReadOnly = false,
        Description = @"The Slack verification token. Value only returned through POST to the action Channel List API, otherwise empty.",
        SerializedName = @"verificationToken",
        PossibleTypes = new [] { typeof(string) })]
        string VerificationToken { get; set; }

    }
    /// The parameters to provide for the Slack channel.
    internal partial interface ISlackChannelPropertiesInternal

    {
        /// <summary>The Slack client id</summary>
        string ClientId { get; set; }
        /// <summary>
        /// The Slack client secret. Value only returned through POST to the action Channel List API, otherwise empty.
        /// </summary>
        string ClientSecret { get; set; }
        /// <summary>Whether this channel is enabled for the bot</summary>
        bool IsEnabled { get; set; }
        /// <summary>Whether this channel is validated for the bot</summary>
        bool? IsValidated { get; set; }
        /// <summary>The Slack landing page Url</summary>
        string LandingPageUrl { get; set; }
        /// <summary>The Sms auth token</summary>
        string LastSubmissionId { get; set; }
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