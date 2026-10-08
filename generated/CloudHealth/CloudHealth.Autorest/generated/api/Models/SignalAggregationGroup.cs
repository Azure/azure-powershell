// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Extensions;

    /// <summary>
    /// A logical group of signals on an entity, evaluated under a configurable aggregation strategy. Groups are independent even
    /// when they share members. Each group's aggregated state is one of the inputs to the entity's composite health computation
    /// alongside any signals not declared in any group's members[].
    /// </summary>
    public partial class SignalAggregationGroup :
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroup,
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal
    {

        /// <summary>Backing field for <see cref="AggregatedHealthState" /> property.</summary>
        private string _aggregatedHealthState;

        /// <summary>
        /// Computed aggregated health state of the group as of the last entity evaluation. Unknown if no resolvable members or all
        /// members filtered out.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string AggregatedHealthState { get => this._aggregatedHealthState; }

        /// <summary>Backing field for <see cref="AggregationType" /> property.</summary>
        private string _aggregationType;

        /// <summary>Aggregation strategy applied across the members of this group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string AggregationType { get => this._aggregationType; set => this._aggregationType = value; }

        /// <summary>Backing field for <see cref="DegradedThreshold" /> property.</summary>
        private double? _degradedThreshold;

        /// <summary>
        /// Degraded threshold for threshold-bearing strategies (MinHealthy, MaxNotHealthy). For MinHealthy: group is degraded when
        /// the healthy member count/percentage falls to or below this value. For MaxNotHealthy: group is degraded when the not-healthy
        /// member count/percentage reaches or exceeds this value. Optional — if not set, the group transitions directly between Healthy
        /// and Unhealthy. MUST NOT be set when aggregationType is WorstOf or BestOf.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public double? DegradedThreshold { get => this._degradedThreshold; set => this._degradedThreshold = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Display name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="IgnoreUnknown" /> property.</summary>
        private bool? _ignoreUnknown;

        /// <summary>
        /// If true (default), members reporting Unknown are excluded from the aggregation. For MinHealthy and MaxNotHealthy this
        /// flag affects the denominator/count and is meaningful. For WorstOf and BestOf the flag has no observable effect: under
        /// WorstOf, Unknown=0 is the lowest severity and can never beat any non-Unknown member in a Max() so filtering it changes
        /// nothing observable; under BestOf, Unknown is unconditionally excluded by the strategy itself irrespective of the flag.
        /// The flag is retained on the contract for vocabulary symmetry across all four strategies.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public bool? IgnoreUnknown { get => this._ignoreUnknown; set => this._ignoreUnknown = value; }

        /// <summary>Backing field for <see cref="Member" /> property.</summary>
        private System.Collections.Generic.List<string> _member;

        /// <summary>
        /// Names of signals on this entity which are members of the group. Members are matched by name; references to signals that
        /// do not currently exist on the entity are accepted (typically for pre-declared external signals) and surfaced via 'unresolvedMembers'.
        /// A signal may be listed in multiple groups; no duplicates within this list.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> Member { get => this._member; set => this._member = value; }

        /// <summary>Internal Acessors for AggregatedHealthState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal.AggregatedHealthState { get => this._aggregatedHealthState; set { {_aggregatedHealthState = value;} } }

        /// <summary>Internal Acessors for UnresolvedMember</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal.UnresolvedMember { get => this._unresolvedMember; set { {_unresolvedMember = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the aggregation group. Unique within the entity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="UnhealthyThreshold" /> property.</summary>
        private double? _unhealthyThreshold;

        /// <summary>
        /// Unhealthy threshold for threshold-bearing strategies. Required when aggregationType is MinHealthy or MaxNotHealthy; MUST
        /// NOT be set otherwise.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public double? UnhealthyThreshold { get => this._unhealthyThreshold; set => this._unhealthyThreshold = value; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit;

        /// <summary>
        /// Unit type for the thresholds. Required when aggregationType is MinHealthy or MaxNotHealthy; MUST NOT be set otherwise.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; set => this._unit = value; }

        /// <summary>Backing field for <see cref="UnresolvedMember" /> property.</summary>
        private System.Collections.Generic.List<string> _unresolvedMember;

        /// <summary>
        /// Members listed in 'members' that do not currently resolve to a signal on this entity at the time of the last entity evaluation.
        /// Treated as Unknown during aggregation. Empty/omitted when every member resolves.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> UnresolvedMember { get => this._unresolvedMember; }

        /// <summary>Creates an new <see cref="SignalAggregationGroup" /> instance.</summary>
        public SignalAggregationGroup()
        {

        }
    }
    /// A logical group of signals on an entity, evaluated under a configurable aggregation strategy. Groups are independent even
    /// when they share members. Each group's aggregated state is one of the inputs to the entity's composite health computation
    /// alongside any signals not declared in any group's members[].
    public partial interface ISignalAggregationGroup :
        Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Computed aggregated health state of the group as of the last entity evaluation. Unknown if no resolvable members or all
        /// members filtered out.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Computed aggregated health state of the group as of the last entity evaluation. Unknown if no resolvable members or all members filtered out.",
        SerializedName = @"aggregatedHealthState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PSArgumentCompleterAttribute("Healthy", "Degraded", "Unhealthy", "Unknown")]
        string AggregatedHealthState { get;  }
        /// <summary>Aggregation strategy applied across the members of this group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Aggregation strategy applied across the members of this group.",
        SerializedName = @"aggregationType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PSArgumentCompleterAttribute("WorstOf", "BestOf", "MinHealthy", "MaxNotHealthy")]
        string AggregationType { get; set; }
        /// <summary>
        /// Degraded threshold for threshold-bearing strategies (MinHealthy, MaxNotHealthy). For MinHealthy: group is degraded when
        /// the healthy member count/percentage falls to or below this value. For MaxNotHealthy: group is degraded when the not-healthy
        /// member count/percentage reaches or exceeds this value. Optional — if not set, the group transitions directly between Healthy
        /// and Unhealthy. MUST NOT be set when aggregationType is WorstOf or BestOf.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Degraded threshold for threshold-bearing strategies (MinHealthy, MaxNotHealthy). For MinHealthy: group is degraded when the healthy member count/percentage falls to or below this value. For MaxNotHealthy: group is degraded when the not-healthy member count/percentage reaches or exceeds this value. Optional — if not set, the group transitions directly between Healthy and Unhealthy. MUST NOT be set when aggregationType is WorstOf or BestOf.",
        SerializedName = @"degradedThreshold",
        PossibleTypes = new [] { typeof(double) })]
        double? DegradedThreshold { get; set; }
        /// <summary>Display name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Display name",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>
        /// If true (default), members reporting Unknown are excluded from the aggregation. For MinHealthy and MaxNotHealthy this
        /// flag affects the denominator/count and is meaningful. For WorstOf and BestOf the flag has no observable effect: under
        /// WorstOf, Unknown=0 is the lowest severity and can never beat any non-Unknown member in a Max() so filtering it changes
        /// nothing observable; under BestOf, Unknown is unconditionally excluded by the strategy itself irrespective of the flag.
        /// The flag is retained on the contract for vocabulary symmetry across all four strategies.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"If true (default), members reporting Unknown are excluded from the aggregation. For MinHealthy and MaxNotHealthy this flag affects the denominator/count and is meaningful. For WorstOf and BestOf the flag has no observable effect: under WorstOf, Unknown=0 is the lowest severity and can never beat any non-Unknown member in a Max() so filtering it changes nothing observable; under BestOf, Unknown is unconditionally excluded by the strategy itself irrespective of the flag. The flag is retained on the contract for vocabulary symmetry across all four strategies.",
        SerializedName = @"ignoreUnknown",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IgnoreUnknown { get; set; }
        /// <summary>
        /// Names of signals on this entity which are members of the group. Members are matched by name; references to signals that
        /// do not currently exist on the entity are accepted (typically for pre-declared external signals) and surfaced via 'unresolvedMembers'.
        /// A signal may be listed in multiple groups; no duplicates within this list.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Names of signals on this entity which are members of the group. Members are matched by name; references to signals that do not currently exist on the entity are accepted (typically for pre-declared external signals) and surfaced via 'unresolvedMembers'. A signal may be listed in multiple groups; no duplicates within this list.",
        SerializedName = @"members",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> Member { get; set; }
        /// <summary>Name of the aggregation group. Unique within the entity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of the aggregation group. Unique within the entity.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// Unhealthy threshold for threshold-bearing strategies. Required when aggregationType is MinHealthy or MaxNotHealthy; MUST
        /// NOT be set otherwise.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Unhealthy threshold for threshold-bearing strategies. Required when aggregationType is MinHealthy or MaxNotHealthy; MUST NOT be set otherwise.",
        SerializedName = @"unhealthyThreshold",
        PossibleTypes = new [] { typeof(double) })]
        double? UnhealthyThreshold { get; set; }
        /// <summary>
        /// Unit type for the thresholds. Required when aggregationType is MinHealthy or MaxNotHealthy; MUST NOT be set otherwise.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Unit type for the thresholds. Required when aggregationType is MinHealthy or MaxNotHealthy; MUST NOT be set otherwise.",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PSArgumentCompleterAttribute("Absolute", "Percentage")]
        string Unit { get; set; }
        /// <summary>
        /// Members listed in 'members' that do not currently resolve to a signal on this entity at the time of the last entity evaluation.
        /// Treated as Unknown during aggregation. Empty/omitted when every member resolves.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Members listed in 'members' that do not currently resolve to a signal on this entity at the time of the last entity evaluation. Treated as Unknown during aggregation. Empty/omitted when every member resolves.",
        SerializedName = @"unresolvedMembers",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> UnresolvedMember { get;  }

    }
    /// A logical group of signals on an entity, evaluated under a configurable aggregation strategy. Groups are independent even
    /// when they share members. Each group's aggregated state is one of the inputs to the entity's composite health computation
    /// alongside any signals not declared in any group's members[].
    internal partial interface ISignalAggregationGroupInternal

    {
        /// <summary>
        /// Computed aggregated health state of the group as of the last entity evaluation. Unknown if no resolvable members or all
        /// members filtered out.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PSArgumentCompleterAttribute("Healthy", "Degraded", "Unhealthy", "Unknown")]
        string AggregatedHealthState { get; set; }
        /// <summary>Aggregation strategy applied across the members of this group.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PSArgumentCompleterAttribute("WorstOf", "BestOf", "MinHealthy", "MaxNotHealthy")]
        string AggregationType { get; set; }
        /// <summary>
        /// Degraded threshold for threshold-bearing strategies (MinHealthy, MaxNotHealthy). For MinHealthy: group is degraded when
        /// the healthy member count/percentage falls to or below this value. For MaxNotHealthy: group is degraded when the not-healthy
        /// member count/percentage reaches or exceeds this value. Optional — if not set, the group transitions directly between Healthy
        /// and Unhealthy. MUST NOT be set when aggregationType is WorstOf or BestOf.
        /// </summary>
        double? DegradedThreshold { get; set; }
        /// <summary>Display name</summary>
        string DisplayName { get; set; }
        /// <summary>
        /// If true (default), members reporting Unknown are excluded from the aggregation. For MinHealthy and MaxNotHealthy this
        /// flag affects the denominator/count and is meaningful. For WorstOf and BestOf the flag has no observable effect: under
        /// WorstOf, Unknown=0 is the lowest severity and can never beat any non-Unknown member in a Max() so filtering it changes
        /// nothing observable; under BestOf, Unknown is unconditionally excluded by the strategy itself irrespective of the flag.
        /// The flag is retained on the contract for vocabulary symmetry across all four strategies.
        /// </summary>
        bool? IgnoreUnknown { get; set; }
        /// <summary>
        /// Names of signals on this entity which are members of the group. Members are matched by name; references to signals that
        /// do not currently exist on the entity are accepted (typically for pre-declared external signals) and surfaced via 'unresolvedMembers'.
        /// A signal may be listed in multiple groups; no duplicates within this list.
        /// </summary>
        System.Collections.Generic.List<string> Member { get; set; }
        /// <summary>Name of the aggregation group. Unique within the entity.</summary>
        string Name { get; set; }
        /// <summary>
        /// Unhealthy threshold for threshold-bearing strategies. Required when aggregationType is MinHealthy or MaxNotHealthy; MUST
        /// NOT be set otherwise.
        /// </summary>
        double? UnhealthyThreshold { get; set; }
        /// <summary>
        /// Unit type for the thresholds. Required when aggregationType is MinHealthy or MaxNotHealthy; MUST NOT be set otherwise.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.PSArgumentCompleterAttribute("Absolute", "Percentage")]
        string Unit { get; set; }
        /// <summary>
        /// Members listed in 'members' that do not currently resolve to a signal on this entity at the time of the last entity evaluation.
        /// Treated as Unknown during aggregation. Empty/omitted when every member resolves.
        /// </summary>
        System.Collections.Generic.List<string> UnresolvedMember { get; set; }

    }
}