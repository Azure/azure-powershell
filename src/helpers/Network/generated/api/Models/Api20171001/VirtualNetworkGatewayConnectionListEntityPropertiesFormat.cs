namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>VirtualNetworkGatewayConnection properties</summary>
    public partial class VirtualNetworkGatewayConnectionListEntityPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayConnectionListEntityPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayConnectionListEntityPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="AuthorizationKey" /> property.</summary>
        private string _authorizationKey;

        /// <summary>The authorizationKey.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AuthorizationKey { get => this._authorizationKey; set => this._authorizationKey = value; }

        /// <summary>Backing field for <see cref="ConnectionStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus? _connectionStatus;

        /// <summary>
        /// Virtual network Gateway connection status. Possible values are 'Unknown', 'Connecting', 'Connected' and 'NotConnected'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus? ConnectionStatus { get => this._connectionStatus; }

        /// <summary>Backing field for <see cref="ConnectionType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType _connectionType;

        /// <summary>
        /// Gateway connection type. Possible values are: 'IPsec','Vnet2Vnet','ExpressRoute', and 'VPNClient.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType ConnectionType { get => this._connectionType; set => this._connectionType = value; }

        /// <summary>Backing field for <see cref="EgressBytesTransferred" /> property.</summary>
        private long? _egressBytesTransferred;

        /// <summary>The egress bytes transferred in this connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? EgressBytesTransferred { get => this._egressBytesTransferred; }

        /// <summary>Backing field for <see cref="EnableBgp" /> property.</summary>
        private bool? _enableBgp;

        /// <summary>EnableBgp flag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? EnableBgp { get => this._enableBgp; set => this._enableBgp = value; }

        /// <summary>Backing field for <see cref="IngressBytesTransferred" /> property.</summary>
        private long? _ingressBytesTransferred;

        /// <summary>The ingress bytes transferred in this connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? IngressBytesTransferred { get => this._ingressBytesTransferred; }

        /// <summary>Backing field for <see cref="IpsecPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicy[] _ipsecPolicy;

        /// <summary>The IPSec Policies to be considered by this connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicy[] IpsecPolicy { get => this._ipsecPolicy; set => this._ipsecPolicy = value; }

        /// <summary>Backing field for <see cref="LocalNetworkGateway2" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReference _localNetworkGateway2;

        /// <summary>The reference to local network gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReference LocalNetworkGateway2 { get => (this._localNetworkGateway2 = this._localNetworkGateway2 ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkConnectionGatewayReference()); set => this._localNetworkGateway2 = value; }

        /// <summary>The ID of VirtualNetworkGateway or LocalNetworkGateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string LocalNetworkGateway2Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReferenceInternal)LocalNetworkGateway2).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReferenceInternal)LocalNetworkGateway2).Id = value; }

        /// <summary>Internal Acessors for ConnectionStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayConnectionListEntityPropertiesFormatInternal.ConnectionStatus { get => this._connectionStatus; set { {_connectionStatus = value;} } }

        /// <summary>Internal Acessors for EgressBytesTransferred</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayConnectionListEntityPropertiesFormatInternal.EgressBytesTransferred { get => this._egressBytesTransferred; set { {_egressBytesTransferred = value;} } }

        /// <summary>Internal Acessors for IngressBytesTransferred</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayConnectionListEntityPropertiesFormatInternal.IngressBytesTransferred { get => this._ingressBytesTransferred; set { {_ingressBytesTransferred = value;} } }

        /// <summary>Internal Acessors for LocalNetworkGateway2</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReference Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayConnectionListEntityPropertiesFormatInternal.LocalNetworkGateway2 { get => (this._localNetworkGateway2 = this._localNetworkGateway2 ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkConnectionGatewayReference()); set { {_localNetworkGateway2 = value;} } }

        /// <summary>Internal Acessors for Peer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayConnectionListEntityPropertiesFormatInternal.Peer { get => (this._peer = this._peer ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set { {_peer = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayConnectionListEntityPropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for TunnelConnectionStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITunnelConnectionHealth[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayConnectionListEntityPropertiesFormatInternal.TunnelConnectionStatus { get => this._tunnelConnectionStatus; set { {_tunnelConnectionStatus = value;} } }

        /// <summary>Internal Acessors for VnetGateway1</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReference Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayConnectionListEntityPropertiesFormatInternal.VnetGateway1 { get => (this._vnetGateway1 = this._vnetGateway1 ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkConnectionGatewayReference()); set { {_vnetGateway1 = value;} } }

        /// <summary>Internal Acessors for VnetGateway2</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReference Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayConnectionListEntityPropertiesFormatInternal.VnetGateway2 { get => (this._vnetGateway2 = this._vnetGateway2 ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkConnectionGatewayReference()); set { {_vnetGateway2 = value;} } }

        /// <summary>Backing field for <see cref="Peer" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource _peer;

        /// <summary>The reference to peerings resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Peer { get => (this._peer = this._peer ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set => this._peer = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PeerId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)Peer).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)Peer).Id = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The provisioning state of the VirtualNetworkGatewayConnection resource. Possible values are: 'Updating', 'Deleting', and
        /// 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="ResourceGuid" /> property.</summary>
        private string _resourceGuid;

        /// <summary>The resource GUID property of the VirtualNetworkGatewayConnection resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceGuid { get => this._resourceGuid; set => this._resourceGuid = value; }

        /// <summary>Backing field for <see cref="RoutingWeight" /> property.</summary>
        private int? _routingWeight;

        /// <summary>The routing weight.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? RoutingWeight { get => this._routingWeight; set => this._routingWeight = value; }

        /// <summary>Backing field for <see cref="SharedKey" /> property.</summary>
        private string _sharedKey;

        /// <summary>The IPSec shared key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SharedKey { get => this._sharedKey; set => this._sharedKey = value; }

        /// <summary>Backing field for <see cref="TunnelConnectionStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITunnelConnectionHealth[] _tunnelConnectionStatus;

        /// <summary>Collection of all tunnels' connection health status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITunnelConnectionHealth[] TunnelConnectionStatus { get => this._tunnelConnectionStatus; }

        /// <summary>Backing field for <see cref="UsePolicyBasedTrafficSelector" /> property.</summary>
        private bool? _usePolicyBasedTrafficSelector;

        /// <summary>Enable policy-based traffic selectors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? UsePolicyBasedTrafficSelector { get => this._usePolicyBasedTrafficSelector; set => this._usePolicyBasedTrafficSelector = value; }

        /// <summary>Backing field for <see cref="VnetGateway1" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReference _vnetGateway1;

        /// <summary>The reference to virtual network gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReference VnetGateway1 { get => (this._vnetGateway1 = this._vnetGateway1 ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkConnectionGatewayReference()); set => this._vnetGateway1 = value; }

        /// <summary>The ID of VirtualNetworkGateway or LocalNetworkGateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string VnetGateway1Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReferenceInternal)VnetGateway1).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReferenceInternal)VnetGateway1).Id = value; }

        /// <summary>Backing field for <see cref="VnetGateway2" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReference _vnetGateway2;

        /// <summary>The reference to virtual network gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReference VnetGateway2 { get => (this._vnetGateway2 = this._vnetGateway2 ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkConnectionGatewayReference()); set => this._vnetGateway2 = value; }

        /// <summary>The ID of VirtualNetworkGateway or LocalNetworkGateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string VnetGateway2Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReferenceInternal)VnetGateway2).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReferenceInternal)VnetGateway2).Id = value; }

        /// <summary>
        /// Creates an new <see cref="VirtualNetworkGatewayConnectionListEntityPropertiesFormat" /> instance.
        /// </summary>
        public VirtualNetworkGatewayConnectionListEntityPropertiesFormat()
        {

        }
    }
    /// VirtualNetworkGatewayConnection properties
    public partial interface IVirtualNetworkGatewayConnectionListEntityPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The authorizationKey.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The authorizationKey.",
        SerializedName = @"authorizationKey",
        PossibleTypes = new [] { typeof(string) })]
        string AuthorizationKey { get; set; }
        /// <summary>
        /// Virtual network Gateway connection status. Possible values are 'Unknown', 'Connecting', 'Connected' and 'NotConnected'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Virtual network Gateway connection status. Possible values are 'Unknown', 'Connecting', 'Connected' and 'NotConnected'.",
        SerializedName = @"connectionStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus? ConnectionStatus { get;  }
        /// <summary>
        /// Gateway connection type. Possible values are: 'IPsec','Vnet2Vnet','ExpressRoute', and 'VPNClient.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gateway connection type. Possible values are: 'IPsec','Vnet2Vnet','ExpressRoute', and 'VPNClient.",
        SerializedName = @"connectionType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType ConnectionType { get; set; }
        /// <summary>The egress bytes transferred in this connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The egress bytes transferred in this connection.",
        SerializedName = @"egressBytesTransferred",
        PossibleTypes = new [] { typeof(long) })]
        long? EgressBytesTransferred { get;  }
        /// <summary>EnableBgp flag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"EnableBgp flag",
        SerializedName = @"enableBgp",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableBgp { get; set; }
        /// <summary>The ingress bytes transferred in this connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The ingress bytes transferred in this connection.",
        SerializedName = @"ingressBytesTransferred",
        PossibleTypes = new [] { typeof(long) })]
        long? IngressBytesTransferred { get;  }
        /// <summary>The IPSec Policies to be considered by this connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IPSec Policies to be considered by this connection.",
        SerializedName = @"ipsecPolicies",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicy[] IpsecPolicy { get; set; }
        /// <summary>The ID of VirtualNetworkGateway or LocalNetworkGateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ID of VirtualNetworkGateway or LocalNetworkGateway resource.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string LocalNetworkGateway2Id { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string PeerId { get; set; }
        /// <summary>
        /// The provisioning state of the VirtualNetworkGatewayConnection resource. Possible values are: 'Updating', 'Deleting', and
        /// 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the VirtualNetworkGatewayConnection resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The resource GUID property of the VirtualNetworkGatewayConnection resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource GUID property of the VirtualNetworkGatewayConnection resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGuid { get; set; }
        /// <summary>The routing weight.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The routing weight.",
        SerializedName = @"routingWeight",
        PossibleTypes = new [] { typeof(int) })]
        int? RoutingWeight { get; set; }
        /// <summary>The IPSec shared key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IPSec shared key.",
        SerializedName = @"sharedKey",
        PossibleTypes = new [] { typeof(string) })]
        string SharedKey { get; set; }
        /// <summary>Collection of all tunnels' connection health status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Collection of all tunnels' connection health status.",
        SerializedName = @"tunnelConnectionStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITunnelConnectionHealth) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITunnelConnectionHealth[] TunnelConnectionStatus { get;  }
        /// <summary>Enable policy-based traffic selectors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable policy-based traffic selectors.",
        SerializedName = @"usePolicyBasedTrafficSelectors",
        PossibleTypes = new [] { typeof(bool) })]
        bool? UsePolicyBasedTrafficSelector { get; set; }
        /// <summary>The ID of VirtualNetworkGateway or LocalNetworkGateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ID of VirtualNetworkGateway or LocalNetworkGateway resource.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string VnetGateway1Id { get; set; }
        /// <summary>The ID of VirtualNetworkGateway or LocalNetworkGateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ID of VirtualNetworkGateway or LocalNetworkGateway resource.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string VnetGateway2Id { get; set; }

    }
    /// VirtualNetworkGatewayConnection properties
    internal partial interface IVirtualNetworkGatewayConnectionListEntityPropertiesFormatInternal

    {
        /// <summary>The authorizationKey.</summary>
        string AuthorizationKey { get; set; }
        /// <summary>
        /// Virtual network Gateway connection status. Possible values are 'Unknown', 'Connecting', 'Connected' and 'NotConnected'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus? ConnectionStatus { get; set; }
        /// <summary>
        /// Gateway connection type. Possible values are: 'IPsec','Vnet2Vnet','ExpressRoute', and 'VPNClient.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType ConnectionType { get; set; }
        /// <summary>The egress bytes transferred in this connection.</summary>
        long? EgressBytesTransferred { get; set; }
        /// <summary>EnableBgp flag</summary>
        bool? EnableBgp { get; set; }
        /// <summary>The ingress bytes transferred in this connection.</summary>
        long? IngressBytesTransferred { get; set; }
        /// <summary>The IPSec Policies to be considered by this connection.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpsecPolicy[] IpsecPolicy { get; set; }
        /// <summary>The reference to local network gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReference LocalNetworkGateway2 { get; set; }
        /// <summary>The ID of VirtualNetworkGateway or LocalNetworkGateway resource.</summary>
        string LocalNetworkGateway2Id { get; set; }
        /// <summary>The reference to peerings resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Peer { get; set; }
        /// <summary>Resource ID.</summary>
        string PeerId { get; set; }
        /// <summary>
        /// The provisioning state of the VirtualNetworkGatewayConnection resource. Possible values are: 'Updating', 'Deleting', and
        /// 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The resource GUID property of the VirtualNetworkGatewayConnection resource.</summary>
        string ResourceGuid { get; set; }
        /// <summary>The routing weight.</summary>
        int? RoutingWeight { get; set; }
        /// <summary>The IPSec shared key.</summary>
        string SharedKey { get; set; }
        /// <summary>Collection of all tunnels' connection health status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITunnelConnectionHealth[] TunnelConnectionStatus { get; set; }
        /// <summary>Enable policy-based traffic selectors.</summary>
        bool? UsePolicyBasedTrafficSelector { get; set; }
        /// <summary>The reference to virtual network gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReference VnetGateway1 { get; set; }
        /// <summary>The ID of VirtualNetworkGateway or LocalNetworkGateway resource.</summary>
        string VnetGateway1Id { get; set; }
        /// <summary>The reference to virtual network gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkConnectionGatewayReference VnetGateway2 { get; set; }
        /// <summary>The ID of VirtualNetworkGateway or LocalNetworkGateway resource.</summary>
        string VnetGateway2Id { get; set; }

    }
}