namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Information on the connectivity status.</summary>
    public partial class ConnectivityInformation :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityInformation,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityInformationInternal
    {

        /// <summary>Backing field for <see cref="AvgLatencyInMS" /> property.</summary>
        private int? _avgLatencyInMS;

        /// <summary>Average latency in milliseconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? AvgLatencyInMS { get => this._avgLatencyInMS; }

        /// <summary>Backing field for <see cref="ConnectionStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionStatus? _connectionStatus;

        /// <summary>The connection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionStatus? ConnectionStatus { get => this._connectionStatus; }

        /// <summary>Backing field for <see cref="Hop" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHop[] _hop;

        /// <summary>List of hops between the source and the destination.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHop[] Hop { get => this._hop; }

        /// <summary>Backing field for <see cref="MaxLatencyInMS" /> property.</summary>
        private int? _maxLatencyInMS;

        /// <summary>Maximum latency in milliseconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? MaxLatencyInMS { get => this._maxLatencyInMS; }

        /// <summary>Internal Acessors for AvgLatencyInMS</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityInformationInternal.AvgLatencyInMS { get => this._avgLatencyInMS; set { {_avgLatencyInMS = value;} } }

        /// <summary>Internal Acessors for ConnectionStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionStatus? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityInformationInternal.ConnectionStatus { get => this._connectionStatus; set { {_connectionStatus = value;} } }

        /// <summary>Internal Acessors for Hop</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHop[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityInformationInternal.Hop { get => this._hop; set { {_hop = value;} } }

        /// <summary>Internal Acessors for MaxLatencyInMS</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityInformationInternal.MaxLatencyInMS { get => this._maxLatencyInMS; set { {_maxLatencyInMS = value;} } }

        /// <summary>Internal Acessors for MinLatencyInMS</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityInformationInternal.MinLatencyInMS { get => this._minLatencyInMS; set { {_minLatencyInMS = value;} } }

        /// <summary>Internal Acessors for ProbesFailed</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityInformationInternal.ProbesFailed { get => this._probesFailed; set { {_probesFailed = value;} } }

        /// <summary>Internal Acessors for ProbesSent</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityInformationInternal.ProbesSent { get => this._probesSent; set { {_probesSent = value;} } }

        /// <summary>Backing field for <see cref="MinLatencyInMS" /> property.</summary>
        private int? _minLatencyInMS;

        /// <summary>Minimum latency in milliseconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? MinLatencyInMS { get => this._minLatencyInMS; }

        /// <summary>Backing field for <see cref="ProbesFailed" /> property.</summary>
        private int? _probesFailed;

        /// <summary>Number of failed probes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? ProbesFailed { get => this._probesFailed; }

        /// <summary>Backing field for <see cref="ProbesSent" /> property.</summary>
        private int? _probesSent;

        /// <summary>Total number of probes sent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? ProbesSent { get => this._probesSent; }

        /// <summary>Creates an new <see cref="ConnectivityInformation" /> instance.</summary>
        public ConnectivityInformation()
        {

        }
    }
    /// Information on the connectivity status.
    public partial interface IConnectivityInformation :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Average latency in milliseconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Average latency in milliseconds.",
        SerializedName = @"avgLatencyInMs",
        PossibleTypes = new [] { typeof(int) })]
        int? AvgLatencyInMS { get;  }
        /// <summary>The connection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The connection status.",
        SerializedName = @"connectionStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionStatus? ConnectionStatus { get;  }
        /// <summary>List of hops between the source and the destination.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of hops between the source and the destination.",
        SerializedName = @"hops",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHop) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHop[] Hop { get;  }
        /// <summary>Maximum latency in milliseconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Maximum latency in milliseconds.",
        SerializedName = @"maxLatencyInMs",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxLatencyInMS { get;  }
        /// <summary>Minimum latency in milliseconds.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Minimum latency in milliseconds.",
        SerializedName = @"minLatencyInMs",
        PossibleTypes = new [] { typeof(int) })]
        int? MinLatencyInMS { get;  }
        /// <summary>Number of failed probes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Number of failed probes.",
        SerializedName = @"probesFailed",
        PossibleTypes = new [] { typeof(int) })]
        int? ProbesFailed { get;  }
        /// <summary>Total number of probes sent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Total number of probes sent.",
        SerializedName = @"probesSent",
        PossibleTypes = new [] { typeof(int) })]
        int? ProbesSent { get;  }

    }
    /// Information on the connectivity status.
    internal partial interface IConnectivityInformationInternal

    {
        /// <summary>Average latency in milliseconds.</summary>
        int? AvgLatencyInMS { get; set; }
        /// <summary>The connection status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionStatus? ConnectionStatus { get; set; }
        /// <summary>List of hops between the source and the destination.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHop[] Hop { get; set; }
        /// <summary>Maximum latency in milliseconds.</summary>
        int? MaxLatencyInMS { get; set; }
        /// <summary>Minimum latency in milliseconds.</summary>
        int? MinLatencyInMS { get; set; }
        /// <summary>Number of failed probes.</summary>
        int? ProbesFailed { get; set; }
        /// <summary>Total number of probes sent.</summary>
        int? ProbesSent { get; set; }

    }
}