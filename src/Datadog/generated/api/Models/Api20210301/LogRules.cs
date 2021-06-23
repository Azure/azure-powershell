namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    /// <summary>Set of rules for sending logs for the Monitor resource.</summary>
    public partial class LogRules :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRules,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ILogRulesInternal
    {

        /// <summary>Backing field for <see cref="FilteringTag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[] _filteringTag;

        /// <summary>
        /// List of filtering tags to be used for capturing logs. This only takes effect if SendResourceLogs flag is enabled. If empty,
        /// all resources will be captured. If only Exclude action is specified, the rules will apply to the list of all available
        /// resources. If Include actions are specified, the rules will only include resources with the associated tags.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[] FilteringTag { get => this._filteringTag; set => this._filteringTag = value; }

        /// <summary>Backing field for <see cref="SendAadLog" /> property.</summary>
        private bool? _sendAadLog;

        /// <summary>Flag specifying if AAD logs should be sent for the Monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public bool? SendAadLog { get => this._sendAadLog; set => this._sendAadLog = value; }

        /// <summary>Backing field for <see cref="SendResourceLog" /> property.</summary>
        private bool? _sendResourceLog;

        /// <summary>Flag specifying if Azure resource logs should be sent for the Monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public bool? SendResourceLog { get => this._sendResourceLog; set => this._sendResourceLog = value; }

        /// <summary>Backing field for <see cref="SendSubscriptionLog" /> property.</summary>
        private bool? _sendSubscriptionLog;

        /// <summary>
        /// Flag specifying if Azure subscription logs should be sent for the Monitor resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public bool? SendSubscriptionLog { get => this._sendSubscriptionLog; set => this._sendSubscriptionLog = value; }

        /// <summary>Creates an new <see cref="LogRules" /> instance.</summary>
        public LogRules()
        {

        }
    }
    /// Set of rules for sending logs for the Monitor resource.
    public partial interface ILogRules :
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
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[] FilteringTag { get; set; }
        /// <summary>Flag specifying if AAD logs should be sent for the Monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag specifying if AAD logs should be sent for the Monitor resource.",
        SerializedName = @"sendAadLogs",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SendAadLog { get; set; }
        /// <summary>Flag specifying if Azure resource logs should be sent for the Monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag specifying if Azure resource logs should be sent for the Monitor resource.",
        SerializedName = @"sendResourceLogs",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SendResourceLog { get; set; }
        /// <summary>
        /// Flag specifying if Azure subscription logs should be sent for the Monitor resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag specifying if Azure subscription logs should be sent for the Monitor resource.",
        SerializedName = @"sendSubscriptionLogs",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SendSubscriptionLog { get; set; }

    }
    /// Set of rules for sending logs for the Monitor resource.
    internal partial interface ILogRulesInternal

    {
        /// <summary>
        /// List of filtering tags to be used for capturing logs. This only takes effect if SendResourceLogs flag is enabled. If empty,
        /// all resources will be captured. If only Exclude action is specified, the rules will apply to the list of all available
        /// resources. If Include actions are specified, the rules will only include resources with the associated tags.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[] FilteringTag { get; set; }
        /// <summary>Flag specifying if AAD logs should be sent for the Monitor resource.</summary>
        bool? SendAadLog { get; set; }
        /// <summary>Flag specifying if Azure resource logs should be sent for the Monitor resource.</summary>
        bool? SendResourceLog { get; set; }
        /// <summary>
        /// Flag specifying if Azure subscription logs should be sent for the Monitor resource.
        /// </summary>
        bool? SendSubscriptionLog { get; set; }

    }
}