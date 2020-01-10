namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the express route circuit connection.</summary>
    public partial class ExpressRouteCircuitConnectionPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitConnectionPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitConnectionPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="AddressPrefix" /> property.</summary>
        private string _addressPrefix;

        /// <summary>/29 IP address space to carve out Customer addresses for tunnels.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AddressPrefix { get => this._addressPrefix; set => this._addressPrefix = value; }

        /// <summary>Backing field for <see cref="AuthorizationKey" /> property.</summary>
        private string _authorizationKey;

        /// <summary>The authorization key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AuthorizationKey { get => this._authorizationKey; set => this._authorizationKey = value; }

        /// <summary>Backing field for <see cref="CircuitConnectionStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus? _circuitConnectionStatus;

        /// <summary>Express Route Circuit connection state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus? CircuitConnectionStatus { get => this._circuitConnectionStatus; }

        /// <summary>Backing field for <see cref="ExpressRouteCircuitPeering" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _expressRouteCircuitPeering;

        /// <summary>
        /// Reference to Express Route Circuit Private Peering Resource of the circuit initiating connection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource ExpressRouteCircuitPeering { get => (this._expressRouteCircuitPeering = this._expressRouteCircuitPeering ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._expressRouteCircuitPeering = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ExpressRouteCircuitPeeringId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)ExpressRouteCircuitPeering).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)ExpressRouteCircuitPeering).Id = value; }

        /// <summary>Internal Acessors for CircuitConnectionStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitConnectionPropertiesFormatInternal.CircuitConnectionStatus { get => this._circuitConnectionStatus; set { {_circuitConnectionStatus = value;} } }

        /// <summary>Internal Acessors for ExpressRouteCircuitPeering</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitConnectionPropertiesFormatInternal.ExpressRouteCircuitPeering { get => (this._expressRouteCircuitPeering = this._expressRouteCircuitPeering ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_expressRouteCircuitPeering = value;} } }

        /// <summary>Internal Acessors for PeerExpressRouteCircuitPeering</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitConnectionPropertiesFormatInternal.PeerExpressRouteCircuitPeering { get => (this._peerExpressRouteCircuitPeering = this._peerExpressRouteCircuitPeering ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_peerExpressRouteCircuitPeering = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitConnectionPropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

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
        /// Provisioning state of the circuit connection resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>
        /// Creates an new <see cref="ExpressRouteCircuitConnectionPropertiesFormat" /> instance.
        /// </summary>
        public ExpressRouteCircuitConnectionPropertiesFormat()
        {

        }
    }
    /// Properties of the express route circuit connection.
    public partial interface IExpressRouteCircuitConnectionPropertiesFormat :
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
        /// <summary>The authorization key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The authorization key.",
        SerializedName = @"authorizationKey",
        PossibleTypes = new [] { typeof(string) })]
        string AuthorizationKey { get; set; }
        /// <summary>Express Route Circuit connection state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Express Route Circuit connection state.",
        SerializedName = @"circuitConnectionStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus? CircuitConnectionStatus { get;  }
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
        /// Provisioning state of the circuit connection resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the circuit connection resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }

    }
    /// Properties of the express route circuit connection.
    internal partial interface IExpressRouteCircuitConnectionPropertiesFormatInternal

    {
        /// <summary>/29 IP address space to carve out Customer addresses for tunnels.</summary>
        string AddressPrefix { get; set; }
        /// <summary>The authorization key.</summary>
        string AuthorizationKey { get; set; }
        /// <summary>Express Route Circuit connection state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.CircuitConnectionStatus? CircuitConnectionStatus { get; set; }
        /// <summary>
        /// Reference to Express Route Circuit Private Peering Resource of the circuit initiating connection.
        /// </summary>
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
        /// Provisioning state of the circuit connection resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }

    }
}