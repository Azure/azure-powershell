namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>VpnConnection Resource.</summary>
    public partial class VpnConnection :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnection,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource();

        /// <summary>Expected bandwidth in MBPS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? ConnectionBandwidth { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).ConnectionBandwidth; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).ConnectionBandwidth = value; }

        /// <summary>The connection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus? ConnectionStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).ConnectionStatus; }

        /// <summary>Egress bytes transferred.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public long? EgressBytesTransferred { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).EgressBytesTransferred; }

        /// <summary>EnableBgp flag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? EnableBgp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).EnableBgp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).EnableBgp = value; }

        /// <summary>Enable internet security</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? EnableInternetSecurity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).EnableInternetSecurity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).EnableInternetSecurity = value; }

        /// <summary>EnableBgp flag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? EnableRateLimiting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).EnableRateLimiting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).EnableRateLimiting = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>Ingress bytes transferred.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public long? IngressBytesTransferred { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).IngressBytesTransferred; }

        /// <summary>The IPSec Policies to be considered by this connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] IpsecPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).IpsecPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).IpsecPolicy = value; }

        /// <summary>Internal Acessors for ConnectionStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionInternal.ConnectionStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).ConnectionStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).ConnectionStatus = value; }

        /// <summary>Internal Acessors for EgressBytesTransferred</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionInternal.EgressBytesTransferred { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).EgressBytesTransferred; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).EgressBytesTransferred = value; }

        /// <summary>Internal Acessors for Etag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionInternal.Etag { get => this._etag; set { {_etag = value;} } }

        /// <summary>Internal Acessors for IngressBytesTransferred</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionInternal.IngressBytesTransferred { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).IngressBytesTransferred; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).IngressBytesTransferred = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnConnectionProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for RemoteVpnSite</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionInternal.RemoteVpnSite { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).RemoteVpnSite; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).RemoteVpnSite = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionProperties _property;

        /// <summary>Properties of the VPN connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnConnectionProperties()); set => this._property = value; }

        /// <summary>Connection protocol used for this connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol? ProtocolType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).VpnConnectionProtocolType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).VpnConnectionProtocolType = value; }

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RemoteVpnSiteId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).RemoteVpnSiteId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).RemoteVpnSiteId = value; }

        /// <summary>Routing weight for vpn connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? RoutingWeight { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).RoutingWeight; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).RoutingWeight = value; }

        /// <summary>SharedKey for the vpn connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SharedKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).SharedKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).SharedKey = value; }

        /// <summary>Use local azure ip to initiate connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? UseLocalAzureIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).UseLocalAzureIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)Property).UseLocalAzureIPAddress = value; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__subResource), __subResource);
            await eventListener.AssertObjectIsValid(nameof(__subResource), __subResource);
        }

        /// <summary>Creates an new <see cref="VpnConnection" /> instance.</summary>
        public VpnConnection()
        {

        }
    }
    /// VpnConnection Resource.
    public partial interface IVpnConnection :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource
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
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get;  }
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
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the resource that is unique within a resource group. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Connection protocol used for this connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Connection protocol used for this connection",
        SerializedName = @"vpnConnectionProtocolType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol? ProtocolType { get; set; }
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

    }
    /// VpnConnection Resource.
    internal partial interface IVpnConnectionInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal
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
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>Ingress bytes transferred.</summary>
        long? IngressBytesTransferred { get; set; }
        /// <summary>The IPSec Policies to be considered by this connection.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[] IpsecPolicy { get; set; }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>Properties of the VPN connection.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionProperties Property { get; set; }
        /// <summary>Connection protocol used for this connection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol? ProtocolType { get; set; }
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

    }
}