namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Recommendation resource specific properties</summary>
    public partial class RecommendationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ActionName" /> property.</summary>
        private string _actionName;

        /// <summary>Name of action recommended by this object.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ActionName { get => this._actionName; set => this._actionName = value; }

        /// <summary>Backing field for <see cref="BladeName" /> property.</summary>
        private string _bladeName;

        /// <summary>Deep link to a blade on the portal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string BladeName { get => this._bladeName; set => this._bladeName = value; }

        /// <summary>Backing field for <see cref="CategoryTag" /> property.</summary>
        private string[] _categoryTag;

        /// <summary>The list of category tags that this recommendation belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] CategoryTag { get => this._categoryTag; }

        /// <summary>Backing field for <see cref="Channel" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels? _channel;

        /// <summary>List of channels that this recommendation can apply.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels? Channel { get => this._channel; set => this._channel = value; }

        /// <summary>Backing field for <see cref="CreationTime" /> property.</summary>
        private global::System.DateTime? _creationTime;

        /// <summary>Timestamp when this instance was created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? CreationTime { get => this._creationTime; set => this._creationTime = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>UI friendly name of the rule (may not be unique).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private int? _enabled;

        /// <summary>
        /// True if this recommendation is still valid (i.e. "actionable"). False if it is invalid.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>The end time in UTC of a range that the recommendation refers to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Backing field for <see cref="ExtensionName" /> property.</summary>
        private string _extensionName;

        /// <summary>Extension name of the portal if exists.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ExtensionName { get => this._extensionName; set => this._extensionName = value; }

        /// <summary>Backing field for <see cref="ForwardLink" /> property.</summary>
        private string _forwardLink;

        /// <summary>Forward link to an external document associated with the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ForwardLink { get => this._forwardLink; set => this._forwardLink = value; }

        /// <summary>Backing field for <see cref="IsDynamic" /> property.</summary>
        private bool? _isDynamic;

        /// <summary>True if this is associated with a dynamically added rule</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsDynamic { get => this._isDynamic; set => this._isDynamic = value; }

        /// <summary>Backing field for <see cref="Level" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel? _level;

        /// <summary>Level indicating how critical this recommendation can impact.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel? Level { get => this._level; set => this._level = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Recommendation text.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Internal Acessors for CategoryTag</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal.CategoryTag { get => this._categoryTag; set { {_categoryTag = value;} } }

        /// <summary>Backing field for <see cref="NextNotificationTime" /> property.</summary>
        private global::System.DateTime? _nextNotificationTime;

        /// <summary>
        /// When to notify this recommendation next in UTC. Null means that this will never be notified anymore.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? NextNotificationTime { get => this._nextNotificationTime; set => this._nextNotificationTime = value; }

        /// <summary>Backing field for <see cref="NotificationExpirationTime" /> property.</summary>
        private global::System.DateTime? _notificationExpirationTime;

        /// <summary>Date and time in UTC when this notification expires.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? NotificationExpirationTime { get => this._notificationExpirationTime; set => this._notificationExpirationTime = value; }

        /// <summary>Backing field for <see cref="NotifiedTime" /> property.</summary>
        private global::System.DateTime? _notifiedTime;

        /// <summary>
        /// Last timestamp in UTC this instance was actually notified. Null means that this recommendation hasn't been notified yet.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? NotifiedTime { get => this._notifiedTime; set => this._notifiedTime = value; }

        /// <summary>Backing field for <see cref="RecommendationId" /> property.</summary>
        private string _recommendationId;

        /// <summary>A GUID value that each recommendation object is associated with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RecommendationId { get => this._recommendationId; set => this._recommendationId = value; }

        /// <summary>Backing field for <see cref="ResourceId" /> property.</summary>
        private string _resourceId;

        /// <summary>Full ARM resource ID string that this recommendation object is associated with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ResourceId { get => this._resourceId; set => this._resourceId = value; }

        /// <summary>Backing field for <see cref="ResourceScope" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ResourceScopeType? _resourceScope;

        /// <summary>
        /// Name of a resource type this recommendation applies, e.g. Subscription, ServerFarm, Site.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ResourceScopeType? ResourceScope { get => this._resourceScope; set => this._resourceScope = value; }

        /// <summary>Backing field for <see cref="RuleName" /> property.</summary>
        private string _ruleName;

        /// <summary>Unique name of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RuleName { get => this._ruleName; set => this._ruleName = value; }

        /// <summary>Backing field for <see cref="Score" /> property.</summary>
        private double? _score;

        /// <summary>A metric value measured by the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public double? Score { get => this._score; set => this._score = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>The beginning time in UTC of a range that the recommendation refers to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string[] _state;

        /// <summary>
        /// The list of states of this recommendation. If it's null then it should be considered "Active".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] State { get => this._state; set => this._state = value; }

        /// <summary>Creates an new <see cref="RecommendationProperties" /> instance.</summary>
        public RecommendationProperties()
        {

        }
    }
    /// Recommendation resource specific properties
    public partial interface IRecommendationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Name of action recommended by this object.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of action recommended by this object.",
        SerializedName = @"actionName",
        PossibleTypes = new [] { typeof(string) })]
        string ActionName { get; set; }
        /// <summary>Deep link to a blade on the portal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Deep link to a blade on the portal.",
        SerializedName = @"bladeName",
        PossibleTypes = new [] { typeof(string) })]
        string BladeName { get; set; }
        /// <summary>The list of category tags that this recommendation belongs to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The list of category tags that this recommendation belongs to.",
        SerializedName = @"categoryTags",
        PossibleTypes = new [] { typeof(string) })]
        string[] CategoryTag { get;  }
        /// <summary>List of channels that this recommendation can apply.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of channels that this recommendation can apply.",
        SerializedName = @"channels",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels? Channel { get; set; }
        /// <summary>Timestamp when this instance was created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Timestamp when this instance was created.",
        SerializedName = @"creationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreationTime { get; set; }
        /// <summary>UI friendly name of the rule (may not be unique).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"UI friendly name of the rule (may not be unique).",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>
        /// True if this recommendation is still valid (i.e. "actionable"). False if it is invalid.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"True if this recommendation is still valid (i.e. ""actionable""). False if it is invalid.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(int) })]
        int? Enabled { get; set; }
        /// <summary>The end time in UTC of a range that the recommendation refers to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The end time in UTC of a range that the recommendation refers to.",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Extension name of the portal if exists.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Extension name of the portal if exists.",
        SerializedName = @"extensionName",
        PossibleTypes = new [] { typeof(string) })]
        string ExtensionName { get; set; }
        /// <summary>Forward link to an external document associated with the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Forward link to an external document associated with the rule.",
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
        /// <summary>Level indicating how critical this recommendation can impact.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Level indicating how critical this recommendation can impact.",
        SerializedName = @"level",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel? Level { get; set; }
        /// <summary>Recommendation text.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Recommendation text.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>
        /// When to notify this recommendation next in UTC. Null means that this will never be notified anymore.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"When to notify this recommendation next in UTC. Null means that this will never be notified anymore.",
        SerializedName = @"nextNotificationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? NextNotificationTime { get; set; }
        /// <summary>Date and time in UTC when this notification expires.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Date and time in UTC when this notification expires.",
        SerializedName = @"notificationExpirationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? NotificationExpirationTime { get; set; }
        /// <summary>
        /// Last timestamp in UTC this instance was actually notified. Null means that this recommendation hasn't been notified yet.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Last timestamp in UTC this instance was actually notified. Null means that this recommendation hasn't been notified yet.",
        SerializedName = @"notifiedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? NotifiedTime { get; set; }
        /// <summary>A GUID value that each recommendation object is associated with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A GUID value that each recommendation object is associated with.",
        SerializedName = @"recommendationId",
        PossibleTypes = new [] { typeof(string) })]
        string RecommendationId { get; set; }
        /// <summary>Full ARM resource ID string that this recommendation object is associated with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Full ARM resource ID string that this recommendation object is associated with.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get; set; }
        /// <summary>
        /// Name of a resource type this recommendation applies, e.g. Subscription, ServerFarm, Site.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of a resource type this recommendation applies, e.g. Subscription, ServerFarm, Site.",
        SerializedName = @"resourceScope",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ResourceScopeType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ResourceScopeType? ResourceScope { get; set; }
        /// <summary>Unique name of the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Unique name of the rule.",
        SerializedName = @"ruleName",
        PossibleTypes = new [] { typeof(string) })]
        string RuleName { get; set; }
        /// <summary>A metric value measured by the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A metric value measured by the rule.",
        SerializedName = @"score",
        PossibleTypes = new [] { typeof(double) })]
        double? Score { get; set; }
        /// <summary>The beginning time in UTC of a range that the recommendation refers to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The beginning time in UTC of a range that the recommendation refers to.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }
        /// <summary>
        /// The list of states of this recommendation. If it's null then it should be considered "Active".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of states of this recommendation. If it's null then it should be considered ""Active"".",
        SerializedName = @"states",
        PossibleTypes = new [] { typeof(string) })]
        string[] State { get; set; }

    }
    /// Recommendation resource specific properties
    internal partial interface IRecommendationPropertiesInternal

    {
        /// <summary>Name of action recommended by this object.</summary>
        string ActionName { get; set; }
        /// <summary>Deep link to a blade on the portal.</summary>
        string BladeName { get; set; }
        /// <summary>The list of category tags that this recommendation belongs to.</summary>
        string[] CategoryTag { get; set; }
        /// <summary>List of channels that this recommendation can apply.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels? Channel { get; set; }
        /// <summary>Timestamp when this instance was created.</summary>
        global::System.DateTime? CreationTime { get; set; }
        /// <summary>UI friendly name of the rule (may not be unique).</summary>
        string DisplayName { get; set; }
        /// <summary>
        /// True if this recommendation is still valid (i.e. "actionable"). False if it is invalid.
        /// </summary>
        int? Enabled { get; set; }
        /// <summary>The end time in UTC of a range that the recommendation refers to.</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Extension name of the portal if exists.</summary>
        string ExtensionName { get; set; }
        /// <summary>Forward link to an external document associated with the rule.</summary>
        string ForwardLink { get; set; }
        /// <summary>True if this is associated with a dynamically added rule</summary>
        bool? IsDynamic { get; set; }
        /// <summary>Level indicating how critical this recommendation can impact.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel? Level { get; set; }
        /// <summary>Recommendation text.</summary>
        string Message { get; set; }
        /// <summary>
        /// When to notify this recommendation next in UTC. Null means that this will never be notified anymore.
        /// </summary>
        global::System.DateTime? NextNotificationTime { get; set; }
        /// <summary>Date and time in UTC when this notification expires.</summary>
        global::System.DateTime? NotificationExpirationTime { get; set; }
        /// <summary>
        /// Last timestamp in UTC this instance was actually notified. Null means that this recommendation hasn't been notified yet.
        /// </summary>
        global::System.DateTime? NotifiedTime { get; set; }
        /// <summary>A GUID value that each recommendation object is associated with.</summary>
        string RecommendationId { get; set; }
        /// <summary>Full ARM resource ID string that this recommendation object is associated with.</summary>
        string ResourceId { get; set; }
        /// <summary>
        /// Name of a resource type this recommendation applies, e.g. Subscription, ServerFarm, Site.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ResourceScopeType? ResourceScope { get; set; }
        /// <summary>Unique name of the rule.</summary>
        string RuleName { get; set; }
        /// <summary>A metric value measured by the rule.</summary>
        double? Score { get; set; }
        /// <summary>The beginning time in UTC of a range that the recommendation refers to.</summary>
        global::System.DateTime? StartTime { get; set; }
        /// <summary>
        /// The list of states of this recommendation. If it's null then it should be considered "Active".
        /// </summary>
        string[] State { get; set; }

    }
}