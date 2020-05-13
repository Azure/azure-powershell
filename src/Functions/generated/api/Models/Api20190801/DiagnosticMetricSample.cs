namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Class representing Diagnostic Metric</summary>
    public partial class DiagnosticMetricSample :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticMetricSample,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticMetricSampleInternal
    {

        /// <summary>Backing field for <see cref="IsAggregated" /> property.</summary>
        private bool? _isAggregated;

        /// <summary>Whether the values are aggregates across all workers or not</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsAggregated { get => this._isAggregated; set => this._isAggregated = value; }

        /// <summary>Backing field for <see cref="Maximum" /> property.</summary>
        private double? _maximum;

        /// <summary>Maximum of the metric sampled during the time period</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public double? Maximum { get => this._maximum; set => this._maximum = value; }

        /// <summary>Backing field for <see cref="Minimum" /> property.</summary>
        private double? _minimum;

        /// <summary>Minimum of the metric sampled during the time period</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public double? Minimum { get => this._minimum; set => this._minimum = value; }

        /// <summary>Backing field for <see cref="RoleInstance" /> property.</summary>
        private string _roleInstance;

        /// <summary>
        /// Role Instance. Null if this counter is not per instance
        /// This is returned and should be whichever instance name we desire to be returned
        /// i.e. CPU and Memory return RDWORKERNAME (LargeDed..._IN_0)
        /// where RDWORKERNAME is Machine name below and RoleInstance name in parenthesis
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RoleInstance { get => this._roleInstance; set => this._roleInstance = value; }

        /// <summary>Backing field for <see cref="Timestamp" /> property.</summary>
        private global::System.DateTime? _timestamp;

        /// <summary>Time at which metric is measured</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? Timestamp { get => this._timestamp; set => this._timestamp = value; }

        /// <summary>Backing field for <see cref="Total" /> property.</summary>
        private double? _total;

        /// <summary>
        /// Total value of the metric. If multiple measurements are made this will have sum of all.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public double? Total { get => this._total; set => this._total = value; }

        /// <summary>Creates an new <see cref="DiagnosticMetricSample" /> instance.</summary>
        public DiagnosticMetricSample()
        {

        }
    }
    /// Class representing Diagnostic Metric
    public partial interface IDiagnosticMetricSample :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Whether the values are aggregates across all workers or not</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the values are aggregates across all workers or not",
        SerializedName = @"isAggregated",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsAggregated { get; set; }
        /// <summary>Maximum of the metric sampled during the time period</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum of the metric sampled during the time period",
        SerializedName = @"maximum",
        PossibleTypes = new [] { typeof(double) })]
        double? Maximum { get; set; }
        /// <summary>Minimum of the metric sampled during the time period</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum of the metric sampled during the time period",
        SerializedName = @"minimum",
        PossibleTypes = new [] { typeof(double) })]
        double? Minimum { get; set; }
        /// <summary>
        /// Role Instance. Null if this counter is not per instance
        /// This is returned and should be whichever instance name we desire to be returned
        /// i.e. CPU and Memory return RDWORKERNAME (LargeDed..._IN_0)
        /// where RDWORKERNAME is Machine name below and RoleInstance name in parenthesis
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Role Instance. Null if this counter is not per instance
        This is returned and should be whichever instance name we desire to be returned
        i.e. CPU and Memory return RDWORKERNAME (LargeDed..._IN_0)
        where RDWORKERNAME is Machine name below and RoleInstance name in parenthesis",
        SerializedName = @"roleInstance",
        PossibleTypes = new [] { typeof(string) })]
        string RoleInstance { get; set; }
        /// <summary>Time at which metric is measured</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Time at which metric is measured",
        SerializedName = @"timestamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? Timestamp { get; set; }
        /// <summary>
        /// Total value of the metric. If multiple measurements are made this will have sum of all.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Total value of the metric. If multiple measurements are made this will have sum of all.",
        SerializedName = @"total",
        PossibleTypes = new [] { typeof(double) })]
        double? Total { get; set; }

    }
    /// Class representing Diagnostic Metric
    internal partial interface IDiagnosticMetricSampleInternal

    {
        /// <summary>Whether the values are aggregates across all workers or not</summary>
        bool? IsAggregated { get; set; }
        /// <summary>Maximum of the metric sampled during the time period</summary>
        double? Maximum { get; set; }
        /// <summary>Minimum of the metric sampled during the time period</summary>
        double? Minimum { get; set; }
        /// <summary>
        /// Role Instance. Null if this counter is not per instance
        /// This is returned and should be whichever instance name we desire to be returned
        /// i.e. CPU and Memory return RDWORKERNAME (LargeDed..._IN_0)
        /// where RDWORKERNAME is Machine name below and RoleInstance name in parenthesis
        /// </summary>
        string RoleInstance { get; set; }
        /// <summary>Time at which metric is measured</summary>
        global::System.DateTime? Timestamp { get; set; }
        /// <summary>
        /// Total value of the metric. If multiple measurements are made this will have sum of all.
        /// </summary>
        double? Total { get; set; }

    }
}