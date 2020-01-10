namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// Peer Express Route Circuit Connection in an ExpressRouteCircuitPeering resource.
    /// </summary>
    public partial class PeerExpressRouteCircuitConnection :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnection,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource();

        /// <summary>/29 IP address space to carve out Customer addresses for tunnels.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string AddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).AddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).AddressPrefix = value; }

        /// <summary>
        /// The resource guid of the authorization used for the express route circuit connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string AuthResourceGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).AuthResourceGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).AuthResourceGuid = value; }

        /// <summary>Express Route Circuit connection state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus? CircuitConnectionStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).CircuitConnectionStatus; }

        /// <summary>The name of the express route circuit connection resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ConnectionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).ConnectionName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).ConnectionName = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ExpressRouteCircuitPeeringId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).ExpressRouteCircuitPeeringId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).ExpressRouteCircuitPeeringId = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>Internal Acessors for CircuitConnectionStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal.CircuitConnectionStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).CircuitConnectionStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).CircuitConnectionStatus = value; }

        /// <summary>Internal Acessors for Etag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal.Etag { get => this._etag; set { {_etag = value;} } }

        /// <summary>Internal Acessors for ExpressRouteCircuitPeering</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal.ExpressRouteCircuitPeering { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).ExpressRouteCircuitPeering; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).ExpressRouteCircuitPeering = value; }

        /// <summary>Internal Acessors for PeerExpressRouteCircuitPeering</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal.PeerExpressRouteCircuitPeering { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).PeerExpressRouteCircuitPeering; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).PeerExpressRouteCircuitPeering = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PeerExpressRouteCircuitConnectionPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PeerExpressRouteCircuitPeeringId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).PeerExpressRouteCircuitPeeringId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).PeerExpressRouteCircuitPeeringId = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormat _property;

        /// <summary>Properties of the peer express route circuit connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PeerExpressRouteCircuitConnectionPropertiesFormat()); set => this._property = value; }

        /// <summary>
        /// Provisioning state of the peer express route circuit connection resource. Possible values are: 'Succeeded', 'Updating',
        /// 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal)Property).ProvisioningState; }

        /// <summary>Creates an new <see cref="PeerExpressRouteCircuitConnection" /> instance.</summary>
        public PeerExpressRouteCircuitConnection()
        {

        }

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
    }
    /// Peer Express Route Circuit Connection in an ExpressRouteCircuitPeering resource.
    public partial interface IPeerExpressRouteCircuitConnection :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource
    {
        /// <summary>/29 IP address space to carve out Customer addresses for tunnels.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"/29 IP address space to carve out Customer addresses for tunnels.",
        SerializedName = @"addressPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string AddressPrefix { get; set; }
        /// <summary>
        /// The resource guid of the authorization used for the express route circuit connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource guid of the authorization used for the express route circuit connection.",
        SerializedName = @"authResourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string AuthResourceGuid { get; set; }
        /// <summary>Express Route Circuit connection state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Express Route Circuit connection state.",
        SerializedName = @"circuitConnectionStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus? CircuitConnectionStatus { get;  }
        /// <summary>The name of the express route circuit connection resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the express route circuit connection resource.",
        SerializedName = @"connectionName",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionName { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get;  }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ExpressRouteCircuitPeeringId { get; set; }
        /// <summary>
        /// Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets name of the resource that is unique within a resource group. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string PeerExpressRouteCircuitPeeringId { get; set; }
        /// <summary>
        /// Provisioning state of the peer express route circuit connection resource. Possible values are: 'Succeeded', 'Updating',
        /// 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the peer express route circuit connection resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }

    }
    /// Peer Express Route Circuit Connection in an ExpressRouteCircuitPeering resource.
    internal partial interface IPeerExpressRouteCircuitConnectionInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal
    {
        /// <summary>/29 IP address space to carve out Customer addresses for tunnels.</summary>
        string AddressPrefix { get; set; }
        /// <summary>
        /// The resource guid of the authorization used for the express route circuit connection.
        /// </summary>
        string AuthResourceGuid { get; set; }
        /// <summary>Express Route Circuit connection state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus? CircuitConnectionStatus { get; set; }
        /// <summary>The name of the express route circuit connection resource.</summary>
        string ConnectionName { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>Reference to Express Route Circuit Private Peering Resource of the circuit.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource ExpressRouteCircuitPeering { get; set; }
        /// <summary>Resource ID.</summary>
        string ExpressRouteCircuitPeeringId { get; set; }
        /// <summary>
        /// Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Reference to Express Route Circuit Private Peering Resource of the peered circuit.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource PeerExpressRouteCircuitPeering { get; set; }
        /// <summary>Resource ID.</summary>
        string PeerExpressRouteCircuitPeeringId { get; set; }
        /// <summary>Properties of the peer express route circuit connection.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormat Property { get; set; }
        /// <summary>
        /// Provisioning state of the peer express route circuit connection resource. Possible values are: 'Succeeded', 'Updating',
        /// 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }

    }
}