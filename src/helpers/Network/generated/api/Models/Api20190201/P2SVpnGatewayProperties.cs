namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters for P2SVpnGateway</summary>
    public partial class P2SVpnGatewayProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CustomRoute" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace _customRoute;

        /// <summary>
        /// The reference of the address space resource which represents the custom routes specified by the customer for P2SVpnGateway
        /// and P2S VpnClient.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace CustomRoute { get => (this._customRoute = this._customRoute ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpace()); set => this._customRoute = value; }

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] CustomRouteAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpaceInternal)CustomRoute).AddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpaceInternal)CustomRoute).AddressPrefix = value; }

        /// <summary>Internal Acessors for CustomRoute</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal.CustomRoute { get => (this._customRoute = this._customRoute ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpace()); set { {_customRoute = value;} } }

        /// <summary>Internal Acessors for P2SVpnServerConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal.P2SVpnServerConfiguration { get => (this._p2SVpnServerConfiguration = this._p2SVpnServerConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_p2SVpnServerConfiguration = value;} } }

        /// <summary>Internal Acessors for VirtualHub</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal.VirtualHub { get => (this._virtualHub = this._virtualHub ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_virtualHub = value;} } }

        /// <summary>Internal Acessors for VpnClientAddressPool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal.VpnClientAddressPool { get => (this._vpnClientAddressPool = this._vpnClientAddressPool ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpace()); set { {_vpnClientAddressPool = value;} } }

        /// <summary>Internal Acessors for VpnClientConnectionHealth</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealth Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal.VpnClientConnectionHealth { get => (this._vpnClientConnectionHealth = this._vpnClientConnectionHealth ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientConnectionHealth()); set { {_vpnClientConnectionHealth = value;} } }

        /// <summary>Internal Acessors for VpnClientConnectionHealthTotalEgressBytesTransferred</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal.VpnClientConnectionHealthTotalEgressBytesTransferred { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)VpnClientConnectionHealth).TotalEgressBytesTransferred; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)VpnClientConnectionHealth).TotalEgressBytesTransferred = value; }

        /// <summary>Internal Acessors for VpnClientConnectionHealthTotalIngressBytesTransferred</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal.VpnClientConnectionHealthTotalIngressBytesTransferred { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)VpnClientConnectionHealth).TotalIngressBytesTransferred; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)VpnClientConnectionHealth).TotalIngressBytesTransferred = value; }

        /// <summary>Backing field for <see cref="P2SVpnServerConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _p2SVpnServerConfiguration;

        /// <summary>The P2SVpnServerConfiguration to which the p2sVpnGateway is attached to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource P2SVpnServerConfiguration { get => (this._p2SVpnServerConfiguration = this._p2SVpnServerConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._p2SVpnServerConfiguration = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string P2SVpnServerConfigurationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)P2SVpnServerConfiguration).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)P2SVpnServerConfiguration).Id = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="VirtualHub" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _virtualHub;

        /// <summary>The VirtualHub to which the gateway belongs</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource VirtualHub { get => (this._virtualHub = this._virtualHub ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._virtualHub = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string VirtualHubId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)VirtualHub).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)VirtualHub).Id = value; }

        /// <summary>Backing field for <see cref="VpnClientAddressPool" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace _vpnClientAddressPool;

        /// <summary>
        /// The reference of the address space resource which represents Address space for P2S VpnClient.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace VpnClientAddressPool { get => (this._vpnClientAddressPool = this._vpnClientAddressPool ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpace()); set => this._vpnClientAddressPool = value; }

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] VpnClientAddressPoolAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpaceInternal)VpnClientAddressPool).AddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpaceInternal)VpnClientAddressPool).AddressPrefix = value; }

        /// <summary>Backing field for <see cref="VpnClientConnectionHealth" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealth _vpnClientConnectionHealth;

        /// <summary>All P2S VPN clients' connection health status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealth VpnClientConnectionHealth { get => (this._vpnClientConnectionHealth = this._vpnClientConnectionHealth ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientConnectionHealth()); }

        /// <summary>List of allocated ip addresses to the connected p2s vpn clients.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] VpnClientConnectionHealthAllocatedIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)VpnClientConnectionHealth).AllocatedIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)VpnClientConnectionHealth).AllocatedIPAddress = value; }

        /// <summary>Total of the Egress Bytes Transferred in this connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public long? VpnClientConnectionHealthTotalEgressBytesTransferred { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)VpnClientConnectionHealth).TotalEgressBytesTransferred; }

        /// <summary>Total of the Ingress Bytes Transferred in this P2S Vpn connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public long? VpnClientConnectionHealthTotalIngressBytesTransferred { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)VpnClientConnectionHealth).TotalIngressBytesTransferred; }

        /// <summary>The total of p2s vpn clients connected at this time to this P2SVpnGateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? VpnClientConnectionHealthVpnClientConnectionsCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)VpnClientConnectionHealth).VpnClientConnectionsCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)VpnClientConnectionHealth).VpnClientConnectionsCount = value; }

        /// <summary>Backing field for <see cref="VpnGatewayScaleUnit" /> property.</summary>
        private int? _vpnGatewayScaleUnit;

        /// <summary>The scale unit for this p2s vpn gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? VpnGatewayScaleUnit { get => this._vpnGatewayScaleUnit; set => this._vpnGatewayScaleUnit = value; }

        /// <summary>Creates an new <see cref="P2SVpnGatewayProperties" /> instance.</summary>
        public P2SVpnGatewayProperties()
        {

        }
    }
    /// Parameters for P2SVpnGateway
    public partial interface IP2SVpnGatewayProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of address blocks reserved for this virtual network in CIDR notation.",
        SerializedName = @"addressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] CustomRouteAddressPrefix { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string P2SVpnServerConfigurationId { get; set; }
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
        string VirtualHubId { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of address blocks reserved for this virtual network in CIDR notation.",
        SerializedName = @"addressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] VpnClientAddressPoolAddressPrefix { get; set; }
        /// <summary>List of allocated ip addresses to the connected p2s vpn clients.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of allocated ip addresses to the connected p2s vpn clients.",
        SerializedName = @"allocatedIpAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] VpnClientConnectionHealthAllocatedIPAddress { get; set; }
        /// <summary>Total of the Egress Bytes Transferred in this connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Total of the Egress Bytes Transferred in this connection",
        SerializedName = @"totalEgressBytesTransferred",
        PossibleTypes = new [] { typeof(long) })]
        long? VpnClientConnectionHealthTotalEgressBytesTransferred { get;  }
        /// <summary>Total of the Ingress Bytes Transferred in this P2S Vpn connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Total of the Ingress Bytes Transferred in this P2S Vpn connection",
        SerializedName = @"totalIngressBytesTransferred",
        PossibleTypes = new [] { typeof(long) })]
        long? VpnClientConnectionHealthTotalIngressBytesTransferred { get;  }
        /// <summary>The total of p2s vpn clients connected at this time to this P2SVpnGateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The total of p2s vpn clients connected at this time to this P2SVpnGateway.",
        SerializedName = @"vpnClientConnectionsCount",
        PossibleTypes = new [] { typeof(int) })]
        int? VpnClientConnectionHealthVpnClientConnectionsCount { get; set; }
        /// <summary>The scale unit for this p2s vpn gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The scale unit for this p2s vpn gateway.",
        SerializedName = @"vpnGatewayScaleUnit",
        PossibleTypes = new [] { typeof(int) })]
        int? VpnGatewayScaleUnit { get; set; }

    }
    /// Parameters for P2SVpnGateway
    internal partial interface IP2SVpnGatewayPropertiesInternal

    {
        /// <summary>
        /// The reference of the address space resource which represents the custom routes specified by the customer for P2SVpnGateway
        /// and P2S VpnClient.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace CustomRoute { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        string[] CustomRouteAddressPrefix { get; set; }
        /// <summary>The P2SVpnServerConfiguration to which the p2sVpnGateway is attached to.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource P2SVpnServerConfiguration { get; set; }
        /// <summary>Resource ID.</summary>
        string P2SVpnServerConfigurationId { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The VirtualHub to which the gateway belongs</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource VirtualHub { get; set; }
        /// <summary>Resource ID.</summary>
        string VirtualHubId { get; set; }
        /// <summary>
        /// The reference of the address space resource which represents Address space for P2S VpnClient.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace VpnClientAddressPool { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        string[] VpnClientAddressPoolAddressPrefix { get; set; }
        /// <summary>All P2S VPN clients' connection health status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealth VpnClientConnectionHealth { get; set; }
        /// <summary>List of allocated ip addresses to the connected p2s vpn clients.</summary>
        string[] VpnClientConnectionHealthAllocatedIPAddress { get; set; }
        /// <summary>Total of the Egress Bytes Transferred in this connection</summary>
        long? VpnClientConnectionHealthTotalEgressBytesTransferred { get; set; }
        /// <summary>Total of the Ingress Bytes Transferred in this P2S Vpn connection</summary>
        long? VpnClientConnectionHealthTotalIngressBytesTransferred { get; set; }
        /// <summary>The total of p2s vpn clients connected at this time to this P2SVpnGateway.</summary>
        int? VpnClientConnectionHealthVpnClientConnectionsCount { get; set; }
        /// <summary>The scale unit for this p2s vpn gateway.</summary>
        int? VpnGatewayScaleUnit { get; set; }

    }
}