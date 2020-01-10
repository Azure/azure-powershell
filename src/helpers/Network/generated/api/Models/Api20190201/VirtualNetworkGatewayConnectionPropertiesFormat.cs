namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>VirtualNetworkGatewayConnection properties</summary>
    public partial class VirtualNetworkGatewayConnectionPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnectionPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnectionPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="AuthorizationKey" /> property.</summary>
        private string _authorizationKey;

        /// <summary>The authorizationKey.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AuthorizationKey { get => this._authorizationKey; set => this._authorizationKey = value; }

        /// <summary>The BGP speaker's ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public long? BgpSettingAsn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).BgpAsn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).BgpAsn = value; }

        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string BgpSettingBgpPeeringAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).BgpPeeringAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).BgpPeeringAddress = value; }

        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? BgpSettingPeerWeight { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).BgpPeerWeight; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).BgpPeerWeight = value; }

        /// <summary>Backing field for <see cref="ConnectionProtocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol? _connectionProtocol;

        /// <summary>Connection protocol used for this connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol? ConnectionProtocol { get => this._connectionProtocol; set => this._connectionProtocol = value; }

        /// <summary>Backing field for <see cref="ConnectionStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus? _connectionStatus;

        /// <summary>Virtual Network Gateway connection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus? ConnectionStatus { get => this._connectionStatus; }

        /// <summary>Backing field for <see cref="ConnectionType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType _connectionType;

        /// <summary>Gateway connection type.</summary>
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

        /// <summary>Backing field for <see cref="ExpressRouteGatewayBypass" /> property.</summary>
        private bool? _expressRouteGatewayBypass;

        /// <summary>Bypass ExpressRoute Gateway for data forwarding</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? ExpressRouteGatewayBypass { get => this._expressRouteGatewayBypass; set => this._expressRouteGatewayBypass = value; }

        /// <summary>IP address of local network gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string GatewayIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).GatewayIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).GatewayIPAddress = value; }

        /// <summary>Backing field for <see cref="IngressBytesTransferred" /> property.</summary>
        private long? _ingressBytesTransferred;

        /// <summary>The ingress bytes transferred in this connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? IngressBytesTransferred { get => this._ingressBytesTransferred; }

        /// <summary>Backing field for <see cref="IpsecPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] _ipsecPolicy;

        /// <summary>The IPSec Policies to be considered by this connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] IpsecPolicy { get => this._ipsecPolicy; set => this._ipsecPolicy = value; }

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] LocalNetworkAddressSpaceAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).AddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).AddressPrefix = value; }

        /// <summary>Backing field for <see cref="LocalNetworkGateway2" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGateway _localNetworkGateway2;

        /// <summary>The reference to local network gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGateway LocalNetworkGateway2 { get => (this._localNetworkGateway2 = this._localNetworkGateway2 ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LocalNetworkGateway()); set => this._localNetworkGateway2 = value; }

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string LocalNetworkGateway2Etag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).Etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string LocalNetworkGateway2Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)LocalNetworkGateway2).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)LocalNetworkGateway2).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string LocalNetworkGateway2Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)LocalNetworkGateway2).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)LocalNetworkGateway2).Location = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string LocalNetworkGateway2Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)LocalNetworkGateway2).Name; }

        /// <summary>
        /// The provisioning state of the LocalNetworkGateway resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string LocalNetworkGateway2PropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).ProvisioningState; }

        /// <summary>The resource GUID property of the LocalNetworkGateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string LocalNetworkGateway2PropertiesResourceGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).ResourceGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).ResourceGuid = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags LocalNetworkGateway2Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)LocalNetworkGateway2).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)LocalNetworkGateway2).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string LocalNetworkGateway2Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)LocalNetworkGateway2).Type; }

        /// <summary>Internal Acessors for BgpSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnectionPropertiesFormatInternal.BgpSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).BgpSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).BgpSetting = value; }

        /// <summary>Internal Acessors for ConnectionStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnectionPropertiesFormatInternal.ConnectionStatus { get => this._connectionStatus; set { {_connectionStatus = value;} } }

        /// <summary>Internal Acessors for EgressBytesTransferred</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnectionPropertiesFormatInternal.EgressBytesTransferred { get => this._egressBytesTransferred; set { {_egressBytesTransferred = value;} } }

        /// <summary>Internal Acessors for IngressBytesTransferred</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnectionPropertiesFormatInternal.IngressBytesTransferred { get => this._ingressBytesTransferred; set { {_ingressBytesTransferred = value;} } }

        /// <summary>Internal Acessors for LocalNetworkAddressSpace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnectionPropertiesFormatInternal.LocalNetworkAddressSpace { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).LocalNetworkAddressSpace; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).LocalNetworkAddressSpace = value; }

        /// <summary>Internal Acessors for LocalNetworkGateway2</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGateway Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnectionPropertiesFormatInternal.LocalNetworkGateway2 { get => (this._localNetworkGateway2 = this._localNetworkGateway2 ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LocalNetworkGateway()); set { {_localNetworkGateway2 = value;} } }

        /// <summary>Internal Acessors for LocalNetworkGateway2Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnectionPropertiesFormatInternal.LocalNetworkGateway2Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)LocalNetworkGateway2).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)LocalNetworkGateway2).Name = value; }

        /// <summary>Internal Acessors for LocalNetworkGateway2PropertiesProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnectionPropertiesFormatInternal.LocalNetworkGateway2PropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).ProvisioningState = value; }

        /// <summary>Internal Acessors for LocalNetworkGateway2Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnectionPropertiesFormatInternal.LocalNetworkGateway2Property { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayInternal)LocalNetworkGateway2).Property = value; }

        /// <summary>Internal Acessors for LocalNetworkGateway2Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnectionPropertiesFormatInternal.LocalNetworkGateway2Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)LocalNetworkGateway2).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)LocalNetworkGateway2).Type = value; }

        /// <summary>Internal Acessors for Peer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnectionPropertiesFormatInternal.Peer { get => (this._peer = this._peer ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_peer = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnectionPropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for TunnelConnectionStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITunnelConnectionHealth[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGatewayConnectionPropertiesFormatInternal.TunnelConnectionStatus { get => this._tunnelConnectionStatus; set { {_tunnelConnectionStatus = value;} } }

        /// <summary>Backing field for <see cref="Peer" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _peer;

        /// <summary>The reference to peerings resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Peer { get => (this._peer = this._peer ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._peer = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PeerId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)Peer).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)Peer).Id = value; }

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
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITunnelConnectionHealth[] _tunnelConnectionStatus;

        /// <summary>Collection of all tunnels' connection health status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITunnelConnectionHealth[] TunnelConnectionStatus { get => this._tunnelConnectionStatus; }

        /// <summary>Backing field for <see cref="UsePolicyBasedTrafficSelector" /> property.</summary>
        private bool? _usePolicyBasedTrafficSelector;

        /// <summary>Enable policy-based traffic selectors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? UsePolicyBasedTrafficSelector { get => this._usePolicyBasedTrafficSelector; set => this._usePolicyBasedTrafficSelector = value; }

        /// <summary>Backing field for <see cref="VnetGateway1" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway _vnetGateway1;

        /// <summary>The reference to virtual network gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway VnetGateway1 { get => (this._vnetGateway1 = this._vnetGateway1 ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualNetworkGateway()); set => this._vnetGateway1 = value; }

        /// <summary>Backing field for <see cref="VnetGateway2" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway _vnetGateway2;

        /// <summary>The reference to virtual network gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway VnetGateway2 { get => (this._vnetGateway2 = this._vnetGateway2 ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualNetworkGateway()); set => this._vnetGateway2 = value; }

        /// <summary>
        /// Creates an new <see cref="VirtualNetworkGatewayConnectionPropertiesFormat" /> instance.
        /// </summary>
        public VirtualNetworkGatewayConnectionPropertiesFormat()
        {

        }
    }
    /// VirtualNetworkGatewayConnection properties
    public partial interface IVirtualNetworkGatewayConnectionPropertiesFormat :
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
        /// <summary>The BGP speaker's ASN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The BGP speaker's ASN.",
        SerializedName = @"asn",
        PossibleTypes = new [] { typeof(long) })]
        long? BgpSettingAsn { get; set; }
        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The BGP peering address and BGP identifier of this BGP speaker.",
        SerializedName = @"bgpPeeringAddress",
        PossibleTypes = new [] { typeof(string) })]
        string BgpSettingBgpPeeringAddress { get; set; }
        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The weight added to routes learned from this BGP speaker.",
        SerializedName = @"peerWeight",
        PossibleTypes = new [] { typeof(int) })]
        int? BgpSettingPeerWeight { get; set; }
        /// <summary>Connection protocol used for this connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Connection protocol used for this connection",
        SerializedName = @"connectionProtocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol? ConnectionProtocol { get; set; }
        /// <summary>Virtual Network Gateway connection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Virtual Network Gateway connection status.",
        SerializedName = @"connectionStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus? ConnectionStatus { get;  }
        /// <summary>Gateway connection type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gateway connection type.",
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
        /// <summary>Bypass ExpressRoute Gateway for data forwarding</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Bypass ExpressRoute Gateway for data forwarding",
        SerializedName = @"expressRouteGatewayBypass",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ExpressRouteGatewayBypass { get; set; }
        /// <summary>IP address of local network gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP address of local network gateway.",
        SerializedName = @"gatewayIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string GatewayIPAddress { get; set; }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] IpsecPolicy { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of address blocks reserved for this virtual network in CIDR notation.",
        SerializedName = @"addressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] LocalNetworkAddressSpaceAddressPrefix { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string LocalNetworkGateway2Etag { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string LocalNetworkGateway2Id { get; set; }
        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string LocalNetworkGateway2Location { get; set; }
        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string LocalNetworkGateway2Name { get;  }
        /// <summary>
        /// The provisioning state of the LocalNetworkGateway resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the LocalNetworkGateway resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string LocalNetworkGateway2PropertiesProvisioningState { get;  }
        /// <summary>The resource GUID property of the LocalNetworkGateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource GUID property of the LocalNetworkGateway resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string LocalNetworkGateway2PropertiesResourceGuid { get; set; }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags LocalNetworkGateway2Tag { get; set; }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string LocalNetworkGateway2Type { get;  }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITunnelConnectionHealth) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITunnelConnectionHealth[] TunnelConnectionStatus { get;  }
        /// <summary>Enable policy-based traffic selectors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable policy-based traffic selectors.",
        SerializedName = @"usePolicyBasedTrafficSelectors",
        PossibleTypes = new [] { typeof(bool) })]
        bool? UsePolicyBasedTrafficSelector { get; set; }
        /// <summary>The reference to virtual network gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The reference to virtual network gateway resource.",
        SerializedName = @"virtualNetworkGateway1",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway VnetGateway1 { get; set; }
        /// <summary>The reference to virtual network gateway resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference to virtual network gateway resource.",
        SerializedName = @"virtualNetworkGateway2",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway VnetGateway2 { get; set; }

    }
    /// VirtualNetworkGatewayConnection properties
    internal partial interface IVirtualNetworkGatewayConnectionPropertiesFormatInternal

    {
        /// <summary>The authorizationKey.</summary>
        string AuthorizationKey { get; set; }
        /// <summary>Local network gateway's BGP speaker settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpSettings BgpSetting { get; set; }
        /// <summary>The BGP speaker's ASN.</summary>
        long? BgpSettingAsn { get; set; }
        /// <summary>The BGP peering address and BGP identifier of this BGP speaker.</summary>
        string BgpSettingBgpPeeringAddress { get; set; }
        /// <summary>The weight added to routes learned from this BGP speaker.</summary>
        int? BgpSettingPeerWeight { get; set; }
        /// <summary>Connection protocol used for this connection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol? ConnectionProtocol { get; set; }
        /// <summary>Virtual Network Gateway connection status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionStatus? ConnectionStatus { get; set; }
        /// <summary>Gateway connection type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionType ConnectionType { get; set; }
        /// <summary>The egress bytes transferred in this connection.</summary>
        long? EgressBytesTransferred { get; set; }
        /// <summary>EnableBgp flag</summary>
        bool? EnableBgp { get; set; }
        /// <summary>Bypass ExpressRoute Gateway for data forwarding</summary>
        bool? ExpressRouteGatewayBypass { get; set; }
        /// <summary>IP address of local network gateway.</summary>
        string GatewayIPAddress { get; set; }
        /// <summary>The ingress bytes transferred in this connection.</summary>
        long? IngressBytesTransferred { get; set; }
        /// <summary>The IPSec Policies to be considered by this connection.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] IpsecPolicy { get; set; }
        /// <summary>Local network site address space.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace LocalNetworkAddressSpace { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        string[] LocalNetworkAddressSpaceAddressPrefix { get; set; }
        /// <summary>The reference to local network gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGateway LocalNetworkGateway2 { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string LocalNetworkGateway2Etag { get; set; }
        /// <summary>Resource ID.</summary>
        string LocalNetworkGateway2Id { get; set; }
        /// <summary>Resource location.</summary>
        string LocalNetworkGateway2Location { get; set; }
        /// <summary>Resource name.</summary>
        string LocalNetworkGateway2Name { get; set; }
        /// <summary>
        /// The provisioning state of the LocalNetworkGateway resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string LocalNetworkGateway2PropertiesProvisioningState { get; set; }
        /// <summary>The resource GUID property of the LocalNetworkGateway resource.</summary>
        string LocalNetworkGateway2PropertiesResourceGuid { get; set; }
        /// <summary>Properties of the local network gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILocalNetworkGatewayPropertiesFormat LocalNetworkGateway2Property { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags LocalNetworkGateway2Tag { get; set; }
        /// <summary>Resource type.</summary>
        string LocalNetworkGateway2Type { get; set; }
        /// <summary>The reference to peerings resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Peer { get; set; }
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
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITunnelConnectionHealth[] TunnelConnectionStatus { get; set; }
        /// <summary>Enable policy-based traffic selectors.</summary>
        bool? UsePolicyBasedTrafficSelector { get; set; }
        /// <summary>The reference to virtual network gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway VnetGateway1 { get; set; }
        /// <summary>The reference to virtual network gateway resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkGateway VnetGateway2 { get; set; }

    }
}