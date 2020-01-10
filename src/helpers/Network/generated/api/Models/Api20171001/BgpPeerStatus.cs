namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>BGP peer status details</summary>
    public partial class BgpPeerStatus :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpPeerStatus,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpPeerStatusInternal
    {

        /// <summary>Backing field for <see cref="Asn" /> property.</summary>
        private int? _asn;

        /// <summary>The autonomous system number of the remote BGP peer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Asn { get => this._asn; }

        /// <summary>Backing field for <see cref="ConnectedDuration" /> property.</summary>
        private string _connectedDuration;

        /// <summary>For how long the peering has been up</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ConnectedDuration { get => this._connectedDuration; }

        /// <summary>Backing field for <see cref="LocalAddress" /> property.</summary>
        private string _localAddress;

        /// <summary>The virtual network gateway's local address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string LocalAddress { get => this._localAddress; }

        /// <summary>Backing field for <see cref="MessagesReceived" /> property.</summary>
        private long? _messagesReceived;

        /// <summary>The number of BGP messages received</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? MessagesReceived { get => this._messagesReceived; }

        /// <summary>Backing field for <see cref="MessagesSent" /> property.</summary>
        private long? _messagesSent;

        /// <summary>The number of BGP messages sent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? MessagesSent { get => this._messagesSent; }

        /// <summary>Internal Acessors for Asn</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpPeerStatusInternal.Asn { get => this._asn; set { {_asn = value;} } }

        /// <summary>Internal Acessors for ConnectedDuration</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpPeerStatusInternal.ConnectedDuration { get => this._connectedDuration; set { {_connectedDuration = value;} } }

        /// <summary>Internal Acessors for LocalAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpPeerStatusInternal.LocalAddress { get => this._localAddress; set { {_localAddress = value;} } }

        /// <summary>Internal Acessors for MessagesReceived</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpPeerStatusInternal.MessagesReceived { get => this._messagesReceived; set { {_messagesReceived = value;} } }

        /// <summary>Internal Acessors for MessagesSent</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpPeerStatusInternal.MessagesSent { get => this._messagesSent; set { {_messagesSent = value;} } }

        /// <summary>Internal Acessors for Neighbor</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpPeerStatusInternal.Neighbor { get => this._neighbor; set { {_neighbor = value;} } }

        /// <summary>Internal Acessors for RoutesReceived</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpPeerStatusInternal.RoutesReceived { get => this._routesReceived; set { {_routesReceived = value;} } }

        /// <summary>Internal Acessors for State</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.BgpPeerState? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpPeerStatusInternal.State { get => this._state; set { {_state = value;} } }

        /// <summary>Backing field for <see cref="Neighbor" /> property.</summary>
        private string _neighbor;

        /// <summary>The remote BGP peer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Neighbor { get => this._neighbor; }

        /// <summary>Backing field for <see cref="RoutesReceived" /> property.</summary>
        private long? _routesReceived;

        /// <summary>The number of routes learned from this peer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? RoutesReceived { get => this._routesReceived; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.BgpPeerState? _state;

        /// <summary>The BGP peer state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.BgpPeerState? State { get => this._state; }

        /// <summary>Creates an new <see cref="BgpPeerStatus" /> instance.</summary>
        public BgpPeerStatus()
        {

        }
    }
    /// BGP peer status details
    public partial interface IBgpPeerStatus :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The autonomous system number of the remote BGP peer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The autonomous system number of the remote BGP peer",
        SerializedName = @"asn",
        PossibleTypes = new [] { typeof(int) })]
        int? Asn { get;  }
        /// <summary>For how long the peering has been up</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"For how long the peering has been up",
        SerializedName = @"connectedDuration",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectedDuration { get;  }
        /// <summary>The virtual network gateway's local address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The virtual network gateway's local address",
        SerializedName = @"localAddress",
        PossibleTypes = new [] { typeof(string) })]
        string LocalAddress { get;  }
        /// <summary>The number of BGP messages received</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The number of BGP messages received",
        SerializedName = @"messagesReceived",
        PossibleTypes = new [] { typeof(long) })]
        long? MessagesReceived { get;  }
        /// <summary>The number of BGP messages sent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The number of BGP messages sent",
        SerializedName = @"messagesSent",
        PossibleTypes = new [] { typeof(long) })]
        long? MessagesSent { get;  }
        /// <summary>The remote BGP peer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The remote BGP peer",
        SerializedName = @"neighbor",
        PossibleTypes = new [] { typeof(string) })]
        string Neighbor { get;  }
        /// <summary>The number of routes learned from this peer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The number of routes learned from this peer",
        SerializedName = @"routesReceived",
        PossibleTypes = new [] { typeof(long) })]
        long? RoutesReceived { get;  }
        /// <summary>The BGP peer state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The BGP peer state",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.BgpPeerState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.BgpPeerState? State { get;  }

    }
    /// BGP peer status details
    internal partial interface IBgpPeerStatusInternal

    {
        /// <summary>The autonomous system number of the remote BGP peer</summary>
        int? Asn { get; set; }
        /// <summary>For how long the peering has been up</summary>
        string ConnectedDuration { get; set; }
        /// <summary>The virtual network gateway's local address</summary>
        string LocalAddress { get; set; }
        /// <summary>The number of BGP messages received</summary>
        long? MessagesReceived { get; set; }
        /// <summary>The number of BGP messages sent</summary>
        long? MessagesSent { get; set; }
        /// <summary>The remote BGP peer</summary>
        string Neighbor { get; set; }
        /// <summary>The number of routes learned from this peer</summary>
        long? RoutesReceived { get; set; }
        /// <summary>The BGP peer state</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.BgpPeerState? State { get; set; }

    }
}