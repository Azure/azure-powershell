namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Bot resource definition</summary>
    public partial class Bot :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBot,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.Resource();

        /// <summary>Collection of channels for which the bot is configured</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string[] ConfiguredChannel { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).ConfiguredChannel; }

        /// <summary>The description of the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).Description = value ?? null; }

        /// <summary>The Application Insights key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string DeveloperAppInsightKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).DeveloperAppInsightKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).DeveloperAppInsightKey = value ?? null; }

        /// <summary>The Application Insights Api Key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string DeveloperAppInsightsApiKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).DeveloperAppInsightsApiKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).DeveloperAppInsightsApiKey = value ?? null; }

        /// <summary>The Application Insights App Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string DeveloperAppInsightsApplicationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).DeveloperAppInsightsApplicationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).DeveloperAppInsightsApplicationId = value ?? null; }

        /// <summary>The Name of the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).DisplayName = value ?? null; }

        /// <summary>Collection of channels for which the bot is enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string[] EnabledChannel { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).EnabledChannel; }

        /// <summary>The bot's endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string Endpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).Endpoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).Endpoint = value ?? null; }

        /// <summary>The bot's endpoint version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string EndpointVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).EndpointVersion; }

        /// <summary>Entity Tag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Etag { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Etag = value ?? null; }

        /// <summary>The Icon Url of the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string IconUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).IconUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).IconUrl = value ?? null; }

        /// <summary>Specifies the resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Id; }

        /// <summary>Required. Gets or sets the Kind of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.Kind? Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Kind = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.Kind)""); }

        /// <summary>Specifies the location of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Location = value ?? null; }

        /// <summary>Collection of LUIS App Ids</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string[] LuisAppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).LuisAppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).LuisAppId = value ?? null /* arrayOf */; }

        /// <summary>The LUIS Key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string LuisKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).LuisKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).LuisKey = value ?? null; }

        /// <summary>Internal Acessors for ConfiguredChannel</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal.ConfiguredChannel { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).ConfiguredChannel; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).ConfiguredChannel = value; }

        /// <summary>Internal Acessors for EnabledChannel</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal.EnabledChannel { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).EnabledChannel; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).EnabledChannel = value; }

        /// <summary>Internal Acessors for EndpointVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal.EndpointVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).EndpointVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).EndpointVersion = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotProperties Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.BotProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for SkuTier</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuTier? Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal.SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).SkuTier; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).SkuTier = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Type = value; }

        /// <summary>Microsoft App Id for the bot</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string MsaAppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).MsaAppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotPropertiesInternal)Property).MsaAppId = value ?? null; }

        /// <summary>Specifies the name of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotProperties _property;

        /// <summary>The set of properties specific to bot resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.BotProperties()); set => this._property = value; }

        /// <summary>Gets or sets the SKU of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISku Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Sku = value ?? null /* model class */; }

        /// <summary>The sku name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuName? SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).SkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).SkuName = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuName)""); }

        /// <summary>Gets the sku tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuTier? SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).SkuTier; }

        /// <summary>Contains resource tags defined as key/value pairs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Tag = value ?? null /* model class */; }

        /// <summary>Specifies the type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="Bot" /> instance.</summary>
        public Bot()
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
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Bot resource definition
    public partial interface IBot :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResource
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
        Required = false,
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
        Required = false,
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
        Required = false,
        ReadOnly = false,
        Description = @"Microsoft App Id for the bot",
        SerializedName = @"msaAppId",
        PossibleTypes = new [] { typeof(string) })]
        string MsaAppId { get; set; }

    }
    /// Bot resource definition
    internal partial interface IBotInternal :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal
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
        /// <summary>The set of properties specific to bot resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotProperties Property { get; set; }

    }
}