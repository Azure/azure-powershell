namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    /// <summary>Set of rules for sending metrics for the Monitor resource.</summary>
    public partial class MetricRules :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMetricRules,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMetricRulesInternal
    {

        /// <summary>Backing field for <see cref="FilteringTag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[] _filteringTag;

        /// <summary>
        /// List of filtering tags to be used for capturing metrics. If empty, all resources will be captured. If only Exclude action
        /// is specified, the rules will apply to the list of all available resources. If Include actions are specified, the rules
        /// will only include resources with the associated tags.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[] FilteringTag { get => this._filteringTag; set => this._filteringTag = value; }

        /// <summary>Creates an new <see cref="MetricRules" /> instance.</summary>
        public MetricRules()
        {

        }
    }
    /// Set of rules for sending metrics for the Monitor resource.
    public partial interface IMetricRules :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
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
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[] FilteringTag { get; set; }

    }
    /// Set of rules for sending metrics for the Monitor resource.
    internal partial interface IMetricRulesInternal

    {
        /// <summary>
        /// List of filtering tags to be used for capturing metrics. If empty, all resources will be captured. If only Exclude action
        /// is specified, the rules will apply to the list of all available resources. If Include actions are specified, the rules
        /// will only include resources with the associated tags.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[] FilteringTag { get; set; }

    }
}