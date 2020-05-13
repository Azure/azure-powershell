namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>RecommendationRule resource specific properties</summary>
    public partial class RecommendationRuleProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRuleProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal
    {

        /// <summary>Backing field for <see cref="ActionName" /> property.</summary>
        private string _actionName;

        /// <summary>Name of action that is recommended by this rule in string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ActionName { get => this._actionName; set => this._actionName = value; }

        /// <summary>Backing field for <see cref="BladeName" /> property.</summary>
        private string _bladeName;

        /// <summary>Deep link to a blade on the portal. Applicable to dynamic rule only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string BladeName { get => this._bladeName; set => this._bladeName = value; }

        /// <summary>Backing field for <see cref="CategoryTag" /> property.</summary>
        private string[] _categoryTag;

        /// <summary>The list of category tags that this recommendation rule belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] CategoryTag { get => this._categoryTag; }

        /// <summary>Backing field for <see cref="Channel" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels? _channel;

        /// <summary>List of available channels that this rule applies.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels? Channel { get => this._channel; set => this._channel = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Localized detailed description of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>UI friendly name of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="ExtensionName" /> property.</summary>
        private string _extensionName;

        /// <summary>Extension name of the portal if exists. Applicable to dynamic rule only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ExtensionName { get => this._extensionName; set => this._extensionName = value; }

        /// <summary>Backing field for <see cref="ForwardLink" /> property.</summary>
        private string _forwardLink;

        /// <summary>
        /// Forward link to an external document associated with the rule. Applicable to dynamic rule only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ForwardLink { get => this._forwardLink; set => this._forwardLink = value; }

        /// <summary>Backing field for <see cref="IsDynamic" /> property.</summary>
        private bool? _isDynamic;

        /// <summary>True if this is associated with a dynamically added rule</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsDynamic { get => this._isDynamic; set => this._isDynamic = value; }

        /// <summary>Backing field for <see cref="Level" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel? _level;

        /// <summary>Level of impact indicating how critical this rule is.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel? Level { get => this._level; set => this._level = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Localized name of the rule (Good for UI).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Internal Acessors for CategoryTag</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal.CategoryTag { get => this._categoryTag; set { {_categoryTag = value;} } }

        /// <summary>Backing field for <see cref="RecommendationId" /> property.</summary>
        private string _recommendationId;

        /// <summary>
        /// Recommendation ID of an associated recommendation object tied to the rule, if exists.
        /// If such an object doesn't exist, it is set to null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RecommendationId { get => this._recommendationId; set => this._recommendationId = value; }

        /// <summary>Backing field for <see cref="RecommendationName" /> property.</summary>
        private string _recommendationName;

        /// <summary>Unique name of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RecommendationName { get => this._recommendationName; set => this._recommendationName = value; }

        /// <summary>Creates an new <see cref="RecommendationRuleProperties" /> instance.</summary>
        public RecommendationRuleProperties()
        {

        }
    }
    /// RecommendationRule resource specific properties
    public partial interface IRecommendationRuleProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
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
    /// RecommendationRule resource specific properties
    internal partial interface IRecommendationRulePropertiesInternal

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
        /// <summary>
        /// Recommendation ID of an associated recommendation object tied to the rule, if exists.
        /// If such an object doesn't exist, it is set to null.
        /// </summary>
        string RecommendationId { get; set; }
        /// <summary>Unique name of the rule.</summary>
        string RecommendationName { get; set; }

    }
}