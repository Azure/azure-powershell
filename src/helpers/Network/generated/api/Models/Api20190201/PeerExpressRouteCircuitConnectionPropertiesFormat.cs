namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the peer express route circuit connection.</summary>
    public partial class PeerExpressRouteCircuitConnectionPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="AddressPrefix" /> property.</summary>
        private string _addressPrefix;

        /// <summary>/29 IP address space to carve out Customer addresses for tunnels.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AddressPrefix { get => this._addressPrefix; set => this._addressPrefix = value; }

        /// <summary>Backing field for <see cref="AuthResourceGuid" /> property.</summary>
        private string _authResourceGuid;

        /// <summary>
        /// The resource guid of the authorization used for the express route circuit connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AuthResourceGuid { get => this._authResourceGuid; set => this._authResourceGuid = value; }

        /// <summary>Backing field for <see cref="CircuitConnectionStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus? _circuitConnectionStatus;

        /// <summary>Express Route Circuit connection state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus? CircuitConnectionStatus { get => this._circuitConnectionStatus; }

        /// <summary>Backing field for <see cref="ConnectionName" /> property.</summary>
        private string _connectionName;

        /// <summary>The name of the express route circuit connection resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ConnectionName { get => this._connectionName; set => this._connectionName = value; }

        /// <summary>Backing field for <see cref="ExpressRouteCircuitPeering" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _expressRouteCircuitPeering;

        /// <summary>Reference to Express Route Circuit Private Peering Resource of the circuit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource ExpressRouteCircuitPeering { get => (this._expressRouteCircuitPeering = this._expressRouteCircuitPeering ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._expressRouteCircuitPeering = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ExpressRouteCircuitPeeringId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)ExpressRouteCircuitPeering).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)ExpressRouteCircuitPeering).Id = value; }

        /// <summary>Internal Acessors for CircuitConnectionStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal.CircuitConnectionStatus { get => this._circuitConnectionStatus; set { {_circuitConnectionStatus = value;} } }

        /// <summary>Internal Acessors for ExpressRouteCircuitPeering</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal.ExpressRouteCircuitPeering { get => (this._expressRouteCircuitPeering = this._expressRouteCircuitPeering ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_expressRouteCircuitPeering = value;} } }

        /// <summary>Internal Acessors for PeerExpressRouteCircuitPeering</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal.PeerExpressRouteCircuitPeering { get => (this._peerExpressRouteCircuitPeering = this._peerExpressRouteCircuitPeering ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_peerExpressRouteCircuitPeering = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPeerExpressRouteCircuitConnectionPropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="PeerExpressRouteCircuitPeering" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _peerExpressRouteCircuitPeering;

        /// <summary>
        /// Reference to Express Route Circuit Private Peering Resource of the peered circuit.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource PeerExpressRouteCircuitPeering { get => (this._peerExpressRouteCircuitPeering = this._peerExpressRouteCircuitPeering ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._peerExpressRouteCircuitPeering = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PeerExpressRouteCircuitPeeringId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)PeerExpressRouteCircuitPeering).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)PeerExpressRouteCircuitPeering).Id = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Provisioning state of the peer express route circuit connection resource. Possible values are: 'Succeeded', 'Updating',
        /// 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>
        /// Creates an new <see cref="PeerExpressRouteCircuitConnectionPropertiesFormat" /> instance.
        /// </summary>
        public PeerExpressRouteCircuitConnectionPropertiesFormat()
        {

        }
    }
    /// Properties of the peer express route circuit connection.
    public partial interface IPeerExpressRouteCircuitConnectionPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
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
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ExpressRouteCircuitPeeringId { get; set; }
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
    /// Properties of the peer express route circuit connection.
    internal partial interface IPeerExpressRouteCircuitConnectionPropertiesFormatInternal

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
        /// <summary>Reference to Express Route Circuit Private Peering Resource of the circuit.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource ExpressRouteCircuitPeering { get; set; }
        /// <summary>Resource ID.</summary>
        string ExpressRouteCircuitPeeringId { get; set; }
        /// <summary>
        /// Reference to Express Route Circuit Private Peering Resource of the peered circuit.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource PeerExpressRouteCircuitPeering { get; set; }
        /// <summary>Resource ID.</summary>
        string PeerExpressRouteCircuitPeeringId { get; set; }
        /// <summary>
        /// Provisioning state of the peer express route circuit connection resource. Possible values are: 'Succeeded', 'Updating',
        /// 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }

    }
}