namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The parameters to provide for the Bot.</summary>
    public partial class BotProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotProperties,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ConfiguredChannel" /> property.</summary>
        private string[] _configuredChannel;

        /// <summary>Collection of channels for which the bot is configured</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string[] ConfiguredChannel { get => this._configuredChannel; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>The description of the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="DeveloperAppInsightKey" /> property.</summary>
        private string _developerAppInsightKey;

        /// <summary>The Application Insights key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string DeveloperAppInsightKey { get => this._developerAppInsightKey; set => this._developerAppInsightKey = value; }

        /// <summary>Backing field for <see cref="DeveloperAppInsightsApiKey" /> property.</summary>
        private string _developerAppInsightsApiKey;

        /// <summary>The Application Insights Api Key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string DeveloperAppInsightsApiKey { get => this._developerAppInsightsApiKey; set => this._developerAppInsightsApiKey = value; }

        /// <summary>Backing field for <see cref="DeveloperAppInsightsApplicationId" /> property.</summary>
        private string _developerAppInsightsApplicationId;

        /// <summary>The Application Insights App Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string DeveloperAppInsightsApplicationId { get => this._developerAppInsightsApplicationId; set => this._developerAppInsightsApplicationId = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>The Name of the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="EnabledChannel" /> property.</summary>
        private string[] _enabledChannel;

        /// <summary>Collection of channels for which the bot is enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string[] EnabledChannel { get => this._enabledChannel; }

        /// <summary>Backing field for <see cref="Endpoint" /> property.</summary>
        private string _endpoint;

        /// <summary>The bot's endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Endpoint { get => this._endpoint; set => this._endpoint = value; }

        /// <summary>Backing field for <see cref="EndpointVersion" /> property.</summary>
        private string _endpointVersion;

        /// <summary>The bot's endpoint version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string EndpointVersion { get => this._endpointVersion; }

        /// <summary>Backing field for <see cref="IconUrl" /> property.</summary>
        private string _iconUrl;

        /// <summary>The Icon Url of the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string IconUrl { get => this._iconUrl; set => this._iconUrl = value; }

        /// <summary>Backing field for <see cref="LuisAppId" /> property.</summary>
        private string[] _luisAppId;

        /// <summary>Collection of LUIS App Ids</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string[] LuisAppId { get => this._luisAppId; set => this._luisAppId = value; }

        /// <summary>Backing field for <see cref="LuisKey" /> property.</summary>
        private string _luisKey;

        /// <summary>The LUIS Key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string LuisKey { get => this._luisKey; set => this._luisKey = value; }

        /// <summary>Internal Acessors for ConfiguredChannel</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal.ConfiguredChannel { get => this._configuredChannel; set { {_configuredChannel = value;} } }

        /// <summary>Internal Acessors for EnabledChannel</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal.EnabledChannel { get => this._enabledChannel; set { {_enabledChannel = value;} } }

        /// <summary>Internal Acessors for EndpointVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal.EndpointVersion { get => this._endpointVersion; set { {_endpointVersion = value;} } }

        /// <summary>Backing field for <see cref="MsaAppId" /> property.</summary>
        private string _msaAppId;

        /// <summary>Microsoft App Id for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string MsaAppId { get => this._msaAppId; set => this._msaAppId = value; }

        /// <summary>Creates an new <see cref="BotProperties" /> instance.</summary>
        public BotProperties()
        {

        }
    }
    /// The parameters to provide for the Bot.
    public partial interface IBotProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>Collection of channels for which the bot is configured</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Collection of channels for which the bot is configured",
        SerializedName = @"configuredChannels",
        PossibleTypes = new [] { typeof(string) })]
        string[] ConfiguredChannel { get;  }
        /// <summary>The description of the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The description of the bot",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The Application Insights key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Application Insights key",
        SerializedName = @"developerAppInsightKey",
        PossibleTypes = new [] { typeof(string) })]
        string DeveloperAppInsightKey { get; set; }
        /// <summary>The Application Insights Api Key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Application Insights Api Key",
        SerializedName = @"developerAppInsightsApiKey",
        PossibleTypes = new [] { typeof(string) })]
        string DeveloperAppInsightsApiKey { get; set; }
        /// <summary>The Application Insights App Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Application Insights App Id",
        SerializedName = @"developerAppInsightsApplicationId",
        PossibleTypes = new [] { typeof(string) })]
        string DeveloperAppInsightsApplicationId { get; set; }
        /// <summary>The Name of the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Name of the bot",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>Collection of channels for which the bot is enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Collection of channels for which the bot is enabled",
        SerializedName = @"enabledChannels",
        PossibleTypes = new [] { typeof(string) })]
        string[] EnabledChannel { get;  }
        /// <summary>The bot's endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The bot's endpoint",
        SerializedName = @"endpoint",
        PossibleTypes = new [] { typeof(string) })]
        string Endpoint { get; set; }
        /// <summary>The bot's endpoint version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The bot's endpoint version",
        SerializedName = @"endpointVersion",
        PossibleTypes = new [] { typeof(string) })]
        string EndpointVersion { get;  }
        /// <summary>The Icon Url of the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Icon Url of the bot",
        SerializedName = @"iconUrl",
        PossibleTypes = new [] { typeof(string) })]
        string IconUrl { get; set; }
        /// <summary>Collection of LUIS App Ids</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Collection of LUIS App Ids",
        SerializedName = @"luisAppIds",
        PossibleTypes = new [] { typeof(string) })]
        string[] LuisAppId { get; set; }
        /// <summary>The LUIS Key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The LUIS Key",
        SerializedName = @"luisKey",
        PossibleTypes = new [] { typeof(string) })]
        string LuisKey { get; set; }
        /// <summary>Microsoft App Id for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Microsoft App Id for the bot",
        SerializedName = @"msaAppId",
        PossibleTypes = new [] { typeof(string) })]
        string MsaAppId { get; set; }

    }
    /// The parameters to provide for the Bot.
    internal partial interface IBotPropertiesInternal

    {
        /// <summary>Collection of channels for which the bot is configured</summary>
        string[] ConfiguredChannel { get; set; }
        /// <summary>The description of the bot</summary>
        string Description { get; set; }
        /// <summary>The Application Insights key</summary>
        string DeveloperAppInsightKey { get; set; }
        /// <summary>The Application Insights Api Key</summary>
        string DeveloperAppInsightsApiKey { get; set; }
        /// <summary>The Application Insights App Id</summary>
        string DeveloperAppInsightsApplicationId { get; set; }
        /// <summary>The Name of the bot</summary>
        string DisplayName { get; set; }
        /// <summary>Collection of channels for which the bot is enabled</summary>
        string[] EnabledChannel { get; set; }
        /// <summary>The bot's endpoint</summary>
        string Endpoint { get; set; }
        /// <summary>The bot's endpoint version</summary>
        string EndpointVersion { get; set; }
        /// <summary>The Icon Url of the bot</summary>
        string IconUrl { get; set; }
        /// <summary>Collection of LUIS App Ids</summary>
        string[] LuisAppId { get; set; }
        /// <summary>The LUIS Key</summary>
        string LuisKey { get; set; }
        /// <summary>Microsoft App Id for the bot</summary>
        string MsaAppId { get; set; }

    }
}