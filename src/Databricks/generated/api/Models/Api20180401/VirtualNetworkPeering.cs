namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>Peerings in a VirtualNetwork resource</summary>
    public partial class VirtualNetworkPeering :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeering,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal
    {

        /// <summary>
        /// Whether the forwarded traffic from the VMs in the local virtual network will be allowed/disallowed in remote virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public bool? AllowForwardedTraffic { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).AllowForwardedTraffic; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).AllowForwardedTraffic = value ?? default(bool); }

        /// <summary>
        /// If gateway links can be used in remote virtual networking to link to this virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public bool? AllowGatewayTransit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).AllowGatewayTransit; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).AllowGatewayTransit = value ?? default(bool); }

        /// <summary>
        /// Whether the VMs in the local virtual network space would be able to access the VMs in remote virtual network space.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public bool? AllowVirtualNetworkAccess { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).AllowVirtualNetworkAccess; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).AllowVirtualNetworkAccess = value ?? default(bool); }

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string[] DatabrickAddressSpaceAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).DatabrickAddressSpaceAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).DatabrickAddressSpaceAddressPrefix = value ?? null /* arrayOf */; }

        /// <summary>The Id of the databricks virtual network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string DatabrickVirtualNetworkId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).DatabrickVirtualNetworkId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).DatabrickVirtualNetworkId = value ?? null; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Internal Acessors for DatabricksAddressSpace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal.DatabricksAddressSpace { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).DatabricksAddressSpace; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).DatabricksAddressSpace = value; }

        /// <summary>Internal Acessors for DatabricksVirtualNetwork</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal.DatabricksVirtualNetwork { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).DatabricksVirtualNetwork; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).DatabricksVirtualNetwork = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for PeeringState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal.PeeringState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).PeeringState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).PeeringState = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for RemoteAddressSpace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal.RemoteAddressSpace { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).RemoteAddressSpace; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).RemoteAddressSpace = value; }

        /// <summary>Internal Acessors for RemoteVirtualNetwork</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatRemoteVirtualNetwork Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal.RemoteVirtualNetwork { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).RemoteVirtualNetwork; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).RemoteVirtualNetwork = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the virtual network peering resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>The status of the virtual network peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState? PeeringState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).PeeringState; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormat _property;

        /// <summary>List of properties for vNet Peering</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormat()); set => this._property = value; }

        /// <summary>The provisioning state of the virtual network peering resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).ProvisioningState; }

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string[] RemoteAddressSpaceAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).RemoteAddressSpaceAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).RemoteAddressSpaceAddressPrefix = value ?? null /* arrayOf */; }

        /// <summary>The Id of the remote virtual network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string RemoteVirtualNetworkId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).RemoteVirtualNetworkId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).RemoteVirtualNetworkId = value ?? null; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>type of the virtual network peering resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>
        /// If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote
        /// peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have
        /// this flag set to true. This flag cannot be set if virtual network already has a gateway.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public bool? UseRemoteGateway { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).UseRemoteGateway; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal)Property).UseRemoteGateway = value ?? default(bool); }

        /// <summary>Creates an new <see cref="VirtualNetworkPeering" /> instance.</summary>
        public VirtualNetworkPeering()
        {

        }
    }
    /// Peerings in a VirtualNetwork resource
    public partial interface IVirtualNetworkPeering :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Whether the forwarded traffic from the VMs in the local virtual network will be allowed/disallowed in remote virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the forwarded traffic from the VMs in the local virtual network will be allowed/disallowed in remote virtual network.",
        SerializedName = @"allowForwardedTraffic",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowForwardedTraffic { get; set; }
        /// <summary>
        /// If gateway links can be used in remote virtual networking to link to this virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If gateway links can be used in remote virtual networking to link to this virtual network.",
        SerializedName = @"allowGatewayTransit",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowGatewayTransit { get; set; }
        /// <summary>
        /// Whether the VMs in the local virtual network space would be able to access the VMs in remote virtual network space.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether the VMs in the local virtual network space would be able to access the VMs in remote virtual network space.",
        SerializedName = @"allowVirtualNetworkAccess",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowVirtualNetworkAccess { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of address blocks reserved for this virtual network in CIDR notation.",
        SerializedName = @"addressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] DatabrickAddressSpaceAddressPrefix { get; set; }
        /// <summary>The Id of the databricks virtual network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Id of the databricks virtual network.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string DatabrickVirtualNetworkId { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Name of the virtual network peering resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the virtual network peering resource",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>The status of the virtual network peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The status of the virtual network peering.",
        SerializedName = @"peeringState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState? PeeringState { get;  }
        /// <summary>The provisioning state of the virtual network peering resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the virtual network peering resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState? ProvisioningState { get;  }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of address blocks reserved for this virtual network in CIDR notation.",
        SerializedName = @"addressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] RemoteAddressSpaceAddressPrefix { get; set; }
        /// <summary>The Id of the remote virtual network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Id of the remote virtual network.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string RemoteVirtualNetworkId { get; set; }
        /// <summary>type of the virtual network peering resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"type of the virtual network peering resource",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }
        /// <summary>
        /// If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote
        /// peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have
        /// this flag set to true. This flag cannot be set if virtual network already has a gateway.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have this flag set to true. This flag cannot be set if virtual network already has a gateway.",
        SerializedName = @"useRemoteGateways",
        PossibleTypes = new [] { typeof(bool) })]
        bool? UseRemoteGateway { get; set; }

    }
    /// Peerings in a VirtualNetwork resource
    internal partial interface IVirtualNetworkPeeringInternal

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
        bool? AllowVirtualNetworkAccess { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        string[] DatabrickAddressSpaceAddressPrefix { get; set; }
        /// <summary>The Id of the databricks virtual network.</summary>
        string DatabrickVirtualNetworkId { get; set; }
        /// <summary>The reference to the databricks virtual network address space.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace DatabricksAddressSpace { get; set; }
        /// <summary>
        /// The remote virtual network should be in the same region. See here to learn more (https://docs.microsoft.com/en-us/azure/databricks/administration-guide/cloud-configurations/azure/vnet-peering).
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork DatabricksVirtualNetwork { get; set; }
        /// <summary>Resource ID.</summary>
        string Id { get; set; }
        /// <summary>Name of the virtual network peering resource</summary>
        string Name { get; set; }
        /// <summary>The status of the virtual network peering.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState? PeeringState { get; set; }
        /// <summary>List of properties for vNet Peering</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormat Property { get; set; }
        /// <summary>The provisioning state of the virtual network peering resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState? ProvisioningState { get; set; }
        /// <summary>The reference to the remote virtual network address space.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace RemoteAddressSpace { get; set; }
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        string[] RemoteAddressSpaceAddressPrefix { get; set; }
        /// <summary>
        /// The remote virtual network should be in the same region. See here to learn more (https://docs.microsoft.com/en-us/azure/databricks/administration-guide/cloud-configurations/azure/vnet-peering).
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatRemoteVirtualNetwork RemoteVirtualNetwork { get; set; }
        /// <summary>The Id of the remote virtual network.</summary>
        string RemoteVirtualNetworkId { get; set; }
        /// <summary>type of the virtual network peering resource</summary>
        string Type { get; set; }
        /// <summary>
        /// If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote
        /// peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have
        /// this flag set to true. This flag cannot be set if virtual network already has a gateway.
        /// </summary>
        bool? UseRemoteGateway { get; set; }

    }
}