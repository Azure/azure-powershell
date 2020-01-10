namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Peerings in a virtual network resource.</summary>
    public partial class VirtualNetworkPeering :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeering,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource();

        /// <summary>
        /// Whether the forwarded traffic from the VMs in the remote virtual network will be allowed/disallowed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? AllowForwardedTraffic { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).AllowForwardedTraffic; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).AllowForwardedTraffic = value; }

        /// <summary>
        /// If gateway links can be used in remote virtual networking to link to this virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? AllowGatewayTransit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).AllowGatewayTransit; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).AllowGatewayTransit = value; }

        /// <summary>
        /// Whether the VMs in the linked virtual network space would be able to access all the VMs in local Virtual network space.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? AllowVnetAccess { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).AllowVnetAccess; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).AllowVnetAccess = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkPeeringPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for RemoteAddressSpace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAddressSpace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringInternal.RemoteAddressSpace { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).RemoteAddressSpace; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).RemoteAddressSpace = value; }

        /// <summary>Internal Acessors for RemoteVnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringInternal.RemoteVnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).RemoteVnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).RemoteVnet = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>
        /// The status of the virtual network peering. Possible values are 'Initiated', 'Connected', and 'Disconnected'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState? PeeringState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).PeeringState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).PeeringState = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormat _property;

        /// <summary>Properties of the virtual network peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkPeeringPropertiesFormat()); set => this._property = value; }

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] RemoteAddressSpaceAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).RemoteAddressSpaceAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).RemoteAddressSpaceAddressPrefix = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string RemoteVnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).RemoteVnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).RemoteVnetId = value; }

        /// <summary>
        /// If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote
        /// peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have
        /// this flag set to true. This flag cannot be set if virtual network already has a gateway.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? UseRemoteGateway { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).UseRemoteGateway; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormatInternal)Property).UseRemoteGateway = value; }

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

        /// <summary>Creates an new <see cref="VirtualNetworkPeering" /> instance.</summary>
        public VirtualNetworkPeering()
        {

        }
    }
    /// Peerings in a virtual network resource.
    public partial interface IVirtualNetworkPeering :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource
    {
        /// <summary>
        /// Whether the forwarded traffic from the VMs in the remote virtual network will be allowed/disallowed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the forwarded traffic from the VMs in the remote virtual network will be allowed/disallowed.",
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
        /// Whether the VMs in the linked virtual network space would be able to access all the VMs in local Virtual network space.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the VMs in the linked virtual network space would be able to access all the VMs in local Virtual network space.",
        SerializedName = @"allowVirtualNetworkAccess",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowVnetAccess { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
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
    /// Peerings in a virtual network resource.
    internal partial interface IVirtualNetworkPeeringInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal
    {
        /// <summary>
        /// Whether the forwarded traffic from the VMs in the remote virtual network will be allowed/disallowed.
        /// </summary>
        bool? AllowForwardedTraffic { get; set; }
        /// <summary>
        /// If gateway links can be used in remote virtual networking to link to this virtual network.
        /// </summary>
        bool? AllowGatewayTransit { get; set; }
        /// <summary>
        /// Whether the VMs in the linked virtual network space would be able to access all the VMs in local Virtual network space.
        /// </summary>
        bool? AllowVnetAccess { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The status of the virtual network peering. Possible values are 'Initiated', 'Connected', and 'Disconnected'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkPeeringState? PeeringState { get; set; }
        /// <summary>Properties of the virtual network peering.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkPeeringPropertiesFormat Property { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        string ProvisioningState { get; set; }
        /// <summary>The reference of the remote virtual network address space.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IAddressSpace RemoteAddressSpace { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        string[] RemoteAddressSpaceAddressPrefix { get; set; }
        /// <summary>
        /// The reference of the remote virtual network. The remote virtual network can be in the same or different region (preview).
        /// See here to register for the preview and learn more (https://docs.microsoft.com/en-us/azure/virtual-network/virtual-network-create-peering).
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource RemoteVnet { get; set; }
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