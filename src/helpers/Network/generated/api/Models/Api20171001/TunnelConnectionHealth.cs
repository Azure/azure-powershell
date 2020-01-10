namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>VirtualNetworkGatewayConnection properties</summary>
    public partial class TunnelConnectionHealth :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITunnelConnectionHealth,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITunnelConnectionHealthInternal
    {

        /// <summary>Backing field for <see cref="ConnectionStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus? _connectionStatus;

        /// <summary>Virtual network Gateway connection status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus? ConnectionStatus { get => this._connectionStatus; }

        /// <summary>Backing field for <see cref="EgressBytesTransferred" /> property.</summary>
        private long? _egressBytesTransferred;

        /// <summary>The Egress Bytes Transferred in this connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? EgressBytesTransferred { get => this._egressBytesTransferred; }

        /// <summary>Backing field for <see cref="IngressBytesTransferred" /> property.</summary>
        private long? _ingressBytesTransferred;

        /// <summary>The Ingress Bytes Transferred in this connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? IngressBytesTransferred { get => this._ingressBytesTransferred; }

        /// <summary>Backing field for <see cref="LastConnectionEstablishedUtcTime" /> property.</summary>
        private string _lastConnectionEstablishedUtcTime;

        /// <summary>The time at which connection was established in Utc format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string LastConnectionEstablishedUtcTime { get => this._lastConnectionEstablishedUtcTime; }

        /// <summary>Internal Acessors for ConnectionStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITunnelConnectionHealthInternal.ConnectionStatus { get => this._connectionStatus; set { {_connectionStatus = value;} } }

        /// <summary>Internal Acessors for EgressBytesTransferred</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITunnelConnectionHealthInternal.EgressBytesTransferred { get => this._egressBytesTransferred; set { {_egressBytesTransferred = value;} } }

        /// <summary>Internal Acessors for IngressBytesTransferred</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITunnelConnectionHealthInternal.IngressBytesTransferred { get => this._ingressBytesTransferred; set { {_ingressBytesTransferred = value;} } }

        /// <summary>Internal Acessors for LastConnectionEstablishedUtcTime</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITunnelConnectionHealthInternal.LastConnectionEstablishedUtcTime { get => this._lastConnectionEstablishedUtcTime; set { {_lastConnectionEstablishedUtcTime = value;} } }

        /// <summary>Internal Acessors for Tunnel</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITunnelConnectionHealthInternal.Tunnel { get => this._tunnel; set { {_tunnel = value;} } }

        /// <summary>Backing field for <see cref="Tunnel" /> property.</summary>
        private string _tunnel;

        /// <summary>Tunnel name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Tunnel { get => this._tunnel; }

        /// <summary>Creates an new <see cref="TunnelConnectionHealth" /> instance.</summary>
        public TunnelConnectionHealth()
        {

        }
    }
    /// VirtualNetworkGatewayConnection properties
    public partial interface ITunnelConnectionHealth :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Virtual network Gateway connection status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Virtual network Gateway connection status",
        SerializedName = @"connectionStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus? ConnectionStatus { get;  }
        /// <summary>The Egress Bytes Transferred in this connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Egress Bytes Transferred in this connection",
        SerializedName = @"egressBytesTransferred",
        PossibleTypes = new [] { typeof(long) })]
        long? EgressBytesTransferred { get;  }
        /// <summary>The Ingress Bytes Transferred in this connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Ingress Bytes Transferred in this connection",
        SerializedName = @"ingressBytesTransferred",
        PossibleTypes = new [] { typeof(long) })]
        long? IngressBytesTransferred { get;  }
        /// <summary>The time at which connection was established in Utc format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The time at which connection was established in Utc format.",
        SerializedName = @"lastConnectionEstablishedUtcTime",
        PossibleTypes = new [] { typeof(string) })]
        string LastConnectionEstablishedUtcTime { get;  }
        /// <summary>Tunnel name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Tunnel name.",
        SerializedName = @"tunnel",
        PossibleTypes = new [] { typeof(string) })]
        string Tunnel { get;  }

    }
    /// VirtualNetworkGatewayConnection properties
    internal partial interface ITunnelConnectionHealthInternal

    {
        /// <summary>Virtual network Gateway connection status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus? ConnectionStatus { get; set; }
        /// <summary>The Egress Bytes Transferred in this connection</summary>
        long? EgressBytesTransferred { get; set; }
        /// <summary>The Ingress Bytes Transferred in this connection</summary>
        long? IngressBytesTransferred { get; set; }
        /// <summary>The time at which connection was established in Utc format.</summary>
        string LastConnectionEstablishedUtcTime { get; set; }
        /// <summary>Tunnel name.</summary>
        string Tunnel { get; set; }

    }
}