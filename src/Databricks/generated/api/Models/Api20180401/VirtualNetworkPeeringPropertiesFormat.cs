namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>Properties of the virtual network peering.</summary>
    public partial class VirtualNetworkPeeringPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="AllowForwardedTraffic" /> property.</summary>
        private bool? _allowForwardedTraffic;

        /// <summary>
        /// Whether the forwarded traffic from the VMs in the local virtual network will be allowed/disallowed in remote virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public bool? AllowForwardedTraffic { get => this._allowForwardedTraffic; set => this._allowForwardedTraffic = value; }

        /// <summary>Backing field for <see cref="AllowGatewayTransit" /> property.</summary>
        private bool? _allowGatewayTransit;

        /// <summary>
        /// If gateway links can be used in remote virtual networking to link to this virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public bool? AllowGatewayTransit { get => this._allowGatewayTransit; set => this._allowGatewayTransit = value; }

        /// <summary>Backing field for <see cref="AllowVirtualNetworkAccess" /> property.</summary>
        private bool? _allowVirtualNetworkAccess;

        /// <summary>
        /// Whether the VMs in the local virtual network space would be able to access the VMs in remote virtual network space.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public bool? AllowVirtualNetworkAccess { get => this._allowVirtualNetworkAccess; set => this._allowVirtualNetworkAccess = value; }

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string[] DatabrickAddressSpaceAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpaceInternal)DatabricksAddressSpace).AddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpaceInternal)DatabricksAddressSpace).AddressPrefix = value ?? null /* arrayOf */; }

        /// <summary>The Id of the databricks virtual network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string DatabrickVirtualNetworkId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetworkInternal)DatabricksVirtualNetwork).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetworkInternal)DatabricksVirtualNetwork).Id = value ?? null; }

        /// <summary>Backing field for <see cref="DatabricksAddressSpace" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace _databricksAddressSpace;

        /// <summary>The reference to the databricks virtual network address space.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace DatabricksAddressSpace { get => (this._databricksAddressSpace = this._databricksAddressSpace ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.AddressSpace()); set => this._databricksAddressSpace = value; }

        /// <summary>Backing field for <see cref="DatabricksVirtualNetwork" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork _databricksVirtualNetwork;

        /// <summary>
        /// The remote virtual network should be in the same region. See here to learn more (https://docs.microsoft.com/en-us/azure/databricks/administration-guide/cloud-configurations/azure/vnet-peering).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork DatabricksVirtualNetwork { get => (this._databricksVirtualNetwork = this._databricksVirtualNetwork ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork()); set => this._databricksVirtualNetwork = value; }

        /// <summary>Internal Acessors for DatabricksAddressSpace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal.DatabricksAddressSpace { get => (this._databricksAddressSpace = this._databricksAddressSpace ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.AddressSpace()); set { {_databricksAddressSpace = value;} } }

        /// <summary>Internal Acessors for DatabricksVirtualNetwork</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal.DatabricksVirtualNetwork { get => (this._databricksVirtualNetwork = this._databricksVirtualNetwork ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork()); set { {_databricksVirtualNetwork = value;} } }

        /// <summary>Internal Acessors for PeeringState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal.PeeringState { get => this._peeringState; set { {_peeringState = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for RemoteAddressSpace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal.RemoteAddressSpace { get => (this._remoteAddressSpace = this._remoteAddressSpace ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.AddressSpace()); set { {_remoteAddressSpace = value;} } }

        /// <summary>Internal Acessors for RemoteVirtualNetwork</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatRemoteVirtualNetwork Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatInternal.RemoteVirtualNetwork { get => (this._remoteVirtualNetwork = this._remoteVirtualNetwork ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormatRemoteVirtualNetwork()); set { {_remoteVirtualNetwork = value;} } }

        /// <summary>Backing field for <see cref="PeeringState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState? _peeringState;

        /// <summary>The status of the virtual network peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState? PeeringState { get => this._peeringState; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState? _provisioningState;

        /// <summary>The provisioning state of the virtual network peering resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="RemoteAddressSpace" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace _remoteAddressSpace;

        /// <summary>The reference to the remote virtual network address space.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpace RemoteAddressSpace { get => (this._remoteAddressSpace = this._remoteAddressSpace ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.AddressSpace()); set => this._remoteAddressSpace = value; }

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string[] RemoteAddressSpaceAddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpaceInternal)RemoteAddressSpace).AddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IAddressSpaceInternal)RemoteAddressSpace).AddressPrefix = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="RemoteVirtualNetwork" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatRemoteVirtualNetwork _remoteVirtualNetwork;

        /// <summary>
        /// The remote virtual network should be in the same region. See here to learn more (https://docs.microsoft.com/en-us/azure/databricks/administration-guide/cloud-configurations/azure/vnet-peering).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatRemoteVirtualNetwork RemoteVirtualNetwork { get => (this._remoteVirtualNetwork = this._remoteVirtualNetwork ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormatRemoteVirtualNetwork()); set => this._remoteVirtualNetwork = value; }

        /// <summary>The Id of the remote virtual network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string RemoteVirtualNetworkId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatRemoteVirtualNetworkInternal)RemoteVirtualNetwork).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatRemoteVirtualNetworkInternal)RemoteVirtualNetwork).Id = value ?? null; }

        /// <summary>Backing field for <see cref="UseRemoteGateway" /> property.</summary>
        private bool? _useRemoteGateway;

        /// <summary>
        /// If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote
        /// peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have
        /// this flag set to true. This flag cannot be set if virtual network already has a gateway.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public bool? UseRemoteGateway { get => this._useRemoteGateway; set => this._useRemoteGateway = value; }

        /// <summary>Creates an new <see cref="VirtualNetworkPeeringPropertiesFormat" /> instance.</summary>
        public VirtualNetworkPeeringPropertiesFormat()
        {

        }
    }
    /// Properties of the virtual network peering.
    public partial interface IVirtualNetworkPeeringPropertiesFormat :
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
        /// <summary>The status of the virtual network peering.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.PeeringState? PeeringState { get; set; }
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
        /// <summary>
        /// If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote
        /// peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have
        /// this flag set to true. This flag cannot be set if virtual network already has a gateway.
        /// </summary>
        bool? UseRemoteGateway { get; set; }

    }
}