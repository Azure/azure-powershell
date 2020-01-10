namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Connection state snapshot.</summary>
    public partial class ConnectionStateSnapshot :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionStateSnapshot,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionStateSnapshotInternal
    {

        /// <summary>Backing field for <see cref="AvgLatencyInMS" /> property.</summary>
        private int? _avgLatencyInMS;

        /// <summary>Average latency in ms.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? AvgLatencyInMS { get => this._avgLatencyInMS; set => this._avgLatencyInMS = value; }

        /// <summary>Backing field for <see cref="ConnectionState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionState? _connectionState;

        /// <summary>The connection state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionState? ConnectionState { get => this._connectionState; set => this._connectionState = value; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>The end time of the connection snapshot.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Backing field for <see cref="EvaluationState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EvaluationState? _evaluationState;

        /// <summary>Connectivity analysis evaluation state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EvaluationState? EvaluationState { get => this._evaluationState; set => this._evaluationState = value; }

        /// <summary>Backing field for <see cref="Hop" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHop[] _hop;

        /// <summary>List of hops between the source and the destination.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHop[] Hop { get => this._hop; }

        /// <summary>Backing field for <see cref="MaxLatencyInMS" /> property.</summary>
        private int? _maxLatencyInMS;

        /// <summary>Maximum latency in ms.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? MaxLatencyInMS { get => this._maxLatencyInMS; set => this._maxLatencyInMS = value; }

        /// <summary>Internal Acessors for Hop</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHop[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionStateSnapshotInternal.Hop { get => this._hop; set { {_hop = value;} } }

        /// <summary>Backing field for <see cref="MinLatencyInMS" /> property.</summary>
        private int? _minLatencyInMS;

        /// <summary>Minimum latency in ms.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? MinLatencyInMS { get => this._minLatencyInMS; set => this._minLatencyInMS = value; }

        /// <summary>Backing field for <see cref="ProbesFailed" /> property.</summary>
        private int? _probesFailed;

        /// <summary>The number of failed probes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? ProbesFailed { get => this._probesFailed; set => this._probesFailed = value; }

        /// <summary>Backing field for <see cref="ProbesSent" /> property.</summary>
        private int? _probesSent;

        /// <summary>The number of sent probes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? ProbesSent { get => this._probesSent; set => this._probesSent = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>The start time of the connection snapshot.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Creates an new <see cref="ConnectionStateSnapshot" /> instance.</summary>
        public ConnectionStateSnapshot()
        {

        }
    }
    /// Connection state snapshot.
    public partial interface IConnectionStateSnapshot :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Average latency in ms.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Average latency in ms.",
        SerializedName = @"avgLatencyInMs",
        PossibleTypes = new [] { typeof(int) })]
        int? AvgLatencyInMS { get; set; }
        /// <summary>The connection state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The connection state.",
        SerializedName = @"connectionState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionState? ConnectionState { get; set; }
        /// <summary>The end time of the connection snapshot.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The end time of the connection snapshot.",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Connectivity analysis evaluation state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Connectivity analysis evaluation state.",
        SerializedName = @"evaluationState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EvaluationState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EvaluationState? EvaluationState { get; set; }
        /// <summary>List of hops between the source and the destination.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of hops between the source and the destination.",
        SerializedName = @"hops",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHop) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHop[] Hop { get;  }
        /// <summary>Maximum latency in ms.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum latency in ms.",
        SerializedName = @"maxLatencyInMs",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxLatencyInMS { get; set; }
        /// <summary>Minimum latency in ms.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum latency in ms.",
        SerializedName = @"minLatencyInMs",
        PossibleTypes = new [] { typeof(int) })]
        int? MinLatencyInMS { get; set; }
        /// <summary>The number of failed probes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of failed probes.",
        SerializedName = @"probesFailed",
        PossibleTypes = new [] { typeof(int) })]
        int? ProbesFailed { get; set; }
        /// <summary>The number of sent probes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of sent probes.",
        SerializedName = @"probesSent",
        PossibleTypes = new [] { typeof(int) })]
        int? ProbesSent { get; set; }
        /// <summary>The start time of the connection snapshot.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The start time of the connection snapshot.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }

    }
    /// Connection state snapshot.
    internal partial interface IConnectionStateSnapshotInternal

    {
        /// <summary>Average latency in ms.</summary>
        int? AvgLatencyInMS { get; set; }
        /// <summary>The connection state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionState? ConnectionState { get; set; }
        /// <summary>The end time of the connection snapshot.</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Connectivity analysis evaluation state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EvaluationState? EvaluationState { get; set; }
        /// <summary>List of hops between the source and the destination.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHop[] Hop { get; set; }
        /// <summary>Maximum latency in ms.</summary>
        int? MaxLatencyInMS { get; set; }
        /// <summary>Minimum latency in ms.</summary>
        int? MinLatencyInMS { get; set; }
        /// <summary>The number of failed probes.</summary>
        int? ProbesFailed { get; set; }
        /// <summary>The number of sent probes.</summary>
        int? ProbesSent { get; set; }
        /// <summary>The start time of the connection snapshot.</summary>
        global::System.DateTime? StartTime { get; set; }

    }
}