namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Gateway routing details</summary>
    public partial class GatewayRoute :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IGatewayRoute,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IGatewayRouteInternal
    {

        /// <summary>Backing field for <see cref="AsPath" /> property.</summary>
        private string _asPath;

        /// <summary>The route's AS path sequence</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AsPath { get => this._asPath; }

        /// <summary>Backing field for <see cref="LocalAddress" /> property.</summary>
        private string _localAddress;

        /// <summary>The gateway's local address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string LocalAddress { get => this._localAddress; }

        /// <summary>Internal Acessors for AsPath</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IGatewayRouteInternal.AsPath { get => this._asPath; set { {_asPath = value;} } }

        /// <summary>Internal Acessors for LocalAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IGatewayRouteInternal.LocalAddress { get => this._localAddress; set { {_localAddress = value;} } }

        /// <summary>Internal Acessors for Network</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IGatewayRouteInternal.Network { get => this._network; set { {_network = value;} } }

        /// <summary>Internal Acessors for NextHop</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IGatewayRouteInternal.NextHop { get => this._nextHop; set { {_nextHop = value;} } }

        /// <summary>Internal Acessors for Origin</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IGatewayRouteInternal.Origin { get => this._origin; set { {_origin = value;} } }

        /// <summary>Internal Acessors for SourcePeer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IGatewayRouteInternal.SourcePeer { get => this._sourcePeer; set { {_sourcePeer = value;} } }

        /// <summary>Internal Acessors for Weight</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IGatewayRouteInternal.Weight { get => this._weight; set { {_weight = value;} } }

        /// <summary>Backing field for <see cref="Network" /> property.</summary>
        private string _network;

        /// <summary>The route's network prefix</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Network { get => this._network; }

        /// <summary>Backing field for <see cref="NextHop" /> property.</summary>
        private string _nextHop;

        /// <summary>The route's next hop</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextHop { get => this._nextHop; }

        /// <summary>Backing field for <see cref="Origin" /> property.</summary>
        private string _origin;

        /// <summary>The source this route was learned from</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Origin { get => this._origin; }

        /// <summary>Backing field for <see cref="SourcePeer" /> property.</summary>
        private string _sourcePeer;

        /// <summary>The peer this route was learned from</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SourcePeer { get => this._sourcePeer; }

        /// <summary>Backing field for <see cref="Weight" /> property.</summary>
        private int? _weight;

        /// <summary>The route's weight</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Weight { get => this._weight; }

        /// <summary>Creates an new <see cref="GatewayRoute" /> instance.</summary>
        public GatewayRoute()
        {

        }
    }
    /// Gateway routing details
    public partial interface IGatewayRoute :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The route's AS path sequence</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The route's AS path sequence",
        SerializedName = @"asPath",
        PossibleTypes = new [] { typeof(string) })]
        string AsPath { get;  }
        /// <summary>The gateway's local address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The gateway's local address",
        SerializedName = @"localAddress",
        PossibleTypes = new [] { typeof(string) })]
        string LocalAddress { get;  }
        /// <summary>The route's network prefix</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The route's network prefix",
        SerializedName = @"network",
        PossibleTypes = new [] { typeof(string) })]
        string Network { get;  }
        /// <summary>The route's next hop</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The route's next hop",
        SerializedName = @"nextHop",
        PossibleTypes = new [] { typeof(string) })]
        string NextHop { get;  }
        /// <summary>The source this route was learned from</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The source this route was learned from",
        SerializedName = @"origin",
        PossibleTypes = new [] { typeof(string) })]
        string Origin { get;  }
        /// <summary>The peer this route was learned from</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The peer this route was learned from",
        SerializedName = @"sourcePeer",
        PossibleTypes = new [] { typeof(string) })]
        string SourcePeer { get;  }
        /// <summary>The route's weight</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The route's weight",
        SerializedName = @"weight",
        PossibleTypes = new [] { typeof(int) })]
        int? Weight { get;  }

    }
    /// Gateway routing details
    internal partial interface IGatewayRouteInternal

    {
        /// <summary>The route's AS path sequence</summary>
        string AsPath { get; set; }
        /// <summary>The gateway's local address</summary>
        string LocalAddress { get; set; }
        /// <summary>The route's network prefix</summary>
        string Network { get; set; }
        /// <summary>The route's next hop</summary>
        string NextHop { get; set; }
        /// <summary>The source this route was learned from</summary>
        string Origin { get; set; }
        /// <summary>The peer this route was learned from</summary>
        string SourcePeer { get; set; }
        /// <summary>The route's weight</summary>
        int? Weight { get; set; }

    }
}