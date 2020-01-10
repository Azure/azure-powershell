namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters for VirtualHub</summary>
    public partial class VirtualHubProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AddressPrefix" /> property.</summary>
        private string _addressPrefix;

        /// <summary>Address-prefix for this VirtualHub.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AddressPrefix { get => this._addressPrefix; set => this._addressPrefix = value; }

        /// <summary>Backing field for <see cref="ExpressRouteGateway" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _expressRouteGateway;

        /// <summary>The expressRouteGateway associated with this VirtualHub</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource ExpressRouteGateway { get => (this._expressRouteGateway = this._expressRouteGateway ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._expressRouteGateway = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ExpressRouteGatewayId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)ExpressRouteGateway).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)ExpressRouteGateway).Id = value; }

        /// <summary>Internal Acessors for ExpressRouteGateway</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal.ExpressRouteGateway { get => (this._expressRouteGateway = this._expressRouteGateway ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_expressRouteGateway = value;} } }

        /// <summary>Internal Acessors for P2SVpnGateway</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal.P2SVpnGateway { get => (this._p2SVpnGateway = this._p2SVpnGateway ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_p2SVpnGateway = value;} } }

        /// <summary>Internal Acessors for RouteTable</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRouteTable Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal.RouteTable { get => (this._routeTable = this._routeTable ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualHubRouteTable()); set { {_routeTable = value;} } }

        /// <summary>Internal Acessors for VirtualWan</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal.VirtualWan { get => (this._virtualWan = this._virtualWan ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_virtualWan = value;} } }

        /// <summary>Internal Acessors for VpnGateway</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubPropertiesInternal.VpnGateway { get => (this._vpnGateway = this._vpnGateway ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_vpnGateway = value;} } }

        /// <summary>Backing field for <see cref="P2SVpnGateway" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _p2SVpnGateway;

        /// <summary>The P2SVpnGateway associated with this VirtualHub</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource P2SVpnGateway { get => (this._p2SVpnGateway = this._p2SVpnGateway ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._p2SVpnGateway = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string P2SVpnGatewayId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)P2SVpnGateway).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)P2SVpnGateway).Id = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="RouteTable" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRouteTable _routeTable;

        /// <summary>The routeTable associated with this virtual hub.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRouteTable RouteTable { get => (this._routeTable = this._routeTable ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualHubRouteTable()); set => this._routeTable = value; }

        /// <summary>List of all routes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRoute[] RouteTableRoute { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRouteTableInternal)RouteTable).Route; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRouteTableInternal)RouteTable).Route = value; }

        /// <summary>Backing field for <see cref="VirtualWan" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _virtualWan;

        /// <summary>The VirtualWAN to which the VirtualHub belongs</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource VirtualWan { get => (this._virtualWan = this._virtualWan ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._virtualWan = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string VirtualWanId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)VirtualWan).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)VirtualWan).Id = value; }

        /// <summary>Backing field for <see cref="VnetConnection" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHubVirtualNetworkConnection[] _vnetConnection;

        /// <summary>List of all vnet connections with this VirtualHub.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHubVirtualNetworkConnection[] VnetConnection { get => this._vnetConnection; set => this._vnetConnection = value; }

        /// <summary>Backing field for <see cref="VpnGateway" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _vpnGateway;

        /// <summary>The VpnGateway associated with this VirtualHub</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource VpnGateway { get => (this._vpnGateway = this._vpnGateway ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._vpnGateway = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string VpnGatewayId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)VpnGateway).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)VpnGateway).Id = value; }

        /// <summary>Creates an new <see cref="VirtualHubProperties" /> instance.</summary>
        public VirtualHubProperties()
        {

        }
    }
    /// Parameters for VirtualHub
    public partial interface IVirtualHubProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Address-prefix for this VirtualHub.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Address-prefix for this VirtualHub.",
        SerializedName = @"addressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string AddressPrefix { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ExpressRouteGatewayId { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string P2SVpnGatewayId { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>List of all routes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of all routes.",
        SerializedName = @"routes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRoute) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRoute[] RouteTableRoute { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualWanId { get; set; }
        /// <summary>List of all vnet connections with this VirtualHub.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of all vnet connections with this VirtualHub.",
        SerializedName = @"virtualNetworkConnections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHubVirtualNetworkConnection) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHubVirtualNetworkConnection[] VnetConnection { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string VpnGatewayId { get; set; }

    }
    /// Parameters for VirtualHub
    internal partial interface IVirtualHubPropertiesInternal

    {
        /// <summary>Address-prefix for this VirtualHub.</summary>
        string AddressPrefix { get; set; }
        /// <summary>The expressRouteGateway associated with this VirtualHub</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource ExpressRouteGateway { get; set; }
        /// <summary>Resource ID.</summary>
        string ExpressRouteGatewayId { get; set; }
        /// <summary>The P2SVpnGateway associated with this VirtualHub</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource P2SVpnGateway { get; set; }
        /// <summary>Resource ID.</summary>
        string P2SVpnGatewayId { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The routeTable associated with this virtual hub.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRouteTable RouteTable { get; set; }
        /// <summary>List of all routes.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualHubRoute[] RouteTableRoute { get; set; }
        /// <summary>The VirtualWAN to which the VirtualHub belongs</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource VirtualWan { get; set; }
        /// <summary>Resource ID.</summary>
        string VirtualWanId { get; set; }
        /// <summary>List of all vnet connections with this VirtualHub.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHubVirtualNetworkConnection[] VnetConnection { get; set; }
        /// <summary>The VpnGateway associated with this VirtualHub</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource VpnGateway { get; set; }
        /// <summary>Resource ID.</summary>
        string VpnGatewayId { get; set; }

    }
}