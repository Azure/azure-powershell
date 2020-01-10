namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the virtual network peering.</summary>
    public partial class VirtualNetworkPeeringPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="AllowForwardedTraffic" /> property.</summary>
        private bool? _allowForwardedTraffic;

        /// <summary>
        /// Whether the forwarded traffic from the VMs in the local virtual network will be allowed/disallowed in remote virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? AllowForwardedTraffic { get => this._allowForwardedTraffic; set => this._allowForwardedTraffic = value; }

        /// <summary>Backing field for <see cref="AllowGatewayTransit" /> property.</summary>
        private bool? _allowGatewayTransit;

        /// <summary>
        /// If gateway links can be used in remote virtual networking to link to this virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? AllowGatewayTransit { get => this._allowGatewayTransit; set => this._allowGatewayTransit = value; }

        /// <summary>Backing field for <see cref="AllowVnetAccess" /> property.</summary>
        private bool? _allowVnetAccess;

        /// <summary>
        /// Whether the VMs in the local virtual network space would be able to access the VMs in remote virtual network space.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? AllowVnetAccess { get => this._allowVnetAccess; set => this._allowVnetAccess = value; }

        /// <summary>Internal Acessors for RemoteAddressSpace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal.RemoteAddressSpace { get => (this._remoteAddressSpace = this._remoteAddressSpace ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpace()); set { {_remoteAddressSpace = value;} } }

        /// <summary>Internal Acessors for RemoteVnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeeringPropertiesFormatInternal.RemoteVnet { get => (this._remoteVnet = this._remoteVnet ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_remoteVnet = value;} } }

        /// <summary>Backing field for <see cref="PeeringState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState? _peeringState;

        /// <summary>
        /// The status of the virtual network peering. Possible values are 'Initiated', 'Connected', and 'Disconnected'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState? PeeringState { get => this._peeringState; set => this._peeringState = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="RemoteAddressSpace" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace _remoteAddressSpace;

        /// <summary>The reference of the remote virtual network address space.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace RemoteAddressSpace { get => (this._remoteAddressSpace = this._remoteAddressSpace ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpace()); set => this._remoteAddressSpace = value; }

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] RemoteAddressSpaceAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpaceInternal)RemoteAddressSpace).AddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpaceInternal)RemoteAddressSpace).AddressPrefix = value; }

        /// <summary>Backing field for <see cref="RemoteVnet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _remoteVnet;

        /// <summary>
        /// The reference of the remote virtual network. The remote virtual network can be in the same or different region (preview).
        /// See here to register for the preview and learn more (https://docs.microsoft.com/en-us/azure/virtual-network/virtual-network-create-peering).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource RemoteVnet { get => (this._remoteVnet = this._remoteVnet ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._remoteVnet = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RemoteVnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)RemoteVnet).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)RemoteVnet).Id = value; }

        /// <summary>Backing field for <see cref="UseRemoteGateway" /> property.</summary>
        private bool? _useRemoteGateway;

        /// <summary>
        /// If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote
        /// peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have
        /// this flag set to true. This flag cannot be set if virtual network already has a gateway.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? UseRemoteGateway { get => this._useRemoteGateway; set => this._useRemoteGateway = value; }

        /// <summary>Creates an new <see cref="VirtualNetworkPeeringPropertiesFormat" /> instance.</summary>
        public VirtualNetworkPeeringPropertiesFormat()
        {

        }
    }
    /// Properties of the virtual network peering.
    public partial interface IVirtualNetworkPeeringPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Whether the forwarded traffic from the VMs in the local virtual network will be allowed/disallowed in remote virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the forwarded traffic from the VMs in the local virtual network will be allowed/disallowed in remote virtual network.",
        SerializedName = @"allowForwardedTraffic",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowForwardedTraffic { get; set; }
        /// <summary>
        /// If gateway links can be used in remote virtual networking to link to this virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If gateway links can be used in remote virtual networking to link to this virtual network.",
        SerializedName = @"allowGatewayTransit",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowGatewayTransit { get; set; }
        /// <summary>
        /// Whether the VMs in the local virtual network space would be able to access the VMs in remote virtual network space.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the VMs in the local virtual network space would be able to access the VMs in remote virtual network space.",
        SerializedName = @"allowVirtualNetworkAccess",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowVnetAccess { get; set; }
        /// <summary>
        /// The status of the virtual network peering. Possible values are 'Initiated', 'Connected', and 'Disconnected'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The status of the virtual network peering. Possible values are 'Initiated', 'Connected', and 'Disconnected'.",
        SerializedName = @"peeringState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState? PeeringState { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of address blocks reserved for this virtual network in CIDR notation.",
        SerializedName = @"addressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] RemoteAddressSpaceAddressPrefix { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string RemoteVnetId { get; set; }
        /// <summary>
        /// If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote
        /// peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have
        /// this flag set to true. This flag cannot be set if virtual network already has a gateway.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have this flag set to true. This flag cannot be set if virtual network already has a gateway.",
        SerializedName = @"useRemoteGateways",
        PossibleTypes = new [] { typeof(bool) })]
        bool? UseRemoteGateway { get; set; }

    }
    /// Properties of the virtual network peering.
    internal partial interface IVirtualNetworkPeeringPropertiesFormatInternal

    {
        /// <summary>
        /// Whether the forwarded traffic from the VMs in the local virtual network will be allowed/disallowed in remote virtual network.
        /// </summary>
        bool? AllowForwardedTraffic { get; set; }
        /// <summary>
        /// If gateway links can be used in remote virtual networking to link to this virtual network.
        /// </summary>
        bool? AllowGatewayTransit { get; set; }
        /// <summary>
        /// Whether the VMs in the local virtual network space would be able to access the VMs in remote virtual network space.
        /// </summary>
        bool? AllowVnetAccess { get; set; }
        /// <summary>
        /// The status of the virtual network peering. Possible values are 'Initiated', 'Connected', and 'Disconnected'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState? PeeringState { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        string ProvisioningState { get; set; }
        /// <summary>The reference of the remote virtual network address space.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace RemoteAddressSpace { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        string[] RemoteAddressSpaceAddressPrefix { get; set; }
        /// <summary>
        /// The reference of the remote virtual network. The remote virtual network can be in the same or different region (preview).
        /// See here to register for the preview and learn more (https://docs.microsoft.com/en-us/azure/virtual-network/virtual-network-create-peering).
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource RemoteVnet { get; set; }
        /// <summary>Resource ID.</summary>
        string RemoteVnetId { get; set; }
        /// <summary>
        /// If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote
        /// peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have
        /// this flag set to true. This flag cannot be set if virtual network already has a gateway.
        /// </summary>
        bool? UseRemoteGateway { get; set; }

    }
}