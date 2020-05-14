namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Represents a recommendation rule that the recommendation engine can perform.</summary>
    public partial class RecommendationRule :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRule,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRuleInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Name of action that is recommended by this rule in string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).ActionName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).ActionName = value; }

        /// <summary>Deep link to a blade on the portal. Applicable to dynamic rule only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string BladeName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).BladeName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).BladeName = value; }

        /// <summary>The list of category tags that this recommendation rule belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] CategoryTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).CategoryTag; }

        /// <summary>List of available channels that this rule applies.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels? Channel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).Channel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).Channel = value; }

        /// <summary>Localized detailed description of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).Description = value; }

        /// <summary>UI friendly name of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).DisplayName = value; }

        /// <summary>Extension name of the portal if exists. Applicable to dynamic rule only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ExtensionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).ExtensionName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).ExtensionName = value; }

        /// <summary>
        /// Forward link to an external document associated with the rule. Applicable to dynamic rule only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ForwardLink { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).ForwardLink; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).ForwardLink = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>True if this is associated with a dynamically added rule</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsDynamic { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).IsDynamic; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).IsDynamic = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Level of impact indicating how critical this rule is.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel? Level { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).Level; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).Level = value; }

        /// <summary>Localized name of the rule (Good for UI).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).Message = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for CategoryTag</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRuleInternal.CategoryTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).CategoryTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).CategoryTag = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRuleProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRuleInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RecommendationRuleProperties()); set { {_property = value;} } }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRuleProperties _property;

        /// <summary>RecommendationRule resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRuleProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RecommendationRuleProperties()); set => this._property = value; }

        /// <summary>
        /// Recommendation ID of an associated recommendation object tied to the rule, if exists.
        /// If such an object doesn't exist, it is set to null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RecommendationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).RecommendationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).RecommendationId = value; }

        /// <summary>Unique name of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RecommendationName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).RecommendationName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)Property).RecommendationName = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="RecommendationRule" /> instance.</summary>
        public RecommendationRule()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// Represents a recommendation rule that the recommendation engine can perform.
    public partial interface IRecommendationRule :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>Name of action that is recommended by this rule in string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of action that is recommended by this rule in string.",
        SerializedName = @"actionName",
        PossibleTypes = new [] { typeof(string) })]
        string ActionName { get; set; }
        /// <summary>Deep link to a blade on the portal. Applicable to dynamic rule only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Deep link to a blade on the portal. Applicable to dynamic rule only.",
        SerializedName = @"bladeName",
        PossibleTypes = new [] { typeof(string) })]
        string BladeName { get; set; }
        /// <summary>The list of category tags that this recommendation rule belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The list of category tags that this recommendation rule belongs to.",
        SerializedName = @"categoryTags",
        PossibleTypes = new [] { typeof(string) })]
        string[] CategoryTag { get;  }
        /// <summary>List of available channels that this rule applies.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of available channels that this rule applies.",
        SerializedName = @"channels",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels? Channel { get; set; }
        /// <summary>Localized detailed description of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Localized detailed description of the rule.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>UI friendly name of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"UI friendly name of the rule.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>Extension name of the portal if exists. Applicable to dynamic rule only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Extension name of the portal if exists. Applicable to dynamic rule only.",
        SerializedName = @"extensionName",
        PossibleTypes = new [] { typeof(string) })]
        string ExtensionName { get; set; }
        /// <summary>
        /// Forward link to an external document associated with the rule. Applicable to dynamic rule only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Forward link to an external document associated with the rule. Applicable to dynamic rule only.",
        SerializedName = @"forwardLink",
        PossibleTypes = new [] { typeof(string) })]
        string ForwardLink { get; set; }
        /// <summary>True if this is associated with a dynamically added rule</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"True if this is associated with a dynamically added rule",
        SerializedName = @"isDynamic",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDynamic { get; set; }
        /// <summary>Level of impact indicating how critical this rule is.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Level of impact indicating how critical this rule is.",
        SerializedName = @"level",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel? Level { get; set; }
        /// <summary>Localized name of the rule (Good for UI).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Localized name of the rule (Good for UI).",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>
        /// Recommendation ID of an associated recommendation object tied to the rule, if exists.
        /// If such an object doesn't exist, it is set to null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Recommendation ID of an associated recommendation object tied to the rule, if exists.
        If such an object doesn't exist, it is set to null.",
        SerializedName = @"recommendationId",
        PossibleTypes = new [] { typeof(string) })]
        string RecommendationId { get; set; }
        /// <summary>Unique name of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Unique name of the rule.",
        SerializedName = @"recommendationName",
        PossibleTypes = new [] { typeof(string) })]
        string RecommendationName { get; set; }

    }
    /// Represents a recommendation rule that the recommendation engine can perform.
    internal partial interface IRecommendationRuleInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>Name of action that is recommended by this rule in string.</summary>
        string ActionName { get; set; }
        /// <summary>Deep link to a blade on the portal. Applicable to dynamic rule only.</summary>
        string BladeName { get; set; }
        /// <summary>The list of category tags that this recommendation rule belongs to.</summary>
        string[] CategoryTag { get; set; }
        /// <summary>List of available channels that this rule applies.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels? Channel { get; set; }
        /// <summary>Localized detailed description of the rule.</summary>
        string Description { get; set; }
        /// <summary>UI friendly name of the rule.</summary>
        string DisplayName { get; set; }
        /// <summary>Extension name of the portal if exists. Applicable to dynamic rule only.</summary>
        string ExtensionName { get; set; }
        /// <summary>
        /// Forward link to an external document associated with the rule. Applicable to dynamic rule only.
        /// </summary>
        string ForwardLink { get; set; }
        /// <summary>True if this is associated with a dynamically added rule</summary>
        bool? IsDynamic { get; set; }
        /// <summary>Level of impact indicating how critical this rule is.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel? Level { get; set; }
        /// <summary>Localized name of the rule (Good for UI).</summary>
        string Message { get; set; }
        /// <summary>RecommendationRule resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRuleProperties Property { get; set; }
        /// <summary>
        /// Recommendation ID of an associated recommendation object tied to the rule, if exists.
        /// If such an object doesn't exist, it is set to null.
        /// </summary>
        string RecommendationId { get; set; }
        /// <summary>Unique name of the rule.</summary>
        string RecommendationName { get; set; }

    }
}