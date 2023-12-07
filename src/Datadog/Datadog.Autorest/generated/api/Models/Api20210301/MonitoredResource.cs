namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    /// <summary>
    /// The properties of a resource currently being monitored by the Datadog monitor resource.
    /// </summary>
    public partial class MonitoredResource :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoredResource,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoredResourceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The ARM id of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="ReasonForLogsStatus" /> property.</summary>
        private string _reasonForLogsStatus;

        /// <summary>Reason for why the resource is sending logs (or why it is not sending).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string ReasonForLogsStatus { get => this._reasonForLogsStatus; set => this._reasonForLogsStatus = value; }

        /// <summary>Backing field for <see cref="ReasonForMetricsStatus" /> property.</summary>
        private string _reasonForMetricsStatus;

        /// <summary>Reason for why the resource is sending metrics (or why it is not sending).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string ReasonForMetricsStatus { get => this._reasonForMetricsStatus; set => this._reasonForMetricsStatus = value; }

        /// <summary>Backing field for <see cref="SendingLog" /> property.</summary>
        private bool? _sendingLog;

        /// <summary>Flag indicating if resource is sending logs to Datadog.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public bool? SendingLog { get => this._sendingLog; set => this._sendingLog = value; }

        /// <summary>Backing field for <see cref="SendingMetric" /> property.</summary>
        private bool? _sendingMetric;

        /// <summary>Flag indicating if resource is sending metrics to Datadog.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public bool? SendingMetric { get => this._sendingMetric; set => this._sendingMetric = value; }

        /// <summary>Creates an new <see cref="MonitoredResource" /> instance.</summary>
        public MonitoredResource()
        {

        }
    }
    /// The properties of a resource currently being monitored by the Datadog monitor resource.
    public partial interface IMonitoredResource :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        /// <summary>The ARM id of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM id of the resource.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>Reason for why the resource is sending logs (or why it is not sending).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Reason for why the resource is sending logs (or why it is not sending).",
        SerializedName = @"reasonForLogsStatus",
        PossibleTypes = new [] { typeof(string) })]
        string ReasonForLogsStatus { get; set; }
        /// <summary>Reason for why the resource is sending metrics (or why it is not sending).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Reason for why the resource is sending metrics (or why it is not sending).",
        SerializedName = @"reasonForMetricsStatus",
        PossibleTypes = new [] { typeof(string) })]
        string ReasonForMetricsStatus { get; set; }
        /// <summary>Flag indicating if resource is sending logs to Datadog.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag indicating if resource is sending logs to Datadog.",
        SerializedName = @"sendingLogs",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SendingLog { get; set; }
        /// <summary>Flag indicating if resource is sending metrics to Datadog.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag indicating if resource is sending metrics to Datadog.",
        SerializedName = @"sendingMetrics",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SendingMetric { get; set; }

    }
    /// The properties of a resource currently being monitored by the Datadog monitor resource.
    internal partial interface IMonitoredResourceInternal

    {
        /// <summary>The ARM id of the resource.</summary>
        string Id { get; set; }
        /// <summary>Reason for why the resource is sending logs (or why it is not sending).</summary>
        string ReasonForLogsStatus { get; set; }
        /// <summary>Reason for why the resource is sending metrics (or why it is not sending).</summary>
        string ReasonForMetricsStatus { get; set; }
        /// <summary>Flag indicating if resource is sending logs to Datadog.</summary>
        bool? SendingLog { get; set; }
        /// <summary>Flag indicating if resource is sending metrics to Datadog.</summary>
        bool? SendingMetric { get; set; }

    }
}