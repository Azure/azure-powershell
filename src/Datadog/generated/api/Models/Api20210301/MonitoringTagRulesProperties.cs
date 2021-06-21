namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    /// <summary>Definition of the properties for a TagRules resource.</summary>
    public partial class MonitoringTagRulesProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal
    {

        /// <summary>Backing field for <see cref="LogRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRules _logRule;

        /// <summary>Set of rules for sending logs for the Monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRules LogRule { get => (this._logRule = this._logRule ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.LogRules()); set => this._logRule = value; }

        /// <summary>
        /// List of filtering tags to be used for capturing logs. This only takes effect if SendResourceLogs flag is enabled. If empty,
        /// all resources will be captured. If only Exclude action is specified, the rules will apply to the list of all available
        /// resources. If Include actions are specified, the rules will only include resources with the associated tags.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[] LogRuleFilteringTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRulesInternal)LogRule).FilteringTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRulesInternal)LogRule).FilteringTag = value ?? null /* arrayOf */; }

        /// <summary>Flag specifying if AAD logs should be sent for the Monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public bool? LogRuleSendAadLog { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRulesInternal)LogRule).SendAadLog; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRulesInternal)LogRule).SendAadLog = value ?? default(bool); }

        /// <summary>Flag specifying if Azure resource logs should be sent for the Monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public bool? LogRuleSendResourceLog { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRulesInternal)LogRule).SendResourceLog; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRulesInternal)LogRule).SendResourceLog = value ?? default(bool); }

        /// <summary>
        /// Flag specifying if Azure subscription logs should be sent for the Monitor resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public bool? LogRuleSendSubscriptionLog { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRulesInternal)LogRule).SendSubscriptionLog; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRulesInternal)LogRule).SendSubscriptionLog = value ?? default(bool); }

        /// <summary>Backing field for <see cref="MetricRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMetricRules _metricRule;

        /// <summary>Set of rules for sending metrics for the Monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMetricRules MetricRule { get => (this._metricRule = this._metricRule ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MetricRules()); set => this._metricRule = value; }

        /// <summary>
        /// List of filtering tags to be used for capturing metrics. If empty, all resources will be captured. If only Exclude action
        /// is specified, the rules will apply to the list of all available resources. If Include actions are specified, the rules
        /// will only include resources with the associated tags.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[] MetricRuleFilteringTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMetricRulesInternal)MetricRule).FilteringTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMetricRulesInternal)MetricRule).FilteringTag = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for LogRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRules Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal.LogRule { get => (this._logRule = this._logRule ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.LogRules()); set { {_logRule = value;} } }

        /// <summary>Internal Acessors for MetricRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMetricRules Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal.MetricRule { get => (this._metricRule = this._metricRule ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MetricRules()); set { {_metricRule = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRulesPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? _provisioningState;

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Creates an new <see cref="MonitoringTagRulesProperties" /> instance.</summary>
        public MonitoringTagRulesProperties()
        {

        }
    }
    /// Definition of the properties for a TagRules resource.
    public partial interface IMonitoringTagRulesProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
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

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? ProvisioningState { get;  }

    }
    /// Definition of the properties for a TagRules resource.
    internal partial interface IMonitoringTagRulesPropertiesInternal

    {
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

        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? ProvisioningState { get; set; }

    }
}