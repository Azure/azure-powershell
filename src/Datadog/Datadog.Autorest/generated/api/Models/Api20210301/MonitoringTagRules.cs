namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    /// <summary>Capture logs and metrics of Azure resources based on ARM tags.</summary>
    public partial class MonitoringTagRules :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRules,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The id of the rule set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>
        /// List of filtering tags to be used for capturing logs. This only takes effect if SendResourceLogs flag is enabled. If empty,
        /// all resources will be captured. If only Exclude action is specified, the rules will apply to the list of all available
        /// resources. If Include actions are specified, the rules will only include resources with the associated tags.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[] LogRuleFilteringTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)Property).LogRuleFilteringTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)Property).LogRuleFilteringTag = value ?? null /* arrayOf */; }

        /// <summary>Flag specifying if AAD logs should be sent for the Monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public bool? LogRuleSendAadLog { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)Property).LogRuleSendAadLog; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)Property).LogRuleSendAadLog = value ?? default(bool); }

        /// <summary>Flag specifying if Azure resource logs should be sent for the Monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public bool? LogRuleSendResourceLog { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)Property).LogRuleSendResourceLog; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)Property).LogRuleSendResourceLog = value ?? default(bool); }

        /// <summary>
        /// Flag specifying if Azure subscription logs should be sent for the Monitor resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public bool? LogRuleSendSubscriptionLog { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)Property).LogRuleSendSubscriptionLog; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)Property).LogRuleSendSubscriptionLog = value ?? default(bool); }

        /// <summary>
        /// List of filtering tags to be used for capturing metrics. If empty, all resources will be captured. If only Exclude action
        /// is specified, the rules will apply to the list of all available resources. If Include actions are specified, the rules
        /// will only include resources with the associated tags.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[] MetricRuleFilteringTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)Property).MetricRuleFilteringTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)Property).MetricRuleFilteringTag = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for LogRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRules Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal.LogRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)Property).LogRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)Property).LogRule = value; }

        /// <summary>Internal Acessors for MetricRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMetricRules Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal.MetricRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)Property).MetricRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)Property).MetricRule = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesProperties Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitoringTagRulesProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemData Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal.SystemData { get => (this._systemData = this._systemData ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.SystemData()); set { {_systemData = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the rule set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesProperties _property;

        /// <summary>Definition of the properties for a TagRules resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitoringTagRulesProperties()); set => this._property = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Backing field for <see cref="SystemData" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemData _systemData;

        /// <summary>Metadata pertaining to creation and last modification of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemData SystemData { get => (this._systemData = this._systemData ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.SystemData()); }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).CreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).CreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).CreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).CreatedBy = value ?? null; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType? SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).CreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).CreatedByType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType)""); }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).LastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).LastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).LastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).LastModifiedBy = value ?? null; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType? SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).LastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemDataInternal)SystemData).LastModifiedByType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType)""); }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The type of the rule set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="MonitoringTagRules" /> instance.</summary>
        public MonitoringTagRules()
        {

        }
    }
    /// Capture logs and metrics of Azure resources based on ARM tags.
    public partial interface IMonitoringTagRules :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        /// <summary>The id of the rule set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The id of the rule set.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>
        /// List of filtering tags to be used for capturing logs. This only takes effect if SendResourceLogs flag is enabled. If empty,
        /// all resources will be captured. If only Exclude action is specified, the rules will apply to the list of all available
        /// resources. If Include actions are specified, the rules will only include resources with the associated tags.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of filtering tags to be used for capturing logs. This only takes effect if SendResourceLogs flag is enabled. If empty, all resources will be captured. If only Exclude action is specified, the rules will apply to the list of all available resources. If Include actions are specified, the rules will only include resources with the associated tags.",
        SerializedName = @"filteringTags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[] LogRuleFilteringTag { get; set; }
        /// <summary>Flag specifying if AAD logs should be sent for the Monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag specifying if AAD logs should be sent for the Monitor resource.",
        SerializedName = @"sendAadLogs",
        PossibleTypes = new [] { typeof(bool) })]
        bool? LogRuleSendAadLog { get; set; }
        /// <summary>Flag specifying if Azure resource logs should be sent for the Monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag specifying if Azure resource logs should be sent for the Monitor resource.",
        SerializedName = @"sendResourceLogs",
        PossibleTypes = new [] { typeof(bool) })]
        bool? LogRuleSendResourceLog { get; set; }
        /// <summary>
        /// Flag specifying if Azure subscription logs should be sent for the Monitor resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag specifying if Azure subscription logs should be sent for the Monitor resource.",
        SerializedName = @"sendSubscriptionLogs",
        PossibleTypes = new [] { typeof(bool) })]
        bool? LogRuleSendSubscriptionLog { get; set; }
        /// <summary>
        /// List of filtering tags to be used for capturing metrics. If empty, all resources will be captured. If only Exclude action
        /// is specified, the rules will apply to the list of all available resources. If Include actions are specified, the rules
        /// will only include resources with the associated tags.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of filtering tags to be used for capturing metrics. If empty, all resources will be captured. If only Exclude action is specified, the rules will apply to the list of all available resources. If Include actions are specified, the rules will only include resources with the associated tags.",
        SerializedName = @"filteringTags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[] MetricRuleFilteringTag { get; set; }
        /// <summary>Name of the rule set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the rule set.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timestamp of resource creation (UTC).",
        SerializedName = @"createdAt",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SystemDataCreatedAt { get; set; }
        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity that created the resource.",
        SerializedName = @"createdBy",
        PossibleTypes = new [] { typeof(string) })]
        string SystemDataCreatedBy { get; set; }
        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity that created the resource.",
        SerializedName = @"createdByType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType? SystemDataCreatedByType { get; set; }
        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timestamp of resource last modification (UTC)",
        SerializedName = @"lastModifiedAt",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SystemDataLastModifiedAt { get; set; }
        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity that last modified the resource.",
        SerializedName = @"lastModifiedBy",
        PossibleTypes = new [] { typeof(string) })]
        string SystemDataLastModifiedBy { get; set; }
        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity that last modified the resource.",
        SerializedName = @"lastModifiedByType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType? SystemDataLastModifiedByType { get; set; }
        /// <summary>The type of the rule set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of the rule set.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// Capture logs and metrics of Azure resources based on ARM tags.
    internal partial interface IMonitoringTagRulesInternal

    {
        /// <summary>The id of the rule set.</summary>
        string Id { get; set; }
        /// <summary>Set of rules for sending logs for the Monitor resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRules LogRule { get; set; }
        /// <summary>
        /// List of filtering tags to be used for capturing logs. This only takes effect if SendResourceLogs flag is enabled. If empty,
        /// all resources will be captured. If only Exclude action is specified, the rules will apply to the list of all available
        /// resources. If Include actions are specified, the rules will only include resources with the associated tags.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[] LogRuleFilteringTag { get; set; }
        /// <summary>Flag specifying if AAD logs should be sent for the Monitor resource.</summary>
        bool? LogRuleSendAadLog { get; set; }
        /// <summary>Flag specifying if Azure resource logs should be sent for the Monitor resource.</summary>
        bool? LogRuleSendResourceLog { get; set; }
        /// <summary>
        /// Flag specifying if Azure subscription logs should be sent for the Monitor resource.
        /// </summary>
        bool? LogRuleSendSubscriptionLog { get; set; }
        /// <summary>Set of rules for sending metrics for the Monitor resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMetricRules MetricRule { get; set; }
        /// <summary>
        /// List of filtering tags to be used for capturing metrics. If empty, all resources will be captured. If only Exclude action
        /// is specified, the rules will apply to the list of all available resources. If Include actions are specified, the rules
        /// will only include resources with the associated tags.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[] MetricRuleFilteringTag { get; set; }
        /// <summary>Name of the rule set.</summary>
        string Name { get; set; }
        /// <summary>Definition of the properties for a TagRules resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesProperties Property { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Metadata pertaining to creation and last modification of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemData SystemData { get; set; }
        /// <summary>The timestamp of resource creation (UTC).</summary>
        global::System.DateTime? SystemDataCreatedAt { get; set; }
        /// <summary>The identity that created the resource.</summary>
        string SystemDataCreatedBy { get; set; }
        /// <summary>The type of identity that created the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType? SystemDataCreatedByType { get; set; }
        /// <summary>The timestamp of resource last modification (UTC)</summary>
        global::System.DateTime? SystemDataLastModifiedAt { get; set; }
        /// <summary>The identity that last modified the resource.</summary>
        string SystemDataLastModifiedBy { get; set; }
        /// <summary>The type of identity that last modified the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType? SystemDataLastModifiedByType { get; set; }
        /// <summary>The type of the rule set.</summary>
        string Type { get; set; }

    }
}