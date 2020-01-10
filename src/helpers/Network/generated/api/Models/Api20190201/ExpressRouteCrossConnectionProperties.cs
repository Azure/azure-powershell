namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of ExpressRouteCrossConnection.</summary>
    public partial class ExpressRouteCrossConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="BandwidthInMbps" /> property.</summary>
        private int? _bandwidthInMbps;

        /// <summary>The circuit bandwidth In Mbps.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? BandwidthInMbps { get => this._bandwidthInMbps; set => this._bandwidthInMbps = value; }

        /// <summary>Backing field for <see cref="ExpressRouteCircuit" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitReference _expressRouteCircuit;

        /// <summary>The ExpressRouteCircuit</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitReference ExpressRouteCircuit { get => (this._expressRouteCircuit = this._expressRouteCircuit ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteCircuitReference()); set => this._expressRouteCircuit = value; }

        /// <summary>Corresponding Express Route Circuit Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ExpressRouteCircuitId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitReferenceInternal)ExpressRouteCircuit).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitReferenceInternal)ExpressRouteCircuit).Id = value; }

        /// <summary>Internal Acessors for ExpressRouteCircuit</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitReference Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPropertiesInternal.ExpressRouteCircuit { get => (this._expressRouteCircuit = this._expressRouteCircuit ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteCircuitReference()); set { {_expressRouteCircuit = value;} } }

        /// <summary>Internal Acessors for PrimaryAzurePort</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPropertiesInternal.PrimaryAzurePort { get => this._primaryAzurePort; set { {_primaryAzurePort = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for STag</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPropertiesInternal.STag { get => this._sTag; set { {_sTag = value;} } }

        /// <summary>Internal Acessors for SecondaryAzurePort</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPropertiesInternal.SecondaryAzurePort { get => this._secondaryAzurePort; set { {_secondaryAzurePort = value;} } }

        /// <summary>Backing field for <see cref="Peering" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeering[] _peering;

        /// <summary>The list of peerings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeering[] Peering { get => this._peering; set => this._peering = value; }

        /// <summary>Backing field for <see cref="PeeringLocation" /> property.</summary>
        private string _peeringLocation;

        /// <summary>The peering location of the ExpressRoute circuit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PeeringLocation { get => this._peeringLocation; set => this._peeringLocation = value; }

        /// <summary>Backing field for <see cref="PrimaryAzurePort" /> property.</summary>
        private string _primaryAzurePort;

        /// <summary>The name of the primary port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PrimaryAzurePort { get => this._primaryAzurePort; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="STag" /> property.</summary>
        private int? _sTag;

        /// <summary>The identifier of the circuit traffic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? STag { get => this._sTag; }

        /// <summary>Backing field for <see cref="SecondaryAzurePort" /> property.</summary>
        private string _secondaryAzurePort;

        /// <summary>The name of the secondary port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string SecondaryAzurePort { get => this._secondaryAzurePort; }

        /// <summary>Backing field for <see cref="ServiceProviderNote" /> property.</summary>
        private string _serviceProviderNote;

        /// <summary>Additional read only notes set by the connectivity provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ServiceProviderNote { get => this._serviceProviderNote; set => this._serviceProviderNote = value; }

        /// <summary>Backing field for <see cref="ServiceProviderProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState? _serviceProviderProvisioningState;

        /// <summary>The provisioning state of the circuit in the connectivity provider system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState? ServiceProviderProvisioningState { get => this._serviceProviderProvisioningState; set => this._serviceProviderProvisioningState = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCrossConnectionProperties" /> instance.</summary>
        public ExpressRouteCrossConnectionProperties()
        {

        }
    }
    /// Properties of ExpressRouteCrossConnection.
    public partial interface IExpressRouteCrossConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The circuit bandwidth In Mbps.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The circuit bandwidth In Mbps.",
        SerializedName = @"bandwidthInMbps",
        PossibleTypes = new [] { typeof(int) })]
        int? BandwidthInMbps { get; set; }
        /// <summary>Corresponding Express Route Circuit Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Corresponding Express Route Circuit Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ExpressRouteCircuitId { get; set; }
        /// <summary>The list of peerings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of peerings.",
        SerializedName = @"peerings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeering) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeering[] Peering { get; set; }
        /// <summary>The peering location of the ExpressRoute circuit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The peering location of the ExpressRoute circuit.",
        SerializedName = @"peeringLocation",
        PossibleTypes = new [] { typeof(string) })]
        string PeeringLocation { get; set; }
        /// <summary>The name of the primary port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the primary  port.",
        SerializedName = @"primaryAzurePort",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryAzurePort { get;  }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The identifier of the circuit traffic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The identifier of the circuit traffic.",
        SerializedName = @"sTag",
        PossibleTypes = new [] { typeof(int) })]
        int? STag { get;  }
        /// <summary>The name of the secondary port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the secondary  port.",
        SerializedName = @"secondaryAzurePort",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryAzurePort { get;  }
        /// <summary>Additional read only notes set by the connectivity provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Additional read only notes set by the connectivity provider.",
        SerializedName = @"serviceProviderNotes",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceProviderNote { get; set; }
        /// <summary>The provisioning state of the circuit in the connectivity provider system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the circuit in the connectivity provider system.",
        SerializedName = @"serviceProviderProvisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState? ServiceProviderProvisioningState { get; set; }

    }
    /// Properties of ExpressRouteCrossConnection.
    internal partial interface IExpressRouteCrossConnectionPropertiesInternal

    {
        /// <summary>The circuit bandwidth In Mbps.</summary>
        int? BandwidthInMbps { get; set; }
        /// <summary>The ExpressRouteCircuit</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitReference ExpressRouteCircuit { get; set; }
        /// <summary>Corresponding Express Route Circuit Id.</summary>
        string ExpressRouteCircuitId { get; set; }
        /// <summary>The list of peerings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeering[] Peering { get; set; }
        /// <summary>The peering location of the ExpressRoute circuit.</summary>
        string PeeringLocation { get; set; }
        /// <summary>The name of the primary port.</summary>
        string PrimaryAzurePort { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The identifier of the circuit traffic.</summary>
        int? STag { get; set; }
        /// <summary>The name of the secondary port.</summary>
        string SecondaryAzurePort { get; set; }
        /// <summary>Additional read only notes set by the connectivity provider.</summary>
        string ServiceProviderNote { get; set; }
        /// <summary>The provisioning state of the circuit in the connectivity provider system.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState? ServiceProviderProvisioningState { get; set; }

    }
}