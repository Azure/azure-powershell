namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Details on latency for a time series.</summary>
    public partial class AzureReachabilityReportLatencyInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLatencyInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureReachabilityReportLatencyInfoInternal
    {

        /// <summary>Backing field for <see cref="Score" /> property.</summary>
        private int? _score;

        /// <summary>
        /// The relative latency score between 1 and 100, higher values indicating a faster connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Score { get => this._score; set => this._score = value; }

        /// <summary>Backing field for <see cref="TimeStamp" /> property.</summary>
        private global::System.DateTime? _timeStamp;

        /// <summary>The time stamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public global::System.DateTime? TimeStamp { get => this._timeStamp; set => this._timeStamp = value; }

        /// <summary>Creates an new <see cref="AzureReachabilityReportLatencyInfo" /> instance.</summary>
        public AzureReachabilityReportLatencyInfo()
        {

        }
    }
    /// Details on latency for a time series.
    public partial interface IAzureReachabilityReportLatencyInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The relative latency score between 1 and 100, higher values indicating a faster connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The relative latency score between 1 and 100, higher values indicating a faster connection.",
        SerializedName = @"score",
        PossibleTypes = new [] { typeof(int) })]
        int? Score { get; set; }
        /// <summary>The time stamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time stamp.",
        SerializedName = @"timeStamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TimeStamp { get; set; }

    }
    /// Details on latency for a time series.
    internal partial interface IAzureReachabilityReportLatencyInfoInternal

    {
        /// <summary>
        /// The relative latency score between 1 and 100, higher values indicating a faster connection.
        /// </summary>
        int? Score { get; set; }
        /// <summary>The time stamp.</summary>
        global::System.DateTime? TimeStamp { get; set; }

    }
}