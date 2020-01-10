namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters for VpnConnection</summary>
    public partial class VpnConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ConnectionBandwidth" /> property.</summary>
        private int? _connectionBandwidth;

        /// <summary>Expected bandwidth in MBPS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? ConnectionBandwidth { get => this._connectionBandwidth; set => this._connectionBandwidth = value; }

        /// <summary>Backing field for <see cref="ConnectionStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus? _connectionStatus;

        /// <summary>The connection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus? ConnectionStatus { get => this._connectionStatus; }

        /// <summary>Backing field for <see cref="EgressBytesTransferred" /> property.</summary>
        private long? _egressBytesTransferred;

        /// <summary>Egress bytes transferred.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? EgressBytesTransferred { get => this._egressBytesTransferred; }

        /// <summary>Backing field for <see cref="EnableBgp" /> property.</summary>
        private bool? _enableBgp;

        /// <summary>EnableBgp flag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? EnableBgp { get => this._enableBgp; set => this._enableBgp = value; }

        /// <summary>Backing field for <see cref="EnableInternetSecurity" /> property.</summary>
        private bool? _enableInternetSecurity;

        /// <summary>Enable internet security</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? EnableInternetSecurity { get => this._enableInternetSecurity; set => this._enableInternetSecurity = value; }

        /// <summary>Backing field for <see cref="EnableRateLimiting" /> property.</summary>
        private bool? _enableRateLimiting;

        /// <summary>EnableBgp flag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? EnableRateLimiting { get => this._enableRateLimiting; set => this._enableRateLimiting = value; }

        /// <summary>Backing field for <see cref="IngressBytesTransferred" /> property.</summary>
        private long? _ingressBytesTransferred;

        /// <summary>Ingress bytes transferred.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? IngressBytesTransferred { get => this._ingressBytesTransferred; }

        /// <summary>Backing field for <see cref="IpsecPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] _ipsecPolicy;

        /// <summary>The IPSec Policies to be considered by this connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] IpsecPolicy { get => this._ipsecPolicy; set => this._ipsecPolicy = value; }

        /// <summary>Internal Acessors for ConnectionStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal.ConnectionStatus { get => this._connectionStatus; set { {_connectionStatus = value;} } }

        /// <summary>Internal Acessors for EgressBytesTransferred</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal.EgressBytesTransferred { get => this._egressBytesTransferred; set { {_egressBytesTransferred = value;} } }

        /// <summary>Internal Acessors for IngressBytesTransferred</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal.IngressBytesTransferred { get => this._ingressBytesTransferred; set { {_ingressBytesTransferred = value;} } }

        /// <summary>Internal Acessors for RemoteVpnSite</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal.RemoteVpnSite { get => (this._remoteVpnSite = this._remoteVpnSite ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_remoteVpnSite = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="RemoteVpnSite" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _remoteVpnSite;

        /// <summary>Id of the connected vpn site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource RemoteVpnSite { get => (this._remoteVpnSite = this._remoteVpnSite ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._remoteVpnSite = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RemoteVpnSiteId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)RemoteVpnSite).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)RemoteVpnSite).Id = value; }

        /// <summary>Backing field for <see cref="RoutingWeight" /> property.</summary>
        private int? _routingWeight;

        /// <summary>Routing weight for vpn connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? RoutingWeight { get => this._routingWeight; set => this._routingWeight = value; }

        /// <summary>Backing field for <see cref="SharedKey" /> property.</summary>
        private string _sharedKey;

        /// <summary>SharedKey for the vpn connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SharedKey { get => this._sharedKey; set => this._sharedKey = value; }

        /// <summary>Backing field for <see cref="UseLocalAzureIPAddress" /> property.</summary>
        private bool? _useLocalAzureIPAddress;

        /// <summary>Use local azure ip to initiate connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? UseLocalAzureIPAddress { get => this._useLocalAzureIPAddress; set => this._useLocalAzureIPAddress = value; }

        /// <summary>Backing field for <see cref="VpnConnectionProtocolType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol? _vpnConnectionProtocolType;

        /// <summary>Connection protocol used for this connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol? VpnConnectionProtocolType { get => this._vpnConnectionProtocolType; set => this._vpnConnectionProtocolType = value; }

        /// <summary>Creates an new <see cref="VpnConnectionProperties" /> instance.</summary>
        public VpnConnectionProperties()
        {

        }
    }
    /// Parameters for VpnConnection
    public partial interface IVpnConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Expected bandwidth in MBPS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Expected bandwidth in MBPS.",
        SerializedName = @"connectionBandwidth",
        PossibleTypes = new [] { typeof(int) })]
        int? ConnectionBandwidth { get; set; }
        /// <summary>The connection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The connection status.",
        SerializedName = @"connectionStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus? ConnectionStatus { get;  }
        /// <summary>Egress bytes transferred.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Egress bytes transferred.",
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
        /// <summary>Enable internet security</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable internet security",
        SerializedName = @"enableInternetSecurity",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableInternetSecurity { get; set; }
        /// <summary>EnableBgp flag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"EnableBgp flag",
        SerializedName = @"enableRateLimiting",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableRateLimiting { get; set; }
        /// <summary>Ingress bytes transferred.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Ingress bytes transferred.",
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
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string RemoteVpnSiteId { get; set; }
        /// <summary>Routing weight for vpn connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Routing weight for vpn connection.",
        SerializedName = @"routingWeight",
        PossibleTypes = new [] { typeof(int) })]
        int? RoutingWeight { get; set; }
        /// <summary>SharedKey for the vpn connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SharedKey for the vpn connection.",
        SerializedName = @"sharedKey",
        PossibleTypes = new [] { typeof(string) })]
        string SharedKey { get; set; }
        /// <summary>Use local azure ip to initiate connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Use local azure ip to initiate connection",
        SerializedName = @"useLocalAzureIpAddress",
        PossibleTypes = new [] { typeof(bool) })]
        bool? UseLocalAzureIPAddress { get; set; }
        /// <summary>Connection protocol used for this connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Connection protocol used for this connection",
        SerializedName = @"vpnConnectionProtocolType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol? VpnConnectionProtocolType { get; set; }

    }
    /// Parameters for VpnConnection
    internal partial interface IVpnConnectionPropertiesInternal

    {
        /// <summary>Expected bandwidth in MBPS.</summary>
        int? ConnectionBandwidth { get; set; }
        /// <summary>The connection status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus? ConnectionStatus { get; set; }
        /// <summary>Egress bytes transferred.</summary>
        long? EgressBytesTransferred { get; set; }
        /// <summary>EnableBgp flag</summary>
        bool? EnableBgp { get; set; }
        /// <summary>Enable internet security</summary>
        bool? EnableInternetSecurity { get; set; }
        /// <summary>EnableBgp flag</summary>
        bool? EnableRateLimiting { get; set; }
        /// <summary>Ingress bytes transferred.</summary>
        long? IngressBytesTransferred { get; set; }
        /// <summary>The IPSec Policies to be considered by this connection.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] IpsecPolicy { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Id of the connected vpn site.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource RemoteVpnSite { get; set; }
        /// <summary>Resource ID.</summary>
        string RemoteVpnSiteId { get; set; }
        /// <summary>Routing weight for vpn connection.</summary>
        int? RoutingWeight { get; set; }
        /// <summary>SharedKey for the vpn connection.</summary>
        string SharedKey { get; set; }
        /// <summary>Use local azure ip to initiate connection</summary>
        bool? UseLocalAzureIPAddress { get; set; }
        /// <summary>Connection protocol used for this connection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol? VpnConnectionProtocolType { get; set; }

    }
}